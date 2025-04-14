using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SDCafeCommon.Utilities;
using SDCafeCommon.PinPad;
using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;

namespace SDCafeSales.Views
{
    public partial class frmCardPayment : Form
    {
        frmSalesMain FrmSalesMain;
        TcpClient tcpClient;
        string input;
        int port;
        int recv;
        string stringData;
        Utility util = new Utility();
        

        CCardProcess CardProcess = new CCardProcess();
        //float p_TenderAmt;
        //float p_TipAmt;
        int p_InvoiceNo;

        string p_Station;
        string p_UserName;
        string p_UserPassCode;
        List<POS_StationModel> stations = new List<POS_StationModel>();
        public Boolean bPaymentComplete;
        public Boolean bCashPayment;
        public string strHostResponseCode;
        public string strPaymentType { get; set; }

        public float p_TipAmt { get; set; }

        public float p_TenderAmt { get; set; }

        public bool p_blnPaymentree { get; set; }
        public string p_strTranType { get; set; } // Purchase, Void, Refund, PreAuth, PreAuthComplete, CloseBatch, GetBatchTotal

        POS_PmTreeTranModel posPmTreeTran = new POS_PmTreeTranModel();
        POS_PmTreeRespModel posPmTreeResp = new POS_PmTreeRespModel();
        //CardReceipt to Void
        List<CCardReceipt> cardReceipts = new List<CCardReceipt>();

        // create a enum for the different transaction types
        //public enum PTActionTypes : int
        public Dictionary<string, string> PTActionTypes = new Dictionary<string, string>()
        {
            {"Purchase","00" },
            {"Tokenization","09"},
            {"Refund","10"},
            {"PreAuth","17"},
            {"PreAuthComplete","18"},
            {"Void","30"},
            {"CommitTrans","40"},
            {"CloseBatch","51"},
            {"GetBatchTotal","56"}
        };
        //public enum PTRequestType : int
        public Dictionary<string, string> PTRequestType = new Dictionary<string, string>()
        {
            {"Card","00" },
            {"EBT","15" }
        };
        public frmCardPayment(frmSalesMain _FrmSalesMain)
        {
            InitializeComponent();
            this.FrmSalesMain = _FrmSalesMain;
        }
        public void Set_TenderAmt(double pTenderAmt)
        {
            p_TenderAmt = (float)Math.Round(pTenderAmt,2);
            lblAmount.Text = "Amount is " + pTenderAmt.ToString("C2");
        }
        public void Set_InvoiceNo(int pInvoiceNo)
        {
            p_InvoiceNo = pInvoiceNo;
            lblInvoiceNo.Text = "Invoice # : " + p_InvoiceNo.ToString("D6");
        }
        public void Set_Station(string pStation)
        {
            p_Station = pStation;
            lblStation.Text = "Station # : " + pStation;
        }
        public void Set_UserName(string pUserName)
        {
            p_UserName = pUserName;
            lblUerName.Text = "Served by : " + pUserName;
        }
        public void Set_UserPassCode(string pUserPassCode)
        {
            p_UserPassCode = pUserPassCode;
        }
        //public Boolean bPaymentComplete { get; private set; }
        private void frmCardPayment_Load(object sender, EventArgs e)
        {
            p_blnPaymentree = false;
            dgv_CardData_Initialize();
            if (Get_PinPad_Information())
            {
                lblStatus.Text = "Pinpad is ready!";
                bt_PayPinPad.Enabled = true;
                bt_PayPinPad.PerformClick();
                //return;
            }
            else
            {
                lblStatus.Text = "Only Cash or Manual payment are available!";
                bt_PayPinPad.Enabled = false;
            }
            bPaymentComplete = false;
            bCashPayment = false;
            strPaymentType = "";
            p_TipAmt = 0;

            util.Logger("frmCardPayment is now loaded ! TranType = " + p_strTranType);

            timer1.Interval = 2000;
            timer1.Enabled = true;
            timer1.Start();
        }
        private bool Get_PinPad_Information()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            stations.Clear();
            stations = dbPOS.Get_Station_By_Station(p_Station);
            p_blnPaymentree = false;
            if (stations.Count > 0)
            {
                text_IPADDR.Text = stations[0].IP_Addr;
                text_PortNo.Text = stations[0].IPS_Port.ToString();
                if (
                    (stations[0].IsPaymentree) 
                    && (!string.IsNullOrEmpty(stations[0].Client_Id)) 
                    && (!string.IsNullOrEmpty(stations[0].Location))
                    && (!string.IsNullOrEmpty(stations[0].Register))
                    )
                {
                    p_blnPaymentree = true;
                }
                return Check_PinPad_Connectivity();
            }
            else
            {
                text_IPADDR.Text = "192.168.1.189";
                text_PortNo.Text = "7788";
            }
            return false;
        }

