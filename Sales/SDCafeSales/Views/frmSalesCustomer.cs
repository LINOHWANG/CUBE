using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDCafeCommon.Utilities;
using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.IO.Ports;

namespace SDCafeSales.Views
{


    public partial class frmSalesCustomer : Form
    {
        List<POS_SysConfigModel> sysConfigs = new List<POS_SysConfigModel>();
        List<POS_OrdersModel> orders = new List<POS_OrdersModel>();
        List<POS_OrdersModel> childOrders = new List<POS_OrdersModel>();
        frmSalesMain FrmSalesMain;
        Utility util = new Utility();

        private bool isNewInvoice = false;
        private int iNewInvNo = 0;

        public double iSubTotal { get; set; }
        public double iTaxTotal { get; set; }
        public double iTotalDue { get; set; }
        public double iTotalItems { get; set; }

        public bool b_ScanStarted = false;

        private string[] strAdImageFiles;
        private int iAdImageFiles;
        private int iCurrentAdImageFilesIndex;
        private Size sizeAdImage;
        private int iAdImageX;
        private int iAdImageY;
        private Point pointAdImage;
        private float m_fCashDue;
        private float m_fCashRounding;

        private int m_int_FadeOut = 0;
        private Color colToFadeTo;

        public frmSalesCustomer(frmSalesMain _FrmSalesMain)
        {
            InitializeComponent();
            LoadAdImageFiles();
            this.FrmSalesMain = _FrmSalesMain;
            timer1.Enabled = true;
            timer_AdImg.Enabled = true;
            txtMessages.Text = "Ready to Start !";

            DataAccessPOS dbPOS = new DataAccessPOS();
            sysConfigs = dbPOS.Get_SysConfig_By_Name("SCREEN_LOGO_IMAGE");
            if (sysConfigs.Count > 0)
            {
                pb_Instruction.Image = System.Drawing.Image.FromFile(sysConfigs[0].ConfigValue);
            }
            sysConfigs = dbPOS.Get_SysConfig_By_Name("AD_IMAGE_ROTATION_INTERVAL");
            if (sysConfigs.Count > 0)
            {
                timer_AdImg.Interval = int.Parse(sysConfigs[0].ConfigValue);
            }
            colToFadeTo = Color.FromArgb(0, 250, 250, 250); //create color object with alpha value 0
            m_int_FadeOut = 0;//50;
        }

        private void LoadAdImageFiles()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            sysConfigs = dbPOS.Get_SysConfig_By_Name("AD_IMAGE_FOLDER");
            
            //strAdImageFiles.Initialize();
            if (sysConfigs.Count > 0)
            {
                strAdImageFiles = Directory.GetFiles(sysConfigs[0].ConfigValue);
            }
            iAdImageFiles = strAdImageFiles.Length;
            iCurrentAdImageFilesIndex = 0;

            sizeAdImage = pb_Instruction.Size;
            pointAdImage = pb_Instruction.Location;
        }

        private void bt_Start_Click(object sender, EventArgs e)
        {
            txtMessages.Text = "Scanning is Started !";
            util.Logger("frmSalesCustomer : bt_Start_Click");
            //FrmSalesMain.StartScanByCustomer();
            //Bug #1553
            //dgv_Orders_Initialize();
            Load_Existing_Orders();
            bt_Start.Enabled = false;
            bt_Start.Visible = false;
            bt_Payment.Enabled = true;
            bt_Payment.Visible = true;
            FrmSalesMain.BarCode_Get_Focus();
        }

