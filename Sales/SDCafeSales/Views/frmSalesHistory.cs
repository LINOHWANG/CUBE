using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
using SDCafeCommon.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using static System.Net.WebRequestMethods;


namespace SDCafeSales.Views
{
    public partial class frmSalesHistory : Form
    {
        frmSalesMain FrmSalesMain;
        frmEnterAmount FrmEnterAmount;

        List<POS1_TranCollectionModel> trancols = new List<POS1_TranCollectionModel>();
        List<POS_LoginUserModel> loginUsers = new List<POS_LoginUserModel>();
        POS1_TranCollectionModel trancolSelected = new POS1_TranCollectionModel();
        List<POS1_TranCollectionModel> trancolsRelated = new List<POS1_TranCollectionModel>();
        // string array to store all type of tenters
        string[] strTenderTypes; //Feature #3264
        private string strSelInvNo;
        private int iSelInvNo = 0;
        private int iPpleCount = 0;
        Utility util = new Utility();
        private ImageList m_imageList;
        private List<POS1_OrderCompleteModel> compOrders;
        
        public string p_strUserName { get; set; }
        public string p_strStation { get; set; }
        public string p_strLoginPassword { get; set; }
        public int p_intLoginUserId { get; set; }
        public bool p_blnPaymentree { get; set; }
        public string p_strUserPassCode { get; private set; }

        private string m_strTax1Name;
        private string m_strTax2Name;
        private string m_strTax3Name;

        private float m_fRefundAmt;
        private bool m_bExcludeTip;

        public frmSalesHistory(frmSalesMain _FrmSalesMain)
        {
            InitializeComponent();
            this.FrmSalesMain = _FrmSalesMain;
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void bt_Query_Click(object sender, EventArgs e)
        {
            dgvData_Initialize();
            dgvItems_Initialize();

            float iTotalCount = 0;
            float iTotalSales = 0;
            float iVoidCount = 0;
            float iVoidSales = 0;
            float iTotalTips = 0;
            float iVoidTips = 0;
            string strHTMLBody = "";
            string strConfig = "";

            string strTenderType = "";
            int iRowCount = 0;
            if (cb_Tender.SelectedIndex > 0)
            {
                strTenderType = cb_Tender.SelectedItem.ToString();
            }
            else
            {
                strTenderType = "All";
            }
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            trancols = dbPOS1.Get_TranCollection_by_Date_Tender(dttm_TranStart.Value.ToString("yyyy-MM-dd"), dttm_TranEnd.Value.ToString("yyyy-MM-dd"), strTenderType);
            if (trancols.Count > 0)
            {
                iTotalCount = trancols.Count;
                foreach (var trancol in trancols)
                {
                    iRowCount++;
                    iTotalSales = iTotalSales + (trancol.Amount + trancol.Tax1 + trancol.Tax2 + trancol.Tax3);
                    iTotalTips = iTotalTips + trancol.TotalTip;
                    this.dgvData.Rows.Add(new String[] { trancol.CreateDate.ToString() + " " + trancol.CreateTime.ToString(),
                                                         trancol.InvoiceNo.ToString(),
                                                         trancol.CollectionType,
                                                         trancol.Amount.ToString("0.00"),
                                                         trancol.Tax1.ToString("0.00"),
                                                         trancol.Tax2.ToString("0.00"),
                                                         trancol.Tax3.ToString("0.00"),
                                                         trancol.TotalTip.ToString("0.00"),
                                                         trancol.TotalPaid.ToString("0.00"),
                                                         //trancol.TotalTip.ToString("0.00"),
                                                         trancol.IsVoid.ToString()
                    });
                    // set the row tag with trancol's id
                    this.dgvData.Rows[iRowCount - 1].Tag = trancol.Id.ToString();

                    if (trancol.IsVoid)
                    {
                        iVoidCount++;
                        iVoidSales = iVoidSales + (trancol.Amount + trancol.Tax1 + trancol.Tax2 + trancol.Tax3);
                        iVoidTips = iVoidTips + trancol.TotalTip;
                        for (int i = 0; i < 9; i++)
                        {
                            this.dgvData.Rows[dgvData.RowCount - 2].Cells[i].Style.BackColor = Color.LightSalmon;
                            this.dgvData.Rows[dgvData.RowCount - 2].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                        }
                    }

                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;
                }
                txt_TotalCount.Text = iTotalCount.ToString();
                txt_TotalSales.Text = iTotalSales.ToString("C");
                txt_TotalTips.Text = iTotalTips.ToString("C");

                txt_TotalVoidCount.Text = iVoidCount.ToString();
                txt_TotalVoidCount.BackColor = Color.LightSalmon;
                txt_TotalVoidSales.Text = iVoidSales.ToString("C");
                txt_TotalVoidSales.BackColor = Color.LightSalmon;
                txt_VoidTips.Text = iVoidTips.ToString("C");
                txt_VoidTips.BackColor = Color.LightSalmon;

                txt_TotalSum.Text = (iTotalSales - iVoidSales).ToString("C");
                txt_TipSum.Text = (iTotalTips - iVoidTips).ToString("C");

                string strFirstDayofMonth = dttm_TranStart.Value.ToString("yyyy-MM") + "-01";
                string strLastDayofMonth = dttm_TranEnd.Value.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

                trancols = dbPOS1.Get_TranCollection_by_Date_Tender(strFirstDayofMonth, strLastDayofMonth, strTenderType);

                double dblMonthlyTotal = trancols.Where(item => item.IsVoid != true).Sum(item => item.TotalPaid);

                DataAccessPOS dbPOS = new DataAccessPOS();
                strConfig = dbPOS.Get_SysConfig_By_Name("CON_SEND_EMAIL_REPORT")[0].ConfigValue.Trim();
                if (strConfig.Contains("TRUE"))
                {
                    strHTMLBody = "<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>" + System.Environment.NewLine +
                         "<html>" + System.Environment.NewLine +
                         "<head>" + System.Environment.NewLine +
                         " <style>#grad1 {" + System.Environment.NewLine +
                         " background-image: linear-gradient(to right, white , gray);" + System.Environment.NewLine +
                         " font-family: verdana;" + System.Environment.NewLine +
                         " }</style>" + System.Environment.NewLine +
                         "</head>" + System.Environment.NewLine +
                         "<body>" + System.Environment.NewLine +
                         " <h3 style='color: #000000;'> Dear Business Owner,</h3>" + System.Environment.NewLine +
                         " <h4 style='color: #000000;'> Sales Query action has been taken at YOUR POS today..<br /> " + System.Environment.NewLine +
                         /*" <span style='color: #FF0000;'> <strong>Please find attached excel file for your reference.</strong> </span>" + System.Environment.NewLine +*/
                         " <br /> Date : " + dttm_TranStart.Value.ToString("yyyy-MM-dd") + " to " + dttm_TranEnd.Value.ToString("yyyy-MM-dd") + System.Environment.NewLine +
                         " <br /> Total Net Sales : " + String.Format(txt_TotalSales.Text, "C") + System.Environment.NewLine +
                         " <br /> Total Void : " + String.Format(txt_TotalVoidSales.Text, "C") + System.Environment.NewLine +
                         " <br /> Total Sales : " + String.Format(txt_TotalSum.Text, "C") + System.Environment.NewLine +
                         " <br /> Monthly Total : " + dblMonthlyTotal.ToString("C") + System.Environment.NewLine +
                         " <br /> " + System.Environment.NewLine +
                         " <br /><i> This email was automatically generated and sent from YOUR POS.. </i>" + System.Environment.NewLine +
                         " <br />Best Regards," + System.Environment.NewLine +
                         " </h4>" + System.Environment.NewLine +
                         " <h3 ><strong><span style='color: #0000ff;'>TechServe POS</span></strong><span style='color: #566573;'> &copy; 2023 <a href='https://techservepos.com'>techservepos.com</a></span></h3>" + System.Environment.NewLine +
                         "</body>" + System.Environment.NewLine +
                         "</html>" + System.Environment.NewLine;
                    util.SendEmail("Sales History Query", strHTMLBody, "");
                }
            }
            if (dgvData.RowCount > 0)
            {
                bt_ExcelExport.Enabled = true;
            }
            else
            {
                bt_ExcelExport.Enabled = false;
            }
            RefreshCardProcessButtons(0, 0);
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
            this.dgvData.ColumnCount = 10;
            this.dgvData.Columns[0].Name = "DateTime";
            this.dgvData.Columns[0].Width = 150;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[1].Name = "Invoice #";
            this.dgvData.Columns[1].Width = 120;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = "Payment Type";
            this.dgvData.Columns[2].Width = 100;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = "Net";
            this.dgvData.Columns[3].Width = 100;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[4].Name = m_strTax1Name; // "GST";
            this.dgvData.Columns[4].Width = 70;
            this.dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[5].Name = m_strTax2Name; // "GST";
            this.dgvData.Columns[5].Width = 70;
            this.dgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[6].Name = m_strTax3Name; // "GST";
            this.dgvData.Columns[6].Width = 70;
            this.dgvData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[7].Name = "Tip"; // "GST";
            this.dgvData.Columns[7].Width = 70;
            this.dgvData.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvData.Columns[8].Name = "Paid";
            this.dgvData.Columns[8].Width = 100;
            this.dgvData.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvData.Columns[8].Name = "Tip";
            //this.dgvData.Columns[8].Width = 70;
            //this.dgvData.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[9].Name = "Void";
            this.dgvData.Columns[9].Width = 70;
            this.dgvData.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvData.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold ,GraphicsUnit.Pixel);

            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvData.AllowUserToResizeRows = false;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvData.RowTemplate.MinimumHeight = 30;
        }
        private void dgvItems_Initialize()
        {
            this.dgvItems.AutoSize = false;
            dgvItems.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvItems.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvItems.ColumnCount = 10;
            this.dgvItems.Columns[0].Name = "Seq";
            this.dgvItems.Columns[0].Width = 50;
            this.dgvItems.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvItems.Columns[1].Name = "Type";
            this.dgvItems.Columns[1].Width = 100;
            this.dgvItems.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvItems.Columns[2].Name = "Product";
            this.dgvItems.Columns[2].Width = 150;
            this.dgvItems.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvItems.Columns[3].Name = "Unit Price";
            this.dgvItems.Columns[3].Width = 70;
            this.dgvItems.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvItems.Columns[4].Name = "QTY";
            this.dgvItems.Columns[4].Width = 70;
            this.dgvItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvItems.Columns[5].Name = m_strTax1Name; // "GST";"Tax1";
            this.dgvItems.Columns[5].Width = 70;
            this.dgvItems.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvItems.Columns[6].Name = m_strTax2Name; // "GST";"Tax2";
            this.dgvItems.Columns[6].Width = 70;
            this.dgvItems.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvItems.Columns[7].Name = m_strTax3Name; // "GST";"Tax3";
            this.dgvItems.Columns[7].Width = 70;
            this.dgvItems.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvItems.Columns[8].Name = "Amount";
            this.dgvItems.Columns[8].Width = 70;
            this.dgvItems.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvItems.Columns[9].Name = "Void";
            this.dgvItems.Columns[9].Width = 60;
            this.dgvItems.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "RefundChk";
            dgvCmb.HeaderText = "Refund?";
            this.dgvItems.Columns.Add(dgvCmb);
            this.dgvItems.Columns[this.dgvItems.ColumnCount - 1].Width = 80;
            // Add a numeric column
            //this.dgvItems.Columns.Add();
            DataGridViewTextBoxColumn dgvRefundQty = new DataGridViewTextBoxColumn();
            dgvRefundQty.HeaderText = "Refund Qty";
            dgvRefundQty.Name = "RefundQty";
            this.dgvItems.Columns.Add(dgvRefundQty);
            this.dgvItems.Columns[this.dgvItems.ColumnCount - 1].Width = 80;
            this.dgvItems.Columns[this.dgvItems.ColumnCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvItems.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);

            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvItems.AllowUserToResizeRows = false;
            dgvItems.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvItems.RowTemplate.MinimumHeight = 30;
            dgvItems.MultiSelect = false;
        }
        private void bt_ReprintReceipt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(strSelInvNo)) return;

