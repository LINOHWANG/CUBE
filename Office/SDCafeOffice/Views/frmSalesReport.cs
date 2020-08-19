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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Font = Microsoft.Office.Interop.Excel.Font;

namespace SDCafeOffice.Views
{
    public partial class frmSalesReport : Form
    {
        List<POS1_TranCollectionModel> trancols = new List<POS1_TranCollectionModel>();
        List<POS1_OrderCompleteModel> ordercomps = new List<POS1_OrderCompleteModel>();
        public frmSalesReport()
        {
            InitializeComponent();
        }
        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            dgvData_Initialize();
            dttm_TranStart.Value = DateTime.Now;
            dttm_TranEnd.Value = DateTime.Now;

            dttm_TranStartTime.Format = DateTimePickerFormat.Custom;
            dttm_TranStartTime.CustomFormat = "HH:mm:ss";
            dttm_TranStartTime.Value = Convert.ToDateTime("00:00:00");

            dttm_TranEndTime.Format = DateTimePickerFormat.Custom;
            dttm_TranEndTime.CustomFormat = "HH:mm:ss";
            dttm_TranEndTime.Value = Convert.ToDateTime("23:59:59");
        }
        private void dgvData_Initialize()
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
            this.dgvData.Columns[0].Name = "ID";
            this.dgvData.Columns[0].Width = 80;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[1].Name = "Name";
            this.dgvData.Columns[1].Width = 200;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = "QTY";
            this.dgvData.Columns[2].Width = 100;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = "Amount";
            this.dgvData.Columns[3].Width = 120;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[4].Name = "GST";
            this.dgvData.Columns[4].Width = 100;
            this.dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[5].Name = "PST";
            this.dgvData.Columns[5].Width = 100;
            this.dgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[6].Name = "Tax3";
            this.dgvData.Columns[6].Width = 100;
            this.dgvData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[7].Name = "Total";
            this.dgvData.Columns[7].Width = 120;
            this.dgvData.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvData.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 16F, GraphicsUnit.Pixel);

            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 18F, GraphicsUnit.Pixel);
            this.dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvData.AllowUserToResizeRows = false;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvData.RowTemplate.MinimumHeight = 40;
        }
        private void dgvDataTender_Initialize()
        {
            this.dgvDataTender.AutoSize = false;
            dgvDataTender.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvDataTender.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataTender.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDataTender.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvDataTender.ColumnCount = 6;
            this.dgvDataTender.Columns[0].Name = "Tender";
            this.dgvDataTender.Columns[0].Width = 150;
            this.dgvDataTender.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataTender.Columns[1].Name = "Name";
            this.dgvDataTender.Columns[1].Width = 200;
            this.dgvDataTender.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataTender.Columns[2].Name = "QTY";
            this.dgvDataTender.Columns[2].Width = 120;
            this.dgvDataTender.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataTender.Columns[3].Name = "Net";
            this.dgvDataTender.Columns[3].Width = 150;
            this.dgvDataTender.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDataTender.Columns[4].Name = "Tip";
            this.dgvDataTender.Columns[4].Width = 150;
            this.dgvDataTender.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDataTender.Columns[5].Name = "Total";
            this.dgvDataTender.Columns[5].Width = 150;
            this.dgvDataTender.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvDataTender.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 16F, GraphicsUnit.Pixel);

            this.dgvDataTender.EnableHeadersVisualStyles = false;
            this.dgvDataTender.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 18F, GraphicsUnit.Pixel);
            this.dgvDataTender.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataTender.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvDataTender.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDataTender.AllowUserToResizeRows = false;
            dgvDataTender.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvDataTender.RowTemplate.MinimumHeight = 40;
        }
        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void bt_Query_Click(object sender, EventArgs e)
        {
            Query_SalesSummary();
            Query_CollectionSummary();
        }

        private void Query_CollectionSummary()
        {
            dgvDataTender_Initialize();
            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();

            trancols = dbPOS1.Get_TranCollection_by_DateTimeRange(dttm_TranStart.Value.ToString("yyyy-MM-dd"), dttm_TranStartTime.Value.ToString("HH:mm:ss"),
                                                            dttm_TranEnd.Value.ToString("yyyy-MM-dd"), dttm_TranEndTime.Value.ToString("HH:mm:ss"));

            string[] strColTypeName = new string[] { "Cash", "Debit", "Visa", "MasterCard", "Amex", "GiftCard" };

            float[] iQTY        = new float[] { 0, 0, 0, 0, 0, 0 };
            float[] iNetAmount  = new float[] { 0, 0, 0, 0, 0, 0 };
            float[] iTip        = new float[] { 0, 0, 0, 0, 0, 0 };
            float[] iTotal      = new float[] { 0, 0, 0, 0, 0, 0 };

            float iTotalQTY = 0;
            float iTotalNetAmount = 0;
            float iTotalTip = 0;
            float iTotalTotal = 0;

            string strTemp = "";
            int n = 0;
            if (trancols.Count > 0)
            {
                foreach (var trancol in trancols)
                {
                    for (int i = 0; i < strColTypeName.Length; i++)
                    {
                        if (trancol.CollectionType == strColTypeName[i])
                        {
                            iQTY[i]++;
                            iNetAmount[i] = iNetAmount[i] + trancol.TotalPaid;
                            iTip[i] = iTip[i] + trancol.TotalTip;
                            iTotal[i] = iTotal[i] + (trancol.TotalPaid + trancol.TotalTip);

                            iTotalQTY++;
                            iTotalNetAmount = iTotalNetAmount + trancol.TotalPaid;
                            iTotalTip = iTotalTip + trancol.TotalTip;
                            iTotalTotal = iTotalTotal + (trancol.TotalPaid + trancol.TotalTip); ;
                        }
                    }
                }
            }

            for (int i = 0; i < strColTypeName.Length; i++)
            {
                if (iQTY[i] > 0)
                {
                    this.dgvDataTender.Rows.Add(new String[] { (i.Equals(0) ? strColTypeName[i] : "Card"),
                                                         strColTypeName[i],
                                                         iQTY[i].ToString("0"),
                                                         iNetAmount[i].ToString("#,##0.00"),
                                                         iTip[i].ToString("#,##0.00"),
                                                         iTotal[i].ToString("#,##0.00")

                            });
                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;
                }
            }
            this.dgvDataTender.Rows.Add(new String[] { "",
                                                         "TOTAL",
                                                         iTotalQTY.ToString("0"),
                                                         iTotalNetAmount.ToString("#,##0.00"),
                                                         iTotalTip.ToString("#,##0.00"),
                                                         iTotalTotal.ToString("#,##0.00")

                 });
            for (int j = 0; j < dgvDataTender.Columns.Count; j++)
            {
                this.dgvDataTender.Rows[dgvDataTender.RowCount - 2].Cells[j].Style.BackColor = Color.LightBlue;
                this.dgvDataTender.Rows[dgvDataTender.RowCount - 2].Cells[j].Style.Font = new System.Drawing.Font(this.dgvDataTender.DefaultCellStyle.Font, FontStyle.Bold);
            }
            this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;

        }



        private void Query_SalesSummary()
        {
            dgvData_Initialize();

            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();

            ordercomps = dbPOS1.Get_OrderComplete_by_Date_OrderBy_Type(dttm_TranStart.Value.ToString("yyyy-MM-dd"), dttm_TranStartTime.Value.ToString("HH:mm:ss"),
                                                            dttm_TranEnd.Value.ToString("yyyy-MM-dd"), dttm_TranEndTime.Value.ToString("HH:mm:ss"));

            string strTypeName = "";

            float iQTY = 0;
            float iAmount = 0;
            float iTax1 = 0;
            float iTax2 = 0;
            float iTax3 = 0;
            float iTotal = 0;

            float iTypeQTY = 0;
            float iTypeAmount = 0;
            float iTypeTax1 = 0;
            float iTypeTax2 = 0;
            float iTypeTax3 = 0;
            float iTypeTotal = 0;

            float iSumQTY = 0;
            float iSumAmount = 0;
            float iSumTax1 = 0;
            float iSumTax2 = 0;
            float iSumTax3 = 0;
            float iSumTotal = 0;

            float iDepositQTY = 0;
            float iDepositAmount = 0;
            float iDepositTax1 = 0;
            float iDepositTax2 = 0;
            float iDepositTax3 = 0;
            float iDepositTotal = 0;

            float iDiscountQTY = 0;
            float iDiscountAmount = 0;
            float iDiscountTax1 = 0;
            float iDiscountTax2 = 0;
            float iDiscountTax3 = 0;
            float iDiscountTotal = 0;

            int iTempTypeId = 0;
            int n = 0;
            if (ordercomps.Count > 0)
            {
                foreach (var ordcomp in ordercomps)
                {
                    if (n == 0)
                    {
                        iTempTypeId = ordcomp.ProductTypeId;
                    }

                    if (iTempTypeId != ordcomp.ProductTypeId)
                    {
                        if (iTempTypeId != 0)   // Except Deposit, Discount ... add first
                        {
                            this.dgvData.Rows.Add(new String[] { iTempTypeId.ToString(),
                                                         dbPOS.Get_ProductTypeName_By_Id(iTempTypeId),
                                                         iTypeQTY.ToString("0"),
                                                         iTypeAmount.ToString("#,##0.00"),
                                                         iTypeTax1.ToString("#,##0.00"),
                                                         iTypeTax2.ToString("#,##0.00"),
                                                         iTypeTax3.ToString("#,##0.00"),
                                                         iTypeTotal.ToString("#,##0.00")

                            });
                            this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;
                        }

                        iTypeQTY = 0;
                        iTypeAmount = 0;
                        iTypeTax1 = 0;
                        iTypeTax2 = 0;
                        iTypeTax3 = 0;
                        iTypeTotal = 0;

                        iTempTypeId = ordcomp.ProductTypeId;
                    }

                    iQTY = ordcomp.Quantity;
                    iAmount = ordcomp.Amount;
                    iTax1 = ordcomp.Tax1;
                    iTax2 = ordcomp.Tax2;
                    iTax3 = ordcomp.Tax3;
                    iTotal = iAmount + iTax1 + iTax2 + iTax3;

                    iTypeQTY = iTypeQTY + iQTY;
                    iTypeAmount = iTypeAmount + iAmount;
                    iTypeTax1 = iTypeTax1 + iTax1;
                    iTypeTax2 = iTypeTax2 + iTax2;
                    iTypeTax3 = iTypeTax3 + iTax3;
                    iTypeTotal = iTypeTotal + iTotal;

                    iSumQTY = iSumQTY + iQTY;
                    iSumAmount = iSumAmount + iAmount;
                    iSumTax1 = iSumTax1 + iTax1;
                    iSumTax2 = iSumTax2 + iTax2;
                    iSumTax3 = iSumTax3 + iTax3;
                    iSumTotal = iSumTotal + iTotal;

                    /*Public Const CON_TRAN_CATEGORY_NAME_0 As String = "General"
                    Public Const CON_TRAN_CATEGORY_NAME_1 As String = "Deposit"
                    Public Const CON_TRAN_CATEGORY_NAME_2 As String = "Recycling Fee"
                    Public Const CON_TRAN_CATEGORY_NAME_3 As String = "Chill Charge"
                    Public Const CON_TRAN_CATEGORY_NAME_4 As String = "Discount"
                    Public Const CON_TRAN_CATEGORY_NAME_5 As String = "Free Ticket"
                    Public Const CON_TRAN_CATEGORY_NAME_6 As String = "Rounding" */

                    if (ordcomp.OrderCategoryId == 1)   // Deposit
                    {
                        iDepositQTY = iDepositQTY + iQTY;
                        iDepositAmount = iDepositAmount + iAmount;
                        iDepositTax1 = iDepositTax1 + iTax1;
                        iDepositTax2 = iDepositTax2 + iTax2;
                        iDepositTax3 = iDepositTax3 + iTax3;
                        iDepositTotal = iDepositTotal + iTotal;
                    }
                    if (ordcomp.OrderCategoryId == 4)   // Discount
                    {
                        iDiscountQTY = iDiscountQTY + iQTY;
                        iDiscountAmount = iDiscountAmount + iAmount;
                        iDiscountTax1 = iDiscountTax1 + iTax1;
                        iDiscountTax2 = iDiscountTax2 + iTax2;
                        iDiscountTax3 = iDiscountTax3 + iTax3;
                        iDiscountTotal = iDiscountTotal + iTotal;
                    }
                    n++;
                }

                if (iDepositQTY > 0)
                {
                    this.dgvData.Rows.Add(new String[] { "0",
                                                             "Deposit",
                                                             iDepositQTY.ToString("0"),
                                                             iDepositAmount.ToString("#,##0.00"),
                                                             iDepositTax1.ToString("#,##0.00"),
                                                             iDepositTax2.ToString("#,##0.00"),
                                                             iDepositTax3.ToString("#,##0.00"),
                                                             iDepositTotal.ToString("#,##0.00")

                                });
                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;
                }
                if (iDiscountQTY > 0)
                {
                    this.dgvData.Rows.Add(new String[] { "0",
                                                             "Discount",
                                                             iDiscountQTY.ToString("0"),
                                                             iDiscountAmount.ToString("#,##0.00"),
                                                             iDiscountTax1.ToString("#,##0.00"),
                                                             iDiscountTax2.ToString("#,##0.00"),
                                                             iDiscountTax3.ToString("#,##0.00"),
                                                             iDiscountTotal.ToString("#,##0.00")

                                });
                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;
                    for (int i = 0; i < dgvData.Columns.Count; i++)
                    {
                        this.dgvData.Rows[dgvData.RowCount - 2].Cells[i].Style.BackColor = Color.LightPink;
                    }
                }
                this.dgvData.Rows.Add(new String[] { "-",
                                                             "TOTAL",
                                                             iSumQTY.ToString("0"),
                                                             iSumAmount.ToString("#,##0.00"),
                                                             iSumTax1.ToString("#,##0.00"),
                                                             iSumTax2.ToString("#,##0.00"),
                                                             iSumTax3.ToString("#,##0.00"),
                                                             iSumTotal.ToString("#,##0.00")

                                });
                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    this.dgvData.Rows[dgvData.RowCount - 2].Cells[i].Style.BackColor = Color.LightBlue;
                    this.dgvData.Rows[dgvData.RowCount - 2].Cells[i].Style.Font = new System.Drawing.Font(this.dgvData.DefaultCellStyle.Font, FontStyle.Bold);
                }
                this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;
            }
        }

        private void bt_Print_Click(object sender, EventArgs e)
        {

            Create_Excel_Sales_Report("EPSON-1");
        }

        private void bt_Excel_Click(object sender, EventArgs e)
        {
            Create_Excel_Sales_Report("FILE");
        }
        private void Create_Excel_Sales_Report(string strDestination)
        {

            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not installed!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Excel.Range chartRange;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            
            xlApp.DisplayAlerts = false;
            xlWorkBook.CheckCompatibility = false;
            xlWorkBook.DoNotPromptForConvert = true;

            int iStartRow = 3;

            // --------------------------------------- Header -------------------------------------
            xlWorkSheet.get_Range("a1", "d2").Merge(false);

            chartRange = xlWorkSheet.get_Range("a1", "d2");
            chartRange.FormulaR1C1 = "Sales Report";
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 3;
            chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            //chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            chartRange.Font.Size = 20;

            // --------------------------------------- Header Time ---------------------------------
            xlWorkSheet.Cells[iStartRow, 1] = "Date Time Issued : ";
            xlWorkSheet.Cells[iStartRow, 3] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xlWorkSheet.get_Range("c" + iStartRow.ToString(), "d" + iStartRow.ToString()).Merge(false);

            iStartRow=iStartRow + 2;

            // --------------------------------------- Summary by Type ---------------------------------
            iStartRow = Generate_Summary_Data(xlWorkSheet, iStartRow);

            // --------------------------------------- Tender Summary ---------------------------------
            iStartRow = Generate_Tender_Summary_Data(xlWorkSheet, iStartRow);


            // --------------------------------------- Footer ---------------------------------
            iStartRow = iStartRow + 1;
            xlWorkSheet.Cells[iStartRow, 1] = "Have a great day !";
            xlWorkSheet.get_Range("a" + iStartRow.ToString(), "d" + iStartRow.ToString()).Merge(false);

            // --------------------------------------- Generate Excel File Name -------------------------------------
            // Get the current directory.
            string strCurrentPath = Directory.GetCurrentDirectory();
            string strExcelFullFileName = strCurrentPath + "\\Report";
            if (!Directory.Exists(strExcelFullFileName))
            {
                Directory.CreateDirectory(strExcelFullFileName);
            }
            strExcelFullFileName = strExcelFullFileName + "\\SalesReport_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            // --------------------------------------- Set Width and Page Margin -------------------------------------
            xlWorkSheet.Columns["A:A"].ColumnWidth = 12;
            xlWorkSheet.Columns["B:D"].ColumnWidth = 7;

            xlWorkSheet.PageSetup.TopMargin = 0.3;
            xlWorkSheet.PageSetup.BottomMargin = 1;
            xlWorkSheet.PageSetup.LeftMargin = 0;
            xlWorkSheet.PageSetup.RightMargin = 0;
            xlWorkSheet.PageSetup.HeaderMargin = 0.1;
            xlWorkSheet.PageSetup.FooterMargin = 0.5;

            if (strDestination != "FILE")
            {
                //xlWorkSheet.PrintOutEx(1, xlWorkBook.Worksheets.Count, 1, false,"EPSON-1", false, Type.Missing, false);
                xlWorkSheet.PrintOutEx(1, 1, 1, false);
                // --------------------------------------- Save Excel File -------------------------------------
                // Save and Close 
                xlWorkBook.SaveAs(strExcelFullFileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }
            else
            {
                xlWorkBook.SaveAs(strExcelFullFileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlApp.Visible = true;
            }

        }



        private int Generate_Summary_Data(Worksheet xlWorkSheet, int iStartRow)
        {
            // --------------------------------------- Summary Header ---------------------------------
            xlWorkSheet.Cells[iStartRow, 1] = "Start : " + dttm_TranStart.Value.ToString("yyyy-MM-dd") + " " + dttm_TranStartTime.Value.ToString("HH:mm:ss");
            iStartRow++;
            // --------------------------------------- Summary Header ---------------------------------
            xlWorkSheet.Cells[iStartRow, 1] = "End   : " + dttm_TranEnd.Value.ToString("yyyy-MM-dd") + " " + dttm_TranEndTime.Value.ToString("HH:mm:ss");
            iStartRow=iStartRow + 2;

            // --------------------------------------- Summary Header ---------------------------------
            xlWorkSheet.Cells[iStartRow, 1] = "Sales Summary by Type";
            iStartRow++;
            int iStartSummaryRow = iStartRow;
            // --------------------------------------- Summary Title ---------------------------------
            xlWorkSheet.Cells[iStartRow, 1] = "Type";
            xlWorkSheet.Cells[iStartRow, 2] = "Amount";
            xlWorkSheet.Cells[iStartRow, 3] = "Tax";
            xlWorkSheet.Cells[iStartRow, 4] = "Sum";
            iStartRow++;

            // --------------------------------------- Summary Title ---------------------------------
            xlWorkSheet.Cells[iStartRow, 2] = "QTY";
            xlWorkSheet.Cells[iStartRow, 3] = "GST";
            xlWorkSheet.Cells[iStartRow, 4] = "PST";
            iStartRow++;

            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();

            ordercomps = dbPOS1.Get_OrderComplete_by_Date_OrderBy_Type(dttm_TranStart.Value.ToString("yyyy-MM-dd"), dttm_TranStartTime.Value.ToString("HH:mm:ss"),
                                                            dttm_TranEnd.Value.ToString("yyyy-MM-dd"), dttm_TranEndTime.Value.ToString("HH:mm:ss"));

            string strTypeName = "";

            float iQTY = 0;
            float iAmount = 0;
            float iTax1 = 0;
            float iTax2 = 0;
            float iTax3 = 0;
            float iTotal = 0;

            float iTypeQTY = 0;
            float iTypeAmount = 0;
            float iTypeTax1 = 0;
            float iTypeTax2 = 0;
            float iTypeTax3 = 0;
            float iTypeTotal = 0;

            float iSumQTY = 0;
            float iSumAmount = 0;
            float iSumTax1 = 0;
            float iSumTax2 = 0;
            float iSumTax3 = 0;
            float iSumTotal = 0;

            float iDepositQTY = 0;
            float iDepositAmount = 0;
            float iDepositTax1 = 0;
            float iDepositTax2 = 0;
            float iDepositTax3 = 0;
            float iDepositTotal = 0;

            float iDiscountQTY = 0;
            float iDiscountAmount = 0;
            float iDiscountTax1 = 0;
            float iDiscountTax2 = 0;
            float iDiscountTax3 = 0;
            float iDiscountTotal = 0;

            int iTempTypeId = 0;
            int n = 0;
            if (ordercomps.Count > 0)
            {
                foreach (var ordcomp in ordercomps)
                {
                    if (n == 0)
                    {
                        iTempTypeId = ordcomp.ProductTypeId;
                    }

                    if (iTempTypeId != ordcomp.ProductTypeId)
                    {
                        if (iTempTypeId != 0)   // Except Deposit, Discount ... add first
                        {
                            // --------------------------------------- Type Summary ---------------------------------
                            xlWorkSheet.Cells[iStartRow, 1] = dbPOS.Get_ProductTypeName_By_Id(iTempTypeId);
                            xlWorkSheet.Cells[iStartRow, 2] = iTypeAmount.ToString("0.00");
                            xlWorkSheet.Cells[iStartRow, 3] = (iTypeTax1 + iTypeTax2 + iTypeTax3).ToString("0.00");
                            xlWorkSheet.Cells[iStartRow, 4] = iTypeTotal.ToString("0.00");
                            //xlWorkSheet.get_Range("c" + iStartRow.ToString(), "d" + iStartRow.ToString()).Merge(false);

                            iStartRow++;
;
                            xlWorkSheet.Cells[iStartRow, 2] = "( " + iTypeQTY.ToString("0") + " Ea)" ;
                            xlWorkSheet.Cells[iStartRow, 3] = iTypeTax1 .ToString("0.00");
                            xlWorkSheet.Cells[iStartRow, 4] = iTypeTax2.ToString("0.00");
                            //xlWorkSheet.get_Range("c" + iStartRow.ToString(), "d" + iStartRow.ToString()).Merge(false);

                            iStartRow++;

                        }

                        iTypeQTY = 0;
                        iTypeAmount = 0;
                        iTypeTax1 = 0;
                        iTypeTax2 = 0;
                        iTypeTax3 = 0;
                        iTypeTotal = 0;

                        iTempTypeId = ordcomp.ProductTypeId;
                    }

                    iQTY = ordcomp.Quantity;
                    iAmount = ordcomp.Amount;
                    iTax1 = ordcomp.Tax1;
                    iTax2 = ordcomp.Tax2;
                    iTax3 = ordcomp.Tax3;
                    iTotal = iAmount + iTax1 + iTax2 + iTax3;

                    iTypeQTY = iTypeQTY + iQTY;
                    iTypeAmount = iTypeAmount + iAmount;
                    iTypeTax1 = iTypeTax1 + iTax1;
                    iTypeTax2 = iTypeTax2 + iTax2;
                    iTypeTax3 = iTypeTax3 + iTax3;
                    iTypeTotal = iTypeTotal + iTotal;

                    iSumQTY = iSumQTY + iQTY;
                    iSumAmount = iSumAmount + iAmount;
                    iSumTax1 = iSumTax1 + iTax1;
                    iSumTax2 = iSumTax2 + iTax2;
                    iSumTax3 = iSumTax3 + iTax3;
                    iSumTotal = iSumTotal + iTotal;

                    /*Public Const CON_TRAN_CATEGORY_NAME_0 As String = "General"
                    Public Const CON_TRAN_CATEGORY_NAME_1 As String = "Deposit"
                    Public Const CON_TRAN_CATEGORY_NAME_2 As String = "Recycling Fee"
                    Public Const CON_TRAN_CATEGORY_NAME_3 As String = "Chill Charge"
                    Public Const CON_TRAN_CATEGORY_NAME_4 As String = "Discount"
                    Public Const CON_TRAN_CATEGORY_NAME_5 As String = "Free Ticket"
                    Public Const CON_TRAN_CATEGORY_NAME_6 As String = "Rounding" */

                    if (ordcomp.OrderCategoryId == 1)   // Deposit
                    {
                        iDepositQTY = iDepositQTY + iQTY;
                        iDepositAmount = iDepositAmount + iAmount;
                        iDepositTax1 = iDepositTax1 + iTax1;
                        iDepositTax2 = iDepositTax2 + iTax2;
                        iDepositTax3 = iDepositTax3 + iTax3;
                        iDepositTotal = iDepositTotal + iTotal;
                    }
                    if (ordcomp.OrderCategoryId == 4)   // Discount
                    {
                        iDiscountQTY = iDiscountQTY + iQTY;
                        iDiscountAmount = iDiscountAmount + iAmount;
                        iDiscountTax1 = iDiscountTax1 + iTax1;
                        iDiscountTax2 = iDiscountTax2 + iTax2;
                        iDiscountTax3 = iDiscountTax3 + iTax3;
                        iDiscountTotal = iDiscountTotal + iTotal;
                    }
                    n++;
                }

                if (iDepositQTY > 0)
                {
                    // ---------------------------------------  Deposit Summary ---------------------------------
                    xlWorkSheet.Cells[iStartRow, 1] = "Deposit";
                    xlWorkSheet.Cells[iStartRow, 2] = iDepositAmount.ToString("0.00");
                    xlWorkSheet.Cells[iStartRow, 3] = (iDepositTax1 + iDepositTax2 + iDepositTax3).ToString("0.00");
                    xlWorkSheet.Cells[iStartRow, 4] = iDepositTotal.ToString("0.00");
                    //xlWorkSheet.get_Range("c" + iStartRow.ToString(), "d" + iStartRow.ToString()).Merge(false);

                    iStartRow++;

                    xlWorkSheet.Cells[iStartRow, 2] = "( " + iDepositQTY.ToString("0") + " Ea)";
                    xlWorkSheet.Cells[iStartRow, 3] = iDepositTax1.ToString("0.00");
                    xlWorkSheet.Cells[iStartRow, 4] = iDepositTax2.ToString("0.00");
                    //xlWorkSheet.get_Range("c" + iStartRow.ToString(), "d" + iStartRow.ToString()).Merge(false);

                    iStartRow++;

                }
                if (iDiscountQTY > 0)
                {
                    // ---------------------------------------  Discount Summary  ---------------------------------
                    xlWorkSheet.Cells[iStartRow, 1] = "Discount";
                    xlWorkSheet.Cells[iStartRow, 2] = iDiscountAmount.ToString("0.00");
                    xlWorkSheet.Cells[iStartRow, 3] = (iDiscountTax1 + iDiscountTax2 + iDiscountTax3).ToString("0.00");
                    xlWorkSheet.Cells[iStartRow, 4] = iDiscountTotal.ToString("0.00");
                    //xlWorkSheet.get_Range("c" + iStartRow.ToString(), "d" + iStartRow.ToString()).Merge(false);

                    iStartRow++;

                    xlWorkSheet.Cells[iStartRow, 2] = "( " + iDiscountQTY.ToString("0") + " Ea)";
                    xlWorkSheet.Cells[iStartRow, 3] = iDiscountTax1.ToString("0.00");
                    xlWorkSheet.Cells[iStartRow, 4] = iDiscountTax2.ToString("0.00");
                    //xlWorkSheet.get_Range("c" + iStartRow.ToString(), "d" + iStartRow.ToString()).Merge(false);

                    iStartRow++;
                }
                // --------------------------------------- TOTAL ---------------------------------
                xlWorkSheet.Cells[iStartRow, 1] = "TOTAL";
                xlWorkSheet.Cells[iStartRow, 2] = iSumAmount.ToString("0.00");
                xlWorkSheet.Cells[iStartRow, 3] = (iSumTax1 + iSumTax2 + iSumTax3).ToString("0.00");
                xlWorkSheet.Cells[iStartRow, 4] = iSumTotal.ToString("0.00");
                //xlWorkSheet.get_Range("c" + iStartRow.ToString(), "d" + iStartRow.ToString()).Merge(false);
                iStartRow++;

                xlWorkSheet.Cells[iStartRow, 2] = "( " + iSumQTY.ToString("0") + " Ea)";
                xlWorkSheet.Cells[iStartRow, 3] = iSumTax1.ToString("0.00");
                xlWorkSheet.Cells[iStartRow, 4] = iSumTax2.ToString("0.00");
                //xlWorkSheet.get_Range("c" + iStartRow.ToString(), "d" + iStartRow.ToString()).Merge(false);

                //iStartRow++;
            }
            // --------------------------------------- Set Boder ---------------------------------
            Excel.Range formatRange;
            formatRange = xlWorkSheet.get_Range("A" + iStartSummaryRow.ToString(), "D" + iStartRow.ToString()) ;
            formatRange.Font.Size = 8;
            Excel.Borders border = formatRange.Borders;
            border.LineStyle = Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;
            formatRange.BorderAround(Excel.XlLineStyle.xlContinuous,
            Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic,
            Excel.XlColorIndex.xlColorIndexAutomatic);

            // --------------------------------------- Set Boder on title ---------------------------------
            formatRange = xlWorkSheet.get_Range("A" + iStartSummaryRow.ToString(), "D" + (iStartSummaryRow+1).ToString());
            formatRange.EntireRow.Font.Bold = true;
            formatRange.BorderAround(Excel.XlLineStyle.xlContinuous,
            Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic,
            Excel.XlColorIndex.xlColorIndexAutomatic);

            // --------------------------------------- Set Boder on Total ---------------------------------
            formatRange = xlWorkSheet.get_Range("A" + (iStartRow - 1).ToString(), "D" + (iStartRow).ToString());
            formatRange.EntireRow.Font.Bold = true;
            formatRange.BorderAround(Excel.XlLineStyle.xlContinuous,
            Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic,
            Excel.XlColorIndex.xlColorIndexAutomatic);


            iStartRow++;
            return iStartRow;
        }
        private int Generate_Tender_Summary_Data(Worksheet xlWorkSheet, int iStartRow)
        {
            // --------------------------------------- Summary Header ---------------------------------
            iStartRow++;
            xlWorkSheet.Cells[iStartRow, 1] = "Tender Summary";
            iStartRow++;
            int iStartSummaryRow = iStartRow;
            // --------------------------------------- Summary Title ---------------------------------
            xlWorkSheet.Cells[iStartRow, 1] = "Tender";
            xlWorkSheet.Cells[iStartRow, 2] = "Amount";
            xlWorkSheet.Cells[iStartRow, 3] = "Tip";
            xlWorkSheet.Cells[iStartRow, 4] = "Total";
            iStartRow++;

            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();

            trancols = dbPOS1.Get_TranCollection_by_DateTimeRange(dttm_TranStart.Value.ToString("yyyy-MM-dd"), dttm_TranStartTime.Value.ToString("HH:mm:ss"),
                                                            dttm_TranEnd.Value.ToString("yyyy-MM-dd"), dttm_TranEndTime.Value.ToString("HH:mm:ss"));

            string[] strColTypeName = new string[] { "Cash", "Debit", "Visa", "MasterCard", "Amex", "GiftCard" };

            float[] iQTY = new float[] { 0, 0, 0, 0, 0, 0 };
            float[] iNetAmount = new float[] { 0, 0, 0, 0, 0, 0 };
            float[] iTip = new float[] { 0, 0, 0, 0, 0, 0 };
            float[] iTotal = new float[] { 0, 0, 0, 0, 0, 0 };

            float iTotalQTY = 0;
            float iTotalNetAmount = 0;
            float iTotalTip = 0;
            float iTotalTotal = 0;

            string strTemp = "";
            int n = 0;
            if (trancols.Count > 0)
            {
                foreach (var trancol in trancols)
                {
                    for (int i = 0; i < strColTypeName.Length; i++)
                    {
                        if (trancol.CollectionType == strColTypeName[i])
                        {
                            iQTY[i]++;
                            iNetAmount[i] = iNetAmount[i] + trancol.TotalPaid;
                            iTip[i] = iTip[i] + trancol.TotalTip;
                            iTotal[i] = iTotal[i] + (trancol.TotalPaid + trancol.TotalTip);

                            iTotalQTY++;
                            iTotalNetAmount = iTotalNetAmount + trancol.TotalPaid;
                            iTotalTip = iTotalTip + trancol.TotalTip;
                            iTotalTotal = iTotalTotal + (trancol.TotalPaid + trancol.TotalTip); ;
                        }
                    }
                }
            }

            for (int i = 0; i < strColTypeName.Length; i++)
            {
                if (iQTY[i] > 0)
                {
                    // --------------------------------------- Tender ---------------------------------
                    xlWorkSheet.Cells[iStartRow, 1] = strColTypeName[i] + " ( " + iQTY[i].ToString() + " )";
                    xlWorkSheet.Cells[iStartRow, 2] = iNetAmount[i].ToString("0.00");
                    xlWorkSheet.Cells[iStartRow, 3] = iTip[i].ToString("0.00");
                    xlWorkSheet.Cells[iStartRow, 4] = iTotal[i].ToString("0.00");
                    //xlWorkSheet.get_Range("c" + iStartRow.ToString(), "d" + iStartRow.ToString()).Merge(false);
                    iStartRow++;
                }
            }
            // --------------------------------------- Tender ---------------------------------
            xlWorkSheet.Cells[iStartRow, 1] = "TOTAL" + " (" + iTotalQTY.ToString() + " )";
            xlWorkSheet.Cells[iStartRow, 2] = iTotalNetAmount.ToString("0.00");
            xlWorkSheet.Cells[iStartRow, 3] = iTotalTip.ToString("0.00");
            xlWorkSheet.Cells[iStartRow, 4] = iTotalTotal.ToString("0.00");
            //xlWorkSheet.get_Range("c" + iStartRow.ToString(), "d" + iStartRow.ToString()).Merge(false);
            // --------------------------------------- Set Boder ---------------------------------
            Excel.Range formatRange;
            formatRange = xlWorkSheet.get_Range("A" + iStartSummaryRow.ToString(), "D" + iStartRow.ToString());
            formatRange.Font.Size = 8;
            Excel.Borders border = formatRange.Borders;
            border.LineStyle = Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;
            formatRange.BorderAround(Excel.XlLineStyle.xlContinuous,
            Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic,
            Excel.XlColorIndex.xlColorIndexAutomatic);

            // --------------------------------------- Set Boder on title ---------------------------------
            formatRange = xlWorkSheet.get_Range("A" + iStartSummaryRow.ToString(), "D" + iStartSummaryRow.ToString());
            formatRange.EntireRow.Font.Bold = true;
            formatRange.BorderAround(Excel.XlLineStyle.xlContinuous,
            Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic,
            Excel.XlColorIndex.xlColorIndexAutomatic);

            // --------------------------------------- Set Boder on Total ---------------------------------
            formatRange = xlWorkSheet.get_Range("A" + (iStartRow).ToString(), "D" + (iStartRow).ToString());
            formatRange.EntireRow.Font.Bold = true;
            formatRange.BorderAround(Excel.XlLineStyle.xlContinuous,
            Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic,
            Excel.XlColorIndex.xlColorIndexAutomatic);

            iStartRow++;
            return iStartRow;
        }
    }
}
