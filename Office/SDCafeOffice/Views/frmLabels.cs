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
using Microsoft.Office.Interop.Excel;
using System.IO;
using SDCafeCommon.Utilities;

namespace SDCafeOffice.Views
{
    public partial class frmLabels: Form
    {
        private int m_int_PTypeId;
        List<POS_ProductModel> prods = new List<POS_ProductModel>();
        private Utility util = new Utility();

        public frmLabels()
        {
            InitializeComponent();
        }

        private void frmLabels_Load(object sender, EventArgs e)
        {
            // set the form on the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            LoadLabelFormatCombo();
            LoadProductTypeCombo();
            InitializeDataGridProd();
            InitializeDataGridSelected();
        }

        private void LoadLabelFormatCombo()
        {
            List<POS_SysConfigModel> sysconfigs = new List<POS_SysConfigModel>();
            DataAccessPOS dbPOS = new DataAccessPOS();
            sysconfigs = dbPOS.Get_SysConfig_By_NameContains("LABEL_FORMAT");
            cb_LabelFormat.Items.Clear();
            if (sysconfigs.Count > 0)
            {
                foreach (POS_SysConfigModel sysconfig in sysconfigs)
                {
                    cb_LabelFormat.Items.Add(sysconfig.ConfigDesc);
                }
                cb_LabelFormat.SelectedIndex = 0;
            }
        }

        private void LoadProductTypeCombo()
        {
            // load product type combo
            this.cb_ProdType.Items.Clear();
            this.cb_ProdType.Items.Add("All");

            DataAccessPOS dbPOS = new DataAccessPOS();
            List<POS_ProductTypeModel> types = new List<POS_ProductTypeModel>();
            types = dbPOS.Get_All_ProductTypes();
            foreach (POS_ProductTypeModel type in types)
            {
                this.cb_ProdType.Items.Add(type.TypeName);
            }


        }

        private void InitializeDataGridSelected()
        {
            this.dgvDataSelected.AllowUserToAddRows = false;
            this.dgvDataSelected.RowHeadersVisible = false;
            this.dgvDataSelected.AutoSize = false;
            dgvDataSelected.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            this.dgvDataSelected.MultiSelect = true;
            this.dgvDataSelected.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataSelected.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDataSelected.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvDataSelected.ColumnCount = 4;
            this.dgvDataSelected.Columns[0].Name = "Id";
            this.dgvDataSelected.Columns[0].Width = 60;
            this.dgvDataSelected.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataSelected.Columns[1].Name = "Type Name";
            this.dgvDataSelected.Columns[1].Width = 100;
            this.dgvDataSelected.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataSelected.Columns[2].Name = "Product Name";
            this.dgvDataSelected.Columns[2].Width = 180;
            this.dgvDataSelected.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataSelected.Columns[3].Name = "Price";
            this.dgvDataSelected.Columns[3].Width = 70;
            this.dgvDataSelected.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvDataSelected.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 14F, GraphicsUnit.Pixel);
            this.dgvDataSelected.EnableHeadersVisualStyles = false;
            this.dgvDataSelected.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvDataSelected.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataSelected.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvDataSelected.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDataSelected.AllowUserToResizeRows = false;
            dgvDataSelected.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvDataSelected.RowTemplate.MinimumHeight = 40;
        }

