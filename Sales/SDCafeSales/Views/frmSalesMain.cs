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
        List<POS_StationModel> stations = new List<POS_StationModel>();
        List<POS_OrdersModel> orders = new List<POS_OrdersModel>();
        List<POS1_OrderCompleteModel> compOrders = new List<POS1_OrderCompleteModel>();
        List<POS1_ProductPopModel> prodPops = new List<POS1_ProductPopModel>();
        List<POS_SavedOrdersModel> savedorders = new List<POS_SavedOrdersModel>();

        ToolTip tTip = new ToolTip();

        private CustomButton[] btnArray = new CustomButton[300];
        private CustomButton[] btnTypeArray = new CustomButton[300];

        Utility util = new Utility();
        RawPrinterHelper rawPrt = new RawPrinterHelper();

        public frmCardPayment FrmCardPay;
        public frmSalesCustomer FrmSalesCustomer;
        public frmSalesHistory FrmSalesHist;
        public frmDiscount FrmDiscount;
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
        private float fTotDue = 0;
        private float TaxRate1 = 0;
        private float TaxRate2 = 0;
        private float TaxRate3 = 0;
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

        private Color[] btColor =
        {
            Color.Crimson,
            Color.SeaGreen,
            Color.DeepSkyBlue,
            Color.OrangeRed,
            Color.MediumPurple,
            Color.SaddleBrown,
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

        public frmSalesMain()
        {
            InitializeComponent();

            selectedBTN = null;
            bt_Start.Enabled = false;
        }

        private void frmSalesMain_Load(object sender, EventArgs e)
        {

            if (Screen.AllScreens.Length > 1)
            {
                frmSalesCustomer FrmSalesCustomer = new frmSalesCustomer(this);
                // Important !
                FrmSalesCustomer.StartPosition = FormStartPosition.Manual;

                // Get the second monitor screen
                Screen screen = GetSecondaryScreen();

                // set the location to the top left of the second screen
                FrmSalesCustomer.Location = screen.WorkingArea.Location;

                // set it fullscreen
                //FrmSalesCustomer.Size = new Size(screen.WorkingArea.Width, screen.WorkingArea.Height);
                //FrmSalesCustomer.ShowDialog();
                FrmSalesCustomer.Show();
                FrmSalesCustomer.BringToFront();
                // Show the form
            }
            else
            {
                MessageBox.Show("No External Display is Available");
            }

            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;
            this.BringToFront();

            pnlSideBar.Hide();

            if (Get_Tax_Rates())
            {
                Load_System_Info();
                Load_Existing_Orders();
                PopulateMenuTypeButtons();
                PopulateMenuButtons();
                Load_RFID_Drivers();
                Open_RFID_Connection();
            }
            else
            {
                util.Logger("Error getting tax rates");
                MessageBox.Show("Error getting tax rates. Please call system admin!", "Error");
                this.Close();
            }

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
            }
            else
            {
                util.Logger("Error getting Login Info : " + strUserPass);
                MessageBox.Show("Error getting Login Info. Please call system admin!", "Error");
                this.Close();
            }
            this.Text = "Sales Main ( Terminal : " + strHostName + " / " + strStation + " ) Login User : " + strUserName;

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
            dgv_Orders_Initialize();
            DataAccessPOS dbPOS = new DataAccessPOS();
            orders = dbPOS.Get_Orders_by_Station(strStation);
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
                    if (order.OrderCategoryId == 0)
                    {
                        iAmount = order.Quantity * order.OutUnitPrice;
                        this.dgv_Orders.Rows.Add(new String[] { order.ProductId.ToString(),
                                                                                   order.ProductName,
                                                                                   order.Quantity.ToString(),
                                                                                   order.OutUnitPrice.ToString("0.00"),
                                                                                   iAmount.ToString("0.00"),
                                                                                   order.Id.ToString()
                                });
                    }else if (order.OrderCategoryId > 0) // Discount
                    {
                        iAmount = order.Amount;
                        this.dgv_Orders.Rows.Add(new String[] { order.ProductId.ToString(),
                                                                                   order.ProductName,
                                                                                   order.Quantity.ToString(),
                                                                                   order.Amount.ToString("0.00"),
                                                                                   iAmount.ToString("0.00"),
                                                                                   order.Id.ToString()
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
            taxs = dbPOS.Get_All_Tax();
            if (taxs.Count > 0)
            {
                TaxRate1 = taxs[0].Tax1;
                TaxRate2 = taxs[0].Tax2;
                TaxRate3 = taxs[0].Tax3;
                return true;
            }
            else
            {
                // Error getting tax rate
                return false;
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
            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();

            if (!isNewInvoice)   // Set when start button is pressed
            {
                iNewInvNo = dbPOS1.Get_New_InvoiceNo();
                int iSavedOrderInvNo = dbPOS.Get_SavedOrders_NextInvoiceNo();

                if (iNewInvNo < iSavedOrderInvNo)
                {
                    iNewInvNo = iSavedOrderInvNo;
                }
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
                    //orders = dbPOS.Get_Order_By_ProdId(iNewInvNo, rfids[0].ProductId);
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
                            Tax1Rate = TaxRate1,
                            Tax2Rate = TaxRate2,
                            Tax3Rate = TaxRate3,
                            Tax1 = prods[0].IsTax1 ? TaxRate1 * prods[0].OutUnitPrice : 0,
                            Tax2 = prods[0].IsTax2 ? TaxRate2 * prods[0].OutUnitPrice : 0,
                            Tax3 = prods[0].IsTax3 ? TaxRate3 * prods[0].OutUnitPrice : 0,
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
                            OrderCategoryId = 0
                        });
                        int iNewOrderId = dbPOS.Insert_Order(orders[0]);
                        if (iNewOrderId > 0)
                        {
                            ////////////////////////////////////////////////
                            // Add the ordered item into datagrid view
                            ////////////////////////////////////////////////
                            float iAmount = orders[0].Quantity * orders[0].OutUnitPrice;
                            this.dgv_Orders.Rows.Add(new String[] { prods[0].Id.ToString(),
                                                                               prods[0].ProductName,
                                                                               "1",
                                                                               prods[0].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               iNewOrderId.ToString()
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
                                    Tax1Rate = TaxRate1,
                                    Tax2Rate = TaxRate2,
                                    Tax3Rate = TaxRate3,
                                    Tax1 = prods[0].IsTax1 ? -(TaxRate1 * (prods[0].OutUnitPrice * (rfids[0].DiscountRate / 100))) : 0,
                                    Tax2 = prods[0].IsTax2 ? -(TaxRate2 * (prods[0].OutUnitPrice * (rfids[0].DiscountRate / 100))) : 0, 
                                    Tax3 = prods[0].IsTax3 ? -(TaxRate3 * (prods[0].OutUnitPrice * (rfids[0].DiscountRate / 100))) : 0,
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
                                    OrderCategoryId = 4
                                });
                                int iNewDiscOrderId = dbPOS.Insert_Order(orders[orders.Count-1]);
                                if (iNewDiscOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                                    {
                                    ////////////////////////////////////////////////
                                    // Add the ordered item into datagrid view
                                    ////////////////////////////////////////////////
                                    iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                    this.dgv_Orders.Rows.Add(new String[] { orders[orders.Count-1].Id.ToString(),
                                                                               orders[orders.Count-1].ProductName,
                                                                               "1",
                                                                               orders[orders.Count-1].Amount.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               iNewDiscOrderId.ToString()
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
                                    Tax1Rate = TaxRate1,
                                    Tax2Rate = TaxRate2,
                                    Tax3Rate = TaxRate3,
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
                                });
                                int iNewDepOrderId = dbPOS.Insert_Order(orders[orders.Count-1]);
                                if (iNewDepOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                                {
                                    ////////////////////////////////////////////////
                                    // Add the ordered item into datagrid view
                                    ////////////////////////////////////////////////
                                    iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                    this.dgv_Orders.Rows.Add(new String[] { orders[orders.Count-1].Id.ToString(),
                                                                               orders[orders.Count-1].ProductName,
                                                                               "1",
                                                                               orders[orders.Count-1].Amount.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               iNewDepOrderId.ToString()
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
                                    Tax1Rate = TaxRate1,
                                    Tax2Rate = TaxRate2,
                                    Tax3Rate = TaxRate3,
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
                                });
                                int iNewRecyOrderId = dbPOS.Insert_Order(orders[orders.Count-1]);
                                if (iNewRecyOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                                {
                                    ////////////////////////////////////////////////
                                    // Add the ordered item into datagrid view
                                    ////////////////////////////////////////////////
                                    iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                    this.dgv_Orders.Rows.Add(new String[] { orders[orders.Count-1].Id.ToString(),
                                                                               orders[orders.Count-1].ProductName,
                                                                               "1",
                                                                               orders[orders.Count-1].Amount.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               iNewRecyOrderId.ToString()
                                    });
                                    this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = rfids[0].Id;
                                    row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                                    row.DefaultCellStyle.ForeColor = Color.Blue;
                                    //this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView(prods[0].Id);
                                    //this.dgv_Orders.Rows[Get_OrderedItem_Index_of_GridView(prods[0].Id)].Selected = true;
                                    this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView_By_RFTagID(rfids[0].Id);
                                }
                            } //if (orders[0].Deposit > 0)
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
            Calculate_Total_Due();
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
            orders = dbPOS.Get_Orders_by_Station(strStation);

            if (orders.Count > 0)
            {
                foreach (var order in orders)
                {
                    //if (order.OrderCategoryId == 0)
                    //{
                        iSubTotal = iSubTotal + order.Amount;
                        iTaxTotal = iTaxTotal + (order.Tax1 + order.Tax2 + order.Tax3);
                        iTotalDue = iTotalDue + (order.Amount + order.Tax1 + order.Tax2 + order.Tax3);
                        iTotalItems = iTotalItems + order.Quantity;
                    //}else if (order.OrderCategoryId == 4)   // Discount
                    //{
                    //    iSubTotal = iSubTotal - order.Amount;
                    //    iTaxTotal = iTaxTotal - (order.Tax1 + order.Tax2 + order.Tax3);
                    //    iTotalDue = iTotalDue - (order.Amount + order.Tax1 + order.Tax2 + order.Tax3);
                    //    //iTotalItems = iTotalItems + order.Quantity;
                    //}
                }
            }
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
                    if (row.Cells[0].Value != null)
                    { 
                        row.Selected = false;
                        if (row.Cells[0].Value.ToString() == iProdId.ToString() && row.Tag == null)
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
            this.dgv_Orders.ColumnCount = 6;
            this.dgv_Orders.Columns[0].Name = "Prod Id";
            this.dgv_Orders.Columns[0].Width = 50;
            this.dgv_Orders.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Orders.Columns[1].Name = "Product Name";
            this.dgv_Orders.Columns[1].Width = 110;
            this.dgv_Orders.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgv_Orders.Columns[2].Name = "QTY";
            this.dgv_Orders.Columns[2].Width = 50;
            this.dgv_Orders.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_Orders.Columns[3].Name = "Unit Price";
            this.dgv_Orders.Columns[3].Width = 70;
            this.dgv_Orders.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_Orders.Columns[4].Name = "Amount";
            this.dgv_Orders.Columns[4].Width = 85;
            this.dgv_Orders.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_Orders.Columns[5].Name = "OrderId";
            this.dgv_Orders.Columns[5].Width = 0;
            this.dgv_Orders.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgv_Orders.DefaultCellStyle.Font = new Font("Arial Narrow", 14F, FontStyle.Bold);
            this.dgv_Orders.EnableHeadersVisualStyles = false;
            this.dgv_Orders.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.dgv_Orders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Orders.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgv_Orders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv_Orders.AllowUserToResizeRows = false;
            dgv_Orders.RowTemplate.Resizable = DataGridViewTriState.True;
            dgv_Orders.RowTemplate.MinimumHeight = 50;
            dgv_Orders.AllowUserToAddRows = false;
        }
        private void PopulateMenuTypeButtons()
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
            // Create (20) Buttons: 
            for (int i = 0; i < 300; i++)
            {
                // Initialize one variable 
                //btnArray[i] = new System.Windows.Forms.Button();
                btnTypeArray[i] = new CustomButton();
                btnTypeArray[i].Click -= new System.EventHandler(ClickMenuTypeButton);
            }

            //pnlPType.Controls.Clear();

            DataAccessPOS dbPOS = new DataAccessPOS();
            ptypes = dbPOS.Get_All_ProductTypes();

            if (ptypes.Count > 0)
            {
                int n = 0;
                foreach (var ptype in ptypes)
                {
                    btnTypeArray[n].Tag = n + 1; // Tag of button 
                    btnTypeArray[n].Width = (pnlPType.Width / 4) - 5; // Width of button 
                    btnTypeArray[n].Height = (pnlPType.Height / 3) - 5; // ((pnlPType.Height - 35) / 2) - 5; // Height of button
                    btnTypeArray[n].Font = new Font("Arial", 11, FontStyle.Bold);
                    //btnArray[n].BackColor = Color.LightSteelBlue;
                    btnTypeArray[n].ForeColor = Color.WhiteSmoke;
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
                    btnTypeArray[n].BackColor = btColor[iLines];
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

        private void ClickMenuTypeButton(object sender, EventArgs e)
        {
            int iButtonLine = 0;

            bt_HideSideBar.PerformClick();

            CustomButton btn = (CustomButton)sender;
            btn.BackColor = Color.Yellow;
            btn.ForeColor = Color.DarkBlue;
            if (selectedBTN != null)
            {
                iButtonLine = (iSelectedType_btnArray_Index / 4);

                selectedBTN.BackColor = btColor[iButtonLine]; // Color.LightGray;
                selectedBTN.ForeColor = Color.Black;
            }
            //selectedBTN = (Button)sender;
            selectedBTN = (CustomButton)sender;
            iSelectedType_btnArray_Index = Array.IndexOf(btnTypeArray, (CustomButton)sender);
            txtSelectedMenu.Text = "You have now selected menu type [ " + btn.Text + ", " + btn.Tag + " ]";
            iSelectedProdTypeID = int.Parse(string.Format("{0}", btn.Tag));

            PopulateMenuButtons();

        }

        private void PopulateMenuButtons()
        {
            int xPos = 0;
            int yPos = 0;
            int iLines = 0;

            iCurrentProdPage = 1;
            iTotalProdPages = 1;
            bt_HideSideBar.PerformClick();
            //////////////////////////////////////////////////////
            // Declare and assign number of buttons = 20 
            //System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[30];
            //CustomButton[] btnArray = new CustomButton[35];
            //////////////////////////////////////////////////////
            // Create (20) Buttons: 
            for (int i = 0; i < 300; i++)
            {
                // Initialize one variable 
                //btnArray[i] = new System.Windows.Forms.Button();
                btnArray[i] = new CustomButton();
                btnArray[i].Click -= new System.EventHandler(ClickMenuButton);
            }

            pnlMenu.Controls.Clear();

            DataAccessPOS dbPOS = new DataAccessPOS();
            if (iSelectedProdTypeID > 0)
            {
                prods = dbPOS.Get_All_Products_By_ProdType(iSelectedProdTypeID);
            }
            else
            {
                prods = dbPOS.Get_All_Products();
            }

            if (prods.Count > 0)
            {
                int n = 0;
                foreach (var prod in prods)
                {
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
            lbl_ProdPages.Text = iCurrentProdPage.ToString() + "/" + (iTotalProdPages-1).ToString();
            pnlMenu.Enabled = true; // not need now to this button now 
            //label1.Visible = true;
        }
        // Result of (Click Button) event, get the text of button 
        public void ClickMenuButton(Object sender, System.EventArgs e)
        {
            bt_HideSideBar.PerformClick();

            int iButtonLine = 0;
            //Button btn = (Button)sender;
            CustomButton btn = (CustomButton)sender;
            btn.BackColor = Color.Yellow;
            btn.ForeColor = Color.DarkBlue;
            if (selectedBTN != null)
            {
                iButtonLine = (iSelected_btnArray_Index / 5);
                selectedBTN.BackColor = btColor[iButtonLine]; // Color.LightGray;
                selectedBTN.ForeColor = Color.Black;
            }
            //selectedBTN = (Button)sender;
            selectedBTN = (CustomButton)sender;

            txtSelectedMenu.Text = "You have now selected menu item [ " + btn.Text + ", " + btn.Tag + " ]";
            ////////////////////////////////////////////////////////////////
            // save variables about selected button values
            iSelected_btnArray_Index = Array.IndexOf(btnArray, (CustomButton)sender);
            int iProdID = int.Parse(string.Format("{0}", btn.Tag));
            if (Add_Order_Manually(iProdID))
            {

            }
            //bt_Stop.PerformClick();
            //bt_Start.PerformClick();
        }

        private bool Add_Order_Manually(int pProdID)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();

            if (!isNewInvoice)   // Set when start button is pressed
            {
                iNewInvNo = dbPOS1.Get_New_InvoiceNo();
                int iSavedOrderInvNo = dbPOS.Get_SavedOrders_NextInvoiceNo();

                if (iNewInvNo < iSavedOrderInvNo)
                {
                    iNewInvNo = iSavedOrderInvNo;
                }
                isNewInvoice = true;
            }

            prods.Clear();
            prods = dbPOS.Get_Product_By_ID(pProdID);
            if (prods.Count > 0)
            {
                orders.Clear();
                //Get_Order_By_ProdId(iNewInvNo, pProdID);
                orders = dbPOS.Get_NonRFID_Order_By_ProdId(iNewInvNo, pProdID);
                if (orders.Count == 1)
                {
                    orders[0].Quantity++;
                    //int rowIndex = Get_OrderedItem_Index_of_GridView(pProdID);
                    int rowIndex = Get_OrderedItem_Index_of_GridView_By_ProdID(pProdID);
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
                        orders[0].LastModDate = DateTime.Now.ToString("yyyy-MM-dd");
                        orders[0].LastModTime = DateTime.Now.ToString("HH:mm:ss");
                        dbPOS.Update_Orders_Amount_Qty(orders[0]);
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
                        Tax1Rate = TaxRate1,
                        Tax2Rate = TaxRate2,
                        Tax3Rate = TaxRate3,
                        Tax1 = prods[0].IsTax1 ? TaxRate1 * prods[0].OutUnitPrice : 0,
                        Tax2 = prods[0].IsTax2 ? TaxRate2 * prods[0].OutUnitPrice : 0,
                        Tax3 = prods[0].IsTax3 ? TaxRate3 * prods[0].OutUnitPrice : 0,
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
                        RFTagId = 0
                    });
                    //if (dbPOS.Insert_Order(orders[0]))
                    int iNewOrderId = dbPOS.Insert_Order(orders[0]);
                    if (iNewOrderId > 0)
                    {
                        ////////////////////////////////////////////////
                        // Add the ordered item into datagrid view
                        ////////////////////////////////////////////////
                        float iAmount = orders[0].Quantity * orders[0].OutUnitPrice;
                        this.dgv_Orders.Rows.Add(new String[] { prods[0].Id.ToString(),
                                                                               prods[0].ProductName,
                                                                               "1",
                                                                               prods[0].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               iNewOrderId.ToString()
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
                                Tax1Rate = TaxRate1,
                                Tax2Rate = TaxRate2,
                                Tax3Rate = TaxRate3,
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
                            });
                            int iNewDepOrderId = dbPOS.Insert_Order(orders[orders.Count-1]);
                            if (iNewDepOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                            {
                                ////////////////////////////////////////////////
                                // Add the ordered item into datagrid view
                                ////////////////////////////////////////////////
                                iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                this.dgv_Orders.Rows.Add(new String[] { orders[orders.Count-1].Id.ToString(),
                                                                               orders[orders.Count-1].ProductName,
                                                                               "1",
                                                                               orders[orders.Count-1].Amount.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               iNewDepOrderId.ToString()
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
                                Tax1Rate = TaxRate1,
                                Tax2Rate = TaxRate2,
                                Tax3Rate = TaxRate3,
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
                            });
                            int iNewRecyOrderId = dbPOS.Insert_Order(orders[orders.Count-1]);
                            if (iNewRecyOrderId > 0) //if (dbPOS.Insert_Order(orders[1]))
                            {
                                ////////////////////////////////////////////////
                                // Add the ordered item into datagrid view
                                ////////////////////////////////////////////////
                                iAmount = orders[orders.Count - 1].Amount; //Quantity * orders[1].OutUnitPrice;
                                this.dgv_Orders.Rows.Add(new String[] { orders[orders.Count-1].Id.ToString(),
                                                                               orders[orders.Count-1].ProductName,
                                                                               "1",
                                                                               orders[orders.Count-1].Amount.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               iNewRecyOrderId.ToString()
                                    });

                            }
                        } //if (orders[0].RecyclingFee > 0)
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
            Calculate_Total_Due();
            return true;
        }

        private void bt_Start_Click(object sender, EventArgs e)
        {
            //            if (selectedBTN == null)
            //            {
            //                MessageBox.Show("Please select a menu item first!");
            //                return;
            //            }
            _shouldStop = false;
            
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
            if ((String.IsNullOrEmpty(txt_TotalDue.Text)) | (txt_TotalDue.Text.Contains("$0.00")) & (txtCount.Text.Contains("0")))
            {
                //MessageBox.Show("Nothing to pay yet! Please check Total Amount.");
                txtSelectedMenu.Text = "Nothing was ordered! Please check Total Amount.";
                txtSelectedMenu.BackColor = Color.DarkRed;
            }
            else
            {
                using (var FrmCardPay = new frmCardPayment(this))
                {
                    FrmCardPay.Set_TenderAmt(Convert.ToDouble(txt_TotalDue.Text.Replace("$", "")));
                    FrmCardPay.Set_InvoiceNo(iNewInvNo);
                    FrmCardPay.Set_Station(strStation);
                    FrmCardPay.Set_UserName(strUserName);
                    FrmCardPay.ShowDialog();
                    
                    bPaymentSuccess = FrmCardPay.bPaymentComplete;
                    //bCashPayment = FrmCardPay.bCashPayment;

                    if (FrmCardPay.bPaymentComplete)
                    {
                        util.Logger("Card Payment completed !" + FrmCardPay.strPaymentType);
                        // Move Orders to OrderComplete
                        Process_Order_Complete(iNewInvNo);
                        // Add collection table
                        Process_Tran_Collection(iNewInvNo, FrmCardPay.p_TenderAmt, 0, FrmCardPay.p_TipAmt, FrmCardPay.strPaymentType, true);
                        Process_Receipt(false, true);

                        txtSelectedMenu.Text = "Payment & Printing Receipt is Done : Invoice# " + iNewInvNo.ToString();

                        Initialize_Local_Variables();
                        dgv_Orders_Initialize();
                        Load_Existing_Orders();
                        bt_Stop.PerformClick();
                        bCashPayment = false;
                    }
                    else
                    {
                        txtSelectedMenu.Text = "Payment is not yet completed : Invoice# " + iNewInvNo.ToString();
                        util.Logger("Payment is not done yet!");

                    }
                }
                if (bCashPayment)
                {
                    txtSelectedMenu.Text = "Cash Payment is selected : Invoice# " + iNewInvNo.ToString();
                    using (var FrmCashPay = new frmCashPayment(this))
                    {
                        FrmCashPay.Set_TenderAmt(Convert.ToDouble(txt_TotalDue.Text.Replace("$", "")));
                        FrmCashPay.Set_InvoiceNo(iNewInvNo);
                        FrmCashPay.Set_Station(strStation);
                        FrmCashPay.Set_UserName(strUserName);
                        FrmCashPay.ShowDialog();

                        if (FrmCashPay.bPaymentComplete)
                        {
                            util.Logger("Cash/Manual Payment completed !" + FrmCashPay.strPaymentType);
                            // Move Orders to OrderComplete
                            Process_Order_Complete(iNewInvNo);
                            // Add collection table
                            Process_Tran_Collection(iNewInvNo, FrmCashPay.p_CashAmt, FrmCashPay.p_ChangeAmt, FrmCashPay.p_TipAmt, FrmCashPay.strPaymentType,false);
                            Process_Receipt(false, true);

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

        }

        private void Initialize_Local_Variables()
        {
            iNewInvNo = 0;
            iPpleCount = 0;
            isNewInvoice = false;
            iPpleCount = 0;
            bt_SetPPL.Tag = 0;
            txtAmtEach.Text = "";
            txtQTY.Text = "";
            fTotDue = 0;
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

                    dbPOS1.Insert_OrderComplete(ordercomp);
                    dbPOS.Delete_Order_By_OrderId(order.InvoiceNo,order.Id);

                }
            }
       }
       private void Process_Tran_Collection(int iInvNo, float fTenderAmt, float fChangeAmt, float fTips, string strPaymentType, bool bIsIPSPayment)
       {
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            DataAccessCard dbCard = new DataAccessCard();
            POS1_TranCollectionModel col = new POS1_TranCollectionModel();
            CCardReceipt cardReceipt = new CCardReceipt();

            util.Logger("Process_Tran_Collection iInvNo : " + iInvNo);
            util.Logger("Process_Tran_Collection fTenderAmt : " + fTenderAmt);
            util.Logger("Process_Tran_Collection fChangeAmt : " + fChangeAmt);
            util.Logger("Process_Tran_Collection fTips : " + fTips);
            util.Logger("Process_Tran_Collection strPaymentType : " + strPaymentType);

            compOrders = dbPOS1.Get_OrderComplete_by_InvoiceNo(iInvNo);

            if ((strPaymentType != "Cash") & (bIsIPSPayment))
            {
                util.Logger("Process_Tran_Collection IPS Payment : " + strPaymentType);
                fTenderAmt = dbCard.Get_TenderAmount(iInvNo);
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


                if (strPaymentType == "Cash")
                {
                    //col.Cash = fTenderAmt;
                    col.Cash = fTenderAmt + fChangeAmt - fTips;
                    col.CashTip = fTips;
                }
                else if (strPaymentType == "Debit") 
                {
                    col.Debit = fTenderAmt;
                    col.DebitTip = fTips;
                }
                else if ((strPaymentType == "Visa")|(strPaymentType == "DiscoverCard")|(strPaymentType == "DinersClub")|
                        (strPaymentType == "JCB")|(strPaymentType == "UnionPayCard")|(strPaymentType == "OtherCreditCard"))
                {
                    col.Visa = fTenderAmt;
                    col.VisaTip = fTips;
                }
                else if ((strPaymentType == "MasterCard")| (strPaymentType == "Master"))
                {
                    col.Master = fTenderAmt;
                    col.MasterTip = fTips;
                }
                else if (strPaymentType == "Amex")
                {
                    col.Amex = fTenderAmt;
                    col.AmexTip = fTips;
                }
                else if (strPaymentType == "GiftCard")
                {
                    col.GiftCard = fTenderAmt;
                    col.GiftCardTip = fTips;
                }
                col.CollectionType = strPaymentType;

                col.TotalPaid = col.Cash + col.Visa + col.Debit + col.Master + col.Amex + col.GiftCard + col.Online;
                col.TotalDue = fTotalDueAmt;
                col.Change = fChangeAmt;
                col.TotalTip = col.CashTip + col.VisaTip + col.DebitTip + col.MasterTip + col.AmexTip + col.GiftCardTip;

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
                col.Rounding = 0;
                col.IsOnline = false;
                col.ReceiptNo = dbPOS1.Get_MaxReceiptNo_TranCollection();
                col.InvoiceNo = iInvNo;
                //col.Change = fChangeAmt;

                dbPOS1.Insert_TranCollection(col);

            }

       }
       private bool Process_Save_Order(int iInvNo)
       {
            DataAccessPOS dbPOS = new DataAccessPOS();
            //DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            POS_SavedOrdersModel savedorder = new POS_SavedOrdersModel();
            orders = dbPOS.Get_Orders_by_InvoiceNo(iNewInvNo);
            
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
            savedorders = dbPOS.Get_SavedOrders_by_InvoiceNo(iInvNo);

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

                    if (dbPOS.Insert_Order(recallorder) > 0)
                    {
                        dbPOS.Delete_SavedOrder_By_OrderId(order.InvoiceNo, order.Id);
                        iRecallCount++;
                    }
                }
                if (iRecallCount == savedorders.Count)
                {
                    return true;
                }
            }
            return false;
        }
        private void bt_Void_Click(object sender, EventArgs e)
       {
            if (dgv_Orders.Rows.Count > 0)
            {
                int iRowCount = dgv_Orders.Rows.Count;
                //for (int i = 0; i < iRowCount; iRowCount++)
                foreach (DataGridViewRow row in dgv_Orders.Rows)
                {
                    if (row.Selected)
                    {
                        int iSelectedProdId = System.Convert.ToInt32(row.Cells[0].Value.ToString());
                        int iSelectedOrderId = System.Convert.ToInt32(row.Cells[5].Value.ToString());
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
                                txtSelectedMenu.Text = "Void completed : " + row.Cells[1].Value.ToString();
                                Calculate_Total_Due();
                                return;
                            }
                        }
                        else
                        {
                            if (Void_Product_Item(iSelectedProdId, iSelectedOrderId))
                            {
                                dgv_Orders.Rows.RemoveAt(row.Index);
                                txtSelectedMenu.Text = "Void completed : " + row.Cells[1].Value.ToString();
                                Calculate_Total_Due();
                                return;
                            }
                        }
                    }
                }
            }
       }

       private bool Void_Product_Item(int iSelectedProdId, int iSelectedOrderId)
       {
            int iTagUpdateCnt = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();
            orders.Clear();
            orders = dbPOS.Get_NonRFID_Order_By_OrderId(iNewInvNo, iSelectedOrderId);
            if (orders.Count == 1)
            {
                foreach (var order in orders)
                {
                    if (dbPOS.Delete_Order_By_OrderId(iNewInvNo, order.Id) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool Void_Product_Item_byTagId(int iSelectedTagId)
        {
            int iTagUpdateCnt = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();
            orders.Clear();
            orders = dbPOS.Get_Order_By_Invoice_RFTagId(iNewInvNo, iSelectedTagId);
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
                        util.Logger("Order removed = " + order.RFTagId);
                    }
                }

            }
            dgv_Orders_Initialize();
            Calculate_Total_Due();
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
            if (!string.IsNullOrEmpty(txtQTY.Text))
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
                            int iSelectedProdId = System.Convert.ToInt32(row.Cells[0].Value.ToString());
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
            }
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
        }
        public string StringCentering(string s, int desiredLength)
        {
            if (s.Length >= desiredLength) return s;
            int firstpad = (s.Length + desiredLength) / 2;
            return s.PadLeft(firstpad).PadRight(desiredLength);
        }
        private void Process_Receipt(bool IsInvoice, bool IsCustomerCopy)
        {
            if (!IsInvoice)
            {
                //Print_Receipt(IsInvoice, false);
                Print_Receipt(IsInvoice, IsCustomerCopy);
            }
            //DialogResult dialogResult = MessageBox.Show("Print Customer Copy ?", "Receipt Print", MessageBoxButtons.YesNo);
            using (var FrmYesNo = new frmYesNo(this))
            {
                FrmYesNo.Set_Title("Receipt Print");
                FrmYesNo.Set_Message("Print Customer Copy ?");
                FrmYesNo.StartPosition =  FormStartPosition.Manual; // FormStartPosition.CenterScreen; //
                FrmYesNo.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                FrmYesNo.ShowDialog();

                if (FrmYesNo.bYesNo)
                {
                    if (IsCustomerCopy)
                    {
                        Print_Receipt(IsInvoice, IsCustomerCopy);
                    }
                }
            }

        }
        private void Print_Receipt(bool IsInvoice, bool IsCustomerCopy)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            DataAccessCard dbCard = new DataAccessCard();

            string strHeader = "header";
            string strFooter = "footer";
            string strContent = "1234567890123456789012345678901234567890";
            string strLine = "----------------------------------------";
            string strImageFile = "";
            float iSubTot = 0;
            float iTaxTot = 0;
            float iTotDue = 0;

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
                strContent = String.Format("{0,-17}", "Inv#: " + String.Format("{0}", System.Convert.ToInt32(iNewInvNo))) +
                             String.Format("{0,20}", "Served by: " + strUserName);
                iNextLineYPoint = iNextLineYPoint + iheaderHeight + 5;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                strContent = String.Format("{0,-17}", "Station:" + strStation) +
                             String.Format("{0,20}", "# of Customer:" + iPpleCount.ToString()); 
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                strContent = String.Format("{0,-17}", "Issued:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                if (IsCustomerCopy || bCashPayment)
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
                        orderitems = dbPOS.Get_Orders_by_InvoiceNo(iNewInvNo);
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
                        List<POS1_OrderCompleteModel> orderitems = new List<POS1_OrderCompleteModel>();
                        orderitems = dbPOS1.Get_OrderComplete_by_InvoiceNo(iNewInvNo);
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
                                if (order.ProductName.Length > 20)
                                {
                                    strProd = order.ProductName.Substring(0, 20);
                                }
                                if (order.OrderCategoryId == 0)
                                {
                                    iAmount = order.Quantity * order.OutUnitPrice;
                                    iSubTot = iSubTot + iAmount;
                                    iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
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

                            List<POS1_TranCollectionModel> cols = new List<POS1_TranCollectionModel>();
                            cols = dbPOS1.Get_TranCollection_by_InvoiceNo(iNewInvNo);

                            float fTenderAmt = 0, fTotalTips = 0, fTotalPaid = 0, fTotalChange = 0;

                            if (cols.Count > 0)
                            {
                                foreach (var col in cols)
                                {
                                    if (col.CollectionType == "Cash")
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Cash Paid :") + String.Format("{0,15}", (col.Cash - col.Change).ToString("0.00"));
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
                                    if (col.CollectionType == "Debit")
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
                                    if ((col.CollectionType == "Visa") | (col.CollectionType == "DinersClub") | (col.CollectionType == "DiscoverCard")
                                        | (col.CollectionType == "JCB") | (col.CollectionType == "UnionPayCard") | (col.CollectionType == "OtherCreditCard"))
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
                                    if (col.CollectionType == "MasterCard")
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
                                    if (col.CollectionType == "Amex")
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

                                    fTenderAmt = fTenderAmt + col.Cash + col.Debit + col.Visa + col.Master + col.Amex + col.GiftCard;
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

                List<CCardReceipt> cardReceipts = new List<CCardReceipt>();
                cardReceipts = dbCard.Get_Approved_CardReceipt_By_InvoiceNo(iNewInvNo);
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
                        strTemp1 = " > PURCHASED AMOUNT";
                        fCurrency = (float)System.Convert.ToDouble(receipt.TransactionAmount)/100;
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 2);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = " + TIP ADDED";
                        fCurrency = (float)System.Convert.ToDouble(receipt.TipAmount) / 100;
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = " = TOTAL PAID";
                        fCurrency = (float)System.Convert.ToDouble(receipt.TotalAmount) / 100;
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = receipt.EMVApplicationLabel + " ACCN No : " + receipt.CustomerAccountNumber;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight*2);
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
                        iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("SIGNATURE NOT REQUIRED", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("IMPORTANT", fntCard, brsBlack, (RectangleF)txtRect, format1);
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
            for (int i = 0; i < 300; i++)
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

                // set it fullscreen
                //FrmSalesCustomer.Size = new Size(screen.WorkingArea.Width, screen.WorkingArea.Height);
                //FrmSalesCustomer.ShowDialog();
                FrmSalesCustomer.Show();
                // Show the form
            }
            else
            {
                MessageBox.Show("No External Display is Available");
            }
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
            this.bt_Stop.PerformClick();
            this.bt_Start.PerformClick();
            bt_Start.Enabled = false;
            bt_Payment.Enabled = true;
        }

        private void bt_HideSideBar_Click_1(object sender, EventArgs e)
        {
            pnlSideBar.Hide();
        }

        private void bt_ShowSideBar_Click_1(object sender, EventArgs e)
        {
            pnlSideBar.Location = new Point(861, 4);
            pnlSideBar.Show();
            pnlSideBar.BringToFront();
        }

        private void bt_ShowAllMenuItem_Click_1(object sender, EventArgs e)
        {
            iSelectedProdTypeID = 0;
            PopulateMenuButtonByPopularity();
            txtSelectedMenu.Text = "All menu items are shown";
        }

        private void bt_Start_Click_1(object sender, EventArgs e)
        {
            //            if (selectedBTN == null)
            //            {
            //                MessageBox.Show("Please select a menu item first!");
            //                return;
            //            }
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
            txt_SubTotal.Text = String.Empty;
            txt_TaxTotal.Text = String.Empty;
            txt_TotalDue.Text = String.Empty;
            txtCount.Text = String.Empty;

            //Bug #1553
            Load_Existing_Orders();

            InvenThread = new Thread(DoInventory);
            InvenThread.Start();

            inventoryState = 1;
            return;
        }

        private void bt_Stop_Click_1(object sender, EventArgs e)
        {
            _shouldStop = true;
            bt_Start.Enabled = true;

            /*
             * Exit the inventory quickly
             */
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

        private void bt_Exit_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to finish ?", "POS Sales Main", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                // Do nothing
            }

        }

        private void bt_SalesHistory_Click(object sender, EventArgs e)
        {
            FrmSalesHist = new frmSalesHistory(this);
            FrmSalesHist.Show();
        }

        private void bt_ProdPageUp_Click(object sender, EventArgs e)
        {
            iCurrentProdPage--;

            if (iCurrentProdPage <= 1)
            {
                PopulateMenuButtons();
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
                btnTypeArray[i].BackColor = btColor[iLines];
                // Location of button: 
                //btnArray[i].Left = xPos;
                btnTypeArray[i].Top = yPos;
                // Add buttons to a Panel: E0040150996E1CA8
                xPos = xPos + btnTypeArray[i].Width + 5;    // Left of next button 
                                                        // Write English Character: 
                                                        //btnArray[i].Top = btnArray[i].Top - ((((btnArray[i].Height + 5) * 5) * iCurrentProdPage) - ((btnArray[i].Height + 5) * 5));
            }
            lbl_TypePages.Text = iCurrentTypePage.ToString() + "/" + (iTotalTypePages - 1).ToString();
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
                btnTypeArray[i].BackColor = btColor[iLines];
                // Location of button: 
                //btnArray[i].Left = xPos;
                btnTypeArray[i].Top = yPos;
                // Add buttons to a Panel: E0040150996E1CA8
                xPos = xPos + btnTypeArray[i].Width + 5;    // Left of next button 
                                                            // Write English Character: 
                                                            //btnArray[i].Top = btnArray[i].Top - ((((btnArray[i].Height + 5) * 5) * iCurrentProdPage) - ((btnArray[i].Height + 5) * 5));
            }
            lbl_TypePages.Text = iCurrentTypePage.ToString() + "/" + (iTotalTypePages - 1).ToString();
        }

        private void bt_OpenCashDrawer_Click(object sender, EventArgs e)
        {
            //SendStringToPrinter("EPSON-1", openTillCommand);
            RawPrinterHelper.SendStringToPrinter("EPSON-1", openTillCommand);
        }

        private void bt_OpenCashDrawer1_Click(object sender, EventArgs e)
        {
            //SendStringToPrinter("EPSON-1", openTillCommand);
            RawPrinterHelper.SendStringToPrinter("EPSON-1", openTillCommand);
        }

        private void bt_SaveOrder_Click(object sender, EventArgs e)
        {
            if (iNewInvNo != 0)
            {
                if (Process_Save_Order(iNewInvNo))
                {
                    Print_SavedOrders(iNewInvNo);
                    txtSelectedMenu.Text = "Order Save Completed !";

                    Initialize_Local_Variables();
                    dgv_Orders_Initialize();
                    Load_Existing_Orders();
                    bt_Stop.PerformClick();
                }
                else
                {
                    txtSelectedMenu.Text = "Order Save failed ! : " + iNewInvNo.ToString();
                }
            }
            else
            {
                txtSelectedMenu.Text = "No invoice was selected : " + iNewInvNo.ToString();
            }

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
                             String.Format("{0,20}", "# of Customer:" + iPpleCount.ToString());
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
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight * 2));
                e1.Graphics.DrawString("Please recall this order with Invoice No! #( " + iInvoiceNo.ToString() + " )", fntFooter, brsBlack, (RectangleF)txtRect, format1);
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
                        }
                        txtSelectedMenu.Text = "Recall order successed ! " + iRecallInvoiceNo.ToString();
                    }
                    else
                    {
                        txtSelectedMenu.Text = "Recall canceled ! ";
                    }

                }
            }
            else
            {
                txtSelectedMenu.Text = "Please proceed the on going order first !";
            }
        }
        // Amount Discount
        private void bt_SetDiscount_Click(object sender, EventArgs e)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            Double dblDueAmount = dbPOS.Get_Total_Due_Amount(iNewInvNo);


            if (Add_Discount_Orders_Item(true, "Total D/C(", dblDueAmount,0))
            {
                txtSelectedMenu.Text = "Total Discount added !";
            }
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
                        int iSelectedProdId = System.Convert.ToInt32(row.Cells[0].Value.ToString());
                        int iSelectedOrderId = System.Convert.ToInt32(row.Cells[5].Value.ToString());

                        DataAccessPOS dbPOS = new DataAccessPOS();
                        Double dblDueAmount = dbPOS.Get_Order_Amount_By_OrderId(iNewInvNo, iSelectedOrderId);

                        if (Add_Discount_Orders_Item(false, iSelectedOrderId.ToString() + " (", dblDueAmount, iSelectedOrderId))
                        {
                            txtSelectedMenu.Text = "Item Discount added !";
                        }
                        return;
                    }
                }
            }
        }

        private bool Add_Discount_Orders_Item(bool bIsTotalDiscount, string strDescription, Double dblDueAmount, int iOrderId)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            double iTotalAmount = 0;
            double iTotalTax1 = 0;
            double iTotalTax2 = 0;
            double iTotalTax3 = 0;

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
                        ProductName = strDescription + iDiscountRate.ToString() + "%)",
                        SecondName = strDescription + iDiscountRate.ToString() + "%)",
                        ProductTypeId = 0,
                        InUnitPrice = 0,
                        OutUnitPrice = 0,
                        IsTax1 = false,
                        IsTax2 = false,
                        IsTax3 = false,
                        Quantity = 1,
                        Amount = (float)(-iTotalAmount * (iDiscountRate / 100)),
                        Tax1Rate = TaxRate1,
                        Tax2Rate = TaxRate2,
                        Tax3Rate = TaxRate3,
                        Tax1 = (float)(-iTotalTax1 * (iDiscountRate / 100)),
                        Tax2 = (float)(-iTotalTax2 * (iDiscountRate / 100)),
                        Tax3 = (float)(-iTotalTax3 * (iDiscountRate / 100)),
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
                    });
                    int iNewOrderId = dbPOS.Insert_Order(orders[0]);
                    if (iNewOrderId > 0)
                    {
                        ////////////////////////////////////////////////
                        // Add the ordered item into datagrid view
                        ////////////////////////////////////////////////
                        float iAmount = orders[0].Amount;
                        this.dgv_Orders.Rows.Add(new String[] { prods[0].Id.ToString(),
                                                                               orders[0].ProductName,
                                                                               "1",
                                                                               orders[0].OutUnitPrice.ToString("0.00"),
                                                                               iAmount.ToString("0.00"),
                                                                               iNewOrderId.ToString()
                            });
                        this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = 0;
                        DataGridViewRow row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        //this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView_By_RFTagID(rfids[0].Id);
                    }

                    Calculate_Total_Due();
                }
            }
            return true;
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
