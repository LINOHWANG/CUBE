using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;
using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
using SDCafeCommon.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDCafeOffice.Views
{
    public partial class frmSalesButton : Form
    {
        private List<POS_SalesButtonModel> salesButtonList = new List<POS_SalesButtonModel>();
        private List<POS_ProductModel> prods = new List<POS_ProductModel>();
        private CustomButton[] btnArray = new CustomButton[100];
        private int iButtonCount = 0;
        private int m_intQueryTop = 0;
        private int m_Rows = 0;
        private int m_Cols = 0;
        private CustomButton m_btnSelected;

        public frmSalesButton()
        {
            InitializeComponent();
        }

        private void frmSalesButton_Load(object sender, EventArgs e)
        {
            m_intQueryTop = 100;
            LoadSalesButtonSettings();
        }

        private void LoadSalesButtonSettings()
        {
            int xPos = 0;
            int yPos = 0;
            int iLines = 0;
            int iColor = 0;

            btnArray = new CustomButton[m_intQueryTop];
            for (int i = 0; i < m_intQueryTop; i++)
            {
                // Initialize one variable 
                //btnArray[i] = new System.Windows.Forms.Button();
                btnArray[i] = new CustomButton();
                btnArray[i].Click -= new System.EventHandler(ClickMenuButton);
            }
            m_Rows = 0;
            m_Cols = 0;
            // get Rows and Cols from sysConfig
            DataAccessPOS dbPOS = new DataAccessPOS();
            List<POS_SysConfigModel> sysConfigs = new List<POS_SysConfigModel>();
            POS_SysConfigModel sysConfig = new POS_SysConfigModel();
            sysConfigs = dbPOS.Get_SysConfig_By_Name("SALESBUTTON_ROWS");
            if (sysConfigs.Count > 0 ) {
                m_Rows = Convert.ToInt32(sysConfigs[0].ConfigValue);
                txt_Rows.Text = m_Rows.ToString();
            }
            sysConfigs = dbPOS.Get_SysConfig_By_Name("SALESBUTTON_COLS");
            if (sysConfigs.Count > 0)
            {
                m_Cols = Convert.ToInt32(sysConfigs[0].ConfigValue);
                txt_Cols.Text = m_Cols.ToString();
            }

            salesButtonList = dbPOS.Get_All_SalesButton();
            if (salesButtonList.Count > 0)
            {
                PopulateSalesButtons();

            }
            else
            {
                //MessageBox.Show("No Sales Button Settings found.");
                return;
            }
        }

        private void PopulateSalesButtons()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            POS_ProductModel prod = new POS_ProductModel();
            FontFamily fontFamily = new FontFamily("Arial");
            FontStyle fontStyle = new FontStyle();
            string strProdName = "";

            foreach (POS_SalesButtonModel salesButton in salesButtonList)
            {
                if (salesButton.ProductId > 0)
                {
                    prod = dbPOS.Get_One_Product_By_ID(salesButton.ProductId);
                    if (prod == null)
                    {
                        strProdName = "No Product";
                    }
                    else
                    {
                        strProdName = prod.ProductName;
                    }
                }
                else
                {
                    prod.ProductName = "No Product";
                    strProdName = prod.ProductName;
                }
                btnArray[iButtonCount].Name = salesButton.Row.ToString() + "," + salesButton.Col.ToString();
                btnArray[iButtonCount].Text = strProdName;
                fontFamily = new FontFamily(salesButton.FontName);
                fontStyle = (FontStyle)salesButton.FontStyle;
                btnArray[iButtonCount].Font = new System.Drawing.Font(fontFamily, salesButton.FontSize, fontStyle);
                btnArray[iButtonCount].ForeColor = Color.FromName(salesButton.ForeColor);
                btnArray[iButtonCount].BackColor = Color.FromName(salesButton.BackColor);
                btnArray[iButtonCount].Left = (int)salesButton.ButtonLeft;
                btnArray[iButtonCount].Top = (int)salesButton.ButtonTop;
                btnArray[iButtonCount].Width = (int)salesButton.Width;
                btnArray[iButtonCount].Height = (int)salesButton.Height;
                btnArray[iButtonCount].Tag = salesButton.ProductId;
                btnArray[iButtonCount].CornerRadius = 30;
                btnArray[iButtonCount].RoundCorners = SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight | SDCafeCommon.Utilities.Corners.BottomLeft;
                btnArray[iButtonCount].Click += new System.EventHandler(ClickMenuButton);

                if ((salesButton.IsVisible == false) || (salesButton.ProductId == 0))
                {
                    btnArray[iButtonCount].ForeColor = Color.White;
                    btnArray[iButtonCount].BackColor = Color.DimGray;
                }
                pnlMenu.Controls.Add(btnArray[iButtonCount]);
                iButtonCount++;
            }
        }

        private void ClickMenuButton(object sender, EventArgs e)
        {
            int iProdId = 0;
            int iRow = 0;
            int iCol = 0;

            m_btnSelected = (CustomButton)sender;
            // 
            string[] strRowCol;
            // get row and col from the button name property

            strRowCol = m_btnSelected.Name.Split(',');
            if (strRowCol.Length != 2)
            {
                MessageBox.Show("Invalid Row and Col");
                return;
            }
            iRow = Int32.Parse(strRowCol[0]);
            iCol = Int32.Parse(strRowCol[1]);

            txt_BackColor.Text = m_btnSelected.BackColor.Name;
            txt_ForeColor.Text = m_btnSelected.ForeColor.Name;
            txt_FontName.Text = m_btnSelected.Font.Name;
            txt_FontSize.Text = m_btnSelected.Font.Size.ToString();
            txt_BtnCol.Text = iRow.ToString();
            txt_BtnRow.Text = iCol.ToString();
            //txt_FontStyle.Text = m_btnSelected.Font.Style.ToString();
            txt_ProdId.Text = m_btnSelected.Tag.ToString();
            iProdId = Convert.ToInt32(m_btnSelected.Tag);
            if (iProdId > 0)
            {
                DataAccessPOS dbPOS = new DataAccessPOS();
                POS_ProductModel prod = dbPOS.Get_One_Product_By_ID(iProdId);
                txt_ProdName.Text = prod.ProductName;
            }
            else
            {
                txt_ProdName.Text = "No Product";
            }
            chk_Visible.Checked = true;

        }

        private void bt_SetLayout_Click(object sender, EventArgs e)
        {
            int xPos = 0;
            int yPos = 0;
            int iBtnCount = 0;
            int iColor = 0;
            int iLineWidth = 0;
            int iLineHeight = 0;
            int iSpacing = 5;

            btnArray = new CustomButton[m_intQueryTop];
            for (int i = 0; i < m_intQueryTop; i++)
            {
                // Initialize one variable 
                //btnArray[i] = new System.Windows.Forms.Button();
                btnArray[i] = new CustomButton();
                btnArray[i].Click -= new System.EventHandler(ClickMenuButton);
            }

            m_Rows = Convert.ToInt32(txt_Rows.Text);
            m_Cols = Convert.ToInt32(txt_Cols.Text);

            iLineWidth = (pnlMenu.Width / m_Cols) - 5;
            iLineHeight = (pnlMenu.Height / m_Rows) - 5;

            pnlMenu.Controls.Clear();
            // Add btnArray to pnlMenu based on Rows and Cols
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    btnArray[iBtnCount] = new CustomButton();
                    btnArray[iBtnCount].Text = ""; // "btn " + iBtnCount.ToString();
                    btnArray[iBtnCount].Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
                    btnArray[iBtnCount].ForeColor = Color.Black;
                    btnArray[iBtnCount].BackColor = Color.White;
                    btnArray[iBtnCount].Left = xPos;
                    btnArray[iBtnCount].Top = yPos;
                    btnArray[iBtnCount].Width = iLineWidth;
                    btnArray[iBtnCount].Height = iLineHeight;
                    btnArray[iBtnCount].Tag = 0;
                    btnArray[iBtnCount].CornerRadius = 30;
                    btnArray[iBtnCount].RoundCorners = SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight | SDCafeCommon.Utilities.Corners.BottomLeft;
                    // save row and col to the button name property
                    btnArray[iBtnCount].Name = i.ToString() + "," + j.ToString();
                    btnArray[iBtnCount].Click += new System.EventHandler(ClickMenuButton);
                    pnlMenu.Controls.Add(btnArray[iBtnCount]);
                    xPos += (iLineWidth + iSpacing);
                    iBtnCount++;
                }
                yPos += (iLineHeight + iSpacing);
                xPos = 0;
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            POS_SalesButtonModel salesButton = new POS_SalesButtonModel();
            int iRow = 0;
            int iCol = 0;
            int iBtnCount = 0;
            int iColor = 0;
            int iLineWidth = 0;
            int iLineHeight = 0;
            int iSpacing = 5;
            string[] strRowCol;
            m_Rows = Convert.ToInt32(txt_Rows.Text);
            m_Cols = Convert.ToInt32(txt_Cols.Text);
            iLineWidth = (pnlMenu.Width / m_Cols) - 5;
            iLineHeight = (pnlMenu.Height / m_Rows) - 5;
            dbPOS.Delete_All_SalesButton();
            // Add btnArray to pnlMenu based on Rows and Cols
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    // get row and col from the button name property

                    strRowCol = btnArray[iBtnCount].Name.Split(',');
                    if (strRowCol.Length != 2)
                    {
                        MessageBox.Show("Invalid Row and Col");
                        return;
                    }
                    iRow = Int32.Parse(strRowCol[0]);
                    iCol = Int32.Parse(strRowCol[1]);
                    salesButton.Row = iRow;
                    salesButton.Col = iCol;
                    salesButton.ButtonLeft = btnArray[iBtnCount].Left;
                    salesButton.ButtonTop = btnArray[iBtnCount].Top;
                    salesButton.Width = btnArray[iBtnCount].Width;
                    salesButton.Height = btnArray[iBtnCount].Height;
                    salesButton.FontName = btnArray[iBtnCount].Font.Name;
                    salesButton.FontSize = btnArray[iBtnCount].Font.Size;
                    salesButton.FontStyle = (int)btnArray[iBtnCount].Font.Style;
                    salesButton.ForeColor = btnArray[iBtnCount].ForeColor.Name;
                    salesButton.BackColor = btnArray[iBtnCount].BackColor.Name;
                    salesButton.ProductId = Convert.ToInt32(btnArray[iBtnCount].Tag);
                    salesButton.IsVisible = true;
                    dbPOS.Insert_SalesButton(salesButton);
                    iBtnCount++;
                }
            }
            // save Rows and Cols to sysConfig
            List<POS_SysConfigModel> sysConfigs = new List<POS_SysConfigModel>();
            POS_SysConfigModel sysConfig = new POS_SysConfigModel();
            sysConfigs = dbPOS.Get_SysConfig_By_Name("SALESBUTTON_ROWS");
            if (sysConfigs == null)
            {
                sysConfig.ConfigName = "SALESBUTTON_ROWS";
                sysConfig.ConfigValue = txt_Rows.Text;
                dbPOS.Insert_SysConfig(sysConfig);
            }
            else
            {
                sysConfig = sysConfigs[0];
                sysConfig.ConfigName = "SALESBUTTON_ROWS";
                sysConfig.ConfigValue = txt_Rows.Text; //m_Rows.ToString();
                dbPOS.Update_SysConfig(sysConfig);
            }
            sysConfigs = dbPOS.Get_SysConfig_By_Name("SALESBUTTON_COLS");
            if (sysConfigs == null)
            {
                sysConfig.ConfigName = "SALESBUTTON_COLS";
                sysConfig.ConfigValue = txt_Cols.Text;
                dbPOS.Insert_SysConfig(sysConfig);
            }
            else
            {
                sysConfig = sysConfigs[0];
                sysConfig.ConfigName = "SALESBUTTON_COLS";
                sysConfig.ConfigValue = txt_Cols.Text; //m_Rows.ToString();
                dbPOS.Update_SysConfig(sysConfig);
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }

        private void txt_SearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if enter key is pressed, search the product
            if (e.KeyChar == (char)13)
            {
                SearchProduct(txt_SearchText.Text);
            }
        }

        private void SearchProduct(string p_strText)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            prods.Clear();
            prods = dbPOS.Get_All_Products_By_ProdName_Price(p_strText, 0);
            if (prods.Count > 0)
            {
                Load_Products_DataGrid(prods);
            }
            else
            {
                prods.Clear();
                prods = dbPOS.Get_All_Products_By_BarCode(p_strText, false);
                Load_Products_DataGrid(prods);
            }
        }
        private void Load_Products_DataGrid(List<POS_ProductModel> p_Prods)
        {
            dgvProds_Initialize();

            int iProdCount = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();
            //p_Prods = dbPOS.Get_All_Products();
            if (p_Prods.Count > 0)
            {
                foreach (var prod in p_Prods)
                {

                    iProdCount++;
                    this.dgvProds.Rows.Add(new String[] { prod.Id.ToString(),
                                                    dbPOS.Get_ProductTypeName_By_Id(prod.ProductTypeId),
                                                    prod.ProductName,
                                                    prod.OutUnitPrice.ToString()
                    });

                    /* if (ptype.IsBatchDonation)
                        {
                            this.dgvData.Rows[dgvData.RowCount - 2].Cells[3].Style.BackColor = Color.Green;
                        }
                        if (ptype.IsBatchDiscount)
                        {
                            this.dgvData.Rows[dgvData.RowCount - 2].Cells[4].Style.BackColor = Color.Green;
                        }*/
                    this.dgvProds.FirstDisplayedScrollingRowIndex = dgvProds.RowCount - 1;

                }
            }
            //lbl_AllProds.Text = "Products ( " + iProdCount.ToString() + " )";
        }
        private void dgvProds_Initialize()
        {
            this.dgvProds.AutoSize = false;
            dgvProds.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            this.dgvProds.MultiSelect = true;
            this.dgvProds.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProds.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProds.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvProds.ColumnCount = 4;
            this.dgvProds.Columns[0].Name = "Id";
            this.dgvProds.Columns[0].Width = 60;
            this.dgvProds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvProds.Columns[1].Name = "Type Name";
            this.dgvProds.Columns[1].Width = 100;
            this.dgvProds.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvProds.Columns[2].Name = "Product Name";
            this.dgvProds.Columns[2].Width = 150;
            this.dgvProds.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvProds.Columns[3].Name = "Price";
            this.dgvProds.Columns[3].Width = 70;
            this.dgvProds.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvProds.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 14F, GraphicsUnit.Pixel);
            this.dgvProds.EnableHeadersVisualStyles = false;
            this.dgvProds.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvProds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvProds.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvProds.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvProds.AllowUserToResizeRows = false;
            dgvProds.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvProds.RowTemplate.MinimumHeight = 40;


        }

        private void dgvProds_DoubleClick(object sender, EventArgs e)
        {
            // get the selected product id and product name and set txt_ProdId and txt_ProdName
            int iProdId = 0;
            string strProdName = "";
            iProdId = Convert.ToInt32(dgvProds.CurrentRow.Cells[0].Value);
            strProdName = dgvProds.CurrentRow.Cells[2].Value.ToString();
            txt_ProdId.Text = iProdId.ToString();
            txt_ProdName.Text = strProdName;

            m_btnSelected.Tag = iProdId;
            m_btnSelected.Text = strProdName.ToString();
        }
    }
}
