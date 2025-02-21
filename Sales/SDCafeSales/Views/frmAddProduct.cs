using SDCafeCommon.Model;
using SDCafeCommon.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenFoodFacts4Net.Json;
using SDCafeCommon.DataAccess;

namespace SDCafeSales.Views
{
    public partial class frmAddProduct : Form
    {
        frmSalesMain FrmSalesMain;

        Utility util = new Utility();
        public CustomButton selectedBTN;
        public string m_strBarCode;
        public String m_strNewPrice;
        
        public String m_strBottleDeposit;//Feature #3703
        public String m_strRecyclingFee;//Feature #3703
        public String m_strChillCharge;//Feature #3703

        public bool b_IsPrice;//Feature #3703
        public bool b_IsDeposit;//Feature #3703
        public bool b_IsRecyclingFee;//Feature #3703
        public bool b_IsChillCharge;//Feature #3703

        public String m_strProductName;
        public double m_dblUnitPrice = 0;
        public double m_dblDeposit = 0;//Feature #3703
        public double m_dblRecyclingFee = 0;//Feature #3703
        public double m_dblChillCharge = 0;//Feature #3703

        public bool bTax1 = true, bTax2 = false, bTax3 = false;
        public bool m_bAddNow;
        public float p_Amount { get; set; }
        public string p_PName { get; set; }

        public bool p_IsTax1 { get; set; }
        public bool p_IsTax2 { get; set; }
        public bool p_IsTax3 { get; set; }
        public string p_strCategory { get; set; }
        //public string p_strSelectedType { get; set; }

        OpenFoodFacts4Net.ApiClient.Client off_Apiclient = new OpenFoodFacts4Net.ApiClient.Client(); //Feature #3632
        List<OpenFoodFacts4Net.Json.Data.Product> off_Products = new List<OpenFoodFacts4Net.Json.Data.Product>(); //Feature #3632
        //List<OpenFoodFacts4Net.Json.Data.GetProductResponse> off_ProdResp = new List<OpenFoodFacts4Net.Json.Data.GetProductResponse>();
        Task<OpenFoodFacts4Net.Json.Data.GetProductResponse> off_ProdResp = null; //Feature #3632

        private string m_strBrand;
        private string m_strSize;

        public Color[] btColor =
{
            Color.Crimson,
            Color.SeaGreen,
            Color.DarkOrange, // Num buttons
            Color.OrangeRed,
            Color.MediumPurple,
            Color.SaddleBrown,
            Color.LimeGreen
           // 238,79,82 0X00524FEE,
           // 50,185,87 0x0057B932,
           //35,118,199 0x00C77623,
           // 243,157,33 0x00219DF3,
           // 136,60,219 0x00DB3C88,
           //47,74,126 0x007E4A2F,
           // 0,102,0 0x00006600
        };
        private Process proc;

        public POS_ProductModel p_NewProduct = new POS_ProductModel();
        private string p_strImageUrl;

        public frmAddProduct(frmSalesMain _FrmSalesMain)
        {
            InitializeComponent();
            this.FrmSalesMain = _FrmSalesMain;
            m_strNewPrice = String.Empty;
            m_bAddNow = false;
        }
        public void Set_Amount(double pAmount)
        {
            p_Amount = (float)pAmount;
            txt_UnitlPrice.Text = pAmount.ToString("C2");
        }
        public void Set_ProductName(string pPName)
        {
            p_PName = pPName;
            txt_ProdlName.Text = p_PName;
        }
        internal void Set_BarCode(string pBarCode)
        {
            m_strBarCode = pBarCode;
            txt_BarCode.Text = m_strBarCode;
        }
        private void cb_tax1_Changed(object sender, EventArgs e)
        {
            bTax1 = cb_Tax1.Checked;
        }

        private void cb_tax2_Changed(object sender, EventArgs e)
        {
            bTax2 = cb_Tax2.Checked;
        }

        private void cb_Tax3_Changed(object sender, EventArgs e)
        {
            bTax3 = cb_Tax3.Checked;
        }

        private void txt_ProductName_Click(object sender, EventArgs e)
        {
            //run on screen keyboard
            proc = Process.Start("osk.exe");
            txt_ProdlName.SelectAll();
        }

