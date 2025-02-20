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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        private Color m_colorFore;
        private Color m_colorBack;
        private Graphics grpRec;
        private bool m_blnModified = false;
        private int m_intSelectedProdId;

        public frmSalesButton()
        {
            InitializeComponent();
        }

        private void frmSalesButton_Load(object sender, EventArgs e)
        {
            m_intQueryTop = 100;
            LoadSalesButtonSettings();
            UpdateButton(m_blnModified);
            SearchProduct(txt_SearchText.Text);

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
            Color colorDefaultFore = Color.Black;
            Color colorDefaultBack = Color.White;

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
                try
                {
                    btnArray[iButtonCount].ForeColor = Color.FromArgb(Convert.ToInt32(salesButton.ForeColor));
                    btnArray[iButtonCount].BackColor = Color.FromArgb(Convert.ToInt32(salesButton.BackColor));
                }
                catch (Exception ex)
                {
                    btnArray[iButtonCount].ForeColor = colorDefaultFore;
                    btnArray[iButtonCount].BackColor = colorDefaultBack;
                }
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

            txt_BackColor.Text = m_btnSelected.BackColor.ToArgb().ToString();
            txt_ForeColor.Text = m_btnSelected.ForeColor.ToArgb().ToString();
            txt_ForeColor.ForeColor = m_btnSelected.ForeColor;
            txt_ForeColor.BackColor = m_btnSelected.BackColor;
            txt_BackColor.ForeColor = m_btnSelected.ForeColor;
            txt_BackColor.BackColor = m_btnSelected.BackColor;
            txt_FontName.Text = m_btnSelected.Font.Name;
            txt_FontSize.Text = m_btnSelected.Font.Size.ToString();
            txt_BtnRow.Text = iRow.ToString();
            txt_BtnCol.Text = iCol.ToString();
            //txt_FontStyle.Text = m_btnSelected.Font.Style.ToString();
            txt_ProdId.Text = m_btnSelected.Tag.ToString();
            iProdId = Convert.ToInt32(m_btnSelected.Tag);
            if (iProdId > 0)
            {
                DataAccessPOS dbPOS = new DataAccessPOS();
                POS_ProductModel prod = dbPOS.Get_One_Product_By_ID(iProdId);
                txt_ProdName.Text = prod.ProductName;
                txt_ProdName.BackColor = Color.White;
                bt_Unlink.Enabled = true;

                m_intSelectedProdId = iProdId;
            }
            else
            {
                txt_ProdName.Text = "No Product";
                txt_ProdName.BackColor = Color.DimGray;
                bt_Unlink.Enabled = false;

                m_intSelectedProdId = 0;
            }
            UpdateButton(m_blnModified);

            chk_Visible.Checked = true;

            // if grpRec is not yet created on the pnlMain, draw a rectangle around the button
            if (grpRec == null)
            {
                grpRec = pnlMenu.CreateGraphics();
                Pen p = new Pen(Color.Red, 5);
                grpRec.DrawRectangle(p, m_btnSelected.Left, m_btnSelected.Top, m_btnSelected.Width, m_btnSelected.Height);
            }
            //else, move the rectangle to the new button
            else
            {
                // clear the rectangle with transparent color
                grpRec.Clear(pnlMenu.BackColor);
                Pen p = new Pen(Color.Red, 5);
                grpRec.DrawRectangle(p, m_btnSelected.Left, m_btnSelected.Top, m_btnSelected.Width, m_btnSelected.Height);
            }
            // compare the 2nd column of the row from dgvData using foreach loop with btnArray[iButtonCount].Tag value
            // if they are the same, set the row backcolor hightlighted
            foreach (DataGridViewRow row in dgvProds.Rows)
            {
                if (row.Cells[0].Value == null) continue;
                if (row.Cells[0].Value.ToString() == m_btnSelected.Tag.ToString())
                {
                    // set the row selected
                    row.Selected = true;
                    // scroll to the selected row
                    dgvProds.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
            grpButtonProp.ForeColor = Color.DarkRed;
            // set the frame color to red

        }
        private void UpdateButton(bool p_blnModified)
        {
            if (p_blnModified)
            {
                bt_Save.Enabled = true;
            }
            else
            {
                bt_Save.Enabled = false;
            }
            if (m_intSelectedProdId > 0)
            {
                bt_UpdateProduct.Enabled = true;
            }
            else
            {
                bt_UpdateProduct.Enabled = false;
            }
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
            int iNewRows = 0;
            int iNewCols = 0;

            // set iNewRows and iNewCols values from txt_Rows.text and txt_Cols.text
            iNewCols = Convert.ToInt32(txt_Cols.Text);
            iNewRows = Convert.ToInt32(txt_Rows.Text);


            if (txt_Rows.Text == "" || txt_Cols.Text == "")
            {
                MessageBox.Show("Please enter Rows and Cols");
                return;
            }
            if (txt_Rows.Text == m_Rows.ToString() && txt_Cols.Text == m_Cols.ToString())
            {
                MessageBox.Show("No change in Rows and Cols");
                return;
            }
            // ask user to confirm processing
            if ((m_Cols > iNewCols) || (m_Rows > iNewRows))
            {
                DialogResult result = MessageBox.Show("New layout is smaller than current." +
                                                        Environment.NewLine + // add new line
                                                        "Do you want to set the new layout?" + 
                                                        Environment.NewLine + // add new line
                                                        "Existing layout may be destroyed!", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            //DialogResult result = MessageBox.Show("Do you want to set the layout? Existing layout will be destroyed!", "Confirmation", MessageBoxButtons.YesNo);
            //if (result == DialogResult.No)
            //{
            //  return;
            //}

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

            DataAccessPOS dbPOS = new DataAccessPOS();
            salesButtonList = dbPOS.Get_All_SalesButton();

            pnlMenu.Controls.Clear();
            // Add btnArray to pnlMenu based on Rows and Cols
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    btnArray[iBtnCount] = new CustomButton();
                    btnArray[iBtnCount].Font = new System.Drawing.Font("Arial Narrow", 11, FontStyle.Bold);
                    btnArray[iBtnCount].ForeColor = Color.Black;
                    btnArray[iBtnCount].BackColor = Color.White;
                    btnArray[iBtnCount].Left = xPos;
                    btnArray[iBtnCount].Top = yPos;
                    btnArray[iBtnCount].Width = iLineWidth;
                    btnArray[iBtnCount].Height = iLineHeight;
                    btnArray[iBtnCount].Text = ""; // "btn " + iBtnCount.ToString();
                    btnArray[iBtnCount].Tag = 0;

                    if (salesButtonList.Count > 0)
                    {
                        foreach (POS_SalesButtonModel salesButton in salesButtonList)
                        {
                            if (salesButton.Row == i && salesButton.Col == j)
                            {
                                btnArray[iBtnCount].Text = dbPOS.Get_ProductName_By_Id(salesButton.ProductId);
                                btnArray[iBtnCount].Font = new System.Drawing.Font(salesButton.FontName, salesButton.FontSize, (FontStyle)salesButton.FontStyle);
                                try
                                {
                                    btnArray[iBtnCount].ForeColor = Color.FromArgb(Convert.ToInt32(salesButton.ForeColor));
                                    btnArray[iBtnCount].BackColor = Color.FromArgb(Convert.ToInt32(salesButton.BackColor));
                                }
                                catch (Exception ex)
                                {
                                    btnArray[iBtnCount].ForeColor = Color.Black;
                                    btnArray[iBtnCount].BackColor = Color.White;
                                }
                                btnArray[iBtnCount].Tag = salesButton.ProductId.ToString();
                                break;
                            }
                        }
                    }

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
                m_blnModified = true;
                UpdateButton(m_blnModified);
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
                    salesButton.ForeColor = btnArray[iBtnCount].ForeColor.ToArgb().ToString();
                    salesButton.BackColor = btnArray[iBtnCount].BackColor.ToArgb().ToString();
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
            bool blnExistOnSalesButton = false;
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

                    blnExistOnSalesButton = dbPOS.Check_SalesButton_By_ProductId(prod.Id);
                    if (blnExistOnSalesButton)
                    {
                        // set the row backcolor hightlighted
                        this.dgvProds.Rows[dgvProds.RowCount - 1].DefaultCellStyle.BackColor = Color.Beige;
                        // set the forecolor to dark red
                        this.dgvProds.Rows[dgvProds.RowCount - 1].DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                }
            }
            //lbl_AllProds.Text = "Products ( " + iProdCount.ToString() + " )";
        }
        private void dgvProds_Initialize()
        {
            this.dgvProds.AllowUserToAddRows = false;
            this.dgvProds.RowHeadersVisible = false;
            this.dgvProds.AutoSize = false;
            dgvProds.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            this.dgvProds.MultiSelect = false;
            this.dgvProds.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProds.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProds.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvProds.ColumnCount = 4;
            this.dgvProds.Columns[0].Name = "Id";
            this.dgvProds.Columns[0].Width = 50;
            this.dgvProds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvProds.Columns[1].Name = "Type Name";
            this.dgvProds.Columns[1].Width = 80;
            this.dgvProds.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvProds.Columns[2].Name = "Product Name";
            this.dgvProds.Columns[2].Width = 130;
            this.dgvProds.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvProds.Columns[3].Name = "Price";
            this.dgvProds.Columns[3].Width = 80;
            this.dgvProds.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvProds.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 11F, GraphicsUnit.Pixel);
            this.dgvProds.EnableHeadersVisualStyles = false;
            this.dgvProds.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 12F, GraphicsUnit.Pixel);
            this.dgvProds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvProds.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvProds.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvProds.AllowUserToResizeRows = false;
            dgvProds.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvProds.RowTemplate.MinimumHeight = 30;


        }

        private void dgvProds_DoubleClick(object sender, EventArgs e)
        {
            // get the selected product id and product name and set txt_ProdId and txt_ProdName
            int iProdId = 0;
            string strProdName = "";
            
            if (m_btnSelected == null) return;

            iProdId = Convert.ToInt32(dgvProds.CurrentRow.Cells[0].Value);
            strProdName = dgvProds.CurrentRow.Cells[2].Value.ToString();
            txt_ProdId.Text = iProdId.ToString();
            txt_ProdName.Text = strProdName;

            m_btnSelected.Tag = iProdId;
            m_btnSelected.Text = strProdName.ToString();

            // Set default button color
            m_btnSelected.BackColor = Color.White;
            m_btnSelected.ForeColor = Color.Black;
            txt_BackColor.Text = m_btnSelected.BackColor.Name;
            txt_ForeColor.Text = m_btnSelected.ForeColor.Name;

            m_blnModified = true;
            m_intSelectedProdId = iProdId;
            UpdateButton(m_blnModified);


        }

        private void txt_ForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog clrDialog = new ColorDialog();

            //show the colour dialog and check that user clicked ok
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                //save the colour that the user chose
                m_colorFore = clrDialog.Color;
                m_btnSelected.ForeColor = clrDialog.Color;
                txt_ForeColor.ForeColor = clrDialog.Color;
                txt_BackColor.ForeColor = clrDialog.Color;
                txt_ForeColor.Text = m_colorFore.ToArgb().ToString();
                m_blnModified = true;
                UpdateButton(m_blnModified);
            }
        }

        private void txt_BackColor_Click(object sender, EventArgs e)
        {
            ColorDialog clrDialog = new ColorDialog();

            //show the colour dialog and check that user clicked ok
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                //save the colour that the user chose
                m_colorBack = clrDialog.Color;
                m_btnSelected.BackColor = clrDialog.Color;
                txt_BackColor.BackColor = clrDialog.Color;
                txt_ForeColor.BackColor = clrDialog.Color;
                txt_BackColor.Text = m_colorBack.ToArgb().ToString();
                m_blnModified = true;
                UpdateButton(m_blnModified);
            }
        }

        private void txt_FontName_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            fontDialog1.ShowColor = false;

            fontDialog1.Font = txt_FontName.Font;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txt_FontName.Font = fontDialog1.Font;
                txt_FontName.Text = fontDialog1.Font.Name;
                txt_FontSize.Text = fontDialog1.Font.Size.ToString();
                m_btnSelected.Font = fontDialog1.Font;
                m_blnModified = true;
                UpdateButton(m_blnModified);
            }
        }

        private void bt_Unlink_Click(object sender, EventArgs e)
        {
            m_btnSelected.Tag = 0;
            m_btnSelected.Text = "No Product";
            txt_ProdId.Text = "0";
            txt_ProdName.Text = "";
            m_btnSelected.ForeColor = Color.White;
            m_btnSelected.BackColor = Color.DimGray;

            txt_ProdName.BackColor = Color.DimGray;
            bt_Unlink.Enabled = false;

            m_blnModified = true;
            UpdateButton(m_blnModified);
        }

        private void bt_UpdateProduct_Click(object sender, EventArgs e)
        {
            // Open fromProduct and passing m_intProductId and update the product
            frmProduct frmProd = new frmProduct(m_intSelectedProdId.ToString(),"",false,null);
            frmProd.ShowDialog();
            SearchProduct(txt_SearchText.Text);

            // compare the 2nd column of the row from dgvData using foreach loop with btnArray[iButtonCount].Tag value
            // if they are the same, set the row backcolor hightlighted
            foreach (DataGridViewRow row in dgvProds.Rows)
            {
                if (row.Cells[0].Value == null) continue;
                if (row.Cells[0].Value.ToString() == m_intSelectedProdId.ToString())
                {
                    // set the row selected
                    row.Selected = true;
                    // scroll to the selected row
                    dgvProds.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void dgvProds_Click(object sender, EventArgs e)
        {
            m_intSelectedProdId = Convert.ToInt32(dgvProds.CurrentRow.Cells[0].Value);
            UpdateButton(m_blnModified);
        }
    }
}
