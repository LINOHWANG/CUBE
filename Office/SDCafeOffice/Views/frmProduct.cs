using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDCafeOffice;
using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
using SDCafeCommon.Utilities;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Font = Microsoft.Office.Interop.Excel.Font;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace SDCafeOffice.Views
{
    public partial class frmProduct : Form
    {
        private Func<string> toString;
        List<POS_LoginUserModel> loginUsers = new List<POS_LoginUserModel>();
        List<POS_ProductModel> prods = new List<POS_ProductModel>();
        List<POS_ProductTypeModel> pTypes = new List<POS_ProductTypeModel>();
        List<POS_SysConfigModel> sysConfs = new List<POS_SysConfigModel>();
        Utility util = new Utility();
        String[] strTaxes = new String[3];
        public frmProduct()
        {
            InitializeComponent();
        }

        public frmProduct(String strInProdID)
        {
            InitializeComponent();
            txt_ProdId.Text = strInProdID;
            txt_ProdId.Enabled = false;
            Get_SysConfig_TaxTitle();
            Load_ProdType_Combo_Contents();
            if (String.IsNullOrEmpty(strInProdID))
            {
                txtMessage.Text = "No product was selected. Insert(Save) mode is on!";
            }
            else
            {
                txtMessage.Text = "Selected Product ID : " + strInProdID;
                Load_Product_Info(strInProdID);
            }
        }

        private void Load_ProdType_Combo_Contents()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            pTypes.Clear();
            pTypes = dbPOS.Get_All_ProductTypes();
            if (pTypes.Count > 0)
            {
                int i = 0;
                foreach (var ptype in pTypes)
                {
                    cb_ProdType.Items.Add(ptype.TypeName);
                }
            }
        }

        private void Get_SysConfig_TaxTitle()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            sysConfs.Clear();
            sysConfs = dbPOS.Get_SysConfig_By_Name("Tax1");
            if (sysConfs.Count == 1)
            {
                checkTax1.Text = sysConfs[0].ConfigValue;
            }
            sysConfs.Clear();
            sysConfs = dbPOS.Get_SysConfig_By_Name("Tax2");
            if (sysConfs.Count == 1)
            {
                checkTax2.Text = sysConfs[0].ConfigValue;
            }
            sysConfs.Clear();
            sysConfs = dbPOS.Get_SysConfig_By_Name("Tax3");
            if (sysConfs.Count == 1)
            {
                checkTax3.Text = sysConfs[0].ConfigValue;
            }
        }

        private void Load_Product_Info(string strInProdID)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            prods.Clear();
            prods = dbPOS.Get_Product_By_ID(int.Parse(strInProdID));
            if (prods.Count == 1)
            {
                txt_ProdId.Text = prods[0].Id.ToString();
                txt_ProductName.Text = prods[0].ProductName;
                txt_SecondName.Text = prods[0].SecondName;
                cb_ProdType.SelectedIndex = cb_ProdType.FindStringExact(dbPOS.Get_ProductTypeName_By_Id(prods[0].ProductTypeId));
                txt_IUnitPrice.Text = prods[0].InUnitPrice.ToString();
                txt_OUnitPrice.Text = prods[0].OutUnitPrice.ToString();
                txt_PromPrice1.Text = prods[0].PromoPrice1.ToString();
                txt_PromPrice2.Text = prods[0].PromoPrice2.ToString();
                txt_PromPrice3.Text = prods[0].PromoPrice3.ToString();
                checkTax1.Checked = prods[0].IsTax1;
                checkTax2.Checked = prods[0].IsTax2;
                checkTax3.Checked = prods[0].IsTax3;
                checkPRT1.Checked = prods[0].IsPrinter1;
                checkPRT2.Checked = prods[0].IsPrinter2;
                checkPRT3.Checked = prods[0].IsPrinter3;
                checkPRT4.Checked = prods[0].IsPrinter4;
                checkPRT5.Checked = prods[0].IsPrinter5;
                checkTaxInv.Checked = prods[0].IsTaxInverseCalculation;
                checkSoldOut.Checked = prods[0].IsSoldOut;
                dttm_PromStart.Value = DateTime.ParseExact(prods[0].PromoStartDate.ToString(),"yyyy-MM-dd", CultureInfo.InvariantCulture);
                dttm_PromEnd.Value = DateTime.ParseExact(prods[0].PromoEndDate.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture); //prods[0].PromoEndDate.ToString("yyyy-MM-dd");
                txt_Deposit.Text = prods[0].Deposit.ToString();
                txt_RecyclingFee.Text = prods[0].RecyclingFee.ToString();
                txt_ChillCharge.Text = prods[0].ChillCharge.ToString();
                
                if (prods[0].MemoText == null)
                {
                    txt_Memo.Text = "";
                }
                else
                {
                    txt_Memo.Text = prods[0].MemoText.ToString();
                }
                txt_BarCode.Text = prods[0].BarCode;
                checkManual.Checked = prods[0].IsManualItem;
                txt_Balance.Text = prods[0].Balance.ToString();

                if (txt_BarCode.Text.Length > 0)
                {
                    bt_RprintLabel.Enabled = true;
                    txt_PrintCopy.Enabled = true;
                    if ((txt_PrintCopy.Text.Length == 0) | (txt_PrintCopy.Text == "0"))
                    {
                        txt_PrintCopy.Text = "1";
                    }
                }
                else
                {
                    bt_RprintLabel.Enabled = false;
                    txt_PrintCopy.Enabled = false;
                }

                //cb_PromDay1.Items[]
                //cb_PromDay2.Items[]
                //cb_PromDay3.Items[]
            }

        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            if (String.IsNullOrEmpty(txt_ProdId.Text))
            {
                if (Insert_Product_From_View())
                {
                    txtMessage.Text = "Successfully Added!";
                }
            }
            else
            {
                if (Update_Product_From_View())
                {
                    txtMessage.Text = "Successfully updated!";
                }
            }
        }

        private bool Update_Product_From_View()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            int iTypeId = 0;

            if (String.IsNullOrEmpty(txt_ProductName.Text))
            {
                txtMessage.Text = "Product Name is empty!";
                txt_ProductName.Focus();
                txt_ProductName.BackColor = Color.DarkRed;
                return false;
            }
            else
            {
                txt_ProductName.BackColor = Color.Empty;
            }

            if (cb_ProdType.SelectedItem != null)
            {
                pTypes = dbPOS.Get_ProductTypeId_By_TypeName(cb_ProdType.SelectedItem.ToString());
                if (pTypes.Count == 1)
                {
                    iTypeId = pTypes[0].Id;
                }
                cb_ProdType.BackColor = Color.Empty;
            }
            else
            {
                txtMessage.Text = "Please select a Product Type!";
                cb_ProdType.Focus();
                cb_ProdType.BackColor = Color.DarkRed;
                return false;
            }

            if (String.IsNullOrEmpty(txt_IUnitPrice.Text)) txt_IUnitPrice.Text = "0";
            if (String.IsNullOrEmpty(txt_OUnitPrice.Text)) txt_OUnitPrice.Text = "0";

            if (String.IsNullOrEmpty(cb_PromDay1.Text)) cb_PromDay1.Text = "0";
            if (String.IsNullOrEmpty(cb_PromDay2.Text)) cb_PromDay2.Text = "0";
            if (String.IsNullOrEmpty(cb_PromDay3.Text)) cb_PromDay3.Text = "0";
            if (String.IsNullOrEmpty(txt_PromPrice1.Text)) txt_PromPrice1.Text = "0";
            if (String.IsNullOrEmpty(txt_PromPrice2.Text)) txt_PromPrice2.Text = "0";
            if (String.IsNullOrEmpty(txt_PromPrice3.Text)) txt_PromPrice3.Text = "0";

            if (String.IsNullOrEmpty(txt_Deposit.Text)) txt_Deposit.Text = "0";
            if (String.IsNullOrEmpty(txt_RecyclingFee.Text)) txt_RecyclingFee.Text = "0";
            if (String.IsNullOrEmpty(txt_ChillCharge.Text)) txt_ChillCharge.Text = "0";

            if (String.IsNullOrEmpty(txt_Balance.Text)) txt_Balance.Text = "0";

            if (txt_Memo.Text.Length > 500) txt_Memo.Text = txt_Memo.Text.Substring(0, 500);

            prods.Clear();
            prods.Add(new POS_ProductModel()
            {
                Id = int.Parse(txt_ProdId.Text),
                ProductName = txt_ProductName.Text,
                SecondName = txt_SecondName.Text,
                ProductTypeId = iTypeId,
                InUnitPrice = float.Parse(txt_IUnitPrice.Text),
                OutUnitPrice = float.Parse(txt_OUnitPrice.Text),
                IsTax1 = checkTax1.Checked,
                IsTax2 = checkTax2.Checked,
                IsTax3 = checkTax3.Checked,
                IsTaxInverseCalculation = checkTaxInv.Checked,
                IsPrinter1 = checkPRT1.Checked,
                IsPrinter2 = checkPRT2.Checked,
                IsPrinter3 = checkPRT3.Checked,
                IsPrinter4 = checkPRT4.Checked,
                IsPrinter5 = checkPRT5.Checked,
                PromoStartDate = dttm_PromStart.Value.ToString("yyyy-MM-dd"),
                PromoEndDate = dttm_PromEnd.Value.ToString("yyyy-MM-dd"),
                PromoDay1 = int.Parse(cb_PromDay1.Text),
                PromoDay2 = int.Parse(cb_PromDay2.Text),
                PromoDay3 = int.Parse(cb_PromDay3.Text),
                PromoPrice1 = float.Parse(txt_PromPrice1.Text),
                PromoPrice2 = float.Parse(txt_PromPrice2.Text),
                PromoPrice3 = float.Parse(txt_PromPrice3.Text),
                IsSoldOut = checkSoldOut.Checked,
                Deposit = float.Parse(txt_Deposit.Text),
                RecyclingFee = float.Parse(txt_RecyclingFee.Text),
                ChillCharge = float.Parse(txt_ChillCharge.Text),
                MemoText = txt_Memo.Text,
                IsManualItem = checkManual.Checked,
                Balance = int.Parse(txt_Balance.Text),
                BarCode = txt_BarCode.Text
            });
            int iProdCnt = dbPOS.Update_Product(prods[0]);
            if (string.IsNullOrEmpty(txt_BarCode.Text))
            {
                Update_Product_BarCode(prods[0].Id, prods[0]);
            }
            Load_Product_Info(prods[0].Id.ToString());
            return true;
        }


        private bool Insert_Product_From_View()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            int iTypeId = 0;

            if (String.IsNullOrEmpty(txt_ProductName.Text))
            {
                txtMessage.Text = "Product Name is empty!";
                txt_ProductName.Focus();
                txt_ProductName.BackColor = Color.DarkRed;
                return false;
            }
            else
            {
                txt_ProductName.BackColor = Color.Empty;
            }
            if (cb_ProdType.SelectedItem != null)
            {
                pTypes = dbPOS.Get_ProductTypeId_By_TypeName(cb_ProdType.SelectedItem.ToString());
                if (pTypes.Count == 1)
                {
                    iTypeId = pTypes[0].Id;
                }
                cb_ProdType.BackColor = Color.Empty;
            }
            else
            {
                txtMessage.Text = "Please select a Product Type!";
                cb_ProdType.Focus();
                cb_ProdType.BackColor = Color.DarkRed;
                return false;
            }
            if (String.IsNullOrEmpty(txt_IUnitPrice.Text)) txt_IUnitPrice.Text = "0";
            if (String.IsNullOrEmpty(txt_OUnitPrice.Text)) txt_OUnitPrice.Text = "0";

            if (String.IsNullOrEmpty(cb_PromDay1.Text)) cb_PromDay1.Text = "0";
            if (String.IsNullOrEmpty(cb_PromDay2.Text)) cb_PromDay2.Text = "0";
            if (String.IsNullOrEmpty(cb_PromDay3.Text)) cb_PromDay3.Text = "0";
            if (String.IsNullOrEmpty(txt_PromPrice1.Text)) txt_PromPrice1.Text = "0";
            if (String.IsNullOrEmpty(txt_PromPrice2.Text)) txt_PromPrice2.Text = "0";
            if (String.IsNullOrEmpty(txt_PromPrice3.Text)) txt_PromPrice3.Text = "0";

            if (String.IsNullOrEmpty(txt_Deposit.Text)) txt_Deposit.Text = "0";
            if (String.IsNullOrEmpty(txt_RecyclingFee.Text)) txt_RecyclingFee.Text = "0";
            if (String.IsNullOrEmpty(txt_ChillCharge.Text)) txt_ChillCharge.Text = "0";

            if (String.IsNullOrEmpty(txt_Balance.Text)) txt_Balance.Text = "0";

            if (txt_Memo.Text.Length > 500) txt_Memo.Text = txt_Memo.Text.Substring(0, 500);
                
            prods.Add(new POS_ProductModel()
            {
                ProductName = txt_ProductName.Text,
                SecondName = txt_SecondName.Text,
                ProductTypeId = iTypeId,
                InUnitPrice = float.Parse(txt_IUnitPrice.Text),
                OutUnitPrice = float.Parse(txt_OUnitPrice.Text),
                IsTax1 = checkTax1.Checked,
                IsTax2 = checkTax2.Checked,
                IsTax3 = checkTax3.Checked,
                IsTaxInverseCalculation = checkTaxInv.Checked,
                IsPrinter1 = checkPRT1.Checked,
                IsPrinter2 = checkPRT2.Checked,
                IsPrinter3 = checkPRT3.Checked,
                IsPrinter4 = checkPRT4.Checked,
                IsPrinter5 = checkPRT5.Checked,
                PromoStartDate = dttm_PromStart.Value.ToString("yyyy-MM-dd"),
                PromoEndDate = dttm_PromEnd.Value.ToString("yyyy-MM-dd"),
                PromoDay1 = int.Parse(cb_PromDay1.Text),
                PromoDay2 = int.Parse(cb_PromDay2.Text),
                PromoDay3 = int.Parse(cb_PromDay3.Text),
                PromoPrice1 = float.Parse(txt_PromPrice1.Text),
                PromoPrice2 = float.Parse(txt_PromPrice2.Text),
                PromoPrice3 = float.Parse(txt_PromPrice3.Text),
                IsSoldOut = checkSoldOut.Checked,
                Deposit = float.Parse(txt_Deposit.Text),
                RecyclingFee = float.Parse(txt_RecyclingFee.Text),
                ChillCharge = float.Parse(txt_ChillCharge.Text),
                MemoText = txt_Memo.Text,
                BarCode = txt_BarCode.Text, //string.Empty,
                IsManualItem = checkManual.Checked,
                Balance = int.Parse(txt_Balance.Text)
                
            });
            int iProdId = dbPOS.Insert_Product(prods[0]);
            if (string.IsNullOrEmpty(txt_BarCode.Text))
            {
                Update_Product_BarCode(iProdId, prods[0]);
            }
            Load_Product_Info(iProdId.ToString());
            return true;
        }

        private void Update_Product_BarCode(int iProdId, POS_ProductModel pos_Product)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            string strBarCodeFmt = "000000";
            pos_Product.BarCode = iProdId.ToString(strBarCodeFmt) + pos_Product.ProductTypeId.ToString(strBarCodeFmt);
            pos_Product.Id = iProdId;
            dbPOS.Update_Product(pos_Product);
            txt_BarCode.Text = pos_Product.BarCode;
        }

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_Save.PerformClick();
            }
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            Insert_Product_From_View();
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            int iSelectedProdId = Convert.ToInt32(txt_ProdId.Text);
            if (iSelectedProdId > 0)
            {
                DataAccessPOS dbPOS = new DataAccessPOS();
                dbPOS.Delete_Product_By_Id(iSelectedProdId);
                bt_Exit.PerformClick();
            }
        }

        private void bt_RprintLabel_Click(object sender, EventArgs e)
        {
            int iSelectedProdId = Convert.ToInt32(txt_ProdId.Text);
            int iPrintCopies = Convert.ToInt32(txt_PrintCopy.Text);
            if ((iSelectedProdId > 0) && (iPrintCopies > 0))
            {
                Create_Excel_Barcode_Label(iPrintCopies);
            }
        }

        private void Create_Excel_Barcode_Label(int iCopies)
        {
            string strExcelLabelFile = "";

            // --------------------------------------- GET Excel File Name -------------------------------------
            DataAccessPOS dbPOS = new DataAccessPOS();
            sysConfs.Clear();
            sysConfs = dbPOS.Get_SysConfig_By_Name("BARCODE_LABEL_FILE");
            if (sysConfs.Count == 1)
            {
                strExcelLabelFile = sysConfs[0].ConfigValue;
            }
            if (string.IsNullOrEmpty(strExcelLabelFile))
            {
                return;
            }
            // --------------------------------------- Create Excel Object -------------------------------------
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not installed!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            // --------------------------------------- Open Excel File Name -------------------------------------
            xlWorkBook = xlApp.Workbooks.Open(strExcelLabelFile);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlApp.DisplayAlerts = false;
            xlWorkBook.CheckCompatibility = false;
            xlWorkBook.DoNotPromptForConvert = true;

            // --------------------------------------- Generate Excel File Name -------------------------------------
            // Get the current directory.
            string strCurrentPath = Directory.GetCurrentDirectory();
            string strExcelFullFileName = strCurrentPath + "\\Temp";
            if (!Directory.Exists(strExcelFullFileName))
            {
                Directory.CreateDirectory(strExcelFullFileName);
            }
            strExcelFullFileName = strExcelFullFileName + "\\BarCodeLabel.xls";

            // Setting Printer
            // Create an object that contains printer settings.
            PrinterSettings printerSettings = new PrinterSettings();
            string strPrinterName = @"LeftHans2 LH-560";
            // Define the printer to use.
            printerSettings.PrinterName = strPrinterName;
            //xlApp.ActivePrinter.StartsWith(strPrinterName);
            //-----------------------------------------------------------------------------------------------------
            // Fill Contents
            Excel.Range cell = xlWorkSheet.Evaluate("PRODNAME");
            if (cell != null) cell.Value = txt_ProductName.Text;
            cell = xlWorkSheet.Evaluate("BARCODE");
            if (cell != null) cell.Value = "*" + txt_BarCode.Text.Trim() + "*";
            cell = xlWorkSheet.Evaluate("BARCODETXT");
            if (cell != null) cell.Value = "*" + txt_BarCode.Text.Trim() + "*";
            cell = xlWorkSheet.Evaluate("UNITPRICE");
            if (cell != null) cell.Value = "Price : $" + string.Format(txt_OUnitPrice.Text,"C2");
            //xlWorkSheet.PrintOutEx(1, xlWorkBook.Worksheets.Count, 1, false,"EPSON-1", false, Type.Missing, false);
            xlWorkSheet.PrintOutEx(1, 1, iCopies, false, printerSettings.PrinterName);
            // --------------------------------------- Save Excel File -------------------------------------
            // Save and Close 
            //xlWorkBook.SaveAs(strExcelFullFileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, 
            //                                        Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Save();
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

        }
    }
}
