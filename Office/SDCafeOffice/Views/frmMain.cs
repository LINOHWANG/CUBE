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

        Utility util = new Utility();
        private bool isProduct = false;
        private bool isLoginUser = false;
        private bool isPType = false;
        private bool isRFIDTag = false;
        private bool isSysConfig = false;
        private bool isTax = false;
        private bool isStation = false;

        public frmProduct FrmProd;
        public frmProdType FrmProdType;
        public frmSysConfig FrmSysConfig;
        public frmLoginUser FrmLoginUser;
        public frmStations FrmStations;

        public frmSalesReport FrmSalesReport;


        //private bool isSystem = false;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //pnl_User.Hide();
            //pnl_Product.Hide();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmLogOn = new frmLogOn();
            FrmLogOn.Show();

        }
        private void dgvData_Prod_Initialize()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 12;
            this.dgvData.Columns[0].Name = "Id";
            this.dgvData.Columns[0].Width = 50;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvData.Columns[1].Name = "Product Name";
            this.dgvData.Columns[1].Width = 120;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvData.Columns[2].Name = "Second Name";
            this.dgvData.Columns[2].Width = 120;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvData.Columns[3].Name = "UnitPrice";
            this.dgvData.Columns[3].Width = 120;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[4].Name = dbPOS.Get_SysConfig_By_Name("Tax1")[0].ConfigValue;
            this.dgvData.Columns[4].Width = 50;
            this.dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[5].Name = dbPOS.Get_SysConfig_By_Name("Tax2")[0].ConfigValue; // "Tax2";
            this.dgvData.Columns[5].Width = 50;
            this.dgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[6].Name = dbPOS.Get_SysConfig_By_Name("Tax3")[0].ConfigValue; // "Tax3";
            this.dgvData.Columns[6].Width = 50;
            this.dgvData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[7].Name = "PRT1";
            this.dgvData.Columns[7].Width = 50;
            this.dgvData.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[8].Name = "PRT2";
            this.dgvData.Columns[8].Width = 50;
            this.dgvData.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[9].Name = "PRT3";
            this.dgvData.Columns[9].Width = 50;
            this.dgvData.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[10].Name = "PRT4";
            this.dgvData.Columns[10].Width = 50;
            this.dgvData.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[11].Name = "PRT5";
            this.dgvData.Columns[11].Width = 50;
            this.dgvData.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
        }


        private void bt_Product_Click(object sender, EventArgs e)
        {
            //pnl_Product.Show();
            //pnl_User.Hide();
            bt_Product.BackColor = Color.Yellow;
            bt_LoginUser.BackColor = Color.Khaki;
            bt_ProdType.BackColor = Color.LightGreen;
            bt_RFIDTags.BackColor = Color.LightGreen;
            bt_Tax.BackColor = Color.DarkOrange;
            bt_SysConfig.BackColor = Color.Orchid;

            DataAccessPOS dbPOS = new DataAccessPOS();
            prods = dbPOS.Get_All_Products();
            isProduct = true;
            isLoginUser = false;
            isPType = false;
            isRFIDTag = false;
            isSysConfig = false;
            isTax = false;
            isStation = false;

            dgvData_Prod_Initialize();
            if (prods.Count > 0)
            {
                foreach (var prod in prods)
                {
                    this.dgvData.Rows.Add(new String[] { prod.Id.ToString(),
                                                         prod.ProductName,
                                                         prod.SecondName,
                                                         prod.OutUnitPrice.ToString(),
                                                         prod.IsTax1.ToString(),
                                                         prod.IsTax2.ToString(),
                                                         prod.IsTax3.ToString(),
                                                         prod.IsPrinter1.ToString(),
                                                         prod.IsPrinter2.ToString(),
                                                         prod.IsPrinter3.ToString(),
                                                         prod.IsPrinter4.ToString(),
                                                         prod.IsPrinter5.ToString()
                    });
                    if (prod.IsTax1) 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[4].Style.BackColor = Color.Green; 
                    }
                    else 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[4].Style.BackColor = Color.LightSalmon; 
                    };
                    if (prod.IsTax2) 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[5].Style.BackColor = Color.Green; 
                    }
                    else 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[5].Style.BackColor = Color.LightSalmon; 
                    };
                    if (prod.IsTax3) 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[6].Style.BackColor = Color.Green; 
                    }
                    else 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[6].Style.BackColor = Color.LightSalmon; 
                    };
                    if (prod.IsPrinter1) 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[7].Style.BackColor = Color.Green; 
                    }
                    else 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[7].Style.BackColor = Color.LightSalmon; 
                    };
                    if (prod.IsPrinter2) 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[8].Style.BackColor = Color.Green; 
                    }
                    else 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[8].Style.BackColor = Color.LightSalmon; 
                    };
                    if (prod.IsPrinter3) 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[9].Style.BackColor = Color.Green; 
                    }
                    else 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[9].Style.BackColor = Color.LightSalmon; 
                    };
                    if (prod.IsPrinter4) 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[10].Style.BackColor = Color.Green; 
                    }
                    else 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[10].Style.BackColor = Color.LightSalmon; 
                    };
                    if (prod.IsPrinter5) 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[11].Style.BackColor = Color.Green; 
                    }
                    else 
                    { 
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[11].Style.BackColor = Color.LightSalmon; 
                    };

                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;
                }
            }
        }
        private void dgvData_LoginUser_Initialize()
        {
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
        }
        private void bt_LoginUser_Click(object sender, EventArgs e)
        {
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

            dgvData_LoginUser_Initialize();
            if (loginUsers.Count > 0)
            {
                foreach (var loginUser in loginUsers)
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


 

        private void bt_ProdType_Click(object sender, EventArgs e)
        {
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

            dgvData_ProdType_Initialize();
            if (ptypes.Count > 0)
            {
                foreach (var ptype in ptypes)
                {
                    this.dgvData.Rows.Add(new String[] { ptype.Id.ToString(),
                                                         ptype.TypeName,
                                                         ptype.IsLiquor.ToString(),
                                                         ptype.IsBatchDonation.ToString(),
                                                         ptype.IsBatchDiscount.ToString()
                    });
                    if (ptype.IsBatchDonation)
                    {
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[3].Style.BackColor = Color.Green;
                    }
                    if (ptype.IsBatchDiscount)
                    {
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[4].Style.BackColor = Color.Green;
                    }
                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;

                }
            }
        }
        private void dgvData_ProdType_Initialize()
        {
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
            this.dgvData.Columns[2].Name = "Is Liquor";
            this.dgvData.Columns[2].Width = 150;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = "Is Donation";
            this.dgvData.Columns[3].Width = 150;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[4].Name = "Is Discount";
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
        }

        private void bt_SysConfig_Click(object sender, EventArgs e)
        {
            bt_Product.BackColor = Color.LightGreen;
            bt_LoginUser.BackColor = Color.Khaki;
            bt_ProdType.BackColor = Color.LightGreen;
            bt_RFIDTags.BackColor = Color.LightGreen;
            bt_Tax.BackColor = Color.DarkOrange;
            bt_SysConfig.BackColor = Color.Yellow;

            DataAccessPOS dbPOS = new DataAccessPOS();
            sysconfs = dbPOS.Get_All_SysConfigs();
            isProduct = false;
            isLoginUser = false;
            isPType = false;
            isRFIDTag = false;
            isSysConfig = true;
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
        }
        private void dgvData_Stations_Initialize()
        {
            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 7;
            this.dgvData.Columns[0].Name = "ComputerName";
            this.dgvData.Columns[0].Width = 10;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[1].Name = "Station";
            this.dgvData.Columns[1].Width = 100;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = "StationName";
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
        }
        private void bt_Tax_Click(object sender, EventArgs e)
        {
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

            dgvData_Tax_Initialize();
            if (taxs.Count > 0)
            {
                foreach (var tax in taxs)
                {
                    this.dgvData.Rows.Add(new String[] { tax.Code,
                                                         tax.Tax1.ToString(),
                                                         tax.Tax2.ToString(),
                                                         tax.Tax3.ToString()
                    });
                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;

                }
            }
        }
        private void dgvData_Tax_Initialize()
        {
            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 4;
            this.dgvData.Columns[0].Name = "Code";
            this.dgvData.Columns[0].Width = 150;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[1].Name = "Tax1";
            this.dgvData.Columns[1].Width = 100;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = "Tax2";
            this.dgvData.Columns[2].Width = 100;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = "Tax3";
            this.dgvData.Columns[3].Width = 100;
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
        }
        private void dgvData_MouseClick(object sender, MouseEventArgs e)
        {
            String strSelProdId = String.Empty;
            String strSelConfigId = String.Empty;
            String strSelLoginId = String.Empty;
            String strTypeId = String.Empty;
            String strHostName = String.Empty;

            Int32 selectedRowCount =
                dgvData.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
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
            if (isProduct)
            {
                if (dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value == null)
                {
                    strSelProdId = String.Empty;
                }
                else
                {
                    strSelProdId = dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
                FrmProd = new frmProduct(strSelProdId);
                FrmProd.ShowDialog();
                bt_Product.PerformClick();
            }
            if (isSysConfig)
            {
                if (dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value == null)
                {
                    strSelConfigId = String.Empty;
                }
                else
                {
                    strSelConfigId = dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
                FrmSysConfig = new frmSysConfig(strSelConfigId);
                FrmSysConfig.ShowDialog();
                bt_SysConfig.PerformClick();
            }
            if (isLoginUser)
            {
                if (dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value == null)
                {
                    strSelLoginId = String.Empty;
                }
                else
                {
                    strSelLoginId = dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
                FrmLoginUser = new frmLoginUser(strSelLoginId);
                FrmLoginUser.ShowDialog();
                bt_LoginUser.PerformClick();
            }
            
            if (isPType)
            {
                if (dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value == null)
                {
                    strTypeId = String.Empty;
                }
                else
                {
                    strTypeId = dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
                FrmProdType = new frmProdType(strTypeId);
                FrmProdType.ShowDialog();
                bt_ProdType.PerformClick();
            }
            if (isStation)
            {
                if (dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value == null)
                {
                    strHostName = String.Empty;
                }
                else
                {
                    strHostName = dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[0].Value.ToString();
                }
                FrmStations = new frmStations(strHostName);
                FrmStations.ShowDialog();
                bt_Station.PerformClick();
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void bt_Station_Click(object sender, EventArgs e)
        {
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
            FrmSalesReport = new frmSalesReport();
            FrmSalesReport.ShowDialog();
        }
    }
}
