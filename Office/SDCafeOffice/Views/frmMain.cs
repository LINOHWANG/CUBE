using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
using SDCafeCommon.Utilities;
using SDCafeOffice.Views;
using SDCafeOffice;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Diagnostics.PerformanceData;

namespace SDCafeOffice
{
    public partial class frmMain : Form
    {
        public frmLogOn FrmLogOn;
        List<POS_LoginUserModel> loginUsers = new List<POS_LoginUserModel>();
        List<POS_ProductModel> prods = new List<POS_ProductModel>();
        List<POS_ProductTypeModel> ptypes = new List<POS_ProductTypeModel>();
        List<POS_RFIDTagsModel> rfids = new List<POS_RFIDTagsModel>();
        List<POS_SysConfigModel> sysconfs = new List<POS_SysConfigModel>();
        List<POS_TaxModel> taxs = new List<POS_TaxModel>();
        List<POS_StationModel> stations = new List<POS_StationModel>();
        List<POS_PromotionModel> promos = new List<POS_PromotionModel>();
        List<POS_CategoryModel> categories = new List<POS_CategoryModel>();
        List<POS_ButtonInButtonsModel> buttonInbuttons = new List<POS_ButtonInButtonsModel>();
        List<POS_BIBListModel> bibList = new List<POS_BIBListModel>();

        Utility util = new Utility();
        private bool isProduct = false;
        private bool isLoginUser = false;
        private bool isPType = false;
        private bool isRFIDTag = false;
        private bool isSysConfig = false;
        private bool isTax = false;
        private bool isStation = false;
        private bool isPromotion = false;
        private bool isCategory = false;
        private bool isBIB = false; //Button In Buttons

        public frmProduct FrmProd;
        public frmProdType FrmProdType;
        public frmSysConfig FrmSysConfig;
        public frmLoginUser FrmLoginUser;
        public frmStations FrmStations;
        public frmPromotion FrmPromotion;
        public frmTax FrmTax;
        public frmCategory FrmCategory;
        public frmBIB FrmBIB;

        public frmSalesReport FrmSalesReport;
        private int iDataGridHeight;
        private int iDataGridTop;
        private string p_strSelectedTypeName;

        public frmTimeReport FrmTimeReport;
        public string strStation;
        public string strHostName;
        public string strTax1Name;
        public string strTax2Name;
        public string strTax3Name;
        public string strUserPass;
        private string strGrade;
        public string strUserID;
        public string strUserName;

        private bool _stopLoop;
        private bool bProdExist;
        private string strSelCategoryId;

        //private bool isSystem = false;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            bt_ProductExport.Enabled = false;
            progBarExport.Visible = false;
            //pnl_User.Hide();
            //pnl_Product.Hide();
            iDataGridHeight = dgvData.Height;
            iDataGridTop = gb_Prod.Top; // dgvData.Top;

            chk_IsMainSales.Checked = false;
            chk_IsSales.Checked = true;
            chk_IsManual.Checked = false;

            bt_Stop.Visible = false;

            Load_System_Info();
            Load_PType_Combo_Contents();
            dgvData_Adjustment();
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
                strGrade = loginUsers[0].Grade;
                util.Logger("Load_System_Info strUserID : " + strUserID + "," + strUserName);
            }
            else
            {
                util.Logger("Error getting Login Info : " + strUserPass);
                MessageBox.Show("Error getting Login Info. Please call system admin!", "Error");
                this.Close();
            }

            strTax1Name = dbPOS.Get_Tax_Name(1);
            strTax2Name = dbPOS.Get_Tax_Name(2);
            strTax3Name = dbPOS.Get_Tax_Name(3);

            if (strGrade == "1")
            {
                bt_Station.Enabled = false;
                bt_SysConfig.Enabled = false;
            }
            else if (strGrade == "2")
            {
                bt_LoginUser.Enabled = false;
                bt_Tax.Enabled = false;
                bt_Station.Enabled = false;
                bt_SysConfig.Enabled = false;

                bool blnOK = dbPOS.Get_SysConfig_By_Name("IS_ALLOW_MANGER_TIMEREPORT")[0].ConfigValue == "TRUE"? true:false;
                if (blnOK)
                {
                    bt_TimeReport.Enabled = true;
                }
                else
                {
                    bt_TimeReport.Enabled = false;
                }
                blnOK = dbPOS.Get_SysConfig_By_Name("IS_ALLOW_MANGER_PROMOTION")[0].ConfigValue == "TRUE" ? true : false;
                if (blnOK)
                {
                    bt_Promotion.Enabled = true;
                }
                else
                {
                    bt_Promotion.Enabled = false;
                }
                blnOK = dbPOS.Get_SysConfig_By_Name("IS_ALLOW_MANGER_SALESREPORT")[0].ConfigValue == "TRUE" ? true : false;
                if (blnOK)
                {
                    bt_SalesReport.Enabled = true;
                }
                else
                {
                    bt_SalesReport.Enabled = false;
                }
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
            //FrmLogOn = new frmLogOn();
            //FrmLogOn.Show();

            this.Hide();
            // close this program
            //Application.Exit();


        }
        private void Load_PType_Combo_Contents()
        {
            // Type Combo box contents fill
            DataAccessPOS dbPOS = new DataAccessPOS();
            ptypes = dbPOS.Get_All_ProductTypes();
            if (ptypes.Count > 0)
            {
                cb_PType.Items.Clear();
                int iTypeCount = 0;
                foreach (var pType in ptypes)
                {
                    iTypeCount = cb_PType.Items.Add(pType.TypeName);
                }
            }
            cb_PType.SelectionLength = 0;
        }
        private void dgvData_Adjustment()
        {
            dgvData.Location = new Point(160, 65); //(160, 65);

            if (isProduct)
            {
                gb_Prod.Show();
                gb_SysConfig.Hide();
                //dgvData.Height = iDataGridHeight - cb_PType.Height - 20 - chk_IsManual.Height - 20;
                dgvData.Height = iDataGridHeight - gb_Prod.Height - 10;
                //dgvData.Top = iDataGridTop + cb_PType.Height + chk_IsManual.Height + 20;
                dgvData.Top = iDataGridTop + gb_Prod.Height + 10;
            }
            else if (isSysConfig)
            {
                gb_Prod.Hide();
                gb_SysConfig.Show();
                gb_SysConfig.Top = gb_Prod.Top;
                dgvData.Height = iDataGridHeight - gb_SysConfig.Height - 10;
                dgvData.Top = iDataGridTop + gb_SysConfig.Height + 10;
            }
            else
            {
                gb_Prod.Hide();
                gb_SysConfig.Hide();
                dgvData.Height = iDataGridHeight;
                dgvData.Top = iDataGridTop;
            }
        }
        private void dgvData_Prod_Initialize()
        {
            dgvData_Adjustment();

            //Default checkbox
            chk_IsAll.Checked = true;
            chk_IsManual.Checked = false;

            DataAccessPOS dbPOS = new DataAccessPOS();
            
            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 16;
            this.dgvData.Columns[0].Name = "Id";
            this.dgvData.Columns[0].Width = 50;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvData.Columns[1].Name = "Product Name";
            this.dgvData.Columns[1].Width = 120;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvData.Columns[2].Name = "Second Name";
            this.dgvData.Columns[2].Width = 120;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvData.Columns[3].Name = "Type";
            this.dgvData.Columns[3].Width = 80;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvData.Columns[4].Name = "Category";
            this.dgvData.Columns[4].Width = 80;
            this.dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            this.dgvData.Columns[5].Name = "UnitPrice";
            this.dgvData.Columns[5].Width = 80;
            this.dgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[6].Name = dbPOS.Get_SysConfig_By_Name("Tax1")[0].ConfigValue;
            this.dgvData.Columns[6].Width = 50;
            this.dgvData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[7].Name = dbPOS.Get_SysConfig_By_Name("Tax2")[0].ConfigValue; // "Tax2";
            this.dgvData.Columns[7].Width = 50;
            this.dgvData.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[8].Name = dbPOS.Get_SysConfig_By_Name("Tax3")[0].ConfigValue; // "Tax3";
            this.dgvData.Columns[8].Width = 50;
            this.dgvData.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[9].Name = "InPrice";
            this.dgvData.Columns[9].Width = 80;
            this.dgvData.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[10].Name = "QTY";
            this.dgvData.Columns[10].Width = 80;
            this.dgvData.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[11].Name = "BarCode";
            this.dgvData.Columns[11].Width = 100;
            this.dgvData.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvData.Columns[12].Name = "Promo Start";
            this.dgvData.Columns[12].Width = 100;
            this.dgvData.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[13].Name = "Promo End";
            this.dgvData.Columns[13].Width = 100;
            this.dgvData.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[14].Name = "Promo QTY";
            this.dgvData.Columns[14].Width = 80;
            this.dgvData.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[15].Name = "Promo Unit Price";
            this.dgvData.Columns[15].Width = 80;
            this.dgvData.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvData.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);

            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
            this.dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvData.AllowUserToResizeRows = false;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvData.RowTemplate.MinimumHeight = 40;

