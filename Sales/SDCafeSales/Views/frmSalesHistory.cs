using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDCafeSales.Views
{
    public partial class frmSalesHistory : Form
    {
        frmSalesMain FrmSalesMain;

        List<POS1_TranCollectionModel> trancols = new List<POS1_TranCollectionModel>();
        private string strSelInvNo;
        private int iSelInvNo = 0;
        private string strUserName = String.Empty;
        private string strStation = String.Empty;
        private int iPpleCount = 0;
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

            float iTotalCount = 0;
            float iTotalSales = 0;
            float iVoidCount = 0;
            float iVoidSales = 0;
            float iTotalTips = 0;
            float iVoidTips = 0;

            DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
            trancols = dbPOS1.Get_TranCollection_by_Date(dttm_TranStart.Value.ToString("yyyy-MM-dd"), dttm_TranEnd.Value.ToString("yyyy-MM-dd"));
            if (trancols.Count > 0)
            {
                iTotalCount = trancols.Count;
                foreach (var trancol in trancols)
                {
                    iTotalSales = iTotalSales + (trancol.Amount + trancol.Tax1 + trancol.Tax2 + trancol.Tax3);
                    iTotalTips = iTotalTips + trancol.TotalTip;
                    this.dgvData.Rows.Add(new String[] { trancol.CreateDate.ToString() + " " + trancol.CreateTime.ToString(),
                                                         trancol.InvoiceNo.ToString(),
                                                         trancol.CollectionType,
                                                         trancol.Amount.ToString("0.00"),
                                                         trancol.Tax1.ToString("0.00"),
                                                         trancol.Tax2.ToString("0.00"),
                                                         trancol.Tax3.ToString("0.00"),
                                                         trancol.TotalPaid.ToString("0.00"),
                                                         trancol.TotalTip.ToString("0.00"),
                                                         trancol.IsVoid.ToString()
                    });

                    if (trancol.IsVoid)
                    {
                        iVoidCount++;
                        iVoidSales = iVoidSales + (trancol.Amount + trancol.Tax1 + trancol.Tax2 + trancol.Tax3);
                        iVoidTips = iVoidTips + trancol.TotalTip;
                        for (int i = 0; i < 10; i++)
                        {
                            this.dgvData.Rows[dgvData.RowCount - 2].Cells[i].Style.BackColor = Color.LightSalmon;
                            this.dgvData.Rows[dgvData.RowCount - 2].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                        }
                    }

                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;
                }
                txt_TotalCount.Text = iTotalCount.ToString();
                txt_TotalSales.Text = iTotalSales.ToString("$0.00");
                txt_TotalTips.Text = iTotalTips.ToString("$0.00");
              
                txt_TotalVoidCount.Text = iVoidCount.ToString();
                txt_TotalVoidCount.BackColor = Color.LightSalmon;
                txt_TotalVoidSales.Text = iVoidSales.ToString("$0.00");
                txt_TotalVoidSales.BackColor = Color.LightSalmon;
                txt_VoidTips.Text = iVoidTips.ToString("$0.00");
                txt_VoidTips.BackColor = Color.LightSalmon;

                txt_TotalSum.Text = (iTotalSales - iVoidSales).ToString("$0.00");
                txt_TipSum.Text = (iTotalTips - iVoidTips).ToString("$0.00");
            }
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
            this.dgvData.Columns[1].Width = 140;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = "Payment Type";
            this.dgvData.Columns[2].Width = 100;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = "Net";
            this.dgvData.Columns[3].Width = 100;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[4].Name = "GST";
            this.dgvData.Columns[4].Width = 70;
            this.dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[5].Name = "PST";
            this.dgvData.Columns[5].Width = 70;
            this.dgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[6].Name = "Tax3";
            this.dgvData.Columns[6].Width = 70;
            this.dgvData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[7].Name = "Paid";
            this.dgvData.Columns[7].Width = 100;
            this.dgvData.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[8].Name = "Tip";
            this.dgvData.Columns[8].Width = 70;
            this.dgvData.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[9].Name = "Void";
            this.dgvData.Columns[9].Width = 50;
            this.dgvData.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

        private void bt_ReprintReceipt_Click(object sender, EventArgs e)
        {
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
                //////////////////////////////////////////////////////////////////////////
                // Print order header ------------------------------------------------------
                strContent = String.Format("{0,-17}", "Inv#: " + String.Format("{0}", System.Convert.ToInt32(iSelInvNo))) +
                                String.Format("{0,20}", "Served by: " + strUserName);
                iNextLineYPoint = iNextLineYPoint + iheaderHeight + 5;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                strContent = String.Format("{0,-17}", "Station:" + strStation) +
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
                                    if (col.CollectionType == "Cash")
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
            Int32 selectedRowCount =
            dgvData.Rows.GetRowCount(DataGridViewElementStates.Selected);
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
                if (dbPOS1.IsVoidCollection(Convert.ToInt32(strSelInvNo)) ==true)
                {
                    bt_SetVoid.Text = "Cancel Void";
                    bt_SetVoid.BackColor = Color.GreenYellow;
                }
                else
                {
                    bt_SetVoid.Text = "Set Void";
                    bt_SetVoid.BackColor = Color.LightSalmon;
                }
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
            if (strSelInvNo.Length > 0)
            {
                iSelInvNo = System.Convert.ToInt32(strSelInvNo);
                if (iSelInvNo > 0)
                {
                    using (var FrmYesNo = new frmYesNo(this.FrmSalesMain))
                    {
                        FrmYesNo.Set_Title("Void");

                        FrmYesNo.Set_Message("Set/Unset Void ? Invoice# : " + strSelInvNo);
                        FrmYesNo.StartPosition = FormStartPosition.Manual; // FormStartPosition.CenterScreen; //
                        FrmYesNo.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                                  (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                        FrmYesNo.ShowDialog();

                        if (FrmYesNo.bYesNo)
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

                            bt_Query.PerformClick();
                        }
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