        private async void frmAddProduct_Load(object sender, EventArgs e)
        {
            //this.Top = Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - (this.Height / 2);
            //this.Left = Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - (this.Width / 2);
            //lbl_Titie.Text = "Welcom to AB SD Cafeteria Office Module";
            int xPos = 2;
            int yPos = 2;
            int iLines = 0;
            m_bAddNow = false;
            //////////////////////////////////////////////////////
            // Declare and assign number of buttons = 20 
            //System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[30];
            CustomButton[] btnNums = new CustomButton[13];
            //////////////////////////////////////////////////////
            // Create (20) Buttons: 
            for (int i = 0; i < 13; i++)
            {
                // Initialize one variable 
                //btnArray[i] = new System.Windows.Forms.Button();
                btnNums[i] = new CustomButton();
            }
            int n = 0;
            int iSpace = 2;
            int btWidth = pnlNums.Width - (iSpace * 3);
            int btHeight = pnlNums.Height - (iSpace * 5);
            while (n < 13)
            {
                btnNums[n].Tag = n + 1; // Tag of button 
                btnNums[n].Width = btWidth / 3; // Width of button 
                btnNums[n].Height = btHeight / 5; // Height of button
                btnNums[n].Font = new Font("Arial", 28, FontStyle.Bold);
                //btnArray[n].BackColor = Color.LightSteelBlue;
                btnNums[n].ForeColor = Color.WhiteSmoke;
                btnNums[n].CornerRadius = 30;
                //btnNums[n].RoundCorners = Corners.TopLeft | Corners.TopRight | Corners.BottomLeft;
                btnNums[n].RoundCorners = Corners.All;
                //btnArray[n].AutoSize = true;
                /////////////////////////////////////////////////////
                // 4 Buttons in one line
                /////////////////////////////////////////////////////
                if (n >= 3) // Location of second line of buttons: 
                {
                    if (n % 3 == 0)
                    {
                        xPos = 2;
                        yPos = yPos + btnNums[n].Height + iSpace;
                        iLines++;
                    }
                }
                if (n + 1 == 13)
                {
                    btnNums[n].Width = btWidth;
                }
                btnNums[n].BackColor = btColor[2];
                // Location of button: 
                btnNums[n].Left = xPos;
                btnNums[n].Top = yPos;
                // Add buttons to a Panel: 
                pnlNums.Controls.Add(btnNums[n]);  // Let panel hold the Buttons 
                xPos = xPos + btnNums[n].Width + iSpace;    // Left of next button 
                                                            // Write English Character: 
                /* **************************************************************** 
                    Menu item button text
                //**************************************************************** */

                //btnArray[n].Text = ((char)(n + 65)).ToString() + (n+1).ToString();
                btnNums[n].Text = (n + 1).ToString();
                if (n + 1 == 10)
                {
                    btnNums[n].Text = "OK";
                    btnNums[n].BackColor = Color.ForestGreen;
                    btnNums[n].ForeColor = Color.White;
                }
                if (n + 1 == 11)
                {
                    btnNums[n].Text = "0";
                }
                if (n + 1 == 12)
                {
                    btnNums[n].Text = "DEL";
                    btnNums[n].BackColor = Color.Maroon;
                    btnNums[n].ForeColor = Color.White;
                }
                if (n + 1 == 13)
                {
                    btnNums[n].Text = "EXIT";
                    btnNums[n].BackColor = Color.Gray;
                    btnNums[n].ForeColor = Color.White;
                }
                // the Event of click Button 
                btnNums[n].Click += new System.EventHandler(ClickNumberButton);
                n++;
            }

            LookUpProductFromOpenFoodFacts();

            pnlNums.Enabled = true; // not need now to this button now 

            bTax1 = p_IsTax1;
            bTax2 = p_IsTax2;
            bTax3 = p_IsTax3;
            
            cb_Tax1.Visible = true;
            cb_Tax2.Visible = true;
            cb_Tax3.Visible = true;
            cb_Tax1.Text = FrmSalesMain.strTax1Name;
            cb_Tax2.Text = FrmSalesMain.strTax2Name;
            cb_Tax3.Text = FrmSalesMain.strTax3Name;

            cb_Tax1.Checked = bTax1;
            cb_Tax2.Checked = bTax2;
            cb_Tax3.Checked = bTax3;

            LoadProductCategories();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.BringToFront();
            this.TopMost = true;
            this.TopMost = false;

            b_IsPrice = true;//Feature #3703
            b_IsDeposit = false;//Feature #3703
            b_IsRecyclingFee = false;//Feature #3703
            b_IsChillCharge = false;//Feature #3703

        }
        ////Feature #3632
        private async void LookUpProductFromOpenFoodFacts()
        {
            try
            {
                off_ProdResp = off_Apiclient.GetProductAsync(m_strBarCode);
                await Task.WhenAll(off_ProdResp);
            }
            catch (Exception ex)
            {
                util.Logger("Barcode Not found : " + ex.Message);
                off_ProdResp = null;
            }

            if (off_ProdResp != null)
            {
                if (off_ProdResp.Result != null)
                {
                    if (off_ProdResp.Result.Product == null) return;
                    if (off_ProdResp.Result.Product.ProductName != null)
                        util.Logger("Product found : Product = " + off_ProdResp.Result.Product.ProductName);
                    if (off_ProdResp.Result.Product.Categories != null)
                        util.Logger("Product found : Categories = " + off_ProdResp.Result.Product.Categories);
                    if (off_ProdResp.Result.Product.ImageUrl != null)
                        util.Logger("Product found : ImageUrl = " + off_ProdResp.Result.Product.ImageUrl);
                    if (off_ProdResp.Result.Product.ServingSize != null)
                    {
                        util.Logger("Product found : ServingSize = " + off_ProdResp.Result.Product.ServingSize);
                        m_strSize = off_ProdResp.Result.Product.ServingSize;
                    }
                    if (off_ProdResp.Result.Product.BrandsTags != null)
                    {
                        List<string> brands = new List<string>();
                        brands = off_ProdResp.Result.Product.BrandsTags.ToList();
                        foreach (string brand in brands)
                        {
                            util.Logger("Product found : Brand = " + brand);
                            m_strBrand = brand;
                        }
                    }
                    if (off_ProdResp.Result.Product.ProductName != null)
                    {
                        if (off_ProdResp.Result.Product.ProductName != "")
                            txt_ProdlName.Text = off_ProdResp.Result.Product.ProductName;
                        else
                            txt_ProdlName.Text = "";
                    }
                    txt_UnitlPrice.Focus();
                }
                else
                {
                    txt_ProdlName.Text = "";
                    txt_ProdlName.Focus();
                }
            }
            else
            {
                txt_ProdlName.Focus();
            }
        }