            dgvData.AllowUserToAddRows = true;

        }

        private void bt_Product_Click(object sender, EventArgs e)
        {
            int iPCount = 0;
            bool bIsManual = chk_IsManual.Checked;
            //bool bIsMainSales = chk_IsMainSales.Checked;
            //bool bIsSales = chk_IsSales.Checked;
            //pnl_Product.Show();
            //pnl_User.Hide();
            bt_Product.BackColor = Color.Yellow;
            bt_LoginUser.BackColor = Color.Khaki;
            bt_ProdType.BackColor = Color.LightGreen;
            bt_RFIDTags.BackColor = Color.LightGreen;
            bt_Tax.BackColor = Color.DarkOrange;
            bt_SysConfig.BackColor = Color.Orchid;

            DataAccessPOS dbPOS = new DataAccessPOS();
            if (String.IsNullOrEmpty(p_strSelectedTypeName))
            {
                if (String.IsNullOrEmpty(text_PName.Text))
                {
                    if (String.IsNullOrEmpty(text_BarCode.Text))
                    {
                        //prods = dbPOS.Get_All_Products();
                        //prods = dbPOS.Get_All_Products_Sortby_Name(bIsManual, bIsMainSales, bIsSales);
                        prods = dbPOS.Get_All_Products_Sortby_Name(bIsManual);
                    }
                    else
                    {
                        //prods = dbPOS.Get_All_Products_By_BarCode(text_BarCode.Text, bIsManual, bIsMainSales, bIsSales);
                        prods = dbPOS.Get_All_Products_By_BarCode(text_BarCode.Text, bIsManual);
                    }
                }
                else
                {
                    //prods = dbPOS.Get_All_Products_By_ProdName(text_PName.Text, bIsManual, bIsMainSales, bIsSales);
                    prods = dbPOS.Get_All_Products_By_ProdName(text_PName.Text, bIsManual);
                }

            }
            else
            {
                prods = dbPOS.Get_All_Products_By_ProdType(dbPOS.Get_ProductTypeId_By_TypeName(p_strSelectedTypeName)[0].Id);
            }
            isProduct = true;
            isLoginUser = false;
            isPType = false;
            isRFIDTag = false;
            isSysConfig = false;
            isTax = false;
            isStation = false;
            isPromotion = false;
            isCategory = false;
            isBIB = false;

            dgvData_Prod_Initialize();
            if (prods.Count > 0)
            {
                // in case of only one product, show the product form
                if (prods.Count == 1)
                {
                    FrmProd = new frmProduct(prods[0].Id.ToString(), this);
                    FrmProd.m_strStation = strStation;
                    FrmProd.m_strUserPass = strUserPass;
                    FrmProd.ShowDialog();
                    text_PName.Text = "";
                    text_BarCode.Text = "";
                    text_BarCode.Focus();
                    //return;
                }
                Cursor.Current = Cursors.WaitCursor;
                //show progressbar
                progBarExport.Visible = true;
                progBarExport.Maximum = prods.Count;
                progBarExport.Value = 0;
                // set backcolor of progressbar
                progBarExport.BackColor = Color.LightGreen;
                progBarExport.Style = ProgressBarStyle.Continuous;

                bt_ProductExport.Enabled = true;
                foreach (var prod in prods)
                {
                    iPCount++;
                    progBarExport.Value = iPCount;
                    progBarExport.Refresh();

                    this.dgvData.Rows.Add(new String[] { prod.Id.ToString(),
                                                         prod.ProductName,
                                                         prod.SecondName,
                                                         dbPOS.Get_ProductTypeName_By_Id(prod.ProductTypeId),
                                                         dbPOS.Get_CategoryName_By_Id(prod.CategoryId),
                                                         prod.OutUnitPrice.ToString(),
                                                         prod.IsTax1.ToString(),
                                                         prod.IsTax2.ToString(),
                                                         prod.IsTax3.ToString(),
                                                         prod.InUnitPrice.ToString("C2"),
                                                         prod.Balance.ToString(),
                                                         prod.BarCode,
                                                         prod.PromoStartDate,
                                                         prod.PromoEndDate,
                                                         prod.PromoDay1.ToString(),
                                                         prod.PromoPrice1.ToString("C2")
                    });
                    if (prod.IsTax1) 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[6].Style.BackColor = Color.LightGreen; 
                    }
                    else 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[6].Style.BackColor = Color.LightSalmon; 
                    };
                    if (prod.IsTax2) 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[7].Style.BackColor = Color.LightGreen; 
                    }
                    else 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[7].Style.BackColor = Color.LightSalmon; 
                    };
                    if (prod.IsTax3) 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[8].Style.BackColor = Color.LightGreen; 
                    }
                    else 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[8].Style.BackColor = Color.LightSalmon; 
                    };
                    // Check Promotion and Change Color if Promotion is meet
                    if (IsProductPromotion(prod))
                    {
                        // Set the row color to LightPink
                        this.dgvData.Rows[dgvData.RowCount - 2].DefaultCellStyle.BackColor = Color.Yellow;
                        // Set the row font to bold
                        this.dgvData.Rows[dgvData.RowCount - 2].DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold,GraphicsUnit.Pixel);


                    }
                    if (prod.IsButtonInButton)
                    {
                        // Set the row color to LightPink
                        this.dgvData.Rows[dgvData.RowCount - 2].DefaultCellStyle.BackColor = Color.LightPink;
                    }
                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;
                }
                progBarExport.Visible = false;
                Cursor.Current = Cursors.Default;
                text_BarCode.Focus();
            }
        }

        private bool IsProductPromotion(POS_ProductModel p_Product)
        {
            // Check weather p_Product is promotion product
            if (p_Product.PromoStartDate != "" && p_Product.PromoEndDate != "")
            {
                DateTime dtStartDate = DateTime.Parse(p_Product.PromoStartDate);
                DateTime dtEndDate = DateTime.Parse(p_Product.PromoEndDate);
                DateTime dtNow = DateTime.Now;
                if (dtNow >= dtStartDate && dtNow <= dtEndDate)
                    return true;
                else
                    return false;
            }
            return false;
        }

        private void dgvData_LoginUser_Initialize()
        {
            dgvData_Adjustment();

            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 5;
            this.dgvData.Columns[0].Name = "Id";
            //this.dgvData.Columns[0].Width = 190;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[1].Name = "First Name";
            this.dgvData.Columns[1].Width = 150;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = "Last Name";
            this.dgvData.Columns[2].Width = 150;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = "PassCode";
            this.dgvData.Columns[3].Width = 200;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[4].Name = "Grade";
            this.dgvData.Columns[4].Width = 200;
            this.dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvData.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18F, GraphicsUnit.Pixel);
            this.dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvData.AllowUserToResizeRows = false;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvData.RowTemplate.MinimumHeight = 40;

            dgvData.AllowUserToAddRows = true;
        }
        private void bt_LoginUser_Click(object sender, EventArgs e)
        {
            bt_ProductExport.Enabled = false;

            bt_Product.BackColor = Color.LightGreen;
            bt_LoginUser.BackColor = Color.Yellow;
            bt_ProdType.BackColor = Color.LightGreen;
            bt_RFIDTags.BackColor = Color.LightGreen;
            bt_Tax.BackColor = Color.DarkOrange;
            bt_SysConfig.BackColor = Color.Orchid;

            DataAccessPOS dbPOS = new DataAccessPOS();
            loginUsers = dbPOS.Get_All_LoginUsers();
            isProduct = false;
            isLoginUser = true;
            isPType = false;
            isRFIDTag = false;
            isSysConfig = false;
            isTax = false;
            isStation = false;
            isPromotion = false;
            isCategory = false;
            isBIB = false;

            dgvData_LoginUser_Initialize();
            if (loginUsers.Count > 0)
            {
                foreach (var loginUser in loginUsers)
                {
                    // Exclude Super Users
                    if (loginUser.Grade != "0")
                    { 
                        this.dgvData.Rows.Add(new String[] { loginUser.Id.ToString(),
                                                             loginUser.FirstName,
                                                             loginUser.LastName,
                                                             loginUser.PassWord,
                                                             loginUser.Grade
                        });
                        if (Convert.ToInt32(loginUser.Grade) < 2)
                        {
                            this.dgvData.Rows[dgvData.RowCount - 2].Cells[4].Style.BackColor = Color.Green;
                        }
                        this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;
                    }

                }
            }

        }


 

        private void bt_ProdType_Click(object sender, EventArgs e)
        {
            bt_ProductExport.Enabled = false;
            //bt_ProductImport.Enabled = false;

            bt_Product.BackColor = Color.LightGreen;
            bt_LoginUser.BackColor = Color.Khaki;
            bt_ProdType.BackColor = Color.Yellow;
            bt_RFIDTags.BackColor = Color.LightGreen;
            bt_Tax.BackColor = Color.DarkOrange;
            bt_SysConfig.BackColor = Color.Orchid;

            DataAccessPOS dbPOS = new DataAccessPOS();
            ptypes = dbPOS.Get_All_ProductTypes();
            isProduct = false;
            isLoginUser = false;
            isPType = true;
            isRFIDTag = false;
            isSysConfig = false;
            isTax = false;
            isStation = false;
            isPromotion = false;
            isCategory = false;
            isBIB = false;

            dgvData_ProdType_Initialize();
            if (ptypes.Count > 0)
            {
                foreach (var ptype in ptypes)
                {

                    this.dgvData.Rows.Add(new String[] { ptype.Id.ToString(),
                                                         ptype.TypeName,
                                                         ptype.SortOrder.ToString(),
                                                         ptype.ForeColor,
                                                         ptype.BackColor
                    });
                    if ((ptype.ForeColor != "") && (ptype.ForeColor != null))
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[3].Style.BackColor = Color.FromArgb(int.Parse(ptype.ForeColor));
                    if ((ptype.BackColor != "") && (ptype.BackColor != null))
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[4].Style.BackColor = Color.FromArgb(int.Parse(ptype.BackColor));

                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;

                }
            }
        }
        private void dgvData_ProdType_Initialize()
        {
            dgvData_Adjustment();

            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 5;
            this.dgvData.Columns[0].Name = "Id";
            //this.dgvData.Columns[0].Width = 190;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[1].Name = "Type Name";
            this.dgvData.Columns[1].Width = 200;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = "Sort Order";
            this.dgvData.Columns[2].Width = 150;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = "ForeColor";
            this.dgvData.Columns[3].Width = 150;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[4].Name = "BackColor";
            this.dgvData.Columns[4].Width = 150;
            this.dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvData.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18F, GraphicsUnit.Pixel);
            this.dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvData.AllowUserToResizeRows = false;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvData.RowTemplate.MinimumHeight = 40;

            dgvData.AllowUserToAddRows = true;
        }

        private void bt_SysConfig_Click(object sender, EventArgs e)
        {
            bt_ProductExport.Enabled = false;

            bt_Product.BackColor = Color.LightGreen;
            bt_LoginUser.BackColor = Color.Khaki;
            bt_ProdType.BackColor = Color.LightGreen;
            bt_RFIDTags.BackColor = Color.LightGreen;
            bt_Tax.BackColor = Color.DarkOrange;
            bt_SysConfig.BackColor = Color.Yellow;

            DataAccessPOS dbPOS = new DataAccessPOS();

            if (text_ConfigName.Text != "")
            {
                sysconfs = dbPOS.Get_SysConfig_By_NamePart(text_ConfigName.Text);
            }
            else
            {
                sysconfs = dbPOS.Get_All_SysConfigs();
            }
            //sysconfs = dbPOS.Get_All_SysConfigs();
            isProduct = false;
            isLoginUser = false;
            isPType = false;
            isRFIDTag = false;
            isSysConfig = true;
            isStation = false;
            isPromotion = false;
            isCategory = false;
            isBIB = false;

            dgvData_SysConfig_Initialize();
            if (sysconfs.Count > 0)
            {
                foreach (var sysconf in sysconfs)
                {
                    this.dgvData.Rows.Add(new String[] { sysconf.Id.ToString(),
                                                         sysconf.ConfigName,
                                                         sysconf.ConfigValue,
                                                         sysconf.IsActive.ToString(),
                                                         sysconf.ConfigDesc
                    });
                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;

                }
            }

        }
        private void dgvData_SysConfig_Initialize()
        {
            dgvData_Adjustment();

            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 5;
            this.dgvData.Columns[0].Name = "Id";
            //this.dgvData.Columns[0].Width = 190;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[1].Name = "Config Name";
            this.dgvData.Columns[1].Width = 200;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = "Config Value";
            this.dgvData.Columns[2].Width = 200;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = "Is Active";
            this.dgvData.Columns[3].Width = 100;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[4].Name = "Description";
            this.dgvData.Columns[4].Width = 300;
            this.dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18F, GraphicsUnit.Pixel);
            this.dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvData.AllowUserToResizeRows = false;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvData.RowTemplate.MinimumHeight = 40;

            dgvData.AllowUserToAddRows = true;
        }
        private void bt_RFIDTags_Click(object sender, EventArgs e)
        {
            bt_Product.BackColor = Color.LightGreen;
            bt_LoginUser.BackColor = Color.Khaki;
            bt_ProdType.BackColor = Color.LightGreen;
            bt_RFIDTags.BackColor = Color.Yellow;
            bt_Tax.BackColor = Color.DarkOrange;
            bt_SysConfig.BackColor = Color.Orchid;

            DataAccessPOS dbPOS = new DataAccessPOS();
            rfids = dbPOS.Get_All_RFIDTags();
            isProduct = false;
            isLoginUser = false;
            isPType = false;
            isRFIDTag = true;
            isSysConfig = false;
            isTax = false;
            isStation = false;
            isPromotion = false;
            isCategory = false;
            isBIB = false;

            dgvData_RFIDTags_Initialize();
            if (rfids.Count > 0)
            {
                foreach (var rfid in rfids)
                {
                    this.dgvData.Rows.Add(new String[] { rfid.Id.ToString(),
                                                         dbPOS.Get_ProductName_By_Id(rfid.ProductId),
                                                         rfid.SerialNo,
                                                         rfid.IsUsed.ToString(),
                                                         rfid.DateTimeRegistered.ToString(),
                                                         rfid.DateTimeUsed.ToString(),
                                                         rfid.DiscountRate.ToString(),
                                                         rfid.IsDonation.ToString()
                    });
                    if (rfid.IsUsed)
                    {
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[3].Style.BackColor = Color.Red;
                    }
                    if (rfid.IsDonation)
                    {
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[7].Style.BackColor = Color.Red;
                    }
                    if (rfid.DiscountRate > 0)
                    {
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[6].Style.BackColor = Color.Red;
                    }
                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;

                }
            }
        }
        private void dgvData_RFIDTags_Initialize()
        {
            dgvData_Adjustment();

            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 8;
            this.dgvData.Columns[0].Name = "Id";
            this.dgvData.Columns[0].Width = 50;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[1].Name = "Product ID";
            this.dgvData.Columns[1].Width = 100;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = "Serial No";
            this.dgvData.Columns[2].Width = 200;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = "Is Used";
            this.dgvData.Columns[3].Width = 70;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[4].Name = "Registered Date";
            this.dgvData.Columns[4].Width = 150;
            this.dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[5].Name = "Used Date";
            this.dgvData.Columns[5].Width = 150;
            this.dgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[6].Name = "Discount";
            this.dgvData.Columns[6].Width = 100;
            this.dgvData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[7].Name = "Donation?";
            this.dgvData.Columns[7].Width = 70;
            this.dgvData.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            this.dgvData.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18F, GraphicsUnit.Pixel);
            this.dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvData.AllowUserToResizeRows = false;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvData.RowTemplate.MinimumHeight = 40;

            dgvData.AllowUserToAddRows = true;
        }
        private void dgvData_Stations_Initialize()
        {
            dgvData_Adjustment();

            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 7;
            this.dgvData.Columns[0].Name = "Computer Name";
            this.dgvData.Columns[0].Width = 150;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[1].Name = "Station";
            this.dgvData.Columns[1].Width = 100;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = "Station Name";
            this.dgvData.Columns[2].Width = 200;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = "StationNo";
            this.dgvData.Columns[3].Width = 50;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[4].Name = "Enabled";
            this.dgvData.Columns[4].Width = 50;
            this.dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[5].Name = "IPS IP Addr";
            this.dgvData.Columns[5].Width = 200;
            this.dgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[6].Name = "IPS Port#";
            this.dgvData.Columns[6].Width = 100;
            this.dgvData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvData.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18F, GraphicsUnit.Pixel);
            this.dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvData.AllowUserToResizeRows = false;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvData.RowTemplate.MinimumHeight = 40;

            dgvData.AllowUserToAddRows = true;
        }
        private void bt_Tax_Click(object sender, EventArgs e)
        {
            bt_ProductExport.Enabled = false;

            bt_Product.BackColor = Color.LightGreen;
            bt_LoginUser.BackColor = Color.Khaki;
            bt_ProdType.BackColor = Color.LightGreen;
            bt_RFIDTags.BackColor = Color.LightGreen;
            bt_Tax.BackColor = Color.Yellow;
            bt_SysConfig.BackColor = Color.Orchid;

            DataAccessPOS dbPOS = new DataAccessPOS();
            taxs = dbPOS.Get_All_Tax();
            isProduct = false;
            isLoginUser = false;
            isPType = false;
            isRFIDTag = false;
            isSysConfig = false;
            isTax = true;
            isStation = false;
            isPromotion = false;
            isCategory = false;
            isBIB = false;

            dgvData_Tax_Initialize();
            if (taxs.Count > 0)
            {
                foreach (var tax in taxs)
                {
                    this.dgvData.Rows.Add(new String[] { tax.Code,
                                                         tax.Tax1.ToString(),
                                                         tax.Tax2.ToString(),
                                                         tax.Tax3.ToString(),
                                                         tax.IsTax3IncTax1.ToString()
                    });
                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;

                }
            }
        }
        private void dgvData_Tax_Initialize()
        {
            dgvData_Adjustment();

            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 5;
            this.dgvData.Columns[0].Name = "Code";
            this.dgvData.Columns[0].Width = 150;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[1].Name = strTax1Name;// "Tax1";
            this.dgvData.Columns[1].Width = 100;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = strTax2Name;// "Tax2";
            this.dgvData.Columns[2].Width = 100;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = strTax3Name;// "Tax3";
            this.dgvData.Columns[3].Width = 100;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[4].Name = strTax3Name + " include " + strTax1Name;// "Tax3";
            this.dgvData.Columns[4].Width = 100;
            this.dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvData.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18F, GraphicsUnit.Pixel);
            this.dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvData.AllowUserToResizeRows = false;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvData.RowTemplate.MinimumHeight = 40;

            dgvData.AllowUserToAddRows = true;
        }
        private void dgvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (dgvData.SelectedRows[0].Index == 0)
            //{
                dgvData.ClearSelection();
            //    return;
            //}
        }
        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String strSelProdId = String.Empty;
            String strSelConfigId = String.Empty;
            String strSelLoginId = String.Empty;
            String strTypeId = String.Empty;
            String strHostName = String.Empty;
            String strPromoId = String.Empty;
            String strSelTaxCode = String.Empty;
            String strSelButtonProdId = String.Empty;

            /*          Int32 selectedRowCount =
                          dgvData.Rows.GetRowCount(DataGridViewElementStates.Selected);

                      if (selectedRowCount > 0)
                      {
                          //Header clicked
                          if (dgvData.SelectedRows[0].Index < 0)
                          {
                              return;
                          }
                          System.Text.StringBuilder sb = new System.Text.StringBuilder();

                          for (int i = 0; i < selectedRowCount; i++)
                          {
                              sb.Append("Row: ");
                              sb.Append(dgvData.SelectedRows[i].Index.ToString());
                              sb.Append(Environment.NewLine);
                          }

                          sb.Append("Total: " + selectedRowCount.ToString());
                          //MessageBox.Show(sb.ToString(), "Selected Rows");
                      }
                      else
                      {
                          return;
                      } */
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                if (isProduct)
                {
                    if (row.Cells[0].Value == null)
                    {
                        strSelProdId = String.Empty;
                    }
                    else
                    {
                        strSelProdId = row.Cells[0].Value.ToString();
                    }
                    FrmProd = new frmProduct(strSelProdId, this);
                    FrmProd.m_strStation = strStation;
                    FrmProd.m_strUserPass =  strUserPass;
                    FrmProd.ShowDialog();
                    bt_Product.PerformClick();
                }
                if (isSysConfig)
                {
                    if (row.Cells[0].Value == null)
                    {
                        strSelConfigId = String.Empty;
                    }
                    else
                    {
                        strSelConfigId = row.Cells[0].Value.ToString(); //dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value.ToString();
                    }
                    FrmSysConfig = new frmSysConfig(strSelConfigId);
                    FrmSysConfig.ShowDialog();
                    bt_SysConfig.PerformClick();
                }
                if (isLoginUser)
                {
                    if (row.Cells[0].Value == null)
                    {
                        strSelLoginId = String.Empty;
                    }
                    else
                    {
                        strSelLoginId = row.Cells[0].Value.ToString();
                    }
                    FrmLoginUser = new frmLoginUser(strSelLoginId, this);
                    FrmLoginUser.ShowDialog();
                    bt_LoginUser.PerformClick();
                }

                if (isPType)
                {
                    if (row.Cells[0].Value == null)
                    {
                        strTypeId = String.Empty;
                    }
                    else
                    {
                        strTypeId = row.Cells[0].Value.ToString();
                    }
                    FrmProdType = new frmProdType(strTypeId);
                    FrmProdType.ShowDialog();
                    bt_ProdType.PerformClick();
                    Load_PType_Combo_Contents();
                }
                if (isStation)
                {
                    if (row.Cells[0].Value == null)
                    {
                        strHostName = String.Empty;
                    }
                    else
                    {
                        strHostName = row.Cells[0].Value.ToString();
                    }
                    FrmStations = new frmStations(strHostName);
                    FrmStations.ShowDialog();
                    bt_Station.PerformClick();
                }
                if (isPromotion)
                {
                    if (dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value == null)
                    {
                        strPromoId = String.Empty;
                    }
                    else
                    {
                        strPromoId = dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value.ToString();
                    }
                    FrmPromotion = new frmPromotion(strPromoId);
                    FrmPromotion.ShowDialog();
                    bt_Promotion.PerformClick();
                }
                if (isTax)
                {
                    if (row.Cells[0].Value == null)
                    {
                        strSelTaxCode = String.Empty;
                    }
                    else
                    {
                        strSelTaxCode = row.Cells[0].Value.ToString(); //dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value.ToString();
                    }
                    FrmTax = new frmTax(this, strSelTaxCode, strTax1Name, strTax2Name, strTax3Name);
                    FrmTax.ShowDialog();
                    bt_Tax.PerformClick();
                }
                if (isCategory)
                {
                    if (row.Cells[0].Value == null)
                    {
                        strSelCategoryId = String.Empty;
                    }
                    else
                    {
                        strSelCategoryId = row.Cells[0].Value.ToString(); //dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value.ToString();
                    }
                    FrmCategory = new frmCategory(strSelCategoryId, this);
                    FrmCategory.ShowDialog();
                    bt_Category.PerformClick();
                }
                if (isBIB)
                {
                    if (row.Cells[0].Value == null)
                    {
                        strSelButtonProdId = String.Empty;
                    }
                    else
                    {
                        strSelButtonProdId = row.Cells[1].Value.ToString();
                    }
                    if (strSelButtonProdId == "")
                    {
                        MessageBox.Show("Please select a Button Item first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    FrmBIB = new frmBIB(strSelButtonProdId,this);
                    FrmBIB.p_int_ProductId = Convert.ToInt32(strSelButtonProdId);
                    FrmBIB.ShowDialog();

                    bt_BIBProd.PerformClick();
                }
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void bt_Station_Click(object sender, EventArgs e)
        {
            bt_ProductExport.Enabled = false;

            bt_Product.BackColor = Color.LightGreen;
            bt_LoginUser.BackColor = Color.Khaki;
            bt_ProdType.BackColor = Color.LightGreen;
            bt_RFIDTags.BackColor = Color.LightGreen;
            bt_Tax.BackColor = Color.DarkOrange;
            bt_SysConfig.BackColor = Color.Orchid;
            bt_Station.BackColor = Color.Yellow;

            DataAccessPOS dbPOS = new DataAccessPOS();
            stations = dbPOS.Get_All_Station();
            isProduct = false;
            isLoginUser = false;
            isPType = false;
            isRFIDTag = false;
            isSysConfig = false;
            isTax = false;
            isStation = true;
            isPromotion = false;
            isCategory = false;
            isBIB = false;

            dgvData_Stations_Initialize();
            if (stations.Count > 0)
            {
                foreach (var station in stations)
                {
                    this.dgvData.Rows.Add(new String[] { station.ComputerName.ToString(),
                                                         station.Station.ToString(),
                                                         station.StationName.ToString(),
                                                         station.StationNo.ToString(),
                                                         station.Enabled.ToString(),
                                                         station.IP_Addr.ToString(),
                                                         station.IPS_Port.ToString()
                    });
                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;

                }
            }

        }

        private void bt_SalesReport_Click(object sender, EventArgs e)
        {
            bt_ProductExport.Enabled = false;
            FrmSalesReport = new frmSalesReport();
            FrmSalesReport.ShowDialog();
        }

        private void bt_Promotion_Click(object sender, EventArgs e)
        {
            bt_ProductExport.Enabled = false;
            //pnl_Product.Show();
            //pnl_User.Hide();
            bt_Product.BackColor = Color.Yellow;
            bt_LoginUser.BackColor = Color.Khaki;
            bt_ProdType.BackColor = Color.LightGreen;
            bt_RFIDTags.BackColor = Color.LightGreen;
            bt_Tax.BackColor = Color.DarkOrange;
            bt_SysConfig.BackColor = Color.Orchid;

            DataAccessPOS dbPOS = new DataAccessPOS();
            promos = dbPOS.Get_All_Promotions();
            isProduct = false;
            isLoginUser = false;
            isPType = false;
            isRFIDTag = false;
            isSysConfig = false;
            isTax = false;
            isStation = false;
            isPromotion = true;
            isCategory = false;
            isBIB = false;

            dgvData_Promo_Initialize();
            if (promos.Count > 0)
            {
                foreach (var promo in promos)
                {
                    this.dgvData.Rows.Add(new String[] { promo.Id.ToString(),
                                                         promo.PromoName,
                                                         promo.PromoType.ToString(),
                                                         promo.PromoValue.ToString(),
                                                         promo.PromoQTY.ToString(),
                                                         promo.PromoStartDttm.ToString(),
                                                         promo.PromoEndDttm.ToString()
                    });


                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;
                }
            }
        }
        private void dgvData_Promo_Initialize()
        {
            dgvData_Adjustment();

            DataAccessPOS dbPOS = new DataAccessPOS();

            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 7;
            this.dgvData.Columns[0].Name = "Id";
            this.dgvData.Columns[0].Width = 50;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvData.Columns[1].Name = "Promotion Name";
            this.dgvData.Columns[1].Width = 200;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvData.Columns[2].Name = "Promotion Type";
            this.dgvData.Columns[2].Width = 120;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvData.Columns[3].Name = "Value";
            this.dgvData.Columns[3].Width = 120;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[4].Name = "QTY";
            this.dgvData.Columns[4].Width = 50;
            this.dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[5].Name = "Start Date Time";
            this.dgvData.Columns[5].Width = 200;
            this.dgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[6].Name = "End Date Time";
            this.dgvData.Columns[6].Width = 200;
            this.dgvData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvData.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);

            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18F, GraphicsUnit.Pixel);
            this.dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvData.AllowUserToResizeRows = false;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvData.RowTemplate.MinimumHeight = 40;

            dgvData.AllowUserToAddRows = true;
        }

        private void cb_PType_SelectedIndexChanged(object sender, EventArgs e)
        {
            p_strSelectedTypeName = cb_PType.SelectedItem.ToString();
        }

        private void cb_PType_TextChanged(object sender, EventArgs e)
        {
            p_strSelectedTypeName = cb_PType.Text;
        }

        private void bt_TimeReport_Click(object sender, EventArgs e)
        {
            bt_ProductExport.Enabled = false;

            FrmTimeReport = new frmTimeReport(this);
            FrmTimeReport.ShowDialog();
        }

        private void text_BarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cb_PType.Text = "";
                text_PName.Text = "";
                bt_Product.PerformClick();
            }
        }

        private void text_PName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cb_PType.Text = "";
                text_BarCode.Text = "";
                bt_Product.PerformClick();
            }
        }

        private async void bt_ProductExport_Click(object sender, EventArgs e)
        {
            EnableDisableButtons(false);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Product_Inventory_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _stopLoop = false;
                bt_Stop.Visible = true;

                //show progressbar
                progBarExport.Visible = true;
                progBarExport.Value = 0;
                // set backcolor of progressbar
                progBarExport.BackColor = Color.LightGreen;
                progBarExport.Style = ProgressBarStyle.Continuous;
                string strPtype = cb_PType.Text;

                await Task.Run(() => ExportProduct(sfd, strPtype));
                
                progBarExport.Visible = false;
                bt_Stop.Visible = false;
                // Open the newly saved excel file
                if (File.Exists(sfd.FileName))
                {
                    // copy the file to the temp folder
                    string strTempPath = Path.GetTempPath();
                    string strTempFile = strTempPath + Path.GetFileName(sfd.FileName);
                    File.Copy(sfd.FileName, strTempFile, true);

                    DataAccessPOS dbPOS = new DataAccessPOS();
                    string strConfig = dbPOS.Get_SysConfig_By_Name("CON_SEND_EMAIL_REPORT")[0].ConfigValue.Trim();
                    if (strConfig.Contains("TRUE"))
                    {
                        strConfig = dbPOS.Get_SysConfig_By_Name("CON_SEND_PROD_INVENTORY_EXPORT")[0].ConfigValue.Trim();
                        if (strConfig.Contains("TRUE"))
                        {
                            string strHTMLBody = "<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>" + System.Environment.NewLine +
                             "<html>" + System.Environment.NewLine +
                             "<head>" + System.Environment.NewLine +
                             " <style>#grad1 {" + System.Environment.NewLine +
                             " background-image: linear-gradient(to right, white , gray);" + System.Environment.NewLine +
                             " font-family: verdana;" + System.Environment.NewLine +
                             " }</style>" + System.Environment.NewLine +
                             "</head>" + System.Environment.NewLine +
                             "<body>" + System.Environment.NewLine +
                             " <h3 style='color: #000000;'> Dear Business Owner,</h3>" + System.Environment.NewLine +
                             " <h4 style='color: #000000;'> Product Data Excel Export action has been taken at YOUR POS today..<br /> " + System.Environment.NewLine +
                             " <span style='color: #FF0000;'> <strong>Please find attached excel file for your reference.</strong> </span>" + System.Environment.NewLine +
                             " <br /> " + System.Environment.NewLine +
                             " <br /><i> This email was automatically generated and sent from YOUR POS.. </i>" + System.Environment.NewLine +
                             " <br />Best Regards," + System.Environment.NewLine +
                             " </h4>" + System.Environment.NewLine +
                             " <h3 ><strong><span style='color: #0000ff;'>TechServe POS</span></strong><span style='color: #566573;'> &copy; 2023 <a href='https://techservepos.com'>techservepos.com</a></span></h3>" + System.Environment.NewLine +
                             "</body>" + System.Environment.NewLine +
                             "</html>" + System.Environment.NewLine;
                            util.SendEmail("Product Inventory Excel Export", strHTMLBody, strTempFile);
                        }
                    }

                    //System.Diagnostics.Process.Start(sfd.FileName);
                }

            }
            EnableDisableButtons(true);

        }

        private void EnableDisableButtons(bool p_Enable)
        {
            bt_ProductExport.Enabled = p_Enable;
            bt_Product.Enabled = p_Enable;
            bt_ProductImport.Enabled = p_Enable;
        }

        private void ExportProduct(SaveFileDialog p_sfd, string p_strPType)
        {
            Cursor.Current = Cursors.WaitCursor;

            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = false;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dgvData.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgvData.Columns[i - 1].HeaderText;
            }
            // set background color of the header cell
            worksheet.Rows[1].Interior.Color = Color.LightBlue;
            // storing Each row and column value to excel sheet  
            //set progBarExport maximum value
            progBarExport.Maximum = dgvData.Rows.Count - 1;
            for (int i = 0; i < dgvData.Rows.Count - 1; i++)
            {

                if (_stopLoop) break;
                float fPercent = ((float)i / (float)dgvData.Rows.Count) * 100;
                Invoke(new Action(() =>
                {
                    progBarExport.Value = i;
                    progBarExport.Refresh();
                    // show percentage of progress on the bt_Stop
                    bt_Stop.Text = "Stop ( Exporting " + fPercent.ToString("0.00") + "% ... )";
                }));
                
                for (int j = 0; j < dgvData.Columns.Count; j++)
                {
                    // cells format to text
                    worksheet.Cells[i + 2, j + 1].NumberFormat = "@";
                    worksheet.Cells[i + 2, j + 1] = dgvData.Rows[i].Cells[j].Value.ToString();
                    // Set the same background color on worksheet as dgvData's colume
                    //worksheet.Rows[i + 2].Interior.Color = dgvData.Rows[i].Cells[j].Style.BackColor;
                    Color cellColor = dgvData.Rows[i].Cells[j].Style.BackColor;
                    Color rowColor = dgvData.Rows[i].DefaultCellStyle.BackColor;//Color.FromArgb(0, 0, 0, 0);
                    if (!rowColor.IsEmpty)
                        worksheet.Cells[i + 2, j + 1].Interior.Color = rowColor;
                    if (!cellColor.IsEmpty)
                        worksheet.Cells[i + 2, j + 1].Interior.Color = cellColor;
                }
            }

            // insert Title row on top of the sheet
            worksheet.Rows[1].Insert();
            worksheet.Cells[1, 1] = "Date/Time Exported : " + DateTime.Now.ToString("G");
            worksheet.Rows[1].Insert();
            worksheet.Cells[1, 1] = "Product Inventory : " + p_strPType;
            // set bold font for the title
            worksheet.Cells[1, 1].Font.Bold = true;

            // save the application  
            workbook.SaveAs(p_sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Visible = false;
            app.Quit();

            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);

            Cursor.Current = Cursors.Default;

        }


        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        internal void Set_PassCode(string p_PassCode)
        {
            strUserPass = p_PassCode;
        }

        private void bt_Stop_Click(object sender, EventArgs e)
        {
            _stopLoop = true;
        }

        private void chk_IsAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_IsAll.Checked)
            {
                //chk_IsMainSales.Checked = true;
                //chk_IsSales.Checked = true;
                chk_IsManual.Checked = false;
            }
            else
            {
                //chk_IsMainSales.Checked = false;
                //chk_IsSales.Checked = false;
                chk_IsManual.Checked = true;
            }
        }

        private async void bt_ProductImport_Click(object sender, EventArgs e)
        {
            EnableDisableButtons(false);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Documents (*.xls)|*.xls";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _stopLoop = false;
                bt_Stop.Visible = true;

                //show progressbar
                progBarExport.Visible = true;
                progBarExport.Value = 0;
                // set backcolor of progressbar
                progBarExport.BackColor = Color.LightGreen;
                progBarExport.Style = ProgressBarStyle.Continuous;
                //string strPtype = cb_PType.Text;
                util.Logger("Product Importing started.." + ofd.FileName);
                if (File.Exists(ofd.FileName))
                {

                    await Task.Run(() => ImportProduct(ofd, ofd.FileName));
                    //System.Diagnostics.Process.Start(ofd.FileName);
                }

                progBarExport.Visible = false;
                bt_Stop.Visible = false;
                util.Logger("Product Importing finished.." + ofd.FileName);
            }
            EnableDisableButtons(true);
        }

        private void ImportProduct(object p_ofd, string p_strFileName)
        {
            Cursor.Current = Cursors.WaitCursor;

            DataAccessPOS dbPOS = new DataAccessPOS();
            POS_ProductModel prod = new POS_ProductModel();
            List<POS_ProductModel> prodBarcodes = new List<POS_ProductModel>();
            List<POS_ProductModel> prods = new List<POS_ProductModel>();
            List<POS_ProductTypeModel> pTypes = new List<POS_ProductTypeModel>();
            bool _bHeader = false;
            bool _bErrBreak = false;

            int iUpdateCount = 0;
            int iInsertCount = 0;
            int iBarcodeDupCount = 0;
            int iManualItemCount = 0;
            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(p_strFileName,null,true); // Readonly =  true
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            string strTypeName = "";
            string strTemp = "";

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= rowCount; i++)
            {
                float fPercent = ((float)i / (float)rowCount) * 100;
                Invoke(new Action(() =>
                {
                    progBarExport.Maximum = rowCount;
                    progBarExport.Value = i;
                    progBarExport.Refresh();
                    // show percentage of progress on the bt_Stop
                    bt_Stop.Text = "Stop ( Importing " + fPercent.ToString("0.00") + "% ... )";
                }));

                for (int j = 1; j <= colCount; j++)
                {
                    //new line
                    //if (j == 1)
                    //    Console.Write("\r\n");

                    if (_stopLoop) break;

                    //write the value to the console
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        //Console.Write("[" + i.ToString() + "," + j.ToString() + "] : " + xlRange.Cells[i, j].Value2.ToString() + "\t");
                        // The first Row of the excel file
                        if ((i == 1) && (j == 1))
                        {
                            if (xlRange.Cells[i, j].Value2.ToString().Contains("Product Inventory"))
                            {
                                _bHeader = true;
                                break;
                            }
                            else
                            {
                                _bErrBreak = true;
                            }
                        }
                        // The second Row of the excel file
                        if ((i == 2) && (j == 1))
                        {
                            if (xlRange.Cells[i, j].Value2.ToString().Contains("Date/Time Exported"))
                            {
                                _bHeader = true;
                                break;
                            }
                            else
                            {
                                _bErrBreak = true;
                            }
                        }
                        // The thired Row of the excel file (Header)
                        if ((i == 3) && (j == 1))
                        {
                            if (xlRange.Cells[i, j].Value2.ToString().Contains("Id"))
                            {
                                _bHeader = true;
                                break;
                            }
                            else
                            {
                                _bErrBreak = true;
                            }
                        }
                        _bHeader = false;
                    }
                }
                if (_bErrBreak)
                {
                    break;
                }
                if (_bHeader)
                {
                    continue;
                }
                // if Id value is nothing or empty, then 
                try
                {
                    if (xlRange.Cells[i, 1].Value2.ToString() != null)
                        strTemp = xlRange.Cells[i, 1].Value2.ToString();
                    else
                        strTemp = "0";
                }
                catch (Exception ex)
                {
                    util.Logger("Null ID found.. Row = " + i.ToString());
                    strTemp = "0";
                }

                prod.Id = int.Parse(strTemp);
                prods.Clear();
                if (prod.Id > 0)
                {
                    prods = dbPOS.Get_Product_By_ID(prod.Id);
                }
                if (prods.Count == 0)
                {
                    prod.Id = 0;
                    prod = new POS_ProductModel();
                    bProdExist = false;
                }
                else
                {
                    prod = prods[0];
                    bProdExist = true;
                }

                strTemp = xlRange.Cells[i, 2].Value2.ToString();
                if (strTemp != "")
                {
                    prod.ProductName = xlRange.Cells[i, 2].Value2.ToString();
                    util.Logger(" Product Name is " + strTemp + " " +  i.ToString());
                }
                else
                {
                    util.Logger(" [Error] Product Name is empty.. Row = " + i.ToString());
                    continue;
                }

                strTemp = xlRange.Cells[i, 3].Value2.ToString();
                if (strTemp != "")
                    prod.SecondName = xlRange.Cells[i, 3].Value2.ToString();

                strTypeName = xlRange.Cells[i, 4].Value2.ToString();
                if (strTypeName != "")
                {
                    pTypes = dbPOS.Get_ProductTypeId_By_TypeName(strTypeName);
                    if (pTypes.Count > 0)
                    {
                        prod.ProductTypeId = pTypes[0].Id;
                    }
                    else
                    {
                        pTypes[0].TypeName = strTypeName;
                        pTypes[0].IsLiquor = false;
                        pTypes[0].Id = 0;
                        dbPOS.Insert_ProductType(pTypes[0]);
                        pTypes = dbPOS.Get_ProductTypeId_By_TypeName(strTypeName);
                        if (pTypes.Count > 0)
                        {
                            prod.ProductTypeId = pTypes[0].Id;
                        }
                    }
                }
                strTemp = xlRange.Cells[i, 6].Value2.ToString();
                if (strTemp != "")
                    prod.OutUnitPrice = float.Parse(strTemp.Replace("$",""));

                prod.IsTax1 = bool.Parse(xlRange.Cells[i, 7].Value2.ToString());
                prod.IsTax2 = bool.Parse(xlRange.Cells[i, 8].Value2.ToString());
                prod.IsTax3 = bool.Parse(xlRange.Cells[i, 9].Value2.ToString());
                strTemp = xlRange.Cells[i, 10].Value2.ToString();
                if (strTemp != "")
                    prod.InUnitPrice = float.Parse(strTemp.Replace("$", ""));
                strTemp = xlRange.Cells[i, 11].Value2.ToString();
                if (strTemp != "")
                    prod.Balance = int.Parse(xlRange.Cells[i, 11].Value2.ToString());

                strTemp = xlRange.Cells[i, 12].Value2.ToString();
                if (strTemp != "")
                    prod.BarCode = xlRange.Cells[i, 12].Value2.ToString();

                strTemp = xlRange.Cells[i, 13].Value2.ToString();
                if (strTemp != "")
                    prod.PromoStartDate = strTemp;
                strTemp = xlRange.Cells[i, 14].Value2.ToString();
                if (strTemp != "")
                    prod.PromoEndDate = strTemp; // DateTime.Parse(xlRange.Cells[i, 13].Value2.ToString());
                strTemp = xlRange.Cells[i, 15].Value2.ToString();
                if (strTemp != "")
                    prod.PromoDay1 = int.Parse(xlRange.Cells[i, 15].Value2.ToString());
                strTemp = xlRange.Cells[i, 16].Value2.ToString();
                if (strTemp != "")
                    prod.PromoPrice1 = float.Parse(strTemp.Replace("$", ""));

                // check barcode conflict with existing product ?
                if (!bProdExist)
                {
                    prodBarcodes = dbPOS.Get_Product_By_BarCode(prod.BarCode);
                    if (prodBarcodes.Count > 0)
                    {
                        // skip
                        util.Logger(prod.Id.ToString() + " Duplicate barcode.." + prod.BarCode);
                        iBarcodeDupCount++;
                        continue;
                    }
                }
                if (bProdExist)
                {
                    if (!prod.IsManualItem)
                    {
                        dbPOS.Update_Product(prod);
                        util.Logger(prod.Id.ToString() + " Updated..");
                        iUpdateCount++;
                    }
                    else
                    {
                        util.Logger(prod.Id.ToString() + " Skip Manual Items.." + prod.ProductName);
                        iManualItemCount++;
                    }
                }
                else
                {
                    
                    dbPOS.Insert_Product(prod);
                    util.Logger(prod.Id.ToString() + " Inserted..");
                    iInsertCount++;
                }
            }

            util.Logger(" Total Inserted : " + iInsertCount.ToString());
            util.Logger(" Total Updated : " + iUpdateCount.ToString());
            util.Logger(" Total Barcode Duplicate : " + iBarcodeDupCount.ToString());
            util.Logger(" Total Manual Items : " + iManualItemCount.ToString());

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            
            Cursor.Current = Cursors.Default;

            if (_bErrBreak)
            {
                MessageBox.Show("ERROR : Invalid Inventory Template File..!");
                return;
            }
            MessageBox.Show("Inserted : " + iInsertCount.ToString() + System.Environment.NewLine +
                            "Updated : " + iUpdateCount.ToString() + System.Environment.NewLine +
                            "Total imported " + (iInsertCount + iUpdateCount).ToString() + System.Environment.NewLine +
                            "Barcode Duplicate (Skipped) : " + iBarcodeDupCount.ToString() + System.Environment.NewLine +
                            "Manual Items (Skipped) : " + iManualItemCount.ToString()
                            );

        }

        private void bt_Category_Click(object sender, EventArgs e)
        {
            bt_ProductExport.Enabled = false;
            //bt_ProductImport.Enabled = false;

            bt_Product.BackColor = Color.LightGreen;
            bt_LoginUser.BackColor = Color.Khaki;
            bt_Category.BackColor = Color.Yellow;
            bt_RFIDTags.BackColor = Color.LightGreen;
            bt_Tax.BackColor = Color.DarkOrange;
            bt_SysConfig.BackColor = Color.Orchid;

            DataAccessPOS dbPOS = new DataAccessPOS();
            categories = dbPOS.Get_All_Categories();
            isProduct = false;
            isLoginUser = false;
            isPType = false;
            isRFIDTag = false;
            isSysConfig = false;
            isTax = false;
            isStation = false;
            isPromotion = false;
            isCategory = true;
            isBIB = false;

            dgvData_Category_Initialize();
            if (categories.Count > 0)
            {
                foreach (var category in categories)
                {
                    this.dgvData.Rows.Add(new String[] { category.Id.ToString(),
                                                         category.CategoryName,
                                                         category.IsSeparateReport.ToString(),
                                                         category.IsDCException.ToString()
                    });
                    if (category.IsSeparateReport)
                    {
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[2].Style.BackColor = Color.Green;
                    }
                    if (category.IsDCException)
                    {
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[3].Style.BackColor = Color.Green;
                    }
                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;

                }
            }
        }
        private void dgvData_Category_Initialize()
        {
            dgvData_Adjustment();

            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 4;
            this.dgvData.Columns[0].Name = "Id";
            //this.dgvData.Columns[0].Width = 190;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[1].Name = "Category Name";
            this.dgvData.Columns[1].Width = 200;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = "Is Separate Report";
            this.dgvData.Columns[2].Width = 150;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = "Is DC Exception";
            this.dgvData.Columns[3].Width = 150;

            this.dgvData.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18F, GraphicsUnit.Pixel);
            this.dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvData.AllowUserToResizeRows = false;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvData.RowTemplate.MinimumHeight = 40;

            dgvData.AllowUserToAddRows = true;
        }

        private void chk_IsManual_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_IsManual.Checked)
                chk_IsAll.Checked = false;
            else
                chk_IsAll.Checked = true;
        }

        private void bt_BIBProd_Click(object sender, EventArgs e)
        {
            bt_ProductExport.Enabled = false;

            DataAccessPOS dbPOS = new DataAccessPOS();
            bibList = dbPOS.Get_All_ButtonInButtons_List();
            isProduct = false;
            isLoginUser = false;
            isPType = false;
            isRFIDTag = false;
            isSysConfig = false;
            isTax = false;
            isStation = false;
            isPromotion = false;
            isCategory = false;
            isBIB = true;

            dgvData_BIB_Initialize();
            if (bibList != null)
            {
                if (bibList.Count > 0)
                {
                    foreach (var bib in bibList)
                    {
                        this.dgvData.Rows.Add(new String[] { bib.PTypeName,
                                                         bib.ButtonProdId.ToString(),
                                                         bib.ButtonName,
                                                         bib.ProdCount.ToString()
                    });

                        this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;

                    }
                }
            }
        }
        private void dgvData_BIB_Initialize()
        {
            dgvData_Adjustment();

            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 4;
            this.dgvData.Columns[0].Name = "Type Name";
            this.dgvData.Columns[0].Width = 150;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[1].Name = "Button Prod Id";
            this.dgvData.Columns[1].Width = 150;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = "Button Name";
            this.dgvData.Columns[2].Width = 200;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = "Product Count";
            this.dgvData.Columns[3].Width = 150;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvData.DefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18F, GraphicsUnit.Pixel);
            this.dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvData.AllowUserToResizeRows = false;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvData.RowTemplate.MinimumHeight = 40;

            // not allow to add new row
            dgvData.AllowUserToAddRows = false;
        }
    }
}
