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
using SDCafeKitchen;
using SDCafeOffice.Views;
using System.Drawing.Printing;
using System.Linq;
using System.Diagnostics;
using DymoSDK.Interfaces;
using DymoSDK.Implementations;

namespace SDCafeKitchen.Views
{
    public partial class frmRegisterMain : Form
    {
        List<POS_LoginUserModel> loginUsers = new List<POS_LoginUserModel>();
        List<POS_ProductModel> prods = new List<POS_ProductModel>();
        List<POS_ProductTypeModel> ptypes = new List<POS_ProductTypeModel>();
        List<POS_RFIDTagsModel> rfids = new List<POS_RFIDTagsModel>();
        List<POS_SysConfigModel> sysconfs = new List<POS_SysConfigModel>();
        List<POS_TaxModel> taxs = new List<POS_TaxModel>();
        List<POS1_ProductPopModel> prodPops = new List<POS1_ProductPopModel>();

        Utility util = new Utility();
        public frmPrintCount FrmPrintCount;

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
        //public Button selectedBTN;
        //////////////////////////////////////////////////////
        // Declare and assign number of buttons = 20 
        //System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[30];
        private CustomButton[] btnArray = new CustomButton[300];
        private CustomButton selectedBTN;
        private int iSelected_btnArray_Index = -1;
        private int iSelected_ProdId = 0;
        private int iSelected_TotalTags = 0;
        private int iSelected_UsedTags = 0;

        private CustomButton[] btnTypeArray = new CustomButton[300];
        private int iSelectedType_btnArray_Index = -1;
        private string strSelectedProdName;
        private int iSelectedProdTypeID = 0;
        // 20200710
        private int iCurrentTypePage = 1;
        private int iCurrentProdPage = 1;
        private int iTotalTypePages = 1;
        private int iTotalProdPages = 1;

        public frmProduct FrmProd;
        public frmProdType FrmProdType;

        private bool isRFIDConnected = false;

        private DymoSDK.Implementations.DymoLabel dymoSDKLabel;
        private String strDyMoPrinter = "DYMO LabelWriter 450 Turbo";
        private int iCopies = 1;
        private bool bIsDymoPrinterSpecified = false;

        Thread InvenThread;

        private Process proc;
        // button colors by each line
        public Color[] btColor =
        {
            Color.Crimson,
            Color.SeaGreen,
            Color.DeepSkyBlue,
            Color.OrangeRed,
            Color.MediumPurple,
            Color.SaddleBrown,
            Color.LimeGreen,
            Color.Crimson,
            Color.SeaGreen,
            Color.DeepSkyBlue,
            Color.OrangeRed,
            Color.MediumPurple,
            Color.SaddleBrown,
            Color.Crimson,
            Color.SeaGreen,
            Color.DeepSkyBlue,
            Color.OrangeRed,
            Color.MediumPurple,
            Color.SaddleBrown
           // 238,79,82 0X00524FEE,
           // 50,185,87 0x0057B932,
           //35,118,199 0x00C77623,
           // 243,157,33 0x00219DF3,
           // 136,60,219 0x00DB3C88,
           //47,74,126 0x007E4A2F,
           // 0,102,0 0x00006600
        };
        private int iTagLabelCount = 0;
        private bool bPrtlblTimer = false;

        public frmRegisterMain()
        {
            InitializeComponent();
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

            selectedBTN = null;
            bt_Start.Enabled = false;
        }

        private void frmRegisterMain_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            //////////////////////////////////////////////////////
            // Create (20) Buttons: 
            for (int i = 0; i < 300; i++)
            {
                // Initialize one variable 
                //btnArray[i] = new System.Windows.Forms.Button();
                btnArray[i] = new CustomButton();
            }
            PopulateMenuButtons();
            PopulateMenuTypeButtons();
            //Load_RFID_Drivers();
            //Open_RFID_Connection();
            Load_Dymo_Printer();
        }

        private void Load_Dymo_Printer()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            string strDYMOFile = dbPOS.Get_SysConfig_By_Name("DYMO_LABLE_FILE")[0].ConfigValue;

            if (string.IsNullOrEmpty(strDYMOFile))
            {
                bIsDymoPrinterSpecified = false;
            }
            dymoSDKLabel = new DymoLabel();

