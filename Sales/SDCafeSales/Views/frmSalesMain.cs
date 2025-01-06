using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
using SDCafeCommon.Utilities;
using System.Globalization;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Reflection;
using System.Runtime.Remoting.Proxies;
using System.Net.Sockets;
using System.Linq;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;

namespace SDCafeSales.Views
{
    public partial class frmSalesMain : Form
    {
        /// ///////////////////////////////////////////////
        /// <Table definitions>
        List<POS_LoginUserModel> loginUsers = new List<POS_LoginUserModel>();
        List<POS_ProductModel> prods = new List<POS_ProductModel>();
        List<POS_ProductTypeModel> ptypes = new List<POS_ProductTypeModel>();
        List<POS_RFIDTagsModel> rfids = new List<POS_RFIDTagsModel>();
        List<POS_SysConfigModel> sysconfs = new List<POS_SysConfigModel>();
        List<POS_TaxModel> taxs = new List<POS_TaxModel>();
        private string m_strDefaultTaxCode;
        List<POS_TaxModel> allTaxs = new List<POS_TaxModel>();
        List<POS_StationModel> stations = new List<POS_StationModel>();
        List<POS_OrdersModel> orders = new List<POS_OrdersModel>();
        List<POS_OrdersModel> childOrders = new List<POS_OrdersModel>();
        List<POS1_OrderCompleteModel> compOrders = new List<POS1_OrderCompleteModel>();
        List<POS1_ProductPopModel> prodPops = new List<POS1_ProductPopModel>();
        List<POS_SavedOrdersModel> savedorders = new List<POS_SavedOrdersModel>();

        List<POS_PromotionModel> promos = new List<POS_PromotionModel>();
        List<POS_PromoProductsModel> pprods = new List<POS_PromoProductsModel>();
        List<POS_ProdOrdersModel> prodOrders = new List<POS_ProdOrdersModel>();
        List<POS_SysConfigModel> sysConfs = new List<POS_SysConfigModel>();


        ToolTip tTip = new ToolTip();

        private CustomButton[] btnArray = new CustomButton[10000];
        private CustomButton[] btnTypeArray = new CustomButton[1000];
        private CustomButton[] btnNumArray = new CustomButton[12];
        private CustomButton btnBack = new CustomButton();

        Utility util = new Utility();
        RawPrinterHelper rawPrt = new RawPrinterHelper();

        public frmCardPayment FrmCardPay;
        public frmSalesCustomer FrmSalesCustomer;
        public frmSalesHistory FrmSalesHist;
        public frmDiscount FrmDiscount;
        public frmEditOrderPrice FrmEditOrderPrice;
        public frmYesNo FrmYesNo;
        public frmRecallOrder FrmRecallOrder;
        //public frmRegisterMain FrmRegister;
        /// ///////////////////////////////////////////////
        /// <Rfid variables>
        public UIntPtr hreader;
        public UIntPtr hTag;
        public UIntPtr hTagIcodeslix;
        public UIntPtr hTagTiHFIPlus;
        public Byte enableAFI;
        public Byte AFI;
        public Byte onlyNewTag;
        public bool asyncReport;
        public bool _shouldStop;
        public Byte openState;
        public Byte inventoryState;
        public Byte readerType;
        public Byte[] AntennaSel;
        public Byte AntennaSelCount;
        public ArrayList readerDriverInfoList;
        public ArrayList airInterfaceProtList;
        public List<String> m_blueAddrList = new List<string>();
        RFIDLIB.RFIDLIB_EVENT_CALLBACK callbackDelegate;
        Thread InvenThread;
        //public Button selectedBTN;
        private CustomButton selectedBTN;
        private int iSelected_btnArray_Index = -1;
        private int iSelectedType_btnArray_Index = -1;

        private bool isNewInvoice = false;
        private bool isRFIDConnected = false;
        private int iNewInvNo = 0;
        private int iReprintInvNo = 0;
        private float fTotDue = 0;
        private float m_TaxRate1 = 0;
        private float m_TaxRate2 = 0;
        private float m_TaxRate3 = 0;
        private bool m_bIsTax3IncTax1 = false;
        private int iPpleCount = 0;

        private string strHostName = "";
        public string strStation = "";
        private string strUserID = "";
        private string strUserName = "";
        private string strUserPass = "";
        private Process proc;

        public float iSubTotal;
        public float iTaxTotal;
        public float iTotalDue;
        public float iTotalItems;

        private int iCurrentTypePage = 1;
        private int iCurrentProdPage = 1;
        private int iTotalTypePages = 1;
        private int iTotalProdPages = 1;

        const string ESC = "\u001B";
        const string p = "\u0070";
        const string m = "\u0000";
        const string t1 = "\u0025";
        const string t2 = "\u0250";
        const string openTillCommand = ESC + p + m + t1 + t2;

        private string strBarCode = "";

        private bool bAutoReceipt = false;
        private Color[] btTypeColor =
        {
            Color.MediumSlateBlue,
            Color.MediumVioletRed,
            Color.DarkGreen,
            Color.DarkSlateGray,            
            Color.DimGray,           
            Color.Firebrick,
            Color.ForestGreen,
            Color.DarkSlateGray
        };
        private Color[] btColor =
        {
            Color.LightBlue,
            Color.LightCoral,
            Color.LightCyan,
            Color.LightGoldenrodYellow,
            Color.LightGreen,
            Color.LightGray,
            Color.LightPink,
            Color.LightSalmon,
            Color.LightSeaGreen,
            Color.LightSkyBlue,
            Color.LightSlateGray,
            Color.LightSteelBlue,
            Color.LightYellow,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen,
            Color.LimeGreen
           // 238,79,82 0X00524FEE,
           // 50,185,87 0x0057B932,
           //35,118,199 0x00C77623,
           // 243,157,33 0x00219DF3,
           // 136,60,219 0x00DB3C88,
           //47,74,126 0x007E4A2F,
           // 0,102,0 0x00006600
        };
        private int iSelectedProdTypeID;
        public bool bPaymentSuccess;
        public bool bCashPayment;

        private Random rdm = new Random();
        private Form FrmLogOn = null;

        private ImageList m_ImageList;
        private bool m_blnPinPadAvailable = false;
        TcpClient tcpClient;
        private bool m_blnNumState;
        private int m_intQueryTop;
        private float m_fCashDue;
        private float m_fCashRounding;
        private int iTimerCount;

        public bool m_blnPaymentree { get; set; }

        public string strTax1Name = "Tax1";
        public string strTax2Name = "Tax2";
        public string strTax3Name = "Tax3";
        private float m_fExchangeRateCADUSD;

        public bool m_blnPrintTaxDetails { get; set; }
        public string m_strProdBtnSortOrder { get; set; }

        public frmSalesMain(Form callingForm) :this()
        {
            FrmLogOn = callingForm;
        }
        public frmSalesMain()
        {
            InitializeComponent();

            selectedBTN = null;
            bt_Start.Enabled = false;
        }

        private void frmSalesMain_Load(object sender, EventArgs e)
        {
            util.Logger("################### frmSalesMain_Load #########################");
            Kill_If_SalesCustomer_Opened();
            if (Screen.AllScreens.Length > 1)
            {
                frmSalesCustomer FrmSalesCustomer = new frmSalesCustomer(this);
                // Important !
                FrmSalesCustomer.StartPosition = FormStartPosition.Manual;

                // Get the second monitor screen
                Screen screen = GetSecondaryScreen();

                // set the location to the top left of the second screen
                FrmSalesCustomer.Location = screen.WorkingArea.Location;
                FrmSalesCustomer.Width = screen.WorkingArea.Width;
                FrmSalesCustomer.Height = screen.WorkingArea.Height;

                // set it fullscreen
                //FrmSalesCustomer.Size = new Size(screen.WorkingArea.Width, screen.WorkingArea.Height);
                //FrmSalesCustomer.ShowDialog();
                FrmSalesCustomer.Show();
                FrmSalesCustomer.BringToFront();
                // Show the form
            }
            else
            {
                //MessageBox.Show("No External Display is Available");
                util.Logger("No External Display is Available");
            }

            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;
            this.BringToFront();

            pnlSideBar.Hide();

            if (Get_Tax_Rates())
            {
                Load_Update_Exchage_Rate();
                Load_System_Info();
                Load_ImageList();
                Load_Existing_Orders();
                PopulateMenuTypeButtons();
                PopulateMenuButtons(false, 0);
                ToggleNumTypeButtons();
                //Load_RFID_Drivers();
                //Open_RFID_Connection();
            }
            else
            {
                util.Logger("Error getting tax rates");
                MessageBox.Show("Error getting tax rates. Please call system admin!", "Error");
                this.Close();
            }

            strBarCode = string.Empty;
            BarCode_Get_Focus();
        }