        private void InitializeDataGridProd()
        {
            this.dgvDataProd.AllowUserToAddRows = false;
            this.dgvDataProd.RowHeadersVisible = false;
            this.dgvDataProd.AutoSize = false;
            dgvDataProd.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            this.dgvDataProd.MultiSelect = true;
            this.dgvDataProd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataProd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDataProd.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvDataProd.ColumnCount = 4;
            this.dgvDataProd.Columns[0].Name = "Id";
            this.dgvDataProd.Columns[0].Width = 60;
            this.dgvDataProd.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataProd.Columns[1].Name = "Type Name";
            this.dgvDataProd.Columns[1].Width = 100;
            this.dgvDataProd.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataProd.Columns[2].Name = "Product Name";
            this.dgvDataProd.Columns[2].Width = 180;
            this.dgvDataProd.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataProd.Columns[3].Name = "Price";
            this.dgvDataProd.Columns[3].Width = 70;
            this.dgvDataProd.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvDataProd.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 14F, GraphicsUnit.Pixel);
            this.dgvDataProd.EnableHeadersVisualStyles = false;
            this.dgvDataProd.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvDataProd.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataProd.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvDataProd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDataProd.AllowUserToResizeRows = false;
            dgvDataProd.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvDataProd.RowTemplate.MinimumHeight = 40;
        }

        private void cb_ProdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            List<POS_ProductTypeModel> types = new List<POS_ProductTypeModel>();
            types = dbPOS.Get_ProductTypeId_By_TypeName(cb_ProdType.Text);
            if (types.Count > 0)
            {
                m_int_PTypeId = types[0].Id;
            }
            else
            {
                m_int_PTypeId = 0;
            }
            Search_Products("");
        }

        private void txt_ProdSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // if enter key is pressed, search for products
            if (e.KeyCode == Keys.Enter)
            {
                Search_Products(txt_ProdSearch.Text);
            }
        }
        private void Search_Products(string p_strText)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            List<POS_ProductModel> allprods = new List<POS_ProductModel>();

            if (m_int_PTypeId == 0)
            {
                allprods = dbPOS.Get_All_Products_NonBIB();
            }
            else
            {
                allprods = dbPOS.Get_All_Products_By_ProdType_NonBIB(m_int_PTypeId);
            }

            if (allprods.Count > 0)
            {
                prods.Clear();
                prods = allprods.Where(x => x.ProductName.ToLower().Contains(p_strText.ToLower())).ToList();
                Load_Products_DataGrid(prods);
            }
            else
            {
                prods.Clear();
                prods = dbPOS.Get_All_Products_By_BarCode(p_strText, false);
                Load_Products_DataGrid(prods);
            }
        }

        private void Load_Products_DataGrid(List<POS_ProductModel> prods)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            dgvDataProd.Rows.Clear();
            foreach (POS_ProductModel prod in prods)
            {
                int rowIndex = dgvDataProd.Rows.Add();
                DataGridViewRow row = dgvDataProd.Rows[rowIndex];
                row.Cells["Id"].Value = prod.Id;
                row.Cells["Type Name"].Value = dbPOS.Get_ProductTypeName_By_Id(prod.ProductTypeId);
                row.Cells["Product Name"].Value = prod.ProductName;
                row.Cells["Price"].Value = prod.OutUnitPrice.ToString("0.00");
            }
        }

        private void bt_AddOne_Click(object sender, EventArgs e)
        {
            // check if the product is already in the selected list
            if (dgvDataProd.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDataProd.SelectedRows)
                {
                    int prodId = Convert.ToInt32(row.Cells["Id"].Value);
                    // check if the product is already in the selected list
                    if (dgvDataSelected.Rows.Cast<DataGridViewRow>().Any(r => Convert.ToInt32(r.Cells["Id"].Value) == prodId))
                    {
                        MessageBox.Show("Product is already in the selected list.");
                        return;
                    }
                    else
                    {
                        int rowIndex = dgvDataSelected.Rows.Add();
                        DataGridViewRow newRow = dgvDataSelected.Rows[rowIndex];
                        newRow.Cells["Id"].Value = row.Cells["Id"].Value;
                        newRow.Cells["Type Name"].Value = row.Cells["Type Name"].Value;
                        newRow.Cells["Product Name"].Value = row.Cells["Product Name"].Value;
                        newRow.Cells["Price"].Value = row.Cells["Price"].Value;
                    }
                }
            }
        }

        private void bt_DelOne_Click(object sender, EventArgs e)
        {
            // check if any rows are selected
            if (dgvDataSelected.SelectedRows.Count > 0)
            {
                // remove the selected rows
                foreach (DataGridViewRow row in dgvDataSelected.SelectedRows)
                {
                    dgvDataSelected.Rows.Remove(row);
                }
            }

        }

        private void bt_Print_Click(object sender, EventArgs e)
        {
            // get selected Format
            string strFormat = cb_LabelFormat.Text;
            if (strFormat == "")
            {
                MessageBox.Show("Please select a label format.");
                return;
            }
            List<POS_SysConfigModel> sysconfigs = new List<POS_SysConfigModel>();
            DataAccessPOS dbPOS = new DataAccessPOS();
            sysconfigs = dbPOS.Get_SysConfig_By_Desc(strFormat);
            if (sysconfigs.Count > 0)
            {
                // split the config desc with 'x' to get the column count
                //int columnCount = sysconfigs[0].ConfigDesc.Split('x').Length;
                string[] strColRow = sysconfigs[0].ConfigDesc.Split('x');
                int columnCount = Convert.ToInt32(strColRow[0]);
                int rowCount = Convert.ToInt32(strColRow[1]);

                string strFormatFileName = sysconfigs[0].ConfigValue;
                // check if any rows are selected
                if (dgvDataSelected.Rows.Count > 0)
                {
                    // get the selected products
                    List<POS_ProductModel> selectedProds = new List<POS_ProductModel>();
                    foreach (DataGridViewRow row in dgvDataSelected.Rows)
                    {
                        int prodId = Convert.ToInt32(row.Cells["Id"].Value);
                        POS_ProductModel prod = prods.FirstOrDefault(p => p.Id == prodId);
                        if (prod != null)
                        {
                            selectedProds.Add(prod);
                        }
                    }
                    // print the labels
                    PrintLabels(selectedProds, strFormatFileName, columnCount, rowCount);
                }
                else
                {
                    MessageBox.Show("Please select at least one product.");
                }
            }
        }

        private void PrintLabels(List<POS_ProductModel> selectedProds, string strFormatFileName, int p_int_Cols, int p_int_Rows)
        {
            bool b_isPromo;
            progressBarGen.Maximum = selectedProds.Count;
            progressBarGen.Value = 0;
            progressBarGen.Visible = true;

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not installed!!");
                return;
            }

            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            // --------------------------------------- Open Excel File Name -------------------------------------
            // check if the file exists
            if (!File.Exists(strFormatFileName))
            {
                MessageBox.Show("Label Template file not found: " + strFormatFileName);
                return;
            }
            xlWorkBook = xlApp.Workbooks.Open(strFormatFileName);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlApp.DisplayAlerts = false;
            xlWorkBook.CheckCompatibility = false;
            xlWorkBook.DoNotPromptForConvert = true;

            // set the range to the first column    
            Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.Columns["A:A"];
            Microsoft.Office.Interop.Excel.Range rangePName = range.Find("%PRODUCTNAME%", LookAt: Microsoft.Office.Interop.Excel.XlLookAt.xlWhole);
            Microsoft.Office.Interop.Excel.Range rangeBarCode = range.Find("%BARCODE%", LookAt: Microsoft.Office.Interop.Excel.XlLookAt.xlWhole);
            Microsoft.Office.Interop.Excel.Range rangeBarCodeString = range.Find("%BARCODESTRING%", LookAt: Microsoft.Office.Interop.Excel.XlLookAt.xlWhole);
            Microsoft.Office.Interop.Excel.Range rangePromoInfo = range.Find("%PROMOINFO%", LookAt: Microsoft.Office.Interop.Excel.XlLookAt.xlWhole);
            Microsoft.Office.Interop.Excel.Range rangePrice = range.Find("%PRODUCTPRICE%", LookAt: Microsoft.Office.Interop.Excel.XlLookAt.xlWhole);

            // find the lowest row number from those ranges
            int lowestRow = 0;
            if (rangePName != null)
            {
                lowestRow = rangePName.Row;
            }
            if (rangeBarCode != null && rangeBarCode.Row < lowestRow)
            {
                lowestRow = rangeBarCode.Row;
            }
            if (rangeBarCodeString != null && rangeBarCodeString.Row < lowestRow)
            {
                lowestRow = rangeBarCodeString.Row;
            }
            if (rangePromoInfo != null && rangePromoInfo.Row < lowestRow)
            {
                lowestRow = rangePromoInfo.Row;
            }
            if (rangePrice != null && rangePrice.Row < lowestRow)
            {
                lowestRow = rangePrice.Row;
            }
            // find the highest row number from those ranges
            int highestRow = 0;
            if (rangePName != null)
            {
                highestRow = rangePName.Row;
            }
            if (rangeBarCode != null && rangeBarCode.Row > highestRow)
            {
                highestRow = rangeBarCode.Row;
            }
            if (rangeBarCodeString != null && rangeBarCodeString.Row > highestRow)
            {
                highestRow = rangeBarCodeString.Row;
            }
            if (rangePrice != null && rangePrice.Row > highestRow)
            {
                highestRow = rangePrice.Row;
            }
            // save old ranges
            Microsoft.Office.Interop.Excel.Range oldRangePName = rangePName;
            Microsoft.Office.Interop.Excel.Range oldRangeBarCode = rangeBarCode;
            Microsoft.Office.Interop.Excel.Range oldRangeBarCodeString = rangeBarCodeString;
            Microsoft.Office.Interop.Excel.Range oldRangePromoInfo = rangePromoInfo;
            Microsoft.Office.Interop.Excel.Range oldRangePrice = rangePrice;

            int iGapRows = (highestRow - lowestRow) + 2;

            int rowCount = 1;
            int colCount = 1;
            foreach (POS_ProductModel prod in selectedProds)
            {
                progressBarGen.Value++;

                if (colCount > p_int_Cols)
                {
                    if (rangePName != null) rangePName = rangePName.Offset[iGapRows, p_int_Cols * - 1];
                    if (rangeBarCode != null) rangeBarCode = rangeBarCode.Offset[iGapRows, p_int_Cols * -1];
                    if (rangeBarCodeString != null) rangeBarCodeString = rangeBarCodeString.Offset[iGapRows, p_int_Cols * -1];
                    if (rangePromoInfo != null) rangePromoInfo = rangePromoInfo.Offset[iGapRows, p_int_Cols * -1];
                    if (rangePrice != null) rangePrice = rangePrice.Offset[iGapRows, p_int_Cols * -1];

                    colCount = 1;
                    rowCount++;

                    int rowCount2 = rowCount % p_int_Rows;
                    if (rowCount2 == 0)
                    {
                        // insert a page breaks
                        xlWorkSheet.HPageBreaks.Add(xlWorkSheet.Cells[(rowCount * highestRow) + 1, 1]);
                    }

                }


                // Set the format of the cell from the old range
                if (oldRangePName != null)
                {
                    oldRangePName.Copy();
                    rangePName.PasteSpecial(Microsoft.Office.Interop.Excel.XlPasteType.xlPasteFormats);
                    // set the hight of the cell from the old range
                    rangePName.RowHeight = oldRangePName.RowHeight;
                    rangePName.Value = prod.ProductName;
                }
                if (oldRangeBarCode != null)
                {
                    oldRangeBarCode.Copy();
                    rangeBarCode.PasteSpecial(Microsoft.Office.Interop.Excel.XlPasteType.xlPasteFormats);
                    // set the hight of the cell from the old range
                    rangeBarCode.RowHeight = oldRangeBarCode.RowHeight;
                    rangeBarCode.Value = "*" + prod.BarCode + "*";
                }
                if (oldRangeBarCodeString != null)
                {
                    oldRangeBarCodeString.Copy();
                    rangeBarCodeString.PasteSpecial(Microsoft.Office.Interop.Excel.XlPasteType.xlPasteFormats);
                    rangeBarCodeString.NumberFormat = "@";
                    // set the hight of the cell from the old range
                    rangeBarCodeString.RowHeight = oldRangeBarCodeString.RowHeight;
                    rangeBarCodeString.Value = prod.BarCode;
                }
                b_isPromo = false;
                if (oldRangePromoInfo != null)
                {
                    oldRangePromoInfo.Copy();
                    rangePromoInfo.PasteSpecial(Microsoft.Office.Interop.Excel.XlPasteType.xlPasteFormats);
                    // set the hight of the cell from the old range
                    rangePromoInfo.RowHeight = oldRangePromoInfo.RowHeight;
                    // check if the product is on promo
                    b_isPromo = IsProductPromotion(prod);
                    if (b_isPromo == true)
                    {
                        rangePromoInfo.Value = "Promo : " + prod.PromoPrice1.ToString("C2") + " for " + prod.PromoDay1.ToString() + " EA";
                    }
                    else
                    {
                        rangePromoInfo.Value = "";
                    }
                }
                if (oldRangePrice != null)
                {
                    oldRangePrice.Copy();
                    rangePrice.PasteSpecial(Microsoft.Office.Interop.Excel.XlPasteType.xlPasteFormats);
                    // set the hight of the cell from the old range
                    rangePrice.RowHeight = oldRangePrice.RowHeight;
                    if (b_isPromo == true)
                    {
                        rangePrice.Value = "Regular Price : " + prod.PromoPrice1.ToString("C2");
                        // strikeout the price
                        rangePrice.Font.Strikethrough = true;
                    }
                    else
                        rangePrice.Value = "Price : " + prod.OutUnitPrice.ToString("C2");
                }

                if (rangePName != null) rangePName = rangePName.Offset[0, 1];
                if (rangeBarCode != null) rangeBarCode = rangeBarCode.Offset[0, 1];
                if (rangeBarCodeString != null)  rangeBarCodeString = rangeBarCodeString.Offset[0, 1];
                if (rangePromoInfo != null) rangePromoInfo = rangePromoInfo.Offset[0, 1];
                if (rangePrice != null) rangePrice = rangePrice.Offset[0, 1];

                colCount++;
            }

            // save the workbook
            string strFileName = "Label_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
            string strFilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), strFileName);
            xlWorkBook.SaveAs(strFilePath);
            // close the workbook
            xlWorkBook.Close();
            // quit the excel application
            xlApp.Quit();
            // release the COM objects
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            // Release the COM object
            ReleaseObject(xlWorkSheet);
            ReleaseObject(xlWorkBook);
            ReleaseObject(xlApp);
            // show the file in the explorer
            System.Diagnostics.Process.Start("explorer.exe", strFilePath);





        }

        private bool IsProductPromotion(POS_ProductModel prod)
        {
            // check if the product is on promo
            if ((prod.PromoStartDate != null) && (prod.PromoEndDate != null))
            {
                if (prod.PromoStartDate != "" && prod.PromoEndDate != "")
                {
                    DateTime startDate = Convert.ToDateTime(prod.PromoStartDate);
                    DateTime endDate = Convert.ToDateTime(prod.PromoEndDate);
                    DateTime currentDate = DateTime.Now;
                    if (currentDate >= startDate && currentDate <= endDate)
                    {
                        if ((prod.PromoPrice1 > 0) && (prod.PromoDay1 > 0))
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            return false;
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }
         // Release the COM object
        static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
