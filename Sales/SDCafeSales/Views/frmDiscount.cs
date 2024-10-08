using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDCafeSales.Views
{
    public partial class frmDiscount : Form
    {
        frmSalesMain FrmSalesMain;
        public float p_Amount { get; set; }
        public float fAmountDisc = 0;
        public int iDiscountRate = 0;
        public Boolean bSetDiscount;

        public frmDiscount(frmSalesMain _FrmSalesMain)
        {
            InitializeComponent();
            this.FrmSalesMain = _FrmSalesMain;
            iDiscountRate = 0;
            fAmountDisc = 0;
        }
        public void Set_Amount(double pAmount)
        {
            p_Amount = (float)pAmount;
            txt_Amount.Text = pAmount.ToString("C2");
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_05Percent_Click(object sender, EventArgs e)
        {
            iDiscountRate = 5;
            bt_Exit.PerformClick();
        }

        private void bt_10Percent_Click(object sender, EventArgs e)
        {
            iDiscountRate = 10;
            bt_Exit.PerformClick();
        }

        private void bt_20Percent_Click(object sender, EventArgs e)
        {
            iDiscountRate = 20;
            bt_Exit.PerformClick();
        }

        private void bt_30Percent_Click(object sender, EventArgs e)
        {
            iDiscountRate = 30;
            bt_Exit.PerformClick();
        }

        private void bt_50Percent_Click(object sender, EventArgs e)
        {
            iDiscountRate = 50;
            bt_Exit.PerformClick();
        }

        private void bt_100Percent_Click(object sender, EventArgs e)
        {
            iDiscountRate = 100;
            bt_Exit.PerformClick();
        }

        private void bt_15Percent_Click(object sender, EventArgs e)
        {
            iDiscountRate = 15;
            bt_Exit.PerformClick();
        }


        private void txt_AmountDisc_TextChanged(object sender, EventArgs e)
        {
            iDiscountRate = 0;
        }

        private void bt_AmountDiscSet_Click(object sender, EventArgs e)
        {
            fAmountDisc = float.Parse(txt_AmountDisc.Text, CultureInfo.InvariantCulture.NumberFormat);
            if (fAmountDisc > p_Amount)
            {
                MessageBox.Show("Discount should not exceed the Amount!");
                return;
            }
            iDiscountRate = 0;
            bt_Exit.PerformClick();
        }
    }
}