            dymoSDKLabel.LoadLabelFromFilePath(strDYMOFile);
            bIsDymoPrinterSpecified = true;
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
            //string strCOMPort = "COM1";
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
                //MessageBox.Show("Failed to connect RFID Reader : " + iret.ToString());
                if (iret == -24)
                {
                    MessageBox.Show("Information : Failed to connect RFID Reader : " + iret.ToString() + " Scan will be disabled !", "POS Kitchen");
                }
                else if (iret == -19)
                {
                    MessageBox.Show("Information : Only One Application is able to connect to the Scanner : " + iret.ToString() + " Please exit Sales module and Try again !", "POS Kitchen");
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

                    checkedListBoxAntenna.Items.Add("Antenna#" + iAnt.ToString());
                    //comboBox7.Items.Add("Antenna#" + iAnt.ToString());
                }
                //button19.Enabled = false;
                checkedListBoxAntenna.Enabled = false;
                //comboBox7.Enabled = false;
                if (antennaCount > 1)
                {
                    checkedListBoxAntenna.Enabled = true;
                }


                // this API is not required in your own application
                // To get supported air protocol interface of the reader ,such as ISO15693 ,ISO14443a....
                checkedListBox2.Items.Clear();
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

                    checkedListBox2.Items.Add(aip.m_name, true);

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
        private void bt_Start_Click(object sender, EventArgs e)
        {
            if (selectedBTN == null)
            {
                MessageBox.Show("Please select a menu item first!");
                return;
            }

            _shouldStop = false;

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
            InvenThread = new Thread(DoInventory);
            InvenThread.Start();

            inventoryState = 1;
            return;
        }
        private void bt_Stop_Click(object sender, EventArgs e)
        {
            _shouldStop = true;
            bt_Start.Enabled = true;
            bt_Stop.Enabled = false;
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
            catch(ThreadAbortException e) {
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
        public delegate void delegate_tag_report_handle(UInt32 AIPType, UInt32 tagType, UInt32 antID, Byte[] uid, int uidlen);
        public void dele_tag_report_handler(UInt32 AIPType, UInt32 tagType, UInt32 antID, Byte[] uid, int uidlen)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
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
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = strAIPName;
                        lvi.SubItems.Add(strTagTypeName);
                        lvi.SubItems.Add(strUid);
                        lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"));
                        //lvi.SubItems.Add(antID.ToString());
                        lvi.SubItems.Add(selectedBTN.Text);
                        listView2.Items.Add(lvi);
                        resize_listviews();
                        textCount.Text = listView2.Items.Count.ToString();
                        ///////////////////////////////////////////////////////////////////
                        Add_RFIDTag_Into_Database(selectedBTN.Tag, strUid);
                        iSelected_TotalTags++;

                        int iTotalTagCount = dbPOS.Get_Tag_Count_by_ProdId(iSelected_ProdId);
                        int iUsedTagCount = dbPOS.Get_UsedTag_Count_by_ProdId(iSelected_ProdId);

                        btnArray[iSelected_btnArray_Index].Text = strSelectedProdName +
                                                                Environment.NewLine
                                                                + " ( " +
                                                                iUsedTagCount.ToString() +
                                                                "/" +
                                                                iTotalTagCount.ToString() + " )";
                                                                //+ "( " +
                                                                //iSelected_UsedTags.ToString() +
                                                                //"/" +
                                                                //iSelected_TotalTags.ToString() + " )";

                        /*int iTotalTagCount = dbPOS.Get_Tag_Count_by_ProdId(iSelectedProd);
                        int iUsedTagCount = dbPOS.Get_UsedTag_Count_by_ProdId(iSelectedProd);
                        btnArray[n].Text = prod.ProductName + Environment.NewLine +
                                                                prod.SecondName +
                                                                Environment.NewLine
                                                                + prod.OutUnitPrice.ToString("c2")
                                                                + " ( " +
                                                                iUsedTagCount.ToString() +
                                                                "/" +
                                                                iTotalTagCount.ToString() + " )"; */
                        // Beep at 5000 Hz for 1 second
                        Console.Beep(4000, 15);
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
            //txtCount.Text = listView1.Items.Count.ToString();
            
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

        private void Add_RFIDTag_Into_Database(object prodId, string strUid)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            bool isTagExists = false;
            isTagExists = dbPOS.Check_RFIDTag_Exists(strUid);
            rfids.Clear();
            if (!isTagExists)
            {
                rfids.Add(new POS_RFIDTagsModel()
                {
                    ProductId = (int)prodId,
                    SerialNo = strUid,
                    IsUsed = false,
                    DateTimeRegistered = DateTime.Now,
                    IsDonation = false,
                    DateTimeDonation = new DateTime(1900, 01, 01),
                    DiscountRate = 0,
                    DateTimeDiscount = new DateTime(1900, 01, 01)
                });
                dbPOS.Insert_RFIDTag(rfids[0]);
            }
            else
            {
                rfids.Add(new POS_RFIDTagsModel()
                {
                    ProductId = (int)prodId,
                    SerialNo = strUid,
                    IsUsed = false,
                    DateTimeRegistered = DateTime.Now,
                    DateTimeUsed = new DateTime(1900, 01, 01),
                    IsDonation = false,
                    DateTimeDonation = new DateTime(1900, 01, 01),
                    DiscountRate = 0,
                    DateTimeDiscount = new DateTime(1900, 01, 01)
                });
                dbPOS.Update_RFIDTag(rfids[0]);
            }

            if (bIsDymoPrinterSpecified)
            {
                iTagLabelCount++;
                if (iTagLabelCount == 1)
                {
                    timerPrtLblButton.Interval = 500;
                    timerPrtLblButton.Enabled = true;
                }
                bt_PrintLabel.Text = "Print Labels ( " + iTagLabelCount.ToString() + " )";
                bt_PrintLabel.BackColor = Color.LightGreen;
                bt_PrintLabel.ForeColor = Color.DarkBlue;
            }

        }

        private bool Print_Product_Label(int prodId)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            string strMemoText;
            string strBarCodeText;

            IEnumerable<ILabelObject> enumLabelObj = dymoSDKLabel.GetLabelObjects();

            //    for (int i = 0; i < enumLabelObj.Count; i++)
            foreach (ILabelObject iLabelObj in enumLabelObj)
            {
                //txtLabelObject1 = dymoSDKLabel.GetLabelObject("TextObject");
                if (iLabelObj.Name == "ITextObject0")
                {
                    dymoSDKLabel.UpdateLabelObject(iLabelObj, dbPOS.Get_ProductName_By_Id(prodId) + " (" + dbPOS.Get_ProductPrice_By_Id(prodId).ToString("c2") + ")");
                }
                if (iLabelObj.Name == "ITextObject1")
                {
                    strMemoText = dbPOS.Get_ProductMemo_By_Id(prodId);

                    dymoSDKLabel.UpdateLabelObject(iLabelObj, strMemoText);
                }
                if (iLabelObj.Name == "ITextObject3")
                {
                    strBarCodeText = dbPOS.Get_ProductBarCode_By_Id(prodId);

                    dymoSDKLabel.UpdateLabelObject(iLabelObj, "*" + strBarCodeText + "*");
                }
                //if (iLabelObj.Name == "IImageObject0")
                //{
                //    dymoSDKLabel.SetImageFromFilePath("IImageObject0", "C:\\Cube\\Labels\\Cube_Logo.jpg");
                //}

            }

            bool bStatus = DymoPrinter.Instance.PrintLabel(dymoSDKLabel, strDyMoPrinter, iCopies, true, false, 0, false);
            //bStatus = DymoPrinter.Instance.PrintLabel(dymoSDKLabel, strDyMoPrinter, iCopies, false, false, 0, true);
            //DymoPrinter.Instance.
            //Thread.Sleep(200);
            //            dymoSDKLabel = null;
            return bStatus;
        }