            if (strSelInvNo.Length > 0)
            {
                iSelInvNo = System.Convert.ToInt32(strSelInvNo);
                if (iSelInvNo > 0)
                {
                    Print_Receipt(false, true);
                }
                else
                {

                }
            }

        }
        private void Print_Receipt(bool IsInvoice, bool IsCustomerCopy)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            DataAccessCard dbCard = new DataAccessCard();

            string strHeader = "header";
            string strFooter = "footer";
            string strContent = "1234567890123456789012345678901234567890";
            string strLine = "----------------------------------------";
            string strImageFile = "";
            float iSubTot = 0;
            float iTaxTot = 0;
            float iTotDue = 0;

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
            Font fntHeader = new Font("Courier New", 9);
            Font fntFooter = new Font("Courier New", 10, FontStyle.Bold);
            Font fntContents = new Font("Courier New", 8);
            Font fntTotals = new Font("Courier New", 8, FontStyle.Bold);
            Font fntCard = new Font("Consolas", 8);
            SolidBrush brsBlack = new SolidBrush(Color.Black);

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                int iNextLineYPoint = 0;
                int iLogoHeight = 80;
                int itxtHeight = 12;
                int iheaderHeight = 14;
                int ititleHeight = 17;
                //////////////////////////////////////////////////////////////////////////
                // Print Logo ------------------------------------------------------
                strImageFile = dbPOS.Get_SysConfig_By_Name("IS_RECEIPT_LOGO_PRINT")[0].ConfigValue.Trim();
                if (strImageFile.Contains("TRUE"))
                {
                    strImageFile = dbPOS.Get_SysConfig_By_Name("RECEIPT_LOGO_IMAGE")[0].ConfigValue.Trim();
                    if (strImageFile.Length > 0)
                    {
                        Image logoImg = Image.FromFile(strImageFile);
                        Rectangle logoRect = new Rectangle(new Point(0, 0), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iLogoHeight));
                        //e1.Graphics.DrawRectangle(Pens.Black, logoRect);
                        e1.Graphics.DrawImage(logoImg, logoRect, new Rectangle(0, 0, logoImg.Width, logoImg.Height), GraphicsUnit.Pixel);
                    }
                    iNextLineYPoint = iNextLineYPoint + iLogoHeight;
                }
                //////////////////////////////////////////////////////////////////////////
                // Print Header ------------------------------------------------------
                Rectangle txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                //e1.Graphics.DrawRectangle(Pens.Black, txtRect);
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_TITLE")[0].ConfigValue, fntTitle, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + ititleHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_ADDR1")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_ADDR2")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_PHONE_NO")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_REG_NO")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                //////////////////////////////////////////////////////////////////////////
                // Print order header ------------------------------------------------------
                strContent = String.Format("{0,-17}", "Inv#: " + String.Format("{0}", System.Convert.ToInt32(iSelInvNo))) +
                                String.Format("{0,20}", "Served by: " + p_strUserName);
                iNextLineYPoint = iNextLineYPoint + iheaderHeight + 5;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                strContent = String.Format("{0,-17}", "Station:" + p_strStation) +
                                String.Format("{0,20}", "# of Customer:" + iPpleCount.ToString());
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                strContent = String.Format("{0,-17}", "Issued:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                if (IsCustomerCopy)
                {
                    //////////////////////////////////////////////////////////////////////////
                    // Print a Line ------------------------------------------------------
                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);

                    //////////////////////////////////////////////////////////////////////////
                    // Print order header ------------------------------------------------------
                    strContent = String.Format("{0,-20}", StringCentering("Item Desc", 20)) + String.Format("{0,5}", "QTY") +
                                    String.Format("{0,7}", "Price") + String.Format("{0,8}", "Amount");
                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                    //////////////////////////////////////////////////////////////////////////
                    // Print a Line ------------------------------------------------------
                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);

                    if (IsInvoice)
                    {
                        List<POS_OrdersModel> orderitems = new List<POS_OrdersModel>();
                        orderitems = dbPOS.Get_Orders_by_InvoiceNo(iSelInvNo);
                        if (orderitems.Count > 0)
                        {
                            ////////////////////////////////////////////////
                            // Add the ordered item into datagrid view
                            ////////////////////////////////////////////////
                            //iNewInvNo = orders[0].InvoiceNo;
                            foreach (var order in orderitems)
                            {
                                float iAmount = 0;
                                string strProd = "";

                                if (order.OrderCategoryId == 0)
                                {
                                    iAmount = order.Quantity * order.OutUnitPrice;
                                    iSubTot = iSubTot + iAmount;
                                    iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                                    strProd = order.ProductName;

                                    if (order.ProductName.Length > 20)
                                    {
                                        strProd = order.ProductName.Substring(0, 20);
                                    }

                                    strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                    String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));
                                }
                                else if (order.OrderCategoryId > 0) // Discount, Deposit
                                {
                                    iAmount = order.Amount;
                                    iSubTot = iSubTot + iAmount;
                                    iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                                    strProd = order.ProductName;

                                    if (order.ProductName.Length > 20)
                                    {
                                        strProd = order.ProductName.Substring(0, 20);
                                    }

                                    strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                    String.Format("{0,7}", order.Amount.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                                }
                                //////////////////////////////////////////////////////////////////////////
                                // Print order ------------------------------------------------------
                                iNextLineYPoint = iNextLineYPoint + itxtHeight;
                                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                //e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            }
                            iTotDue = iSubTot + iTaxTot;
                        }
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strContent = String.Format("{0,25}", "Sub Total :") + String.Format("{0,15}", iSubTot.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strContent = String.Format("{0,25}", "Tax :") + String.Format("{0,15}", iTaxTot.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strContent = String.Format("{0,25}", "Total Due :") + String.Format("{0,15}", iTotDue.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                        if (iPpleCount > 1)
                        {
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            float iPplDue = iTotDue / iPpleCount;
                            strContent = String.Format("{0,25}", "1/" + iPpleCount.ToString() + " Each :") + String.Format("{0,15}", iPplDue.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);

                        }
                        if (dbPOS.Get_SysConfig_By_Name("INVOICE_TIP_GUIDE")[0].ConfigValue == "True")
                        {
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            float iTip = iTotDue * (float)0.10;
                            strContent = String.Format("{0,25}", "10% Tip :") + String.Format("{0,15}", iTip.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            iTip = iTotDue * (float)0.15;
                            strContent = String.Format("{0,25}", "15% Tip :") + String.Format("{0,15}", iTip.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            iTip = iTotDue * (float)0.2;
                            strContent = String.Format("{0,25}", "20% Tip :") + String.Format("{0,15}", iTip.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        }
                    }
                    else
                    {
                        List<POS1_OrderCompleteModel> orderitems = new List<POS1_OrderCompleteModel>();
                        orderitems = dbPOS1.Get_OrderComplete_by_InvoiceNo(iSelInvNo);
                        if (orderitems.Count > 0)
                        {
                            ////////////////////////////////////////////////
                            // Add the ordered item into datagrid view
                            ////////////////////////////////////////////////
                            //iNewInvNo = orders[0].InvoiceNo;
                            foreach (var order in orderitems)
                            {
                                float iAmount = 0;
                                string strProd = "";
                                if (order.ProductName.Length > 20)
                                {
                                    strProd = order.ProductName.Substring(0, 20);
                                }
                                if (order.OrderCategoryId == 0)
                                {
                                    iAmount = order.Quantity * order.OutUnitPrice;
                                    iSubTot = iSubTot + iAmount;
                                    iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                                    strProd = order.ProductName;
                                    if (strProd.Length < 21)
                                    {
                                        strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                        String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                                    }
                                    else
                                    {
                                        strContent = String.Format("{0,-20}", strProd.Substring(0, 20)) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                        String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                                    }
                                }
                                else if (order.OrderCategoryId > 0) // Discount
                                {
                                    iAmount = order.Amount;
                                    iSubTot = iSubTot + iAmount;
                                    iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                                    strProd = order.ProductName;
                                    if (strProd.Length < 21)
                                    {
                                        strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                        String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                                    }
                                    else
                                    {

                                        strContent = String.Format("{0,-20}", strProd.Substring(0, 20)) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                    String.Format("{0,7}", order.Amount.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));
                                    }
                                }
                                //////////////////////////////////////////////////////////////////////////
                                // Print order ------------------------------------------------------
                                iNextLineYPoint = iNextLineYPoint + itxtHeight;
                                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                //e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                                if (strProd.Length > 20)
                                {
                                    strContent = String.Format("{0,-20}", "-" + strProd.Substring(20));

                                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    //e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                }
                            }

                            iTotDue = iSubTot + iTaxTot;
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            strContent = String.Format("{0,25}", "Sub Total :") + String.Format("{0,15}", iSubTot.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            strContent = String.Format("{0,25}", "Tax :") + String.Format("{0,15}", iTaxTot.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                            List<POS1_TranCollectionModel> cols = new List<POS1_TranCollectionModel>();
                            cols = dbPOS1.Get_TranCollection_by_InvoiceNo(iSelInvNo);

                            float fTenderAmt = 0, fTotalTips = 0, fTotalPaid = 0, fTotalChange = 0;

                            if (cols.Count > 0)
                            {
                                foreach (var col in cols)
                                {
                                    col.CollectionType = col.CollectionType.ToUpper();
                                    if (col.CollectionType.Contains("CASH"))
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Cash Paid :") + String.Format("{0,15}", (col.Cash - col.Change).ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.CashTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Cash) :") + String.Format("{0,15}", col.CashTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }

                                    }
                                    else if (col.CollectionType.Contains("DEBIT"))
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Debit Paid :") + String.Format("{0,15}", col.Debit.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.DebitTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Debit) :") + String.Format("{0,15}", col.DebitTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }
                                    }
                                    else if (col.CollectionType.Contains("VISA"))
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Visa/Credit Paid :") + String.Format("{0,15}", col.Visa.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.VisaTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Visa/Credit) :") + String.Format("{0,15}", col.VisaTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }

                                    }
                                    else if (col.CollectionType.Contains("MASTER"))
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Master Paid :") + String.Format("{0,15}", col.Master.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.MasterTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Master) :") + String.Format("{0,15}", col.MasterTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }
                                    }
                                    else if (col.CollectionType.Contains("AMEX"))
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Amex Paid :") + String.Format("{0,15}", col.Amex.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.AmexTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Amex) :") + String.Format("{0,15}", col.AmexTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }
                                    }
                                    else
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", col.CollectionType + " Paid :") + String.Format("{0,15}", col.Amex.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.AmexTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip :") + String.Format("{0,15}", col.AmexTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }
                                    }

                                    fTenderAmt = fTenderAmt + col.Cash + col.Debit + col.Visa + col.Master + col.Amex + col.GiftCard;
                                    fTotalPaid = fTotalPaid + col.TotalPaid;
                                    fTotalChange = fTotalChange + col.Change;
                                    fTotalTips = fTotalTips + col.TotalTip;
                                }
                                iTotDue = iTotDue - fTenderAmt;
                                if (fTotalChange != 0)
                                {
                                    //////////////////////////////////////////////////////////////////////////
                                    // Print a Line ------------------------------------------------------
                                    strContent = String.Format("{0,25}", "Total Changes :") + String.Format("{0,15}", fTotalChange.ToString("0.00"));
                                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                }
                                //////////////////////////////////////////////////////////////////////////
                                // Print a Line ------------------------------------------------------
                                strContent = String.Format("{0,25}", "Total Paid :") + String.Format("{0,15}", fTotalPaid.ToString("0.00"));
                                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            }

                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            strContent = String.Format("{0,25}", "Total Due :") + String.Format("{0,15}", iTotDue.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        }
                    }
                }

                //////////////////////////////////////////////////////////////////////////
                // Print a Line ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);

                List<CCardReceipt> cardReceipts = new List<CCardReceipt>();
                cardReceipts = dbCard.Get_Approved_CardReceipt_By_InvoiceNo(iSelInvNo);
                string strTemp1;
                string strTemp2;
                float fCurrency;
                if (cardReceipts.Count > 0)
                {
                    foreach (var receipt in cardReceipts)
                    {
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = "MID:" + receipt.MerchId;
                        strTemp2 = "REF#:" + String.Format("{0:D8}", System.Convert.ToInt32(receipt.ReferenceNo));
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", strTemp2);
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = "TID:" + receipt.TerminalId;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = " > PURCHASED AMOUNT";
                        fCurrency = (float)System.Convert.ToDouble(receipt.TransactionAmount) / 100;
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = " + TIP ADDED";
                        fCurrency = (float)System.Convert.ToDouble(receipt.TipAmount) / 100;
                        if (fCurrency > 0)
                        {
                            strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);

                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            strTemp1 = " = TOTAL PAID";
                            fCurrency = (float)System.Convert.ToDouble(receipt.TotalAmount) / 100;
                            strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        }
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = receipt.EMVApplicationLabel + " ACCN No : " + receipt.CustomerAccountNumber;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = String.Format("DATE: {0:D}", receipt.CreateDate);
                        strTemp2 = String.Format("TIME: {0:T}", receipt.CreateTime);
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", strTemp2);
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = "AUTH NO: " + receipt.AuthorizationNo;
                        strTemp2 = "TSI: " + receipt.EmvTsi;
                        strContent = String.Format("{0,-30}", strTemp1) + String.Format("{0,13}", strTemp2);
                        //iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 2);
                        iNextLineYPoint = iNextLineYPoint + (iheaderHeight);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = "AID: " + receipt.EmvAid;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = "TVR: " + receipt.EmvTvr;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);

                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString(receipt.HostResponseText, fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        //iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        //txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        //e1.Graphics.DrawString("SIGNATURE NOT REQUIRED", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        //iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        //txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        //e1.Graphics.DrawString("IMPORTANT", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("Pls. retain this copy for your records.", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("CARDHOLDER ACKNOWLEDGES RECEIPT OF GOODS", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("AND/OR SERVICES IN THE AMOUNT OF THE", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("TOTAL SHOWN HEREON", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                    } // for each
                } //if (cardReceipts.Count > 0)
                  // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString("THANK YOU FOR COMING", fntCard, brsBlack, (RectangleF)txtRect, format1);
            }; //if (IsInvoice)
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }
        private void Print_Receipt_old(bool IsInvoice, bool IsCustomerCopy)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            DataAccessCard dbCard = new DataAccessCard();

            string strHeader = "header";
            string strFooter = "footer";
            string strContent = "1234567890123456789012345678901234567890";
            string strLine = "----------------------------------------";
            string strImageFile = "";
            float iSubTot = 0;
            float iTaxTot = 0;
            float iTotDue = 0;

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
            Font fntHeader = new Font("Courier New", 9);
            Font fntFooter = new Font("Courier New", 10, FontStyle.Bold);
            Font fntContents = new Font("Courier New", 8);
            Font fntTotals = new Font("Courier New", 8, FontStyle.Bold);
            Font fntCard = new Font("Consolas", 8);
            SolidBrush brsBlack = new SolidBrush(Color.Black);

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                int iNextLineYPoint = 0;
                int iLogoHeight = 80;
                int itxtHeight = 12;
                int iheaderHeight = 14;
                int ititleHeight = 17;
                //////////////////////////////////////////////////////////////////////////
                // Print Logo ------------------------------------------------------
                strImageFile = dbPOS.Get_SysConfig_By_Name("RECEIPT_LOGO_IMAGE")[0].ConfigValue;
                if (strImageFile.Length > 0)
                {
                    Image logoImg = Image.FromFile(strImageFile);
                    Rectangle logoRect = new Rectangle(new Point(0, 0), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iLogoHeight));
                    //e1.Graphics.DrawRectangle(Pens.Black, logoRect);
                    e1.Graphics.DrawImage(logoImg, logoRect, new Rectangle(0, 0, logoImg.Width, logoImg.Height), GraphicsUnit.Pixel);
                }
                //////////////////////////////////////////////////////////////////////////
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iLogoHeight;
                Rectangle txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                //e1.Graphics.DrawRectangle(Pens.Black, txtRect);
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_TITLE")[0].ConfigValue, fntTitle, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + ititleHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_ADDR1")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_ADDR2")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_PHONE_NO")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_REG_NO")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);


                if (IsCustomerCopy)
                {
                    List<POS1_OrderCompleteModel> orderitems = new List<POS1_OrderCompleteModel>();
                    orderitems = dbPOS1.Get_OrderComplete_by_InvoiceNo(iSelInvNo);
                    if (orderitems.Count > 0)
                    {
                        //////////////////////////////////////////////////////////////////////////
                        // Print order header ------------------------------------------------------
                        strContent = String.Format("{0,-17}", "Inv#: " + String.Format("{0}", System.Convert.ToInt32(iSelInvNo))) +
                                        String.Format("{0,20}", "Served by: " + orderitems[0].CreateUserName);
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight + 5;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        strContent = String.Format("{0,-17}", "Station:" + orderitems[0].CreateStation) +
                                        String.Format("{0,20}", "# of Customer:" + iPpleCount.ToString());
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        strContent = String.Format("{0,-17}", "Issued:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + itxtHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);

                        //////////////////////////////////////////////////////////////////////////
                        // Print order header ------------------------------------------------------
                        strContent = String.Format("{0,-20}", StringCentering("Item Desc", 20)) + String.Format("{0,5}", "QTY") +
                                        String.Format("{0,7}", "Price") + String.Format("{0,8}", "Amount");
                        iNextLineYPoint = iNextLineYPoint + itxtHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + itxtHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        ////////////////////////////////////////////////
                        // Add the ordered item into datagrid view
                        ////////////////////////////////////////////////
                        //iNewInvNo = orders[0].InvoiceNo;
                        foreach (var order in orderitems)
                        {
                            float iAmount = order.Quantity * order.OutUnitPrice;
                            iSubTot = iSubTot + iAmount;
                            iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                            string strProd = order.ProductName;
                            if (order.ProductName.Length > 20)
                            {
                                strProd = order.ProductName.Substring(0, 20);
                            }

                            strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                         String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                            //////////////////////////////////////////////////////////////////////////
                            // Print order ------------------------------------------------------
                            iNextLineYPoint = iNextLineYPoint + itxtHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            //e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        }

                        iTotDue = iSubTot + iTaxTot;
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strContent = String.Format("{0,25}", "Sub Total :") + String.Format("{0,15}", iSubTot.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strContent = String.Format("{0,25}", "Tax :") + String.Format("{0,15}", iTaxTot.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                        List<POS1_TranCollectionModel> cols = new List<POS1_TranCollectionModel>();
                        cols = dbPOS1.Get_TranCollection_by_InvoiceNo(iSelInvNo);

                        float fTenderAmt = 0, fTotalTips = 0, fTotalPaid = 0, fTotalChange = 0;

                        if (cols.Count > 0)
                        {
                            foreach (var col in cols)
                            {
                                if (col.CollectionType == "Cash")
                                {
                                    //////////////////////////////////////////////////////////////////////////
                                    // Print a Line ------------------------------------------------------
                                    strContent = String.Format("{0,25}", "Cash Paid :") + String.Format("{0,15}", col.Cash.ToString("0.00"));
                                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                    if (col.CashTip > 0)
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Tip(Cash) :") + String.Format("{0,15}", col.CashTip.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                    }

                                }
                                if (col.CollectionType == "Debit")
                                {
                                    //////////////////////////////////////////////////////////////////////////
                                    // Print a Line ------------------------------------------------------
                                    strContent = String.Format("{0,25}", "Debit Paid :") + String.Format("{0,15}", col.Debit.ToString("0.00"));
                                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                    if (col.DebitTip > 0)
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Tip(Debit) :") + String.Format("{0,15}", col.DebitTip.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                    }
                                }
                                if ((col.CollectionType == "Visa") | (col.CollectionType == "DinersClub") | (col.CollectionType == "DiscoverCard")
                                    | (col.CollectionType == "JCB") | (col.CollectionType == "UnionPayCard") | (col.CollectionType == "OtherCreditCard"))
                                {
                                    //////////////////////////////////////////////////////////////////////////
                                    // Print a Line ------------------------------------------------------
                                    strContent = String.Format("{0,25}", "Visa/Credit Paid :") + String.Format("{0,15}", col.Visa.ToString("0.00"));
                                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                    if (col.VisaTip > 0)
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Tip(Visa/Credit) :") + String.Format("{0,15}", col.VisaTip.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                    }

                                }
                                if (col.CollectionType == "MasterCard")
                                {
                                    //////////////////////////////////////////////////////////////////////////
                                    // Print a Line ------------------------------------------------------
                                    strContent = String.Format("{0,25}", "Master Paid :") + String.Format("{0,15}", col.Master.ToString("0.00"));
                                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                    if (col.MasterTip > 0)
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Tip(Master) :") + String.Format("{0,15}", col.MasterTip.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                    }
                                }
                                if (col.CollectionType == "Amex")
                                {
                                    //////////////////////////////////////////////////////////////////////////
                                    // Print a Line ------------------------------------------------------
                                    strContent = String.Format("{0,25}", "Amex Paid :") + String.Format("{0,15}", col.Amex.ToString("0.00"));
                                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                    if (col.AmexTip > 0)
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Tip(Amex) :") + String.Format("{0,15}", col.AmexTip.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                    }
                                }

                                fTenderAmt = fTenderAmt + col.Cash + col.Debit + col.Visa + col.Master + col.Amex + col.GiftCard;
                                fTotalPaid = fTotalPaid + col.TotalPaid + col.Change;
                                fTotalChange = fTotalChange + col.Change;
                                fTotalTips = fTotalTips + col.TotalTip;
                            }
                            iTotDue = iTotDue - fTenderAmt - fTotalChange;
                            if (fTotalChange != 0)
                            {
                                //////////////////////////////////////////////////////////////////////////
                                // Print a Line ------------------------------------------------------
                                strContent = String.Format("{0,25}", "Total Changes :") + String.Format("{0,15}", fTotalChange.ToString("0.00"));
                                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            }
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            strContent = String.Format("{0,25}", "Total Paid :") + String.Format("{0,15}", fTotalPaid.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        }

                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strContent = String.Format("{0,25}", "Total Due :") + String.Format("{0,15}", iTotDue.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                    }
                }

                //////////////////////////////////////////////////////////////////////////
                // Print a Line ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);

                List<CCardReceipt> cardReceipts = new List<CCardReceipt>();
                cardReceipts = dbCard.Get_Approved_CardReceipt_By_InvoiceNo(iSelInvNo);
                string strTemp1;
                string strTemp2;
                float fCurrency;
                if (cardReceipts.Count > 0)
                {
                    foreach (var receipt in cardReceipts)
                    {
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = "MID:" + receipt.MerchId;
                        strTemp2 = "REF#:" + String.Format("{0:D8}", System.Convert.ToInt32(receipt.ReferenceNo));
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", strTemp2);
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = "TID:" + receipt.TerminalId;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = " > PURCHASED AMOUNT";
                        fCurrency = (float)System.Convert.ToDouble(receipt.TransactionAmount) / 100;
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 2);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = " + TIP ADDED";
                        fCurrency = (float)System.Convert.ToDouble(receipt.TipAmount) / 100;
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = " = TOTAL PAID";
                        fCurrency = (float)System.Convert.ToDouble(receipt.TotalAmount) / 100;
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = receipt.EMVApplicationLabel + " ACCN No : " + receipt.CustomerAccountNumber;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 2);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = String.Format("DATE: {0:D}", receipt.CreateDate);
                        strTemp2 = String.Format("TIME: {0:T}", receipt.CreateTime);
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", strTemp2);
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = "AUTH NO: " + receipt.AuthorizationNo;
                        strTemp2 = "TSI: " + receipt.EmvTsi;
                        strContent = String.Format("{0,-30}", strTemp1) + String.Format("{0,13}", strTemp2);
                        //iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 2);
                        iNextLineYPoint = iNextLineYPoint + (iheaderHeight);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = "AID: " + receipt.EmvAid;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = "TVR: " + receipt.EmvTvr;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);

                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString(receipt.HostResponseText, fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("SIGNATURE NOT REQUIRED", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("IMPORTANT", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("Pls. retain this copy for your records.", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("CARDHOLDER ACKNOWLEDGES RECEIPT OF GOODS", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("AND/OR SERVICES IN THE AMOUNT OF THE", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("TOTAL SHOWN HEREON", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                    } // for each
                } //if (cardReceipts.Count > 0)
                  // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString("THANK YOU FOR COMING", fntCard, brsBlack, (RectangleF)txtRect, format1);
            }; //if (IsInvoice)
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }

        private void dgvData_MouseClick(object sender, MouseEventArgs e)
        {
            int selectedRowIndex = dgvData.CurrentCell.RowIndex;
            Int32 selectedRowCount = dgvData.Rows.GetRowCount(DataGridViewElementStates.Selected);
            // Get the selected row index


            if (selectedRowCount == 1)
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

                if (dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[1].Value == null)
                {
                    strSelInvNo = String.Empty;
                }
                else
                {
                    strSelInvNo = dgvData.Rows[dgvData.SelectedRows[0].Index].Cells[1].Value.ToString();
                }

                DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
                if (dbPOS1.IsVoidCollection(Convert.ToInt32(strSelInvNo)) == true)
                {
                    bt_SetVoid.Text = "Cancel Void";
                    bt_SetVoid.BackColor = Color.GreenYellow;
                }
                else
                {
                    bt_SetVoid.Text = "Manual Void";
                    bt_SetVoid.BackColor = Color.LightSalmon;
                }
                ShowOrderItems(Convert.ToInt32(strSelInvNo));
            }
            RefreshCardProcessButtons(selectedRowCount, selectedRowIndex);

        }

        private void ShowOrderItems(int p_intInvNo)
        {
            int iItemCount = 0;
            string strPTypeName = String.Empty;
            dgvItems.Rows.Clear();
            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            List<POS1_OrderCompleteModel> orderitems = new List<POS1_OrderCompleteModel>();
            orderitems = dbPOS1.Get_OrderComplete_by_InvoiceNo(p_intInvNo);
            if (orderitems.Count > 0)
            {
                foreach (var order in orderitems)
                {
                    iItemCount++;
                    // Get Product Type Name
                    strPTypeName = dbPOS.Get_ProductTypeName_By_Id(order.ProductTypeId);
                    dgvItems.Rows.Add(iItemCount.ToString(), strPTypeName, order.ProductName, order.OutUnitPrice.ToString(), order.Quantity,
                                        order.Tax1, order.Tax2, order.Tax3, order.Amount + order.Tax1 + order.Tax2 + order.Tax3, order.IsVoid);
                    // Set row tag
                    dgvItems.Rows[iItemCount - 1].Tag = order.Id.ToString();
                }
            }
        }

        private void RefreshCardProcessButtons(int selectedRowCount, int p_selectedRowIndex)
        {
            int iselectedCollectionId = 0;
            float fRefundableAmt = 0;
            if (selectedRowCount == 0) return;
            if (p_selectedRowIndex >= 0)
            {
                if (dgvData.Rows[p_selectedRowIndex].Tag != null)
                    iselectedCollectionId = Convert.ToInt32(dgvData.Rows[p_selectedRowIndex].Tag);
            }
            if ((selectedRowCount == 1) && (strSelInvNo.Length > 0))
            {
                DataAccessCard dbCard = new DataAccessCard();
                DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
                List<CCardReceipt> cardReceipts = new List<CCardReceipt>();
                cardReceipts = dbCard.Get_Approved_CardReceipt_By_InvoiceNo(Convert.ToInt32(strSelInvNo));
                trancolSelected = dbPOS1.Get_One_TranCollection_by_Id(iselectedCollectionId);
                trancolsRelated = dbPOS1.Get_TranCollection_by_InvoiceNo(Convert.ToInt32(strSelInvNo));
                fRefundableAmt = GetRefundableAmount(0);
                // remove one of trancolsRelated that is same as trancolSelected
                if (trancolsRelated.Count > 0)
                {
                    for (int i = 0; i < trancolsRelated.Count; i++)
                    {
                        if (trancolsRelated[i].Id == iselectedCollectionId)
                        {
                            trancolsRelated.RemoveAt(i);
                            break;
                        }
                    }
                }

                if ((cardReceipts.Count > 0) && (p_blnPaymentree))
                {
                    bt_CardRefund.Enabled = true;
                    bt_CardVoid.Enabled = true;
                }
                else
                {
                    bt_CardRefund.Enabled = false;
                    bt_CardVoid.Enabled = false;
                }
                // Total Paid is less than zero, then disable the Refund button
                if ((trancolSelected.TotalPaid < 0) && (p_blnPaymentree))
                {
                    bt_CardRefund.Enabled = false;
                    bt_CardVoid.Enabled = false;
                    bt_SetVoid.Enabled = false;
                }
            }
            else
            {
                bt_CardRefund.Enabled = false;
                bt_CardVoid.Enabled = false;
            }
        }

        public string StringCentering(string s, int desiredLength)
        {
            if (s.Length >= desiredLength) return s;
            int firstpad = (s.Length + desiredLength) / 2;
            return s.PadLeft(firstpad).PadRight(desiredLength);
        }

        private void bt_SetVoid_Click(object sender, EventArgs e)
        {
            // get all selected rows on the dgvData
            //Feature #3265
            if (dgvData.SelectedRows.Count > 0)
            {
                if (dgvData.SelectedRows[0].Cells[1].Value == null)
                {
                    strSelInvNo = String.Empty;
                    return;
                }
                else
                {
                    using (var FrmYesNo = new frmYesNo(this.FrmSalesMain))
                    {
                        FrmYesNo.Set_Title("Void");

                        FrmYesNo.Set_Message("Set/Unset All selected Invoice ?");
                        //FrmYesNo.Set_Message("Set/Unset All selected Invoice ?" + strSelInvNo);
                        FrmYesNo.StartPosition = FormStartPosition.Manual; // FormStartPosition.CenterScreen; //
                        FrmYesNo.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                                  (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                        FrmYesNo.ShowDialog();

                        if (FrmYesNo.bYesNo)
                        {
                            foreach (DataGridViewRow row in dgvData.SelectedRows)
                            {
                                if (row.Cells[1].Value == null)
                                {
                                    strSelInvNo = String.Empty;
                                }
                                else
                                {
                                    strSelInvNo = row.Cells[1].Value.ToString();
                                    if (strSelInvNo.Length > 0)
                                    {
                                        iSelInvNo = System.Convert.ToInt32(strSelInvNo);
                                        if (iSelInvNo > 0)
                                        {
                                            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
                                            if (dbPOS1.IsVoidCollection(iSelInvNo))
                                            {
                                                dbPOS1.UnSet_Void_Transaction_by_InvoiceNo(iSelInvNo);
                                            }
                                            else
                                            {
                                                dbPOS1.Set_Void_Transaction_by_InvoiceNo(iSelInvNo);
                                            }
                                        }
                                    }

                                }
                            }
                            bt_Query.PerformClick();
                        }

                    } // using
                } //if
            } // if
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmSalesHistory_Load(object sender, EventArgs e)
        {
            LoadImageList();
            LoadTenderComboBox();
            EnableDisableControls();
            RefreshCardProcessButtons(0, 0);
        }

        private void LoadImageList()
        {
            m_imageList = new ImageList();
            m_imageList.ImageSize = new Size(40, 40);
            m_imageList.ColorDepth = ColorDepth.Depth32Bit;
            m_imageList.Images.Add(Properties.Resources.Card_Void);
            m_imageList.Images.Add(Properties.Resources.Card_Refund);
            m_imageList.Images.Add(Properties.Resources.download_40dp);
            m_imageList.Images.Add(Properties.Resources.search_40dp);
            m_imageList.Images.Add(Properties.Resources.void_block_40dp);
            m_imageList.Images.Add(Properties.Resources.receipt_40dp);
            m_imageList.Images.Add(Properties.Resources.logout_40dp);

            bt_CardVoid.ImageList = m_imageList;
            bt_CardRefund.ImageList = m_imageList;
            bt_CardVoid.ImageIndex = 0;
            bt_CardRefund.ImageIndex = 1;
            bt_CardVoid.ImageAlign = ContentAlignment.MiddleLeft;
            bt_CardRefund.ImageAlign = ContentAlignment.MiddleLeft;
            bt_CardVoid.TextAlign = ContentAlignment.MiddleRight;
            bt_CardRefund.TextAlign = ContentAlignment.MiddleRight;

            bt_ExcelExport.ImageList = m_imageList;
            bt_ExcelExport.ImageIndex = 2;
            bt_ExcelExport.ImageAlign = ContentAlignment.MiddleLeft;
            bt_ExcelExport.TextAlign = ContentAlignment.MiddleRight;

            bt_Query.ImageList = m_imageList;
            bt_Query.ImageIndex = 3;
            bt_Query.ImageAlign = ContentAlignment.MiddleLeft;
            bt_Query.TextAlign = ContentAlignment.MiddleRight;

            bt_SetVoid.ImageList = m_imageList;
            bt_SetVoid.ImageIndex = 4;
            bt_SetVoid.ImageAlign = ContentAlignment.MiddleLeft;
            bt_SetVoid.TextAlign = ContentAlignment.MiddleRight;

            bt_ReprintReceipt.ImageList = m_imageList;
            bt_ReprintReceipt.ImageIndex = 5;
            bt_ReprintReceipt.ImageAlign = ContentAlignment.MiddleLeft;
            bt_ReprintReceipt.TextAlign = ContentAlignment.MiddleRight;

            bt_Exit.ImageList = m_imageList;
            bt_Exit.ImageIndex = 6;
            bt_Exit.ImageAlign = ContentAlignment.MiddleLeft;
            bt_Exit.TextAlign = ContentAlignment.MiddleCenter;

        }

        private void EnableDisableControls()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            loginUsers = dbPOS.Get_LoginUser_By_ID(p_intLoginUserId);
            if (loginUsers.Count > 0)
            {
                if ((loginUsers[0].Grade == "1") || (loginUsers[0].Grade == "0"))
                {
                    dttm_TranStart.Enabled = true;
                    dttm_TranEnd.Enabled = true;
                }
                else
                {
                    dttm_TranStart.Enabled = false;
                    dttm_TranEnd.Enabled = false;
                }
            }

            m_bExcludeTip = dbPOS.Get_SysConfig_By_Name("IS_FULLREFUND_EXCLUDE_TIP")[0].ConfigValue.Trim() == "TRUE" ? true : false;

        }
        //Feature #3264
        private void LoadTenderComboBox()
        {
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            strTenderTypes = dbPOS1.Get_TenderList_FromCollection();
            // Add All string to the string array.
            strTenderTypes = strTenderTypes.Prepend("All").ToArray();
            if (strTenderTypes.Length > 0)
            {
                cb_Tender.DataSource = strTenderTypes;
            }
            DataAccessPOS dbPOS = new DataAccessPOS();
            m_strTax1Name = dbPOS.Get_SysConfig_By_Name("TAX1")[0].ConfigValue;
            m_strTax2Name = dbPOS.Get_SysConfig_By_Name("TAX2")[0].ConfigValue;
            m_strTax3Name = dbPOS.Get_SysConfig_By_Name("TAX3")[0].ConfigValue;
        }

        private void bt_ExcelExport_Click(object sender, EventArgs e)
        {
            //Feature #3264
            Create_Excel_Sales_Report();
        }
        private void Create_Excel_Sales_Report()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Sales_History_" + DateTime.Now.ToString("yyyyMMddHHMMss") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                //show progressbar
                progBarExport.Visible = true;
                progBarExport.Value = 0;
                // set backcolor of progressbar
                progBarExport.BackColor = Color.LightGreen;
                progBarExport.Style = ProgressBarStyle.Continuous;
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
                // Set backcolor of the Header row
                worksheet.Rows[1].Interior.Color = Color.LightGray;
                // storing Each row and column value to excel sheet  
                //set progBarExport maximum value
                progBarExport.Maximum = dgvData.Rows.Count - 1;
                for (int i = 0; i < dgvData.Rows.Count - 1; i++)
                {
                    progBarExport.Value = i;
                    progBarExport.Refresh();

                    for (int j = 0; j < dgvData.Columns.Count; j++)
                    {
                        // cells format to text
                        worksheet.Cells[i + 2, j + 1].NumberFormat = "@";
                        worksheet.Cells[i + 2, j + 1] = dgvData.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // insert Title row on top of the sheet
                worksheet.Rows[1].Insert();
                worksheet.Cells[1, 1] = "Date/Time Exported : " + DateTime.Now.ToString("G");
                worksheet.Rows[1].Insert();
                worksheet.Cells[1, 1] = "Sales History (" + dttm_TranStart.Value.ToString("D") + " ~ " + dttm_TranEnd.Value.ToString("D") + ") : " + cb_Tender.Text;
                // set bold font for the title
                worksheet.Cells[1, 1].Font.Bold = true;
                // save the application  
                workbook.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
                app.Visible = false;
                app.Quit();

                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(app);

                progBarExport.Visible = false;
                Cursor.Current = Cursors.Default;
                // Open the newly saved excel file
                if (System.IO.File.Exists(sfd.FileName))
                {
                    // copy the file to the temp folder
                    string strTempPath = Path.GetTempPath();
                    string strTempFile = strTempPath + Path.GetFileName(sfd.FileName);
                    System.IO.File.Copy(sfd.FileName, strTempFile, true);

                    DataAccessPOS dbPOS = new DataAccessPOS();
                    string strConfig = dbPOS.Get_SysConfig_By_Name("CON_SEND_EMAIL_REPORT")[0].ConfigValue.Trim();
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
                             " <h4 style='color: #000000;'> Sales History Excel Export action has been taken at YOUR POS today..<br /> " + System.Environment.NewLine +
                             " <span style='color: #FF0000;'> <strong>Please find attached excel file for your reference.</strong> </span>" + System.Environment.NewLine +
                             " <br /> Date : " + dttm_TranStart.Value.ToString("yyyy-MM-dd") + " to " + dttm_TranEnd.Value.ToString("yyyy-MM-dd") + System.Environment.NewLine +
                             " <br /> " + System.Environment.NewLine +
                             " <br /><i> This email was automatically generated and sent from YOUR POS.. </i>" + System.Environment.NewLine +
                             " <br />Best Regards," + System.Environment.NewLine +
                             " </h4>" + System.Environment.NewLine +
                             " <h3 ><strong><span style='color: #0000ff;'>TechServe POS</span></strong><span style='color: #566573;'> &copy; 2023 <a href='https://techservepos.com'>techservepos.com</a></span></h3>" + System.Environment.NewLine +
                             "</body>" + System.Environment.NewLine +
                             "</html>" + System.Environment.NewLine;
                        util.SendEmail("Sales History Excel Export", strHTMLBody, strTempFile);
                    }

                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }

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

        private void bt_CardVoid_Click(object sender, EventArgs e)
        {

        }

        private void bt_CardRefund_Click(object sender, EventArgs e)
        {
            float fCash = 0;
            float fDebit = 0;
            float fVisa = 0;
            float fMaster = 0;
            float fAmex = 0;
            float fOthers = 0;
            float fTip = 0;

            bool bCardRefund = false;
            bool bFullRefund = false;
            bool bPartialRefundExists = false;
            string strMsg = "";
            m_fRefundAmt = CalculateRefundAmount();
            bPartialRefundExists = CheckAnyPartialRefundExist();

            if ( (m_fRefundAmt == 0) && (bPartialRefundExists == false))
            {
                using (var FrmYesNo = new frmYesNo(FrmSalesMain))
                {
                    FrmYesNo.Set_Title("Refund");

                    fTip = CheckExcludeTipOnFullRefund();
                    m_fRefundAmt = GetRefundableAmount(fTip);//trancolSelected.TotalPaid - fTip;
                    strMsg = "Full Refund ? " + m_fRefundAmt.ToString("C2");
                    if (fTip > 0)
                    { 
                        strMsg += System.Environment.NewLine + "Tip Exluded : " + fTip.ToString("C2");
                    }
                    FrmYesNo.Set_Message(strMsg);
                    //FrmYesNo.Set_Message("Set/Unset All selected Invoice ?" + strSelInvNo);
                    FrmYesNo.StartPosition = FormStartPosition.Manual; // FormStartPosition.CenterScreen; //
                    FrmYesNo.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                              (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                    FrmYesNo.ShowDialog();

                    if (FrmYesNo.bYesNo)
                    {
                        bFullRefund = true;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            using (var FrmEnterAmount = new frmEnterAmount(this.FrmSalesMain))
            {
                this.TopMost = false;
                FrmEnterAmount.p_Title = "Please confirm Refund Amount !";
                FrmEnterAmount.StartPosition = FormStartPosition.CenterScreen;
                //if (trancolSelected != null)
                if (m_fRefundAmt > 0)
                {
                    FrmEnterAmount.p_TenderAmt = m_fRefundAmt; // trancolSelected.TotalPaid;
                }
                else
                {
                    return;
                }
                FrmEnterAmount.TopLevel = true;
                FrmEnterAmount.ShowDialog();

                this.TopMost = true;
                bCardRefund = FrmEnterAmount.p_IsRefund;
                m_fRefundAmt = FrmEnterAmount.p_RefundAmt;
            }
            if (bCardRefund && m_fRefundAmt > 0)
            {
                // Call frmCardPayment form
                using (var FrmCardPay = new frmCardPayment(this.FrmSalesMain))
                {
                    FrmCardPay.Set_InvoiceNo(trancolSelected.InvoiceNo);
                    FrmCardPay.Set_TenderAmt((double)m_fRefundAmt);
                    FrmCardPay.Set_Station(p_strStation);
                    FrmCardPay.Set_UserName(p_strUserName);
                    FrmCardPay.Set_UserPassCode(p_strLoginPassword);
                    FrmCardPay.p_strTranType = "Refund";
                    FrmCardPay.p_blnPaymentree = this.FrmSalesMain.m_blnPaymentree;
                    FrmCardPay.StartPosition = FormStartPosition.CenterScreen;
                    FrmCardPay.ShowDialog();

                    if (FrmCardPay.bPaymentComplete)
                    {
                        m_fRefundAmt = (float)FrmCardPay.p_TenderAmt;
                        FrmCardPay.strPaymentType = FrmCardPay.strPaymentType.ToUpper();
                        util.Logger("Card Refund completed !" + FrmCardPay.strPaymentType);
                        // Move Orders to OrderComplete
                        //Process_Order_Complete(trancolSelected.InvoiceNo);
                        Process_OrderRefund_Complete(trancolSelected.InvoiceNo, bFullRefund);
                        //Process_Tran_Collection(iNewInvNo, FrmCardPay.p_TenderAmt, 
                        // Add collection table
                        switch (FrmCardPay.strPaymentType)
                        {
                            case "Cash":
                            case "CASH":
                                fCash = m_fRefundAmt * -1;
                                break;
                            case "Debit":
                            case "DEBIT":
                                fDebit = m_fRefundAmt * -1;
                                break;
                            case "Visa":
                            case "VISA":
                                fVisa = m_fRefundAmt * -1;
                                break;
                            case "Master":
                            case "MASTER":
                            case "M/C":
                            case "MasterCard":
                            case "MASTERCARD":
                                FrmCardPay.strPaymentType = "MASTER";
                                fMaster = m_fRefundAmt * -1;
                                break;
                            case "Amex":
                            case "AMEX":
                                fAmex = m_fRefundAmt * -1;
                                break;
                            default:
                                fOthers = m_fRefundAmt * -1;
                                util.Logger("Unknown Card Type !" + FrmCardPay.strPaymentType);
                                break;
                        }
                        if (bFullRefund)
                        {
                            if (m_bExcludeTip)
                            {
                                FrmCardPay.p_TipAmt = 0;
                            }
                            else
                            {
                                FrmCardPay.p_TipAmt = fTip; // trancolSelected.TotalTip;
                            }
                        }
                        Process_RefundTran_Collection(trancolSelected.InvoiceNo, fCash, fDebit, fVisa, fMaster, fAmex, fOthers,
                                                            0, FrmCardPay.p_TipAmt, FrmCardPay.strPaymentType, true, bFullRefund);
                        Print_Receipt(false, true, trancolSelected.InvoiceNo);
                        util.Logger("--------------- Card Refund & Printing Receipt is Done : Invoice# " + trancolSelected.InvoiceNo.ToString());
                        //txtSelectedMenu.Text = "Payment & Printing Receipt is Done : Invoice# " + iNewInvNo.ToString();

                        //Initialize_Local_Variables();
                        //dgv_Orders_Initialize();
                        //Load_Existing_Orders();
                        //bt_Stop.PerformClick();
                        //bCashPayment = false;
                    }
                    else
                    {
                        //txtSelectedMenu.Text = "######### Payment is not yet completed : Invoice# " + iNewInvNo.ToString();
                        util.Logger("Payment Refund is not done yet!");

                    }
                    // Add collection table
                }
                }
            }

        private bool CheckAnyPartialRefundExist()
        {
            bool bRefindExist = false;
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            List<POS1_TranCollectionModel> cols = new List<POS1_TranCollectionModel>();
            cols = dbPOS1.Get_TranCollection_by_InvoiceNo(trancolSelected.InvoiceNo);
            if (cols.Count > 0)
            {
                for (int i = 0; i < cols.Count; i++)
                {
                    if (cols[i].TotalPaid < 0)
                    {
                        bRefindExist = true;
                        break;
                    }
                }
            }
            return bRefindExist;
        }

        private float GetRefundableAmount(float fTip)
        {
            float fRefundAmt = 0;
            fRefundAmt += trancolSelected.TotalPaid - fTip;
            if (trancolsRelated.Count > 0)
            {
                for (int i = 0; i < trancolsRelated.Count; i++)
                {
                    fRefundAmt += trancolsRelated[i].TotalPaid;
                }
            }

            return fRefundAmt;
        }
        private float CheckExcludeTipOnFullRefund()
        {
            if (m_bExcludeTip)
            {
                return trancolSelected.TotalTip;
            }
            else
            {
                return 0;
            }

        }

        private float CalculateRefundAmount()
        {
            // Calculate Refund Amount
            float fRefundAmt = 0;
            float fOrderItemAmt = 0;
            float fOrderItemTaxAmt = 0;
            int iOrderId = 0;
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            // Calculate Refund Amount from dgvItems
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.Cells[11].Value != null)
                {
                    iOrderId = Convert.ToInt32(row.Tag);
                    POS1_OrderCompleteModel orderComp = new POS1_OrderCompleteModel();
                    orderComp = dbPOS1.Get_OrderComplete_by_Id(iOrderId);
                    if (Convert.ToInt32(row.Cells[11].Value.ToString()) > 0)
                    {
                        fOrderItemAmt = ((float)System.Convert.ToDouble(row.Cells[3].Value) * Convert.ToInt32(row.Cells[11].Value.ToString()));
                        fOrderItemTaxAmt = (orderComp.IsTax1 ? (orderComp.Tax1Rate * fOrderItemAmt) : 0) +
                                                  (orderComp.IsTax2 ? (orderComp.Tax2Rate * fOrderItemAmt) : 0) +
                                                  (orderComp.IsTax3 ? (orderComp.Tax3Rate * fOrderItemAmt) : 0);
                        fRefundAmt += (fOrderItemAmt + fOrderItemTaxAmt);
                    }
                }
            }
            fRefundAmt = (float)Math.Round((Double)fRefundAmt, 2);
            return fRefundAmt;
        }

        private void Process_OrderRefund_Complete(int p_invoiceNo, bool p_bFullRefund)
        {
            int iOrderId = 0;
            int iRefundQty = 0;
            // Set OrderComplete to Void
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            //dbPOS1.Set_Void_OrderCoplete_by_InvoiceNo(p_invoiceNo);
            if (p_bFullRefund)
            { // Full Refund
                //dbPOS1.Set_Void_OrderCoplete_by_InvoiceNo(p_invoiceNo);
                foreach (DataGridViewRow row in dgvItems.Rows)
                {

                    iOrderId = Convert.ToInt32(row.Tag);
                    if (iOrderId == 0) continue;
                    POS1_OrderCompleteModel orderComp = new POS1_OrderCompleteModel();
                    orderComp = dbPOS1.Get_OrderComplete_by_Id(iOrderId);
                    if (orderComp != null)
                    {
                        if (orderComp.Quantity > 0)
                        {
                            orderComp.Quantity = orderComp.Quantity * -1;
                            orderComp.Amount = orderComp.OutUnitPrice * orderComp.Quantity;
                            orderComp.Tax1 = (orderComp.IsTax1 ? (orderComp.Tax1Rate * orderComp.Amount) : 0);
                            orderComp.Tax2 = (orderComp.IsTax2 ? (orderComp.Tax2Rate * orderComp.Amount) : 0);
                            orderComp.Tax3 = (orderComp.IsTax3 ? (orderComp.Tax3Rate * orderComp.Amount) : 0);
                            orderComp.CreateDate = DateTime.Now.ToString("yyyy-MM-dd");
                            orderComp.CreateTime = DateTime.Now.ToString("HH:mm:ss");
                            orderComp.CreateUserId = p_intLoginUserId;
                            orderComp.CreateUserName = p_strUserName;
                            orderComp.CreateStation = p_strStation;
                            orderComp.LastModDate = DateTime.Now.ToString("yyyy-MM-dd");
                            orderComp.LastModTime = DateTime.Now.ToString("HH:mm:ss");
                            orderComp.LastModUserId = p_intLoginUserId;
                            orderComp.LastModUserName = p_strUserName;
                            orderComp.LastModStation = p_strStation;
                            orderComp.CompleteDate = DateTime.Now.ToString("yyyy-MM-dd");
                            orderComp.CompleteTime = DateTime.Now.ToString("HH:mm:ss");
                            dbPOS1.Insert_OrderComplete(orderComp);
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    // Cells[11] is Refund Quantity
                    if (row.Cells[11].Value != null)
                    {
                        iOrderId = Convert.ToInt32(row.Tag);
                        POS1_OrderCompleteModel orderComp = new POS1_OrderCompleteModel();
                        orderComp = dbPOS1.Get_OrderComplete_by_Id(iOrderId);
                        if (Convert.ToInt32(row.Cells[11].Value.ToString()) > 0)
                        {
                            iRefundQty = Convert.ToInt32(row.Cells[11].Value.ToString());
                            orderComp.Quantity = iRefundQty * -1;
                            orderComp.Amount = orderComp.OutUnitPrice * orderComp.Quantity;
                            orderComp.Tax1 = (orderComp.IsTax1 ? (orderComp.Tax1Rate * orderComp.Amount) : 0);
                            orderComp.Tax2 = (orderComp.IsTax2 ? (orderComp.Tax2Rate * orderComp.Amount) : 0);
                            orderComp.Tax3 = (orderComp.IsTax3 ? (orderComp.Tax3Rate * orderComp.Amount) : 0);
                            orderComp.CreateDate = DateTime.Now.ToString("yyyy-MM-dd");
                            orderComp.CreateTime = DateTime.Now.ToString("HH:mm:ss");
                            orderComp.CreateUserId = p_intLoginUserId;
                            orderComp.CreateUserName = p_strUserName;
                            orderComp.CreateStation = p_strStation;
                            orderComp.LastModDate = DateTime.Now.ToString("yyyy-MM-dd");
                            orderComp.LastModTime = DateTime.Now.ToString("HH:mm:ss");
                            orderComp.LastModUserId = p_intLoginUserId;
                            orderComp.LastModUserName = p_strUserName;
                            orderComp.LastModStation = p_strStation;
                            orderComp.CompleteDate = DateTime.Now.ToString("yyyy-MM-dd");
                            orderComp.CompleteTime = DateTime.Now.ToString("HH:mm:ss");
                            dbPOS1.Insert_OrderComplete(orderComp);
                        }
                    }
                }
            }
        }
        private void Process_RefundTran_Collection(int iInvNo, float fCashAmt,
                                                         float fDebitAmt,
                                                         float fVisaAmt,
                                                         float fMasterAmt,
                                                         float fAmexAmt,
                                                         float fOthersAmt,
                                                         float fChangeAmt, float fTips, string strPaymentType, bool bIsIPSPayment, bool bIsFullRefund)
        {
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            DataAccessCard dbCard = new DataAccessCard();
            POS1_TranCollectionModel col = new POS1_TranCollectionModel();
            CCardReceipt cardReceipt = new CCardReceipt();

            util.Logger("Process_RefundTran_Collection iInvNo : " + iInvNo);
            util.Logger("Process_RefundTran_Collection fCashAmt : " + fCashAmt);
            util.Logger("Process_RefundTran_Collection fDebitAmt : " + fDebitAmt);
            util.Logger("Process_RefundTran_Collection fVisaAmt : " + fVisaAmt);
            util.Logger("Process_RefundTran_Collection fMasterAmt : " + fMasterAmt);
            util.Logger("Process_RefundTran_Collection fAmexAmt : " + fAmexAmt);
            util.Logger("Process_RefundTran_Collection fOthersAmt : " + fOthersAmt);
            util.Logger("Process_RefundTran_Collection fChangeAmt : " + fChangeAmt);
            util.Logger("Process_RefundTran_Collection fTips : " + fTips);
            util.Logger("Process_RefundTran_Collection strPaymentType : " + strPaymentType);

            compOrders = dbPOS1.Get_OrderComplete_by_InvoiceNo(iInvNo);

            if ((strPaymentType.Contains("CASH")) & (bIsIPSPayment))
            {
                util.Logger("Process_RefundTran_Collection IPS Payment : " + strPaymentType);
                fCashAmt = dbCard.Get_TenderAmount(iInvNo);
                fTips = dbCard.Get_TipAmount(iInvNo);
            }
            else
            {
                util.Logger("Process_RefundTran_Collection Cash/Manual Payment : " + strPaymentType);
            }


            float fAmount = 0;
            float fTotalDueAmt = 0;
            float fTax1 = 0;
            float fTax2 = 0;
            float fTax3 = 0;

            if (compOrders.Count > 0)
            {
                if (bIsFullRefund)
                {
                    //foreach (var order in compOrders.FindAll(s => s.Quantity > 0))
                    //{
                    //    fTax1 = fTax1 + order.Tax1;
                    //    fTax2 = fTax2 + order.Tax2;
                    //    fTax3 = fTax3 + order.Tax3;
                    //    fAmount = fAmount + order.Amount;
                    //}
                    foreach (DataGridViewRow row in dgvItems.Rows)
                    {

                        float fOrderItemAmt = 0;
                        float fOrderItemTaxAmt = 0;
                        int iOrderId = Convert.ToInt32(row.Tag);
                        if (iOrderId > 0)
                        {
                            POS1_OrderCompleteModel orderComp = new POS1_OrderCompleteModel();
                            orderComp = dbPOS1.Get_OrderComplete_by_Id(iOrderId);
                            fOrderItemAmt = ((float)System.Convert.ToDouble(row.Cells[3].Value) * orderComp.Quantity);
                            fTax1 += (orderComp.IsTax1 ? (orderComp.Tax1Rate * fOrderItemAmt) : 0);
                            fTax2 += (orderComp.IsTax2 ? (orderComp.Tax2Rate * fOrderItemAmt) : 0);
                            fTax3 += (orderComp.IsTax3 ? (orderComp.Tax3Rate * fOrderItemAmt) : 0);
                            fAmount += (fOrderItemAmt);
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgvItems.Rows)
                    {
                        if (row.Cells[11].Value != null)
                        {
                            float fOrderItemAmt = 0;
                            float fOrderItemTaxAmt = 0;
                            int iOrderId = Convert.ToInt32(row.Tag);
                            POS1_OrderCompleteModel orderComp = new POS1_OrderCompleteModel();
                            orderComp = dbPOS1.Get_OrderComplete_by_Id(iOrderId);
                            if (Convert.ToInt32(row.Cells[11].Value.ToString()) > 0)
                            {
                                fOrderItemAmt = ((float)System.Convert.ToDouble(row.Cells[3].Value) * Convert.ToInt32(row.Cells[11].Value.ToString()));
                                fTax1 += (orderComp.IsTax1 ? (orderComp.Tax1Rate * fOrderItemAmt) : 0);
                                fTax2 += (orderComp.IsTax2 ? (orderComp.Tax2Rate * fOrderItemAmt) : 0);
                                fTax3 += (orderComp.IsTax3 ? (orderComp.Tax3Rate * fOrderItemAmt) : 0);
                                fAmount += (fOrderItemAmt);
                            }
                        }
                    }
                }
                fTotalDueAmt = fAmount + fTax1 + fTax2 + fTax3;

                col.Amount = fAmount * -1;   // Sub Total without Tax
                col.Tax1 = fTax1 * -1;
                col.Tax2 = fTax2 * -1;
                col.Tax3 = fTax3 * -1;

                if (strPaymentType.Contains("CASH"))
                {
                    if (fCashAmt == 0)
                    {
                        fCashAmt = fTotalDueAmt;
                    }
                    //col.Cash = fTenderAmt;
                    col.Cash = fCashAmt + fChangeAmt - fTips;
                    col.CashTip = fTips;
                }
                else if (strPaymentType.Contains("DEBIT"))
                {
                    col.Debit = fDebitAmt;
                    col.DebitTip = fTips;
                }
                else if (strPaymentType.Contains("VISA"))
                {
                    col.Visa = fVisaAmt;
                    col.VisaTip = fTips;
                }
                else if (strPaymentType.Contains("MASTER"))
                {
                    col.Master = fMasterAmt;
                    col.MasterTip = fTips;
                }
                else if (strPaymentType.Contains("AMEX"))
                {
                    col.Amex = fAmexAmt;
                    col.AmexTip = fTips;
                }
                else if (strPaymentType.Contains("GIFTCARD"))
                {
                    col.GiftCard = fCashAmt;
                    col.GiftCardTip = fTips;
                }
                else
                {
                    col.Others = fOthersAmt;
                    col.OthersTip = fTips;
                }
                col.CollectionType = strPaymentType;

                col.TotalPaid = col.Cash + col.Visa + col.Debit + col.Master + col.Amex + col.GiftCard + col.Others;
                col.TotalDue = fTotalDueAmt;
                col.Change = fChangeAmt;
                col.TotalTip = col.CashTip + col.VisaTip + col.DebitTip + col.MasterTip + col.AmexTip + col.GiftCardTip + col.OthersTip;
                col.TotalPaid += col.TotalTip;

                col.CreateDate = DateTime.Now.ToString("yyyy-MM-dd");
                col.CreateTime = DateTime.Now.ToString("HH:mm:ss");
                col.CreatePasswordCode = p_strLoginPassword;
                col.CreatePasswordName = p_strUserName;
                col.CreateStation = p_strStation;
                col.LastModDate = DateTime.Now.ToString("yyyy-MM-dd");
                col.LastModTime = DateTime.Now.ToString("HH:mm:ss");
                col.LastModPasswordCode = p_strLoginPassword;
                col.LastModPasswordName = p_strUserName;
                col.LastModStation = p_strStation;
                col.IsVoid = false;
                col.Rounding = 0;
                col.IsOnline = false;
                col.ReceiptNo = dbPOS1.Get_MaxReceiptNo_TranCollection();
                col.InvoiceNo = iInvNo;
                //col.Change = fChangeAmt;

                int iCount = dbPOS1.Insert_TranCollection(col);
                util.Logger("Insert_TranCollection ! InvNo :" + col.InvoiceNo + " ReceiptNo :" + col.ReceiptNo + " PaymentType :" + col.CollectionType + " Result : " + iCount.ToString());

            }

        }
        private void Print_Receipt(bool IsInvoice, bool IsCustomerCopy, int p_intInvoiceNo)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            DataAccessCard dbCard = new DataAccessCard();

            string strHeader = "header";
            string strFooter = "footer";
            string strContent = "1234567890123456789012345678901234567890";
            string strLine = "----------------------------------------";
            string strImageFile = "";
            float iSubTot = 0;
            float iTaxTot = 0;
            float iTotDue = 0;

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
            Font fntHeader = new Font("Courier New", 9);
            Font fntFooter = new Font("Courier New", 10, FontStyle.Bold);
            Font fntContents = new Font("Courier New", 8);
            Font fntTotals = new Font("Courier New", 8, FontStyle.Bold);
            Font fntCard = new Font("Consolas", 8);
            SolidBrush brsBlack = new SolidBrush(Color.Black);

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                int iNextLineYPoint = 0;
                int iLogoHeight = 80;
                int itxtHeight = 12;
                int iheaderHeight = 14;
                int ititleHeight = 17;
                //////////////////////////////////////////////////////////////////////////
                // Print Logo ------------------------------------------------------
                strImageFile = dbPOS.Get_SysConfig_By_Name("IS_RECEIPT_LOGO_PRINT")[0].ConfigValue.Trim();
                if (strImageFile.Contains("TRUE"))
                {
                    strImageFile = dbPOS.Get_SysConfig_By_Name("RECEIPT_LOGO_IMAGE")[0].ConfigValue.Trim();
                    if (strImageFile.Length > 0)
                    {
                        Image logoImg = Image.FromFile(strImageFile);
                        Rectangle logoRect = new Rectangle(new Point(0, 0), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iLogoHeight));
                        //e1.Graphics.DrawRectangle(Pens.Black, logoRect);
                        e1.Graphics.DrawImage(logoImg, logoRect, new Rectangle(0, 0, logoImg.Width, logoImg.Height), GraphicsUnit.Pixel);
                    }
                    iNextLineYPoint = iNextLineYPoint + iLogoHeight;
                }
                //////////////////////////////////////////////////////////////////////////
                // Print Header ------------------------------------------------------

                Rectangle txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                //e1.Graphics.DrawRectangle(Pens.Black, txtRect);
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_TITLE")[0].ConfigValue, fntTitle, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + ititleHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_ADDR1")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_ADDR2")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_PHONE_NO")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_REG_NO")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                //////////////////////////////////////////////////////////////////////////
                // Print order header ------------------------------------------------------
                strContent = String.Format("{0,-17}", "Inv#: " + String.Format("{0}", System.Convert.ToInt32(p_intInvoiceNo))) +
                             String.Format("{0,20}", "Served by: " + p_strUserName);
                iNextLineYPoint = iNextLineYPoint + iheaderHeight + 5;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                strContent = String.Format("{0,-17}", "Station:" + p_strStation) +
                             String.Format("{0,20}", "# of Customer:" + iPpleCount.ToString());
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                strContent = String.Format("{0,-17}", "Issued:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                if (IsCustomerCopy)
                {
                    //////////////////////////////////////////////////////////////////////////
                    // Print a Line ------------------------------------------------------
                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);

                    //////////////////////////////////////////////////////////////////////////
                    // Print order header ------------------------------------------------------
                    strContent = String.Format("{0,-20}", StringCentering("Item Desc", 20)) + String.Format("{0,5}", "QTY") +
                                 String.Format("{0,7}", "Price") + String.Format("{0,8}", "Amount");
                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                    //////////////////////////////////////////////////////////////////////////
                    // Print a Line ------------------------------------------------------
                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);

                    if (IsInvoice)
                    {
                        List<POS_OrdersModel> orderitems = new List<POS_OrdersModel>();
                        orderitems = dbPOS.Get_Orders_by_InvoiceNo(p_intInvoiceNo);
                        if (orderitems.Count > 0)
                        {
                            ////////////////////////////////////////////////
                            // Add the ordered item into datagrid view
                            ////////////////////////////////////////////////
                            //iNewInvNo = orders[0].InvoiceNo;
                            foreach (var order in orderitems)
                            {
                                float iAmount = 0;
                                string strProd = "";

                                if (order.OrderCategoryId == 0)
                                {
                                    iAmount = order.Quantity * order.OutUnitPrice;
                                    iSubTot = iSubTot + iAmount;
                                    iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                                    strProd = order.ProductName;

                                    if (order.ProductName.Length > 20)
                                    {
                                        strProd = order.ProductName.Substring(0, 20);
                                    }

                                    strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                 String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));
                                }
                                else if (order.OrderCategoryId > 0) // Discount = 4, Deposit, Return = 5
                                {
                                    iAmount = order.Amount;
                                    iSubTot = iSubTot + iAmount;
                                    iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                                    strProd = order.ProductName;

                                    if (order.ProductName.Length > 20)
                                    {
                                        strProd = order.ProductName.Substring(0, 20);
                                    }

                                    strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                 String.Format("{0,7}", order.Amount.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                                }
                                //////////////////////////////////////////////////////////////////////////
                                // Print order ------------------------------------------------------
                                iNextLineYPoint = iNextLineYPoint + itxtHeight;
                                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                //e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            }
                            iTotDue = iSubTot + iTaxTot;
                        }
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strContent = String.Format("{0,25}", "Sub Total :") + String.Format("{0,15}", iSubTot.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strContent = String.Format("{0,25}", "Tax :") + String.Format("{0,15}", iTaxTot.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strContent = String.Format("{0,25}", "Total Due :") + String.Format("{0,15}", iTotDue.ToString("0.00"));
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                        if (iPpleCount > 1)
                        {
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            float iPplDue = iTotDue / iPpleCount;
                            strContent = String.Format("{0,25}", "1/" + iPpleCount.ToString() + " Each :") + String.Format("{0,15}", iPplDue.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);

                        }
                        if (dbPOS.Get_SysConfig_By_Name("INVOICE_TIP_GUIDE")[0].ConfigValue == "True")
                        {
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            float iTip = iTotDue * (float)0.10;
                            strContent = String.Format("{0,25}", "10% Tip :") + String.Format("{0,15}", iTip.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            iTip = iTotDue * (float)0.15;
                            strContent = String.Format("{0,25}", "15% Tip :") + String.Format("{0,15}", iTip.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            iTip = iTotDue * (float)0.2;
                            strContent = String.Format("{0,25}", "20% Tip :") + String.Format("{0,15}", iTip.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        }
                    }
                    else
                    {
                        List<POS1_OrderCompleteModel> orderitems = new List<POS1_OrderCompleteModel>();
                        orderitems = dbPOS1.Get_OrderComplete_by_InvoiceNo(p_intInvoiceNo);
                        if (orderitems.Count > 0)
                        {
                            ////////////////////////////////////////////////
                            // Add the ordered item into datagrid view
                            ////////////////////////////////////////////////
                            //iNewInvNo = orders[0].InvoiceNo;
                            foreach (var order in orderitems)
                            {
                                float iAmount = 0;
                                string strProd = "";
                                if (order.ProductName.Length > 20)
                                {
                                    strProd = order.ProductName.Substring(0, 20);
                                }
                                if (order.OrderCategoryId == 0)
                                {
                                    iAmount = order.Quantity * order.OutUnitPrice;
                                    iSubTot = iSubTot + iAmount;
                                    iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                                    strProd = order.ProductName;
                                    if (strProd.Length < 21)
                                    {
                                        strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                     String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                                    }
                                    else
                                    {
                                        strContent = String.Format("{0,-20}", strProd.Substring(0, 20)) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                     String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                                    }
                                }
                                else if (order.OrderCategoryId > 0) // Discount
                                {
                                    iAmount = order.Amount;
                                    iSubTot = iSubTot + iAmount;
                                    iTaxTot = iTaxTot + order.Tax1 + order.Tax2 + order.Tax3;
                                    strProd = order.ProductName;
                                    if (strProd.Length < 21)
                                    {
                                        strContent = String.Format("{0,-20}", strProd) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                     String.Format("{0,7}", order.OutUnitPrice.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));

                                    }
                                    else
                                    {

                                        strContent = String.Format("{0,-20}", strProd.Substring(0, 20)) + String.Format("{0,5}", order.Quantity.ToString()) +
                                                 String.Format("{0,7}", order.Amount.ToString("0.00")) + String.Format("{0,8}", iAmount.ToString("0.00"));
                                    }
                                }
                                //////////////////////////////////////////////////////////////////////////
                                // Print order ------------------------------------------------------
                                iNextLineYPoint = iNextLineYPoint + itxtHeight;
                                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                //e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                                if (strProd.Length > 20)
                                {
                                    strContent = String.Format("{0,-20}", "-" + strProd.Substring(20));

                                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    //e1.Graphics.DrawString(strContent, fntContents, brsBlack, (RectangleF)txtRect, format2);
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                }
                            }

                            iTotDue = iSubTot + iTaxTot;
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            strContent = String.Format("{0,25}", "Sub Total :") + String.Format("{0,15}", iSubTot.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            strContent = String.Format("{0,25}", "Tax :") + String.Format("{0,15}", iTaxTot.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                            List<POS1_TranCollectionModel> cols = new List<POS1_TranCollectionModel>();
                            cols = dbPOS1.Get_TranCollection_by_InvoiceNo(p_intInvoiceNo);

                            float fTenderAmt = 0, fTotalTips = 0, fTotalPaid = 0, fTotalChange = 0;

                            if (cols.Count > 0)
                            {
                                foreach (var col in cols)
                                {
                                    col.CollectionType = col.CollectionType.ToUpper();
                                    if (col.CollectionType.Contains("CASH"))
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Cash Paid :") + String.Format("{0,15}", (col.Cash - col.Change).ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.CashTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Cash) :") + String.Format("{0,15}", col.CashTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }

                                    }
                                    else if (col.CollectionType.Contains("DEBIT"))
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Debit Paid :") + String.Format("{0,15}", col.Debit.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.DebitTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Debit) :") + String.Format("{0,15}", col.DebitTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }
                                    }
                                    else if (col.CollectionType.Contains("VISA"))
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Visa/Credit Paid :") + String.Format("{0,15}", col.Visa.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.VisaTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Visa/Credit) :") + String.Format("{0,15}", col.VisaTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }

                                    }
                                    else if (col.CollectionType.Contains("MASTER"))
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Master Paid :") + String.Format("{0,15}", col.Master.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.MasterTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Master) :") + String.Format("{0,15}", col.MasterTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }
                                    }
                                    else if (col.CollectionType.Contains("AMEX"))
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", "Amex Paid :") + String.Format("{0,15}", col.Amex.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.AmexTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip(Amex) :") + String.Format("{0,15}", col.AmexTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }
                                    }
                                    else
                                    {
                                        //////////////////////////////////////////////////////////////////////////
                                        // Print a Line ------------------------------------------------------
                                        strContent = String.Format("{0,25}", col.CollectionType + " Paid :") + String.Format("{0,15}", col.Amex.ToString("0.00"));
                                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                        e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        if (col.AmexTip > 0)
                                        {
                                            //////////////////////////////////////////////////////////////////////////
                                            // Print a Line ------------------------------------------------------
                                            strContent = String.Format("{0,25}", "Tip :") + String.Format("{0,15}", col.AmexTip.ToString("0.00"));
                                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                        }
                                    }


                                    fTenderAmt = fTenderAmt + col.Cash + col.Debit + col.Visa + col.Master + col.Amex + col.GiftCard;
                                    fTotalPaid = fTotalPaid + col.TotalPaid;
                                    fTotalChange = fTotalChange + col.Change;
                                    fTotalTips = fTotalTips + col.TotalTip;
                                }
                                iTotDue = iTotDue - fTenderAmt;
                                if (fTotalChange != 0)
                                {
                                    //////////////////////////////////////////////////////////////////////////
                                    // Print a Line ------------------------------------------------------
                                    strContent = String.Format("{0,25}", "Total Changes :") + String.Format("{0,15}", fTotalChange.ToString("0.00"));
                                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                                }
                                //////////////////////////////////////////////////////////////////////////
                                // Print a Line ------------------------------------------------------
                                strContent = String.Format("{0,25}", "Total Paid :") + String.Format("{0,15}", fTotalPaid.ToString("0.00"));
                                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                            }

                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            strContent = String.Format("{0,25}", "Total Due :") + String.Format("{0,15}", iTotDue.ToString("0.00"));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                        }
                    }
                }

                //////////////////////////////////////////////////////////////////////////
                // Print a Line ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);

                List<CCardReceipt> cardReceipts = new List<CCardReceipt>();
                cardReceipts = dbCard.Get_Approved_CardReceipt_By_InvoiceNo(p_intInvoiceNo);
                string strTemp1;
                string strTemp2;
                float fCurrency;
                if (cardReceipts.Count > 0)
                {
                    foreach (var receipt in cardReceipts)
                    {
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = "MID:" + receipt.MerchId;
                        strTemp2 = "REF#:" + String.Format("{0:D8}", System.Convert.ToInt32(receipt.ReferenceNo));
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", strTemp2);
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = "TID:" + receipt.TerminalId;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        if (receipt.TransactionType == "00")
                            strTemp1 = " > PURCHASED AMOUNT";
                        else if (receipt.TransactionType == "03")
                            strTemp1 = " > REFUND AMOUNT";
                        else if (receipt.TransactionType == "05")
                            strTemp1 = " > VOID AMOUNT";
                        fCurrency = (float)System.Convert.ToDouble(receipt.TransactionAmount) / 100;
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = " + TIP ADDED";
                        fCurrency = (float)System.Convert.ToDouble(receipt.TipAmount) / 100;
                        if (fCurrency > 0)
                        {
                            strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);

                            //////////////////////////////////////////////////////////////////////////
                            // Print a Line ------------------------------------------------------
                            strTemp1 = " = TOTAL PAID";
                            fCurrency = (float)System.Convert.ToDouble(receipt.TotalAmount) / 100;
                            strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", String.Format("{0:C}", fCurrency));
                            iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                            txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                            e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        }
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        strTemp1 = receipt.EMVApplicationLabel + " ACCN No : " + receipt.CustomerAccountNumber;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = String.Format("DATE: {0:D}", receipt.CreateDate);
                        strTemp2 = String.Format("TIME: {0:T}", receipt.CreateTime);
                        strContent = String.Format("{0,-23}", strTemp1) + String.Format("{0,20}", strTemp2);
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = "AUTH NO: " + receipt.AuthorizationNo;
                        strTemp2 = "TSI: " + receipt.EmvTsi;
                        strContent = String.Format("{0,-30}", strTemp1) + String.Format("{0,13}", strTemp2);
                        //iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 2);
                        iNextLineYPoint = iNextLineYPoint + (iheaderHeight);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = "AID: " + receipt.EmvAid;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        //DateTime datetime = DateTime.Now;
                        strTemp1 = "TVR: " + receipt.EmvTvr;
                        strContent = String.Format("{0,-40}", strTemp1);
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strContent, fntCard, brsBlack, (RectangleF)txtRect, format2);

                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString(receipt.HostResponseText, fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        //iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        //txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        //e1.Graphics.DrawString("SIGNATURE NOT REQUIRED", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        //iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 1);
                        //txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        //e1.Graphics.DrawString("IMPORTANT", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("Pls. retain this copy for your records.", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("CARDHOLDER ACKNOWLEDGES RECEIPT OF GOODS", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("AND/OR SERVICES IN THE AMOUNT OF THE", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        // Print Header ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                        e1.Graphics.DrawString("TOTAL SHOWN HEREON", fntCard, brsBlack, (RectangleF)txtRect, format1);
                        //////////////////////////////////////////////////////////////////////////
                        // Print a Line ------------------------------------------------------
                        iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                        txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                        e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                    } // for each
                } //if (cardReceipts.Count > 0)
                  // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString("THANK YOU FOR COMING", fntCard, brsBlack, (RectangleF)txtRect, format1);
            }; //if (IsInvoice)
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int iOrderItemId = 0;
            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            POS1_OrderCompleteModel orderitem = new POS1_OrderCompleteModel();
            POS1_OrderCompleteModel refunditem = new POS1_OrderCompleteModel();
            // Get the selected order item id from the datagrid view
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvItems.Rows[e.RowIndex];
                // Get the row tag
                iOrderItemId = Convert.ToInt32(row.Tag);
                // Get the selected order item
                if (iOrderItemId > 0)
                {
                    orderitem = dbPOS1.Get_OrderComplete_by_Id(iOrderItemId);
                    if (orderitem != null)
                    {
                        refunditem = dbPOS1.Get_Refund_OrderComplete_by_InvoiceNo_ProdId(orderitem.InvoiceNo, orderitem.ProductId);
                        if (refunditem != null)
                            orderitem.Quantity += refunditem.Quantity;
                    }
                    // Set the selected order item to the form
                }
            }
            // Refund checkbox is clicked ?
            if (e.ColumnIndex == 10)
            {
                if ((bool)dgvItems.Rows[e.RowIndex].Cells[10].EditedFormattedValue == true)
                {
                    dgvItems.Rows[e.RowIndex].Cells[11].Value = orderitem.Quantity;
                }
                else
                {
                    dgvItems.Rows[e.RowIndex].Cells[11].Value = 0;
                }
            }

        }
        // set row background color pink if void or refund
        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow row = dgvData.Rows[e.RowIndex];
            if (Convert.ToDouble(row.Cells[8].Value) < 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightPink;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}

