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
        TcpClient server;
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
        List<POS_StationModel> stations = new List<POS_StationModel>();
        public Boolean bPaymentComplete;
        public Boolean bCashPayment;
        public string strPaymentType { get; set; }

        public float p_TipAmt { get; set; }

        public float p_TenderAmt { get; set; }

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
        //public Boolean bPaymentComplete { get; private set; }
        private void frmCardPayment_Load(object sender, EventArgs e)
        {
            dgv_CardData_Initialize();
            if (Get_PinPad_Information())
            {
                lblStatus.Text = "Pinpad is ready!";
                bt_PayPinPad.Enabled = true;
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
            timer1.Interval = 2000;
            timer1.Enabled = true;
            timer1.Start();
        }
        private bool Get_PinPad_Information()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            stations.Clear();
            stations = dbPOS.Get_Station_By_Station(p_Station);
            if (stations.Count > 0)
            {
                text_IPADDR.Text = stations[0].IP_Addr;
                text_PortNo.Text = stations[0].IPS_Port.ToString();
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
                if (server != null)
                {
                    if (server.Connected)
                    {
                        server.Close();
                    }
                }
                server = new TcpClient(text_IPADDR.Text, portNo);
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
                server = new TcpClient(text_IPADDR.Text, portNo);
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
            if (server==null)
            {
                return;
            }

                NetworkStream ns = server.GetStream();
                StateObject state = new StateObject();
                state.workSocket = server.Client;
                server.Client.BeginReceive(state.buffer, 0, state.buffer.Length, SocketFlags.None,
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
            NetworkStream ns = server.GetStream();
            StateObject state = new StateObject();
            state.workSocket = server.Client;
            server.Client.BeginReceive(state.buffer, 0, state.buffer.Length, SocketFlags.None,
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
            String content = String.Empty;
            //bPaymentComplete = false;
            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket.   
            if (!handler.Connected)  return;
            int bytesRead = handler.EndReceive(ar);

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
                    }
                }
                if (strlist.Count() > 1)
                {
                    if (CardProcess.processData(content, p_InvoiceNo, p_Station, p_UserName))
                    {
                        util.Logger("Read Data : CardProcess.processData finished ");
                    }

                    //string strTranState = Encoding.ASCII.GetString(readBytes,0, 2);
                    string strTranState = strlist[0].Substring(0,2);
                    if (strTranState == CTTransactionStatuses.Receipt)   // Receipt "99"
                    {
                        util.Logger("Receipt recieved response back ....");
                        AddText_To_GridControl("Receipt recieved response back ....");
                        lblStatus.Invoke((Action)(() => lblStatus.Text = "Retriving Transaction Receipt data!"));
                        SendResponse("990");
                    }
                    if (strTranState == CTTransactionStatuses.Approved) // Approved "00"
                    {
                        util.Logger("Approved and closing connection....");
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
                        util.Logger("Transaction declined....");
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
                        util.Logger("Transaction Timed out....");
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
                        util.Logger("Transaction CancelledByUser....");
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
            } //if (bytesRead > 0)
        }
        private void bt_Disconnect_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                if (server.Connected)
                {
                    server.Close();
                    util.Logger("PinPad connection closed : " + text_IPADDR.Text + "," + text_PortNo.Text);
                }
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                if (server.Connected)
                {
                    server.Close();
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
            if (server == null)
            {
                return;
            }

            timer1.Interval = 2000;

            if (!server.Connected)
            {
                int portNo = 0;
                portNo = int.Parse(text_PortNo.Text);
                try
                {
                    server = new TcpClient(text_IPADDR.Text, portNo);
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

            NetworkStream ns = server.GetStream();
            StateObject state = new StateObject();
            state.workSocket = server.Client;
            server.Client.BeginReceive(state.buffer, 0, state.buffer.Length, SocketFlags.None,
                  new AsyncCallback(OnReceive), state);

            string strTenderAmt = String.Format("{0}",Math.Round(p_TenderAmt,2) * 100);
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
            BlinkStatusLabel();
            util.Logger("------------------ Card Transaction Started ------------------");
            util.Logger("Send Data To PinPad Terminal : (" + sendBytes.Length.ToString() + ") " + Encoding.ASCII.GetString(sendBytes, 0, sendBytes.Length));
            this.dgv_CardData.Rows.Add(new String[] { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "Send Data To Terminal : (" + sendBytes.Length.ToString() + ") " + Encoding.ASCII.GetString(sendBytes, 0, sendBytes.Length) });
            ns.Write(sendBytes, 0, sendBytes.Length);

            text_Data2Send.Text = "";
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
        private async void BlinkStatusLabel()
        {
            while (true)
            {
                await Task.Delay(500);
                lblStatus.ForeColor = lblStatus.ForeColor == Color.Red ? Color.Green : Color.Red;
            }
        }

        private void bt_PayCash_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Please make a Cash payment at the Cashier!";
            FrmSalesMain.SetCashPayment(true);
            bCashPayment = true;
            BlinkStatusLabel();
            timer2.Interval = 2000;
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
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }
}