        private void resize_listviews()
        {
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                listView1.Columns[i].TextAlign = HorizontalAlignment.Center;
                listView1.Columns[i].Width = -2;
            }
            for (int i = 0; i < listView2.Columns.Count; i++)
            {
                listView2.Columns[i].TextAlign = HorizontalAlignment.Center;
                listView2.Columns[i].Width = -2;
            }
        }
        private void PopulateMenuButtons()
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
                    btnArray[n].Font = new Font("Arial", 10, FontStyle.Bold);

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
                    if (iLines > 5)
                    {
                        iLines = 1;
                    }
                    btnArray[n].BackColor = btColor[iLines];
                    // Location of button: 
                    btnArray[n].Left = xPos;
                    btnArray[n].Top = yPos;
                    ///////////////////////////////////////////////////////////////////
                    // Before adding custombutton, remove the event and control
                    // Add buttons to a Panel: 
                    if (!pnlMenu.Controls.Contains(btnArray[n]))
                    {
                        //btnArray[n].Click -= new System.EventHandler(ClickMenuButton);
                        //pnlMenu.Controls.Remove(btnArray[n]);

                        // the Event of click Button 
                        pnlMenu.Controls.Add(btnArray[n]);  // Let panel hold the Buttons 
                        btnArray[n].Click += new System.EventHandler(ClickMenuButton);
                    }

                    ///////////////////////////////////////////////////////////////////
                    xPos = xPos + btnArray[n].Width + 5;    // Left of next button 
                                                            // Write English Character: 
                                                            /* **************************************************************** 
                                                                Menu item button text
                                                            //**************************************************************** */

                    //btnArray[n].Text = ((char)(n + 65)).ToString() + (n+1).ToString();
                    int iTotalTagCount = dbPOS.Get_Tag_Count_by_ProdId(prod.Id);
                    int iUsedTagCount = dbPOS.Get_UsedTag_Count_by_ProdId(prod.Id);
                    btnArray[n].Text = prod.ProductName + Environment.NewLine +
                                                            prod.SecondName +
                                                            Environment.NewLine 
                                                            + prod.OutUnitPrice.ToString("c2")
                                                            + " ( " + 
                                                            iUsedTagCount.ToString() + 
                                                            "/" +
                                                            iTotalTagCount.ToString() + " )";
                    btnArray[n].Tag = prod.Id;



                    n++;
                }
            }
            lbl_ProdPages.Text = iCurrentProdPage.ToString() + "/" + (iTotalProdPages - 1).ToString();
            pnlMenu.Enabled = true; // not need now to this button now 
            //label1.Visible = true;
        }

        // Result of (Click Button) event, get the text of button 
        public void ClickMenuButton(Object sender, System.EventArgs e)
        {
            int iButtonLine = 0;
            //Button btn = (Button)sender;
            DataAccessPOS dbPOS = new DataAccessPOS();
            CustomButton btn = (CustomButton)sender;
            btn.BackColor = Color.Yellow;
            btn.ForeColor = Color.DarkBlue;
            // Previousely selected Menu button action to change color
            if (selectedBTN != null)
            {
                iButtonLine = (iSelected_btnArray_Index / 5);
                selectedBTN.BackColor = btColor[iButtonLine]; // Color.LightGray;
                selectedBTN.ForeColor = Color.Black;
            }
            //selectedBTN = (Button)sender;
            selectedBTN = (CustomButton)sender;

            iTagLabelCount = 0;

            txtSelectedMenu.Text="You have now selected menu item [ " + btn.Text + ", " + btn.Tag + " ]";
            ////////////////////////////////////////////////////////////////
            // save variables about selected button values
            iSelected_btnArray_Index = Array.IndexOf(btnArray, (CustomButton)sender);
            iSelected_ProdId = int.Parse(btn.Tag.ToString());
            iSelected_TotalTags = dbPOS.Get_Tag_Count_by_ProdId(iSelected_ProdId);
            iSelected_UsedTags = dbPOS.Get_UsedTag_Count_by_ProdId(iSelected_ProdId);
            prods = dbPOS.Get_Product_By_ID(iSelected_ProdId);
            if (prods.Count > 0)
            {
                strSelectedProdName = prods[0].ProductName;
            }
            else {
                strSelectedProdName = String.Empty;
            }
            if (isRFIDConnected)
            {
                bt_Stop.PerformClick();
                bt_Start.PerformClick();
            }
        }

        private void PopulateMenuTypeButtons()
        {
            int xPos = 0;
            int yPos = 0;
            int iLines = 0;
            int iPages = 0;

            iCurrentTypePage = 1;
            iTotalTypePages = 1;

            //////////////////////////////////////////////////////
            // Declare and assign number of buttons = 20 
            //System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[30];
            //////////////////////////////////////////////////////
            // Create (20) Buttons: 
            for (int i = 0; i < 300; i++)
            {
                // Initialize one variable 
                //btnArray[i] = new System.Windows.Forms.Button();
                btnTypeArray[i] = null;
                btnTypeArray[i] = new CustomButton();
                btnTypeArray[i].Click -= new System.EventHandler(ClickMenuTypeButton);
            }

            //pnlPType.Controls.Clear();
            pnlPType.Controls.Clear();

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
                    btnTypeArray[n].Font = new Font("Arial", 10, FontStyle.Bold);
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
                    int iTotalProdCount = dbPOS.Get_Product_Count_by_ProdTypeId(ptype.Id);

                    btnTypeArray[n].Text = ptype.TypeName + Environment.NewLine + "( " + iTotalProdCount.ToString() + " )";
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
            lbl_TypePages.Text = iCurrentTypePage.ToString() + "/" + (iTotalTypePages - 1).ToString();
            pnlPType.Enabled = true; // not need now to this button now 
            //label1.Visible = true;
        }
        private void ClickMenuTypeButton(object sender, EventArgs e)
        {
            int iButtonLine = 0;

            CustomButton btn = (CustomButton)sender;
            btn.BackColor = Color.Yellow;
            btn.ForeColor = Color.DarkBlue;
            // Previousely selected Menu button action to change color
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
        private void bt_Exit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to finish ?", "POS Kitchen Main", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Environment.Exit(0);
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                // Do nothing
            }
        }
        private void frmMain_Closing(object sender, FormClosingEventArgs e)
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
                    while (InvenThread.ThreadState == System.Threading.ThreadState.Running) //ThreadState.Running)
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

        private void bt_Refresh_Click(object sender, EventArgs e)
        {
            bt_Stop.PerformClick();
            this.BackColor = Color.Black;
            PopulateMenuTypeButtons();
            PopulateMenuButtons();
            //            Load_RFID_Drivers();
            //            Open_RFID_Connection();
        }

        private void bt_AddProduct_Click(object sender, EventArgs e)
        {
            string strSelProdId = "";

            if (iSelected_ProdId == 0)
            {
                strSelProdId = String.Empty;
                FrmProd = new frmProduct(strSelProdId, "", true, null);
            }
            else
            {
                strSelProdId = iSelected_ProdId.ToString();
                FrmProd = new frmProduct(strSelProdId, "", false, null);
            }
            FrmProd.ShowDialog(); // Show();
            bt_Refresh.PerformClick();
        }

        private void bt_AddPType_Click(object sender, EventArgs e)
        {
            string strSelProdTypeId = "";

            if (iSelectedProdTypeID == 0)
            {
                strSelProdTypeId = String.Empty;
            }
            else
            {
                strSelProdTypeId = iSelectedProdTypeID.ToString();
            }
            FrmProdType = new frmProdType(strSelProdTypeId);
            FrmProdType.ShowDialog();// FrmProdType.Show();
            bt_Refresh.PerformClick();
        }
        private void bt_UnSelectAll_Click(object sender, EventArgs e)
        {
            bt_Stop.PerformClick();

            //iSelected_btnArray_Index = 0;
            iSelected_ProdId = 0;
            iSelectedProdTypeID = 0;
            //iSelected_TotalTags = 0;
            //iSelected_UsedTags = 0;

            //selectedBTN = null;
            //bt_Start.Enabled = false;

            PopulateMenuTypeButtons();
            PopulateMenuButtons();

            bt_Stop.PerformClick();
        }

        private void bt_ShowAllMenuItem_Click(object sender, EventArgs e)
        {

            bt_Stop.PerformClick();

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
                    if (prodPop.ProductId > 0)
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
                            int iTotalTagCount = dbPOS.Get_Tag_Count_by_ProdId(prod.Id);
                            int iUsedTagCount = dbPOS.Get_UsedTag_Count_by_ProdId(prod.Id);
                            btnArray[n].Text = prod.ProductName +
                                                                    Environment.NewLine + prod.OutUnitPrice.ToString("c2")
                                                                    + " ( " +
                                                                    iUsedTagCount.ToString() +
                                                                    "/" +
                                                                    iTotalTagCount.ToString() + " )";
                            btnArray[n].Tag = prod.Id;
                            // the Event of click Button 
                            btnArray[n].Click += new System.EventHandler(ClickMenuButton);

                            n++;
                        }
                    }
                }
            }
            lbl_ProdPages.Text = iCurrentProdPage.ToString() + "/" + (iTotalProdPages - 1).ToString();
            pnlMenu.Enabled = true; // not need now to this button now 
            //label1.Visible = true;
        }
        public string StringCentering(string s, int desiredLength)
        {
            if (s.Length >= desiredLength) return s;
            int firstpad = (s.Length + desiredLength) / 2;
            return s.PadLeft(firstpad).PadRight(desiredLength);
        }
        private void bt_PrintInventory_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to print ?", "POS Kitchen Main", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            int iTotalSoldTags = 0;
            int iTotalTags = 0;

            int iTypeTotalSoldTags = 0;
            int iTypeTotalTags = 0;

            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            POS_ProductTypeModel prodType = new POS_ProductTypeModel();

            // -------------------- Print Document Setting -----------------------
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
            Font fntHeader = new Font("Arial", 9);
            Font fntFooter = new Font("Courier New", 10, FontStyle.Bold);
            Font fntContents = new Font("Arial", 8);
            Font fntTypeName = new Font("Courier New", 10, FontStyle.Bold);
            Font fntTotals = new Font("Courier New", 8, FontStyle.Bold);
            Font fntCard = new Font("Consolas", 8);
            Font fntLine = new Font("Courier New", 8, FontStyle.Bold);
            SolidBrush brsBlack = new SolidBrush(Color.Black);
            SolidBrush brsWhite = new SolidBrush(Color.White);

            string strPrtPName = "";
            // -------------------- Get necessary data -----------------------
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                int iNextLineYPoint = 0;
                int iLogoHeight = 80;
                int itxtHeight = 12;
                int iheaderHeight = 14;
                int ititleHeight = 17;

                string strHeader = "header";
                string strFooter = "footer";
                string strContent = "1234567890123456789012345678901234567890";
                string strLine = "----------------------------------------";
                string strDblLine = "========================================";

                //////////////////////////////////////////////////////////////////////////
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                Rectangle txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                //e1.Graphics.DrawRectangle(Pens.Black, txtRect);
                e1.Graphics.FillRectangle(brsBlack, txtRect);
                e1.Graphics.DrawString("All Product Tags Inventory", fntTitle, brsWhite, (RectangleF)txtRect, format1);
                // Print Current Date Time --------------------------------------------
                strContent = String.Format("{0,40}", "Issued:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 2);
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                prods = dbPOS.Get_All_Products_OrderBy_Type_ProdName();
                if (prods.Count > 0)
                {

                    int n = 0;
                    int iCurrentTypeId = 0;

                    foreach (var prod in prods)
                    {
                        if (iCurrentTypeId != prod.ProductTypeId)
                        {
                            //iTypeTotalSoldTags = iTypeTotalSoldTags + iUsedTagCount;
                            //iTypeTotalTags = iTypeTotalTags + iTotalTagCount;
                            strContent = String.Format("{0,-15}", "TYPE TOT") +
                                         String.Format("{0,6}", "") +
                                         String.Format("{0,6}", iTypeTotalSoldTags.ToString()) +
                                         String.Format("{0,6}", (iTypeTotalTags - iTypeTotalSoldTags).ToString()) +
                                         String.Format("{0,6}", iTypeTotalTags.ToString());
                            iNextLineYPoint = iNextLineYPoint + itxtHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                            iTypeTotalSoldTags = 0;
                            iTypeTotalTags = 0;

                            string strProdType = dbPOS.Get_ProductTypeName_By_Id(prod.ProductTypeId);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            //iNextLineYPoint = iNextLineYPoint + (itxtHeight * 2);
                            //txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            //e1.Graphics.DrawString(strDblLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print Type header ------------------------------------------------------
                            strContent = String.Format("{0,-30}", ">> " + strProdType); // StringCentering(strProdType, 30));
                            iNextLineYPoint = iNextLineYPoint + (itxtHeight * 2); //itxtHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTypeName, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            iNextLineYPoint = iNextLineYPoint + itxtHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strLine, fntLine, brsBlack, (RectangleF)txtRect, format2);

                            //////////////////////////////////////////////////////////////////////////
                            // Print Product header ------------------------------------------------------
                            strContent = String.Format("{0,-15}", "Product") +
                                         String.Format("{0,6}", "Price") +
                                         String.Format("{0,6}", "Sold") +
                                         String.Format("{0,6}", "Stock") +
                                         String.Format("{0,6}", "Total");
                            iNextLineYPoint = iNextLineYPoint + itxtHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            iNextLineYPoint = iNextLineYPoint + itxtHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strLine, fntLine, brsBlack, (RectangleF)txtRect, format2);

                            iCurrentTypeId = prod.ProductTypeId;
                        }

                        if ((n==0) & (iCurrentTypeId==0))
                        {
                            //////////////////////////////////////////////////////////////////////////
                            // Print Type header ------------------------------------------------------
                            strContent = String.Format("{0,-30}", ">> !!! NO TYPE SPECIFIED !!!"); // StringCentering(strProdType, 30));
                            iNextLineYPoint = iNextLineYPoint + (itxtHeight * 2); //itxtHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTypeName, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            iNextLineYPoint = iNextLineYPoint + itxtHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strLine, fntLine, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print Product header ------------------------------------------------------
                            strContent = String.Format("{0,-15}", "Product") +
                                         String.Format("{0,6}", "Price") +
                                         String.Format("{0,6}", "Sold") +
                                         String.Format("{0,6}", "Stock") +
                                         String.Format("{0,6}", "Total");
                            iNextLineYPoint = iNextLineYPoint + itxtHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            iNextLineYPoint = iNextLineYPoint + itxtHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strLine, fntLine, brsBlack, (RectangleF)txtRect, format2);
                        }

                        int iTotalTagCount = dbPOS.Get_Tag_Count_by_ProdId(prod.Id);
                        int iUsedTagCount = dbPOS.Get_UsedTag_Count_by_ProdId(prod.Id);
                        //////////////////////////////////////////////////////////////////////////
                        // Print Inventory header ------------------------------------------------------

                        if (prod.ProductName.Length > 15)
                        {
                            strPrtPName = prod.ProductName.Substring(0, 14);
                        }
                        else
                        {
                            strPrtPName = prod.ProductName;
                        }
                        strContent = String.Format("{0,-15}", strPrtPName) +
                                     String.Format("{0,6}", prod.OutUnitPrice.ToString("0.00")) +
                                     String.Format("{0,6}",  iUsedTagCount.ToString()) +
                                     String.Format("{0,6}",  (iTotalTagCount - iUsedTagCount).ToString()) +
                                     String.Format("{0,6}", iTotalTagCount.ToString());
                        iNextLineYPoint = iNextLineYPoint + itxtHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                        iTypeTotalSoldTags = iTypeTotalSoldTags + iUsedTagCount;
                        iTypeTotalTags = iTypeTotalTags + iTotalTagCount;

                        iTotalSoldTags = iTotalSoldTags + iUsedTagCount;
                        iTotalTags = iTotalTags + iTotalTagCount;

                        n++;

                    }
                    strContent = String.Format("{0,-15}", "TYPE TOT") +
                                 String.Format("{0,6}", "") +
                                 String.Format("{0,6}", iTypeTotalSoldTags.ToString()) +
                                 String.Format("{0,6}", (iTypeTotalTags - iTypeTotalSoldTags).ToString()) +
                                 String.Format("{0,6}", iTypeTotalTags.ToString());
                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                    //////////////////////////////////////////////////////////////////////////
                    // Print a Line ------------------------------------------------------
                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strLine, fntLine, brsBlack, (RectangleF)txtRect, format2);
                    //////////////////////////////////////////////////////////////////////////
                    strContent = String.Format("{0,-15}", "GRAND TOT") +
                                 String.Format("{0,6}", "") +
                                 String.Format("{0,6}", iTotalSoldTags.ToString()) +
                                 String.Format("{0,6}", (iTotalTags - iTotalSoldTags).ToString()) +
                                 String.Format("{0,6}", iTotalTags.ToString());
                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                    // Print Header ------------------------------------------------------
                    iNextLineYPoint = iNextLineYPoint + (iheaderHeight*2);
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                    e1.Graphics.DrawString(" >>>>>>>>>> End of Report <<<<<<<<<<", fntContents, brsBlack, (RectangleF)txtRect, format2);
                    //e1.Graphics.DrawRectangle(Pens.Black, txtRect);

                }
            }; // p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
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
            if (iCurrentTypePage > (iTotalTypePages - 1))
            {
                iCurrentTypePage = iTotalTypePages - 1;
                //return;
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

        private void bt_SetDonation_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to set donation for all remaining stocks ?", "POS Kitchen Main", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataAccessPOS dbPOS = new DataAccessPOS();
                POS_RFIDTagsModel rfid = new POS_RFIDTagsModel();
                rfids = dbPOS.Get_All_UnUsed_RFIDTags();

                if (rfids.Count > 0)
                {
                    int n = 0;
                    foreach (var rfidUnsold in rfids)
                    {
                        int iPTypeId = dbPOS.Get_ProductTypeId_By_ProductID(rfidUnsold.ProductId);
                        if (dbPOS.Check_ProdType_AbleTo_Donate(iPTypeId))
                        {
                            rfidUnsold.DateTimeDonation = DateTime.Now;
                            int iResult = dbPOS.Set_RFIDTag_Donation_ByID(rfidUnsold);
                        }
                    } //foreach (var rfid in rfids)
                    bt_Refresh.PerformClick();
                    txtSelectedMenu.Text = "All Remaining stock are set to Donation : " + rfids.Count.ToString();
                }//if (rfids.Count > 0)

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                // Do nothing
            }
        }

        private void txt_DiscountRate_Click(object sender, EventArgs e)
        {
            //run on screen keyboard
            proc = Process.Start("osk.exe");
            txt_DiscountRate.SelectAll();
        }

        private void bt_SetDiscount_Click(object sender, EventArgs e)
        {
            if (txt_DiscountRate.TextLength == 0)
            {
                txtSelectedMenu.Text = "Please check Disount Rate ! (1 ~ 99)";
                return;
            }
            int iDiscountRate = Convert.ToInt32(txt_DiscountRate.Text);
            if (iDiscountRate > 0 && iDiscountRate < 100)
            {
                DialogResult dialogResult = MessageBox.Show("Do you really want to set Discount for all remaining stocks ?", "POS Kitchen Main", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DataAccessPOS dbPOS = new DataAccessPOS();
                    POS_RFIDTagsModel rfid = new POS_RFIDTagsModel();
                    rfids = dbPOS.Get_All_UnUsed_RFIDTags();

                    if (rfids.Count > 0)
                    {
                        int n = 0;
                        foreach (var rfidUnsold in rfids)
                        {
                            int iPTypeId = dbPOS.Get_ProductTypeId_By_ProductID(rfidUnsold.ProductId);
                            if (dbPOS.Check_ProdType_AbleTo_Discount(iPTypeId))
                            {
                                rfidUnsold.DateTimeDiscount = DateTime.Now;
                                rfidUnsold.DiscountRate = iDiscountRate;
                                int iResult = dbPOS.Set_RFIDTag_Discount_ByID(rfidUnsold);
                            }
                        } //foreach (var rfid in rfids)
                        bt_Refresh.PerformClick();
                        txtSelectedMenu.Text = "All Remaining stock are set to Donation : " + rfids.Count.ToString();
                    }//if (rfids.Count > 0)

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                    // Do nothing
                }

            }
            else
            {
                txtSelectedMenu.Text = "Please check Disount Rate ! (1 ~ 99)";
            }
        }

        private void bt_SetStockEqual_Click(object sender, EventArgs e)
        {
            string strSelProdId = "";

            if (iSelected_ProdId == 0)
            {
                strSelProdId = String.Empty;
                txtSelectedMenu.Text = "Please select the product !";
            }
            else
            {
                strSelProdId = iSelected_ProdId.ToString();
                DataAccessPOS dbPOS = new DataAccessPOS();

                DialogResult dialogResult = MessageBox.Show("Do you really want to remove All Unsold Tags ? " + dbPOS.Get_ProductName_By_Id(iSelected_ProdId), "POS Kitchen Main", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {


                    POS_RFIDTagsModel rfid = new POS_RFIDTagsModel();

                    //rfids = dbPOS.Get_All_UnUsed_RFIDTags_by_ProdId(iSelected_ProdId);
                    int iDelCount = dbPOS.Delete_All_UnUsed_RFIDTags_by_ProdId(iSelected_ProdId);

                    txtSelectedMenu.Text = "Selected Unsold Tags were removed ! " + iDelCount.ToString() + " EA";
                }
                bt_Refresh.PerformClick();
            }
        }

        private void bt_PrintLabel_Click(object sender, EventArgs e)
        {

            if (iSelected_ProdId == 0)
            {
                return;
            }
            else
            {
                if (iTagLabelCount > 0)
                {
                    bt_PrintLabel.Enabled = false;
                    for (int i = 0; i < iTagLabelCount; i++)
                    {
                        bt_PrintLabel.Text = "Printing Lables ( " + i.ToString() + " )";
                        bt_PrintLabel.ForeColor = Color.DarkBlue;
                        Print_Product_Label(iSelected_ProdId);
                    }
                }
                else
                {
                    using (var FrmPrintCount = new frmPrintCount(this))
                    {
                        FrmPrintCount.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                                  (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                        FrmPrintCount.ShowDialog();

                        if (FrmPrintCount.bPrintNow)
                        {
                            iTagLabelCount = Convert.ToInt32(FrmPrintCount.strQTY);

                            for (int i = 0; i < iTagLabelCount; i++)
                            {
                                bt_PrintLabel.Text = "Printing Lables ( " + i.ToString() + " )";
                                bt_PrintLabel.ForeColor = Color.DarkBlue;
                                Print_Product_Label(iSelected_ProdId);
                            }
                        }

                    }
                }
                iTagLabelCount = 0;
                timerPrtLblButton.Enabled = false;
                bt_PrintLabel.Enabled = true;
                bt_PrintLabel.Text = "Print Lables ( " + iTagLabelCount.ToString() + " )";
                bt_PrintLabel.BackColor = Color.DarkGray;
                bt_PrintLabel.ForeColor = Color.White;

            }

        }

        private void bt_PrintOneLabel_Click(object sender, EventArgs e)
        {
            if (iSelected_ProdId == 0)
            {
                return;
            }
            else
            {
                    Print_Product_Label(iSelected_ProdId);
            }
        }

        private void On_timerPrtLblButton(object sender, EventArgs e)
        {
            if (bPrtlblTimer)
            {
                bt_PrintLabel.BackColor = Color.GreenYellow;
                bPrtlblTimer = false;
            }
            else
            {
                bt_PrintLabel.BackColor = Color.DarkGray;
                bPrtlblTimer = true;
            }

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