        private void bt_Payment_Click(object sender, EventArgs e)
        {
            txtMessages.Text = "Payment Started !";
            util.Logger("frmSalesCustomer : bt_Payment_Click");
            FrmSalesMain.PaymentByCustomer();
            if (FrmSalesMain.bPaymentSuccess)
            {
                bt_Payment.Enabled = false;
                txtMessages.Text = "Payment Completed !";
            }
            else
            {
                txtMessages.Text = "Payment is canceled or aborted !";
            }
            util.Logger("frmSalesCustomer : " + txtMessages.Text);
            bt_Start.Enabled = true;
            bt_Start.Visible = true;
            bt_Payment.Enabled = false;
            bt_Payment.Visible = false;
            FrmSalesMain.BarCode_Get_Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_ItemCount.Text = FrmSalesMain.iTotalItems.ToString("0");
            txt_SubTotal.Text = FrmSalesMain.iSubTotal.ToString("C2");
            txt_TaxTotal.Text = FrmSalesMain.iTaxTotal.ToString("C2");
            txt_TotalDue.Text = FrmSalesMain.iTotalDue.ToString("C2");


            // Rounding for Cash Payment
            m_fCashDue = (float)(Math.Round((FrmSalesMain.iTotalDue / 0.05)) * 0.05);
            m_fCashRounding = (float)Math.Round(m_fCashDue - FrmSalesMain.iTotalDue, 2);
            //util.Logger("frmCashPayment Loading ... Rounding ? " + m_fCashRounding.ToString());
            txt_CashDue.Text = m_fCashDue.ToString("C2");

            // Maximize Ad image
            if (FrmSalesMain.iTotalDue == 0)
            {
                pb_Instruction.Size = this.Size;
                Point pntZero = new Point(0, 0); ;
                pb_Instruction.Location = pntZero;
                pb_Instruction.BringToFront();
            }
            else
            {
                // Original size of Ad image with Amount, Items
                pb_Instruction.Size = sizeAdImage;
                pb_Instruction.Location = pointAdImage;
            }
        }

        private void txt_SubTotal_TextChanged(object sender, EventArgs e)
        {
            Load_Existing_Orders();
            util.Logger("frmSalesCustomer : Total has changed : " + txt_SubTotal.Text + ", InvNo = " + iNewInvNo.ToString());
        }

