using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
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
    public partial class frmBIB : Form
    {
        public int p_int_ProductId { get; set; }
        public int p_int_PTypeId { get; set; }
        public string p_str_ProductName { get; set; }
        public string p_str_PTypeName { get; set; }

        List<POS_ProductModel> prods = new List<POS_ProductModel>();
        List<POS_ProductTypeModel> ptypes = new List<POS_ProductTypeModel>();
        frmMain FrmMain;
        public frmBIB()
        {
            InitializeComponent();
        }
        public frmBIB(string _p_str_ProductId, frmMain _FrmMain)
        {
            FrmMain = _FrmMain;
            InitializeComponent();
            int pid = 0;
            bool isOK = int.TryParse(_p_str_ProductId, out pid);
            p_int_ProductId = pid;

            if (p_int_ProductId > 0)
            {
                DataAccessPOS dbPOS = new DataAccessPOS();
                prods = dbPOS.Get_Product_By_ID(p_int_ProductId);
                if (prods != null)
                {
                    if (prods.Count > 0)
                    {
                        p_int_PTypeId = prods[0].ProductTypeId;
                        p_str_ProductName = prods[0].ProductName;
                        p_str_PTypeName = dbPOS.Get_ProductTypeName_By_Id(p_int_PTypeId);
                        txt_ButtonName.Text = p_str_ProductName;
                        txt_PTypeName.Text = p_str_PTypeName;
                        txt_ButtonProdId.Text = p_int_ProductId.ToString();
                    }
                }
            }

            Load_Products_DataGrid();
            Load_BIBProducts_DataGrid();
        }
        private void dgvDataFrom_Initialize()
        {
            this.dgvDataFrom.AllowUserToAddRows = false;
            this.dgvDataFrom.RowHeadersVisible = false;
            this.dgvDataFrom.AutoSize = false;
            dgvDataFrom.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            this.dgvDataFrom.MultiSelect = true;
            this.dgvDataFrom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataFrom.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDataFrom.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvDataFrom.ColumnCount = 4;
            this.dgvDataFrom.Columns[0].Name = "Id";
            this.dgvDataFrom.Columns[0].Width = 60;
            this.dgvDataFrom.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataFrom.Columns[1].Name = "Type Name";
            this.dgvDataFrom.Columns[1].Width = 100;
            this.dgvDataFrom.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataFrom.Columns[2].Name = "Product Name";
            this.dgvDataFrom.Columns[2].Width = 180;
            this.dgvDataFrom.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataFrom.Columns[3].Name = "Price";
            this.dgvDataFrom.Columns[3].Width = 70;
            this.dgvDataFrom.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvDataFrom.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
            this.dgvDataFrom.EnableHeadersVisualStyles = false;
            this.dgvDataFrom.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvDataFrom.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataFrom.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvDataFrom.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDataFrom.AllowUserToResizeRows = false;
            dgvDataFrom.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvDataFrom.RowTemplate.MinimumHeight = 40;
        }
        private void dgvDataTo_Initialize()
        {
            this.dgvDataTo.AllowUserToAddRows = false;
            this.dgvDataTo.RowHeadersVisible = false;
            this.dgvDataTo.AutoSize = false;
            dgvDataTo.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvDataTo.MultiSelect = true;
            this.dgvDataTo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataTo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDataTo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvDataTo.ColumnCount = 4;
            this.dgvDataTo.Columns[0].Name = "Id";
            this.dgvDataTo.Columns[0].Width = 60;
            this.dgvDataTo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataTo.Columns[1].Name = "Type Name";
            this.dgvDataTo.Columns[1].Width = 100;
            this.dgvDataTo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataTo.Columns[2].Name = "Product Name";
            this.dgvDataTo.Columns[2].Width = 180;
            this.dgvDataTo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataTo.Columns[3].Name = "Price";
            this.dgvDataTo.Columns[3].Width = 70;
            this.dgvDataTo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvDataTo.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
            this.dgvDataTo.EnableHeadersVisualStyles = false;
            this.dgvDataTo.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvDataTo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataTo.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvDataTo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDataTo.AllowUserToResizeRows = false;
            dgvDataTo.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvDataTo.RowTemplate.MinimumHeight = 40;
        }
        private void Load_BIBProducts_DataGrid()
        {
            dgvDataTo_Initialize();


            DataAccessPOS dbPOS = new DataAccessPOS();

            prods = dbPOS.Get_All_BIB_Products_By_ButtonProductId(p_int_ProductId);

            if (prods.Count > 0)
            {
                foreach (var prod in prods)
                {
                    if (!prod.IsManualItem)
                    {
                        this.dgvDataTo.Rows.Add(new String[] { prod.Id.ToString(),
                                                         dbPOS.Get_ProductTypeName_By_Id(prod.ProductTypeId),
                                                         prod.ProductName,
                                                         prod.OutUnitPrice.ToString()
                        });

                        this.dgvDataTo.FirstDisplayedScrollingRowIndex = dgvDataTo.RowCount - 1;
                    }

                }
            }
        }

        private void Load_Products_DataGrid()
        {
            dgvDataFrom_Initialize();


            DataAccessPOS dbPOS = new DataAccessPOS();
            if (p_int_PTypeId == 0)
            {
                prods = dbPOS.Get_All_Products_NonBIB();
            }
            else
            {
                prods = dbPOS.Get_All_Products_By_ProdType_NonBIB(p_int_PTypeId);
            }
            lbl_AllProds.Text = "Products ( " + prods.Count.ToString() + " )";
            if (prods.Count > 0)
            {
                foreach (var prod in prods)
                {
                    //if (!prod.IsManualItem)
                    //{
                        this.dgvDataFrom.Rows.Add(new String[] { prod.Id.ToString(),
                                                         dbPOS.Get_ProductTypeName_By_Id(prod.ProductTypeId),
                                                         prod.ProductName,
                                                         prod.OutUnitPrice.ToString()
                        });
                        this.dgvDataFrom.FirstDisplayedScrollingRowIndex = dgvDataFrom.RowCount - 1;
                    //}

                }
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            // check entries on dgvDataTo
            if (dgvDataTo.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one product to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // delete existing BIB products
            DataAccessPOS dbPOS = new DataAccessPOS();
            dbPOS.Delete_ButtonInButtons(p_int_ProductId);
            POS_ButtonInButtonsModel bib = new POS_ButtonInButtonsModel();
            int iSortOrder = 0;
            foreach (DataGridViewRow row in dgvDataTo.Rows)
            {
                iSortOrder++;
                if (row.Cells[0].Value == null)
                {
                    // continue
                    continue;
                }
                // add new BIB products
                bib.ButtonProdId = p_int_ProductId;
                bib.ButtonName = p_str_ProductName;
                bib.ProductId = Convert.ToInt32(row.Cells[0].Value);
                bib.SortOrder = iSortOrder;

                dbPOS.Add_ButtonInButton(bib);
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void bt_AddOne_Click(object sender, EventArgs e)
        {
            // Get the selected product from dgvDataFrom
            if (dgvDataFrom.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDataFrom.SelectedRows[0];
                int prodId = Convert.ToInt32(row.Cells[0].Value);
                DataAccessPOS dbPOS = new DataAccessPOS();
                POS_ProductModel prod = dbPOS.Get_Product_By_ID(prodId)[0];
                if (prod != null)
                {
                    //if (prod.IsManualItem)
                    //{
                    //    MessageBox.Show("You can not add a manual item to the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    // check if the product is already in the list

                    // get selected rows on dgvDataFrom and add into dgvDataTo
                    foreach (DataGridViewRow rowFrom in dgvDataFrom.SelectedRows)
                    {
                        // check if the row exist in dgvDatato
                        bool isExist = false;
                        if (dgvDataTo.Rows.Count > 0)
                        { 
                            foreach (DataGridViewRow rowTo in dgvDataTo.Rows)
                            {
                                if (rowTo.Cells[0].Value != null)
                                {
                                    if (rowFrom.Cells[0].Value.ToString() == rowTo.Cells[0].Value.ToString())
                                    {
                                        isExist = true;
                                        break;
                                    }
                                }
                            }
                            if (isExist)
                            {
                                MessageBox.Show("The product is already in the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        this.dgvDataTo.Rows.Add(new String[] { rowFrom.Cells[0].Value.ToString(),
                                                         rowFrom.Cells[1].Value.ToString(),
                                                         rowFrom.Cells[2].Value.ToString(),
                                                         rowFrom.Cells[3].Value.ToString()
                        });
                        this.dgvDataTo.Refresh();
                    }
                }
            }
        }

        private void bt_DelOne_Click(object sender, EventArgs e)
        {
            // Get the selected product from dgvDataTo
            if (dgvDataTo.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDataTo.SelectedRows[0];
                int prodId = Convert.ToInt32(row.Cells[0].Value);
                dgvDataTo.Rows.Remove(row);
            }

        }
    }
}