        private bool Check_PinPad_Connectivity()
        {
            int portNo = 0;
            portNo = int.Parse(text_PortNo.Text);

            if (string.IsNullOrEmpty(text_IPADDR.Text))
            {
                //MessageBox.Show("Please check database : Station data empty");
                util.Logger("Please check PinPad : " + text_IPADDR.Text + "," + text_PortNo.Text);
                return false;
            }

            //clientSocket.Connect(text_IPADDR.Text, portNo);
            try
            {
                if (tcpClient != null)
                {
                    if (tcpClient.Connected)
                    {
                        tcpClient.Close();
                    }
                }
                tcpClient = new TcpClient(text_IPADDR.Text, portNo);
                tcpClient.SendTimeout = 5000;
                tcpClient.ReceiveTimeout = 5000;
            }
            catch (SocketException e)
            {
                this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "Unable to connect to server" });
                util.Logger("Unable to connect to PinPad : " + e.ErrorCode + " , " + e.Message + " : " + text_IPADDR.Text + "," + text_PortNo.Text);
                return false;
            }
            this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "Connected to Server..." });
            util.Logger("PinPad connected : " + text_IPADDR.Text + "," + text_PortNo.Text);
            return true;
        }

        private void dgv_CardData_Initialize()
        {
            this.dgv_CardData.AutoSize = false;
            dgv_CardData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgv_CardData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv_CardData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_CardData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgv_CardData.ColumnCount = 2;
            this.dgv_CardData.Columns[0].Name = "DateTime";
            this.dgv_CardData.Columns[0].Width = 50;
            this.dgv_CardData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_CardData.Columns[1].Name = "Data";
            this.dgv_CardData.Columns[1].Width = 400;
            this.dgv_CardData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgv_CardData.DefaultCellStyle.Font = new Font("Arial", 14F, FontStyle.Bold);
            this.dgv_CardData.EnableHeadersVisualStyles = false;
            this.dgv_CardData.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.dgv_CardData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_CardData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgv_CardData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv_CardData.AllowUserToResizeRows = false;
            dgv_CardData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgv_CardData.RowTemplate.MinimumHeight = 50;
            dgv_CardData.AllowUserToAddRows = false;
        }

        private void bt_Connect_Click(object sender, EventArgs e)
        {
            int portNo = 0;
            portNo = int.Parse(text_PortNo.Text);

            if (string.IsNullOrEmpty(text_IPADDR.Text))
            {
                MessageBox.Show("Please check database : Station data empty");
                return;
            }

            //clientSocket.Connect(text_IPADDR.Text, portNo);
            try
            {
                tcpClient = new TcpClient(text_IPADDR.Text, portNo);
                tcpClient.SendTimeout = 5000;
                tcpClient.ReceiveTimeout = 5000;
            }
            catch (SocketException)
            {
                this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "Unable to connect to server" });
                util.Logger("Unable to connect to PinPad : " + text_IPADDR + "," + portNo);
                bt_PayPinPad.Enabled = false;
                return;
            }
            this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "Connected to Server..." });
            util.Logger("PinPad connected : " + text_IPADDR + "," + portNo);
            bt_PayPinPad.Enabled = true;
        }
        delegate void AddTextCallback(string text);

        private void AddText_To_GridControl(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            lblStatus.Text = text;
            if (this.dgv_CardData.InvokeRequired)
            {
                AddTextCallback d = new AddTextCallback(AddText_To_GridControl);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), text }); ;
            }
        }
        private void msg(String readData)
        {

                //'textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + readData;
                this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), readData});
                this.dgv_CardData.FirstDisplayedScrollingRowIndex = dgv_CardData.RowCount - 1;
        }

        private void bt_Send_Click(object sender, EventArgs e)
        {

//            try
//            {
            if (tcpClient ==null)
            {
                return;
            }

                NetworkStream ns = tcpClient.GetStream();
                StateObject state = new StateObject();
                state.workSocket = tcpClient.Client;
                tcpClient.Client.BeginReceive(state.buffer, 0, state.buffer.Length, SocketFlags.None,
                      new AsyncCallback(OnReceive), state);

                //input = "0000" + Encoding.ASCII.GetString(raw) + text_Data2Send.Text;
                input = CTTransactionTypes.SalePurchase + util.GetCharFromHex(CCardTranConst.CON_CT_FS) + CTTags.ECRTransactionAmount + text_Data2Send.Text;
                byte[] sendBytes = new byte[input.Length];
                char[] charArr = input.ToCharArray();

                for (int i = 0; i < charArr.Length; i++)
                {
                    byte curCharByte = Convert.ToByte(charArr[i]);
                    sendBytes[i] = curCharByte;
                }

            lblStatus.Text = "Card Transaction requested...";
            lblAmount.Text = "Amount : " + text_Data2Send.Text.Substring(0, 2) + "." + text_Data2Send.Text.Substring(2, 2);

                util.Logger("------------------ Card Transaction Started ------------------");
                util.Logger("Send Data To PinPad Terminal : (" +sendBytes.Length.ToString() + ") "+ Encoding.ASCII.GetString(sendBytes,0,sendBytes.Length));
                this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "Send Data To Terminal : (" + sendBytes.Length.ToString() + ") " + Encoding.ASCII.GetString(sendBytes, 0, sendBytes.Length) });
                ns.Write(sendBytes, 0, sendBytes.Length);

                strHostResponseCode = "";
                text_Data2Send.Text = "";
                //receiveData(sender, e);
                //ns.Close();

 //           }
 //           catch (Exception ex)
 //           {
 //               MessageBox.Show(ex.Message, "Send Button", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
 //           }
        }
        private void SendResponse(string strData)
        {
            NetworkStream ns = tcpClient.GetStream();
            StateObject state = new StateObject();
            state.workSocket = tcpClient.Client;
            tcpClient.Client.BeginReceive(state.buffer, 0, state.buffer.Length, SocketFlags.None,
                  new AsyncCallback(OnReceive), state);

            string hex = "1C";
            byte[] raw = new byte[1];
            raw[0] = Convert.ToByte(hex.Substring(0, 2), 16);
            input = strData;
            byte[] sendBytes = new byte[input.Length];
            char[] charArr = input.ToCharArray();

            for (int i = 0; i < charArr.Length; i++)
            {
                byte curCharByte = Convert.ToByte(charArr[i]);
                sendBytes[i] = curCharByte;
            }

            lblStatus.Invoke((Action)(() => lblStatus.Text = "Card transaction requested..."));
            util.Logger("Send Response back To Terminal : " + Encoding.ASCII.GetString(sendBytes, 0, sendBytes.Length));
            AddText_To_GridControl("Send Response back To Terminal : " + Encoding.ASCII.GetString(sendBytes, 0, sendBytes.Length));
            ns.Write(sendBytes, 0, sendBytes.Length);

            text_Data2Send.Text = "";

        }
        private void SendPmTreeResponse(string strData)
        {
            NetworkStream ns = tcpClient.GetStream();
            StateObject state = new StateObject();
            state.workSocket = tcpClient.Client;
            tcpClient.Client.BeginReceive(state.buffer, 0, state.buffer.Length, SocketFlags.None,
                  new AsyncCallback(OnReceive), state);

            string hex = "1C";
            byte[] raw = new byte[1];
            raw[0] = Convert.ToByte(hex.Substring(0, 2), 16);
            input = strData;
            byte[] sendBytes = new byte[input.Length];
            char[] charArr = input.ToCharArray();

            for (int i = 0; i < charArr.Length; i++)
            {
                byte curCharByte = Convert.ToByte(charArr[i]);
                sendBytes[i] = curCharByte;
            }

            lblStatus.Invoke((Action)(() => lblStatus.Text = "Card transaction requested..."));
            util.Logger("Send Response back To Terminal : " + Encoding.ASCII.GetString(sendBytes, 0, sendBytes.Length));
            AddText_To_GridControl("Send Response back To Terminal : " + Encoding.ASCII.GetString(sendBytes, 0, sendBytes.Length));
            ns.Write(sendBytes, 0, sendBytes.Length);

            text_Data2Send.Text = "";

        }
        /// <summary>
        /// Asynchronous Callback function which receives data from client
        /// </summary>
        /// <param name="ar"></param>
        public void OnReceive(IAsyncResult ar)
        {
            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            // Read data from the client socket.   
            if (!handler.Connected) return;
            int bytesRead = handler.EndReceive(ar);

            String content = String.Empty;
            //bPaymentComplete = false;
            string strProcessingCode = "";
            string strProcessingMsg = "";

            if (p_blnPaymentree)
            {
                // Paymentree Integration
                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.ASCII.GetString(
                                                            state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read   
                    // more data.  
                    content = Encoding.ASCII.GetString(state.buffer, 0, bytesRead);

                    util.Logger("bPaymentree Recieved : Read Data -> (" + bytesRead + " Bytes) " + content);
                    strProcessingCode = ProcessPaymentreeTransaction(handler, content);
                    //split the content by : to get the response code and message
                    string[] strlist = strProcessingCode.Split(':');
                    if (strlist.Count() > 1)
                    {
                        strProcessingCode = strlist[0];
                        strProcessingMsg = strlist[1];
                    }
                    util.Logger("bPaymentree Recieved : ProcessPaymentreeTransaction finished : strProcessingCode = " + strProcessingCode + " " + strProcessingMsg);
                    if (strProcessingCode != "0")
                    {
                        util.Logger("Transaction Error...." + strProcessingMsg);
                        //AddText_To_GridControl("Transaction Error ! " + strProcessingMsg);
                        try
                        {
                            lblStatus.Invoke((Action)(() => lblStatus.Text = "Transaction Error ! " + strProcessingMsg));
                        }
                        catch (Exception ex)
                        {
                            util.Logger("Exception : Transaction Error ! " + strProcessingMsg);
                        }
                        handler.Close();
                        handler.Dispose();
                        return;
                    }
                    else
                    {
                        util.Logger("Paymentree : Approved and closing connection....");
                        //AddText_To_GridControl("Paymentree : Approved and closing connection....");
                        try
                        {
                            lblStatus.Invoke((Action)(() => lblStatus.Text = "Paymentree : Approved : " + strPaymentType));
                        }
                        catch(Exception ex)
                        {
                            util.Logger("Exception : Paymentree : Approved : " + strPaymentType);
                        }
                        handler.Close();
                        handler.Dispose();
                        bPaymentComplete = true;
                        return;
                    }
                }
            }
            else
            {
                // Elavon or Global Payment Simi Integration
                if (bytesRead > 0)
                {
                    // There  might be more data, so store the data received so far.  
                    //                state.sb.Append(Encoding.ASCII.GetString(
                    //                    state.buffer, 0, bytesRead));
                    //state.sb.Clear();
                    state.sb.Append(Encoding.ASCII.GetString(
                                        state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read   
                    // more data.  
                    content = Encoding.ASCII.GetString(state.buffer, 0, bytesRead);

                    byte[] readBytes = new byte[content.Length];
                    char[] charArr = content.ToCharArray();
                    for (int i = 0; i < charArr.Length; i++)
                    {
                        byte curCharByte = Convert.ToByte(charArr[i]);
                        readBytes[i] = curCharByte;
                    }
                    util.Logger("Read Data : (" + readBytes.Length.ToString() + ") " + Encoding.ASCII.GetString(readBytes, 0, readBytes.Length));
                    AddText_To_GridControl(Encoding.ASCII.GetString(readBytes, 0, readBytes.Length));
                    //this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), content.ToString() });
                    if (readBytes.Length == 1)
                    {
                        //if (readBytes[0] == raw_0x11[0]) //CON_CT_HEART_BEAT
                        if (readBytes[0] == util.GetCharFromHex(CCardTranConst.CON_CT_HEART_BEAT)) //CON_CT_HEART_BEAT
                        {
                            // Not all data received. Get more.  
                            util.Logger("Read Data : HEART_BEAT ");
                            AddText_To_GridControl("Read Data : HEART_BEAT ");
                        }
                        else
                        {
                            util.Logger("Read Data : NON HEART_BEAT ");
                            AddText_To_GridControl("Read Data : NON HEART_BEAT ");
                        }

                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(OnReceive), state);
                    }
                    String[] strlist = content.Split(util.GetCharFromHex(CCardTranConst.CON_CT_FS));
                    int index = 0;
                    util.Logger(" ==> Total Tag data received count : " + strlist.Count());

                    if (strlist.Count() == 1)
                    {
                        if (strlist[0].Length > 2)
                        {
                            string strTranState = strlist[0].Substring(0, 2);

                            if (strTranState == CTTransactionStatuses.DeclinedByHostOrCard) // Declined "10"
                            {
                                util.Logger("Transaction declined....");
                                AddText_To_GridControl("Transaction declined....");
                                lblStatus.Invoke((Action)(() => lblStatus.Text = "Declined by Host or Card...."));
                                handler.Close();
                                handler.Dispose();
                                //NetworkStream ns = server.GetStream();
                                //ns.Close();
                                return;
                            }
                            if (strTranState == CTTransactionStatuses.CommunicationError) // CommunicationError "11"
                            {
                                util.Logger("Communication Error ....");
                                AddText_To_GridControl("Communication Error ....");
                                lblStatus.Invoke((Action)(() => lblStatus.Text = "Communication Error ...."));
                                handler.Close();
                                handler.Dispose();
                                //NetworkStream ns = server.GetStream();
                                //ns.Close();
                                return;
                            }
                            if (strTranState == CTTransactionStatuses.CancelledByUser) // CancelledByUser = "12";
                            {
                                util.Logger("Transaction CancelledByUser....");
                                AddText_To_GridControl("Transaction CancelledByUser....");
                                lblStatus.Invoke((Action)(() => lblStatus.Text = "Transaction CancelledByUser...."));
                                handler.Close();
                                handler.Dispose();
                                //NetworkStream ns = server.GetStream();
                                //ns.Close();
                                return;
                            }
                            if (strTranState == CTTransactionStatuses.TimedOutOnUserInput) // TimedOutOnUserInput = "13";
                            {
                                util.Logger("Transaction Timed out....");
                                AddText_To_GridControl("Transaction Timed out....");
                                lblStatus.Invoke((Action)(() => lblStatus.Text = "Transaction Timed out...."));
                                handler.Close();
                                handler.Dispose();
                                //NetworkStream ns = server.GetStream();
                                //ns.Close();
                                return;
                            }
                            // TransactionNotCompleted
                            if (strTranState == CTTransactionStatuses.TransactionNotCompleted) // TransactionNotCompleted = "14";
                            {
                                util.Logger("Transaction Not Completed....");
                                AddText_To_GridControl("Transaction Not Completed....");
                                lblStatus.Invoke((Action)(() => lblStatus.Text = "Transaction Not Completed...."));
                                handler.Close();
                                handler.Dispose();
                                //NetworkStream ns = server.GetStream();
                                //ns.Close();
                                return;
                            }
                            if (strTranState == CTTransactionStatuses.DeclinedByMerchant) // DeclinedByMerchant = "16";
                            {
                                util.Logger("Declined by Merchant....");
                                AddText_To_GridControl("Declined by Merchant....");
                                lblStatus.Invoke((Action)(() => lblStatus.Text = "Declined by Merchant...."));
                                handler.Close();
                                handler.Dispose();
                                //NetworkStream ns = server.GetStream();
                                //ns.Close();
                                return;
                            }
                            if (strTranState == CTTransactionStatuses.RecordNotFound) // RecordNotFound = "17";
                            {
                                util.Logger("Record Not Found....");
                                AddText_To_GridControl("Record Not Found....");
                                lblStatus.Invoke((Action)(() => lblStatus.Text = "Record Not Found...."));
                                handler.Close();
                                handler.Dispose();
                                //NetworkStream ns = server.GetStream();
                                //ns.Close();
                                return;
                            }
                        }
                    }
                    if (strlist.Count() > 1)
                    {
                        strProcessingCode = CardProcess.processData(content, p_InvoiceNo, p_Station, p_UserName);
                        //strTranState = "99" Receipt : Actual TransactionStatus (002,101) is returned
                        //strTranState = Else         : first 2 byte of recieved msg (Transaction Status) is returned
                        util.Logger("1. Read Data : CardProcess.processData finished : strProcessingCode = " + strProcessingCode);

                        //string strTranState = Encoding.ASCII.GetString(readBytes,0, 2);
                        // first 2 bytes is Transaction Status
                        string strTranState = strlist[0].Substring(0, 2);
                        util.Logger("> TranState Code : " + strTranState);
                        if (strTranState == CTTransactionStatuses.Receipt)   // Receipt "99"
                        {
                            util.Logger("2. Receipt recieved response back ....");
                            AddText_To_GridControl("Receipt recieved response back ....");
                            lblStatus.Invoke((Action)(() => lblStatus.Text = "Retriving Transaction Receipt data!"));
                            SendResponse("990");
                        }
                        if (strTranState == CTTransactionStatuses.Approved) // Approved "00"
                        {
                            util.Logger("> Approved and closing connection....");
                            AddText_To_GridControl("Approved and closing connection....");
                            handler.Close();
                            handler.Dispose();
                            //NetworkStream ns = server.GetStream();
                            //ns.Close();
                            bPaymentComplete = true;
                            strPaymentType = CTCardTypes.GetTypeName(CardProcess.GetCustomerCardType(content));
                            lblStatus.Invoke((Action)(() => lblStatus.Text = "Approved : " + strPaymentType));
                            return;
                        }
                        if (strTranState == CTTransactionStatuses.DeclinedByHostOrCard) // Declined "10"
                        {
                            util.Logger("> Transaction declined....");
                            AddText_To_GridControl("Transaction declined....");
                            lblStatus.Invoke((Action)(() => lblStatus.Text = "Declined by Host or Card...."));
                            handler.Close();
                            handler.Dispose();
                            //NetworkStream ns = server.GetStream();
                            //ns.Close();
                            return;
                        }
                        if (strTranState == CTTransactionStatuses.TimedOutOnUserInput) // TimedOutOnUserInput = "13";
                        {
                            util.Logger("> Transaction Timed out....");
                            AddText_To_GridControl("Transaction Timed out....");
                            lblStatus.Invoke((Action)(() => lblStatus.Text = "Transaction Timed out...."));
                            handler.Close();
                            handler.Dispose();
                            //NetworkStream ns = server.GetStream();
                            //ns.Close();
                            return;
                        }
                        if (strTranState == CTTransactionStatuses.CancelledByUser) // CancelledByUser = "12";
                        {
                            util.Logger("> Transaction CancelledByUser....");
                            AddText_To_GridControl("Transaction CancelledByUser....");
                            lblStatus.Invoke((Action)(() => lblStatus.Text = "Transaction CancelledByUser...."));
                            handler.Close();
                            handler.Dispose();
                            //NetworkStream ns = server.GetStream();
                            //ns.Close();
                            return;
                        }
                    }

                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(OnReceive), state);
                }//if (bytesRead > 0)
            } //if (bPaymentree)
        }

        private string ProcessPaymentreeTransaction(Socket p_socketHandler, string p_content)
        {
            // Convert p_content to POS_PmTreeRespModel
            try
            {
                posPmTreeResp = util.LoadFromXML(p_content);
            }
            catch (Exception ex)
            {
                util.Logger("Error : ProcessPaymentreeTransaction LoadFromXML : " + ex.Message);
                return "X";
            }

            string strProcessingCode = posPmTreeResp.TransRespCode;
            if (posPmTreeResp.TransRespCode == "0") // Action Successful
            {
                strProcessingCode = CardProcess.processPmTreeData(posPmTreeResp, p_InvoiceNo, p_Station, p_UserName, p_strTranType);
            }

            if (strProcessingCode == "0")
            {
                //---------------------------------------------------
                // Upon receiving 0 Response Code, we can commit now
                // BUILD XML for REQUEST TOKEN
                //---------------------------------------------------
                // Send commit message to Paymentree
                posPmTreeTran.Request_Type = PTRequestType["Card"];
                posPmTreeTran.Action_Type = PTActionTypes["CommitTrans"];
                posPmTreeTran.Client_Id = "";// stations[0].Client_Id"";
                posPmTreeTran.Location = "";// stations[0].Location;
                posPmTreeTran.Register = "";
                posPmTreeTran.Cashier = ""; // p_UserName;
                posPmTreeTran.Req_Trans_Id = p_InvoiceNo.ToString();

                string strXML = util.ToXML(posPmTreeTran);
                util.Logger("Paymentree Commit : " + strXML);
                //AddText_To_GridControl("Paymentree Commit : " + strXML);
                p_socketHandler.Send(Encoding.ASCII.GetBytes(strXML));

                util.Logger("Paymentree : Approved and closing connection....");
                //AddText_To_GridControl("Paymentree : Approved and closing connection....");
                p_socketHandler.Close();
                p_socketHandler.Dispose();
                bPaymentComplete = true;
                p_TipAmt = Int32.Parse(posPmTreeResp.TipAmt);
                p_TipAmt = (float)Math.Round(p_TipAmt, 2) / 100;
                strPaymentType = posPmTreeResp.CardCode;
                lblStatus.Invoke((Action)(() => lblStatus.Text = "Paymentree : Approved : " + strPaymentType));
                return strProcessingCode;
            }
            else
            {
                util.Logger("Paymentree : Error transaction...." + strProcessingCode + " " + posPmTreeResp.TransRespMsg);
                //AddText_To_GridControl("Paymentree : Error...." + posPmTreeResp.TransRespMsg);
                p_socketHandler.Close();
                p_socketHandler.Dispose();
                bPaymentComplete = false;
                return strProcessingCode + ":" + posPmTreeResp.TransRespMsg;
            }
        }

        private void bt_Disconnect_Click(object sender, EventArgs e)
        {
            if (tcpClient != null)
            {
                if (tcpClient.Connected)
                {
                    tcpClient.Close();
                    util.Logger("PinPad connection closed : " + text_IPADDR.Text + "," + text_PortNo.Text);
                }
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            if (tcpClient != null)
            {
                if (tcpClient.Connected)
                {
                    tcpClient.Close();
                    util.Logger("Exiting ... frmCardPayment and PinPad closed : " + text_IPADDR.Text + "," + text_PortNo.Text);
                }
            }
            if (bPaymentComplete)
            {
                util.Logger("frmCardPayment Exiting ... with PaymentComplete");
            }
            this.Close();
            //Application.ExitThread();
            //Application.Exit();
        }

        private void bt_PayPinPad_Click(object sender, EventArgs e)
        {
            if (tcpClient == null)
            {
                return;
            }

            timer1.Interval = 2000;

            if (!tcpClient.Connected)
            {
                int portNo = 0;
                portNo = int.Parse(text_PortNo.Text);
                try
                {
                    tcpClient = new TcpClient(text_IPADDR.Text, portNo);
                }
                catch (SocketException)
                {
                    this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "Unable to connect to server" });
                    util.Logger("Unable to connect to PinPad : " + text_IPADDR + "," + portNo);
                    bt_PayPinPad.Enabled = false;
                    return;
                }
                this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "Connected to Server..." });
                util.Logger("PinPad connected : " + text_IPADDR + "," + portNo);
                bt_PayPinPad.Enabled = true;
            }

            if (p_blnPaymentree)
            {
                StartPaymentreeTran();
            }
            else
            {
                NetworkStream ns = tcpClient.GetStream();
                StateObject state = new StateObject();
                state.workSocket = tcpClient.Client;
                tcpClient.Client.BeginReceive(state.buffer, 0, state.buffer.Length, SocketFlags.None,
                      new AsyncCallback(OnReceive), state);

                string strTenderAmt = String.Format("{0}", Math.Round(p_TenderAmt, 2) * 100);
                //input = "0000" + Encoding.ASCII.GetString(raw) + text_Data2Send.Text;
                input = CTTransactionTypes.SalePurchase + util.GetCharFromHex(CCardTranConst.CON_CT_FS) + CTTags.ECRTransactionAmount + strTenderAmt;
                byte[] sendBytes = new byte[input.Length];
                char[] charArr = input.ToCharArray();

                for (int i = 0; i < charArr.Length; i++)
                {
                    byte curCharByte = Convert.ToByte(charArr[i]);
                    sendBytes[i] = curCharByte;
                }

                lblStatus.Text = "Card Transaction requested... Please follow instruction on PINPAD!";
                //lblAmount.Text = "Amount : " + text_Data2Send.Text.Substring(0, 2) + "." + text_Data2Send.Text.Substring(2, 2);
                timerBlinkStatus.Start();
                util.Logger("------------------ Card Transaction Started ------------------");
                util.Logger("Send Data To PinPad Terminal : (" + sendBytes.Length.ToString() + ") " + Encoding.ASCII.GetString(sendBytes, 0, sendBytes.Length));
                this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "Send Data To Terminal : (" + sendBytes.Length.ToString() + ") " + Encoding.ASCII.GetString(sendBytes, 0, sendBytes.Length) });
                ns.Write(sendBytes, 0, sendBytes.Length);

                text_Data2Send.Text = "";
            }
        }

        private void StartPaymentreeTran()
        {
            // Check data validation
            bool bValidPaymentreeTran = ValidatePaymentreeTran();

            if (!bValidPaymentreeTran)
            {
                return;
            }

            if (p_strTranType == "Purchase")
                ProcessPurchasePaymentreeTran();
            else if (p_strTranType == "Refund")
                ProcessRefundPaymentreeTran();
            else if (p_strTranType == "Void")
                ProcessVoidPaymentreeTran();
            else
                MessageBox.Show("Invalid Transaction Type! " + p_strTranType);

        }

        private void ProcessPurchasePaymentreeTran()
        {
            // Populate posPmTreeTran data
            posPmTreeTran.Request_Type = PTRequestType["Card"];
            posPmTreeTran.Action_Type = PTActionTypes["Purchase"];
            posPmTreeTran.Client_Id = stations[0].Client_Id;
            posPmTreeTran.Location = stations[0].Location;
            posPmTreeTran.Register = stations[0].Register;
            posPmTreeTran.Cashier = p_UserPassCode; //p_UserName;
            posPmTreeTran.Req_Trans_Id = p_InvoiceNo.ToString();
            posPmTreeTran.Amount = (int)(p_TenderAmt * 100);
            posPmTreeTran.Token = "";
            posPmTreeTran.Dynamic_Ip = "";
            posPmTreeTran.Dynamic_Port = 0;

            // Serialize posPmTreeTran data to XML format
            string strXML = util.ToXML(posPmTreeTran);
            util.Logger(strXML);

            NetworkStream ns = tcpClient.GetStream();
            StateObject state = new StateObject();
            state.workSocket = tcpClient.Client;
            tcpClient.Client.BeginReceive(state.buffer, 0, state.buffer.Length, SocketFlags.None,
                  new AsyncCallback(OnReceive), state);

            var utf8 = new UTF8Encoding();
            byte[] sendBytes = utf8.GetBytes(strXML);

            lblStatus.Text = "Paymentree Card Transaction requested... Please follow instruction on PINPAD!";
            //lblAmount.Text = "Amount : " + text_Data2Send.Text.Substring(0, 2) + "." + text_Data2Send.Text.Substring(2, 2);
            timerBlinkStatus.Start();
            util.Logger("------------------ Paymentree Card Transaction Started ------------------");
            util.Logger("Paymentree : Send Data To PinPad Terminal : (" + sendBytes.Length.ToString() + ") " + utf8.GetString(sendBytes));
            this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "Send Data To Terminal : (" + sendBytes.Length.ToString() + ") " + utf8.GetString(sendBytes) });
            //ns.Write(sendBytes, 0, sendBytes.Length);
            tcpClient.Client.Send(sendBytes, 0, sendBytes.Length, SocketFlags.None);

            text_Data2Send.Text = "";
        }
        private void ProcessVoidPaymentreeTran()
        {
            DataAccessCard dbCard = new DataAccessCard();
            cardReceipts = dbCard.Get_Approved_CardReceipt_By_InvoiceNo(p_InvoiceNo);
            // Populate posPmTreeTran data
            posPmTreeTran.Request_Type = PTRequestType["Card"];
            posPmTreeTran.Action_Type = PTActionTypes["Void"];
            posPmTreeTran.Client_Id = stations[0].Client_Id;
            posPmTreeTran.Location = stations[0].Location;
            posPmTreeTran.Register = stations[0].Register;
            posPmTreeTran.Cashier = p_UserPassCode; //p_UserName;
            posPmTreeTran.Req_Trans_Id = p_InvoiceNo.ToString();
            if (cardReceipts.Count > 0)
                posPmTreeTran.Trans_Id_To_Void = cardReceipts[0].TicketNo;
            posPmTreeTran.Amount = (int)(p_TenderAmt * 100);
            posPmTreeTran.Token = "";
            posPmTreeTran.Dynamic_Ip = "";
            posPmTreeTran.Dynamic_Port = 0;

            // Serialize posPmTreeTran data to XML format
            string strXML = util.ToXML(posPmTreeTran);
            util.Logger(strXML);

            NetworkStream ns = tcpClient.GetStream();
            StateObject state = new StateObject();
            state.workSocket = tcpClient.Client;
            tcpClient.Client.BeginReceive(state.buffer, 0, state.buffer.Length, SocketFlags.None,
                  new AsyncCallback(OnReceive), state);

            var utf8 = new UTF8Encoding();
            byte[] sendBytes = utf8.GetBytes(strXML);

            lblStatus.Text = "Paymentree Void Transaction requested... Please follow instruction on PINPAD!";
            //lblAmount.Text = "Amount : " + text_Data2Send.Text.Substring(0, 2) + "." + text_Data2Send.Text.Substring(2, 2);
            timerBlinkStatus.Start();
            util.Logger("------------------ Paymentree Void Transaction Started ------------------");
            util.Logger("Paymentree : Send Data To PinPad Terminal : (" + sendBytes.Length.ToString() + ") " + utf8.GetString(sendBytes));
            this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "Send Data To Terminal : (" + sendBytes.Length.ToString() + ") " + utf8.GetString(sendBytes) });
            //ns.Write(sendBytes, 0, sendBytes.Length);
            tcpClient.Client.Send(sendBytes, 0, sendBytes.Length, SocketFlags.None);

            text_Data2Send.Text = "";
        }

        private void ProcessRefundPaymentreeTran()
        {
            // Populate posPmTreeTran data
            posPmTreeTran.Request_Type = PTRequestType["Card"];
            posPmTreeTran.Action_Type = PTActionTypes["Refund"];
            posPmTreeTran.Client_Id = stations[0].Client_Id;
            posPmTreeTran.Location = stations[0].Location;
            posPmTreeTran.Register = stations[0].Register;
            posPmTreeTran.Cashier = p_UserPassCode; //p_UserName;
            posPmTreeTran.Req_Trans_Id = p_InvoiceNo.ToString();
            posPmTreeTran.Amount = (int)(p_TenderAmt * 100);
            posPmTreeTran.Token = "";
            posPmTreeTran.Dynamic_Ip = "";
            posPmTreeTran.Dynamic_Port = 0;

            // Serialize posPmTreeTran data to XML format
            string strXML = util.ToXML(posPmTreeTran);
            util.Logger(strXML);

            NetworkStream ns = tcpClient.GetStream();
            StateObject state = new StateObject();
            state.workSocket = tcpClient.Client;
            tcpClient.Client.BeginReceive(state.buffer, 0, state.buffer.Length, SocketFlags.None,
                  new AsyncCallback(OnReceive), state);

            var utf8 = new UTF8Encoding();
            byte[] sendBytes = utf8.GetBytes(strXML);

            lblStatus.Text = "Paymentree Refund Transaction requested... Please follow instruction on PINPAD!";
            //lblAmount.Text = "Amount : " + text_Data2Send.Text.Substring(0, 2) + "." + text_Data2Send.Text.Substring(2, 2);
            timerBlinkStatus.Start();
            util.Logger("------------------ Paymentree Refund Transaction Started ------------------");
            util.Logger("Paymentree : Send Data To PinPad Terminal : (" + sendBytes.Length.ToString() + ") " + utf8.GetString(sendBytes));
            this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "Send Data To Terminal : (" + sendBytes.Length.ToString() + ") " + utf8.GetString(sendBytes) });
            //ns.Write(sendBytes, 0, sendBytes.Length);
            tcpClient.Client.Send(sendBytes, 0, sendBytes.Length, SocketFlags.None);

            text_Data2Send.Text = "";
        }
        private bool ValidatePaymentreeTran()
        {
            if (string.IsNullOrEmpty(stations[0].Client_Id))
            {
                MessageBox.Show("Client Id is empty!");
                return false;
            }
            if (string.IsNullOrEmpty(stations[0].Location))
            {
                MessageBox.Show("Location is empty!");
                return false;
            }
            if (string.IsNullOrEmpty(stations[0].Register))
            {
                MessageBox.Show("Register is empty!");
                return false;
            }
            if (string.IsNullOrEmpty(p_UserName))
            {
                MessageBox.Show("Cashier is empty!");
                return false;
            }
            if (p_InvoiceNo == 0)
            {
                MessageBox.Show("Invoice No is empty!");
                return false;
            }
            if (p_TenderAmt == 0)
            {
                MessageBox.Show("Tender Amount is empty!");
                return false;
            }
            return true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //util.Logger("------------------ Card Transaction timer invoked ------------------" + bPaymentComplete);
            if (lblAmount.Visible)
            {
                lblAmount.Visible = false;
            }
            else
            {
                lblAmount.Visible = true;
            }
            if (bPaymentComplete)
            {
                bt_Exit.PerformClick();
            }
        }
        //private async void BlinkStatusLabel()
        //{
        //    while (true)
        //    {
        //        await Task.Delay(500);
        //        lblStatus.ForeColor = lblStatus.ForeColor == Color.Red ? Color.Green : Color.Red;
        //    }
        //}
        private void timerBlinkStatus_Tick(object sender, EventArgs e)
        {
            lblStatus.ForeColor = lblStatus.ForeColor == Color.Red ? Color.Green : Color.Red;
        }
        private void bt_PayCash_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Please make a Cash payment at the Cashier!";
            FrmSalesMain.SetCashPayment(true);
            bCashPayment = true;
            timerBlinkStatus.Start();
            strPaymentType = "Cash";
            timer2.Interval = 1000;
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            bt_Exit.PerformClick();
        }


    }
    /// <summary>
    /// Server receive state
    /// </summary>
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 8192;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }
}