        private void dgv_Orders_Initialize()
        {
            this.dgv_Orders.AutoSize = false;
            dgv_Orders.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgv_Orders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Orders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Orders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgv_Orders.ColumnCount = 6;
            this.dgv_Orders.Columns[0].Name = "Seq";
            this.dgv_Orders.Columns[0].Width = 40;
            this.dgv_Orders.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Orders.Columns[1].Name = "Product Name";
            this.dgv_Orders.Columns[1].Width = 115;
            this.dgv_Orders.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgv_Orders.Columns[2].Name = "QTY";
            this.dgv_Orders.Columns[2].Width = 50;
            this.dgv_Orders.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_Orders.Columns[3].Name = "Unit Price";
            this.dgv_Orders.Columns[3].Width = 55;
            this.dgv_Orders.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_Orders.Columns[4].Name = "Amount";
            this.dgv_Orders.Columns[4].Width = 70;
            this.dgv_Orders.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_Orders.Columns[5].Name = "Tax";
            this.dgv_Orders.Columns[5].Width = 40;
            this.dgv_Orders.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgv_Orders.Columns[5].Name = "OrderId";
            //this.dgv_Orders.Columns[5].Width = 0;
            //this.dgv_Orders.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgv_Orders.DefaultCellStyle.Font = new Font("Arial Narrow", 12F, FontStyle.Bold);
            this.dgv_Orders.EnableHeadersVisualStyles = false;
            this.dgv_Orders.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold);
            this.dgv_Orders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Orders.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgv_Orders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv_Orders.AllowUserToResizeRows = false;
            dgv_Orders.RowTemplate.Resizable = DataGridViewTriState.True;
            dgv_Orders.RowTemplate.MinimumHeight = 20;
            dgv_Orders.RowTemplate.Height = 40;
            dgv_Orders.AllowUserToAddRows = false;
        }
        private void Load_Existing_Orders()
        {
            int iIndex = 0;
            string strTaxShort;

            dgv_Orders_Initialize();
            DataAccessPOS dbPOS = new DataAccessPOS();
            orders = dbPOS.Get_ParentOrders_by_Station(FrmSalesMain.strStation);
            if (orders.Count > 0)
            {
                ////////////////////////////////////////////////
                // Add the ordered item into datagrid view
                ////////////////////////////////////////////////
                isNewInvoice = true;
                iNewInvNo = orders[0].InvoiceNo;
                foreach (var order in orders)
                {
                    iIndex++;
                    float iAmount = 0;
                    if (order.OrderCategoryId == 0)
                    {
                        iAmount = order.Quantity * order.OutUnitPrice;
                        iAmount = order.Quantity * order.OutUnitPrice;
                        strTaxShort = "";
                        strTaxShort += order.IsTax1 ? FrmSalesMain.strTax1Name.Substring(0, 1) : "";
                        strTaxShort += order.IsTax2 ? FrmSalesMain.strTax2Name.Substring(0, 1) : "";
                        strTaxShort += order.IsTax3 ? FrmSalesMain.strTax3Name.Substring(0, 1) : "";
                        this.dgv_Orders.Rows.Add(new String[] { iIndex.ToString(),
                                                                                   order.ProductName,
                                                                                   order.Quantity.ToString(),
                                                                                   order.OutUnitPrice.ToString("0.00"),
                                                                                   //iAmount.ToString("0.00")
                                                                                   order.Amount.ToString("0.00"),
                                                                                   strTaxShort
                                });
                        childOrders.Clear();
                        childOrders = dbPOS.Get_ChildOrders_by_Station(FrmSalesMain.strStation, order.Id);
                        foreach (var corder in childOrders)
                        {
                            strTaxShort = "";
                            strTaxShort += corder.IsTax1 ? FrmSalesMain.strTax1Name.Substring(0, 1) : "";
                            strTaxShort += corder.IsTax2 ? FrmSalesMain.strTax2Name.Substring(0, 1) : "";
                            strTaxShort += corder.IsTax3 ? FrmSalesMain.strTax3Name.Substring(0, 1) : "";
                            if (corder.OrderCategoryId == 0)
                            {
                                iAmount = corder.Quantity * corder.OutUnitPrice;
                                this.dgv_Orders.Rows.Add(new String[] {  iIndex.ToString(),
                                                                                   corder.ProductName,
                                                                                   corder.Quantity.ToString(),
                                                                                   corder.OutUnitPrice.ToString("0.00"),
                                                                                   //iAmount.ToString("0.00"),
                                                                                   corder.Amount.ToString("0.00"),
                                                                                   strTaxShort
                                });
                            }
                            else if (corder.OrderCategoryId > 0) // Discount
                            {
                                iAmount = corder.Amount;
                                this.dgv_Orders.Rows.Add(new String[] { iIndex.ToString(),
                                                                                   corder.ProductName,
                                                                                   corder.Quantity.ToString(),
                                                                                   corder.OutUnitPrice.ToString("0.00"),
                                                                                   //iAmount.ToString("0.00"),
                                                                                   corder.Amount.ToString("0.00"),
                                                                                   strTaxShort
                                });
                                this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = corder.RFTagId;
                                DataGridViewRow row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                                row.DefaultCellStyle.ForeColor = Color.DarkGray;
                                // Reduce the row height
                                dgv_Orders.Rows[dgv_Orders.Rows.Count - 1].Height = 20;
                                //dgv_Orders.Refresh();
                            }
                            if (corder.RFTagId > 0)
                            {
                                this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = corder.RFTagId;
                                DataGridViewRow row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                                row.DefaultCellStyle.ForeColor = Color.Blue;
                            }
                            else
                            {
                                this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = null;
                            }
                            this.dgv_Orders.FirstDisplayedScrollingRowIndex = dgv_Orders.RowCount - 1;

                        }
                    }
                    else if (order.OrderCategoryId == 4) // Promo Discount
                    {
                        strTaxShort = "";
                        strTaxShort += order.IsTax1 ? FrmSalesMain.strTax1Name.Substring(0, 1) : "";
                        strTaxShort += order.IsTax2 ? FrmSalesMain.strTax2Name.Substring(0, 1) : "";
                        strTaxShort += order.IsTax3 ? FrmSalesMain.strTax3Name.Substring(0, 1) : "";
                        iAmount = order.Amount;
                        this.dgv_Orders.Rows.Add(new String[] { iIndex.ToString(),
                                                                                   order.ProductName,
                                                                                   order.Quantity.ToString(),
                                                                                   order.OutUnitPrice.ToString("0.00"),
                                                                                   //iAmount.ToString("0.00")
                                                                                   order.Amount.ToString("0.00"),
                                                                                   strTaxShort
                                });
                        DataGridViewRow row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    if (order.RFTagId > 0)
                    {
                        this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = order.RFTagId;
                        DataGridViewRow row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                        row.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        if (this.dgv_Orders.RowCount > 0)
                        this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = null;
                    }
                    if (dgv_Orders.RowCount > 0)
                        this.dgv_Orders.FirstDisplayedScrollingRowIndex = dgv_Orders.RowCount - 1;
                    //this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView(order.RFTagId);
                    //this.dgv_Orders.Rows[Get_OrderedItem_Index_of_GridView(order.RFTagId)].Selected = true;
                    // this.dgv_Orders.Rows[dgv_Orders.RowCount - 1].Selected = true;
                }
            }
            this.dgv_Orders.ClearSelection();
        }

        private void timer_AdImg_Tick(object sender, EventArgs e)
        {
            if (strAdImageFiles.Count() == 0)
            {
                return;
            }
            // wait until timerFadeOut is finished
            if (timerFadeOut.Enabled)
            {
                return;
            }
            else
            {
                m_int_FadeOut = 50;
                timerFadeOut.Start();
                while (timerFadeOut.Enabled)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
            }

            pb_Instruction.Image = System.Drawing.Image.FromFile(strAdImageFiles[iCurrentAdImageFilesIndex]);
            iCurrentAdImageFilesIndex++;
            if (iCurrentAdImageFilesIndex >= strAdImageFiles.Length)
            {
                iCurrentAdImageFilesIndex = 0;
            }
        }
        private void timerFadeOut_Tick(object sender, EventArgs e)
        {

            if (m_int_FadeOut == 80)
            {
                //if m_int_FadeOut was incremented up to 102, the picture was faded 
                //and the buttons can be enabled again
                m_int_FadeOut = 50;
                timerFadeOut.Stop();
                return;
            }
            else
            {
                //pass incremented m_int_FadeOut, and chosen color to function 
                //Lighter and set modified image as second picture box image
                pb_Instruction.Image = Lighter(pb_Instruction.Image, m_int_FadeOut++, colToFadeTo.R,
                                       colToFadeTo.G, colToFadeTo.B);

            }
        }
        private System.Drawing.Image Lighter(System.Drawing.Image imgLight, int level, int nRed, int nGreen, int nBlue)
        {
            //convert image to graphics object
            Graphics graphics = Graphics.FromImage(imgLight);
            int conversion = (5 * (level - 50)); //calculate new alpha value
                                                 //create mask with blended alpha value and chosen color as pen 
            Pen pLight = new Pen(Color.FromArgb(conversion, nRed,
                                 nGreen, nBlue), imgLight.Width * 2);
            //apply created mask to graphics object
            graphics.DrawLine(pLight, -1, -1, imgLight.Width, imgLight.Height);
            //save created graphics object and modify image object by that
            graphics.Save();
            graphics.Dispose(); //dispose graphics object
            return imgLight; //return modified image
        }


    }
}
