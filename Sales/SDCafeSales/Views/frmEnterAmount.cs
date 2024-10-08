using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDCafeSales.Views
{
    public partial class frmEnterAmount : Form
    {
        frmSalesMain FrmSalesMain;
        private string m_strAmount;
        public float p_TenderAmt { get; set; }
        public float p_RefundAmt { get; set; }

        public bool p_IsRefund { get; set; }
        public string p_Title { get; set; }

        public frmEnterAmount(frmSalesMain frmSalesMain)
        {
            InitializeComponent();
            FrmSalesMain = frmSalesMain;
        }
        private void frmEnterAmount_Load(object sender, EventArgs e)
        {
            p_IsRefund = false;
            m_strAmount = p_TenderAmt.ToString();
            txt_Amount.Text = m_strAmount;
            // remove . on m_strAmount
            m_strAmount = m_strAmount.Replace(".", "");
            // if debug mode, show the amount on the label

            lblTest.Text = m_strAmount;     
            lblTest.Visible = false;
            lblTitle.Text = p_Title;
        }
        private void bt_Process_Click(object sender, EventArgs e)
        {
            p_IsRefund = true;
            p_RefundAmt = float.Parse(txt_Amount.Text);
            this.Close();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            p_IsRefund = false;
            p_RefundAmt = 0;
            this.Close();
        }
        private void AmountTextUpdate()
        {
            lblTest.Text = m_strAmount;

            if (m_strAmount.Length < 3)
            {
                txt_Amount.Text = "0." + m_strAmount;
                if (m_strAmount.Length == 1) txt_Amount.Text = "0.0" + m_strAmount;
                else if (m_strAmount.Length == 0) txt_Amount.Text = "0.00";
            }
            else
            {
                if (m_strAmount.Substring(0, 1) == "0")
                    m_strAmount = m_strAmount.Substring(1);
                txt_Amount.Text = m_strAmount.Substring(0, m_strAmount.Length - 2) + "." + m_strAmount.Substring(m_strAmount.Length - 2, 2);
            }
        }
        private void btNum1_Click(object sender, EventArgs e)
        {
            m_strAmount = m_strAmount + btNum1.Text;
            AmountTextUpdate();
        }
        private void btNum2_Click(object sender, EventArgs e)
        {
            m_strAmount = m_strAmount + btNum2.Text;
            AmountTextUpdate();

        }

        private void btNum3_Click(object sender, EventArgs e)
        {
            m_strAmount = m_strAmount + btNum3.Text;
            AmountTextUpdate();
        }

        private void btNum4_Click(object sender, EventArgs e)
        {
            m_strAmount = m_strAmount + btNum4.Text;
            AmountTextUpdate();
        }

        private void btNum5_Click(object sender, EventArgs e)
        {
            m_strAmount = m_strAmount + btNum5.Text;
            AmountTextUpdate();
        }

        private void btNum6_Click(object sender, EventArgs e)
        {
            m_strAmount = m_strAmount + btNum6.Text;
            AmountTextUpdate();

        }

        private void btNum7_Click(object sender, EventArgs e)
        {
            m_strAmount = m_strAmount + btNum7.Text;
            AmountTextUpdate();
        }

        private void btNum8_Click(object sender, EventArgs e)
        {
            m_strAmount = m_strAmount + btNum8.Text;
            AmountTextUpdate();
        }

        private void btNum9_Click(object sender, EventArgs e)
        {
            m_strAmount = m_strAmount + btNum9.Text;
            AmountTextUpdate();
        }

        private void btNum0_Click(object sender, EventArgs e)
        {
            m_strAmount = m_strAmount + btNum0.Text;
            AmountTextUpdate();
        }

        private void btNumDelete_Click(object sender, EventArgs e)
        {
            // Delete the last character
            if (m_strAmount.Length > 0)
            {
                m_strAmount = m_strAmount.Substring(0, m_strAmount.Length - 1);
            }
            AmountTextUpdate();
        }

        private void btNumClear_Click(object sender, EventArgs e)
        {
            m_strAmount = "";
            AmountTextUpdate();
        }

    }
}
