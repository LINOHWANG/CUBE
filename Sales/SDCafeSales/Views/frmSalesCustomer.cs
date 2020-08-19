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

namespace SDCafeSales.Views
{


    public partial class frmSalesCustomer : Form
    {
        List<POS_OrdersModel> orders = new List<POS_OrdersModel>();
        frmSalesMain FrmSalesMain;
        Utility util = new Utility();

        private bool isNewInvoice = false;
        private int iNewInvNo = 0;

        public double iSubTotal { get; set; }
        public double iTaxTotal { get; set; }
        public double iTotalDue { get; set; }
        public double iTotalItems { get; set; }

        public bool b_ScanStarted = false;

        public frmSalesCustomer(frmSalesMain _FrmSalesMain)
        {
            InitializeComponent();
            this.FrmSalesMain = _FrmSalesMain;
            timer1.Enabled = true;
            txtMessages.Text = "Ready to Start !";
        }

        private void bt_Start_Click(object sender, EventArgs e)
        {
            txtMessages.Text = "Scanning is Started !";
            FrmSalesMain.StartScanByCustomer();
            //Bug #1553
            //dgv_Orders_Initialize();
            Load_Existing_Orders();
            bt_Start.Enabled = false;
            bt_Payment.Enabled = true;
        }

        private void bt_Payment_Click(object sender, EventArgs e)
        {
            txtMessages.Text = "Payment Started !";
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
            bt_Start.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_ItemCount.Text = FrmSalesMain.iTotalItems.ToString("0");
            txt_SubTotal.Text = FrmSalesMain.iSubTotal.ToString("C2");
            txt_TaxTotal.Text = FrmSalesMain.iTaxTotal.ToString("C2");
            txt_TotalDue.Text = FrmSalesMain.iTotalDue.ToString("C2");
        }

        private void txt_SubTotal_TextChanged(object sender, EventArgs e)
        {
            util.Logger("Total has changed : " + txt_SubTotal.Text);
            Load_Existing_Orders();
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
            this.dgv_Orders.ColumnCount = 5;
            this.dgv_Orders.Columns[0].Name = "Seq";
            this.dgv_Orders.Columns[0].Width = 50;
            this.dgv_Orders.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Orders.Columns[1].Name = "Product Name";
            this.dgv_Orders.Columns[1].Width = 110;
            this.dgv_Orders.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgv_Orders.Columns[2].Name = "QTY";
            this.dgv_Orders.Columns[2].Width = 50;
            this.dgv_Orders.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_Orders.Columns[3].Name = "Unit Price";
            this.dgv_Orders.Columns[3].Width = 70;
            this.dgv_Orders.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_Orders.Columns[4].Name = "Amount";
            this.dgv_Orders.Columns[4].Width = 85;
            this.dgv_Orders.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgv_Orders.Columns[5].Name = "OrderId";
            //this.dgv_Orders.Columns[5].Width = 0;
            //this.dgv_Orders.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgv_Orders.DefaultCellStyle.Font = new Font("Arial Narrow", 14F, FontStyle.Bold);
            this.dgv_Orders.EnableHeadersVisualStyles = false;
            this.dgv_Orders.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.dgv_Orders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Orders.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgv_Orders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv_Orders.AllowUserToResizeRows = false;
            dgv_Orders.RowTemplate.Resizable = DataGridViewTriState.True;
            dgv_Orders.RowTemplate.MinimumHeight = 50;
            dgv_Orders.AllowUserToAddRows = false;
        }
        private void Load_Existing_Orders()
        {
            int iIndex = 0;

            dgv_Orders_Initialize();
            DataAccessPOS dbPOS = new DataAccessPOS();
            orders = dbPOS.Get_Orders_by_Station(FrmSalesMain.strStation);
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
                        this.dgv_Orders.Rows.Add(new String[] { order.ProductId.ToString(),
                                                                                   order.ProductName,
                                                                                   order.Quantity.ToString(),
                                                                                   order.OutUnitPrice.ToString("0.00"),
                                                                                   iAmount.ToString("0.00")
                                });
                    }
                    else if (order.OrderCategoryId > 0) // Discount
                    {
                        iAmount = order.Amount;
                        this.dgv_Orders.Rows.Add(new String[] { order.ProductId.ToString(),
                                                                                   order.ProductName,
                                                                                   order.Quantity.ToString(),
                                                                                   order.Amount.ToString("0.00"),
                                                                                   iAmount.ToString("0.00")
                                });
                    }
                    if (order.RFTagId > 0)
                    {
                        this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = order.RFTagId;
                        DataGridViewRow row = this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1];
                        row.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        this.dgv_Orders.Rows[this.dgv_Orders.RowCount - 1].Tag = null;
                    }
                    this.dgv_Orders.FirstDisplayedScrollingRowIndex = dgv_Orders.RowCount - 1;
                    //this.dgv_Orders.FirstDisplayedScrollingRowIndex = Get_OrderedItem_Index_of_GridView(order.RFTagId);
                    //this.dgv_Orders.Rows[Get_OrderedItem_Index_of_GridView(order.RFTagId)].Selected = true;
                    // this.dgv_Orders.Rows[dgv_Orders.RowCount - 1].Selected = true;
                }
            }
            this.dgv_Orders.ClearSelection();
        }
    }
}