        private void cbBox_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            p_strCategory = (string)cmb.SelectedItem.ToString();
        }

        private void txt_UnitlPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if enter key is pressed
            if (e.KeyChar == (char)Keys.Enter)
            {
                CustomButton btn = new CustomButton();
                btn.Text = "OK";
                ClickNumberButton(btn, e);
            }
        }

        private void txt_UnitlPrice_Click(object sender, EventArgs e)
        {
            b_IsPrice = true;
            b_IsDeposit = false;
            b_IsRecyclingFee = false;
            b_IsChillCharge = false;
        }

        private void txt_Deposit_Click(object sender, EventArgs e)
        {
            b_IsPrice = false;
            b_IsDeposit = true;
            b_IsRecyclingFee = false;
            b_IsChillCharge = false;
        }

        private void txt_RecyclingFee_Click(object sender, EventArgs e)
        {
            b_IsPrice = false;
            b_IsDeposit = false;
            b_IsRecyclingFee = true;
            b_IsChillCharge = false;
        }

        private void txt_ChillCharge_Click(object sender, EventArgs e)
        {
            b_IsPrice = false;
            b_IsDeposit = false;
            b_IsRecyclingFee = false;
            b_IsChillCharge = true;
        }

        private void LoadProductCategories()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            List<POS_ProductTypeModel>  prodTypes = new List<POS_ProductTypeModel>();
            prodTypes = dbPOS.Get_All_ProductTypes();
            if (prodTypes.Count > 0)
            {
                cbBox_Category.Items.Clear();
                foreach (POS_ProductTypeModel prodType in prodTypes)
                {
                    cbBox_Category.Items.Add(prodType.TypeName);
                }
            }
        }
        private bool ValidateNumbers()
        {
            bool bValid = false;
            m_dblDeposit = 0;
            m_dblRecyclingFee = 0;
            m_dblChillCharge = 0;

            try
            {
                if (m_strNewPrice != "")
                {
                    m_dblUnitPrice = Convert.ToDouble(m_strNewPrice);
                }
                if (m_strBottleDeposit != "")
                {
                    m_dblDeposit = Convert.ToDouble(m_strBottleDeposit);
                }
                if (m_strRecyclingFee != "")
                {
                    m_dblRecyclingFee = Convert.ToDouble(m_strRecyclingFee);
                }
                if (m_strChillCharge != "")
                {
                    m_dblChillCharge = Convert.ToDouble(m_strChillCharge);
                }
                bValid = true;
            }
            catch (Exception ex)
            {
                util.Logger("Error in ValidateNumbers : " + ex.Message);
                bValid = false;
            }

            return bValid;
        }
        private void ClickNumberButton(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            CustomButton btn = (CustomButton)sender;
            btn.BackColor = Color.Yellow;
            btn.ForeColor = Color.DarkBlue;
            if (selectedBTN != null)
            {
                selectedBTN.BackColor = btColor[2];
                selectedBTN.ForeColor = Color.Black;
            }
            //selectedBTN = (Button)sender;
            selectedBTN = (CustomButton)sender;
            if (btn.Text == "OK")  // OK
            {
                //this.Show();
                m_strProductName = txt_ProdlName.Text;
                m_strNewPrice = txt_UnitlPrice.Text;
                if (m_strNewPrice == "") return;

                bool bNumberValid = ValidateNumbers();
                if (!bNumberValid)
                {
                    MessageBox.Show("Please enter valid number for Price, Deposit, Recycling Fee, Chill Charge", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bTax1 = cb_Tax1.Checked;
                bTax2 = cb_Tax2.Checked;
                bTax3 = cb_Tax3.Checked;
                // p_NewProduct setting
                p_NewProduct.BarCode = m_strBarCode;
                p_NewProduct.ProductName = m_strProductName;
                p_NewProduct.SecondName = "NEW ON " + DateTime.Now.ToString("yyyy-MM-dd");
                p_NewProduct.OutUnitPrice = (float)m_dblUnitPrice;
                p_NewProduct.IsTax1 = bTax1;
                p_NewProduct.IsTax2 = bTax2;
                p_NewProduct.IsTax3 = bTax3;
                p_NewProduct.Balance = 0;
                p_NewProduct.IsSoldOut = false;
                p_NewProduct.IsManualItem = false;
                p_NewProduct.IsMainSalesButton = false;
                p_NewProduct.IsSalesButton = true;
                p_NewProduct.ForeColor = Color.Black.ToArgb().ToString();
                p_NewProduct.BackColor = Color.White.ToArgb().ToString();
                p_NewProduct.IsPrinter1 = false;
                p_NewProduct.IsPrinter2 = false;
                p_NewProduct.IsPrinter3 = false;
                p_NewProduct.IsPrinter4 = false;
                p_NewProduct.IsPrinter5 = false;
                p_NewProduct.MemoText = string.Empty;
                p_NewProduct.Deposit = (float)m_dblDeposit; //Feature #3703
                p_NewProduct.RecyclingFee = (float)m_dblRecyclingFee; //Feature #3703
                p_NewProduct.ChillCharge = (float)m_dblChillCharge; //Feature #3703
                p_NewProduct.PromoStartDate = string.Empty;
                p_NewProduct.PromoEndDate = string.Empty;
                p_NewProduct.PromoDay1 = 0;
                p_NewProduct.PromoDay2 = 0;
                p_NewProduct.PromoDay3 = 0;
                p_NewProduct.PromoPrice1 = 0;
                p_NewProduct.PromoPrice2 = 0;
                p_NewProduct.PromoPrice3 = 0;
                p_NewProduct.IsTaxInverseCalculation = false;
                p_NewProduct.Brand = m_strBrand;
                p_NewProduct.Size = m_strSize;
                p_NewProduct.CategoryId = 1; // Default Category to 'Sales' Bug #3698
                // Check Product Type
                if (p_strCategory != "")
                {
                    DataAccessPOS dbPOS = new DataAccessPOS();
                    List<POS_ProductTypeModel> prodTypes = new List<POS_ProductTypeModel>();
                    prodTypes = dbPOS.Get_ProductTypeId_By_TypeName(p_strCategory);
                    if (prodTypes.Count > 0)
                    {
                        p_NewProduct.ProductTypeId = prodTypes[0].Id;
                    }
                    else
                    {
                        p_NewProduct.ProductTypeId = 0;
                    }
                }
                else
                {
                    p_NewProduct.ProductTypeId = 0;
                }
                m_bAddNow = true;
                this.Close();
                return;
            }
            if (btn.Text == "DEL")  // DELETE
            {
                if (b_IsPrice)
                {
                    m_strNewPrice = string.Empty;
                    txt_UnitlPrice.Text = m_strNewPrice;
                    m_dblUnitPrice = 0;
                }
                else if (b_IsDeposit)
                {
                    m_strBottleDeposit = string.Empty;
                    txt_Deposit.Text = m_strBottleDeposit;
                }
                else if (b_IsRecyclingFee)
                {
                    m_strRecyclingFee = string.Empty;
                    txt_RecyclingFee.Text = m_strRecyclingFee;
                }
                else if (b_IsChillCharge)
                {
                    m_strChillCharge = string.Empty;
                    txt_ChillCharge.Text = m_strChillCharge;
                }
                m_bAddNow = false;
                return;
            }
            if (btn.Text == "EXIT")  // OK
            {
                m_strNewPrice = string.Empty;
                m_dblUnitPrice = 0;
                m_bAddNow = false;
                this.Close();
                return;
            }

            if (b_IsPrice)
            {
                txt_UnitlPrice.Text = m_strNewPrice + btn.Text;
                //if ((txt_NewPrice.Text.Length > 2) && (txt_NewPrice.Text.IndexOf('.') < 0))
                if (txt_UnitlPrice.Text.Length > 2)
                {
                    string strTemp = m_strNewPrice + btn.Text;
                    int i = strTemp.IndexOf('.');
                    if (strTemp.IndexOf('.') > -1)
                    {
                        strTemp = strTemp.Remove(strTemp.IndexOf('.'), 1);
                    }
                    txt_UnitlPrice.Text = strTemp.Insert(strTemp.Length - 2, ".");
                }
                m_strNewPrice = txt_UnitlPrice.Text;
            }
            else if (b_IsDeposit)
            {
                txt_Deposit.Text = m_strBottleDeposit + btn.Text;
                if (txt_Deposit.Text.Length > 2)
                {
                    string strTemp = m_strBottleDeposit + btn.Text;
                    int i = strTemp.IndexOf('.');
                    if (strTemp.IndexOf('.') > -1)
                    {
                        strTemp = strTemp.Remove(strTemp.IndexOf('.'), 1);
                    }
                    txt_Deposit.Text = strTemp.Insert(strTemp.Length - 2, ".");
                }
                m_strBottleDeposit = txt_Deposit.Text;
            }
            else if (b_IsRecyclingFee)
            {
                txt_RecyclingFee.Text = m_strRecyclingFee + btn.Text;
                if (txt_RecyclingFee.Text.Length > 2)
                {
                    string strTemp = m_strRecyclingFee + btn.Text;
                    int i = strTemp.IndexOf('.');
                    if (strTemp.IndexOf('.') > -1)
                    {
                        strTemp = strTemp.Remove(strTemp.IndexOf('.'), 1);
                    }
                    txt_RecyclingFee.Text = strTemp.Insert(strTemp.Length - 2, ".");
                }
                m_strRecyclingFee = txt_RecyclingFee.Text;
            }
            else if (b_IsChillCharge)
            {
                txt_ChillCharge.Text = m_strChillCharge + btn.Text;
                if (txt_ChillCharge.Text.Length > 2)
                {
                    string strTemp = m_strChillCharge + btn.Text;
                    int i = strTemp.IndexOf('.');
                    if (strTemp.IndexOf('.') > -1)
                    {
                        strTemp = strTemp.Remove(strTemp.IndexOf('.'), 1);
                    }
                    txt_ChillCharge.Text = strTemp.Insert(strTemp.Length - 2, ".");
                }
                m_strChillCharge = txt_ChillCharge.Text;
            }
        }
    }

}