        private void Load_Update_Exchage_Rate()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            sysconfs = dbPOS.Get_SysConfig_By_Name("CADUSD_CONVERSION_RATE");
            if (sysconfs.Count > 0)
                if (sysconfs[0].ConfigDesc != DateTime.Today.ToString())
                {
                    try
                    {
                        using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
                        {
                            string strURL = "https://v6.exchangerate-api.com/v6/94124759da58f6d5593c6bbf/latest/USD";
                            client.BaseAddress = new Uri(strURL);
                            HttpResponseMessage response = client.GetAsync("CAD").Result;
                            response.EnsureSuccessStatusCode();
                            string result = response.Content.ReadAsStringAsync().Result;
                            util.Logger(strURL + " ==> Result: " + result);
                            dynamic data = JObject.Parse(result);
                            if (data["result"] == "success")
                            {
                                string strUSDRates = (string)data["conversion_rates"]["USD"];
                                sysconfs[0].ConfigValue = strUSDRates;
                                sysconfs[0].ConfigDesc = DateTime.Today.ToString();
                                dbPOS.Update_SysConfig(sysconfs[0]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        util.Logger("Error getting exchange rate : " + ex.Message);
                        MessageBox.Show("Error getting exchange rate. Please call system admin!", "Error");
                        this.Close();
                    }
                    float.TryParse(sysconfs[0].ConfigValue, NumberStyles.Float, CultureInfo.InvariantCulture, out m_fExchangeRateCADUSD);
                }
                else
                    m_fExchangeRateCADUSD = 0;
        }

        private void Load_ImageList()
        {
            m_ImageList = new ImageList();
            m_ImageList.ImageSize = new Size(40, 40);
            m_ImageList.ColorDepth = ColorDepth.Depth32Bit;
            m_ImageList.Images.Add(Properties.Resources.Card_Terminal_POS_100x100); //0
            m_ImageList.Images.Add(Properties.Resources.logout_40dp);               //1
            m_ImageList.Images.Add(Properties.Resources.receipt_long_40dp);         //2
            m_ImageList.Images.Add(Properties.Resources.receipt_long_off_40dp);     //3
            m_ImageList.Images.Add(Properties.Resources.plus_circle_40dp);          //4
            m_ImageList.Images.Add(Properties.Resources.minus_circle_40dp);         //5
            m_ImageList.Images.Add(Properties.Resources.cd_open_40dp);              //6
            m_ImageList.Images.Add(Properties.Resources.Invoice_40dp);              //7
            m_ImageList.Images.Add(Properties.Resources.payments_40dp);             //8
            m_ImageList.Images.Add(Properties.Resources.Cash_Refund);             //9
            m_ImageList.Images.Add(Properties.Resources.settings_42x42_Black);             //10
            m_ImageList.Images.Add(Properties.Resources.multiple_content_copy_40dp);             //11
            m_ImageList.Images.Add(Properties.Resources.bookmark_40dp);             //12
            m_ImageList.Images.Add(Properties.Resources.bookmark_recall_40dp);             //13
            m_ImageList.Images.Add(Properties.Resources.history_40dp);             //14
            m_ImageList.Images.Add(Properties.Resources.arrow_back_40dp);             //15
            m_ImageList.Images.Add(Properties.Resources.menu_40dp);             //16
            bt_Exit.ImageList = m_ImageList;
            bt_Exit.ImageIndex = 1;

            bt_Payment.Text = "Card" + System.Environment.NewLine + "Pay";
            bt_Payment.TextAlign = ContentAlignment.MiddleRight;
            bt_Payment.ImageList = m_ImageList;
            bt_Payment.ImageIndex = 0;
            bt_Payment.ImageAlign = ContentAlignment.MiddleLeft;
            if (m_blnPinPadAvailable)
            {
                bt_Payment.Enabled = true;
            }
            else
            {
                bt_Payment.Enabled = false;
            }

            //bt_SalesHistory
            bt_SalesHistory.ImageList = m_ImageList;
            bt_SalesHistory.ImageIndex = 14;
            bt_SalesHistory.ImageAlign = ContentAlignment.MiddleLeft;
            //bt_cashPayment.Text = "Cash /" + System.Environment.NewLine + "Manual" + System.Environment.NewLine + "Pay";
            bt_SalesHistory.Text = "Sales" + System.Environment.NewLine + "History";
            bt_SalesHistory.TextAlign = ContentAlignment.MiddleRight;


            bt_cashPayment.ImageList = m_ImageList;
            bt_cashPayment.ImageIndex = 8;
            bt_cashPayment.ImageAlign = ContentAlignment.MiddleLeft;
            //bt_cashPayment.Text = "Cash /" + System.Environment.NewLine + "Manual" + System.Environment.NewLine + "Pay";
            bt_cashPayment.Text = "Cash /" + System.Environment.NewLine + "Manual Pay";
            bt_cashPayment.TextAlign = ContentAlignment.MiddleRight;

            bt_Plus.ImageList = m_ImageList;
            bt_Plus.ImageIndex = 4;
            bt_Plus.ImageAlign = ContentAlignment.MiddleCenter;
            bt_Plus.Text = "";
            bt_Minus.ImageList = m_ImageList;
            bt_Minus.ImageIndex = 5;
            bt_Minus.ImageAlign = ContentAlignment.MiddleCenter;
            bt_Minus.Text = "";

            bt_PrintInvoice.ImageList = m_ImageList;
            bt_PrintInvoice.ImageIndex = 7;
            bt_PrintInvoice.ImageAlign = ContentAlignment.MiddleLeft;
            bt_PrintInvoice.Text = "Invoice";
            bt_PrintInvoice.TextAlign = ContentAlignment.MiddleRight;

            //bt_OpenCashDrawer on Side bar
            bt_OpenCashDrawer.ImageList = m_ImageList;
            bt_OpenCashDrawer.ImageIndex = 6;
            bt_OpenCashDrawer.ImageAlign = ContentAlignment.MiddleLeft;
            bt_OpenCashDrawer.Text = "Open" + System.Environment.NewLine + "C/D";
            bt_OpenCashDrawer.TextAlign = ContentAlignment.MiddleRight;

            bt_OpenCashDrawer1.ImageList = m_ImageList;
            bt_OpenCashDrawer1.ImageIndex = 6;
            bt_OpenCashDrawer1.ImageAlign = ContentAlignment.MiddleLeft;
            bt_OpenCashDrawer1.Text = "Open" + System.Environment.NewLine + "C/D";
            bt_OpenCashDrawer1.TextAlign = ContentAlignment.MiddleRight;

            bt_LastReprint.ImageList = m_ImageList;
            bt_LastReprint.ImageIndex = 7;
            bt_LastReprint.ImageAlign = ContentAlignment.MiddleLeft;
            bt_LastReprint.Text = "Re-Print" + System.Environment.NewLine + "Last" + System.Environment.NewLine + "Tran";
            bt_LastReprint.TextAlign = ContentAlignment.MiddleRight;

            bt_Office.ImageList = m_ImageList;
            bt_Office.ImageIndex = 10;
            bt_Office.ImageAlign = ContentAlignment.MiddleLeft;
            bt_Office.Text = "Office";
            bt_Office.TextAlign = ContentAlignment.MiddleRight;

            bt_SetQTY.ImageList = m_ImageList;
            bt_SetQTY.ImageIndex = 11;
            bt_SetQTY.ImageAlign = ContentAlignment.MiddleLeft;
            bt_SetQTY.Text = "Multiple";
            bt_SetQTY.TextAlign = ContentAlignment.MiddleRight;

            bt_SaveOrder.ImageList = m_ImageList;
            bt_SaveOrder.ImageIndex = 12;
            bt_SaveOrder.ImageAlign = ContentAlignment.MiddleLeft;
            bt_SaveOrder.Text = "Save" + System.Environment.NewLine + "Order";
            bt_SaveOrder.TextAlign = ContentAlignment.MiddleRight;


            bt_RecallOrder.ImageList = m_ImageList;
            bt_RecallOrder.ImageIndex = 13;
            bt_RecallOrder.ImageAlign = ContentAlignment.MiddleLeft;
            bt_RecallOrder.Text = "Recall" + System.Environment.NewLine + "Order";
            bt_RecallOrder.TextAlign = ContentAlignment.MiddleRight;

            Check_AutoReceipt(false);
            Show_AutoReceipt_Button();

        }

        private void Kill_If_SalesCustomer_Opened()
        {
            List<Form> formsToClose = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                if ((form != this) && (form.Name != "frmLogOn"))
                {
                    formsToClose.Add(form);
                }
            }

            formsToClose.ForEach(f => f.Close());
        }

        private void Load_System_Info()
        {
            string hostName = System.Net.Dns.GetHostName();
            DataAccessPOS dbPOS = new DataAccessPOS();
            stations = dbPOS.Get_Station_By_HostName(hostName);
            if (stations.Count > 0)
            {
                strStation = stations[0].Station;
                strHostName = stations[0].ComputerName;
                util.Logger("Load_System_Info strStation : " + strStation);
                util.Logger("Load_System_Info strHostName : " + strHostName);
            }
            else
            {
                strStation = "";
                strHostName = hostName;
                util.Logger("Error getting Station Info : " + hostName);
                MessageBox.Show("Error getting Station Info. Please call system admin!", "Error");
                this.Close();
            }
            loginUsers = dbPOS.UserLogin(strUserPass);
            if (loginUsers.Count > 0)
            {
                strUserID = loginUsers[0].Id.ToString();
                strUserName = loginUsers[0].FirstName + " " + loginUsers[0].LastName;
                strUserPass = loginUsers[0].PassWord;
                util.Logger("Load_System_Info strUserID : " + strUserID + "," + strUserName);
            }
            else
            {
                util.Logger("Error getting Login Info : " + strUserPass);
                MessageBox.Show("Error getting Login Info. Please call system admin!", "Error");
                this.Close();
            }
            this.Text = "Sales Main ( Terminal : " + strHostName + " / " + strStation + " ) Login User : " + strUserName;

            m_blnPinPadAvailable = Get_PinPad_Information();

            sysconfs = dbPOS.Get_SysConfig_By_Name("PRODUCT_TOP_QUERY_VALUE");
            if (sysconfs.Count > 0)
                m_intQueryTop = int.Parse(sysconfs[0].ConfigValue);
            else
                m_intQueryTop = 100;
            sysconfs = dbPOS.Get_SysConfig_By_Name("IS_TYPE_BUTTONS_TO_NUMS");

            if (sysconfs.Count > 0)
                m_blnNumState = sysconfs[0].ConfigValue == "TRUE" ? true : false;
            else
                m_blnNumState = false;

            strTax1Name = dbPOS.Get_Tax_Name(1);
            strTax2Name = dbPOS.Get_Tax_Name(2);
            strTax3Name = dbPOS.Get_Tax_Name(3);

            sysconfs = dbPOS.Get_SysConfig_By_Name("IS_PRINT_TAX_DETAILS");
            if (sysconfs.Count > 0)
                m_blnPrintTaxDetails = sysconfs[0].ConfigValue == "TRUE" ? true : false;
            else
                m_blnPrintTaxDetails = false;

            sysconfs = dbPOS.Get_SysConfig_By_Name("PRODUCT_BUTTON_SORT_ORDER");
            if (sysconfs.Count > 0)
                m_strProdBtnSortOrder = sysconfs[0].ConfigValue;
            else
                m_strProdBtnSortOrder = "";

            Show_AutoReceipt_Button();
        }
        private bool Get_PinPad_Information()
        {
            string strIPAddress = "";
            string strPortNo = "";
            DataAccessPOS dbPOS = new DataAccessPOS();
            stations.Clear();
            stations = dbPOS.Get_Station_By_Station(strStation);
            //bPaymentree = false;
            if (stations.Count > 0)
            {
                strIPAddress = stations[0].IP_Addr;
                strPortNo = stations[0].IPS_Port.ToString();
                if (
                    (stations[0].IsPaymentree)
                    && (!string.IsNullOrEmpty(stations[0].Client_Id))
                    && (!string.IsNullOrEmpty(stations[0].Location))
                    && (!string.IsNullOrEmpty(stations[0].Register))
                    )
                {
                    m_blnPaymentree = true;
                }
                return Check_PinPad_Connectivity(strIPAddress, strPortNo);
            }
            else
            {
                //text_IPADDR.Text = "192.168.1.189";
                //text_PortNo.Text = "7788";
            }
            return false;
        }
        private bool Check_PinPad_Connectivity(string p_strIPAddr, string p_strPortNo)
        {
            int portNo = 0;
            portNo = int.Parse(p_strPortNo);

            if (string.IsNullOrEmpty(p_strIPAddr))
            {
                //MessageBox.Show("Please check database : Station data empty");
                util.Logger("Please check PinPad : " + p_strIPAddr + "," + p_strPortNo);
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
                tcpClient = new TcpClient(p_strIPAddr, portNo);
                tcpClient.SendTimeout = 5000;
                tcpClient.ReceiveTimeout = 5000;
            }
            catch (SocketException e)
            {
                util.Logger("Unable to connect to PinPad : " + e.ErrorCode + " , " + e.Message + " : " + p_strIPAddr + "," + p_strPortNo);
                return false;
            }
            util.Logger("PinPad connected : " + p_strIPAddr + "," + p_strPortNo);
            return true;
        }
        public void Set_PassCode(string pPassCode)
        {
            strUserPass = pPassCode;
            util.Logger("passcode : " + pPassCode);
        }
        //Public Const CON_TRAN_CATEGORY_NAME_0 As String = "General"
        //Public Const CON_TRAN_CATEGORY_NAME_1 As String = "Deposit"
        //Public Const CON_TRAN_CATEGORY_NAME_2 As String = "Recycling Fee"
        //Public Const CON_TRAN_CATEGORY_NAME_3 As String = "Chill Charge"
        //Public Const CON_TRAN_CATEGORY_NAME_4 As String = "Discount"
        //Public Const CON_TRAN_CATEGORY_NAME_5 As String = "Free Ticket"
        //Public Const CON_TRAN_CATEGORY_NAME_6 As String = "Rounding"    'by FK 20170823
        private void Load_Existing_Orders()
        {
            string strTaxShort = "";
            int iSeq = 0;

            dgv_Orders_Initialize();
            DataAccessPOS dbPOS = new DataAccessPOS();
            orders.Clear();
            orders = dbPOS.Get_ParentOrders_by_Station(strStation);
            util.Logger("Load_Existing_Orders strStation : " + strStation);
            if (orders.Count > 0)
            {
                ////////////////////////////////////////////////
                // Add the ordered item into datagrid view
                ////////////////////////////////////////////////
                isNewInvoice = true;
                iNewInvNo = orders[0].InvoiceNo;
                foreach (var order in orders)
                {
                    float iAmount = 0;
                    if (order.ParentId == 0)
                    {
                        iSeq++;
                    }
                    if (order.OrderCategoryId == 0)
                    {
                        iAmount = order.Quantity * order.OutUnitPrice;
                        strTaxShort = "";
                        strTaxShort += order.IsTax1 ? strTax1Name.Substring(0, 1) : "";
                        strTaxShort += order.IsTax2 ? strTax2Name.Substring(0, 1) : "";
                        strTaxShort += order.IsTax3 ? strTax3Name.Substring(0, 1) : "";
                        this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                                   order.ProductName,
                                                                                   order.Quantity.ToString(),
                                                                                   order.OutUnitPrice.ToString("0.00"),
                                                                                   //iAmount.ToString("0.00"),
                                                                                   order.Amount.ToString("0.00"),
                                                                                   strTaxShort,
                                                                                   order.Id.ToString(),
                                                                                   order.ProductId.ToString(),
                                                                                   order.BarCode
                                });
                        childOrders.Clear();
                        childOrders = dbPOS.Get_ChildOrders_by_Station(strStation,  order.Id);
                        foreach (var corder in childOrders)
                        {
                            strTaxShort = "";
                            strTaxShort += corder.IsTax1 ? strTax1Name.Substring(0, 1) : "";
                            strTaxShort += corder.IsTax2 ? strTax2Name.Substring(0, 1) : "";
                            strTaxShort += corder.IsTax3 ? strTax3Name.Substring(0, 1) : "";
                            if (corder.OrderCategoryId == 0)
                            {
                                iAmount = corder.Quantity * corder.OutUnitPrice;
                                this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                                   corder.ProductName,
                                                                                   corder.Quantity.ToString(),
                                                                                   corder.OutUnitPrice.ToString("0.00"),
                                                                                   //iAmount.ToString("0.00"),
                                                                                   corder.Amount.ToString("0.00"),
                                                                                   strTaxShort,
                                                                                   corder.Id.ToString(),
                                                                                   corder.ProductId.ToString(),
                                                                                   corder.BarCode
                                });
                            }
                            else if (corder.OrderCategoryId > 0) // Discount
                            {
                                iAmount = corder.Amount;
                                this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                                   corder.ProductName,
                                                                                   corder.Quantity.ToString(),
                                                                                   corder.OutUnitPrice.ToString("0.00"),
                                                                                   //iAmount.ToString("0.00"),
                                                                                   corder.Amount.ToString("0.00"),
                                                                                   strTaxShort,
                                                                                   corder.Id.ToString(),
                                                                                   corder.ProductId.ToString(),
                                                                                   corder.BarCode
                                });
                                this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = corder.RFTagId;
                                DataGridViewRow row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                                row.DefaultCellStyle.ForeColor = Color.Red;
                            }
                            if (corder.RFTagId > 0)
                            {
                                this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = corder.RFTagId;
                                DataGridViewRow row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                                row.DefaultCellStyle.ForeColor = Color.Blue;
                            }
                            else
                            {
                                this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = null;
                            }
                            this.dgv_Orders.FirstDisplayedScrollingRowIndex = dgv_Orders.RowCount - 1;

                        }
                    }
                    else if (order.OrderCategoryId > 0) // Discount
                    {
                        strTaxShort = "";
                        strTaxShort += order.IsTax1 ? strTax1Name.Substring(0, 1) : "";
                        strTaxShort += order.IsTax2 ? strTax2Name.Substring(0, 1) : "";
                        strTaxShort += order.IsTax3 ? strTax3Name.Substring(0, 1) : "";
                        iAmount = order.Amount;
                        this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                                   order.ProductName,
                                                                                   order.Quantity.ToString(),
                                                                                   order.OutUnitPrice.ToString("0.00"),
                                                                                   //iAmount.ToString("0.00"),
                                                                                   order.Amount.ToString("0.00"),
                                                                                   strTaxShort,
                                                                                   order.Id.ToString(),
                                                                                   order.ProductId.ToString(),
                                                                                   order.BarCode
                                });

                    }
                    if (order.RFTagId > 0)
                    {
                        this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = order.RFTagId;
                        DataGridViewRow row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                        row.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = null;
                    }
                    this.dgv_Orders.FirstDisplayedScrollingRowIndex = dgv_Orders.RowCount - 1;
                    //this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView(order.RFTagId);
                    //this.dgv_Orders.Rows[Get_OrderedItem_Index_of_GridView(order.RFTagId)].Selected = true;
                    
                    //this.dgv_Orders.Rows[dgv_Orders.RowCount - 1].Selected = true;
                }
            }
            Calculate_Total_Due();
        }

        private bool Get_Tax_Rates()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            m_strDefaultTaxCode = dbPOS.Get_SysConfig_By_Name("DEFAULT_TAXCODE")[0].ConfigValue;
            
            allTaxs = dbPOS.Get_All_Tax();

            if (m_strDefaultTaxCode != "")
            {
                taxs = dbPOS.Get_Tax_By_Code(m_strDefaultTaxCode);
                if (taxs.Count > 0)
                {
                    m_TaxRate1 = taxs[0].Tax1;
                    m_TaxRate2 = taxs[0].Tax2;
                    m_TaxRate3 = taxs[0].Tax3;
                    m_bIsTax3IncTax1 = taxs[0].IsTax3IncTax1;
                    return true;
                }
                else
                {
                    // Error getting tax rate
                    return false;
                }
            }
            else
            {
                taxs = dbPOS.Get_All_Tax();
                if (taxs.Count > 0)
                {
                    m_TaxRate1 = taxs[0].Tax1;
                    m_TaxRate2 = taxs[0].Tax2;
                    m_TaxRate3 = taxs[0].Tax3;
                    m_bIsTax3IncTax1 = taxs[0].IsTax3IncTax1;
                    return true;
                }
                else
                {
                    // Error getting tax rate
                    return false;
                }
            }
        }

        public void CallBack(UIntPtr wparam, UIntPtr lparam)
        {
            int iret;
            UInt32 aip_id = 0;
            UInt32 tag_id = 0;
            UInt32 ant_id = 0;
            Byte dsfid = 0;
            Byte[] uid = new Byte[8];
            iret = RFIDLIB.rfidlib_aip_iso15693.ISO15693_ParseTagDataReport(lparam, ref aip_id, ref tag_id, ref ant_id, ref dsfid, uid);
            if (iret == 0)
            {
                /* It is ISO15693 tag data */
                object[] pList = { aip_id, tag_id, ant_id, dsfid, uid };
                Invoke(new InventoryTagReportEventHandler(AddTag), pList);
                //ListViewItem lvi = new ListViewItem();
                //lvi.Text = BitConverter.ToString(uid).Replace("-", string.Empty);
                //listView1.Items.Add(lvi);
            }

        }
        public void AddTag(UInt32 aip_id, UInt32 tag_id, UInt32 ant_id, Byte dsfid, Byte[] uid)
        {
            ListViewItem lvi = new ListViewItem();
            String tagtype;
            String strUid;
            strUid = BitConverter.ToString(uid, 0, 8).Replace("-", string.Empty);
            pnlReceipt.Visible = false;
            switch (tag_id)
            {
                case 1:
                    tagtype = "NXP ICODE SLI";
                    break;
                case 2:
                    tagtype = "Tag-it HF-I plus";
                    break;
                case 4:
                    tagtype = "Fujitsu MB89R118C";
                    break;
                case 5:
                    tagtype = "ST M24LR64";
                    break;
                case 6:
                    tagtype = "ST M24LR16E";
                    break;
                case 7:
                    tagtype = "NXP ICODE SLIX";
                    break;
                case 8:
                    tagtype = "Tag-it HF-I Standard";
                    break;
                case 9:
                    tagtype = "Tag-it HF-I Pro";
                    break;
                default:
                    tagtype = "Unknown tag";
                    break;
            }
            bool found = false;
            int i;
            for (i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[2].Text == strUid && listView1.Items[i].SubItems[4].Text == ant_id.ToString())
                {
                    found = true;
                    break;
                }

            }
            if (!found)
            {
                Byte[] baDsfid = new Byte[1];
                baDsfid[0] = dsfid;
                lvi.Text = tagtype;
                lvi.SubItems.Add(BitConverter.ToString(baDsfid).Replace("-", string.Empty));
                lvi.SubItems.Add(strUid);
                lvi.SubItems.Add("1");
                lvi.SubItems.Add(ant_id.ToString());
                listView1.Items.Add(lvi);
                //comboBox3.Items.Add(strUid);
            }
            else
            {
                String strCounter = listView1.Items[i].SubItems[3].Text;
                int counter;
                counter = int.Parse(strCounter);
                counter++;
                if (counter >= 100000)
                {
                    counter = 1;
                }
                listView1.Items[i].SubItems[3].Text = counter.ToString();
            }
            //label13.Text = listView1.Items.Count.ToString();
        }
        private delegate void InventoryTagReportEventHandler(UInt32 aip_id, UInt32 tag_id, UInt32 ant_id, Byte dsfid, Byte[] uid);
        private delegate void delegateInventoryFinishCallback();
        public void InventoryFinishCallback()
        {
            //button5.Enabled = true;
            //button6.Enabled = false;
            //button3.Enabled = true;
            inventoryState = 0;
        }
        private void Load_RFID_Drivers()
        {
            util.Logger("Load_RFID_Drivers");
            /// ///////////////////////////////////////////////
            /// <Rfid variables init>
            hreader = (UIntPtr)0;
            hTag = (UIntPtr)0;
            hTagIcodeslix = (UIntPtr)0;
            hTagTiHFIPlus = (UIntPtr)0;

            enableAFI = 0;
            AFI = 0;
            onlyNewTag = 0;
            asyncReport = false;
            callbackDelegate = new RFIDLIB.RFIDLIB_EVENT_CALLBACK(CallBack);
            openState = 0;
            inventoryState = 0;
            readerType = 0;
            AntennaSel = new byte[16];
            AntennaSelCount = 0;

            readerDriverInfoList = new ArrayList();
            airInterfaceProtList = new ArrayList();
            /* 
             *  Call required, when application load ,this API just only need to load once
             *  Load all reader driver dll from drivers directory, like "rfidlib_ANRD201.dll"  
             *  To avoid Error : Project Build Option -> General -> Conditional compliation Symbols : UNICODE
             */
            RFIDLIB.rfidlib_reader.RDR_LoadReaderDrivers("");

            /*
             * Not call required,it can be Omitted in your own appliation
             * enum and show loaded reader driver 
             */
            UInt32 nCount;
            nCount = RFIDLIB.rfidlib_reader.RDR_GetLoadedReaderDriverCount();
            uint i;
            for (i = 0; i < nCount; i++)
            {
                UInt32 nSize;
                CReaderDriverInf driver = new CReaderDriverInf();
                StringBuilder strCatalog = new StringBuilder();
                strCatalog.Append('\0', 64);

                nSize = (UInt32)strCatalog.Capacity;
                RFIDLIB.rfidlib_reader.RDR_GetLoadedReaderDriverOpt(i, RFIDLIB.rfidlib_def.LOADED_RDRDVR_OPT_CATALOG, strCatalog, ref nSize);
                driver.m_catalog = strCatalog.ToString();
                if (driver.m_catalog == RFIDLIB.rfidlib_def.RDRDVR_TYPE_READER) // Only reader we need
                {
                    StringBuilder strName = new StringBuilder();
                    strName.Append('\0', 64);
                    nSize = (UInt32)strName.Capacity;
                    RFIDLIB.rfidlib_reader.RDR_GetLoadedReaderDriverOpt(i, RFIDLIB.rfidlib_def.LOADED_RDRDVR_OPT_NAME, strName, ref nSize);
                    driver.m_name = strName.ToString();

                    StringBuilder strProductType = new StringBuilder();
                    strProductType.Append('\0', 64);
                    nSize = (UInt32)strProductType.Capacity;
                    RFIDLIB.rfidlib_reader.RDR_GetLoadedReaderDriverOpt(i, RFIDLIB.rfidlib_def.LOADED_RDRDVR_OPT_ID, strProductType, ref nSize);
                    driver.m_productType = strProductType.ToString();

                    StringBuilder strCommSupported = new StringBuilder();
                    strCommSupported.Append('\0', 64);
                    nSize = (UInt32)strCommSupported.Capacity;
                    RFIDLIB.rfidlib_reader.RDR_GetLoadedReaderDriverOpt(i, RFIDLIB.rfidlib_def.LOADED_RDRDVR_OPT_COMMTYPESUPPORTED, strCommSupported, ref nSize);
                    driver.m_commTypeSupported = (UInt32)int.Parse(strCommSupported.ToString());

                    readerDriverInfoList.Add(driver);
                }

            }
            for (i = 0; i < readerDriverInfoList.Count; i++)
            {
                CReaderDriverInf drv = (CReaderDriverInf)(readerDriverInfoList[(int)i]);
                //comboBox6.Items.Add(drv.m_name);
            }

        }

        private void Open_RFID_Connection()
        {
            /*
             * Try to open communcation layer for specified reader 
             */
            //string strReaderDriverName = ((CReaderDriverInf)(readerDriverInfoList[readerType])).m_name;
            string strReaderDriverName = "M201";
            DataAccessPOS dbPOS = new DataAccessPOS();
            string strCOMPort = dbPOS.Get_SysConfig_By_Name("RFID_READER_COMPORT")[0].ConfigValue; //"COM1";
            string strBaudRate = "38400";
            string strFrame = "8E1";
            string connstr = "";
            // Build serial communication connection string
            connstr = RFIDLIB.rfidlib_def.CONNSTR_NAME_RDTYPE + "=" + strReaderDriverName + ";" +
                                      RFIDLIB.rfidlib_def.CONNSTR_NAME_COMMTYPE + "=" + RFIDLIB.rfidlib_def.CONNSTR_NAME_COMMTYPE_COM + ";" +
                                      RFIDLIB.rfidlib_def.CONNSTR_NAME_COMNAME + "=" + strCOMPort + ";" +
                                      RFIDLIB.rfidlib_def.CONNSTR_NAME_COMBARUD + "=" + strBaudRate + ";" +
                                      RFIDLIB.rfidlib_def.CONNSTR_NAME_COMFRAME + "=" + strFrame + ";" +
                                      RFIDLIB.rfidlib_def.CONNSTR_NAME_BUSADDR + "=" + "255";
            // Call required to open reader driver
            int iret = 0;
            UInt32 antennaCount = 0;
            iret = RFIDLIB.rfidlib_reader.RDR_Open(connstr, ref hreader);
            if (iret != 0)
            {
                /*
                 *  Open fail:
                 *  if you Encounter this error ,make sure you has called the API "RFIDLIB.rfidlib_reader.RDR_LoadReaderDrivers("\\Drivers")" 
                 *  when application load
                 */
                util.Logger("Failed to connect RFID Reader : " + iret.ToString());
                if (iret == -24)
                {
                    MessageBox.Show("Information : Failed to connect RFID Reader : " + iret.ToString() + " Check your Scanner! Scan will be disabled !", "POS Sales");
                }
                else if (iret == -19)
                {
                    MessageBox.Show("Information : Only One Application is able to connect to the Scanner : " + iret.ToString() + " Please exit Kitchen module and Try again !", "POS Sales");
                }
                //checkedListBox1.Enabled = true;
                //button2.Enabled = true;
                bt_Start.Enabled = false;
                bt_Stop.Enabled = false;
                openState = 1;
                isRFIDConnected = false;
            }
            else
            {
                /*
                 * Open Ok and try to get some information from driver ,and assign value to the correspondding control 
                 */

                // this API is not required in your own application
                // Get antenna count
                antennaCount = RFIDLIB.rfidlib_reader.RDR_GetAntennaInterfaceCount(hreader);
                int i;
                for (i = 0; i < antennaCount; i++)
                {
                    int iAnt;
                    iAnt = i + 1;

                    //checkedListBoxAntenna.Items.Add("Antenna#" + iAnt.ToString());
                    //comboBox7.Items.Add("Antenna#" + iAnt.ToString());
                }
                //button19.Enabled = false;
                //checkedListBoxAntenna.Enabled = false;
                //comboBox7.Enabled = false;
                if (antennaCount > 1)
                {
                    //checkedListBoxAntenna.Enabled = true;
                }


                // this API is not required in your own application
                // To get supported air protocol interface of the reader ,such as ISO15693 ,ISO14443a....
                //checkedListBox2.Items.Clear();
                UInt32 index = 0;

                UInt32 AIType;
                while (true)
                {
                    AIType = 0;
                    iret = RFIDLIB.rfidlib_reader.RDR_GetSupportedAirInterfaceProtocol(hreader, index, ref AIType);
                    if (iret != 0)
                    {
                        break;
                    }
                    StringBuilder namebuf = new StringBuilder();
                    namebuf.Append('\0', 128);
                    RFIDLIB.rfidlib_reader.RDR_GetAirInterfaceProtName(hreader, AIType, namebuf, (UInt32)namebuf.Capacity);

                    CSupportedAirProtocol aip = new CSupportedAirProtocol();
                    aip.m_ID = AIType;
                    aip.m_name = namebuf.ToString();
                    aip.m_en = true;
                    airInterfaceProtList.Add(aip);

                    //checkedListBox2.Items.Add(aip.m_name, true);

                    index++;
                }

                /*
                 * Enable controls
                 */
                //button2.Enabled = false;
                //button3.Enabled = true;
                //button4.Enabled = true;
                //button5.Enabled = true;
                //button7.Enabled = true;
                //button30.Enabled = true;

                ////ST M24LR page 
                //button61.Enabled = true;
                //button58.Enabled = true;
                //button61.Enabled = true;
                //button59.Enabled = true;

                ////ST LRI2k page
                //bntLRI2kConn.Enabled = true;
                bt_Start.Enabled = true;
                openState = 1;
                isRFIDConnected = true;
            }

        }
        public void DoInventory()
        {
            try
            {
                Boolean enISO15693, enISO14443a, enISO18000p3m3;
                delegate_tag_report_handle cbTagReportHandle;

                cbTagReportHandle = new delegate_tag_report_handle(dele_tag_report_handler);
                enISO15693 = enISO14443a = enISO18000p3m3 = false;
                /* check air protocol */
                for (int i = 0; i < airInterfaceProtList.Count; i++)
                {
                    CSupportedAirProtocol aip;
                    aip = (CSupportedAirProtocol)airInterfaceProtList[i];
                    if (aip.m_en)
                    {
                        if (aip.m_ID == RFIDLIB.rfidlib_def.RFID_APL_ISO15693_ID)
                        {
                            //create ISO15693 inventory parameter  
                            enISO15693 = true;
                        }
                        else if (aip.m_ID == RFIDLIB.rfidlib_def.RFID_APL_ISO14443A_ID)
                        {
                            //create ISO14443A inventory parameter  
                            enISO14443a = true;
                        }
                        else if (aip.m_ID == RFIDLIB.rfidlib_def.RFID_APL_ISO18000P3M3)
                        {
                            enISO18000p3m3 = true;
                        }
                    }
                }
                int iret;
                Byte AIType = RFIDLIB.rfidlib_def.AI_TYPE_NEW;
                if (onlyNewTag == 1)
                {
                    AIType = RFIDLIB.rfidlib_def.AI_TYPE_CONTINUE;  //only new tag inventory 
                }
                while (!_shouldStop)
                {

                    UInt32 nTagCount = 0;
                    iret = tag_inventory(AIType, AntennaSelCount, AntennaSel, enISO15693, enISO14443a, enISO18000p3m3, enableAFI, AFI, cbTagReportHandle, ref nTagCount);
                    if (iret == 0)
                    {
                        // inventory ok

                    }
                    else
                    {
                        // inventory error 
                    }
                    AIType = RFIDLIB.rfidlib_def.AI_TYPE_NEW;
                    if (onlyNewTag == 1)
                    {
                        AIType = RFIDLIB.rfidlib_def.AI_TYPE_CONTINUE;  //only new tag inventory 
                    }
                }
                object[] pFinishList = { };
                try
                {
                    Invoke(new delegateInventoryFinishCallback(InventoryFinishCallback), pFinishList);
                }
                catch (Exception e)
                {
                    ////////////////////////////////////////////////////////////////////////////
                    // Ignore the exception since Thread.join() does not work when stopping
                    //MessageBox.Show("Error :" + e.Message);
                }

                /*
                 *  If API RDR_SetCommuImmeTimeout is called when stop, API RDR_ResetCommuImmeTimeout 
                 *  must be called too, Otherwise, an error -5 may occurs .
                 */
                RFIDLIB.rfidlib_reader.RDR_ResetCommuImmeTimeout(hreader);
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("DoInventory Thread - caught ThreadAbortException - resetting.");
                Console.WriteLine("Exception message: {0}", e.Message);
                Thread.ResetAbort();
            }
            Console.WriteLine("DoInventory Thread - still alive and working.");
            Console.WriteLine("DoInventory Thread - finished working.");
        }
        public int tag_inventory(
                               Byte AIType,
                                 Byte AntennaSelCount,
                                 Byte[] AntennaSel,
                                bool enable15693,
                                bool enable14443A,
                                bool enable18000p3m3,
                                  Byte enableAFI,
                                 Byte afiVal,
                                delegate_tag_report_handle tagReportHandler,
                                 ref UInt32 nTagCount)
        {
            int iret;
            iret = 0;
            UIntPtr InvenParamSpecList = UIntPtr.Zero;
            InvenParamSpecList = RFIDLIB.rfidlib_reader.RDR_CreateInvenParamSpecList();
            if (InvenParamSpecList.ToUInt64() != 0)
            {
                if (enable15693 == true)
                {
                    RFIDLIB.rfidlib_aip_iso15693.ISO15693_CreateInvenParam(InvenParamSpecList, 0, enableAFI, AFI, 0);
                }
                if (enable14443A == true)
                {
                    RFIDLIB.rfidlib_aip_iso14443A.ISO14443A_CreateInvenParam(InvenParamSpecList, 0);
                }
                if (enable18000p3m3)
                {
                    RFIDLIB.rfidlib_aip_iso18000p3m3.ISO18000p3m3_CreateInvenParam(InvenParamSpecList, 0, 0, 0, RFIDLIB.rfidlib_def.ISO18000p6C_Dynamic_Q);
                }
            }
            nTagCount = 0;
            LABEL_TAG_INVENTORY:

            /////////////////////////////////////////////////////////
            if (hreader != (UIntPtr)0)
            {
                try
                {
                    iret = RFIDLIB.rfidlib_reader.RDR_TagInventory(hreader, AIType, AntennaSelCount, AntennaSel, InvenParamSpecList);
                }
                catch (System.AccessViolationException ex)
                {
                    // Recompile as a.NET 3.5 assembly and run it in .NET 4.0.
                    // Add a line to your application's config file under the configuration/runtime element: 
                    //  < runtime >
                    //        < legacyCorruptedStateExceptionsPolicy enabled = "true" />
                    //  </ runtime >
                    Console.WriteLine("{0} AccessViolationException caught.", ex);
                    iret = -1;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    iret = -1;

                }

                if (iret == 0 || iret == -21)
                {
                    nTagCount += RFIDLIB.rfidlib_reader.RDR_GetTagDataReportCount(hreader);
                    UIntPtr TagDataReport;
                    TagDataReport = (UIntPtr)0;
                    TagDataReport = RFIDLIB.rfidlib_reader.RDR_GetTagDataReport(hreader, RFIDLIB.rfidlib_def.RFID_SEEK_FIRST); //first
                    while (TagDataReport.ToUInt64() > 0)
                    {
                        UInt32 aip_id = 0;
                        UInt32 tag_id = 0;
                        UInt32 ant_id = 0;
                        Byte dsfid = 0;
                        Byte uidlen = 0;
                        Byte[] uid = new Byte[16];

                        /* Parse iso15693 tag report */
                        if (enable15693 == true)
                        {
                            iret = RFIDLIB.rfidlib_aip_iso15693.ISO15693_ParseTagDataReport(TagDataReport, ref aip_id, ref tag_id, ref ant_id, ref dsfid, uid);
                            if (iret == 0)
                            {
                                uidlen = 8;
                                object[] pList = { aip_id, tag_id, ant_id, uid, (int)uidlen };
                                try
                                {
                                    Invoke(tagReportHandler, pList);
                                }
                                catch (Exception e)
                                {
                                    Console.Beep(9000, 1000);
                                    return iret;
                                }
                                //tagReportHandler(hreader, aip_id, tag_id, ant_id, uid ,8);
                            }
                        }

                        /* Parse Iso14443A tag report */
                        if (enable14443A == true)
                        {
                            iret = RFIDLIB.rfidlib_aip_iso14443A.ISO14443A_ParseTagDataReport(TagDataReport, ref aip_id, ref tag_id, ref ant_id, uid, ref uidlen);
                            if (iret == 0)
                            {
                                object[] pList = { aip_id, tag_id, ant_id, uid, (int)uidlen };
                                Invoke(tagReportHandler, pList);
                                //tagReportHandler(hreader, aip_id, tag_id, ant_id, uid, uidlen);
                            }
                        }

                        /* Parse Iso18000-3 mode 3  tag report */
                        if (enable18000p3m3)
                        {
                            UInt32 metaFlags = 0;
                            Byte[] tagData = new Byte[32];
                            UInt32 tagDataLen = (UInt32)tagData.Length;
                            iret = RFIDLIB.rfidlib_aip_iso18000p3m3.ISO18000p3m3_ParseTagDataReport(TagDataReport, ref aip_id, ref tag_id, ref ant_id, ref metaFlags, tagData, ref tagDataLen);
                            if (iret == 0)
                            {
                                object[] pList = { aip_id, tag_id, ant_id, tagData, (int)tagDataLen };
                                Invoke(tagReportHandler, pList);
                            }
                        }

                        /* Get Next report from buffer */
                        try
                        {
                            TagDataReport = RFIDLIB.rfidlib_reader.RDR_GetTagDataReport(hreader, RFIDLIB.rfidlib_def.RFID_SEEK_NEXT); //next
                        }
                        catch (Exception e)
                        {
                            // Beep at 5000 Hz for 1 second
                            Console.Beep(9000, 1000);
                        }
                    }
                    if (iret == -21) // stop trigger occur,need to inventory left tags
                    {
                        AIType = RFIDLIB.rfidlib_def.AI_TYPE_CONTINUE;//use only-new-tag inventory 
                        goto LABEL_TAG_INVENTORY;
                    }
                    iret = 0;
                }
            }
            if (InvenParamSpecList.ToUInt64() != 0) RFIDLIB.rfidlib_reader.DNODE_Destroy(InvenParamSpecList);

            return iret;
        }

        internal void SetCashPayment(bool p_bCashPayment)
        {
            bCashPayment = p_bCashPayment;
            util.Logger("SalesMain : Cash Payment is just now set to TRUE!");
            //throw new NotImplementedException();
        }

        public delegate void delegate_tag_report_handle(UInt32 AIPType, UInt32 tagType, UInt32 antID, Byte[] uid, int uidlen);
        public void dele_tag_report_handler(UInt32 AIPType, UInt32 tagType, UInt32 antID, Byte[] uid, int uidlen)
        {

            String strUid;

            int iret;
            String strAIPName, strTagTypeName;
            StringBuilder sbAIPName = new StringBuilder();
            sbAIPName.Append('\0', 128);
            UInt32 nSize = (UInt32)sbAIPName.Capacity;
            iret = RFIDLIB.rfidlib_reader.RDR_GetAIPTypeName(hreader, AIPType, sbAIPName, ref nSize);
            if (iret != 0)
            {
                strAIPName = "Unknown";
            }
            else
            {
                strAIPName = sbAIPName.ToString();
            }

            StringBuilder sbTagName = new StringBuilder();
            sbTagName.Append('\0', 128);
            nSize = (UInt32)sbTagName.Capacity;
            iret = RFIDLIB.rfidlib_reader.RDR_GetTagTypeName(hreader, AIPType, tagType, sbTagName, ref nSize);
            if (iret != 0)
            {
                strTagTypeName = "Unknown";
            }
            else
            {
                strTagTypeName = sbTagName.ToString();
            }

            strUid = BitConverter.ToString(uid, 0, (int)uidlen).Replace("-", string.Empty);

            bool found = false;
            int i;
            for (i = 0; i < listView1.Items.Count; i++)
            {
                // skip if the tag is already on the list
                //                if (listView1.Items[i].SubItems[2].Text == strUid && listView1.Items[i].SubItems[4].Text == antID.ToString())
                if (listView1.Items[i].SubItems[2].Text == strUid)
                {
                    bool found2 = false;
                    int j;
                    for (j = 0; j < listView2.Items.Count; j++)
                    {
                        //if (listView2.Items[j].SubItems[2].Text == strUid && listView2.Items[j].SubItems[4].Text == antID.ToString())
                        if (listView2.Items[j].SubItems[2].Text == strUid)
                        {
                            found2 = true;
                            break;
                        }
                    }
                    if (!found2)
                    {
                        ///////////////////////////////////////////////////////////
                        // New tag
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = strAIPName;
                        lvi.SubItems.Add(strTagTypeName);
                        lvi.SubItems.Add(strUid);
                        lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"));
                        //lvi.SubItems.Add(antID.ToString());
                        //lvi.SubItems.Add(selectedBTN.Text);
                        //
                        ///////////////////////////////////////////////////////////////////
                        if (Add_RFIDTag_Into_Order(strUid))
                        {
                            listView2.Items.Add(lvi);
                            Console.Beep(4000, 15);
                        }
                        else
                        {
                            Console.Beep(5000, 2000);
                        }
                        // Beep at 5000 Hz for 1 second

                    }
                    listView1.Items[i].Remove();
                    found = true;
                    break;
                }

            }
            if (!found)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = strAIPName;
                lvi.SubItems.Add(strTagTypeName);
                lvi.SubItems.Add(strUid);
                lvi.SubItems.Add(DateTime.Now.ToString("hh.mm.ss.ffffff"));
                lvi.SubItems.Add(antID.ToString());
                listView1.Items.Add(lvi);
            }
            else
            {
                //String strCounter = listView1.Items[i].SubItems[3].Text;
                //int counter;
                //counter = int.Parse(strCounter);
                //counter++;
                //if (counter >= 100000)
                //{
                //    counter = 1;
                //}
                //listView1.Items[i].SubItems[3].Text = counter.ToString();
            }

            /* you can try to read or write tag below */
            //int iret ;
            //UIntPtr hTag = UIntPtr.Zero ;
            //if (AIPType == RFIDLIB.rfidlib_def.RFID_APL_ISO15693_ID){
            //     /* iso15693 example to read multiple blocks here */
            //    iret = RFIDLIB.rfidlib_aip_iso15693.ISO15693_Connect(hreader, tagType, 1, uid, ref hTag);
            //    if(iret == 0){
            //        UInt32 numOfBlksRead ;
            //        UInt32 bytesRead;
            //        Byte[] bufBlocks = new Byte[64];
            //        numOfBlksRead = bytesRead =0 ;
            //        iret = RFIDLIB.rfidlib_aip_iso15693.ISO15693_ReadMultiBlocks(hreader, hTag, 1, 0, 4, ref numOfBlksRead, bufBlocks,(UInt32) bufBlocks.GetLength(0), ref bytesRead);
            //        if(iret == 0){
            //            /* read multiple blocks ok */
            //        }

            //        RFIDLIB.rfidlib_reader.RDR_TagDisconnect(hreader, hTag);
            //    }
            //}
            //else if (AIPType == RFIDLIB.rfidlib_def.RFID_APL_ISO14443A_ID && tagType == RFIDLIB.rfidlib_def.RFID_ISO14443A_PICC_NXP_MIFARE_S50_ID)
            //{
            //    /* iso14443a mifare s50 read block example here */
            //    iret = RFIDLIB.rfidlib_aip_iso14443A.MFCL_Connect(hreader, 0/* 0:s50,1:s70*/, uid, ref hTag);
            //    if(iret == 0){
            //        Byte[] block = new Byte[16] ;
            //        iret = RFIDLIB.rfidlib_aip_iso14443A.MFCL_ReadBlock(hreader,hTag,0,block,(UInt32)block.GetLength(0)) ;
            //        if(iret == 0) {
            //            /* read block ok*/
            //        }
            //        RFIDLIB.rfidlib_reader.RDR_TagDisconnect(hreader, hTag);
            //    }
            //}

        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="strUid"></param>
        // Add tags into order
        private bool Add_RFIDTag_Into_Order(string strUid)
        {
            string strTaxShort = "";
            int iSeq = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            float fTax1, fTax2, fTax3 = 0;

            util.Logger(" Add_RFIDTag_Into_Order : strUid = " + strUid + " InvNo = " + iNewInvNo.ToString());

            pnlReceipt.Visible = false;
            if (!isNewInvoice)   // Set when start button is pressed
            {
                
                iNewInvNo = dbPOS1.Get_New_InvoiceNo();
                int iSavedOrderInvNo = dbPOS.Get_SavedOrders_NextInvoiceNo();

                if (iNewInvNo < iSavedOrderInvNo)
                {
                    iNewInvNo = iSavedOrderInvNo;
                }
                util.Logger(" Add_RFIDTag_Into_Order Get_New_InvoiceNo : InvoiceNo = " + iNewInvNo.ToString());
                isNewInvoice = true;
            }
            rfids.Clear();
            rfids = dbPOS.Get_RFIDTags_By_SerialNo(strUid);
            if (rfids.Count > 0)
            {
                if (rfids[0].IsUsed)
                {
                    // Error : RFID Tag is already used
                    util.Logger("Error : RFID Tag is already used , Tag Serial#= " + rfids[0].SerialNo +",Inv#:" + rfids[0].InvoiceNo);
                    //MessageBox.Show("Error : RFID Tag is already used , Tag Serial#= " + rfids[0].SerialNo + ",Inv#:" + rfids[0].InvoiceNo);
                    txtSelectedMenu.Text = "Error : RFID Tag is already used , Tag Serial#= " + rfids[0].SerialNo + ",Inv#:" + rfids[0].InvoiceNo;
                    txtSelectedMenu.ForeColor = Color.Red;
                    txtSelectedMenu.BackColor = Color.White;
                    return false;
                }
                prods.Clear();
                prods = dbPOS.Get_Product_By_ID(rfids[0].ProductId);
                if (prods.Count > 0)
                {
                    orders.Clear();
                    //_Order_By_ProdId(iNewInvNo, rfids[0].ProductId);
                    orders = dbPOS.Get_Order_By_Invoice_RFTagId(iNewInvNo, rfids[0].Id);
                    /*if (orders.Count == 1)
                    {
                        //this.dgv_Orders.Rows.Add(new String[] { rfids[0].Id.ToString(),
                        //                                                       prods[0].ProductName,
                        //                                                       prods[0].OutUnitPrice.ToString(),
                        //                                                       prod.OutUnitPrice.ToString()
                        //            });
                        //this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;
                        orders[0].Quantity++;
                        int rowIndex = Get_OrderedItem_Index_of_GridView(rfids[0].ProductId);
                        if (rowIndex > -1) // found the product
                        {
                            // update datagrid veiw
                            dgv_Orders.Rows[rowIndex].Cells[2].Value = orders[0].Quantity.ToString();
                            float iAmount = orders[0].Quantity * prods[0].OutUnitPrice;
                            dgv_Orders.Rows[rowIndex].Cells[4].Value = iAmount.ToString("0.00");
                            // update orders table
                            orders[0].Amount = orders[0].OutUnitPrice * orders[0].Quantity;
                            if (orders[0].IsTax1) orders[0].Tax1 = orders[0].Amount * orders[0].Tax1Rate;
                            if (orders[0].IsTax2) orders[0].Tax2 = orders[0].Amount * orders[0].Tax2Rate;
                            if (orders[0].IsTax3) orders[0].Tax3 = orders[0].Amount * orders[0].Tax3Rate;
                            orders[0].LastModDate = DateTime.Now.ToShortDateString();
                            orders[0].LastModTime = DateTime.Now.ToShortTimeString();
                            dbPOS.Update_Orders_Amount_Qty(orders[0]);
                        }
                    }
                    else */
                    if (orders.Count > 1)
                    {
                        // Error on duplicated data exists
                        util.Logger("Add_RFIDTag : Error on duplicated Tag data exists : InvoiceNo = " + iNewInvNo.ToString() + ", TagId =" + rfids[0].Id + ", Serial# =" + rfids[0].SerialNo);
                        MessageBox.Show("Add_RFIDTag : Error on duplicated Tag data exists : InvoiceNo = " + iNewInvNo.ToString() + ", TagId =" + rfids[0].Id + ", Serial# =" + rfids[0].SerialNo);
                    }
                    else //  (orders.Count == 0)
                    {
                        ////////////////////////////////////////////////
                        // Add the ordered item into Orders table
                        ////////////////////////////////////////////////
                        ///
                        orders.Clear();
                        // Tax Calculation
                        fTax1 = prods[0].IsTax1 ? m_TaxRate1 * prods[0].OutUnitPrice : 0;
                        fTax2 = prods[0].IsTax2 ? m_TaxRate2 * prods[0].OutUnitPrice : 0;
                        if (m_bIsTax3IncTax1)
                            fTax3 = prods[0].IsTax3 ? m_TaxRate3 * (prods[0].OutUnitPrice + fTax1) : 0;
                        else
                            fTax3 = prods[0].IsTax3 ? m_TaxRate3 * prods[0].OutUnitPrice : 0;

                        orders.Add(new POS_OrdersModel()
                        {
                            TranType = "20",
                            ProductId = prods[0].Id,
                            ProductName = prods[0].ProductName,
                            SecondName = prods[0].SecondName,
                            ProductTypeId = prods[0].ProductTypeId,
                            InUnitPrice = prods[0].InUnitPrice,
                            OutUnitPrice = prods[0].OutUnitPrice,
                            IsTax1 = prods[0].IsTax1,
                            IsTax2 = prods[0].IsTax2,
                            IsTax3 = prods[0].IsTax3,
                            Quantity = 1,
                            Amount = prods[0].OutUnitPrice * 1,
                            Tax1Rate = m_TaxRate1,
                            Tax2Rate = m_TaxRate2,
                            Tax3Rate = m_TaxRate3,
                            Tax1 = fTax1,
                            Tax2 = fTax2,
                            Tax3 = fTax3,
                            Deposit = prods[0].Deposit,
                            RecyclingFee = prods[0].RecyclingFee,
                            ChillCharge = prods[0].ChillCharge,
                            InvoiceNo = iNewInvNo,
                            IsPaidComplete = false,
                            CompleteDate = "",
                            CompleteTime = "",
                            CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                            CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                            CreateUserId = System.Convert.ToInt32(strUserID),
                            CreateUserName = strUserName,
                            CreateStation = strStation,
                            LastModDate = "",
                            LastModTime = "",
                            LastModUserId = System.Convert.ToInt32(strUserID),
                            LastModUserName = "",
                            LastModStation = "",
                            RFTagId = rfids[0].Id,
                            ParentId = 0,
                            OrderCategoryId = 0,
                            IsDiscounted = false,
                            BarCode = prods[0].BarCode
                        });
                        int iNewOrderId = dbPOS.Insert_Order(orders[0]);
                        if (iNewOrderId > 0)
                        {
                            ////////////////////////////////////////////////
                            // Add the ordered item into datagrid view
                            ////////////////////////////////////////////////
                            float iAmount = orders[0].Quantity * orders[0].OutUnitPrice;
                            iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                            strTaxShort += prods[0].IsTax1 ? strTax1Name.Substring(0, 1) : "";
                            strTaxShort += prods[0].IsTax2 ? strTax2Name.Substring(0, 1) : "";
                            strTaxShort += prods[0].IsTax3 ? strTax3Name.Substring(0, 1) : "";

                            this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                               prods[0].ProductName,
                                                                               "1",
                                                                               prods[0].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               strTaxShort,
                                                                               iNewOrderId.ToString(),
                                                                               prods[0].Id.ToString(),
                                                                               prods[0].BarCode
                            });
                            this.dgv_Orders.Rows[this.dgv_Orders.RowCount-1].Tag = rfids[0].Id;
                            DataGridViewRow row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                            row.DefaultCellStyle.ForeColor = Color.Blue;
                            //this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView(prods[0].Id);
                            //this.dgv_Orders.Rows[Get_OrderedItem_Index_of_GridView(prods[0].Id)].Selected = true;
                            this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView_By_RFTagID(rfids[0].Id);
                            //this.dgv_Orders.Rows[Get_OrderedItem_Index_of_GridView(rfids[0].Id)].Selected = true;
                            /////////////////////////////////////////////////
                            // RFID Tags are set DiscountRage ?
                            /////////////////////////////////////////////////
                            if (rfids[0].DiscountRate > 0)
                            {
                                // Get Parent Order Id
                                int iParentId = iNewOrderId; // dbPOS.Get_Latest_OrderId_by_InvoiceNo_ProductId(orders[0].InvoiceNo, orders[0].ProductId);
                                                             ////////////////////////////////////////////////
                                                             // Add the Discount order item into Orders table
                                                             ////////////////////////////////////////////////
                                ///
                                // Tax Calculation
                                fTax1 = prods[0].IsTax1 ? -(m_TaxRate1 * (prods[0].OutUnitPrice * (rfids[0].DiscountRate / 100))) : 0;
                                fTax2 = prods[0].IsTax2 ? -(m_TaxRate2 * (prods[0].OutUnitPrice * (rfids[0].DiscountRate / 100))) : 0;
                                if (m_bIsTax3IncTax1)
                                    fTax3 = prods[0].IsTax3 ? -(m_TaxRate3 * ((prods[0].OutUnitPrice + fTax1) * (rfids[0].DiscountRate / 100))) : 0;
                                else
                                    fTax3 = prods[0].IsTax3 ? -(m_TaxRate3 * (prods[0].OutUnitPrice * (rfids[0].DiscountRate / 100))) : 0;

                                orders.Add(new POS_OrdersModel()
                                {
                                    TranType = "20",
                                    ProductId = 0,
                                    ProductName = ">Discount(" + rfids[0].DiscountRate+"%)",
                                    SecondName = ">Discount(" + rfids[0].DiscountRate + "%)",
                                    ProductTypeId = 0,
                                    InUnitPrice = 0,
                                    OutUnitPrice = 0,
                                    IsTax1 = prods[0].IsTax1,
                                    IsTax2 = prods[0].IsTax2,
                                    IsTax3 = prods[0].IsTax3,
                                    Quantity = 1,
                                    Amount = -(prods[0].OutUnitPrice * (rfids[0].DiscountRate / 100)),
                                    Tax1Rate = m_TaxRate1,
                                    Tax2Rate = m_TaxRate2,
                                    Tax3Rate = m_TaxRate3,
                                    Tax1 = fTax1,
                                    Tax2 = fTax2, 
                                    Tax3 = fTax3,
                                    Deposit = 0,
                                    RecyclingFee = 0,
                                    ChillCharge = 0,
                                    InvoiceNo = iNewInvNo,
                                    IsPaidComplete = false,
                                    CompleteDate = "",
                                    CompleteTime = "",
                                    CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                                    CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                                    CreateUserId = System.Convert.ToInt32(strUserID),
                                    CreateUserName = strUserName,
                                    CreateStation = strStation,
                                    LastModDate = "",
                                    LastModTime = "",
                                    LastModUserId = System.Convert.ToInt32(strUserID),
                                    LastModUserName = "",
                                    LastModStation = "",
                                    RFTagId = rfids[0].Id,
                                    ParentId = iParentId,
                                    OrderCategoryId = 4,    /* Discount */
                                    IsDiscounted = false,
                                    BarCode = prods[0].BarCode
                                });
                                int iNewDiscOrderId = dbPOS.Insert_Order(orders[orders.Count-1]);
                                if (iNewDiscOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                                    {
                                    ////////////////////////////////////////////////
                                    // Add the ordered item into datagrid view
                                    ////////////////////////////////////////////////
                                    iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                    iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                                    strTaxShort = "";
                                    strTaxShort += orders[orders.Count - 1].IsTax1 ? strTax1Name.Substring(0, 1) : "";
                                    strTaxShort += orders[orders.Count - 1].IsTax2 ? strTax2Name.Substring(0, 1) : "";
                                    strTaxShort += orders[orders.Count - 1].IsTax3 ? strTax3Name.Substring(0, 1) : "";
                                    this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                               orders[orders.Count-1].ProductName,
                                                                               "1",
                                                                               orders[orders.Count-1].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               strTaxShort,
                                                                               iNewDiscOrderId.ToString(),
                                                                               orders[orders.Count-1].Id.ToString(),
                                                                               orders[orders.Count-1].BarCode
                                    });
                                    this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = rfids[0].Id;
                                    row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                                    row.DefaultCellStyle.ForeColor = Color.Blue;
                                    //this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView(prods[0].Id);
                                    //this.dgv_Orders.Rows[Get_OrderedItem_Index_of_GridView(prods[0].Id)].Selected = true;
                                    this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView_By_RFTagID(rfids[0].Id);
                                }
                            } //if (rfids[0].DiscountRate > 0)
                            /////////////////////////////////////////////////
                            // Deposit ?
                            /////////////////////////////////////////////////
                            if (orders[0].Deposit > 0)
                            {
                                // Get Parent Order Id
                                int iParentId = iNewOrderId; // dbPOS.Get_Latest_OrderId_by_InvoiceNo_ProductId(orders[0].InvoiceNo, orders[0].ProductId);
                                ////////////////////////////////////////////////
                                // Add the Discount order item into Orders table
                                ////////////////////////////////////////////////
                                orders.Add(new POS_OrdersModel()
                                {
                                    TranType = "20",
                                    ProductId = 0,
                                    ProductName = ">Deposit",
                                    SecondName = ">Deposit",
                                    ProductTypeId = 0,
                                    InUnitPrice = 0,
                                    OutUnitPrice = 0,
                                    IsTax1 = prods[0].IsTax1,
                                    IsTax2 = prods[0].IsTax2,
                                    IsTax3 = prods[0].IsTax3,
                                    Quantity = 1,
                                    Amount = prods[0].Deposit,
                                    Tax1Rate = m_TaxRate1,
                                    Tax2Rate = m_TaxRate2,
                                    Tax3Rate = m_TaxRate3,
                                    Tax1 = 0,
                                    Tax2 = 0,
                                    Tax3 = 0,
                                    Deposit = 0,
                                    RecyclingFee = 0,
                                    ChillCharge = 0,
                                    InvoiceNo = iNewInvNo,
                                    IsPaidComplete = false,
                                    CompleteDate = "",
                                    CompleteTime = "",
                                    CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                                    CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                                    CreateUserId = System.Convert.ToInt32(strUserID),
                                    CreateUserName = strUserName,
                                    CreateStation = strStation,
                                    LastModDate = "",
                                    LastModTime = "",
                                    LastModUserId = System.Convert.ToInt32(strUserID),
                                    LastModUserName = "",
                                    LastModStation = "",
                                    RFTagId = rfids[0].Id,
                                    ParentId = iParentId,
                                    OrderCategoryId = 1 // Deposit
                                    ,
                                    IsDiscounted = false,
                                    BarCode = ""
                                });
                                int iNewDepOrderId = dbPOS.Insert_Order(orders[orders.Count-1]);
                                if (iNewDepOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                                {
                                    ////////////////////////////////////////////////
                                    // Add the ordered item into datagrid view
                                    ////////////////////////////////////////////////
                                    iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                    iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                                    strTaxShort = "";
                                    strTaxShort += orders[orders.Count - 1].IsTax1 ? strTax1Name.Substring(0, 1) : "";
                                    strTaxShort += orders[orders.Count - 1].IsTax2 ? strTax2Name.Substring(0, 1) : "";
                                    strTaxShort += orders[orders.Count - 1].IsTax3 ? strTax3Name.Substring(0, 1) : "";
                                    this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                               orders[orders.Count-1].ProductName,
                                                                               "1",
                                                                               orders[orders.Count-1].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               strTaxShort,
                                                                               iNewDepOrderId.ToString(),
                                                                               orders[orders.Count-1].Id.ToString(),
                                                                               orders[orders.Count-1].BarCode
                                    });
                                    this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = rfids[0].Id;
                                    row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                                    row.DefaultCellStyle.ForeColor = Color.Blue;
                                    //this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView(prods[0].Id);
                                    //this.dgv_Orders.Rows[Get_OrderedItem_Index_of_GridView(prods[0].Id)].Selected = true;
                                    this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView_By_RFTagID(rfids[0].Id);
                                }
                            } //if (orders[0].Deposit > 0)
                            /////////////////////////////////////////////////
                            // RecyclingFee ?
                            /////////////////////////////////////////////////
                            if (orders[0].RecyclingFee > 0)
                            {
                                // Get Parent Order Id
                                int iParentId = iNewOrderId; // dbPOS.Get_Latest_OrderId_by_InvoiceNo_ProductId(orders[0].InvoiceNo, orders[0].ProductId);
                                ////////////////////////////////////////////////
                                // Add the Discount order item into Orders table
                                ////////////////////////////////////////////////
                                orders.Add(new POS_OrdersModel()
                                {
                                    TranType = "20",
                                    ProductId = 0,
                                    ProductName = ">Recycling Fee",
                                    SecondName = ">Recycling Fee",
                                    ProductTypeId = 0,
                                    InUnitPrice = 0,
                                    OutUnitPrice = 0,
                                    IsTax1 = prods[0].IsTax1,
                                    IsTax2 = prods[0].IsTax2,
                                    IsTax3 = prods[0].IsTax3,
                                    Quantity = 1,
                                    Amount = prods[0].RecyclingFee,
                                    Tax1Rate = m_TaxRate1,
                                    Tax2Rate = m_TaxRate2,
                                    Tax3Rate = m_TaxRate3,
                                    Tax1 = 0,
                                    Tax2 = 0,
                                    Tax3 = 0,
                                    Deposit = 0,
                                    RecyclingFee = 0,
                                    ChillCharge = 0,
                                    InvoiceNo = iNewInvNo,
                                    IsPaidComplete = false,
                                    CompleteDate = "",
                                    CompleteTime = "",
                                    CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                                    CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                                    CreateUserId = System.Convert.ToInt32(strUserID),
                                    CreateUserName = strUserName,
                                    CreateStation = strStation,
                                    LastModDate = "",
                                    LastModTime = "",
                                    LastModUserId = System.Convert.ToInt32(strUserID),
                                    LastModUserName = "",
                                    LastModStation = "",
                                    RFTagId = rfids[0].Id,
                                    ParentId = iParentId,
                                    OrderCategoryId = 2 // RecyclingFee
                                    ,IsDiscounted = false
                                    ,BarCode = ""
                                });
                                int iNewRecyOrderId = dbPOS.Insert_Order(orders[orders.Count-1]);
                                if (iNewRecyOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                                {
                                    ////////////////////////////////////////////////
                                    // Add the ordered item into datagrid view
                                    ////////////////////////////////////////////////
                                    iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                    iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                                    strTaxShort = "";
                                    strTaxShort += orders[orders.Count - 1].IsTax1 ? strTax1Name.Substring(0, 1) : "";
                                    strTaxShort += orders[orders.Count - 1].IsTax2 ? strTax2Name.Substring(0, 1) : "";
                                    strTaxShort += orders[orders.Count - 1].IsTax3 ? strTax3Name.Substring(0, 1) : "";
                                    this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                               orders[orders.Count-1].ProductName,
                                                                               "1",
                                                                               orders[orders.Count-1].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               strTaxShort,
                                                                               iNewRecyOrderId.ToString(),
                                                                               orders[orders.Count-1].Id.ToString(),
                                                                               orders[orders.Count-1].BarCode
                                    });
                                    this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = rfids[0].Id;
                                    row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                                    row.DefaultCellStyle.ForeColor = Color.Blue;
                                    //this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView(prods[0].Id);
                                    //this.dgv_Orders.Rows[Get_OrderedItem_Index_of_GridView(prods[0].Id)].Selected = true;
                                    this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView_By_RFTagID(rfids[0].Id);
                                }
                            } //if (orders[0].Deposit > 0)
                            /////////////////////////////////////////////////
                            // ChillCharge ?
                            /////////////////////////////////////////////////
                            if (orders[0].ChillCharge > 0)
                            {
                                // Get Parent Order Id
                                int iParentId = iNewOrderId; // dbPOS.Get_Latest_OrderId_by_InvoiceNo_ProductId(orders[0].InvoiceNo, orders[0].ProductId);
                                ////////////////////////////////////////////////
                                // Add the Discount order item into Orders table
                                ////////////////////////////////////////////////
                                orders.Add(new POS_OrdersModel()
                                {
                                    TranType = "20",
                                    ProductId = 0,
                                    ProductName = ">Chill Charge",
                                    SecondName = ">Chill Charge",
                                    ProductTypeId = 0,
                                    InUnitPrice = 0,
                                    OutUnitPrice = 0,
                                    IsTax1 = prods[0].IsTax1,
                                    IsTax2 = prods[0].IsTax2,
                                    IsTax3 = prods[0].IsTax3,
                                    Quantity = 1,
                                    Amount = prods[0].ChillCharge,
                                    Tax1Rate = m_TaxRate1,
                                    Tax2Rate = m_TaxRate2,
                                    Tax3Rate = m_TaxRate3,
                                    Tax1 = 0,
                                    Tax2 = 0,
                                    Tax3 = 0,
                                    Deposit = 0,
                                    RecyclingFee = 0,
                                    ChillCharge = 0,
                                    InvoiceNo = iNewInvNo,
                                    IsPaidComplete = false,
                                    CompleteDate = "",
                                    CompleteTime = "",
                                    CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                                    CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                                    CreateUserId = System.Convert.ToInt32(strUserID),
                                    CreateUserName = strUserName,
                                    CreateStation = strStation,
                                    LastModDate = "",
                                    LastModTime = "",
                                    LastModUserId = System.Convert.ToInt32(strUserID),
                                    LastModUserName = "",
                                    LastModStation = "",
                                    RFTagId = rfids[0].Id,
                                    ParentId = iParentId,
                                    OrderCategoryId = 3 // ChillCharge
                                    ,
                                    IsDiscounted = false
                                    ,
                                    BarCode = ""
                                });
                                int iNewChillOrderId = dbPOS.Insert_Order(orders[orders.Count - 1]);
                                if (iNewChillOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                                {
                                    ////////////////////////////////////////////////
                                    // Add the ordered item into datagrid view
                                    ////////////////////////////////////////////////
                                    iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                    iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                                    strTaxShort = "";
                                    strTaxShort += orders[orders.Count - 1].IsTax1 ? strTax1Name.Substring(0, 1) : "";
                                    strTaxShort += orders[orders.Count - 1].IsTax2 ? strTax2Name.Substring(0, 1) : "";
                                    strTaxShort += orders[orders.Count - 1].IsTax3 ? strTax3Name.Substring(0, 1) : "";
                                    this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                               orders[orders.Count-1].ProductName,
                                                                               "1",
                                                                               orders[orders.Count-1].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               strTaxShort,
                                                                               iNewChillOrderId.ToString(),
                                                                               orders[orders.Count-1].Id.ToString(),
                                                                               orders[orders.Count-1].BarCode
                                    });
                                    this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = rfids[0].Id;
                                    row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                                    row.DefaultCellStyle.ForeColor = Color.Blue;
                                    //this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView(prods[0].Id);
                                    //this.dgv_Orders.Rows[Get_OrderedItem_Index_of_GridView(prods[0].Id)].Selected = true;
                                    this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView_By_RFTagID(rfids[0].Id);
                                }
                            } //if (orders[0].ChillCharge > 0)
                        }
                        else
                        {
                            //Error insert order
                            util.Logger("Error insert order : InvNo = " + iNewInvNo.ToString() + " SerialNo = " + strUid + ", ProdId = " + rfids[0].ProductId.ToString());
                            MessageBox.Show("Error insert order : InvNo = " + iNewInvNo.ToString() + " SerialNo = " + strUid + ", ProdId = " + rfids[0].ProductId.ToString());
                            return false;
                        }
                    }
                }
                else // Product for the tag not exits
                {
                    // Error 
                    util.Logger("Product for the tag not exits : SerialNo = " + strUid + ", ProdId = " + rfids[0].ProductId.ToString());
                    MessageBox.Show("Product for the tag not exits : SerialNo = " + strUid + ", ProdId = " + rfids[0].ProductId.ToString());
                    return false;
                }
                rfids[0].InvoiceNo = iNewInvNo;
                rfids[0].IsUsed = true;
                rfids[0].DateTimeUsed = DateTime.Now;
                rfids[0].DateTimeDiscount = new DateTime(1900, 01, 01);
                rfids[0].DateTimeDonation = new DateTime(1900, 01, 01);
                int iTagUpdateCnt = dbPOS.Update_RFIDTag(rfids[0]);
            }
            else // RFIDtags not exists
            {
                // Error 
                util.Logger("RFIDtags not exists : SerialNo = " + strUid);
                MessageBox.Show("RFIDtags not exists : SerialNo = " + strUid);
                return false;
            }
            Check_Assorted_Promotions();
            Calculate_Total_Due();
            return true;
        }
        private void Check_Assorted_Promotions()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            //orders = dbPOS.Get_Orders_by_InvoiceNo(iNewInvNo);
            util.Logger("Check_Promotions");
            promos = dbPOS.Get_All_Effective_Promotions();

            if (promos.Count > 0)
            {
                foreach (var promo in promos)
                {
                    pprods = dbPOS.Get_PromoProducts_By_PromoId(promo.Id);
                    string strSQLWhere;
                    if (pprods.Count > 0)
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        foreach (var pprod in pprods)
                        {
                            sb.Append(pprod.ProdId + ",");
                        }
                        strSQLWhere = sb.ToString();
                        // Remove last ","
                        strSQLWhere = strSQLWhere.Substring(0,strSQLWhere.Length-1);
                        util.Logger("Check_Promotions - " + promo.PromoName.ToString() + " " + promo.Id.ToString() + " = " + strSQLWhere);

                        int iOrderedQTY = dbPOS.Get_Order_QTY_By_MutipleProductIds(strStation, strSQLWhere);

                        if (iOrderedQTY >= promo.PromoQTY)
                        {
                            int iDiscountTimes = iOrderedQTY / promo.PromoQTY;

                            Add_Discount_Orders_By_Promotion(promo.PromoName, promo.PromoType, promo.PromoValue, promo.PromoQTY, iOrderedQTY, iDiscountTimes, strSQLWhere);
                            
                            dgv_Orders_Initialize();
                            Load_Existing_Orders();
                            Calculate_Total_Due();
                        }
                    }

                }
            }
        }
        private bool Add_Discount_Orders_By_Promotion(string strPromoName, int iPromoType, float fPromoValue, int iPromoQTY, int iOrderedQTY, int iDiscountTimes, string strSQLWhere)
        {
            string strTaxShort = "";
            int iSeq = 0;

            DataAccessPOS dbPOS = new DataAccessPOS();
            util.Logger("Add_Discount_Orders_By_Promotion");
            //double iTotalAmount = 0;
            double iAverageAmount = 0;
            double iTotalTax1 = 0;
            double iTotalTax2 = 0;
            double iTotalTax3 = 0;
            dbPOS.Delete_Promotion_Discount_Orders(strStation);
            //iTotalAmount = dbPOS.Get_Orders_Amount_By_MultipleProdId(strSQLWhere);
			iAverageAmount = dbPOS.Get_Orders_Average_Amount_By_MultipleProdId(strStation, strSQLWhere);
            //iTotalTax1 = dbPOS.Get_Orders_Tax1_MultipleProdId(strSQLWhere);
            //iTotalTax2 = dbPOS.Get_Orders_Tax2_MultipleProdId(strSQLWhere);
            //iTotalTax3 = dbPOS.Get_Orders_Tax3_MultipleProdId(strSQLWhere);
            pnlReceipt.Visible = false;

            if (iPromoType == 1)
			{
				double iDiscountRate = fPromoValue;
			
                if (iDiscountRate > 0 && iDiscountRate <= 100)
                {
                    orders.Clear();
                    ////////////////////////////////////////////////
                    // Add the ordered item into Orders table
                    ////////////////////////////////////////////////
                    orders.Add(new POS_OrdersModel()
                    {
                        TranType = "20",
                        ProductId = 0,
                        ProductName = strPromoName + "(" + iDiscountRate.ToString() + "%)",
                        SecondName = strPromoName + "(" + iDiscountRate.ToString() + "%)",
                        ProductTypeId = 0,
                        InUnitPrice = 0,
                        OutUnitPrice = 0,
                        IsTax1 = true,
                        IsTax2 = false,
                        IsTax3 = false,
                        Quantity = iDiscountTimes,
                        Amount = (float)(-(iAverageAmount * iPromoQTY * iDiscountTimes) * (iDiscountRate / 100)),
                        Tax1Rate = m_TaxRate1,
                        Tax2Rate = m_TaxRate2,
                        Tax3Rate = m_TaxRate3,
                        Tax1 = (float)(-(iAverageAmount * iPromoQTY * iDiscountTimes) * (iDiscountRate / 100) * m_TaxRate1),
                        Tax2 = 0, // (float)(-iTotalTax2 * (iDiscountRate / 100)),
                        Tax3 = 0, // (float)(-iTotalTax3 * (iDiscountRate / 100)),
                        InvoiceNo = iNewInvNo,
                        IsPaidComplete = false,
                        CompleteDate = "",
                        CompleteTime = "",
                        CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), //DateTime.Now.ToShortDateString(),
                        CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                        CreateUserId = System.Convert.ToInt32(strUserID),
                        CreateUserName = strUserName,
                        CreateStation = strStation,
                        LastModDate = "",
                        LastModTime = "",
                        LastModUserId = System.Convert.ToInt32(strUserID),
                        LastModUserName = "",
                        LastModStation = "",
                        RFTagId = 0,
                        ParentId = 0,
                        OrderCategoryId = 4     // Discount
                        ,
                        IsDiscounted = true     // Promotion
                        ,BarCode = ""
                    });
                    int iNewOrderId = dbPOS.Insert_Order(orders[0]);
                    util.Logger(" ## Discount_Orders_By_Promotion : " + orders[0].Id.ToString() + ", PROD=" + orders[0].ProductName + ", New Amount = " + orders[0].Amount.ToString());
                    if (iNewOrderId > 0)
                    {
                        ////////////////////////////////////////////////
                        // Add the ordered item into datagrid view
                        ////////////////////////////////////////////////
                        float iAmount = orders[0].Amount;
                        iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                        strTaxShort = "";
                        strTaxShort += orders[0].IsTax1 ? strTax1Name.Substring(0, 1) : "";
                        strTaxShort += orders[0].IsTax2 ? strTax2Name.Substring(0, 1) : "";
                        strTaxShort += orders[0].IsTax3 ? strTax3Name.Substring(0, 1) : "";
                        this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                               orders[0].ProductName,
                                                                               "1",
                                                                               orders[0].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               strTaxShort,
                                                                               iNewOrderId.ToString(),
                                                                               prods[0].Id.ToString(),
                                                                               prods[0].BarCode
                            });
                        this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = 0;
                        DataGridViewRow row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        //this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView_By_RFTagID(rfids[0].Id);
                    }
                }
            }
            return true;
        }
        private void Calculate_Total_Due()
        {
            iSubTotal = 0;
            iTaxTotal = 0;
            iTotalDue = 0;
            iTotalItems = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();
            //orders = dbPOS.Get_Orders_by_InvoiceNo(iNewInvNo);
            orders = dbPOS.Get_All_Orders_by_Station(strStation);
            util.Logger("Calculate_Total_Due # of Orders : " + orders.Count.ToString());
            if (orders.Count > 0)
            {
                //iTotalItems = iTotalItems + order.Quantity;
                iTotalItems = orders.FindAll(ord => ord.ProductId > 0).Sum(x => x.Quantity);
                foreach (var order in orders)
                {
                    //if (order.OrderCategoryId == 0)
                    //{
                        iSubTotal = iSubTotal + order.Amount;
                        iTaxTotal = iTaxTotal + (order.Tax1 + order.Tax2 + order.Tax3);
                        iTotalDue = iTotalDue + (order.Amount + order.Tax1 + order.Tax2 + order.Tax3);
                    //}else if (order.OrderCategoryId == 4)   // Discount
                    //{
                    //    iSubTotal = iSubTotal - order.Amount;
                    //    iTaxTotal = iTaxTotal - (order.Tax1 + order.Tax2 + order.Tax3);
                    //    iTotalDue = iTotalDue - (order.Amount + order.Tax1 + order.Tax2 + order.Tax3);
                    //    //iTotalItems = iTotalItems + order.Quantity;
                    //}
                }
            }
            //iTotalItems = dbPOS.Get_ParentOrders_by_Station(strStation).Count;
            fTotDue = iTotalItems;
            txtCount.Text = iTotalItems.ToString("0");
            txt_SubTotal.Text = iSubTotal.ToString("c2");
            txt_TaxTotal.Text = iTaxTotal.ToString("c2");
            txt_TotalDue.Text = iTotalDue.ToString("c2");

        }

        private int Get_OrderedItem_Index_of_GridView_By_RFTagID(int iRFTagId)
        {
            int rowIndex = 0;
            if (dgv_Orders.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv_Orders.Rows)
                {
                    //if (row.Cells[0].Value != null)
                    if (row.Tag != null)
                    {
                        row.Selected = false;
                        /*if (row.Cells[0].Value.ToString() == productId.ToString())
                        {
                            row.Selected = true;
                            this.dgv_Orders.FirstDisplayedScrollingRowIndex = row.Index;
                            rowIndex = row.Index;
                            //return rowIndex;
                        }*/
                        if (row.Tag.ToString() == iRFTagId.ToString())
                        {
                            row.Selected = true;
                            this.dgv_Orders.FirstDisplayedScrollingRowIndex = row.Index;
                            rowIndex = row.Index;
                        }
                    }
                }
            }
            return rowIndex;
        }
        private int Get_OrderedItem_Index_of_GridView_By_ProdID(int iProdId)
        {
            int rowIndex = 0;
            if (dgv_Orders.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv_Orders.Rows)
                {
                    // Product Id row.Cells[7]
                    if (row.Cells[7].Value != null)
                    { 
                        row.Selected = false;
                        if (row.Cells[7].Value.ToString() == iProdId.ToString() && row.Tag == null)
                        {
                            row.Selected = true;
                            this.dgv_Orders.FirstDisplayedScrollingRowIndex = row.Index;
                            rowIndex = row.Index;
                            //return rowIndex;
                        }
                    }
                }
            }
            return rowIndex;
        }
        private int Get_OrderedItem_Index_of_GridView_By_BarCode(string strBarCode)
        {
            int rowIndex = 0;
            if (dgv_Orders.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv_Orders.Rows)
                {
                    if (row.Cells[7].Value != null)
                    {
                        row.Selected = false;
                        if (row.Cells[7].Value.ToString() == strBarCode && row.Tag == null)
                        {
                            row.Selected = true;
                            this.dgv_Orders.FirstDisplayedScrollingRowIndex = row.Index;
                            rowIndex = row.Index;
                            //return rowIndex;
                        }
                    }
                }
            }
            return rowIndex;
        }
        private void dgv_Orders_Initialize()
        {
            this.dgv_Orders.AutoSize = false;
            dgv_Orders.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgv_Orders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Orders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Orders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgv_Orders.ColumnCount = 9;
            this.dgv_Orders.Columns[0].Name = "Seq";
            this.dgv_Orders.Columns[0].Width = 40;
            this.dgv_Orders.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Orders.Columns[1].Name = "Product Name";
            this.dgv_Orders.Columns[1].Width = 115;
            this.dgv_Orders.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgv_Orders.Columns[2].Name = "QTY";
            this.dgv_Orders.Columns[2].Width = 50;
            this.dgv_Orders.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_Orders.Columns[3].Name = "Unit Price";
            this.dgv_Orders.Columns[3].Width = 55;
            this.dgv_Orders.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_Orders.Columns[4].Name = "Amount";
            this.dgv_Orders.Columns[4].Width = 70;
            this.dgv_Orders.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_Orders.Columns[5].Name = "Tax";
            this.dgv_Orders.Columns[5].Width = 40;
            this.dgv_Orders.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_Orders.Columns[6].Name = "OrderId";
            this.dgv_Orders.Columns[6].Width = 0;
            this.dgv_Orders.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_Orders.Columns[7].Name = "Prod Id";
            this.dgv_Orders.Columns[7].Width = 0;
            this.dgv_Orders.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Orders.Columns[8].Name = "BarCode";
            this.dgv_Orders.Columns[8].Width = 0;
            this.dgv_Orders.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgv_Orders.DefaultCellStyle.Font = new Font("Arial Narrow", 12F, FontStyle.Bold);
            this.dgv_Orders.EnableHeadersVisualStyles = false;
            this.dgv_Orders.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold);
            this.dgv_Orders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Orders.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgv_Orders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv_Orders.AllowUserToResizeRows = false;
            dgv_Orders.RowTemplate.Resizable = DataGridViewTriState.True;
            dgv_Orders.RowTemplate.MinimumHeight = 40;
            dgv_Orders.AllowUserToAddRows = false;
        }
        private void PopulateMenuTypeButtons()
        {
            int xPos = 0;
            int yPos = 0;
            int iLines = 0;
            int iColor = 0;

            iCurrentTypePage = 1;
            iTotalTypePages = 1;

            bt_HideSideBar.PerformClick();
            //////////////////////////////////////////////////////
            // Declare and assign number of buttons = 20 
            //System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[30];
            //////////////////////////////////////////////////////
            // Create (20) Buttons: 
            for (int i = 0; i < 1000; i++)
            {
                // Initialize one variable 
                //btnArray[i] = new System.Windows.Forms.Button();
                btnTypeArray[i] = new CustomButton();
                btnTypeArray[i].Click -= new System.EventHandler(ClickMenuTypeButton);
            }

            pnlPType.Controls.Clear();

            DataAccessPOS dbPOS = new DataAccessPOS();
            ptypes = dbPOS.Get_All_ProductTypes();

            if (ptypes.Count > 0)
            {
                int n = 0;
                // Add Default Sales Button
                btnTypeArray[n].Tag = n + 1; // Tag of button 
                btnTypeArray[n].Width = (pnlPType.Width / 4) - 5; // Width of button 
                btnTypeArray[n].Height = (pnlPType.Height / 3) - 5; // ((pnlPType.Height - 35) / 2) - 5; // Height of button
                btnTypeArray[n].Font = new Font("Arial", 11, FontStyle.Bold);
                //btnArray[n].BackColor = Color.LightSteelBlue;
                btnTypeArray[n].ForeColor = Color.AntiqueWhite;
                btnTypeArray[n].CornerRadius = 30;
                btnTypeArray[n].RoundCorners = Corners.TopLeft | Corners.TopRight | Corners.BottomLeft;
                /////////////////////////////////////////////////////
                // 4 Buttons in one line
                /////////////////////////////////////////////////////
                if (n >= 4) // Location of second line of buttons: 
                {
                    if (n % 4 == 0)
                    {
                        xPos = 0;
                        yPos = yPos + btnTypeArray[n].Height + 5;
                        iLines++;
                    }
                }
                if ((n) % 12 == 0)
                {
                    iTotalTypePages++;
                }
                if (iLines > 5)
                {
                    iLines = 1;
                }
                btnTypeArray[n].BackColor = btTypeColor[iLines];
                // Location of button: 
                btnTypeArray[n].Left = xPos;
                btnTypeArray[n].Top = yPos;
                // Add buttons to a Panel: E0040150996E1CA8
                pnlPType.Controls.Add(btnTypeArray[n]);  // Let panel hold the Buttons 
                xPos = xPos + btnTypeArray[n].Width + 5;    // Left of next button 
                                                            // Write English Character: 
                /* **************************************************************** 
                    Menu item button text
                //**************************************************************** */

                //btnArray[n].Text = ((char)(n + 65)).ToString() + (n+1).ToString();

                btnTypeArray[n].Text = "MAIN";
                //if (prod.ProductName.Length > 10)
                //{
                //    int spaceIndex = prod.ProductName.IndexOf(" ", 10);
                //    if (spaceIndex > 10)
                //    {
                //        btnArray[n].Text = prod.ProductName.Substring(0, spaceIndex) + Environment.NewLine + prod.ProductName.Substring(spaceIndex);
                //    }
                //}
                btnTypeArray[n].Tag = 0;

                // the Event of click Button 
                btnTypeArray[n].Click += new System.EventHandler(ClickMenuTypeButton);
                n++;
                foreach (var ptype in ptypes)
                {

                    btnTypeArray[n].Tag = n + 1; // Tag of button 
                    btnTypeArray[n].Width = (pnlPType.Width / 4) - 5; // Width of button 
                    btnTypeArray[n].Height = (pnlPType.Height / 3) - 5; // ((pnlPType.Height - 35) / 2) - 5; // Height of button
                    btnTypeArray[n].Font = new Font("Arial", 11, FontStyle.Bold);
                    //btnArray[n].BackColor = Color.LightSteelBlue;
                    btnTypeArray[n].ForeColor = Color.AntiqueWhite;
                    btnTypeArray[n].CornerRadius = 30;
                    btnTypeArray[n].RoundCorners = Corners.TopLeft | Corners.TopRight | Corners.BottomLeft;
                    //btnArray[n].RoundCorners = Corners.All;
                    //btnArray[n].AutoSize = true;
                    /////////////////////////////////////////////////////
                    // 4 Buttons in one line
                    /////////////////////////////////////////////////////
                    if (n >= 4) // Location of second line of buttons: 
                    {
                        if (n % 4 == 0)
                        {
                            xPos = 0;
                            yPos = yPos + btnTypeArray[n].Height + 5;
                            iLines++;
                        }
                    }
                    if ((n) % 12 == 0)
                    {
                        iTotalTypePages++;
                    }
                    if (iLines > 5)
                    {
                        iLines = 1;
                    }
                    //btnTypeArray[n].BackColor = btTypeColor[iLines];
                    iColor = int.TryParse(ptype.BackColor.ToString(), out iColor) ? iColor : 0;
                    if (iColor != 0)
                    {
                        btnTypeArray[n].BackColor = Color.FromArgb(iColor);
                    }
                    iColor = int.TryParse(ptype.ForeColor.ToString(), out iColor) ? iColor : 0;
                    if (iColor != 0)
                    {
                        btnTypeArray[n].ForeColor = Color.FromArgb(iColor);
                    }

                    // Location of button: 
                    btnTypeArray[n].Left = xPos;
                    btnTypeArray[n].Top = yPos;
                    // Add buttons to a Panel: E0040150996E1CA8
                    pnlPType.Controls.Add(btnTypeArray[n]);  // Let panel hold the Buttons 
                    xPos = xPos + btnTypeArray[n].Width + 5;    // Left of next button 
                                                                // Write English Character: 
                                                                /* **************************************************************** 
                                                                    Menu item button text
                                                                //**************************************************************** */

                    //btnArray[n].Text = ((char)(n + 65)).ToString() + (n+1).ToString();

                    btnTypeArray[n].Text = ptype.TypeName;
                    //if (prod.ProductName.Length > 10)
                    //{
                    //    int spaceIndex = prod.ProductName.IndexOf(" ", 10);
                    //    if (spaceIndex > 10)
                    //    {
                    //        btnArray[n].Text = prod.ProductName.Substring(0, spaceIndex) + Environment.NewLine + prod.ProductName.Substring(spaceIndex);
                    //    }
                    //}
                    btnTypeArray[n].Tag = ptype.Id;

                    // the Event of click Button 
                    btnTypeArray[n].Click += new System.EventHandler(ClickMenuTypeButton);

                    n++;
                }
            }
            lbl_TypePages.Text = iCurrentTypePage.ToString()+"/" + (iTotalTypePages - 1).ToString();
            pnlPType.Enabled = true; // not need now to this button now 
            //label1.Visible = true;



        }
        private void PopulateNumButtons()
        {
            int xPos = 0;
            int yPos = 0;
            int iLines = 0;

            iCurrentTypePage = 1;
            iTotalTypePages = 1;

            bt_HideSideBar.PerformClick();
            //////////////////////////////////////////////////////
            // Declare and assign number of buttons = 20 
            //System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[30];
            //////////////////////////////////////////////////////
            // Create (12) Buttons: 
            for (int i = 0; i < 12; i++)
            {
                // Initialize one variable 
                btnNumArray[i] = new CustomButton();
                btnNumArray[i].Click -= new System.EventHandler(ClickMenuNumButton);
            }

            pnlPType.Controls.Clear();

            for (int n = 0; n < 12; n++)
            {
                btnNumArray[n].Tag = n + 1; // Tag of button 
                btnNumArray[n].Width = (pnlPType.Width / 4) - 5; // Width of button 
                btnNumArray[n].Height = (pnlPType.Height / 3) - 5; // ((pnlPType.Height - 35) / 2) - 5; // Height of button
                btnNumArray[n].Font = new Font("Arial", 18, FontStyle.Bold);
                btnNumArray[n].ForeColor = Color.AntiqueWhite;
                btnNumArray[n].CornerRadius = 10;
                btnNumArray[n].RoundCorners = Corners.TopLeft | Corners.BottomRight | Corners.TopRight | Corners.BottomLeft;

                /////////////////////////////////////////////////////
                // 4 Buttons in one line
                /////////////////////////////////////////////////////
                if (n >= 4) // Location of second line of buttons: 
                {
                    if (n % 4 == 0)
                    {
                        xPos = 0;
                        yPos = yPos + btnNumArray[n].Height + 5;
                        iLines++;
                    }
                }
                if ((n) % 12 == 0)
                {
                    iTotalTypePages++;
                }
                if (iLines > 5)
                {
                    iLines = 1;
                }
                btnNumArray[n].BackColor = btTypeColor[0]; //btTypeColor[iLines];
                // Location of button: 
                btnNumArray[n].Left = xPos;
                btnNumArray[n].Top = yPos;
                // Add buttons to a Panel: E0040150996E1CA8
                pnlPType.Controls.Add(btnNumArray[n]);  // Let panel hold the Buttons 
                xPos = xPos + btnNumArray[n].Width + 5;    // Left of next button 
                                                           // Write English Character: 
                /* **************************************************************** 
                    Menu item button text
                //**************************************************************** */
                if (n < 10)
                {
                    btnNumArray[n].Text = n.ToString();
                    btnNumArray[n].Tag = n;
                }
                else if (n == 10)
                {
                    btnNumArray[n].Text = "C";
                    btnNumArray[n].Tag = "C";
                    btnNumArray[n].BackColor = btTypeColor[1];
                }
                else if (n == 11)
                {
                    btnNumArray[n].Text = "<";
                    btnNumArray[n].Tag = "<";
                    btnNumArray[n].BackColor = btTypeColor[2];
                }

                // the Event of click Button 
                btnNumArray[n].Click += new System.EventHandler(ClickMenuNumButton);
            }
            lbl_TypePages.Text = iCurrentTypePage.ToString() + "/" + (iTotalTypePages - 1).ToString();
            pnlPType.Enabled = true; // not need now to this button now 
            //label1.Visible = true;
        }

        private void ClickMenuNumButton(object sender, EventArgs e)
        {
            CustomButton btn = (CustomButton)sender;
            //btn.BackColor = Color.Yellow;
            //btn.ForeColor = Color.DarkBlue;
            //if (selectedBTN != null)
            //{
                //selectedBTN.BackColor = btColor[2];
                //selectedBTN.ForeColor = Color.Black;
            //}
            if (btn.Tag == "C")
            {
                txtBarCode.Text = "";
            }
            else if (btn.Tag == "<")
            {
                if (txtBarCode.Text.Length > 0)
                {
                    txtBarCode.Text = txtBarCode.Text.Substring(0, txtBarCode.Text.Length - 1);
                }
            }
            else
            {
                txtBarCode.Text = txtBarCode.Text + btn.Tag;
            }
        }

        private void ClickMenuTypeButton(object sender, EventArgs e)
        {
            int iButtonLine = 0;
            int iTypeId = 0;
            int iColor = 0;

            bt_HideSideBar.PerformClick();

            CustomButton btn = (CustomButton)sender;
            btn.BackColor = Color.Yellow;
            btn.ForeColor = Color.DarkBlue;
            if (selectedBTN != null)
            {
                // set the button color to original color from database
                iButtonLine = (iSelectedType_btnArray_Index / 4);
                iTypeId = int.TryParse(selectedBTN.Tag.ToString(), out iTypeId) ? iTypeId : 0;
                if (iTypeId > 0)
                {
                    DataAccessPOS dbPOS = new DataAccessPOS();
                    List<POS_ProductTypeModel> pts = new List<POS_ProductTypeModel>(); 
                    pts = dbPOS.Get_ProductType_By_ID(iTypeId);
                    if (pts.Count > 0)
                    {
                        iColor = int.TryParse(pts[0].BackColor.ToString(), out iColor) ? iColor : 0;
                        if (iColor != 0)
                        {
                            selectedBTN.BackColor = Color.FromArgb(iColor);
                        }
                        iColor = int.TryParse(pts[0].ForeColor.ToString(), out iColor) ? iColor : 0;
                        if (iColor != 0)
                        {
                            selectedBTN.ForeColor = Color.FromArgb(iColor);
                        }
                    }
                }
            }
            //selectedBTN = (Button)sender;
            selectedBTN = (CustomButton)sender;
            iSelectedType_btnArray_Index = Array.IndexOf(btnTypeArray, (CustomButton)sender);
            txtSelectedMenu.Text = "You have now selected menu type [ " + btn.Text + ", " + btn.Tag + " ]";
            iSelectedProdTypeID = int.Parse(string.Format("{0}", btn.Tag));

            PopulateMenuButtons(false, 0);
            BarCode_Get_Focus();

        }

        private void PopulateMenuButtons(bool p_isBIB, int p_int_bibProdId)
        {
            int xPos = 0;
            int yPos = 0;
            int iLines = 0;
            int iColor = 0;

            iCurrentProdPage = 1;
            iTotalProdPages = 1;
            bt_HideSideBar.PerformClick();
            //////////////////////////////////////////////////////
            // Declare and assign number of buttons = 20 
            //System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[30];
            //CustomButton[] btnArray = new CustomButton[35];
            //////////////////////////////////////////////////////
            // Create (20) Buttons: 
            // redefine array size
            btnArray = new CustomButton[m_intQueryTop];
            for (int i = 0; i < m_intQueryTop; i++)
            {
                // Initialize one variable 
                //btnArray[i] = new System.Windows.Forms.Button();
                btnArray[i] = new CustomButton();
                btnArray[i].Click -= new System.EventHandler(ClickMenuButton);
            }

            pnlMenu.Controls.Clear();

            DataAccessPOS dbPOS = new DataAccessPOS();
            if (p_isBIB)
            {
                prods = dbPOS.Get_All_Products_By_BIBProdId(p_int_bibProdId);
            }
            else
            {
                if (iSelectedProdTypeID > 0)
                {
                    if (m_strProdBtnSortOrder != "" && m_strProdBtnSortOrder != null)
                    {
                        try
                        {
                            prods = dbPOS.Get_All_Products_By_ProdType_SortOrder(iSelectedProdTypeID, m_intQueryTop, m_strProdBtnSortOrder);
                        }
                        catch (Exception ex)
                        {
                            //Show a MsgBox with ex.Message
                            MessageBox.Show("PRODUCT_BUTTON_SORT_ORDER " + "configuration Error: " + ex.Message);

                            prods = dbPOS.Get_All_Products_By_ProdType_Sortby_Price(iSelectedProdTypeID, m_intQueryTop);
                        }
                    }
                    else
                    {
                        prods = dbPOS.Get_All_Products_By_ProdType_Sortby_Price(iSelectedProdTypeID, m_intQueryTop);
                    }
                }
                else
                {
                    prods = dbPOS.Get_All_DefaultSales_Products();
                }
            }

            if (prods.Count > 0)
            {
                int n = 0;
                foreach (var prod in prods)
                {
                    // skip if product's IsSameButton is false
                    if (!prod.IsSalesButton)
                    {
                        continue;
                    }
                    btnArray[n].Tag = n;// + 1; // Tag of button 
                    btnArray[n].Width = (pnlMenu.Width / 5) - 5; // Width of button 
                    btnArray[n].Height = (pnlMenu.Height / 5) - 5; // Height of button
                    btnArray[n].Font = new Font("Arial", 9, FontStyle.Bold);
                    //btnArray[n].BackColor = Color.LightSteelBlue;
                    btnArray[n].ForeColor = Color.Black;
                    btnArray[n].CornerRadius = 30;
                    btnArray[n].RoundCorners = Corners.TopLeft | Corners.TopRight | Corners.BottomLeft;
                    //btnArray[n].RoundCorners = Corners.All;
                    //btnArray[n].AutoSize = true;
                    /////////////////////////////////////////////////////
                    // 4 Buttons in one line
                    /////////////////////////////////////////////////////
                    if (n >= 5) // Location of second line of buttons: 
                    {
                        if (n % 5 == 0)
                        {
                            xPos = 0;
                            yPos = yPos + btnArray[n].Height + 5;
                            iLines++;
                        }
                    }
                    if ((n) % 25 == 0)
                    {
                        iTotalProdPages++;
                    }
                    if (iLines > 5)
                    {
                        iLines = 1;
                    }
                    btnArray[n].BackColor = btColor[iLines];
                    // Location of button: 
                    btnArray[n].Left = xPos;
                    btnArray[n].Top = yPos;
                    // Add buttons to a Panel: E0040150996E1CA8
                    pnlMenu.Controls.Add(btnArray[n]);  // Let panel hold the Buttons 
                    xPos = xPos + btnArray[n].Width + 5;    // Left of next button 
                                                            // Write English Character: 
                    /* **************************************************************** 
                        Menu item button text
                    //**************************************************************** */

                    //btnArray[n].Text = ((char)(n + 65)).ToString() + (n+1).ToString();

                    if (prod.IsManualItem)
                    {
                        btnArray[n].ForeColor = Color.DarkRed;
                        btnArray[n].Text = prod.ProductName;
                    }
                    else
                    { 
                        btnArray[n].Text = prod.ProductName + Environment.NewLine + prod.OutUnitPrice.ToString("c2");
                    }
                    iColor = int.TryParse(prod.BackColor.ToString(), out iColor) ? iColor : 0;
                    if (iColor != 0)
                    {
                        btnArray[n].BackColor = Color.FromArgb(iColor);
                    }
                    iColor = int.TryParse(prod.ForeColor.ToString(), out iColor) ? iColor : 0;
                    if (iColor != 0)
                    {
                        btnArray[n].ForeColor = Color.FromArgb(iColor);
                    }
                    if (prod.IsButtonInButton)
                    {
                        // add image on the button
                        //m_ImageList ?
                        btnArray[n].ImageList = m_ImageList;
                        btnArray[n].ImageIndex = 16; //menu
                        btnArray[n].ImageAlign = ContentAlignment.MiddleLeft;
                        btnArray[n].TextAlign = ContentAlignment.MiddleRight;
                        btnArray[n].Text = prod.ProductName;
                    }
                    //if (prod.ProductName.Length > 10)
                    //{
                    //    int spaceIndex = prod.ProductName.IndexOf(" ", 10);
                    //    if (spaceIndex > 10)
                    //    {
                    //        btnArray[n].Text = prod.ProductName.Substring(0, spaceIndex) + Environment.NewLine + prod.ProductName.Substring(spaceIndex);
                    //    }
                    //}
                    btnArray[n].Tag = prod.Id;


                    // the Event of click Button 
                    btnArray[n].Click += new System.EventHandler(ClickMenuButton);

                    n++;
                }
            }
            // If the button is ButtonInButton, add a back button on the right bottom corner of the panel
            if (p_isBIB)
            {
                // Add a back button on the pnlMenu right bottom corner
                xPos = (pnlMenu.Width / 5) * 4;
                yPos = (pnlMenu.Height / 5) * 4;
                btnBack = new CustomButton();
                btnBack.Tag = 0;
                btnBack.Width = (pnlMenu.Width / 5) - 5; // Width of button
                btnBack.Height = (pnlMenu.Height / 5) - 5; // Height of button
                btnBack.Font = new Font("Arial", 9, FontStyle.Bold);
                btnBack.ForeColor = Color.White;
                btnBack.CornerRadius = 30;
                btnBack.RoundCorners = Corners.TopLeft | Corners.TopRight | Corners.BottomLeft;
                btnBack.BackColor = Color.DarkOrange;
                btnBack.Left = xPos;
                btnBack.Top = yPos;
                btnBack.Text = "Back";
                btnBack.ImageList = m_ImageList;
                btnBack.ImageIndex = 15;
                btnBack.ImageAlign = ContentAlignment.MiddleLeft;
                btnBack.TextAlign = ContentAlignment.MiddleRight;
                // the event of click Button
                btnBack.Click += new System.EventHandler(ClickMenuBackButton);
                pnlMenu.Controls.Add(btnBack);

            }
            lbl_ProdPages.Text = iCurrentProdPage.ToString() + "/" + (iTotalProdPages-1).ToString();
            pnlMenu.Enabled = true; // not need now to this button now 
            //label1.Visible = true;
        }

        private void ClickMenuBackButton(object sender, EventArgs e)
        {
            PopulateMenuButtons(false, 0);
        }

        // Result of (Click Button) event, get the text of button 
        public void ClickMenuButton(Object sender, System.EventArgs e)
        {

            bt_HideSideBar.PerformClick();

            int iButtonLine = 0;
            //Button btn = (Button)sender;
            CustomButton btn = (CustomButton)sender;
            //btn.BackColor = Color.Yellow;
            //btn.ForeColor = Color.DarkBlue;
            if (selectedBTN != null)
            {
                iButtonLine = (iSelected_btnArray_Index / 5);
              //  selectedBTN.BackColor = btColor[iButtonLine]; // Color.LightGray;
              //  selectedBTN.ForeColor = Color.Black;
            }
            //selectedBTN = (Button)sender;
            selectedBTN = (CustomButton)sender;

            txtSelectedMenu.Text = "You have now selected menu item [ " + btn.Text + ", " + btn.Tag + " ]";
            util.Logger("ClickMenuButton "+ btn.Tag.ToString());
            ////////////////////////////////////////////////////////////////
            // save variables about selected button values
            iSelected_btnArray_Index = Array.IndexOf(btnArray, (CustomButton)sender);
            int iProdID = int.Parse(string.Format("{0}", btn.Tag));
            if (Add_Order_Manually(iProdID))
            {

            }
            //bt_Stop.PerformClick();
            //bt_Start.PerformClick();
            BarCode_Get_Focus();
        }

        private bool Add_Order_Manually(int pProdID)
        {
            string strTaxShort = "";
            int iSeq = 0;
            bool bQTYPromotionProduct = false;
            int iOrderQty = 1;
            float fTax1, fTax2, fTax3 = 0;

            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            util.Logger("Add_Order_Manually ProdId = "+ pProdID + ", InvoiceNo" + iNewInvNo.ToString());

            pnlReceipt.Visible = false;
            if (!isNewInvoice)   // Set when start button is pressed
            {
                
                iNewInvNo = dbPOS1.Get_New_InvoiceNo();
                int iSavedOrderInvNo = dbPOS.Get_SavedOrders_NextInvoiceNo();

                if (iNewInvNo < iSavedOrderInvNo)
                {
                    iNewInvNo = iSavedOrderInvNo;
                }
                util.Logger(" Add_Order_Manually Get_New_InvoiceNo : InvoiceNo = " + iNewInvNo.ToString());
                isNewInvoice = true;
            }

            prods.Clear();
            prods = dbPOS.Get_Product_By_ID(pProdID);
            if (prods.Count > 0)
            {
                // if the product is buttoninbutton item?
                if (prods[0].IsButtonInButton)
                {
                    // Show button in button items
                    PopulateMenuButtons(true, prods[0].Id);
                    return true;
                }
                if (prods[0].IsManualItem)
                { 
                    Add_Order_ManualItem(pProdID);
                    return true;
                }

                if ((txtQTY.Text != "") && (txtQTY.Text != "0"))
                {
                    try
                    {
                        iOrderQty = Int32.Parse(txtQTY.Text);
                    }
                    catch
                    {
                        iOrderQty = 1;
                    }
                    txtQTY.Text = "";
                }

                // Payout
                if (prods[0].CategoryId == 2)
                    prods[0].OutUnitPrice = prods[0].OutUnitPrice * -1;

                orders.Clear();
                //Get_Order_By_ProdId(iNewInvNo, pProdID);
                orders = dbPOS.Get_NonRFID_Order_By_ProdId(iNewInvNo, pProdID);
                if (orders.Count == 1)
                {
                    orders[0].Quantity += iOrderQty;
                    bQTYPromotionProduct = Check_QTY_Promotion_Product(prods[0], orders[0].Quantity);
                    if (bQTYPromotionProduct)
                    {
                        prods[0].OutUnitPrice = prods[0].PromoPrice1;
                        orders[0].OutUnitPrice = prods[0].PromoPrice1;
                    }
                    //int rowIndex = Get_OrderedItem_Index_of_GridView(pProdID);
                    int rowIndex = Get_OrderedItem_Index_of_GridView_By_ProdID(pProdID);
                    if (rowIndex > -1) // found the product on GridView
                    {
                        // update datagrid veiw
                        dgv_Orders.Rows[rowIndex].Cells[2].Value = orders[0].Quantity.ToString();
                        float iAmount = orders[0].Quantity * prods[0].OutUnitPrice;
                        dgv_Orders.Rows[rowIndex].Cells[3].Value = prods[0].OutUnitPrice.ToString("0.00");
                        dgv_Orders.Rows[rowIndex].Cells[4].Value = iAmount.ToString("0.00");
                        // update orders table
                        orders[0].Amount = orders[0].OutUnitPrice * orders[0].Quantity;
                        if (orders[0].IsTax1) orders[0].Tax1 = orders[0].Amount * orders[0].Tax1Rate;
                        if (orders[0].IsTax2) orders[0].Tax2 = orders[0].Amount * orders[0].Tax2Rate;
                        if (orders[0].IsTax3) orders[0].Tax3 = orders[0].Amount * orders[0].Tax3Rate;
                        orders[0].LastModDate = DateTime.Now.ToString("yyyy-MM-dd");
                        orders[0].LastModTime = DateTime.Now.ToString("HH:mm:ss");
                        dbPOS.Update_Orders_Amount_Qty(orders[0]);

                        // --------------------- Child Orders such as Deposit, Chill charge, Recycling fee
                        childOrders.Clear();
                        childOrders = dbPOS.Get_Child_Order_By_OrderId(iNewInvNo, orders[0].Id);
                        if (childOrders.Count > 0)
                        {
                            foreach (var childOrder in childOrders)
                            {
                                rowIndex = Get_OrderedItem_Index_of_GridView_By_OrderId(childOrder.Id);
                                if (rowIndex > -1) // found the product
                                {
                                    // update datagrid veiw
                                    childOrder.Quantity += iOrderQty;
                                    dgv_Orders.Rows[rowIndex].Cells[2].Value = childOrder.Quantity.ToString();
                                    iAmount = childOrder.Quantity * childOrder.OutUnitPrice;
                                    dgv_Orders.Rows[rowIndex].Cells[3].Value = childOrder.OutUnitPrice.ToString();
                                    dgv_Orders.Rows[rowIndex].Cells[4].Value = iAmount.ToString("0.00");
                                    // update orders table
                                    childOrder.Amount = childOrder.OutUnitPrice * childOrder.Quantity;
                                    if (childOrder.IsTax1) childOrder.Tax1 = childOrder.Amount * childOrder.Tax1Rate;
                                    if (childOrder.IsTax2) childOrder.Tax2 = childOrder.Amount * childOrder.Tax2Rate;
                                    if (childOrder.IsTax3) childOrder.Tax3 = childOrder.Amount * childOrder.Tax3Rate;
                                    childOrder.LastModDate = DateTime.Now.ToString("yyyy-MM-dd");
                                    childOrder.LastModTime = DateTime.Now.ToString("HH:mm:ss");
                                    dbPOS.Update_Orders_Amount_Qty(childOrder);
                                }
                            }
                        }
                        // --------------------- Child Orders such as Deposit, Chill charge, Recycling fee
                    }
                }
                else if (orders.Count > 1)
                {
                    // Error on duplicated data exists
                    util.Logger("Error on duplicated data exists : InvoiceNo = " + iNewInvNo.ToString());
                    MessageBox.Show("Error on duplicated data exists : InvoiceNo = " + iNewInvNo.ToString());
                }
                else //  (orders.Count == 0)
                {
                    ////////////////////////////////////////////////
                    // Add the ordered item into Orders table
                    ////////////////////////////////////////////////
                    ///
                    if (prods[0].TaxCode != null)
                    {
                        if (prods[0].TaxCode != "")
                        {
                            SetTaxRates(prods[0].TaxCode);
                        }
                        else
                        {
                            SetTaxRates(m_strDefaultTaxCode);
                        }
                    }
                    else
                    {
                        SetTaxRates(m_strDefaultTaxCode);
                    }
                    orders.Add(new POS_OrdersModel()
                    {
                        TranType = "20",
                        ProductId = prods[0].Id,
                        ProductName = prods[0].ProductName,
                        SecondName = prods[0].SecondName,
                        ProductTypeId = prods[0].ProductTypeId,
                        InUnitPrice = prods[0].InUnitPrice,
                        OutUnitPrice = prods[0].OutUnitPrice,
                        IsTax1 = prods[0].IsTax1,
                        IsTax2 = prods[0].IsTax2,
                        IsTax3 = prods[0].IsTax3,
                        Quantity = iOrderQty,
                        Amount = prods[0].OutUnitPrice * iOrderQty,
                        Tax1Rate = m_TaxRate1,
                        Tax2Rate = m_TaxRate2,
                        Tax3Rate = m_TaxRate3,
                        Tax1 = prods[0].IsTax1 ? m_TaxRate1 * (prods[0].OutUnitPrice * iOrderQty) : 0,
                        Tax2 = prods[0].IsTax2 ? m_TaxRate2 * (prods[0].OutUnitPrice * iOrderQty) : 0,
                        Tax3 = prods[0].IsTax3 ? m_TaxRate3 * (prods[0].OutUnitPrice * iOrderQty) : 0,
                        Deposit = prods[0].Deposit,
                        RecyclingFee = prods[0].RecyclingFee,
                        ChillCharge = prods[0].ChillCharge,
                        InvoiceNo = iNewInvNo,
                        IsPaidComplete = false,
                        CompleteDate = "",
                        CompleteTime = "",
                        CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                        CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                        CreateUserId = System.Convert.ToInt32(strUserID),
                        CreateUserName = strUserName,
                        CreateStation = strStation,
                        LastModDate = "",
                        LastModTime = "",
                        LastModUserId = System.Convert.ToInt32(strUserID),
                        LastModUserName = "",
                        LastModStation = "",
                        RFTagId = 0,
                        ParentId = 0,
                        OrderCategoryId = 0,
                        IsDiscounted = false,
                        BarCode = prods[0].BarCode
                    });

                    //if (dbPOS.Insert_Order(orders[0]))
                    int iNewOrderId = dbPOS.Insert_Order(orders[0]);
                    if (iNewOrderId > 0)
                    {
                        ////////////////////////////////////////////////
                        // Add the ordered item into datagrid view
                        ////////////////////////////////////////////////
                        float iAmount = orders[0].Quantity * orders[0].OutUnitPrice;
                        iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                        strTaxShort += prods[0].IsTax1 ? strTax1Name.Substring(0, 1) : "";
                        strTaxShort += prods[0].IsTax2 ? strTax2Name.Substring(0, 1) : "";
                        strTaxShort += prods[0].IsTax3 ? strTax3Name.Substring(0, 1) : "";
                        this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                               prods[0].ProductName,
                                                                               orders[0].Quantity.ToString("0"),
                                                                               prods[0].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               strTaxShort,
                                                                               iNewOrderId.ToString(),
                                                                               prods[0].Id.ToString(),
                                                                               prods[0].BarCode
                            });
                        /////////////////////////////////////////////////
                        // Deposit ?
                        /////////////////////////////////////////////////
                        if (orders[0].Deposit > 0)
                        {
                            // Get Parent Order Id
                            int iParentId = iNewOrderId; // dbPOS.Get_Latest_OrderId_by_InvoiceNo_ProductId(orders[0].InvoiceNo, orders[0].ProductId);
                            ////////////////////////////////////////////////
                            // Add the Discount order item into Orders table
                            ////////////////////////////////////////////////
                            SetTaxRates(m_strDefaultTaxCode);
                            orders.Add(new POS_OrdersModel()
                            {
                                TranType = "20",
                                ProductId = 0,
                                ProductName = "> Deposit",
                                SecondName = "> Deposit",
                                ProductTypeId = 0,
                                InUnitPrice = 0,
                                OutUnitPrice = prods[0].Deposit,
                                IsTax1 = prods[0].IsTax1,
                                IsTax2 = prods[0].IsTax2,
                                IsTax3 = prods[0].IsTax3,
                                Quantity = iOrderQty,
                                Amount = prods[0].Deposit * iOrderQty,
                                Tax1Rate = m_TaxRate1,
                                Tax2Rate = m_TaxRate2,
                                Tax3Rate = m_TaxRate3,
                                Tax1 = 0,
                                Tax2 = 0,
                                Tax3 = 0,
                                Deposit = 0,
                                RecyclingFee = 0,
                                ChillCharge = 0,
                                InvoiceNo = iNewInvNo,
                                IsPaidComplete = false,
                                CompleteDate = "",
                                CompleteTime = "",
                                CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                                CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                                CreateUserId = System.Convert.ToInt32(strUserID),
                                CreateUserName = strUserName,
                                CreateStation = strStation,
                                LastModDate = "",
                                LastModTime = "",
                                LastModUserId = System.Convert.ToInt32(strUserID),
                                LastModUserName = "",
                                LastModStation = "",
                                RFTagId = 0,
                                ParentId = iParentId,
                                OrderCategoryId = 1 // Deposit
                                ,
                                IsDiscounted = false
                                ,BarCode = ""
                            });
                            int iNewDepOrderId = dbPOS.Insert_Order(orders[orders.Count-1]);
                            if (iNewDepOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                            {
                                ////////////////////////////////////////////////
                                // Add the ordered item into datagrid view
                                ////////////////////////////////////////////////
                                iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                                this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                               orders[orders.Count-1].ProductName,
                                                                               orders[orders.Count-1].Quantity.ToString(),
                                                                               orders[orders.Count-1].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               "",
                                                                               iNewDepOrderId.ToString(),
                                                                               orders[orders.Count-1].Id.ToString(),
                                                                               orders[orders.Count-1].BarCode
                                    });

                            }
                        } //if (orders[0].Deposit > 0)
                        /////////////////////////////////////////////////
                        // Recycling Fee ?
                        /////////////////////////////////////////////////
                        if (orders[0].RecyclingFee > 0)
                        {
                            // Get Parent Order Id
                            int iParentId = iNewOrderId; // dbPOS.Get_Latest_OrderId_by_InvoiceNo_ProductId(orders[0].InvoiceNo, orders[0].ProductId);
                            ////////////////////////////////////////////////
                            // Add the Discount order item into Orders table
                            ////////////////////////////////////////////////
                            SetTaxRates(m_strDefaultTaxCode);
                            orders.Add(new POS_OrdersModel()
                            {
                                TranType = "20",
                                ProductId = 0,
                                ProductName = "> Recycling Fee",
                                SecondName = "> Recycling Fee",
                                ProductTypeId = 0,
                                InUnitPrice = 0,
                                OutUnitPrice = prods[0].RecyclingFee,
                                IsTax1 = prods[0].IsTax1,
                                IsTax2 = prods[0].IsTax2,
                                IsTax3 = prods[0].IsTax3,
                                Quantity = iOrderQty,
                                Amount = prods[0].RecyclingFee * iOrderQty,
                                Tax1Rate = m_TaxRate1,
                                Tax2Rate = m_TaxRate2,
                                Tax3Rate = m_TaxRate3,
                                Tax1 = 0,
                                Tax2 = 0,
                                Tax3 = 0,
                                Deposit = 0,
                                RecyclingFee = 0,
                                ChillCharge = 0,
                                InvoiceNo = iNewInvNo,
                                IsPaidComplete = false,
                                CompleteDate = "",
                                CompleteTime = "",
                                CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                                CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                                CreateUserId = System.Convert.ToInt32(strUserID),
                                CreateUserName = strUserName,
                                CreateStation = strStation,
                                LastModDate = "",
                                LastModTime = "",
                                LastModUserId = System.Convert.ToInt32(strUserID),
                                LastModUserName = "",
                                LastModStation = "",
                                RFTagId = 0,
                                ParentId = iParentId,
                                OrderCategoryId = 2 // RecyclingFee
                                ,
                                IsDiscounted = false
                                ,BarCode = ""
                            });
                            int iNewRecyOrderId = dbPOS.Insert_Order(orders[orders.Count-1]);
                            if (iNewRecyOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                            {
                                ////////////////////////////////////////////////
                                // Add the ordered item into datagrid view
                                ////////////////////////////////////////////////
                                iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                                this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                               orders[orders.Count-1].ProductName,
                                                                               orders[orders.Count-1].Quantity.ToString(),
                                                                               orders[orders.Count-1].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               "",
                                                                               iNewRecyOrderId.ToString(),
                                                                               orders[orders.Count-1].Id.ToString(),
                                                                               orders[orders.Count-1].BarCode
                                    });

                            }
                        } //if (orders[0].RecyclingFee > 0)
                          /////////////////////////////////////////////////
                          // ChillCharge ?
                          /////////////////////////////////////////////////
                        if (orders[0].ChillCharge > 0)
                        {
                            // Get Parent Order Id
                            int iParentId = iNewOrderId; // dbPOS.Get_Latest_OrderId_by_InvoiceNo_ProductId(orders[0].InvoiceNo, orders[0].ProductId);
                                                         ////////////////////////////////////////////////
                                                         // Add the Chill Charge Sub order item into Orders table
                                                         ////////////////////////////////////////////////
                            orders.Add(new POS_OrdersModel()
                            {
                                TranType = "20",
                                ProductId = 0,
                                ProductName = "> Chill Charge",
                                SecondName = "> Chill Charge",
                                ProductTypeId = 0,
                                InUnitPrice = 0,
                                OutUnitPrice = prods[0].ChillCharge,
                                IsTax1 = prods[0].IsTax1,
                                IsTax2 = prods[0].IsTax2,
                                IsTax3 = prods[0].IsTax3,
                                Quantity = iOrderQty,
                                Amount = prods[0].ChillCharge * iOrderQty,
                                Tax1Rate = m_TaxRate1,
                                Tax2Rate = m_TaxRate2,
                                Tax3Rate = m_TaxRate3,
                                Tax1 = 0,
                                Tax2 = 0,
                                Tax3 = 0,
                                Deposit = 0,
                                RecyclingFee = 0,
                                ChillCharge = 0,
                                InvoiceNo = iNewInvNo,
                                IsPaidComplete = false,
                                CompleteDate = "",
                                CompleteTime = "",
                                CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                                CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                                CreateUserId = System.Convert.ToInt32(strUserID),
                                CreateUserName = strUserName,
                                CreateStation = strStation,
                                LastModDate = "",
                                LastModTime = "",
                                LastModUserId = System.Convert.ToInt32(strUserID),
                                LastModUserName = "",
                                LastModStation = "",
                                RFTagId = 0,
                                ParentId = iParentId,
                                OrderCategoryId = 3 // ChillCharge
                                ,
                                IsDiscounted = false
                                ,
                                BarCode = ""
                            });
                            int iNewChillOrderId = dbPOS.Insert_Order(orders[orders.Count - 1]);
                            if (iNewChillOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                            {
                                ////////////////////////////////////////////////
                                // Add the ordered item into datagrid view
                                ////////////////////////////////////////////////
                                iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                                this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                              orders[orders.Count-1].ProductName,
                                                                              orders[orders.Count-1].Quantity.ToString(),
                                                                              orders[orders.Count-1].OutUnitPrice.ToString("0.00"),
                                                                              iAmount.ToString("0.00"),
                                                                              "",
                                                                              iNewChillOrderId.ToString(),
                                                                              orders[orders.Count-1].Id.ToString(),
                                                                              orders[orders.Count-1].BarCode
                                   });

                            }
                        } //if (orders[0].ChillCharge > 0)
                    }
                    else
                    {
                        //Error insert order
                        util.Logger("Error insert order : InvNo = " + iNewInvNo.ToString() + ", ProdId = " + pProdID);
                        MessageBox.Show("Error insert order : InvNo = " + iNewInvNo.ToString() + ", ProdId = " + pProdID);
                        return false;
                    }
                    this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView_By_ProdID(pProdID);
                    this.dgv_Orders.Rows[Get_OrderedItem_Index_of_GridView_By_ProdID(pProdID)].Selected = true;
                }
            }
            else // Product for the tag not exits
            {
                // Error 
                util.Logger("Product does not exits : ProdId = " + pProdID);
                MessageBox.Show("Product does not exits : ProdId = " + pProdID);
                return false;
            }
            Check_Assorted_Promotions();
            Calculate_Total_Due();
            return true;
        }

        private bool Check_QTY_Promotion_Product(POS_ProductModel p_Product, float p_OrderQty)
        {
            // Check weather p_Product is promotion product
            if (p_Product.PromoStartDate != "" && p_Product.PromoEndDate != "")
            {
                DateTime dtStartDate = DateTime.Parse(p_Product.PromoStartDate);
                DateTime dtEndDate = DateTime.Parse(p_Product.PromoEndDate);
                DateTime dtNow = DateTime.Now;
                if (dtNow >= dtStartDate && dtNow <= dtEndDate)
                {
                    // Check ordered qty is greater or equal than promotion qty
                    if ((p_Product.PromoDay1 <= p_OrderQty) && (p_Product.PromoPrice1 > 0))
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        private bool Add_Order_BarCode(string strBarCode)
        {
            string strTaxShort = "";
            int iSeq = 0;
            int iOrderQty = 1;
            bool bQTYPromotionProduct = false;

            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            util.Logger("Add_Order_BarCode strBarCode = " + strBarCode + ", InvoiceNo" + iNewInvNo.ToString());
            pnlReceipt.Visible = false;
            if (!isNewInvoice)   // Set when start button is pressed
            {
                iNewInvNo = dbPOS1.Get_New_InvoiceNo();
                int iSavedOrderInvNo = dbPOS.Get_SavedOrders_NextInvoiceNo();

                if (iNewInvNo < iSavedOrderInvNo)
                {
                    iNewInvNo = iSavedOrderInvNo;
                }
                util.Logger(" Add_Order_BarCode Get_New_InvoiceNo : InvoiceNo = " + iNewInvNo.ToString());
                isNewInvoice = true;
            }

            prods.Clear();
            prods = dbPOS.Get_Product_By_BarCode(strBarCode);
            if (prods.Count > 0)
            {
                orders.Clear();
                //Get_Order_By_ProdId(iNewInvNo, pProdID);
                orders = dbPOS.Get_NonRFID_Order_By_BarCode(iNewInvNo, strBarCode);
                if (orders.Count == 1)
                {
                    // Multi
                    if ((txtQTY.Text != "") && (txtQTY.Text != "0"))
                    {
                        try
                        {
                            iOrderQty = Int32.Parse(txtQTY.Text);
                        }
                        catch
                        {
                            iOrderQty = 1;
                        }
                        txtQTY.Text = "";
                    }
                    orders[0].Quantity = orders[0].Quantity + iOrderQty;
                    bQTYPromotionProduct = Check_QTY_Promotion_Product(prods[0], orders[0].Quantity);
                    if (bQTYPromotionProduct)
                    {
                        prods[0].OutUnitPrice = prods[0].PromoPrice1;
                        orders[0].OutUnitPrice = prods[0].PromoPrice1;
                    }
                    //int rowIndex = Get_OrderedItem_Index_of_GridView(pProdID);
                    int rowIndex = Get_OrderedItem_Index_of_GridView_By_BarCode(strBarCode);
                    if (rowIndex > -1) // found the product
                    {
                        // update datagrid veiw
                        dgv_Orders.Rows[rowIndex].Cells[2].Value = orders[0].Quantity.ToString();
                        float iAmount = orders[0].Quantity * prods[0].OutUnitPrice;
                        dgv_Orders.Rows[rowIndex].Cells[3].Value = prods[0].OutUnitPrice.ToString("0.00");
                        dgv_Orders.Rows[rowIndex].Cells[4].Value = iAmount.ToString("0.00");
                        // update orders table
                        orders[0].Amount = orders[0].OutUnitPrice * orders[0].Quantity;
                        if (orders[0].IsTax1) orders[0].Tax1 = orders[0].Amount * orders[0].Tax1Rate;
                        if (orders[0].IsTax2) orders[0].Tax2 = orders[0].Amount * orders[0].Tax2Rate;
                        if (orders[0].IsTax3) orders[0].Tax3 = orders[0].Amount * orders[0].Tax3Rate;
                        orders[0].LastModDate = DateTime.Now.ToString("yyyy-MM-dd");
                        orders[0].LastModTime = DateTime.Now.ToString("HH:mm:ss");
                        dbPOS.Update_Orders_Amount_Qty(orders[0]);

                        // --------------------- Child Orders such as Deposit, Chill charge, Recycling fee
                        childOrders.Clear();
                        childOrders = dbPOS.Get_Child_Order_By_OrderId(iNewInvNo, orders[0].Id);
                        if (childOrders.Count > 0)
                        {
                            foreach (var childOrder in childOrders)
                            {
                                rowIndex = Get_OrderedItem_Index_of_GridView_By_OrderId(childOrder.Id);
                                if (rowIndex > -1) // found the product
                                {
                                    // update datagrid veiw
                                    childOrder.Quantity += iOrderQty;
                                    dgv_Orders.Rows[rowIndex].Cells[2].Value = childOrder.Quantity.ToString();
                                    iAmount = childOrder.Quantity * childOrder.OutUnitPrice;
                                    dgv_Orders.Rows[rowIndex].Cells[3].Value = childOrder.OutUnitPrice.ToString();
                                    dgv_Orders.Rows[rowIndex].Cells[4].Value = iAmount.ToString("0.00");
                                    // update orders table
                                    childOrder.Amount = childOrder.OutUnitPrice * childOrder.Quantity;
                                    if (childOrder.IsTax1) childOrder.Tax1 = childOrder.Amount * childOrder.Tax1Rate;
                                    if (childOrder.IsTax2) childOrder.Tax2 = childOrder.Amount * childOrder.Tax2Rate;
                                    if (childOrder.IsTax3) childOrder.Tax3 = childOrder.Amount * childOrder.Tax3Rate;
                                    childOrder.LastModDate = DateTime.Now.ToString("yyyy-MM-dd");
                                    childOrder.LastModTime = DateTime.Now.ToString("HH:mm:ss");
                                    dbPOS.Update_Orders_Amount_Qty(childOrder);
                                }
                            }
                        }
                        // --------------------- Child Orders such as Deposit, Chill charge, Recycling fee
                    }   // if
                }
                else if (orders.Count > 1)
                {
                    // Error on duplicated data exists
                    util.Logger("Error on duplicated data exists : InvoiceNo = " + iNewInvNo.ToString());
                    MessageBox.Show("Error on duplicated data exists : InvoiceNo = " + iNewInvNo.ToString());
                }
                else //  (orders.Count == 0)
                {
                    // Multi
                    if ((txtQTY.Text != "") && (txtQTY.Text != "0"))
                    {
                        try
                        {
                            iOrderQty = Int32.Parse(txtQTY.Text);
                        }
                        catch
                        {
                            iOrderQty = 1;
                        }
                        txtQTY.Text = "";
                    }
                    if (prods[0].TaxCode != null)
                    {
                        if (prods[0].TaxCode != "")
                        {
                            SetTaxRates(prods[0].TaxCode);
                        }
                        else
                        {
                            SetTaxRates(m_strDefaultTaxCode);
                        }
                    }
                    else
                    {
                        SetTaxRates(m_strDefaultTaxCode);
                    }
                    ////////////////////////////////////////////////
                    // Add the ordered item into Orders table
                    ////////////////////////////////////////////////
                    orders.Add(new POS_OrdersModel()
                    {
                        TranType = "20",
                        ProductId = prods[0].Id,
                        ProductName = prods[0].ProductName,
                        SecondName = prods[0].SecondName,
                        ProductTypeId = prods[0].ProductTypeId,
                        InUnitPrice = prods[0].InUnitPrice,
                        OutUnitPrice = prods[0].OutUnitPrice,
                        IsTax1 = prods[0].IsTax1,
                        IsTax2 = prods[0].IsTax2,
                        IsTax3 = prods[0].IsTax3,
                        Quantity = iOrderQty,
                        Amount = prods[0].OutUnitPrice * iOrderQty,
                        Tax1Rate = m_TaxRate1,
                        Tax2Rate = m_TaxRate2,
                        Tax3Rate = m_TaxRate3,
                        Tax1 = prods[0].IsTax1 ? m_TaxRate1 * prods[0].OutUnitPrice : 0,
                        Tax2 = prods[0].IsTax2 ? m_TaxRate2 * prods[0].OutUnitPrice : 0,
                        Tax3 = prods[0].IsTax3 ? m_TaxRate3 * prods[0].OutUnitPrice : 0,
                        Deposit = prods[0].Deposit,
                        RecyclingFee = prods[0].RecyclingFee,
                        ChillCharge = prods[0].ChillCharge,
                        InvoiceNo = iNewInvNo,
                        IsPaidComplete = false,
                        CompleteDate = "",
                        CompleteTime = "",
                        CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                        CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                        CreateUserId = System.Convert.ToInt32(strUserID),
                        CreateUserName = strUserName,
                        CreateStation = strStation,
                        LastModDate = "",
                        LastModTime = "",
                        LastModUserId = System.Convert.ToInt32(strUserID),
                        LastModUserName = "",
                        LastModStation = "",
                        RFTagId = 0,
                        ParentId = 0,
                        OrderCategoryId = 0,
                        IsDiscounted = false,
                        BarCode = prods[0].BarCode
                    });
                    //if (dbPOS.Insert_Order(orders[0]))
                    int iNewOrderId = dbPOS.Insert_Order(orders[0]);
                    if (iNewOrderId > 0)
                    {
                        ////////////////////////////////////////////////
                        // Add the ordered item into datagrid view
                        ////////////////////////////////////////////////
                        float iAmount = orders[0].Quantity * orders[0].OutUnitPrice;
                        iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                        strTaxShort += prods[0].IsTax1 ? strTax1Name.Substring(0, 1) : "";
                        strTaxShort += prods[0].IsTax2 ? strTax2Name.Substring(0, 1) : "";
                        strTaxShort += prods[0].IsTax3 ? strTax3Name.Substring(0, 1) : "";
                        this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                               prods[0].ProductName,
                                                                               orders[0].Quantity.ToString(),
                                                                               prods[0].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               strTaxShort,
                                                                               iNewOrderId.ToString(),
                                                                               prods[0].Id.ToString(),
                                                                               prods[0].BarCode
                            });
                        /////////////////////////////////////////////////
                        // Deposit ?
                        /////////////////////////////////////////////////
                        if (orders[0].Deposit > 0)
                        {
                            // Get Parent Order Id
                            int iParentId = iNewOrderId; // dbPOS.Get_Latest_OrderId_by_InvoiceNo_ProductId(orders[0].InvoiceNo, orders[0].ProductId);
                                                         ////////////////////////////////////////////////
                                                         // Add the Discount order item into Orders table
                                                         ////////////////////////////////////////////////
                            orders.Add(new POS_OrdersModel()
                            {
                                TranType = "20",
                                ProductId = 0,
                                ProductName = "> Deposit",
                                SecondName = "> Deposit",
                                ProductTypeId = 0,
                                InUnitPrice = 0,
                                OutUnitPrice = prods[0].Deposit,
                                IsTax1 = prods[0].IsTax1,
                                IsTax2 = prods[0].IsTax2,
                                IsTax3 = prods[0].IsTax3,
                                Quantity = iOrderQty,
                                Amount = prods[0].Deposit * iOrderQty,
                                Tax1Rate = m_TaxRate1,
                                Tax2Rate = m_TaxRate2,
                                Tax3Rate = m_TaxRate3,
                                Tax1 = 0,
                                Tax2 = 0,
                                Tax3 = 0,
                                Deposit = 0,
                                RecyclingFee = 0,
                                ChillCharge = 0,
                                InvoiceNo = iNewInvNo,
                                IsPaidComplete = false,
                                CompleteDate = "",
                                CompleteTime = "",
                                CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                                CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                                CreateUserId = System.Convert.ToInt32(strUserID),
                                CreateUserName = strUserName,
                                CreateStation = strStation,
                                LastModDate = "",
                                LastModTime = "",
                                LastModUserId = System.Convert.ToInt32(strUserID),
                                LastModUserName = "",
                                LastModStation = "",
                                RFTagId = 0,
                                ParentId = iParentId,
                                OrderCategoryId = 1 // Deposit
                                ,
                                IsDiscounted = false
                                ,
                                BarCode = ""
                            });
                            int iNewDepOrderId = dbPOS.Insert_Order(orders[orders.Count - 1]);
                            if (iNewDepOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                            {
                                ////////////////////////////////////////////////
                                // Add the ordered item into datagrid view
                                ////////////////////////////////////////////////
                                iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                                this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                               orders[orders.Count-1].ProductName,
                                                                               orders[orders.Count-1].Quantity.ToString(),
                                                                               orders[orders.Count-1].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               "",
                                                                               iNewDepOrderId.ToString(),
                                                                               orders[orders.Count-1].Id.ToString(),
                                                                               orders[orders.Count-1].BarCode
                                    });

                            }
                        } //if (orders[0].Deposit > 0)
                        /////////////////////////////////////////////////
                        // Recycling Fee ?
                        /////////////////////////////////////////////////
                        if (orders[0].RecyclingFee > 0)
                        {
                            // Get Parent Order Id
                            int iParentId = iNewOrderId; // dbPOS.Get_Latest_OrderId_by_InvoiceNo_ProductId(orders[0].InvoiceNo, orders[0].ProductId);
                                                         ////////////////////////////////////////////////
                                                         // Add the Discount order item into Orders table
                                                         ////////////////////////////////////////////////
                            orders.Add(new POS_OrdersModel()
                            {
                                TranType = "20",
                                ProductId = 0,
                                ProductName = "> Recycling Fee",
                                SecondName = "> Recycling Fee",
                                ProductTypeId = 0,
                                InUnitPrice = 0,
                                OutUnitPrice = prods[0].RecyclingFee,
                                IsTax1 = prods[0].IsTax1,
                                IsTax2 = prods[0].IsTax2,
                                IsTax3 = prods[0].IsTax3,
                                Quantity = iOrderQty,
                                Amount = prods[0].RecyclingFee * iOrderQty,
                                Tax1Rate = m_TaxRate1,
                                Tax2Rate = m_TaxRate2,
                                Tax3Rate = m_TaxRate3,
                                Tax1 = 0,
                                Tax2 = 0,
                                Tax3 = 0,
                                Deposit = 0,
                                RecyclingFee = 0,
                                ChillCharge = 0,
                                InvoiceNo = iNewInvNo,
                                IsPaidComplete = false,
                                CompleteDate = "",
                                CompleteTime = "",
                                CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                                CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                                CreateUserId = System.Convert.ToInt32(strUserID),
                                CreateUserName = strUserName,
                                CreateStation = strStation,
                                LastModDate = "",
                                LastModTime = "",
                                LastModUserId = System.Convert.ToInt32(strUserID),
                                LastModUserName = "",
                                LastModStation = "",
                                RFTagId = 0,
                                ParentId = iParentId,
                                OrderCategoryId = 2 // RecyclingFee
                                ,
                                IsDiscounted = false
                                ,
                                BarCode = ""
                            });
                            int iNewRecyOrderId = dbPOS.Insert_Order(orders[orders.Count - 1]);
                            if (iNewRecyOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                            {
                                ////////////////////////////////////////////////
                                // Add the ordered item into datagrid view
                                ////////////////////////////////////////////////
                                iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                                this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                               orders[orders.Count-1].ProductName,
                                                                               orders[orders.Count-1].Quantity.ToString(),
                                                                               orders[orders.Count-1].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               "",
                                                                               iNewRecyOrderId.ToString(),
                                                                               orders[orders.Count-1].Id.ToString(),
                                                                               orders[orders.Count-1].BarCode
                                    });

                            }
                        } //if (orders[0].RecyclingFee > 0)
                          /////////////////////////////////////////////////
                          // ChillCharge ?
                          /////////////////////////////////////////////////
                        if (orders[0].ChillCharge > 0)
                        {
                            // Get Parent Order Id
                            int iParentId = iNewOrderId; // dbPOS.Get_Latest_OrderId_by_InvoiceNo_ProductId(orders[0].InvoiceNo, orders[0].ProductId);
                                                         ////////////////////////////////////////////////
                                                         // Add the Chill Charge Sub order item into Orders table
                                                         ////////////////////////////////////////////////
                            orders.Add(new POS_OrdersModel()
                            {
                                TranType = "20",
                                ProductId = 0,
                                ProductName = "> Chill Charge",
                                SecondName = "> Chill Charge",
                                ProductTypeId = 0,
                                InUnitPrice = 0,
                                OutUnitPrice = prods[0].ChillCharge,
                                IsTax1 = prods[0].IsTax1,
                                IsTax2 = prods[0].IsTax2,
                                IsTax3 = prods[0].IsTax3,
                                Quantity = iOrderQty,
                                Amount = prods[0].ChillCharge * iOrderQty,
                                Tax1Rate = m_TaxRate1,
                                Tax2Rate = m_TaxRate2,
                                Tax3Rate = m_TaxRate3,
                                Tax1 = 0,
                                Tax2 = 0,
                                Tax3 = 0,
                                Deposit = 0,
                                RecyclingFee = 0,
                                ChillCharge = 0,
                                InvoiceNo = iNewInvNo,
                                IsPaidComplete = false,
                                CompleteDate = "",
                                CompleteTime = "",
                                CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                                CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                                CreateUserId = System.Convert.ToInt32(strUserID),
                                CreateUserName = strUserName,
                                CreateStation = strStation,
                                LastModDate = "",
                                LastModTime = "",
                                LastModUserId = System.Convert.ToInt32(strUserID),
                                LastModUserName = "",
                                LastModStation = "",
                                RFTagId = 0,
                                ParentId = iParentId,
                                OrderCategoryId = 3 // ChillCharge
                                ,
                                IsDiscounted = false
                                ,
                                BarCode = ""
                            });
                            int iNewChillOrderId = dbPOS.Insert_Order(orders[orders.Count - 1]);
                            if (iNewChillOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                            {
                                ////////////////////////////////////////////////
                                // Add the ordered item into datagrid view
                                ////////////////////////////////////////////////
                                iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                                this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                              orders[orders.Count-1].ProductName,
                                                                              orders[orders.Count-1].Quantity.ToString(),
                                                                              orders[orders.Count-1].OutUnitPrice.ToString("0.00"),
                                                                              iAmount.ToString("0.00"),
                                                                              "",
                                                                              iNewChillOrderId.ToString(),
                                                                              orders[orders.Count-1].Id.ToString(),
                                                                              orders[orders.Count-1].BarCode
                                   });

                            }
                        } //if (orders[0].ChillCharge > 0)
                    }
                    else
                    {
                        //Error insert order
                        util.Logger("Error insert order : InvNo = " + iNewInvNo.ToString() + ", barCode = " + strBarCode);
                        MessageBox.Show("Error insert order : InvNo = " + iNewInvNo.ToString() + ", barCode = " + strBarCode);
                        return false;
                    }
                    this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView_By_BarCode(strBarCode);
                    this.dgv_Orders.Rows[Get_OrderedItem_Index_of_GridView_By_BarCode(strBarCode)].Selected = true;
                }
            }
            else // Product for the tag not exits
            {
                // Error 
                util.Logger("Product does not exits : barCode = " + strBarCode);
                //MessageBox.Show("Product does not exits : barCode = " + strBarCode);
                //
                //using (var FrmYesNo = new frmYesNo(this))
                //{
                //    FrmYesNo.Set_Title("POS Sales Main");
                //    FrmYesNo.Set_Message("Product does not exits !" + System.Environment.NewLine + "BarCode = " + strBarCode + System.Environment.NewLine + "Do you want to Add this Product ?");
                //    FrmYesNo.StartPosition = FormStartPosition.Manual; // FormStartPosition.CenterScreen; //
                //    FrmYesNo.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                //              (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                //    FrmYesNo.ShowDialog();

                //    if (FrmYesNo.bYesNo)
                //    {
 
                //    }
                //}
                // Open frmAddProduct
                using (var FrmAddProduct = new frmAddProduct(this))
                {
                    FrmAddProduct.Set_BarCode(strBarCode);
                    FrmAddProduct.p_IsTax1 = true;
                    FrmAddProduct.p_IsTax2 = true;
                    FrmAddProduct.p_IsTax3 = false;
                    FrmAddProduct.StartPosition = FormStartPosition.Manual; // FormStartPosition.CenterScreen; //
                    FrmAddProduct.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                              (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                    FrmAddProduct.ShowDialog();

                    if (FrmAddProduct.m_bAddNow == true)
                    {
                        // Add Order
                        int iNewProdId = dbPOS.Insert_Product(FrmAddProduct.p_NewProduct);
                        if (iNewProdId > 0) Add_Order_BarCode(strBarCode);
                    }
                }

                strBarCode = "";
                txtBarCode.Text = "";   //Bug #2551
                return false;
            }
            Check_Assorted_Promotions();
            Calculate_Total_Due();
            //
            return true;
        }

        private void SetTaxRates(string taxCode)
        {
            foreach(var tax in allTaxs)
            {
                if (tax.Code == taxCode)
                {
                    m_TaxRate1 = tax.Tax1;
                    m_TaxRate2 = tax.Tax2;
                    m_TaxRate3 = tax.Tax3;
                    return;
                }
            }
        }

        private void bt_Start_Click(object sender, EventArgs e)
        {
            //            if (selectedBTN == null)
            //            {
            //                MessageBox.Show("Please select a menu item first!");
            //                return;
            //            }
            _shouldStop = false;
            util.Logger("bt_Start_Click : InvoiceNo = " + iNewInvNo.ToString());
            bPaymentSuccess = false;    // global variable used by another form
            bCashPayment = false;

            bt_Start.Enabled = false;

            Load_Existing_Orders();

            listView1.Items.Clear();
            listView2.Items.Clear();

            // reader option setting
            enableAFI = 0;
            onlyNewTag = 0;
            // antenna selection
            int iCount = 4;
            AntennaSelCount = (Byte)iCount;
            CSupportedAirProtocol aip;
            aip = (CSupportedAirProtocol)airInterfaceProtList[0];
            aip.m_en = true;
            /*
             * Start the thread to inventory tags 
             */
            //// Set the flag for the new customer
            isNewInvoice = false;
            iNewInvNo = 0;
            txt_SubTotal.Text = String.Empty;
            txt_TaxTotal.Text = String.Empty;
            txt_TotalDue.Text = String.Empty;
            txtCount.Text = String.Empty;


            InvenThread = new Thread(DoInventory);
            InvenThread.Start();

            inventoryState = 1;
            return;
        }

        private void bt_Stop_Click(object sender, EventArgs e)
        {
            _shouldStop = true;
            bt_Start.Enabled = true;
            /*
             * Exit the inventory quickly
             */

            util.Logger("bt_Stop_Click : InvoiceNo = " + iNewInvNo.ToString());

            RFIDLIB.rfidlib_reader.RDR_SetCommuImmeTimeout(hreader);
            ////////////////////////////////////////
            // Abort Inventory Scan thread
            if (InvenThread != null)
            //if (!_shouldStop)
            //if (InvenThread.IsAlive)
            {
                InvenThread.Interrupt();
                //System.Threading.Thread.Sleep(2000);
                InvenThread.Abort();
                // InvenThread.Join();
                InvenThread = null;

                /////////////////////////////////////
                // Normal stop of thread
                //InvenThread.Join();
            }

        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            util.Logger("bt_Exit_Click : InvoiceNo = " + iNewInvNo.ToString());
            this.Close();
            Environment.Exit(0);
            Application.Exit();
        }

        private void frmSalesMain_Closing(object sender, FormClosingEventArgs e)
        {
            /*
             *  Close reader driver ,this API is required
             */
            int iret = 0;
            //_shouldStop = true;
            txtSelectedMenu.Text = "Please wait until application is fully closed!";
            txtSelectedMenu.BackColor = Color.Red;
            ////////////////////////////////////////
            // Abort Inventory Scan thread
            if (isRFIDConnected)
            {
                if (InvenThread != null)
                //if (!_shouldStop)
                //if (InvenThread.IsAlive)
                {
                    _shouldStop = true;
                    InvenThread.Interrupt();
                    System.Threading.Thread.Sleep(500);
                    while (InvenThread.ThreadState == System.Threading.ThreadState.Running)
                    {
                        InvenThread.Abort();
                    }
                    /////////////////////////////////////
                    // Normal stop of thread
                    //InvenThread.Join();
                }

                ////////////////////////////////////////
                // Closing the connection with Reader

                iret = RFIDLIB.rfidlib_reader.RDR_Close(hreader);
                if (iret == 0)
                {
                    hreader = (UIntPtr)0;
                    //MessageBox.Show("RFID Reader disconnected successfully!");
                    openState = 0;
                }
                else
                {
                    MessageBox.Show("RFID Reader disconnection failed!");
                }
                if (openState > 0)
                {
                    MessageBox.Show("Close reader driver first!");
                    e.Cancel = true;
                }
            }
            Environment.Exit(0);
            Application.Exit();
        }

        private void bt_Payment_Click(object sender, EventArgs e)
        {
            float fCash = 0;
            float fDebit = 0;
            float fVisa = 0;
            float fMaster = 0;
            float fAmex = 0;
            float fOthers = 0;
            float fCheque = 0;
            float fCharge = 0;

            util.Logger("bt_Payment_Click : InvoiceNo = " + iNewInvNo.ToString());
            if ((String.IsNullOrEmpty(txt_TotalDue.Text)) | (txt_TotalDue.Text.Contains("$0.00")) & (txtCount.Text.Contains("0")))
            {
                //MessageBox.Show("Nothing to pay yet! Please check Total Amount.");
                txtSelectedMenu.Text = "Nothing was ordered! Please check Total Amount.";
                txtSelectedMenu.BackColor = Color.DarkRed;
                util.Logger(txtSelectedMenu.Text);
            }
            else
            {
                using (var FrmCardPay = new frmCardPayment(this))
                {
                    FrmCardPay.Set_TenderAmt(Convert.ToDouble(txt_TotalDue.Text.Replace("$", "")));
                    FrmCardPay.Set_InvoiceNo(iNewInvNo);
                    FrmCardPay.Set_Station(strStation);
                    FrmCardPay.Set_UserName(strUserName);
                    FrmCardPay.Set_UserPassCode(strUserPass);
                    FrmCardPay.p_strTranType = "Purchase";
                    FrmCardPay.ShowDialog();
                    
                    bPaymentSuccess = FrmCardPay.bPaymentComplete;
                    //bCashPayment = FrmCardPay.bCashPayment;

                    if (FrmCardPay.bPaymentComplete)
                    {
                        FrmCardPay.strPaymentType = FrmCardPay.strPaymentType.ToUpper();
                        util.Logger("Card Payment completed ! " + FrmCardPay.strPaymentType);
                        // Move Orders to OrderComplete
                        Process_Order_Complete(iNewInvNo);
                        // Add collection table
                        switch (FrmCardPay.strPaymentType)
                        {
                            case "Cash":
                            case "CASH":
                                fCash = FrmCardPay.p_TenderAmt;
                                break;
                            case "Debit":
                            case "DEBIT":
                                fDebit = FrmCardPay.p_TenderAmt;
                                break;
                            case "Visa":
                            case "VISA":
                                fVisa = FrmCardPay.p_TenderAmt;
                                break;
                            case "Master":
                            case "MASTER":
                            case "M/C":
                            case "MasterCard":
                            case "MASTERCARD":
                                FrmCardPay.strPaymentType = "MASTER";
                                fMaster = FrmCardPay.p_TenderAmt;
                                break;
                            case "Amex":
                            case "AMEX":
                                fAmex = FrmCardPay.p_TenderAmt;
                                break;
                            default:
                                fOthers = FrmCardPay.p_TenderAmt;
                                util.Logger("Unknown Card Type !" + FrmCardPay.strPaymentType);
                                break;
                        }
                        //Process_Tran_Collection(iNewInvNo, FrmCardPay.p_TenderAmt, 
                        Process_Tran_Collection(iNewInvNo, fCash,fDebit,fVisa,fMaster,fAmex,fOthers,0,0,
                                                            0, FrmCardPay.p_TipAmt, 0 /* Rounding */, FrmCardPay.strPaymentType, true);
                        Process_Receipt(false, true);
                        util.Logger("--------------- Card Payment & Printing Receipt is Done : Invoice# " + iNewInvNo.ToString());
                        txtSelectedMenu.Text = "Payment & Printing Receipt is Done : Invoice# " + iNewInvNo.ToString();

                        Initialize_Local_Variables();
                        dgv_Orders_Initialize();
                        Load_Existing_Orders();
                        bt_Stop.PerformClick();
                        bCashPayment = false;
                    }
                    else
                    {
                        txtSelectedMenu.Text = "######### Payment is not yet completed : Invoice# " + iNewInvNo.ToString();
                        util.Logger("Payment is not done yet!");

                    }
                }
                if (bCashPayment)
                {
                    txtSelectedMenu.Text = "Cash Payment is selected : Invoice# " + iNewInvNo.ToString();
                    util.Logger(txtSelectedMenu.Text);
                    using (var FrmCashPay = new frmCashPayment(this))
                    {
                        //FrmCashPay.Set_TenderAmt(Convert.ToDouble(txt_TotalDue.Text.Replace("$", "")));
                        FrmCashPay.Set_TenderAmt(iTotalDue);
                        FrmCashPay.Set_InvoiceNo(iNewInvNo);
                        FrmCashPay.Set_Station(strStation);
                        FrmCashPay.Set_UserName(strUserName);
                        FrmCashPay.ShowDialog();

                        if (FrmCashPay.bPaymentComplete)
                        {
                            FrmCashPay.strPaymentType = FrmCashPay.strPaymentType.ToUpper();
                            util.Logger("Cash/Manual Payment completed !" + FrmCashPay.strPaymentType);
                            // Move Orders to OrderComplete
                            Process_Order_Complete(iNewInvNo);
                            // Add collection table
                            switch (FrmCashPay.strPaymentType)
                            {
                                case "CASH":
                                    fCash = FrmCashPay.p_CashAmt;
                                    break;
                                case "CHEQUE":
                                    fCheque = FrmCashPay.p_ChequeAmt;
                                    break;
                                case "CHARGE":
                                    fCharge = FrmCashPay.p_ChargeAmt;
                                    break;
                                case "DEBIT":
                                    fDebit = FrmCashPay.p_DebitAmt;
                                    break;
                                case "VISA":
                                    fVisa = FrmCashPay.p_VisaAmt;
                                    break;
                                case "MASTER":
                                case "MASTERCARD":
                                case "M/C":
                                    fMaster = FrmCashPay.p_MasterAmt;
                                    break;
                                case "AMEX":
                                    fAmex = FrmCashPay.p_AmexAmt;
                                    break;
                                default:
                                    fOthers = FrmCashPay.p_AmexAmt;
                                    util.Logger("Unknown Card Type !" + FrmCashPay.strPaymentType);
                                    break;
                            }
                            // Add Round Transaction when CASH paymenttype, if fCash's decimal 2nd digit is not 0 or 5
                            if (FrmCashPay.strPaymentType == "CASH")
                            {
                                if ((fCash - Math.Truncate(fCash)) != 0.0)
                                {
 
                                }
                            }

                            Process_Tran_Collection(iNewInvNo, fCash, fDebit, fVisa, fMaster, fAmex,fOthers, fCheque, fCharge,
                                                            0, FrmCashPay.p_TipAmt, 0 /*Rounding*/,FrmCashPay.strPaymentType, true);
                            //Process_Tran_Collection(iNewInvNo, FrmCashPay.p_CashAmt, FrmCashPay.p_ChangeAmt, FrmCashPay.p_TipAmt, FrmCashPay.strPaymentType,false);
                            Process_Receipt(false, false);

                            util.Logger("--------------- Cash Payment & Printing Receipt is Done : Invoice# " + iNewInvNo.ToString());
                            txtSelectedMenu.Text = "Payment & Printing Receipt is Done : Invoice# " + iNewInvNo.ToString();

                            Initialize_Local_Variables();
                            dgv_Orders_Initialize();
                            Load_Existing_Orders();
                            bt_Stop.PerformClick();
                        }
                        else
                        {
                            txtSelectedMenu.Text = "Payment is not yet completed : Invoice# " + iNewInvNo.ToString();
                            util.Logger("Payment is not done yet!");
                            //Bug #1554
                            bCashPayment = false;
                        }
                    }
                    
                }

            }
            BarCode_Get_Focus();

        }

        private void Initialize_Local_Variables()
        {
            util.Logger("---------------- Initialize_Local_Variables : Old InvNo : " + iNewInvNo.ToString());
            iPpleCount = 0;
            iPpleCount = 0;
            bt_SetPPL.Tag = 0;
            txtAmtEach.Text = "";
            txtQTY.Text = "";
            fTotDue = 0;
            //// Set the flag for the new customer
            isNewInvoice = false;
            iNewInvNo = 0;
            iReprintInvNo = 0;
            m_fCashRounding = 0;

            txt_SubTotal.Text = String.Empty;
            txt_TaxTotal.Text = String.Empty;
            txt_TotalDue.Text = String.Empty;
            txtCount.Text = String.Empty;
        }
        private void Process_Rounding_Tran(int iNewInvNo, float p_fCashRounding)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            orders.Clear();
            ////////////////////////////////////////////////
            // Add the ordered item into Orders table
            ////////////////////////////////////////////////
            orders.Add(new POS_OrdersModel()
            {
                TranType = "20",
                ProductId = 0,
                ProductName = "Cash Rounding",
                SecondName = "Cash Rounding",
                ProductTypeId = 0,
                InUnitPrice = 0,
                OutUnitPrice = p_fCashRounding,
                IsTax1 = false,
                IsTax2 = false,
                IsTax3 = false,
                Quantity = 1,
                Amount = p_fCashRounding,
                Tax1Rate = m_TaxRate1,
                Tax2Rate = m_TaxRate2,
                Tax3Rate = m_TaxRate3,
                Tax1 = 0,
                Tax2 = 0, // (float)(-iTotalTax2 * (iDiscountRate / 100)),
                Tax3 = 0, // (float)(-iTotalTax3 * (iDiscountRate / 100)),
                InvoiceNo = iNewInvNo,
                IsPaidComplete = false,
                CompleteDate = "",
                CompleteTime = "",
                CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), //DateTime.Now.ToShortDateString(),
                CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                CreateUserId = System.Convert.ToInt32(strUserID),
                CreateUserName = strUserName,
                CreateStation = strStation,
                LastModDate = "",
                LastModTime = "",
                LastModUserId = System.Convert.ToInt32(strUserID),
                LastModUserName = "",
                LastModStation = "",
                RFTagId = 0,
                ParentId = 0,
                OrderCategoryId = 6    // Rounding
                ,
                IsDiscounted = false     // Promotion
                ,
                BarCode = ""
            });
            int iNewOrderId = dbPOS.Insert_Order(orders[0]);
            util.Logger(" ## Process_Rounding_Tran : " + orders[0].Id.ToString() + ", PROD=" + orders[0].ProductName + ", New Amount = " + orders[0].Amount.ToString());
        }
        private void Process_Order_Complete(int iNewInvNo)
       {
            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            POS1_OrderCompleteModel ordercomp = new POS1_OrderCompleteModel();
            orders = dbPOS.Get_Orders_by_InvoiceNo(iNewInvNo);

            if (orders.Count > 0)
            {
                foreach (var order in orders)
                {
                    ordercomp.OrderId = order.Id;
                    ordercomp.TranType = order.TranType;
                    ordercomp.ProductId = order.ProductId;
                    ordercomp.ProductName = order.ProductName;
                    ordercomp.ProductTypeId = order.ProductTypeId;
                    ordercomp.InUnitPrice = order.InUnitPrice;
                    ordercomp.OutUnitPrice = order.OutUnitPrice;
                    ordercomp.IsTax1 = order.IsTax1;
                    ordercomp.IsTax2 = order.IsTax2;
                    ordercomp.IsTax3 = order.IsTax3;
                    ordercomp.UnitCategoryId = order.UnitCategoryId;
                    ordercomp.Deposit = order.Deposit;
                    ordercomp.RecyclingFee = order.RecyclingFee;
                    ordercomp.ChillCharge = order.ChillCharge;
                    ordercomp.IsPointException = order.IsPointException;
                    ordercomp.IsManualPrice = order.IsManualPrice;
                    ordercomp.Tare = order.Tare;
                    ordercomp.Quantity = order.Quantity;
                    ordercomp.Amount = order.Amount;
                    ordercomp.Tax1Rate = order.Tax1Rate;
                    ordercomp.Tax2Rate = order.Tax2Rate;
                    ordercomp.Tax3Rate = order.Tax3Rate;
                    ordercomp.Tax1 = order.Tax1;
                    ordercomp.Tax2 = order.Tax2;
                    ordercomp.Tax3 = order.Tax3;
                    ordercomp.InvoiceNo = order.InvoiceNo;
                    ordercomp.IsPaidComplete = true;
                    ordercomp.CompleteDate = DateTime.Now.ToString("yyyy-MM-dd");
                    ordercomp.CompleteTime = DateTime.Now.ToString("HH:mm:ss");
                    ordercomp.CreateUserId = System.Convert.ToInt32(strUserID);
                    ordercomp.CreateUserName = strUserName;
                    ordercomp.CreateStation = strStation;
                    ordercomp.LastModDate = DateTime.Now.ToString("yyyy-MM-dd");
                    ordercomp.LastModTime = DateTime.Now.ToString("HH:mm:ss");
                    ordercomp.LastModUserId = System.Convert.ToInt32(strUserID);
                    ordercomp.LastModUserName = strUserName;
                    ordercomp.LastModStation = strStation;
                    ordercomp.ParentId = order.ParentId;
                    ordercomp.OrderCategoryId = order.OrderCategoryId;
                    ordercomp.IsDiscounted = order.IsDiscounted;
                    ordercomp.BarCode = order.BarCode;


                    int iCount = dbPOS1.Insert_OrderComplete(ordercomp);
                    util.Logger("Insert_OrderComplete ! InvNo :" + order.InvoiceNo + " OrdId :" + order.Id.ToString() + " Result : " + iCount.ToString());
                    iCount = dbPOS.Delete_Order_By_OrderId(order.InvoiceNo,order.Id);
                    util.Logger("Delete_Order_By_OrderId ! InvNo :" + order.InvoiceNo + " OrdId :" + order.Id.ToString() + " Result : " + iCount.ToString());

                    //////////////////////////////////////////////////////////
                    // Product Balance Update Should be done here
                    // order.ProductId
                    // order.Quantity
                    prods = dbPOS.Get_Product_By_ID(order.ProductId);
                    if (prods.Count == 1)
                    {
                        float fBeforeQTY = prods[0].Balance;
                        prods[0].Balance = prods[0].Balance - order.Quantity;
                        dbPOS.Update_Product_Balance(prods[0]);
                        dbPOS1.Insert_ProductInventoryLog(prods[0], 2 /* Sale */, fBeforeQTY, prods[0].Balance, strUserPass, strStation);

                    }
                    //////////////////////////////////////////////////////////
                }
            }
       }
       //private void Process_Tran_Collection(int iInvNo, float fTenderAmt, float fChangeAmt, float fTips, string strPaymentType, bool bIsIPSPayment)
        private void Process_Tran_Collection(int iInvNo, float fCashAmt,
                                                         float fDebitAmt,
                                                         float fVisaAmt,
                                                         float fMasterAmt,
                                                         float fAmexAmt,
                                                         float fOthersAmt,
                                                         float fChequeAmt,
                                                         float fChargeAmt,
                                                         float fChangeAmt, 
                                                         float fTips,
                                                         float fRounding,
                                                         string strPaymentType, bool bIsIPSPayment)
        {
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            DataAccessCard dbCard = new DataAccessCard();
            POS1_TranCollectionModel col = new POS1_TranCollectionModel();
            CCardReceipt cardReceipt = new CCardReceipt();

            util.Logger("Process_Tran_Collection iInvNo : " + iInvNo);
            util.Logger("Process_Tran_Collection fCashAmt : " + fCashAmt);
            util.Logger("Process_Tran_Collection fDebitAmt : " + fDebitAmt);
            util.Logger("Process_Tran_Collection fVisaAmt : " + fVisaAmt);
            util.Logger("Process_Tran_Collection fMasterAmt : " + fMasterAmt);
            util.Logger("Process_Tran_Collection fAmexAmt : " + fAmexAmt);
            util.Logger("Process_Tran_Collection fOthersAmt : " + fOthersAmt);
            util.Logger("Process_Tran_Collection fChequeAmt : " + fChequeAmt);
            util.Logger("Process_Tran_Collection fChargeAmt : " + fChargeAmt);
            util.Logger("Process_Tran_Collection fChangeAmt : " + fChangeAmt);
            util.Logger("Process_Tran_Collection fTips : " + fTips);
            util.Logger("Process_Tran_Collection fRounding : " + fRounding);
            util.Logger("Process_Tran_Collection strPaymentType : " + strPaymentType);

            compOrders = dbPOS1.Get_OrderComplete_by_InvoiceNo(iInvNo);

            if ((strPaymentType.Contains("CASH")) & (bIsIPSPayment))
            {
                util.Logger("Process_Tran_Collection IPS Payment : " + strPaymentType);
                fCashAmt = dbCard.Get_TenderAmount(iInvNo);
                fTips = dbCard.Get_TipAmount(iInvNo);
            }
            else
            {
                util.Logger("Process_Tran_Collection Cash/Manual Payment : " + strPaymentType);
            }
            

            float fAmount = 0;
            float fTotalDueAmt = 0;
            float fTax1 = 0;
            float fTax2 = 0;
            float fTax3 = 0;

            if (compOrders.Count > 0)
            {
                foreach (var order in compOrders)
                {
                    fTax1 = fTax1 + order.Tax1;
                    fTax2 = fTax2 + order.Tax2;
                    fTax3 = fTax3 + order.Tax3;
                    fAmount = fAmount + order.Amount;
                }
                fTotalDueAmt = fAmount + fTax1 + fTax2 + fTax3;

                col.Amount = fAmount;   // Sub Total without Tax
                col.Tax1 = fTax1;
                col.Tax2 = fTax2;
                col.Tax3 = fTax3;


                if (strPaymentType.Contains("CASH"))
                {
                    if (fCashAmt == 0)
                    {
                        fCashAmt = fTotalDueAmt;
                    }
                    //col.Cash = fTenderAmt;
                    col.Cash = fCashAmt + fChangeAmt - fTips;
                    col.CashTip = fTips;
                }
                else
                { 
                    // MULTI or CARDS
                    col.Cash = fCashAmt;
                    if (strPaymentType.Contains("CASH"))
                        col.CashTip = fTips;
                    col.Cheque = fChequeAmt + fChangeAmt;
                    col.Charge = fChargeAmt;
                    col.Debit = fDebitAmt;
                    if (strPaymentType.Contains("DEBIT"))
                        col.DebitTip = fTips;
                    col.Visa = fVisaAmt;
                    if (strPaymentType.Contains("VISA"))
                        col.VisaTip = fTips;
                    col.Master = fMasterAmt;
                    if (strPaymentType.Contains("MASTER"))
                        col.MasterTip = fTips;
                    col.Amex = fAmexAmt;
                    if (strPaymentType.Contains("AMEX"))
                        col.AmexTip = fTips;
                    col.GiftCard = 0;
                    if (strPaymentType.Contains("GIFTCARD"))
                        col.GiftCardTip = 0;
                    col.Others = fOthersAmt;
                    col.Change = fChangeAmt;
                    col.Rounding = 0;
                }
                col.CollectionType = strPaymentType;

                col.TotalPaid = col.Cash + col.Visa + col.Debit + col.Master + col.Amex + col.GiftCard + col.Cheque + col.Charge + +col.Others;
                col.TotalDue = fTotalDueAmt;
                col.Change = fChangeAmt;
                col.TotalTip = col.CashTip + col.VisaTip + col.DebitTip + col.MasterTip + col.AmexTip + col.GiftCardTip + col.OthersTip;
                col.TotalPaid += col.TotalTip;

                col.CreateDate = DateTime.Now.ToString("yyyy-MM-dd");
                col.CreateTime = DateTime.Now.ToString("HH:mm:ss");
                col.CreatePasswordCode = strUserID;
                col.CreatePasswordName = strUserName;
                col.CreateStation = strStation;
                col.LastModDate = DateTime.Now.ToString("yyyy-MM-dd");
                col.LastModTime = DateTime.Now.ToString("HH:mm:ss");
                col.LastModPasswordCode = strUserID;
                col.LastModPasswordName = strUserName;
                col.LastModStation = strStation;
                col.IsVoid = false;
                col.Rounding = fRounding;
                col.IsOnline = false;
                col.ReceiptNo = dbPOS1.Get_MaxReceiptNo_TranCollection();
                col.InvoiceNo = iInvNo;
                //col.Change = fChangeAmt;

                int iCount = dbPOS1.Insert_TranCollection(col);
                util.Logger("Insert_TranCollection ! InvNo :" + col.InvoiceNo + " ReceiptNo :" + col.ReceiptNo + " PaymentType :" + col.CollectionType + " Result : " + iCount.ToString());

            }

       }
       private bool Process_Save_Order(int iInvNo)
       {
            DataAccessPOS dbPOS = new DataAccessPOS();
            //DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            POS_SavedOrdersModel savedorder = new POS_SavedOrdersModel();
            orders = dbPOS.Get_Orders_by_InvoiceNo(iNewInvNo);

            util.Logger("Process_Save_Order ! InvNo :" + iInvNo.ToString());
            
            int iSavedCount = 0;

            if (orders.Count > 0)
            {
                foreach (var order in orders)
                {
                    //savedorder.OrderId = order.Id;
                    savedorder.TranType = order.TranType;
                    savedorder.ProductId = order.ProductId;
                    savedorder.ProductName = order.ProductName;
                    savedorder.ProductTypeId = order.ProductTypeId;
                    savedorder.InUnitPrice = order.InUnitPrice;
                    savedorder.OutUnitPrice = order.OutUnitPrice;
                    savedorder.IsTax1 = order.IsTax1;
                    savedorder.IsTax2 = order.IsTax2;
                    savedorder.IsTax3 = order.IsTax3;
                    savedorder.UnitCategoryId = order.UnitCategoryId;
                    savedorder.Deposit = order.Deposit;
                    savedorder.RecyclingFee = order.RecyclingFee;
                    savedorder.ChillCharge = order.ChillCharge;
                    savedorder.IsPointException = order.IsPointException;
                    savedorder.IsManualPrice = order.IsManualPrice;
                    savedorder.Tare = order.Tare;
                    savedorder.Quantity = order.Quantity;
                    savedorder.Amount = order.Amount;
                    savedorder.Tax1Rate = order.Tax1Rate;
                    savedorder.Tax2Rate = order.Tax2Rate;
                    savedorder.Tax3Rate = order.Tax3Rate;
                    savedorder.Tax1 = order.Tax1;
                    savedorder.Tax2 = order.Tax2;
                    savedorder.Tax3 = order.Tax3;
                    savedorder.InvoiceNo = order.InvoiceNo;
                    savedorder.IsPaidComplete = true;
                    savedorder.CompleteDate = DateTime.Now.ToString("yyyy-MM-dd");
                    savedorder.CompleteTime = DateTime.Now.ToString("HH:mm:ss");
                    savedorder.CreateUserId = System.Convert.ToInt32(strUserID);
                    savedorder.CreateUserName = strUserName;
                    savedorder.CreateStation = strStation;
                    savedorder.LastModDate = DateTime.Now.ToString("yyyy-MM-dd");
                    savedorder.LastModTime = DateTime.Now.ToString("HH:mm:ss");
                    savedorder.LastModUserId = System.Convert.ToInt32(strUserID);
                    savedorder.LastModUserName = strUserName;
                    savedorder.LastModStation = strStation;
                    savedorder.ParentId = order.ParentId;
                    savedorder.OrderCategoryId = order.OrderCategoryId;
                    savedorder.IsDiscounted = order.IsDiscounted;
                    savedorder.BarCode = order.BarCode;

                    if (dbPOS.Insert_SavedOrders(savedorder) > 0)
                    {
                        dbPOS.Delete_Order_By_OrderId(order.InvoiceNo, order.Id);
                        iSavedCount++;
                    }
                }
                if (iSavedCount == orders.Count)
                {
                    return true;
                }
            }
            return false;
        }
        private bool Process_Recall_Saved_Order(int iInvNo)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            //DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            POS_SavedOrdersModel savedorder = new POS_SavedOrdersModel();
            POS_OrdersModel recallorder = new POS_OrdersModel();

            orders = dbPOS.Get_Orders_by_InvoiceNo(iNewInvNo);

            if (orders.Count > 0)
            {
                MessageBox.Show("Unable to Recall due to there is on going order items!");
                return false;
            }
            savedorders = dbPOS.Get_SavedOrders_by_InvoiceNo(iInvNo);

            util.Logger("Process_Recall_Saved_Order ! InvNo :" + iInvNo.ToString());

            int iRecallCount = 0;

            if (savedorders.Count > 0)
            {
                foreach (var order in savedorders)
                {
                    recallorder.TranType = order.TranType;
                    recallorder.ProductId = order.ProductId;
                    recallorder.ProductName = order.ProductName;
                    recallorder.ProductTypeId = order.ProductTypeId;
                    recallorder.InUnitPrice = order.InUnitPrice;
                    recallorder.OutUnitPrice = order.OutUnitPrice;
                    recallorder.IsTax1 = order.IsTax1;
                    recallorder.IsTax2 = order.IsTax2;
                    recallorder.IsTax3 = order.IsTax3;
                    recallorder.UnitCategoryId = order.UnitCategoryId;
                    recallorder.Deposit = order.Deposit;
                    recallorder.RecyclingFee = order.RecyclingFee;
                    recallorder.ChillCharge = order.ChillCharge;
                    recallorder.IsPointException = order.IsPointException;
                    recallorder.IsManualPrice = order.IsManualPrice;
                    recallorder.Tare = order.Tare;
                    recallorder.Quantity = order.Quantity;
                    recallorder.Amount = order.Amount;
                    recallorder.Tax1Rate = order.Tax1Rate;
                    recallorder.Tax2Rate = order.Tax2Rate;
                    recallorder.Tax3Rate = order.Tax3Rate;
                    recallorder.Tax1 = order.Tax1;
                    recallorder.Tax2 = order.Tax2;
                    recallorder.Tax3 = order.Tax3;
                    recallorder.InvoiceNo = order.InvoiceNo;
                    recallorder.IsPaidComplete = true;
                    recallorder.CompleteDate = DateTime.Now.ToString("yyyy-MM-dd");
                    recallorder.CompleteTime = DateTime.Now.ToString("HH:mm:ss");
                    recallorder.CreateUserId = System.Convert.ToInt32(strUserID);
                    recallorder.CreateUserName = strUserName;
                    recallorder.CreateStation = strStation;
                    recallorder.LastModDate = DateTime.Now.ToString("yyyy-MM-dd");
                    recallorder.LastModTime = DateTime.Now.ToString("HH:mm:ss");
                    recallorder.LastModUserId = System.Convert.ToInt32(strUserID);
                    recallorder.LastModUserName = strUserName;
                    recallorder.LastModStation = strStation;
                    recallorder.ParentId = order.ParentId;
                    recallorder.OrderCategoryId = order.OrderCategoryId;
                    recallorder.IsDiscounted = order.IsDiscounted;
                    recallorder.BarCode = order.BarCode;

                    if (dbPOS.Insert_Order(recallorder) > 0)
                    {
                        dbPOS.Delete_SavedOrder_By_OrderId(order.InvoiceNo, order.Id);
                        iRecallCount++;
                    }
                }
                if (iRecallCount == savedorders.Count)
                {
                    util.Logger("Process_Recall_Saved_Order ! iRecallCount :" + iRecallCount.ToString());
                    return true;
                }
            }
            util.Logger("Process_Recall_Saved_Order ! failed ");
            return false;
        }
        public void BarCode_Get_Focus()
        {
            txtBarCode.Focus();
        }
        private void bt_Void_Click(object sender, EventArgs e)
       {
            util.Logger("bt_Void_Click InvNo :" + iNewInvNo.ToString());
            if (dgv_Orders.Rows.Count > 0)
            {
                int iRowCount = dgv_Orders.Rows.Count;
                //for (int i = 0; i < iRowCount; iRowCount++)
                foreach (DataGridViewRow row in dgv_Orders.Rows)
                {
                    if (row.Selected)
                    {
                        //int iSelectedProdId = System.Convert.ToInt32(row.Cells[0].Value.ToString());
                        //int iSelectedOrderId = System.Convert.ToInt32(row.Cells[5].Value.ToString());
                        int iSelectedProdId = System.Convert.ToInt32(row.Cells[7].Value.ToString());
                        int iSelectedOrderId = System.Convert.ToInt32(row.Cells[6].Value.ToString());
                        int iSelectedTagId = 0;
                        if (row.Tag!=null)
                        {
                            iSelectedTagId = System.Convert.ToInt32(row.Tag.ToString());
                        }
                        if (iSelectedTagId > 0)
                        {
                            
                            if (Void_Product_Item_byTagId(iSelectedTagId))
                            {
                                dgv_Orders.Rows.RemoveAt(row.Index);
                                txtSelectedMenu.Text = "Item Void completed : " + row.Cells[1].Value.ToString();
                                Calculate_Total_Due();
                                BarCode_Get_Focus();
                                return;
                            }
                        }
                        else
                        {
                            if (Void_Product_Item(iSelectedProdId, iSelectedOrderId))
                            {
                                dgv_Orders.Rows.RemoveAt(row.Index);
                                txtSelectedMenu.Text = "Item Void completed : " + row.Cells[1].Value.ToString();
                                Calculate_Total_Due();
                                BarCode_Get_Focus();
                                return;
                            }
                        }
                    }
                }
            }
            BarCode_Get_Focus();
        }

       private bool Void_Product_Item(int iSelectedProdId, int iSelectedOrderId)
       {
            int iTagUpdateCnt = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();
            orders.Clear();
            orders = dbPOS.Get_NonRFID_Order_By_OrderId(iNewInvNo, iSelectedOrderId);

            util.Logger("Void_Product_Item InvNo :" + iNewInvNo.ToString() + ", iSelectedProdId = " + iSelectedProdId.ToString());

            if (orders.Count == 1)
            {
                foreach (var order in orders)
                {
                    if (dbPOS.Delete_Order_By_OrderId(iNewInvNo, order.Id) == 1)
                    {
                        util.Logger("Void_Product_Item Success InvNo  :" + iNewInvNo.ToString() + ", iSelectedProdId = " + iSelectedProdId.ToString());
                        return true;
                    }
                }
            }
            util.Logger("Void_Product_Item Failed InvNo  :" + iNewInvNo.ToString() + ", iSelectedProdId = " + iSelectedProdId.ToString());
            return false;
        }
        private bool Void_Product_Item_byTagId(int iSelectedTagId)
        {
            int iTagUpdateCnt = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();
            orders.Clear();
            orders = dbPOS.Get_Order_By_Invoice_RFTagId(iNewInvNo, iSelectedTagId);

            util.Logger("Void_Product_Item_byTagId InvNo  :" + iNewInvNo.ToString() + ", iSelectedTagId = " + iSelectedTagId.ToString());

            if (orders.Count == 1)
            {
                foreach (var order in orders)
                {
                    if (order.RFTagId > 0)
                    {
                        if (dbPOS.Check_RFIDTag_Exists_ById(order.RFTagId))
                        {
                            iTagUpdateCnt = dbPOS.Reset_RFIDTag_ByID(order.RFTagId);
                        }
                    }
                    if (iTagUpdateCnt != 1)
                    {
                        util.Logger("RFID Tag Reset Error : order.RFTagId = " + order.RFTagId);
                    }
                    else
                    {
                        util.Logger("RFID Tag Reset Successful : order.RFTagId = " + order.RFTagId);
                    }
                    if (dbPOS.Delete_Order_By_RFTagID(iNewInvNo, order.RFTagId) == 1)
                    {
                        return true;
                    }
                }

            }
            return false;
        }
        private void bt_VoidAll_Click(object sender, EventArgs e)
        {
            int iTagUpdateCnt = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();
            orders.Clear();
            orders = dbPOS.Get_Orders_by_InvoiceNo(iNewInvNo);

            util.Logger("bt_VoidAll_Click InvNo  :" + iNewInvNo.ToString() + ", orders.Count = " + orders.Count.ToString());

            if (orders.Count > 0)
            {
                foreach (var order in orders)
                {
                    if (order.RFTagId > 0)
                    {
                        if (dbPOS.Check_RFIDTag_Exists_ById(order.RFTagId))
                        {
                            iTagUpdateCnt = dbPOS.Reset_RFIDTag_ByID(order.RFTagId);
                        }
                    }
                    if (iTagUpdateCnt != 1)
                    {
                        util.Logger("RFID Tag Reset Error : order.RFTagId = " + order.RFTagId);
                    }
                    else
                    {
                        util.Logger("RFID Tag Reset Successful : order.RFTagId = " + order.RFTagId);
                    }
                    if (dbPOS.Delete_Order_By_OrderId(iNewInvNo, order.Id) == 1)
                    {
                        util.Logger("Order removed = (Invoice#,Prod,Amount,Qty) " + iNewInvNo + "," + order.ProductName + "," + order.Amount + "," + order.Quantity);
                    }
                }

            }
            dgv_Orders_Initialize();
            
            Initialize_Local_Variables();
            Load_Existing_Orders();

            if (isRFIDConnected)
            {
                this.bt_Stop.PerformClick();
                this.bt_Start.PerformClick();
            }
            bt_Start.Enabled = false;
            bt_Payment.Enabled = true;

            Calculate_Total_Due();
            BarCode_Get_Focus();
        }
        private void bt_SetQTY_Click(object sender, EventArgs e)
        {
            try
            {
                if (proc != null)
                {
                    proc.Kill();
                }
            }
            catch (Exception)
            {

            }

            DataAccessPOS dbPOS = new DataAccessPOS();
            if ((!string.IsNullOrEmpty(txtQTY.Text)) && (txtQTY.Text != "0"))
            {
                int iQTY = 0;
                try
                {
                    iQTY = int.Parse(txtQTY.Text);
                    txtSelectedMenu.ForeColor = Color.Black;
                    txtQTY.BackColor = Color.LightGreen;
                }
                catch(Exception)
                {
                    txtSelectedMenu.Text = "QTY should be numeric! Please correct tye QTY";
                    txtSelectedMenu.ForeColor = Color.Red;
                    txtQTY.BackColor = Color.Pink;
                    txtQTY.Focus();
                    return;
                }
                if ((dgv_Orders.Rows.Count > 0) & (iQTY > 0))
                {
                    foreach (DataGridViewRow row in dgv_Orders.Rows)
                    {
                        
                        if (row.Selected)
                        {
                            int iSelectedProdId = System.Convert.ToInt32(row.Cells[7].Value.ToString()); // Cells[6] product id
                            int iSelectedTagId = 0;
                            if (row.Tag != null)
                            {
                                iSelectedTagId = System.Convert.ToInt32(row.Tag.ToString());
                            }
                            if (iSelectedTagId > 0)
                            {
                                txtSelectedMenu.Text = "Selected Row is a RFIDTag item, so can not set QTY! " + iSelectedTagId.ToString();
                                txtSelectedMenu.ForeColor = Color.Red;
                                txtSelectedMenu.BackColor = Color.White;
                                txtQTY.BackColor = Color.Pink;
                                txtQTY.Focus();
                            }
                            else
                            {
                                // Set QTY for only Non-RFID Tag prod items
                                orders.Clear();
                                orders = dbPOS.Get_NonRFID_Order_By_ProdId(iNewInvNo, iSelectedProdId);
                                //int iUsedTagCount = dbPOS.Get_Used_RFIDTags_Count_By_ProdID_InvNo(iNewInvNo, iSelectedProdId);
                                //if (iUsedTagCount > iQTY)
                                //{
                                //    txtSelectedMenu.Text = "Associated # of RFID Tags are more than QTY to set manually! Unable to set QTY! : " + iUsedTagCount.ToString();
                                //    txtSelectedMenu.ForeColor = Color.Red;
                                //    txtSelectedMenu.BackColor = Color.White;
                                //    txtQTY.BackColor = Color.Pink;
                                //    txtQTY.Focus();
                                //    return;
                                //}
                                if (orders.Count == 1)
                                {
                                    orders[0].Quantity = iQTY;

                                    // update datagrid veiw
                                    row.Cells[2].Value = orders[0].Quantity.ToString();
                                    float iAmount = orders[0].Quantity * orders[0].OutUnitPrice;
                                    row.Cells[4].Value = iAmount.ToString("0.00");
                                    // update orders table
                                    orders[0].Amount = orders[0].OutUnitPrice * orders[0].Quantity;
                                    if (orders[0].IsTax1) orders[0].Tax1 = orders[0].Amount * orders[0].Tax1Rate;
                                    if (orders[0].IsTax2) orders[0].Tax2 = orders[0].Amount * orders[0].Tax2Rate;
                                    if (orders[0].IsTax3) orders[0].Tax3 = orders[0].Amount * orders[0].Tax3Rate;
                                    orders[0].LastModDate = DateTime.Now.ToString("yyyy-MM-dd"); //DateTime.Now.ToShortDateString();
                                    orders[0].LastModTime = DateTime.Now.ToString("HH:mm:ss"); //DateTime.Now.ToShortTimeString();
                                    dbPOS.Update_Orders_Amount_Qty(orders[0]);

                                }
                                else if (orders.Count > 1)
                                {
                                    // Error on duplicated data exists
                                    util.Logger("Error on duplicated data exists : InvoiceNo = " + iNewInvNo.ToString());
                                    MessageBox.Show("Error on duplicated data exists : InvoiceNo = " + iNewInvNo.ToString());
                                }
                            }
                        }
                    }
                    Calculate_Total_Due();
                    txtQTY.Text = "0";
                }
                else
                {
                    txtSelectedMenu.Text = "QTY is not set or No ordered items to update!";
                }
                //txtBarCode.Focus();
            }
            else
            {
                txtQTY.Text = txtBarCode.Text;
                txtBarCode.Text = "";
            }
            BarCode_Get_Focus();
        }

        private void txtQTY_Click(object sender, EventArgs e)
        {
            //run on screen keyboard
            proc = Process.Start("osk.exe");
            txtQTY.SelectAll();
        }

        private void bt_PrintInvoice_Click(object sender, EventArgs e)
        {
            if (iNewInvNo != 0)
            {
                Process_Receipt(true, true);
                txtSelectedMenu.Text = "Invoice Printing is Done : " + iNewInvNo.ToString();
            }
            else
            {
                txtSelectedMenu.Text = "Invoice Printing is not possible : " + iNewInvNo.ToString();
            }
            BarCode_Get_Focus();
        }
        public string StringCentering(string s, int desiredLength)
        {
            if (s.Length >= desiredLength) return s;
            int firstpad = (s.Length + desiredLength) / 2;
            return s.PadLeft(firstpad).PadRight(desiredLength);
        }
        private void Process_Receipt(bool IsInvoice, bool IsMerchantCopy)
        {
            util.Logger("Process_Receipt InvNo  :" + iNewInvNo.ToString());
            if (!IsInvoice)
            {
                //Print_Receipt(IsInvoice, false);
                if (IsMerchantCopy)
                    Print_Receipt(IsInvoice, IsMerchantCopy, iNewInvNo);
            }
            //DialogResult dialogResult = MessageBox.Show("Print Customer Copy ?", "Receipt Print", MessageBoxButtons.YesNo);
            if (bAutoReceipt)
            {
                /*using (var FrmYesNo = new frmYesNo(this))
                {
                    FrmYesNo.Set_Title("Receipt Print");
                    FrmYesNo.Set_Message("Print Customer Copy ?");
                    FrmYesNo.StartPosition = FormStartPosition.Manual; // FormStartPosition.CenterScreen; //
                    FrmYesNo.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                              (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                    FrmYesNo.ShowDialog();

                    if (FrmYesNo.bYesNo)
                    {
                        if (IsCustomerCopy)
                        {*/
                //sCustomerCopy
                Print_Receipt(IsInvoice, false, iNewInvNo);//IsCustomerCopy);
                        /*}
                    }
                }*/
            }

            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            DataAccessCard dbCard = new DataAccessCard();
            List<POS1_TranCollectionModel> cols = new List<POS1_TranCollectionModel>();
            List<POS1_OrderCompleteModel> orderComItems = new List<POS1_OrderCompleteModel>();
            List<CCardReceipt> cardReceipts = new List<CCardReceipt>();

            cols = dbPOS1.Get_TranCollection_by_InvoiceNo(iNewInvNo);
            orderComItems = dbPOS1.Get_OrderComplete_by_InvoiceNo(iNewInvNo);
            cardReceipts = dbCard.Get_Approved_CardReceipt_By_InvoiceNo(iNewInvNo);

            ShowReceiptInfoOnScreen(cols, orderComItems, cardReceipts);

        }
        private void Print_Receipt(bool IsInvoice, bool IsMerchantCopy, int p_iInvoiceNo)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            DataAccessCard dbCard = new DataAccessCard();
            List<POS1_TranCollectionModel> cols = new List<POS1_TranCollectionModel>();
            List<POS1_OrderCompleteModel> orderComItems = new List<POS1_OrderCompleteModel>();
            List<CCardReceipt> cardReceipts = new List<CCardReceipt>();

            string strHeader = "header";
            string strFooter = "footer";
            string strContent = "1234567890123456789012345678901234567890";
            string strLine = "----------------------------------------";
            string strImageFile = "";
            float iSubTot = 0;
            float iTaxTot = 0;
            float iTotDue = 0;
            float fTax1Tot = 0;
            float fTax2Tot = 0;
            float fTax3Tot = 0;

            PrintDocument p = new PrintDocument();

            // Construct 2 new StringFormat objects
            StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
            StringFormat format2 = new StringFormat(format1);

            // Set the LineAlignment and Alignment properties for
            // both StringFormat objects to different values.
            format1.LineAlignment = StringAlignment.Near;
            format1.Alignment = StringAlignment.Center;
            format2.LineAlignment = StringAlignment.Center;
            format2.Alignment = StringAlignment.Near;

            p.PrinterSettings.PrinterName = "EPSON-1";
            Font fntTitle = new Font("Arial", 12, FontStyle.Bold);
            Font fntHeader = new Font("Courier New", 9);
            Font fntFooter = new Font("Courier New", 10, FontStyle.Bold);
            Font fntContents = new Font("Courier New", 8);
            Font fntTotals = new Font("Courier New", 8, FontStyle.Bold);
            Font fntCard = new Font("Consolas", 8);
            SolidBrush brsBlack = new SolidBrush(Color.Black);

            orderComItems = dbPOS1.Get_OrderComplete_by_InvoiceNo(p_iInvoiceNo);

            int iItemCount = (int)orderComItems.FindAll(item => item.ProductId > 0).Sum(item => item.Quantity);

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                int iNextLineYPoint = 0;
                int iLogoHeight = 80;
                int itxtHeight = 12;
                int iheaderHeight = 14;
                int ititleHeight = 17;
                //////////////////////////////////////////////////////////////////////////
                // Print Logo ------------------------------------------------------
                strImageFile = dbPOS.Get_SysConfig_By_Name("IS_RECEIPT_LOGO_PRINT")[0].ConfigValue.Trim();
                if (strImageFile.Contains("TRUE"))
                {
                    strImageFile = dbPOS.Get_SysConfig_By_Name("RECEIPT_LOGO_IMAGE")[0].ConfigValue.Trim();
                    if (strImageFile.Length > 0)
                    {
                        Image logoImg = Image.FromFile(strImageFile);
                        Rectangle logoRect = new Rectangle(new Point(0, 0), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iLogoHeight));
                        //e1.Graphics.DrawRectangle(Pens.Black, logoRect);
                        e1.Graphics.DrawImage(logoImg, logoRect, new Rectangle(0, 0, logoImg.Width, logoImg.Height), GraphicsUnit.Pixel);
                    }
                    iNextLineYPoint = iNextLineYPoint + iLogoHeight;
                }
                //////////////////////////////////////////////////////////////////////////
                // Print Header ------------------------------------------------------
                
                Rectangle txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                //e1.Graphics.DrawRectangle(Pens.Black, txtRect);
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_TITLE")[0].ConfigValue, fntTitle, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + ititleHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_ADDR1")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_ADDR2")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_PHONE_NO")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_REG_NO")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                //////////////////////////////////////////////////////////////////////////
                // Print order header ------------------------------------------------------
                strContent = String.Format("{0,-17}", "Inv#: " + String.Format("{0}", System.Convert.ToInt32(p_iInvoiceNo))) +
                             String.Format("{0,20}", "Served by: " + strUserName);
                iNextLineYPoint = iNextLineYPoint + iheaderHeight + 5;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                strContent = String.Format("{0,-17}", "Station:" + strStation) +
                             String.Format("{0,20}", "# of Items:" + iItemCount.ToString()); 
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                strContent = String.Format("{0,-17}", "Issued:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                if (!IsMerchantCopy || bCashPayment)
                {
                    //////////////////////////////////////////////////////////////////////////
                    // Print a Line ------------------------------------------------------
                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);

                    //////////////////////////////////////////////////////////////////////////
                    // Print order header ------------------------------------------------------
                    strContent = String.Format("{0,-20}", StringCentering("Item Desc", 20)) + String.Format("{0,5}", "QTY") +
                                 String.Format("{0,7}", "Price") + String.Format("{0,8}", "Amount");
                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                    //////////////////////////////////////////////////////////////////////////
                    // Print a Line ------------------------------------------------------
                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);

                    if (IsInvoice)
                    {
                        List<POS_OrdersModel> orderitems = new List<POS_OrdersModel>();
                        orderitems = dbPOS.Get_Orders_by_InvoiceNo(p_iInvoiceNo);
                        if (orderitems.Count > 0)
                        {
                            ////////////////////////////////////////////////
                            // Add the ordered item into datagrid view
                            ////////////////////////////////////////////////
                            //iNewInvNo = orders[0].InvoiceNo;
                            foreach (var order in orderitems)
                            {
                                float iAmount = 0;
                                string strProd = "";

                                if (order.OrderCategoryId == 0)
                                {
                                    iAmount = order.Quantity * order.OutUnitPrice;
                                    iSubTot = iSubTot + iAmount;
                                    iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                                    fTax1Tot += order.Tax1;
                                    fTax2Tot += order.Tax2;
                                    fTax3Tot += order.Tax3;
                                    strProd = order.ProductName;

                                    if (order.ProductName.Length > 20)
                                    {
                                        strProd = order.ProductName.Substring(0, 20);
                                    }

                                    strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                 String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));
                                }
                                else if (order.OrderCategoryId > 0) // Discount = 4, Deposit, Return = 5
                                {
                                    iAmount = order.Amount;
                                    iSubTot = iSubTot + iAmount;
                                    iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                                    fTax1Tot += order.Tax1;
                                    fTax2Tot += order.Tax2;
                                    fTax3Tot += order.Tax3;
                                    strProd = order.ProductName;

                                    if (order.ProductName.Length > 20)
                                    {
                                        strProd = order.ProductName.Substring(0, 20);
                                    }

                                    strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                 String.Format("{0,7}", order.Amount.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                                }
                                //////////////////////////////////////////////////////////////////////////
                                // Print order ------------------------------------------------------
                                iNextLineYPoint = iNextLineYPoint + itxtHeight;
                                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                //e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            }
                            iTotDue = iSubTot + iTaxTot;
                        }
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strContent = String.Format("{0,25}", "Sub Total :") + String.Format("{0,15}", iSubTot.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strContent = String.Format("{0,25}", "Tax :") + String.Format("{0,15}", iTaxTot.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        if (m_blnPrintTaxDetails)
                        {
                            if (fTax1Tot > 0)
                            {
                                strContent = String.Format("{0,25}", strTax1Name + " :") + String.Format("{0,15}", fTax1Tot.ToString("0.00"));
                                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            }
                            if (fTax2Tot > 0)
                            {
                                strContent = String.Format("{0,25}", strTax2Name + " :") + String.Format("{0,15}", fTax2Tot.ToString("0.00"));
                                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            }
                            if (fTax3Tot > 0)
                            {
                                strContent = String.Format("{0,25}", strTax3Name + " :") + String.Format("{0,15}", fTax3Tot.ToString("0.00"));
                                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            }
                        }
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strContent = String.Format("{0,25}", "Total Due :") + String.Format("{0,15}", iTotDue.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                        if (iPpleCount > 1)
                        {
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            float iPplDue = iTotDue / iPpleCount;
                            strContent = String.Format("{0,25}", "1/" + iPpleCount.ToString() + " Each :") + String.Format("{0,15}", iPplDue.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);

                        }
                        if (dbPOS.Get_SysConfig_By_Name("INVOICE_TIP_GUIDE")[0].ConfigValue == "True")
                        {
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            float iTip = iTotDue * (float)0.10;
                            strContent = String.Format("{0,25}", "10% Tip :") + String.Format("{0,15}", iTip.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            iTip = iTotDue * (float)0.15;
                            strContent = String.Format("{0,25}", "15% Tip :") + String.Format("{0,15}", iTip.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            iTip = iTotDue * (float)0.2;
                            strContent = String.Format("{0,25}", "20% Tip :") + String.Format("{0,15}", iTip.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        }
                    }
                    else
                    {
                        if (orderComItems.Count > 0)
                        {
                            ////////////////////////////////////////////////
                            // Add the ordered item into datagrid view
                            ////////////////////////////////////////////////
                            //iNewInvNo = orders[0].InvoiceNo;
                            foreach (var order in orderComItems)
                            {
                                float iAmount = 0;
                                string strProd = "";
                                if (order.ProductName.Length > 20)
                                {
                                    strProd = order.ProductName.Substring(0, 20);
                                }
                                if (order.OrderCategoryId == 0)
                                {
                                    iAmount = order.Quantity * order.OutUnitPrice;
                                    iSubTot = iSubTot + iAmount;
                                    iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                                    fTax1Tot += order.Tax1;
                                    fTax2Tot += order.Tax2;
                                    fTax3Tot += order.Tax3;
                                    strProd = order.ProductName;
                                    if (strProd.Length < 21)
                                    {
                                        strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                     String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                                    }
                                    else
                                    {
                                        strContent = String.Format("{0,-20}", strProd.Substring(0, 20)) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                     String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                                    }
                                }
                                else if (order.OrderCategoryId > 0) // Discount
                                {
                                    iAmount = order.Amount;
                                    iSubTot = iSubTot + iAmount;
                                    iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                                    fTax1Tot += order.Tax1;
                                    fTax2Tot += order.Tax2;
                                    fTax3Tot += order.Tax3;
                                    strProd = order.ProductName;
                                    if (strProd.Length < 21)
                                    {
                                        strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                     String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                                    }
                                    else
                                    {

                                        strContent = String.Format("{0,-20}", strProd.Substring(0, 20)) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                 String.Format("{0,7}", order.Amount.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));
                                    }
                                }
                                //////////////////////////////////////////////////////////////////////////
                                // Print order ------------------------------------------------------
                                iNextLineYPoint = iNextLineYPoint + itxtHeight;
                                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                //e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                                if (strProd.Length > 20)
                                {
                                    strContent = String.Format("{0,-20}", "-" + strProd.Substring(20));

                                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    //e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                }
                            }

                            iTotDue = iSubTot + iTaxTot;
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            strContent = String.Format("{0,25}", "Sub Total :") + String.Format("{0,15}", iSubTot.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            strContent = String.Format("{0,25}", "Tax :") + String.Format("{0,15}", iTaxTot.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            if (m_blnPrintTaxDetails)
                            {
                                if (fTax1Tot > 0)
                                {
                                    strContent = String.Format("{0,25}", strTax1Name + " :") + String.Format("{0,15}", fTax1Tot.ToString("0.00"));
                                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                }
                                if (fTax2Tot > 0)
                                {
                                    strContent = String.Format("{0,25}", strTax2Name + " :") + String.Format("{0,15}", fTax2Tot.ToString("0.00"));
                                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                }
                                if (fTax3Tot > 0)
                                {
                                    strContent = String.Format("{0,25}", strTax3Name + " :") + String.Format("{0,15}", fTax3Tot.ToString("0.00"));
                                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                }
                            }
                            cols = dbPOS1.Get_TranCollection_by_InvoiceNo(p_iInvoiceNo);

                            float fTenderAmt = 0, fTotalTips = 0, fTotalPaid = 0, fTotalChange = 0;

                            if (cols.Count > 0)
                            {
                                foreach (var col in cols)
                                {
                                    col.CollectionType = col.CollectionType.ToUpper();
                                    //if (col.CollectionType.Contains("CASH"))
                                    if (col.Cash > 0)
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        if (col.CollectionType == "CASH")
                                            strContent = String.Format("{0,25}", "Cash Paid :") + String.Format("{0,15}", (col.Cash - col.Change).ToString("0.00"));
                                        else
                                            strContent = String.Format("{0,25}", "Cash Paid :") + String.Format("{0,15}", (col.Cash).ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.CashTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Cash) :") + String.Format("{0,15}", col.CashTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }

                                    }
                                    //else if (col.CollectionType.Contains("CHEQUE"))
                                    if (col.Cheque > 0)
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Cheque Paid :") + String.Format("{0,15}", (col.Cheque - col.Change).ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);


                                    }
                                    //else if (col.CollectionType.Contains("CHARGE"))
                                    if (col.Charge > 0)
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Charge Paid :") + String.Format("{0,15}", col.Charge.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                                    }
                                    //else if (col.CollectionType.Contains("DEBIT"))
                                    if (col.Debit > 0)
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Debit Paid :") + String.Format("{0,15}", col.Debit.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.DebitTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Debit) :") + String.Format("{0,15}", col.DebitTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }
                                    }
                                    //else if (col.CollectionType.Contains("VISA"))
                                    if (col.Visa > 0)
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Visa/Credit Paid :") + String.Format("{0,15}", col.Visa.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.VisaTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Visa/Credit) :") + String.Format("{0,15}", col.VisaTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }

                                    }
                                    //else if (col.CollectionType.Contains("MASTER"))
                                    if (col.Master > 0)
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Master Paid :") + String.Format("{0,15}", col.Master.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.MasterTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Master) :") + String.Format("{0,15}", col.MasterTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }
                                    }
                                    //else if (col.CollectionType.Contains("AMEX"))
                                    if (col.Amex > 0)
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Amex Paid :") + String.Format("{0,15}", col.Amex.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.AmexTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Amex) :") + String.Format("{0,15}", col.AmexTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }
                                    }
                                    if (col.GiftCard > 0)
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        // MULTI ?
                                        //strContent = String.Format("{0,25}", col.CollectionType + " Paid :") + String.Format("{0,15}", col.Amex.ToString("0.00"));
                                        strContent = String.Format("{0,25}", "Gift Card Paid :") + String.Format("{0,15}", col.GiftCard.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.GiftCardTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(G/C) :") + String.Format("{0,15}", col.GiftCardTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }
                                    }


                                    fTenderAmt = fTenderAmt + col.Cash + col.Debit + col.Visa + col.Master + col.Amex + col.GiftCard + col.Cheque + col.Charge;
                                    fTotalPaid = fTotalPaid + col.TotalPaid;
                                    fTotalChange = fTotalChange + col.Change;
                                    fTotalTips = fTotalTips + col.TotalTip;
                                }
                                iTotDue = iTotDue - fTenderAmt;
                                if (fTotalChange != 0)
                                {
                                    //////////////////////////////////////////////////////////////////////////
                                    // Print a Line ------------------------------------------------------
                                    strContent = String.Format("{0,25}", "Total Changes :") + String.Format("{0,15}", fTotalChange.ToString("0.00"));
                                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                }
                                //////////////////////////////////////////////////////////////////////////
                                // Print a Line ------------------------------------------------------
                                strContent = String.Format("{0,25}", "Total Paid :") + String.Format("{0,15}", fTotalPaid.ToString("0.00"));
                                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            }

                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            strContent = String.Format("{0,25}", "Total Due :") + String.Format("{0,15}", iTotDue.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        }
                    }
                }

                //////////////////////////////////////////////////////////////////////////
                // Print a Line ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);

                cardReceipts = dbCard.Get_Approved_CardReceipt_By_InvoiceNo(p_iInvoiceNo);
                string strTemp1;
                string strTemp2;
                float fCurrency;
                if (cardReceipts.Count > 0)
                {
                    foreach (var receipt in cardReceipts)
                    {
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = "MID:" + receipt.MerchId;
                        strTemp2 = "REF#:" + String.Format("{0:D8}", System.Convert.ToInt32(receipt.ReferenceNo));
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", strTemp2);
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = "TID:" + receipt.TerminalId;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //strTemp1 = " > PURCHASED AMOUNT";
                        //strTemp1 = " > PURCHASED AMOUNT";
                        if (receipt.TransactionType == "00")
                            strTemp1 = " > PURCHASED AMOUNT";
                        else if (receipt.TransactionType == "03")
                            strTemp1 = " > REFUND AMOUNT";
                        else if (receipt.TransactionType == "05")
                            strTemp1 = " > VOID AMOUNT";
                        fCurrency = (float)System.Convert.ToDouble(receipt.TransactionAmount)/100;
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = " + TIP ADDED";
                        fCurrency = (float)System.Convert.ToDouble(receipt.TipAmount) / 100;
                        if (fCurrency > 0)
                        {
                            strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);

                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            //strTemp1 = " = TOTAL PAID";
                            if (receipt.TransactionType == "00")
                                strTemp1 = " = TOTAL PAID";
                            else if (receipt.TransactionType == "03")
                                strTemp1 = " = TOTAL REFUND";
                            else if (receipt.TransactionType == "05")
                                strTemp1 = " = TOTAL VOID";
                            fCurrency = (float)System.Convert.ToDouble(receipt.TotalAmount) / 100;
                            strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        }
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = receipt.EMVApplicationLabel + " ACCN No : " + receipt.CustomerAccountNumber;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight*1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = String.Format("DATE: {0:D}", receipt.CreateDate);
                        strTemp2 = String.Format("TIME: {0:T}", receipt.CreateTime);
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", strTemp2);
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = "AUTH NO: " + receipt.AuthorizationNo;
                        strTemp2 = "TSI: " + receipt.EmvTsi;
                        strContent = String.Format("{0,-30}", strTemp1) + String.Format("{0,13}", strTemp2);
                        //iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 2);
                        iNextLineYPoint = iNextLineYPoint + (iheaderHeight);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = "AID: " + receipt.EmvAid;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = "TVR: " + receipt.EmvTvr;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);

                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString(receipt.HostResponseText, fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        //iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        //txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        //e1.Graphics.DrawString("SIGNATURE NOT REQUIRED", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        //iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        //txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        //e1.Graphics.DrawString("IMPORTANT", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("Pls. retain this copy for your records.", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("CARDHOLDER ACKNOWLEDGES RECEIPT OF GOODS", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("AND/OR SERVICES IN THE AMOUNT OF THE", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("TOTAL SHOWN HEREON", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                    } // for each
                } //if (cardReceipts.Count > 0)
                  // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString("THANK YOU FOR COMING", fntCard, brsBlack, (RectangleF)txtRect, format1);
            }; //if (IsInvoice)
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }

        private void ShowReceiptInfoOnScreen(List<POS1_TranCollectionModel> cols, List<POS1_OrderCompleteModel> orderComItems, List<CCardReceipt> cardReceipts)
        {
            int iLastBottom = 0;
            int iItemCount = (int)orderComItems.FindAll(item => item.ProductId > 0).Sum(item => item.Quantity);

            // Add a line
            Label lblLine1 = new Label();
            Label lblLine2 = new Label();
            lblLine1.Name = "Line1";
            lblLine1.Text = "--------------------------------------------------";
            lblLine1.Font = new Font("Arial", 12, FontStyle.Bold);
            lblLine1.ForeColor = Color.WhiteSmoke;
            lblLine1.TextAlign = ContentAlignment.MiddleCenter;
            lblLine1.Width = pnlReceipt.Width;
            lblLine1.Height = 20;

            lblLine2.Name = "Line2";
            lblLine2.Text = "--------------------------------------------------";
            lblLine2.Font = new Font("Arial", 12, FontStyle.Bold);
            lblLine2.ForeColor = Color.WhiteSmoke;
            lblLine2.TextAlign = ContentAlignment.MiddleCenter;
            lblLine2.Width = pnlReceipt.Width;
            lblLine2.Height = 20;

            if (cols.Count > 0)
            {
                pnlReceipt.Visible = true;
                pnlReceipt.Top = dgv_Orders.Top;
                pnlReceipt.Left = dgv_Orders.Left;
                pnlReceipt.Width = dgv_Orders.Width;
                pnlReceipt.Height = dgv_Orders.Height;

                // delete all label controls on the pnlReceipt
                pnlReceipt.Controls.Clear();
                // Add a label to pnlReceipt panel
                Label lbl = new Label();
                lbl.Name = "lblReceipt";
                lbl.Text = "Last Receipt (Invoice # : " + cols.First().InvoiceNo.ToString() + ")";
                lbl.Font = new Font("Arial", 12, FontStyle.Bold);
                lbl.ForeColor = Color.Black;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Width = pnlReceipt.Width;
                lbl.Height = 30;
                lbl.Top = 0;
                lbl.Left = 0;
                pnlReceipt.Controls.Add(lbl);
                iLastBottom = lbl.Bottom;

                // Add a label to pnlReceipt panel
                Label lblItems = new Label();
                lblItems.Name = "Items";
                lblItems.Text = "Number of Items : " + iItemCount.ToString();
                lblItems.Font = new Font("Arial", 16, FontStyle.Bold);
                lblItems.ForeColor = Color.White;
                lblItems.TextAlign = ContentAlignment.MiddleCenter;
                lblItems.Width = pnlReceipt.Width;
                lblItems.Height = 30;
                lblItems.Top = iLastBottom;
                lblItems.Left = 0;
                pnlReceipt.Controls.Add(lblItems);
                iLastBottom = lblItems.Bottom;

                lblLine1.Top = iLastBottom;
                lblLine1.Left = 0;
                pnlReceipt.Controls.Add(lblLine1);
                iLastBottom = lblLine1.Bottom;

                // Add a label to pnlReceipt panel
                Label lblSubTotal = new Label();
                lblSubTotal.Name = "SubTotal";
                lblSubTotal.Text = "Sub Total : " + cols.Sum(col => col.Amount).ToString("C2");
                lblSubTotal.Font = new Font("Arial", 16, FontStyle.Bold);
                lblSubTotal.ForeColor = Color.White;
                lblSubTotal.TextAlign = ContentAlignment.MiddleCenter;
                lblSubTotal.Width = pnlReceipt.Width;
                lblSubTotal.Height = 30;
                lblSubTotal.Top = iLastBottom;
                lblSubTotal.Left = 0;
                pnlReceipt.Controls.Add(lblSubTotal);
                iLastBottom = lblSubTotal.Bottom;

                // Add a label to pnlReceipt panel
                if (cols.Sum(col => col.Tax1) != 0)
                {
                    Label lblTax1 = new Label();
                    lblTax1.Name = "strTax1Name";
                    lblTax1.Text = strTax1Name + " : " + cols.Sum(col => col.Tax1).ToString("C2");
                    lblTax1.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblTax1.ForeColor = Color.LightGray;
                    lblTax1.TextAlign = ContentAlignment.MiddleCenter;
                    lblTax1.Width = pnlReceipt.Width;
                    lblTax1.Height = 30;
                    lblTax1.Top = iLastBottom;
                    lblTax1.Left = 0;
                    pnlReceipt.Controls.Add(lblTax1);
                    iLastBottom = lblTax1.Bottom;
                }
                if (cols.Sum(col => col.Tax2) != 0)
                {
                    Label lblTax2 = new Label();
                    lblTax2.Name = "strTax2Name";
                    lblTax2.Text = strTax2Name + " : " + cols.Sum(col => col.Tax2).ToString("C2");
                    lblTax2.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblTax2.ForeColor = Color.LightGray;
                    lblTax2.TextAlign = ContentAlignment.MiddleCenter;
                    lblTax2.Width = pnlReceipt.Width;
                    lblTax2.Height = 30;
                    lblTax2.Top = iLastBottom;
                    lblTax2.Left = 0;
                    pnlReceipt.Controls.Add(lblTax2);
                    iLastBottom = lblTax2.Bottom;
                }
                if (cols.Sum(col => col.Tax3) != 0)
                {
                    Label lblTax3 = new Label();
                    lblTax3.Name = "strTax3Name";
                    lblTax3.Text = strTax3Name + " : " + cols.Sum(col => col.Tax3).ToString("C2");
                    lblTax3.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblTax3.ForeColor = Color.LightGray;
                    lblTax3.TextAlign = ContentAlignment.MiddleCenter;
                    lblTax3.Width = pnlReceipt.Width;
                    lblTax3.Height = 30;
                    lblTax3.Top = iLastBottom;
                    lblTax3.Left = 0;
                    pnlReceipt.Controls.Add(lblTax3);
                    iLastBottom = lblTax3.Bottom;
                }
                if (cols.Sum(col => (col.Tax1 + col.Tax2 + col.Tax3)) != 0)
                {
                    Label lblTaxSum = new Label();
                    lblTaxSum.Name = "TaxTot";
                    lblTaxSum.Text = "Tax Total : " + cols.Sum(col => col.Tax1 + col.Tax2 + col.Tax3).ToString("C2");
                    lblTaxSum.Font = new Font("Arial", 16, FontStyle.Bold);
                    lblTaxSum.ForeColor = Color.White;
                    lblTaxSum.TextAlign = ContentAlignment.MiddleCenter;
                    lblTaxSum.Width = pnlReceipt.Width;
                    lblTaxSum.Height = 30;
                    lblTaxSum.Top = iLastBottom;
                    lblTaxSum.Left = 0;
                    pnlReceipt.Controls.Add(lblTaxSum);
                    iLastBottom = lblTaxSum.Bottom;
                }
                if (cols.Sum(col => (col.Amount + col.Tax1 + col.Tax2 + col.Tax3)) != 0)
                {
                    Label lblTotAmt = new Label();
                    lblTotAmt.Name = "TotAmt";
                    lblTotAmt.Text = "Total Amount : " + cols.Sum(col => col.Amount + col.Tax1 + col.Tax2 + col.Tax3).ToString("C2");
                    lblTotAmt.Font = new Font("Arial", 16, FontStyle.Bold);
                    lblTotAmt.ForeColor = Color.White;
                    lblTotAmt.TextAlign = ContentAlignment.MiddleCenter;
                    lblTotAmt.Width = pnlReceipt.Width;
                    lblTotAmt.Height = 30;
                    lblTotAmt.Top = iLastBottom;
                    lblTotAmt.Left = 0;
                    pnlReceipt.Controls.Add(lblTotAmt);
                    iLastBottom = lblTotAmt.Bottom;
                }

                lblLine2.Top = iLastBottom;
                lblLine2.Left = 0;
                pnlReceipt.Controls.Add(lblLine2);
                iLastBottom = lblLine2.Bottom;

                if (cols.Sum(col => (col.Cash)) != 0)
                {
                    Label lblCash = new Label();
                    lblCash.Name = "Cash";
                    lblCash.Text = "Cash Paid : " + cols.Sum(col => (col.Cash - col.Change)).ToString("C2");
                    lblCash.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblCash.ForeColor = Color.WhiteSmoke;
                    lblCash.TextAlign = ContentAlignment.MiddleCenter;
                    lblCash.Width = pnlReceipt.Width;
                    lblCash.Height = 30;
                    lblCash.Top = iLastBottom;
                    lblCash.Left = 0;
                    pnlReceipt.Controls.Add(lblCash);
                    iLastBottom = lblCash.Bottom;
                }
                if (cols.Sum(col => (col.Debit)) != 0)
                {
                    Label lblDebit = new Label();
                    lblDebit.Name = "Debit";
                    lblDebit.Text = "Debit Paid : " + cols.Sum(col => col.Debit).ToString("C2");
                    lblDebit.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblDebit.ForeColor = Color.WhiteSmoke;
                    lblDebit.TextAlign = ContentAlignment.MiddleCenter;
                    lblDebit.Width = pnlReceipt.Width;
                    lblDebit.Height = 30;
                    lblDebit.Top = iLastBottom;
                    lblDebit.Left = 0;
                    pnlReceipt.Controls.Add(lblDebit);
                    iLastBottom = lblDebit.Bottom;
                }
                if (cols.Sum(col => (col.Visa)) != 0)
                {
                    Label lblVisa = new Label();
                    lblVisa.Name = "Visa";
                    lblVisa.Text = "Visa Paid : " + cols.Sum(col => col.Visa).ToString("C2");
                    lblVisa.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblVisa.ForeColor = Color.WhiteSmoke;
                    lblVisa.TextAlign = ContentAlignment.MiddleCenter;
                    lblVisa.Width = pnlReceipt.Width;
                    lblVisa.Height = 30;
                    lblVisa.Top = iLastBottom;
                    lblVisa.Left = 0;
                    pnlReceipt.Controls.Add(lblVisa);
                    iLastBottom = lblVisa.Bottom;
                }
                if (cols.Sum(col => (col.Master)) != 0)
                {
                    Label lblMaster = new Label();
                    lblMaster.Name = "Master";
                    lblMaster.Text = "Master Paid : " + cols.Sum(col => col.Master).ToString("C2");
                    lblMaster.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblMaster.ForeColor = Color.WhiteSmoke;
                    lblMaster.TextAlign = ContentAlignment.MiddleCenter;
                    lblMaster.Width = pnlReceipt.Width;
                    lblMaster.Height = 30;
                    lblMaster.Top = iLastBottom;
                    lblMaster.Left = 0;
                    pnlReceipt.Controls.Add(lblMaster);
                    iLastBottom = lblMaster.Bottom;
                }
                if (cols.Sum(col => (col.Amex)) != 0)
                {
                    Label lblAmex = new Label();
                    lblAmex.Name = "Amex";
                    lblAmex.Text = "Amex Paid : " + cols.Sum(col => col.Amex).ToString("C2");
                    lblAmex.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblAmex.ForeColor = Color.WhiteSmoke;
                    lblAmex.TextAlign = ContentAlignment.MiddleCenter;
                    lblAmex.Width = pnlReceipt.Width;
                    lblAmex.Height = 30;
                    lblAmex.Top = iLastBottom;
                    lblAmex.Left = 0;
                    pnlReceipt.Controls.Add(lblAmex);
                    iLastBottom = lblAmex.Bottom;
                }
                if (cardReceipts.Count > 0)
                {
                    Label lblAmex = new Label();
                    lblAmex.Name = "CardReceipt";
                    lblAmex.Text = "Card Tran Status : " + cardReceipts[0].HostResponseText;
                    lblAmex.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblAmex.ForeColor = Color.Gray;
                    lblAmex.TextAlign = ContentAlignment.MiddleCenter;
                    lblAmex.Width = pnlReceipt.Width;
                    lblAmex.Height = 30;
                    lblAmex.Top = iLastBottom;
                    lblAmex.Left = 0;
                    pnlReceipt.Controls.Add(lblAmex);
                    iLastBottom = lblAmex.Bottom;
                }
                if (cols.Sum(col => (col.GiftCard)) != 0)
                {
                    Label lblGiftCard = new Label();
                    lblGiftCard.Name = "GiftCard";
                    lblGiftCard.Text = "GiftCard Paid : " + cols.Sum(col => col.GiftCard).ToString("C2");
                    lblGiftCard.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblGiftCard.ForeColor = Color.WhiteSmoke;
                    lblGiftCard.TextAlign = ContentAlignment.MiddleCenter;
                    lblGiftCard.Width = pnlReceipt.Width;
                    lblGiftCard.Height = 30;
                    lblGiftCard.Top = iLastBottom;
                    lblGiftCard.Left = 0;
                    pnlReceipt.Controls.Add(lblGiftCard);
                    iLastBottom = lblGiftCard.Bottom;
                }
                if (cols.Sum(col => (col.Cheque)) != 0)
                {
                    Label lblCheque = new Label();
                    lblCheque.Name = "Cheque";
                    lblCheque.Text = "Cheque Paid : " + cols.Sum(col => col.Cheque).ToString("C2");
                    lblCheque.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblCheque.ForeColor = Color.WhiteSmoke;
                    lblCheque.TextAlign = ContentAlignment.MiddleCenter;
                    lblCheque.Width = pnlReceipt.Width;
                    lblCheque.Height = 30;
                    lblCheque.Top = iLastBottom;
                    lblCheque.Left = 0;
                    pnlReceipt.Controls.Add(lblCheque);
                    iLastBottom = lblCheque.Bottom;
                }
                if (cols.Sum(col => (col.Charge)) != 0)
                {
                    Label lblCharge = new Label();
                    lblCharge.Name = "Charge";
                    lblCharge.Text = "Charge Paid : " + cols.Sum(col => col.Charge).ToString("C2");
                    lblCharge.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblCharge.ForeColor = Color.WhiteSmoke;
                    lblCharge.TextAlign = ContentAlignment.MiddleCenter;
                    lblCharge.Width = pnlReceipt.Width;
                    lblCharge.Height = 30;
                    lblCharge.Top = iLastBottom;
                    lblCharge.Left = 0;
                    pnlReceipt.Controls.Add(lblCharge);
                    iLastBottom = lblCharge.Bottom;
                }
                if (cols.Sum(col => (col.Change)) != 0)
                {
                    Label lblChange = new Label();
                    lblChange.Name = "Change";
                    lblChange.Text = "Change : " + cols.Sum(col => col.Change).ToString("C2");
                    lblChange.Font = new Font("Arial", 12, FontStyle.Bold);
                    lblChange.ForeColor = Color.OrangeRed;
                    lblChange.TextAlign = ContentAlignment.MiddleCenter;
                    lblChange.Width = pnlReceipt.Width;
                    lblChange.Height = 30;
                    lblChange.Top = iLastBottom;
                    lblChange.Left = 0;
                    pnlReceipt.Controls.Add(lblChange);
                    iLastBottom = lblChange.Bottom;
                }
                if (cols.Sum(col => (col.TotalPaid)) != 0)
                {
                    Label lblTotalPaid = new Label();
                    lblTotalPaid.Name = "Total";
                    lblTotalPaid.Text = "Total Paid : " + cols.Sum(col => col.TotalPaid).ToString("C2");
                    lblTotalPaid.Font = new Font("Arial", 16, FontStyle.Bold);
                    lblTotalPaid.ForeColor = Color.Gold;
                    lblTotalPaid.TextAlign = ContentAlignment.MiddleCenter;
                    lblTotalPaid.Width = pnlReceipt.Width;
                    lblTotalPaid.Height = 30;
                    lblTotalPaid.Top = iLastBottom;
                    lblTotalPaid.Left = 0;
                    pnlReceipt.Controls.Add(lblTotalPaid);
                    iLastBottom = lblTotalPaid.Bottom;
                }
            }
        }

        private void bt_SetPPL_Click(object sender, EventArgs e)
        {
            try
            {
                if (proc != null)
                {
                    proc.Kill();
                }
            }
            catch (Exception)
            {

            }

            DataAccessPOS dbPOS = new DataAccessPOS();
            if (!string.IsNullOrEmpty(txtAmtEach.Text))
            {
                try
                {
                    iPpleCount = int.Parse(txtAmtEach.Text);
                    txtSelectedMenu.ForeColor = Color.Black;
                    txtAmtEach.BackColor = Color.LightGreen;
                    fTotDue = dbPOS.Get_Total_Due_Amount(iNewInvNo);
                    float dueNum = fTotDue / iPpleCount;
                    txtAmtEach.Text = string.Format("{0:c}", dueNum);
                    bt_SetPPL.Tag = iPpleCount;
                }
                catch (Exception)
                {

                    if ((int)bt_SetPPL.Tag > 0)
                    {
                        fTotDue = dbPOS.Get_Total_Due_Amount(iNewInvNo);
                        float dueNum = fTotDue / iPpleCount;
                        txtAmtEach.Text = string.Format("{0:c}", dueNum);
                    }
                    else
                    {
                        iPpleCount = 0;
                        bt_SetPPL.Tag = 0;
                        txtSelectedMenu.Text = "1/N should be numeric! Please correct the number";
                        txtSelectedMenu.ForeColor = Color.Red;
                        txtAmtEach.BackColor = Color.Pink;
                        txtAmtEach.Focus();
                    }
                    return;
                }
                tTip.Show("1/N is " + bt_SetPPL.Tag, bt_SetPPL);
            }
            BarCode_Get_Focus();
        }

        private void txtAmtEach_Click(object sender, EventArgs e)
        {
            //run on screen keyboard
            proc = Process.Start("osk.exe");
            txtAmtEach.Text = "0";
            txtAmtEach.SelectAll();
            iPpleCount = 0;
            bt_SetPPL.Tag = 0;
        }

        private void bt_ShowAllMenuItem_Click(object sender, EventArgs e)
        {
            iSelectedProdTypeID = 0;
            PopulateMenuButtonByPopularity();
            txtSelectedMenu.Text = "All menu items are shown";
            BarCode_Get_Focus();
        }

        private void PopulateMenuButtonByPopularity()
        {
            int xPos = 0;
            int yPos = 0;
            int iLines = 0;

            iCurrentProdPage = 1;
            iTotalProdPages = 1;
            //////////////////////////////////////////////////////
            // Declare and assign number of buttons = 20 
            //System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[30];
            //CustomButton[] btnArray = new CustomButton[35];
            //////////////////////////////////////////////////////
            // Create (20) Buttons: 
            for (int i = 0; i < 100; i++)
            {
                // Initialize one variable 
                //btnArray[i] = new System.Windows.Forms.Button();
                btnArray[i] = new CustomButton();
                btnArray[i].Click -= new System.EventHandler(ClickMenuButton);
            }

            pnlMenu.Controls.Clear();

            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            POS_ProductModel prod = new POS_ProductModel();
            prodPops = dbPOS1.Get_ProdPopularity_OrderComp();

            if (prodPops.Count > 0)
            {
                int n = 0;
                foreach (var prodPop in prodPops)
                {
                    prods = dbPOS.Get_Product_By_ID(prodPop.ProductId);
                    if (prods.Count > 0)
                    {
                        prod = prods[0];
                        btnArray[n].Tag = n + 1; // Tag of button 
                        btnArray[n].Width = (pnlMenu.Width / 5) - 5; // Width of button 
                        btnArray[n].Height = (pnlMenu.Height / 5) - 5; // Height of button
                        btnArray[n].Font = new Font("Arial", 11, FontStyle.Bold);
                        //btnArray[n].BackColor = Color.LightSteelBlue;
                        btnArray[n].ForeColor = Color.WhiteSmoke;
                        btnArray[n].CornerRadius = 30;
                        btnArray[n].RoundCorners = Corners.TopLeft | Corners.TopRight | Corners.BottomLeft;
                        //btnArray[n].RoundCorners = Corners.All;
                        //btnArray[n].AutoSize = true;
                        /////////////////////////////////////////////////////
                        // 4 Buttons in one line
                        /////////////////////////////////////////////////////
                        if (n >= 5) // Location of second line of buttons: 
                        {
                            if (n % 5 == 0)
                            {
                                xPos = 0;
                                yPos = yPos + btnArray[n].Height + 5;
                                iLines++;
                            }
                        }
                        if ((n) % 25 == 0)
                        {
                            iTotalProdPages++;
                        }
                        if (iLines > 5)
                        {
                            iLines = 1;
                        }
                        btnArray[n].BackColor = btColor[iLines];
                        // Location of button: 
                        btnArray[n].Left = xPos;
                        btnArray[n].Top = yPos;
                        // Add buttons to a Panel: E0040150996E1CA8
                        pnlMenu.Controls.Add(btnArray[n]);  // Let panel hold the Buttons 
                        xPos = xPos + btnArray[n].Width + 5;    // Left of next button 
                                                                // Write English Character: 
                        /* **************************************************************** 
                            Menu item button text
                        //**************************************************************** */

                        //btnArray[n].Text = ((char)(n + 65)).ToString() + (n+1).ToString();

                        btnArray[n].Text = prod.ProductName + Environment.NewLine + prod.OutUnitPrice.ToString("c2");
                        //if (prod.ProductName.Length > 10)
                        //{
                        //    int spaceIndex = prod.ProductName.IndexOf(" ", 10);
                        //    if (spaceIndex > 10)
                        //    {
                        //        btnArray[n].Text = prod.ProductName.Substring(0, spaceIndex) + Environment.NewLine + prod.ProductName.Substring(spaceIndex);
                        //    }
                        //}
                        btnArray[n].Tag = prod.Id;

                        // the Event of click Button 
                        btnArray[n].Click += new System.EventHandler(ClickMenuButton);

                        n++;
                    }
                }
            }
            lbl_ProdPages.Text = iCurrentProdPage.ToString() + "/" + (iTotalProdPages - 1).ToString();
            pnlMenu.Enabled = true; // not need now to this button now 
            //label1.Visible = true;
        }

        private void timerSetTime_Tick(object sender, EventArgs e)
        {
            textNow.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");

            iTimerCount++;

            if (iTimerCount >= 3)
            {
                // Rounding for Cash Payment
                m_fCashDue = (float)(Math.Round((iTotalDue / 0.05)) * 0.05);
                m_fCashRounding = (float)Math.Round(m_fCashDue - iTotalDue, 2);
                //util.Logger("frmCashPayment Loading ... Rounding ? " + m_fCashRounding.ToString());
                if (lblTotalDue.Text != "Total Due")
                {
                    lblTotalDue.Text = "Total Due";
                    txt_TotalDue.Text = iTotalDue.ToString("C2");
                    txt_TotalDue.BackColor = Color.Yellow;
                }
                else
                {
                    lblTotalDue.Text = "Cash Due";
                    txt_TotalDue.Text = m_fCashDue.ToString("c2");
                    txt_TotalDue.BackColor = Color.LightSalmon;
                }
                iTimerCount = 0;
            }

        }

        private void bt_SalesCustomer_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == "frmSalesCustomer")
                {
                    frm.BringToFront();
                    return;
                }
            }
            if (Screen.AllScreens.Length > 1)
            {
                frmSalesCustomer FrmSalesCustomer = new frmSalesCustomer(this);
                // Important !
                FrmSalesCustomer.StartPosition = FormStartPosition.Manual;

                // Get the second monitor screen
                Screen screen = GetSecondaryScreen();

                // set the location to the top left of the second screen
                FrmSalesCustomer.Location = screen.WorkingArea.Location;
                FrmSalesCustomer.Width = screen.WorkingArea.Width;
                FrmSalesCustomer.Height = screen.WorkingArea.Height;
                // set it fullscreen
                //FrmSalesCustomer.Size = new Size(screen.WorkingArea.Width, screen.WorkingArea.Height);
                //FrmSalesCustomer.ShowDialog();
                FrmSalesCustomer.Show();
                // Show the form
            }
            else
            {
                //MessageBox.Show("No External Display is Available");
            }
            BarCode_Get_Focus();
        }
        public Screen GetSecondaryScreen()
        {
            if (Screen.AllScreens.Length == 1)
            {
                return null;
            }

            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Primary == false)
                {
                    return screen;
                }
            }

            return null;
        }
        public void PaymentByCustomer()
        {
           this.bt_Payment.PerformClick();
        }
        public void StartScanByCustomer()
        {
            util.Logger("StartScanByCustomer : InvoiceNo = " + iNewInvNo.ToString());
            Initialize_Local_Variables();
            if (isRFIDConnected)
            {
                this.bt_Stop.PerformClick();
                this.bt_Start.PerformClick();
            }
            bt_Start.Enabled = false;
            bt_Payment.Enabled = true;

        }

        private void bt_HideSideBar_Click_1(object sender, EventArgs e)
        {
            pnlSideBar.Hide();
            BarCode_Get_Focus();
        }

        private void bt_ShowSideBar_Click_1(object sender, EventArgs e)
        {
            pnlSideBar.Location = new Point(861, 4);
            pnlSideBar.Show();
            pnlSideBar.BringToFront();
            BarCode_Get_Focus();
            timerExtendBar.Enabled = true;
        }

        private void bt_ShowAllMenuItem_Click_1(object sender, EventArgs e)
        {
            iSelectedProdTypeID = 0;
            PopulateMenuButtonByPopularity();
            txtSelectedMenu.Text = "All menu items are shown";
            BarCode_Get_Focus();
        }

        private void bt_Start_Click_1(object sender, EventArgs e)
        {
            //            if (selectedBTN == null)
            //            {
            //                MessageBox.Show("Please select a menu item first!");
            //                return;
            //            }
            if (!isRFIDConnected)
            {
                return;
            }
            _shouldStop = false;

            bPaymentSuccess = false;    // global variable used by another form
            bCashPayment = false;

            bt_Start.Enabled = false;
            bt_Stop.Enabled = true;

            listView1.Items.Clear();
            listView2.Items.Clear();

            // reader option setting
            enableAFI = 0;
            onlyNewTag = 0;
            // antenna selection
            int iCount = 4;
            AntennaSelCount = (Byte)iCount;
            CSupportedAirProtocol aip;
            aip = (CSupportedAirProtocol)airInterfaceProtList[0];
            aip.m_en = true;
            /*
             * Start the thread to inventory tags 
             */
            //// Set the flag for the new customer
            isNewInvoice = false;
            iNewInvNo = 0;
            Initialize_Local_Variables();

            //Bug #1553
            util.Logger("bt_Start_Click_1 : InvoiceNo = " + iNewInvNo.ToString());
            Load_Existing_Orders();

            InvenThread = new Thread(DoInventory);
            InvenThread.Start();

            inventoryState = 1;
            BarCode_Get_Focus();
            return;
        }

        private void bt_Stop_Click_1(object sender, EventArgs e)
        {
            if (!isRFIDConnected)
            {
                return;
            }
            _shouldStop = true;
            bt_Start.Enabled = true;

            /*
             * Exit the inventory quickly
             */
            RFIDLIB.rfidlib_reader.RDR_SetCommuImmeTimeout(hreader);

            util.Logger("bt_Stop_Click_1 InvNo  :" + iNewInvNo.ToString());
            ////////////////////////////////////////
            // Abort Inventory Scan thread
            if (InvenThread != null)
            //if (!_shouldStop)
            //if (InvenThread.IsAlive)
            {
                InvenThread.Interrupt();
                //System.Threading.Thread.Sleep(2000);
                InvenThread.Abort();
                // InvenThread.Join();
                InvenThread = null;

                /////////////////////////////////////
                // Normal stop of thread
                //InvenThread.Join();
            }
            BarCode_Get_Focus();
        }

        private void bt_Exit_Click_1(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Do you really want to finish ?", "POS Sales Main", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    this.Close();
            //    Application.Exit();
            //}
            //else if (dialogResult == DialogResult.No)
            //{
                //do something else
                // Do nothing
            //}
            using (var FrmYesNo = new frmYesNo(this))
            {
                FrmYesNo.Set_Title("POS Sales Main");
                FrmYesNo.Set_Message("Do you really want to finish ?");
                FrmYesNo.StartPosition = FormStartPosition.Manual; // FormStartPosition.CenterScreen; //
                FrmYesNo.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                FrmYesNo.ShowDialog();

                if (FrmYesNo.bYesNo)
                {
                    //Kill_If_SalesCustomer_Opened();
                    //this.Hide();
                    // This hides the form, and causes ShowDialog() to return in your Form1
                    //this.DialogResult = DialogResult.OK;
                    this.Hide();
                    Application.Exit();
//                  if (this.FrmLogOn != null)
//                        this.FrmLogOn.Show();
                    //this.Close();

                }
            }

        }

        private void bt_SalesHistory_Click(object sender, EventArgs e)
        {
            //if (loginUsers[0].Grade == "1")
            //{
                FrmSalesHist = new frmSalesHistory(this);
                FrmSalesHist.p_strLoginPassword = loginUsers[0].PassWord;
                FrmSalesHist.p_intLoginUserId = loginUsers[0].Id;
                FrmSalesHist.p_blnPaymentree = m_blnPaymentree;
                FrmSalesHist.p_strUserName = loginUsers[0].FirstName;
                FrmSalesHist.p_strStation = strStation;

                FrmSalesHist.Show();
                FrmSalesHist.BringToFront();
                // Show the FrmSalesHist on Top most
                FrmSalesHist.TopMost = true;
            //}
            /*else
            {
                using (var FrmYesNo = new frmYesNo(this))
                {
                    FrmYesNo.Set_Title("POS Sales Main");
                    FrmYesNo.Set_Message("Please check your login grade!");
                    FrmYesNo.StartPosition = FormStartPosition.Manual; // FormStartPosition.CenterScreen; //
                    FrmYesNo.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                              (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                    FrmYesNo.ShowDialog();

                    if (FrmYesNo.bYesNo)
                    {
                        // do nothing
                    }
                }
            }*/
            //BarCode_Get_Focus();
        }

        private void bt_ProdPageUp_Click(object sender, EventArgs e)
        {
            iCurrentProdPage--;

            if (iCurrentProdPage <= 1)
            {
                PopulateMenuButtons(false, 0);
                return;
            }

            int xPos = 0;
            int yPos = (((btnArray[0].Height + 5) * 5) * -iCurrentProdPage) + ((btnArray[0].Height + 5) * 5);
            int iLines = 0;
            int iPages = 0;

            for (int i = 0; i < btnArray.Length; i++)
            {
                //btnTypeArray[n].Left = xPos; // Should be no changes
                /////////////////////////////////////////////////////
                // 4 Buttons in one line
                /////////////////////////////////////////////////////
                if (i >= 5) // Location of second line of buttons: 
                {
                    if (i % 5 == 0)
                    {
                        //xPos = 0;
                        //yPos = yPos - ((((btnArray[i].Height + 5) * 5) * iCurrentProdPage) - ((btnArray[i].Height + 5) * 5));
                        yPos = yPos + btnArray[i].Height + 5;
                        iLines++;
                    }
                }
                if ((i) % 25 == 0)
                {
                    iPages++;
                }
                if (iLines > 5)
                {
                    iLines = 1;
                }
                btnArray[i].BackColor = btColor[iLines];
                // Location of button: 
                //btnArray[i].Left = xPos;
                btnArray[i].Top = yPos;
                // Add buttons to a Panel: E0040150996E1CA8
                xPos = xPos + btnArray[i].Width + 5;    // Left of next button 
                                                        // Write English Character: 
                                                        //btnArray[i].Top = btnArray[i].Top - ((((btnArray[i].Height + 5) * 5) * iCurrentProdPage) - ((btnArray[i].Height + 5) * 5));
            }
            lbl_ProdPages.Text = iCurrentProdPage.ToString() + "/" + (iTotalProdPages - 1).ToString();
            BarCode_Get_Focus();
        }

        private void bt_ProdPageDown_Click(object sender, EventArgs e)
        {
            iCurrentProdPage++;

            if (iCurrentProdPage > (iTotalProdPages - 1))
            {
                iCurrentProdPage = iTotalProdPages - 1;
                return;
            }

            int xPos = 0;
            int yPos = (((btnArray[0].Height + 5) * 5) * - iCurrentProdPage) + ((btnArray[0].Height + 5) * 5);
            int iLines = 0;
            int iPages = 0;

            for (int i = 0; i < btnArray.Length; i++)
            {
                //btnTypeArray[n].Left = xPos; // Should be no changes
                /////////////////////////////////////////////////////
                // 4 Buttons in one line
                /////////////////////////////////////////////////////
                if (i >= 5) // Location of second line of buttons: 
                {
                    if (i % 5 == 0)
                    {
                        //xPos = 0;
                        //yPos = yPos - ((((btnArray[i].Height + 5) * 5) * iCurrentProdPage) - ((btnArray[i].Height + 5) * 5));
                        yPos = yPos + btnArray[i].Height + 5;
                        iLines++;
                    }
                }
                if ((i) % 25 == 0)
                {
                    iPages++;
                }
                if (iLines>5)
                {
                    iLines = 1;
                }

                btnArray[i].BackColor = btColor[iLines];
                // Location of button: 
                //btnArray[i].Left = xPos;
                btnArray[i].Top = yPos;
                // Add buttons to a Panel: E0040150996E1CA8
                xPos = xPos + btnArray[i].Width + 5;    // Left of next button 
                                                        // Write English Character: 
                //btnArray[i].Top = btnArray[i].Top - ((((btnArray[i].Height + 5) * 5) * iCurrentProdPage) - ((btnArray[i].Height + 5) * 5));
            }
            lbl_ProdPages.Text = iCurrentProdPage.ToString() + "/" + (iTotalProdPages - 1).ToString();
            BarCode_Get_Focus();
        }

        private void bt_TypePageUp_Click(object sender, EventArgs e)
        {
            iCurrentTypePage--;
            if (iCurrentTypePage <= 1)
            {
                PopulateMenuTypeButtons();
                return;
            }

            int xPos = 0;
            int yPos = (((btnTypeArray[0].Height + 5) * 3) * -iCurrentTypePage) + ((btnTypeArray[0].Height + 5) * 3);
            int iLines = 0;
            int iPages = 0;

            for (int i = 0; i < btnTypeArray.Length; i++)
            {
                //btnTypeArray[n].Left = xPos; // Should be no changes
                /////////////////////////////////////////////////////
                // 4 Buttons in one line
                /////////////////////////////////////////////////////
                if (i >= 4) // Location of second line of buttons: 
                {
                    if (i % 4 == 0)
                    {
                        //xPos = 0;
                        //yPos = yPos - ((((btnArray[i].Height + 5) * 5) * iCurrentProdPage) - ((btnArray[i].Height + 5) * 5));
                        yPos = yPos + btnTypeArray[i].Height + 5;
                        iLines++;
                    }
                }
                if ((i) % 12 == 0)
                {
                    iPages++;
                }
                if (iLines > 5)
                {
                    iLines = 1;
                }
                btnTypeArray[i].BackColor = btTypeColor[iLines]; //btColor[iLines];
                // Location of button: 
                //btnArray[i].Left = xPos;
                btnTypeArray[i].Top = yPos;
                // Add buttons to a Panel: E0040150996E1CA8
                xPos = xPos + btnTypeArray[i].Width + 5;    // Left of next button 
                                                        // Write English Character: 
                                                        //btnArray[i].Top = btnArray[i].Top - ((((btnArray[i].Height + 5) * 5) * iCurrentProdPage) - ((btnArray[i].Height + 5) * 5));
            }
            lbl_TypePages.Text = iCurrentTypePage.ToString() + "/" + (iTotalTypePages - 1).ToString();
            BarCode_Get_Focus();
        }

        private void bt_TypePageDown_Click(object sender, EventArgs e)
        {
            iCurrentTypePage++;
            if (iCurrentTypePage > (iTotalTypePages-1))
            {
                iCurrentTypePage = iTotalTypePages - 1;
                //return;
            }

            int xPos = 0;
            int yPos = (((btnTypeArray[0].Height + 5) * 3) * - iCurrentTypePage) + ((btnTypeArray[0].Height + 5) * 3);
            int iLines = 0;
            int iPages = 0;

            for (int i = 0; i < btnTypeArray.Length; i++)
            {
                //btnTypeArray[n].Left = xPos; // Should be no changes
                /////////////////////////////////////////////////////
                // 4 Buttons in one line
                /////////////////////////////////////////////////////
                if (i >= 4) // Location of second line of buttons: 
                {
                    if (i % 4 == 0)
                    {
                        //xPos = 0;
                        //yPos = yPos - ((((btnArray[i].Height + 5) * 5) * iCurrentProdPage) - ((btnArray[i].Height + 5) * 5));
                        yPos = yPos + btnTypeArray[i].Height + 5;
                        iLines++;
                    }
                }
                if ((i) % 12 == 0)
                {
                    iPages++;
                }
                if (iLines > 5)
                {
                    iLines = 1;
                }
                btnTypeArray[i].BackColor = btTypeColor[iLines]; //btColor[iLines];
                // Location of button: 
                //btnArray[i].Left = xPos;
                btnTypeArray[i].Top = yPos;
                // Add buttons to a Panel: E0040150996E1CA8
                xPos = xPos + btnTypeArray[i].Width + 5;    // Left of next button 
                                                            // Write English Character: 
                                                            //btnArray[i].Top = btnArray[i].Top - ((((btnArray[i].Height + 5) * 5) * iCurrentProdPage) - ((btnArray[i].Height + 5) * 5));
            }
            lbl_TypePages.Text = iCurrentTypePage.ToString() + "/" + (iTotalTypePages - 1).ToString();
            BarCode_Get_Focus();
        }

        private void bt_OpenCashDrawer_Click(object sender, EventArgs e)
        {
            //SendStringToPrinter("EPSON-1", openTillCommand);
            RawPrinterHelper.SendStringToPrinter("EPSON-1", openTillCommand);
            BarCode_Get_Focus();
        }

        private void bt_OpenCashDrawer1_Click(object sender, EventArgs e)
        {
            //SendStringToPrinter("EPSON-1", openTillCommand);
            RawPrinterHelper.SendStringToPrinter("EPSON-1", openTillCommand);
            BarCode_Get_Focus();
        }

        private void bt_SaveOrder_Click(object sender, EventArgs e)
        {
            if (iNewInvNo != 0)
            {
                if (Process_Save_Order(iNewInvNo))
                {
                    Print_SavedOrders(iNewInvNo);
                    txtSelectedMenu.Text = "Order Save Completed !";
                    
                    util.Logger("Order Save Completed ! : Invoice# " + iNewInvNo.ToString());

                    Initialize_Local_Variables();
                    dgv_Orders_Initialize();
                    Load_Existing_Orders();
                    bt_Stop.PerformClick();
                }
                else
                {
                    txtSelectedMenu.Text = "Order Save failed ! : " + iNewInvNo.ToString();
                    util.Logger("Order Save failed !  : Invoice# " + iNewInvNo.ToString());
                }
            }
            else
            {
                txtSelectedMenu.Text = "No invoice was selected : " + iNewInvNo.ToString();
                util.Logger("No invoice was selected to save order  : Invoice# " + iNewInvNo.ToString());
            }
            BarCode_Get_Focus();
        }

        private void Print_SavedOrders(int iInvoiceNo)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            string strHeader = "header";
            string strFooter = "footer";
            string strContent = "1234567890123456789012345678901234567890";
            string strLine = "----------------------------------------";
            string strImageFile = "";
            float iSubTot = 0;
            float iTaxTot = 0;
            float iTotDue = 0;
            float fTax1Tot = 0, fTax2Tot = 0, fTax3Tot = 0;

            PrintDocument p = new PrintDocument();

            // Construct 2 new StringFormat objects
            StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
            StringFormat format2 = new StringFormat(format1);

            // Set the LineAlignment and Alignment properties for
            // both StringFormat objects to different values.
            format1.LineAlignment = StringAlignment.Near;
            format1.Alignment = StringAlignment.Center;
            format2.LineAlignment = StringAlignment.Center;
            format2.Alignment = StringAlignment.Near;

            p.PrinterSettings.PrinterName = "EPSON-1";
            Font fntTitle = new Font("Arial", 12, FontStyle.Bold);
            Font fntHeader = new Font("Courier New", 9);
            Font fntFooter = new Font("Courier New", 10, FontStyle.Bold);
            Font fntInvNoBarCode = new Font("IDAutomationHC39M", 12, FontStyle.Regular);
            Font fntContents = new Font("Courier New", 8);
            Font fntTotals = new Font("Courier New", 8, FontStyle.Bold);
            Font fntCard = new Font("Consolas", 8);
            SolidBrush brsBlack = new SolidBrush(Color.Black);

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                int iNextLineYPoint = 0;
                int iLogoHeight = 80;
                int itxtHeight = 12;
                int iheaderHeight = 14;
                int ititleHeight = 17;
                //////////////////////////////////////////////////////////////////////////
                // Print Logo ------------------------------------------------------
                strImageFile = dbPOS.Get_SysConfig_By_Name("RECEIPT_LOGO_IMAGE")[0].ConfigValue;
                if (strImageFile.Length > 0)
                {
                    Image logoImg = Image.FromFile(strImageFile);
                    Rectangle logoRect = new Rectangle(new Point(0, 0), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iLogoHeight));
                    //e1.Graphics.DrawRectangle(Pens.Black, logoRect);
                    e1.Graphics.DrawImage(logoImg, logoRect, new Rectangle(0, 0, logoImg.Width, logoImg.Height), GraphicsUnit.Pixel);
                }
                //////////////////////////////////////////////////////////////////////////
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iLogoHeight;
                Rectangle txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                //e1.Graphics.DrawRectangle(Pens.Black, txtRect);
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_TITLE")[0].ConfigValue, fntTitle, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + ititleHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_ADDR1")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_ADDR2")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_PHONE_NO")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_REG_NO")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                //////////////////////////////////////////////////////////////////////////
                // Print order header ------------------------------------------------------
                strContent = String.Format("{0,-17}", "Inv#: " + String.Format("{0}", System.Convert.ToInt32(iInvoiceNo))) +
                             String.Format("{0,20}", "Served by: " + strUserName);
                iNextLineYPoint = iNextLineYPoint + iheaderHeight + 5;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                strContent = String.Format("{0,-17}", "Station:" + strStation) +
                             String.Format("{0,20}", "# of Items:" + iPpleCount.ToString());
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                strContent = String.Format("{0,-17}", "Order Saved :" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);


                //////////////////////////////////////////////////////////////////////////
                // Print a Line ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + itxtHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);

                //////////////////////////////////////////////////////////////////////////
                // Print order header ------------------------------------------------------
                strContent = String.Format("{0,-20}", StringCentering("Item Desc", 20)) + String.Format("{0,5}", "QTY") +
                             String.Format("{0,7}", "Price") + String.Format("{0,8}", "Amount");
                iNextLineYPoint = iNextLineYPoint + itxtHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                //////////////////////////////////////////////////////////////////////////
                // Print a Line ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + itxtHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);

                List<POS_SavedOrdersModel> savedorderitems = new List<POS_SavedOrdersModel>();
                savedorderitems = dbPOS.Get_SavedOrders_by_InvoiceNo(iInvoiceNo);
                if (savedorderitems.Count > 0)
                {
                    ////////////////////////////////////////////////
                    // Add the ordered item into datagrid view
                    ////////////////////////////////////////////////
                    //iNewInvNo = orders[0].InvoiceNo;
                    foreach (var order in savedorderitems)
                    {
                        float iAmount = 0;
                        string strProd = "";

                        if (order.OrderCategoryId == 0)
                        {
                            iAmount = order.Quantity * order.OutUnitPrice;
                            iSubTot = iSubTot + iAmount;
                            iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                            
                            fTax1Tot = fTax1Tot + order.Tax1;
                            fTax2Tot = fTax2Tot + order.Tax2;
                            fTax3Tot = fTax3Tot + order.Tax3;

                            strProd = order.ProductName;

                            if (order.ProductName.Length > 20)
                            {
                                strProd = order.ProductName.Substring(0, 20);
                            }

                            strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                         String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));
                        }
                        else if (order.OrderCategoryId > 0) // Discount, Deposit
                        {
                            iAmount = order.Amount;
                            iSubTot = iSubTot + iAmount;
                            iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;

                            fTax1Tot = fTax1Tot + order.Tax1;
                            fTax2Tot = fTax2Tot + order.Tax2;
                            fTax3Tot = fTax3Tot + order.Tax3;

                            strProd = order.ProductName;

                            if (order.ProductName.Length > 20)
                            {
                                strProd = order.ProductName.Substring(0, 20);
                            }

                            strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                         String.Format("{0,7}", order.Amount.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                        }
                        //////////////////////////////////////////////////////////////////////////
                        // Print order ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + itxtHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        //e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                    }
                    iTotDue = iSubTot + iTaxTot;

                    //////////////////////////////////////////////////////////////////////////
                    // Print a Line ------------------------------------------------------
                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                    //////////////////////////////////////////////////////////////////////////
                    // Print a Line ------------------------------------------------------
                    strContent = String.Format("{0,25}", "Sub Total :") + String.Format("{0,15}", iSubTot.ToString("0.00"));
                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                    //////////////////////////////////////////////////////////////////////////
                    // Print a Line ------------------------------------------------------
                    strContent = String.Format("{0,25}", "Tax :") + String.Format("{0,15}", iTaxTot.ToString("0.00"));
                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                    if (m_blnPrintTaxDetails)
                    {
                        if (fTax1Tot > 0)
                        {
                            strContent = String.Format("{0,25}", strTax1Name + " :") + String.Format("{0,15}", fTax1Tot.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        }
                        if (fTax2Tot > 0)
                        {
                            strContent = String.Format("{0,25}", strTax2Name + " :") + String.Format("{0,15}", fTax2Tot.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        }
                        if (fTax3Tot > 0)
                        {
                            strContent = String.Format("{0,25}", strTax3Name + " :") + String.Format("{0,15}", fTax3Tot.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        }
                    }
                    //////////////////////////////////////////////////////////////////////////
                    // Print a Line ------------------------------------------------------
                    strContent = String.Format("{0,25}", "Total Due :") + String.Format("{0,15}", iTotDue.ToString("0.00"));
                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                    if (iPpleCount > 1)
                    {
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        float iPplDue = iTotDue / iPpleCount;
                        strContent = String.Format("{0,25}", "1/" + iPpleCount.ToString() + " Each :") + String.Format("{0,15}", iPplDue.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);

                    }
                    if (dbPOS.Get_SysConfig_By_Name("INVOICE_TIP_GUIDE")[0].ConfigValue == "True")
                    {
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        float iTip = iTotDue * (float)0.10;
                        strContent = String.Format("{0,25}", "10% Tip :") + String.Format("{0,15}", iTip.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iTip = iTotDue * (float)0.15;
                        strContent = String.Format("{0,25}", "15% Tip :") + String.Format("{0,15}", iTip.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iTip = iTotDue * (float)0.2;
                        strContent = String.Format("{0,25}", "20% Tip :") + String.Format("{0,15}", iTip.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                    }

                }


                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight ;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight * 2));
                e1.Graphics.DrawString("Please recall this order with Invoice No! #( " + iInvoiceNo.ToString() + " )", fntFooter, brsBlack, (RectangleF)txtRect, format1);

                // Print Barcode ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 4);
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight * 2));
                e1.Graphics.DrawString("*99999" + iInvoiceNo.ToString("0000000")+ "*", fntInvNoBarCode, brsBlack, (RectangleF)txtRect, format1);


            }; //if (IsInvoice)
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }

        private void bt_RecallOrder_Click(object sender, EventArgs e)
        {
            util.Logger("bt_RecallOrder_Click InvNo  :" + iNewInvNo.ToString());

            if (txtCount.Text == "0" | txtCount.Text=="")
            {
                using (var FrmRecallOrder = new frmRecallOrder(this))
                {
                    FrmRecallOrder.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                              (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                    FrmRecallOrder.ShowDialog();

                    if (FrmRecallOrder.bRecallNow)
                    {
                        int iRecallInvoiceNo = Convert.ToInt32(FrmRecallOrder.strInvoiceNo);
                        if (Process_Recall_Saved_Order(iRecallInvoiceNo))
                        {
                            Initialize_Local_Variables();
                            dgv_Orders_Initialize();
                            Load_Existing_Orders();
                            bt_Stop.PerformClick();
                            pnlReceipt.Visible = false;
                            iNewInvNo = iRecallInvoiceNo;
                            txtSelectedMenu.Text = "Recall order successed ! " + iRecallInvoiceNo.ToString();
                            util.Logger("Recall order successed ! iRecallInvoiceNo = " + iRecallInvoiceNo.ToString());
                        }
                        else
                        {
                            txtSelectedMenu.Text = "Recall order not exist ! " + iRecallInvoiceNo.ToString();
                            util.Logger("Recall order not exist : failed ! iRecallInvoiceNo = " + iRecallInvoiceNo.ToString());
                        }
                    }
                    else
                    {
                        txtSelectedMenu.Text = "Recall canceled ! ";
                        util.Logger("Recall canceled ! " + FrmRecallOrder.strInvoiceNo);
                    }

                }
            }
            else
            {
                txtSelectedMenu.Text = "Please proceed the on going order first !";
            }
            BarCode_Get_Focus();
        }
        // Amount Discount
        private void bt_SetDiscount_Click(object sender, EventArgs e)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            List<POS_OrdersModel> orders = new List<POS_OrdersModel>();
            orders = dbPOS.Get_Orders_by_InvoiceNo(iNewInvNo);
            if (orders.Count > 0)
            {
                if (orders.Find(x => x.IsDiscounted == true) != null)
                {
                    // Already discounted order
                    txtSelectedMenu.Text = "One or more item(s) is(are) already discounted !";
                    Console.Beep(9000, 1000);
                    BarCode_Get_Focus();
                    return;
                }
            }

            Double dblDueAmount = dbPOS.Get_Total_Due_Amount(iNewInvNo);

            if (Add_Discount_Orders_Item(0, true, "Total D/C(", dblDueAmount,0))
            {
                txtSelectedMenu.Text = "Total Discount added !";
            }
            BarCode_Get_Focus();
        }
        // Selected Item Discount
        private void bt_SetItemDiscount_Click(object sender, EventArgs e)
        {
            if (dgv_Orders.Rows.Count > 0)
            {
                int iRowCount = dgv_Orders.Rows.Count;
                //for (int i = 0; i < iRowCount; iRowCount++)
                foreach (DataGridViewRow row in dgv_Orders.Rows)
                {
                    if (row.Selected)
                    {
                        //int iSelectedProdId = System.Convert.ToInt32(row.Cells[0].Value.ToString());
                        //int iSelectedOrderId = System.Convert.ToInt32(row.Cells[5].Value.ToString());
                        int iSelectedProdId = System.Convert.ToInt32(row.Cells[7].Value.ToString());
                        int iSelectedOrderId = System.Convert.ToInt32(row.Cells[6].Value.ToString());

                        DataAccessPOS dbPOS = new DataAccessPOS();
                        List<POS_OrdersModel> orders = new List<POS_OrdersModel>();
                        orders = dbPOS.Get_Order_By_OrderId(iSelectedOrderId);
                        if (orders.Count > 0)
                        {
                            if (orders[0].IsDiscounted)
                            {
                                // Already discounted order
                                txtSelectedMenu.Text = "The Selected Item : " + orders[0].ProductName + " is already discounted !";
                                Console.Beep(9000, 1000);
                                BarCode_Get_Focus();
                                return;
                            }
                        }
                        Double dblDueAmount = dbPOS.Get_Order_Amount_By_OrderId(iNewInvNo, iSelectedOrderId);

                        //if (Add_Discount_Orders_Item(false, iSelectedOrderId.ToString() + " (", dblDueAmount, iSelectedOrderId))
                        if (Add_Discount_Orders_Item(row.Index, false, "-D/C:" + row.Cells[1].Value.ToString() + " (", dblDueAmount, iSelectedOrderId))
                        {
                            txtSelectedMenu.Text = "Item Discount added !";
                        }
                        BarCode_Get_Focus();
                        return;
                    }
                }
            }
            BarCode_Get_Focus();
        }

        private bool Add_Discount_Orders_Item(int iSelectedRow, bool bIsTotalDiscount, string strDescription, Double dblDueAmount, int iOrderId)
        {
            int iSeq = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();

            double iTotalAmount = 0;
            double iTotalTax1 = 0;
            double iTotalTax2 = 0;
            double iTotalTax3 = 0;

            util.Logger("Add_Discount_Orders_Item ! InvNo  :" + iNewInvNo.ToString() + " Order Id : " + iOrderId.ToString());

            pnlReceipt.Visible = false;

            if (bIsTotalDiscount)
            {
                iTotalAmount = dbPOS.Get_Total_Amount(iNewInvNo);
                iTotalTax1 = dbPOS.Get_Total_Tax1(iNewInvNo);
                iTotalTax2 = dbPOS.Get_Total_Tax2(iNewInvNo);
                iTotalTax3 = dbPOS.Get_Total_Tax3(iNewInvNo);
            }
            else
            {
                iTotalAmount = dbPOS.Get_Orders_Amount(iOrderId);
                iTotalTax1 = dbPOS.Get_Orders_Tax1(iOrderId);
                iTotalTax2 = dbPOS.Get_Orders_Tax2(iOrderId);
                iTotalTax3 = dbPOS.Get_Orders_Tax3(iOrderId);
            }


            using (var FrmDiscount = new frmDiscount(this))
            {
                FrmDiscount.Set_Amount(dblDueAmount);
                FrmDiscount.ShowDialog();

                double iDiscountRate = FrmDiscount.iDiscountRate;
                //Feature #2604
                float fDiscountAmount = FrmDiscount.fAmountDisc * -1;
                //Feature #2604
                if ((iDiscountRate > 0 && iDiscountRate <= 100) || (fDiscountAmount < 0))
                {
                    orders.Clear();
                    //Feature #2604 ---------------------------
                    float fNewAmount = 0;
                    float fTax1 = 0;
                    float fTax2 = 0;
                    float fTax3 = 0;
                    if (fDiscountAmount < 0)
                    {
                        strDescription = strDescription + "$" + fDiscountAmount.ToString() + ")";
                        fNewAmount = fDiscountAmount;
                        fTax1 = (float)(-iTotalTax1 * ((fDiscountAmount * -1) / iTotalAmount));
                        fTax2 = (float)(-iTotalTax2 * ((fDiscountAmount * -1) / iTotalAmount));
                        fTax3 = (float)(-iTotalTax3 * ((fDiscountAmount * -1) / iTotalAmount));
                    }
                    else if (iDiscountRate > 0)
                    {
                        strDescription = strDescription + iDiscountRate.ToString() + "%)";
                        fNewAmount = (float)(-iTotalAmount * (iDiscountRate / 100));
                        fTax1 = (float)(-iTotalTax1 * (iDiscountRate / 100));
                        fTax2 = (float)(-iTotalTax2 * (iDiscountRate / 100));
                        fTax3 = (float)(-iTotalTax3 * (iDiscountRate / 100));
                    }
                    else
                    {
                        BarCode_Get_Focus();
                        return false;
                    }
                    
                    ////////////////////////////////////////////////
                    // Add the ordered item into Orders table
                    ////////////////////////////////////////////////
                    orders.Add(new POS_OrdersModel()
                    {
                        TranType = "20",
                        ProductId = 0,
                        ProductName = strDescription,
                        SecondName = strDescription,
                        ProductTypeId = 0,
                        InUnitPrice = 0,
                        OutUnitPrice = 0,
                        IsTax1 = false,
                        IsTax2 = false,
                        IsTax3 = false,
                        Quantity = 1,
                        Amount = fNewAmount,
                        Tax1Rate = m_TaxRate1,
                        Tax2Rate = m_TaxRate2,
                        Tax3Rate = m_TaxRate3,
                        Tax1 = fTax1,
                        Tax2 = fTax2,
                        Tax3 = fTax3,
                        InvoiceNo = iNewInvNo,
                        IsPaidComplete = false,
                        CompleteDate = "",
                        CompleteTime = "",
                        CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), //DateTime.Now.ToShortDateString(),
                        CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                        CreateUserId = System.Convert.ToInt32(strUserID),
                        CreateUserName = strUserName,
                        CreateStation = strStation,
                        LastModDate = "",
                        LastModTime = "",
                        LastModUserId = System.Convert.ToInt32(strUserID),
                        LastModUserName = "",
                        LastModStation = "",
                        RFTagId = 0,
                        ParentId = iOrderId,
                        OrderCategoryId = 4,     // Discount
                        BarCode = ""
                    });
                    //Feature #2604 ---------------------------
                    int iNewOrderId = dbPOS.Insert_Order(orders[0]);
                    util.Logger(" ## _Discount_Orders_Item : " + orders[0].Id.ToString() + ", PROD=" + orders[0].ProductName + ", New Amount = " + orders[0].Amount.ToString());
                    if (iNewOrderId > 0)
                    {
                        ////////////////////////////////////////////////
                        // Add the ordered item into datagrid view
                        ////////////////////////////////////////////////
                        float iAmount = orders[0].Amount;
                        iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                        /* if (iSelectedRow > 0)
                         {*/

                        this.dgv_Orders.Rows.Insert(iSelectedRow, new String[] { iSeq.ToString(),
                                                                               orders[0].ProductName,
                                                                               "1",
                                                                               orders[0].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               "",
                                                                               iNewOrderId.ToString(),
                                                                               prods[0].Id.ToString(),
                                                                               prods[0].BarCode
                            });
                     /*   }
                        else
                        {
                            this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                       orders[0].ProductName,
                                                       "1",
                                                       orders[0].OutUnitPrice.ToString("0.00"),
                                                       iAmount.ToString("0.00"),
                                                       iNewOrderId.ToString(),
                                                       prods[0].Id.ToString(),
                                                       prods[0].BarCode
                            });
                            this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = 0;
                            DataGridViewRow row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                            row.DefaultCellStyle.ForeColor = Color.Red;
                        }*/
                        //this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView_By_RFTagID(rfids[0].Id);

                        // Set IsDiscounted = true for the order
                        bool bIsUpdated = dbPOS.Update_Order_IsDiscounted(iNewInvNo, iOrderId, true);
                    }

                    dgv_Orders_Initialize();
                    Load_Existing_Orders();
                    Calculate_Total_Due();
                }
            }
            BarCode_Get_Focus();
            return true;
        }
        private bool Add_Amount_Discount_Orders_Item(string strDescription, Double dblAmount)
        {
            int iSeq = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();

            double iTotalAmount = dblAmount;
            double iTotalTax1 = 0;
            double iTotalTax2 = 0;
            double iTotalTax3 = 0;

            orders.Clear();

            pnlReceipt.Visible = false;

            if (iNewInvNo == 0)
            {
                return false;
            }

            util.Logger("Add_Amount_Discount_Orders_Item ! InvNo  :" + iNewInvNo.ToString());
            ////////////////////////////////////////////////
            // Add the ordered item into Orders table
            ////////////////////////////////////////////////
            orders.Add(new POS_OrdersModel()
            {
                TranType = "20",
                ProductId = 0,
                ProductName = strDescription,
                SecondName = strDescription,
                ProductTypeId = 0,
                InUnitPrice = 0,
                OutUnitPrice = 0,
                IsTax1 = false,
                IsTax2 = false,
                IsTax3 = false,
                Quantity = 1,
                Amount = (float)(-dblAmount),
                Tax1Rate = m_TaxRate1,
                Tax2Rate = m_TaxRate2,
                Tax3Rate = m_TaxRate3,
                Tax1 = (float)(-dblAmount * m_TaxRate1),
                Tax2 = 0, // (float)(-iTotalTax2 * (iDiscountRate / 100)),
                Tax3 = 0, // (float)(-iTotalTax3 * (iDiscountRate / 100)),
                InvoiceNo = iNewInvNo,
                IsPaidComplete = false,
                CompleteDate = "",
                CompleteTime = "",
                CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), //DateTime.Now.ToShortDateString(),
                CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                CreateUserId = System.Convert.ToInt32(strUserID),
                CreateUserName = strUserName,
                CreateStation = strStation,
                LastModDate = "",
                LastModTime = "",
                LastModUserId = System.Convert.ToInt32(strUserID),
                LastModUserName = "",
                LastModStation = "",
                RFTagId = 0,
                ParentId = 0,
                OrderCategoryId = 4,     // Discount
                BarCode = ""
            });
            int iNewOrderId = dbPOS.Insert_Order(orders[0]);
            util.Logger(" ## Discount : " + orders[0].Id.ToString() + ", PRODID=" + orders[0].ProductId + ", Discount Amount = " + orders[0].Amount.ToString("C2"));
            if (iNewOrderId > 0)
            {
                ////////////////////////////////////////////////
                // Add the ordered item into datagrid view
                ////////////////////////////////////////////////
                float iAmount = orders[0].Amount;
                iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                       orders[0].ProductName,
                                                                       "1",
                                                                       orders[0].OutUnitPrice.ToString("0.00"),
                                                                       iAmount.ToString("0.00"),
                                                                       "",
                                                                       iNewOrderId.ToString(),
                                                                       prods[0].Id.ToString(),
                                                                       prods[0].BarCode,
                    });
                this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = 0;
                DataGridViewRow row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                row.DefaultCellStyle.ForeColor = Color.Red;
                //this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView_By_RFTagID(rfids[0].Id);
            }

            dgv_Orders_Initialize();
            Load_Existing_Orders();
            Calculate_Total_Due();
            BarCode_Get_Focus();
            return true;
        }

        private void bt_SetIOneDollarDiscount_Click(object sender, EventArgs e)
        {
            Add_Amount_Discount_Orders_Item("$1 Discount", 1);
            BarCode_Get_Focus();
        }

        private void bt_EditPrice_Click(object sender, EventArgs e)
        {
            if (dgv_Orders.Rows.Count > 0)
            {
                int iRowCount = dgv_Orders.Rows.Count;
                //for (int i = 0; i < iRowCount; iRowCount++)
                foreach (DataGridViewRow row in dgv_Orders.Rows)
                {
                    if (row.Selected)
                    {
                        int iSelectedProdId = System.Convert.ToInt32(row.Cells[7].Value.ToString());
                        int iSelectedOrderId = System.Convert.ToInt32(row.Cells[6].Value.ToString());

                        DataAccessPOS dbPOS = new DataAccessPOS();
                        Double dblDueAmount = dbPOS.Get_Order_Amount_By_OrderId(iNewInvNo, iSelectedOrderId);

                        if (Edit_Order_Price(dblDueAmount, iSelectedOrderId, iSelectedProdId))
                        {
                            txtSelectedMenu.Text = "Item Edit Completed !";
                            dgv_Orders_Initialize();
                            Load_Existing_Orders();
                            Calculate_Total_Due();
                        }
                        return;
                    }
                }
            }
            BarCode_Get_Focus();

        }

        private bool Edit_Order_Price(double dblDueAmount, int iSelectedOrderId, int iSelectedProdId)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            List<POS_ProductModel>  prods = new List<POS_ProductModel>();
            using (var FrmEditOrderPrice = new frmEditOrderPrice(this))
            {
                prods = dbPOS.Get_Product_By_ID(iSelectedProdId);
                if (prods.Count > 0)
                {
                    FrmEditOrderPrice.Set_ProductName(prods[0].ProductName);
                    FrmEditOrderPrice.Set_Amount(dblDueAmount);
                    FrmEditOrderPrice.p_IsTax1 = prods[0].IsTax1;
                    FrmEditOrderPrice.p_IsTax2 = prods[0].IsTax2;
                    FrmEditOrderPrice.p_IsTax3 = prods[0].IsTax3;
                }
                FrmEditOrderPrice.ShowDialog();

                double dblNewAmount = FrmEditOrderPrice.dblNewAmount;
                bool bManualTax1 = FrmEditOrderPrice.bTax1;
                bool bManualTax2 = FrmEditOrderPrice.bTax2;
                bool bManualTax3 = FrmEditOrderPrice.bTax3;

                if (dblNewAmount > 0)
                {
                    orders.Clear();
                    //orders = dbPOS.Get_Order_By_ProdId(iNewInvNo, rfids[0].ProductId);
                    orders = dbPOS.Get_Order_By_OrderId(iSelectedOrderId);
                    if (orders.Count == 1)
                    {
                        orders[0].Amount = (float)dblNewAmount;
                        if (bManualTax1)
                        {
                            orders[0].Tax1 = (float)(dblNewAmount * orders[0].Tax1Rate);
                        }
                        else
                        {
                            orders[0].Tax1 = 0;
                        }
                        if (bManualTax2)
                        {
                            orders[0].Tax2 = (float)(dblNewAmount * orders[0].Tax2Rate);
                        }
                        else
                        {
                            orders[0].Tax2 = 0;
                        }
                        if (bManualTax3)
                        {
                            if (m_bIsTax3IncTax1)
                                orders[0].Tax3 = (float)((dblNewAmount + orders[0].Tax1) * orders[0].Tax3Rate);
                            else
                                orders[0].Tax3 = (float)(dblNewAmount * orders[0].Tax3Rate);
                        }
                        else
                        {
                            orders[0].Tax3 = 0;
                        }
                        orders[0].IsTax1 = bManualTax1;
                        orders[0].IsTax2 = bManualTax2;
                        orders[0].IsTax3 = bManualTax3;
                        // Update Tax column of selected dgv_orders row

                        dbPOS.Update_Orders_Amount_Qty(orders[0]);
                        util.Logger(" ## Edit Price : " + orders[0].Id.ToString() + ", PRODID=" + orders[0].ProductId + ", New Amount = " + dblNewAmount.ToString());
                        Calculate_Total_Due();
                    }
                }
            }
            BarCode_Get_Focus();
            return true;
        }

        private void bt_SetITwoDollarDiscount_Click(object sender, EventArgs e)
        {
            Add_Amount_Discount_Orders_Item("$2 Discount", 2);
            BarCode_Get_Focus();
        }

        private void bt_SetIThreeDollarDiscount_Click(object sender, EventArgs e)
        {
            Add_Amount_Discount_Orders_Item("$3 Discount", 3);
            BarCode_Get_Focus();
        }

        private void bt_ManualPrice_Click(object sender, EventArgs e)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            int iManualProdId = dbPOS.Get_ProductId_By_ProdName("Manual Item");
            if (iManualProdId > 0)
            {
                Add_Order_ManualItem(iManualProdId);
            }
            else
            {
                MessageBox.Show("Manual Item is not registered! Please add first!");
            }
            BarCode_Get_Focus();
        }

        private bool Add_Order_ManualItem(int pProdID)
        {
            string strTaxShort = "";
            string strManualName = "";
            double dblManualPrice = 0;
            double dblBarCodeAmount = 0;
            bool bManualTax1 = false;
            bool bManualTax2 = false;
            bool bManualTax3 = false;
            int iSeq = 0;
            int iOrderQty = 1;
            float fTax1, fTax2, fTax3 = 0;

            pnlReceipt.Visible = false;

            if ((txtQTY.Text != "") && (txtQTY.Text != "0"))
            {
                try
                {
                    iOrderQty = Int32.Parse(txtQTY.Text);
                }
                catch
                {
                    iOrderQty = 1;
                }
                txtQTY.Text = "";
            }
            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();


            util.Logger("Add_Order_ManualItem ! InvNo  :" + iNewInvNo.ToString() + ", ProdId = " + pProdID.ToString());

            if (!isNewInvoice)   // Set when start button is pressed
            {
                iNewInvNo = dbPOS1.Get_New_InvoiceNo();
                int iSavedOrderInvNo = dbPOS.Get_SavedOrders_NextInvoiceNo();

                if (iNewInvNo < iSavedOrderInvNo)
                {
                    iNewInvNo = iSavedOrderInvNo;
                }
                util.Logger(" Add_Order_Manually Get_New_InvoiceNo : InvoiceNo = " + iNewInvNo.ToString());
                isNewInvoice = true;
            }

            List<POS_ProductModel> prods = new List<POS_ProductModel>();
            prods = dbPOS.Get_Product_By_ID(pProdID);

            try
            {
                dblBarCodeAmount = Convert.ToInt32(txtBarCode.Text);
            }
            catch
            {
                dblBarCodeAmount = 0;
            }

            if (dblBarCodeAmount > 0)
            {
                dblManualPrice = dblBarCodeAmount / 100;
                if (prods.Count > 0)
                {
                    strManualName = prods[0].ProductName;
                    bManualTax1 = prods[0].IsTax1;
                    bManualTax2 = prods[0].IsTax2;
                    bManualTax3 = prods[0].IsTax3;
                }
            }
            else
            {
                using (var FrmManualPrice = new frmManualPrice(this))
                {
                    if (prods.Count > 0)
                    {
                        //FrmManualPrice.Set_ProductName(dbPOS.Get_ProductName_By_Id(pProdID));
                        FrmManualPrice.Set_ProductName(prods[0].ProductName);
                        FrmManualPrice.Set_Amount(0);

                        FrmManualPrice.p_IsTax1 = prods[0].IsTax1;
                        FrmManualPrice.p_IsTax2 = prods[0].IsTax2;
                        FrmManualPrice.p_IsTax3 = prods[0].IsTax3;
                    }

                    FrmManualPrice.ShowDialog();

                    strManualName = FrmManualPrice.strManualName;
                    dblManualPrice = FrmManualPrice.dblManualPrice;
                    bManualTax1 = FrmManualPrice.bTax1;
                    bManualTax2 = FrmManualPrice.bTax2;
                    bManualTax3 = FrmManualPrice.bTax3;
                }
            }

            if (dblManualPrice > 0)
            {
                ////////////////////////////////////////////////
                // Add the ordered item into Orders table
                ////////////////////////////////////////////////

                orders.Clear();

                // Payout
                if (prods[0].CategoryId == 2)
                    dblManualPrice = dblManualPrice * -1;

                if (prods[0].TaxCode != null)
                {
                    if (prods[0].TaxCode != "")
                    {
                        SetTaxRates(prods[0].TaxCode);
                    }
                    else
                    {
                        SetTaxRates(m_strDefaultTaxCode);
                    }
                }
                else
                {
                    SetTaxRates(m_strDefaultTaxCode);
                }
                // Tax Calculation
                fTax1 = bManualTax1 ? m_TaxRate1 * (float)(dblManualPrice * iOrderQty) : 0;
                fTax2 = bManualTax2 ? m_TaxRate2 * (float)(dblManualPrice * iOrderQty) : 0;
                if (m_bIsTax3IncTax1)
                    fTax3 = bManualTax3 ? m_TaxRate3 * (float)((dblManualPrice + fTax1) * iOrderQty) : 0;
                else
                    fTax3 = bManualTax3 ? m_TaxRate3 * (float)(dblManualPrice * iOrderQty) : 0;
                orders.Add(new POS_OrdersModel()
                {
                    TranType = "20",
                    ProductId = pProdID,
                    ProductName = strManualName,
                    SecondName = strManualName,
                    ProductTypeId = prods[0].ProductTypeId,
                    InUnitPrice = 0,
                    OutUnitPrice = (float)dblManualPrice,
                    IsTax1 = bManualTax1,
                    IsTax2 = bManualTax2,
                    IsTax3 = bManualTax3,
                    Quantity = iOrderQty,
                    Amount = (float)dblManualPrice * iOrderQty,
                    Tax1Rate = m_TaxRate1,
                    Tax2Rate = m_TaxRate2,
                    Tax3Rate = m_TaxRate3,
                    Tax1 = fTax1,
                    Tax2 = fTax2,
                    Tax3 = fTax3,
                    Deposit = 0,
                    RecyclingFee = 0,
                    ChillCharge = 0,
                    IsManualPrice = prods[0].IsManualItem,
                    InvoiceNo = iNewInvNo,
                    IsPaidComplete = false,
                    CompleteDate = "",
                    CompleteTime = "",
                    CreateDate = DateTime.Now.ToString("yyyy-MM-dd"), // DateTime.Now.ToShortDateString(),
                    CreateTime = DateTime.Now.ToString("HH:mm:ss"), //DateTime.Now.ToShortTimeString(),
                    CreateUserId = System.Convert.ToInt32(strUserID),
                    CreateUserName = strUserName,
                    CreateStation = strStation,
                    LastModDate = "",
                    LastModTime = "",
                    LastModUserId = System.Convert.ToInt32(strUserID),
                    LastModUserName = "",
                    LastModStation = "",
                    RFTagId = 0,
                    ParentId = 0,
                    OrderCategoryId = 0,
                    IsDiscounted = false,
                    BarCode = ""
                });
                //if (dbPOS.Insert_Order(orders[0]))
                int iNewOrderId = dbPOS.Insert_Order(orders[0]);
                if (iNewOrderId > 0)
                {
                    ////////////////////////////////////////////////
                    // Add the ordered item into datagrid view
                    ////////////////////////////////////////////////
                    float iAmount = orders[0].Quantity * orders[0].OutUnitPrice;
                    iSeq = dbPOS.Get_Orders_Count_by_InvoiceNo(iNewInvNo);
                    strTaxShort += orders[0].IsTax1 ? strTax1Name.Substring(0, 1) : "";
                    strTaxShort += orders[0].IsTax2 ? strTax2Name.Substring(0, 1) : "";
                    strTaxShort += orders[0].IsTax3 ? strTax3Name.Substring(0, 1) : "";
                    this.dgv_Orders.Rows.Add(new String[] { iSeq.ToString(),
                                                                               strManualName,
                                                                               orders[0].Quantity.ToString("0"),
                                                                               orders[0].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               strTaxShort,
                                                                               iNewOrderId.ToString(),
                                                                               orders[0].ProductId.ToString(),
                                                                               orders[0].BarCode
                            });
                    this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView_By_ProdID(pProdID);
                    this.dgv_Orders.Rows[Get_OrderedItem_Index_of_GridView_By_ProdID(pProdID)].Selected = true;

                }
                else
                {
                    //Error insert order
                    util.Logger("Error insert order : InvNo = " + iNewInvNo.ToString() + ", ProdId = " + pProdID);
                    MessageBox.Show("Error insert order : InvNo = " + iNewInvNo.ToString() + ", ProdId = " + pProdID);
                    return false;
                }
            }
            // clear txtBarCode
            txtBarCode.Text = "";

            Check_Assorted_Promotions();
            Calculate_Total_Due();
            BarCode_Get_Focus();
            return true;

        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //util.Logger($"txtBarCode_KeyPress: '{e.KeyChar}' pressed.");
            
            lblBarCode.ForeColor = Color.FromArgb(rdm.Next(0, 256),rdm.Next(0, 256), rdm.Next(0, 256));
            lblBarCode2.ForeColor = Color.FromArgb(rdm.Next(0, 256), rdm.Next(0, 256), rdm.Next(0, 256));

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                strBarCode = strBarCode + (char)e.KeyChar;
                //util.Logger($"Barcode = '{strBarCode}'");
            }
            if (e.KeyChar == 13)
            {
                strBarCode = txtBarCode.Text;
                util.Logger($" ====> Complete Barcode = '{strBarCode}'");
                if (strBarCode.Length > 5)
                {
                    if (strBarCode.Substring(0, 5) == "99999")
                    {
                        int iRecallInvoiceNo = Convert.ToInt32(strBarCode.Substring(5, 7));
                        if (Process_Recall_Saved_Order(iRecallInvoiceNo))
                        {
                            Initialize_Local_Variables();
                            dgv_Orders_Initialize();
                            Load_Existing_Orders();
                            bt_Stop.PerformClick();
                            pnlReceipt.Visible = false;
                            iNewInvNo = iRecallInvoiceNo;
                            txtSelectedMenu.Text = "Recall order successed ! " + iRecallInvoiceNo.ToString();
                            util.Logger("Recall order successed ! iRecallInvoiceNo = " + iRecallInvoiceNo.ToString());
                        }
                        else
                        {
                            txtSelectedMenu.Text = "Recall order not exist ! " + iRecallInvoiceNo.ToString();
                            util.Logger("Recall order not exist : failed ! iRecallInvoiceNo = " + iRecallInvoiceNo.ToString());
                        }
                        txtBarCode.Text = string.Empty;
                        strBarCode = string.Empty;
                        return;
                    }
                }
                if (Add_Order_BarCode(strBarCode) == true)
                {
                    txtBarCode.Text = string.Empty;
                    strBarCode = string.Empty;
                }
                else
                {
                    strBarCode = string.Empty;
                }
            }
            BarCode_Get_Focus();
        }

        private void frmSalesMain_Shown(object sender, EventArgs e)
        {
            txtBarCode.Focus();
        }

        private void bt_cashPayment_Click(object sender, EventArgs e)
        {
            txtSelectedMenu.Text = "Cash Payment is selected : Invoice# " + iNewInvNo.ToString();
            util.Logger(txtSelectedMenu.Text);
            if (fTotDue == 0)
            {
                txtSelectedMenu.Text = "Check your due amount ! " + fTotDue.ToString("C2");
                return;
            }
            using (var FrmCashPay = new frmCashPayment(this))
            {
                //FrmCashPay.Set_TenderAmt(Convert.ToDouble(txt_TotalDue.Text.Replace("$", "")));
                FrmCashPay.Set_TenderAmt(iTotalDue);
                FrmCashPay.Set_InvoiceNo(iNewInvNo);
                FrmCashPay.Set_Station(strStation);
                FrmCashPay.Set_UserName(strUserName);
                //FrmCashPay.p_CashAmt = m_fCashDue;
                FrmCashPay.ShowDialog();

                if (FrmCashPay.bPaymentComplete)
                {
                    util.Logger("Cash/Manual Payment completed !" + FrmCashPay.strPaymentType);
                    // if rounding is not zero, add to Orders table 
                    if (FrmCashPay.strPaymentType == "CASH")
                    {
                        if (FrmCashPay.m_fCashRounding != 0)
                        {
                            Process_Rounding_Tran(iNewInvNo, FrmCashPay.m_fCashRounding);
                        }
                    }
                    // Move Orders to OrderComplete
                    Process_Order_Complete(iNewInvNo);
                    // Add collection table
                    Process_Tran_Collection(iNewInvNo, FrmCashPay.p_CashAmt,
                                                        FrmCashPay.p_DebitAmt,
                                                        FrmCashPay.p_VisaAmt,
                                                        FrmCashPay.p_MasterAmt,
                                                        FrmCashPay.p_AmexAmt,
                                                        FrmCashPay.p_OthersAmt,
                                                        FrmCashPay.p_ChequeAmt,
                                                        FrmCashPay.p_ChargeAmt,
                                                        FrmCashPay.p_ChangeAmt, 
                                                        FrmCashPay.p_TipAmt,
                                                        FrmCashPay.m_fCashRounding,
                                                        FrmCashPay.strPaymentType, false);
                    Process_Receipt(false, false);

                    util.Logger("--------------- Cash Payment & Printing Receipt is Done : Invoice# " + iNewInvNo.ToString());
                    txtSelectedMenu.Text = "Payment & Printing Receipt is Done : Invoice# " + iNewInvNo.ToString();

                    Initialize_Local_Variables();
                    dgv_Orders_Initialize();
                    Load_Existing_Orders();
                    bt_Stop.PerformClick();
                }
                else
                {
                    txtSelectedMenu.Text = "Payment is not yet completed : Invoice# " + iNewInvNo.ToString();
                    util.Logger("Payment is not done yet!");
                    //Bug #1554
                    bCashPayment = false;
                }
            }
            BarCode_Get_Focus();
        }



        private void bt_AutoReceipt_Click(object sender, EventArgs e)
        {
            Check_AutoReceipt(true);
            Show_AutoReceipt_Button();
            BarCode_Get_Focus();
        }

        private void Show_AutoReceipt_Button()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            sysConfs.Clear();
            sysConfs = dbPOS.Get_SysConfig_By_Name("IS_AUTO_RECEIPT_PRINT"); //"COM1";
            if (sysConfs.Count == 0)
            {
                sysConfs.Clear();
                sysConfs.Add(new POS_SysConfigModel()
                {
                    //Id = int.Parse(txt_ConfigID.Text),
                    ConfigName = "IS_AUTO_RECEIPT_PRINT",
                    ConfigValue = "FALSE",
                    ConfigDesc = "",
                    IsActive = true
                });
                int isysConfigCnt = dbPOS.Insert_SysConfig(sysConfs[0]);
                bAutoReceipt = false;
            }
            else
            {
                if (sysConfs[0].ConfigValue == "TRUE")
                {
                    bAutoReceipt = true;
                }
                else
                {
                    bAutoReceipt = false;
                }
            }
            bt_AutoReceipt.Text = "Print" + System.Environment.NewLine + "Receipt";
            bt_AutoReceipt.TextAlign = ContentAlignment.MiddleRight;
            if (bAutoReceipt)
            {
                bt_AutoReceipt.BackColor = Color.Green;
                bt_AutoReceipt.ForeColor = Color.Black;
                bt_AutoReceipt.ImageList = m_ImageList;
                bt_AutoReceipt.ImageIndex = 2;
                bt_AutoReceipt.ImageAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                bt_AutoReceipt.BackColor = Color.DarkRed;
                bt_AutoReceipt.ForeColor = Color.LightGray;
                bt_AutoReceipt.ImageList = m_ImageList;
                bt_AutoReceipt.ImageIndex = 3;
                bt_AutoReceipt.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void Check_AutoReceipt(bool p_IsUpdate)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            sysConfs.Clear();
            sysConfs = dbPOS.Get_SysConfig_By_Name("IS_AUTO_RECEIPT_PRINT"); //"COM1";
            if (sysConfs.Count == 0)
            {
                sysConfs.Clear();
                sysConfs.Add(new POS_SysConfigModel()
                {
                    //Id = int.Parse(txt_ConfigID.Text),
                    ConfigName = "IS_AUTO_RECEIPT_PRINT",
                    ConfigValue = "FALSE",
                    ConfigDesc = "",
                    IsActive = true
                });
                int isysConfigCnt = dbPOS.Insert_SysConfig(sysConfs[0]);
                bAutoReceipt = false;
            }
            else
            {
                if (sysConfs[0].ConfigValue == "TRUE")
                {
                    if (p_IsUpdate)
                    {
                        sysConfs[0].ConfigValue = "FALSE";
                        bAutoReceipt = false;
                    }
                    else
                        bAutoReceipt = true;
                }
                else
                {
                    if (p_IsUpdate)
                    {
                        sysConfs[0].ConfigValue = "TRUE";
                        bAutoReceipt = true;
                    }
                    else
                        bAutoReceipt = false;
                }
                if (p_IsUpdate)
                    dbPOS.Update_SysConfig(sysConfs[0]);
            }
        }

        private void timerExtendBar_Tick(object sender, EventArgs e)
        {
            pnlSideBar.Hide();
            timerExtendBar.Enabled = false;
            BarCode_Get_Focus();
        }

        private int Get_OrderedItem_Index_of_GridView_By_OrderId(int orderId)
        {
            int rowIndex = 0;
            if (dgv_Orders.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv_Orders.Rows)
                {
                    if (row.Cells[6].Value != null)
                    {
                        row.Selected = false;
                        if (row.Cells[6].Value.ToString() == orderId.ToString() && row.Tag == null)
                        {
                            row.Selected = true;
                            this.dgv_Orders.FirstDisplayedScrollingRowIndex = row.Index;
                            rowIndex = row.Index;
                            //return rowIndex;
                        }
                    }
                }
            }
            return rowIndex;
        }

        private void bt_Plus_Click(object sender, EventArgs e)
        {
            bool bQTYPromotionProduct = false;
            float fTax1, fTax2, fTax3 = 0;

            DataAccessPOS dbPOS = new DataAccessPOS();
            if (dgv_Orders.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv_Orders.Rows)
                {

                    if (row.Selected)
                    {
                        int iSelectedProdId = System.Convert.ToInt32(row.Cells[7].Value.ToString()); // Cells[7] product id

                        // Set QTY for only Non-RFID Tag prod items
                        orders.Clear();
                        orders = dbPOS.Get_NonRFID_Order_By_ProdId(iNewInvNo, iSelectedProdId);
                        if (orders.Count == 1)
                        {
                            prods.Clear();
                            prods = dbPOS.Get_Product_By_ID(orders[0].ProductId);

                            orders[0].Quantity = orders[0].Quantity + 1;

                            if ((prods.Count > 0) && (orders[0].IsManualPrice != true))
                            {
                                bQTYPromotionProduct = Check_QTY_Promotion_Product(prods[0], orders[0].Quantity);
                                if (bQTYPromotionProduct)
                                {
                                    prods[0].OutUnitPrice = prods[0].PromoPrice1;
                                    orders[0].OutUnitPrice = prods[0].PromoPrice1;
                                }
                                else
                                {
                                    orders[0].OutUnitPrice = prods[0].OutUnitPrice;
                                }
                            }
                            // update datagrid veiw
                            row.Cells[2].Value = orders[0].Quantity.ToString();
                            float iAmount = orders[0].Quantity * orders[0].OutUnitPrice;
                            row.Cells[3].Value = orders[0].OutUnitPrice.ToString("0.00");
                            row.Cells[4].Value = iAmount.ToString("0.00");
                            // update orders table
                            orders[0].Amount = orders[0].OutUnitPrice * orders[0].Quantity;

                            // Tax Calculation
                            fTax1 = orders[0].IsTax1 ? m_TaxRate1 * orders[0].Amount : 0;
                            fTax2 = orders[0].IsTax2 ? m_TaxRate2 * orders[0].Amount : 0;
                            if (m_bIsTax3IncTax1)
                                fTax3 = orders[0].IsTax3 ? m_TaxRate3 * (orders[0].Amount + fTax1) : 0;
                            else
                                fTax3 = orders[0].IsTax3 ? m_TaxRate3 * orders[0].Amount : 0;

                            if (orders[0].IsTax1) orders[0].Tax1 = fTax1;
                            if (orders[0].IsTax2) orders[0].Tax2 = fTax2;// orders[0].Amount * orders[0].Tax2Rate;
                            if (orders[0].IsTax3) orders[0].Tax3 = fTax3;// orders[0].Amount * orders[0].Tax3Rate;
                            orders[0].LastModDate = DateTime.Now.ToString("yyyy-MM-dd"); //DateTime.Now.ToShortDateString();
                            orders[0].LastModTime = DateTime.Now.ToString("HH:mm:ss"); //DateTime.Now.ToShortTimeString();
                            dbPOS.Update_Orders_Amount_Qty(orders[0]);
                        }
                        else if (orders.Count > 1)
                        {
                            // Error on duplicated data exists
                            util.Logger("Error on duplicated data exists : InvoiceNo = " + iNewInvNo.ToString());
                            MessageBox.Show("Error on duplicated data exists : InvoiceNo = " + iNewInvNo.ToString());
                        }
                    }
                }
                Calculate_Total_Due();
                txtQTY.Text = "0";
            }
            else
            {
                txtSelectedMenu.Text = "QTY is not set or No ordered items to update!";
            }
            //txtBarCode.Focus();

            BarCode_Get_Focus();
        }

        private void bt_Minus_Click(object sender, EventArgs e)
        {
            bool bQTYPromotionProduct = false;
            float fTax1, fTax2, fTax3 = 0;

            DataAccessPOS dbPOS = new DataAccessPOS();

            if (dgv_Orders.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv_Orders.Rows)
                {

                    if (row.Selected)
                    {
                        //int iSelectedProdId = System.Convert.ToInt32(row.Cells[7].Value.ToString()); // Cells[7] product id
                        int iSelectedOrderId = System.Convert.ToInt32(row.Cells[6].Value.ToString()); // Cells[6] order id  //Bug #2553

                        // Set QTY for only Non-RFID Tag prod items
                        orders.Clear();
                        //orders = dbPOS.Get_NonRFID_Order_By_ProdId(iNewInvNo, iSelectedProdId);   //Bug #2553
                        orders = dbPOS.Get_NonRFID_Order_By_OrderId(iNewInvNo, iSelectedOrderId);   //Bug #2553
                        if ((orders.Count == 1) && (orders[0].Quantity > 1))
                        {
                            prods.Clear();
                            prods = dbPOS.Get_Product_By_ID(orders[0].ProductId);

                            orders[0].Quantity = orders[0].Quantity - 1;

                            if ((prods.Count > 0) && (orders[0].IsManualPrice != true))
                            {
                                bQTYPromotionProduct = Check_QTY_Promotion_Product(prods[0], orders[0].Quantity);
                                if (bQTYPromotionProduct)
                                {
                                    prods[0].OutUnitPrice = prods[0].PromoPrice1;
                                    orders[0].OutUnitPrice = prods[0].PromoPrice1;
                                }
                                else
                                {
                                    orders[0].OutUnitPrice = prods[0].OutUnitPrice;
                                }
                            }

                            // update datagrid veiw
                            row.Cells[2].Value = orders[0].Quantity.ToString();
                            float iAmount = orders[0].Quantity * orders[0].OutUnitPrice;
                            row.Cells[3].Value = orders[0].OutUnitPrice.ToString("0.00");
                            row.Cells[4].Value = iAmount.ToString("0.00");
                            // update orders table
                            orders[0].Amount = orders[0].OutUnitPrice * orders[0].Quantity;

                            // Tax Calculation
                            fTax1 = orders[0].IsTax1 ? m_TaxRate1 * orders[0].Amount : 0;
                            fTax2 = orders[0].IsTax2 ? m_TaxRate2 * orders[0].Amount : 0;
                            if (m_bIsTax3IncTax1)
                                fTax3 = orders[0].IsTax3 ? m_TaxRate3 * (orders[0].Amount + fTax1) : 0;
                            else
                                fTax3 = orders[0].IsTax3 ? m_TaxRate3 * orders[0].Amount : 0;
                            if (orders[0].IsTax1) orders[0].Tax1 = fTax1; // orders[0].Amount * orders[0].Tax1Rate;
                            if (orders[0].IsTax2) orders[0].Tax2 = fTax2; //orders[0].Amount * orders[0].Tax2Rate;
                            if (orders[0].IsTax3) orders[0].Tax3 = fTax3; //orders[0].Amount * orders[0].Tax3Rate;
                            orders[0].LastModDate = DateTime.Now.ToString("yyyy-MM-dd"); //DateTime.Now.ToShortDateString();
                            orders[0].LastModTime = DateTime.Now.ToString("HH:mm:ss"); //DateTime.Now.ToShortTimeString();
                            dbPOS.Update_Orders_Amount_Qty(orders[0]);
                        }
                        else if ((orders.Count == 1) && (orders[0].Quantity == 1))
                        {
                            dbPOS.Delete_Order_By_OrderId(orders[0].InvoiceNo, orders[0].Id);
                            dgv_Orders.Rows.RemoveAt(row.Index);
                        }
                        else if (orders.Count > 1)
                        {
                            // Error on duplicated data exists
                            util.Logger("Error on duplicated data exists : InvoiceNo = " + iNewInvNo.ToString());
                            MessageBox.Show("Error on duplicated data exists : InvoiceNo = " + iNewInvNo.ToString());
                        }
                    }
                }
                Calculate_Total_Due();
                txtQTY.Text = "0";
            }
            else
            {
                txtSelectedMenu.Text = "QTY is not set or No ordered items to update!";
            }
            //txtBarCode.Focus();

            BarCode_Get_Focus();
        }

        private void bt_SetReturn_Click(object sender, EventArgs e)
        {
            float fTax1, fTax2, fTax3 = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();
            if (dgv_Orders.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv_Orders.Rows)
                {

                    if (row.Selected)
                    {
                        //int iSelectedProdId = System.Convert.ToInt32(row.Cells[7].Value.ToString()); // Cells[7] product id
                        int iSelectedOrderId = System.Convert.ToInt32(row.Cells[6].Value.ToString()); // Cells[6] order id  //Bug #2553

                        // Set QTY for only Non-RFID Tag prod items
                        orders.Clear();
                        //orders = dbPOS.Get_NonRFID_Order_By_ProdId(iNewInvNo, iSelectedProdId);   //Bug #2553
                        orders = dbPOS.Get_NonRFID_Order_By_OrderId(iNewInvNo, iSelectedOrderId);   //Bug #2553
                        if (orders.Count == 1)
                        {

                            orders[0].Quantity = orders[0].Quantity * - 1;

                            // update datagrid veiw
                            row.Cells[2].Value = orders[0].Quantity.ToString();
                            float iAmount = orders[0].Quantity * orders[0].OutUnitPrice;
                            row.Cells[4].Value = iAmount.ToString("0.00");
                            // update orders table
                            orders[0].Amount = orders[0].OutUnitPrice * orders[0].Quantity;

                            // Tax Calculation
                            fTax1 = orders[0].IsTax1 ? m_TaxRate1 * orders[0].Amount : 0;
                            fTax2 = orders[0].IsTax2 ? m_TaxRate2 * orders[0].Amount : 0;
                            if (m_bIsTax3IncTax1)
                                fTax3 = orders[0].IsTax3 ? m_TaxRate3 * (orders[0].Amount + fTax1) : 0;
                            else
                                fTax3 = orders[0].IsTax3 ? m_TaxRate3 * orders[0].Amount : 0;
                            if (orders[0].IsTax1) orders[0].Tax1 = fTax1; // orders[0].Amount * orders[0].Tax1Rate;
                            if (orders[0].IsTax2) orders[0].Tax2 = fTax2; //orders[0].Amount * orders[0].Tax2Rate;
                            if (orders[0].IsTax3) orders[0].Tax3 = fTax3; //orders[0].Amount * orders[0].Tax3Rate;
                            orders[0].LastModDate = DateTime.Now.ToString("yyyy-MM-dd"); //DateTime.Now.ToShortDateString();
                            orders[0].LastModTime = DateTime.Now.ToString("HH:mm:ss"); //DateTime.Now.ToShortTimeString();
                            if (orders[0].Quantity < 0) 
                                orders[0].OrderCategoryId = 5;  // Return
                            else
                                orders[0].OrderCategoryId = 0;  // Normal
                            dbPOS.Update_Orders_Amount_Qty(orders[0]);
                            //this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = corder.RFTagId;
                            if (orders[0].Quantity < 0)
                                row.DefaultCellStyle.ForeColor = Color.Red;
                            else
                                row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
                Calculate_Total_Due();
                txtQTY.Text = "0";
            }
            else
            {
                txtSelectedMenu.Text = "QTY is not set or No ordered items to update!";
            }
            //txtBarCode.Focus();

            BarCode_Get_Focus();
        }

        private void bt_NumTypeToggle_Click(object sender, EventArgs e)
        {
            m_blnNumState = !m_blnNumState;
            
            DataAccessPOS dbPOS = new DataAccessPOS();
            sysconfs = dbPOS.Get_SysConfig_By_Name("IS_TYPE_BUTTONS_TO_NUMS");
            if (sysconfs.Count > 0)
            {
                sysconfs[0].ConfigValue = m_blnNumState ? "TRUE" : "FALSE";
                dbPOS.Update_SysConfig(sysconfs[0]);
            }

            ToggleNumTypeButtons();
        }

        private void ToggleNumTypeButtons()
        {
            if (m_blnNumState)
            {
                bt_NumTypeToggle.Text = "SHOW TYPES";
                bt_NumTypeToggle.BackColor = Color.DarkRed;
                bt_NumTypeToggle.ForeColor = Color.White;
                PopulateNumButtons();
            }
            else
            {
                bt_NumTypeToggle.Text = "SHOW NUMS";
                bt_NumTypeToggle.BackColor = Color.LightGoldenrodYellow;
                bt_NumTypeToggle.ForeColor = Color.DarkRed;
                PopulateMenuTypeButtons();
            }
        }

        private void bt_LastReprint_Click(object sender, EventArgs e)
        {
            // Get the last invoice no from POS1 database
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessCard dbCard = new DataAccessCard();
            List<POS1_TranCollectionModel> cols = new List<POS1_TranCollectionModel>();
            List<POS1_OrderCompleteModel> orderComItems = new List<POS1_OrderCompleteModel>();
            List<CCardReceipt> cardReceipts = new List<CCardReceipt>();

            POS1_TranCollectionModel lastcol = dbPOS1.Get_Last_TranCollection();
            iReprintInvNo = lastcol.InvoiceNo;
            
            util.Logger("Reprint Last Invoice No = " + iReprintInvNo.ToString());

            Print_Receipt(false, false, iReprintInvNo);

            cols = dbPOS1.Get_TranCollection_by_InvoiceNo(iReprintInvNo);
            orderComItems = dbPOS1.Get_OrderComplete_by_InvoiceNo(iReprintInvNo);
            cardReceipts = dbCard.Get_Approved_CardReceipt_By_InvoiceNo(iReprintInvNo);

            ShowReceiptInfoOnScreen(cols, orderComItems, cardReceipts);

            BarCode_Get_Focus();

        }

        private void bt_SalesReport_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.Hide();
            // Open Sales Report Form frmSalesReport on SDCafeKitchen project
            SDCafeOffice.frmLogOn frmOffice = new SDCafeOffice.frmLogOn();
            // show the form on the center of primary monitor 
            frmOffice.StartPosition = FormStartPosition.CenterScreen;
            frmOffice.ShowDialog();

            // get all forms opened
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if ((frm.Name == "frmLogOn") && (frm.ProductName == "SDCafeOffice"))
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Dispose();
                    break;
                }
            }

            this.Show();
            //this.TopMost = true;
            this.BringToFront();
            BarCode_Get_Focus();

        }
    }
    public class TagReportEvent : Object
    {
        public UInt32 aipType;
        public UInt32 tagType;
        public UInt32 antID;
        public Byte dsfid;
        public Byte[] uid;
        TagReportEvent()
        {
            aipType = 0;
            tagType = 0;
            antID = 0;
            dsfid = 0;
            uid = new Byte[8];
        }

    }
    public class CReaderDriverInf
    {
        public string m_catalog;
        public string m_name;
        public string m_productType;
        public UInt32 m_commTypeSupported;
    }
    public class CSupportedAirProtocol
    {
        public UInt32 m_ID;
        public string m_name;
        public Boolean m_en;
    }
}
