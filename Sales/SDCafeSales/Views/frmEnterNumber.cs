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
    public partial class frmEnterNumber : Form
    {
        frmSalesMain FrmSalesMain;
        private string m_strNumber;
        public string p_Title { get; set; }
        public string p_strNumber { get; set; }
        public bool p_bIsNumberSet { get; set; }
        public frmEnterNumber(frmSalesMain frmSalesMain)
        {
            InitializeComponent();
            FrmSalesMain = frmSalesMain;
        }
        private void frmEnterNumber_Load(object sender, EventArgs e)
        {
            m_strNumber = "";
            p_strNumber = "";
            p_bIsNumberSet = false;
            lblTitle.Text = p_Title;
        }
        private void bt_Process_Click(object sender, EventArgs e)
        {
            p_strNumber = txt_Number.Text;
            p_bIsNumberSet = true;
            this.Close();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            p_strNumber = "";
            p_bIsNumberSet = false;
            this.Close();
        }
        private void UpdateNumberText()
        {
            txt_Number.Text = m_strNumber;
        }
        private void btNum1_Click(object sender, EventArgs e)
        {
            m_strNumber = m_strNumber + btNum1.Text;
            UpdateNumberText();
        }
        private void btNum2_Click(object sender, EventArgs e)
        {
            m_strNumber = m_strNumber + btNum2.Text;
            UpdateNumberText();
        }

        private void btNum3_Click(object sender, EventArgs e)
        {
            m_strNumber = m_strNumber + btNum3.Text;
            UpdateNumberText();
        }

        private void btNum4_Click(object sender, EventArgs e)
        {
            m_strNumber = m_strNumber + btNum4.Text;
            UpdateNumberText();
        }

        private void btNum5_Click(object sender, EventArgs e)
        {
            m_strNumber = m_strNumber + btNum5.Text;
            UpdateNumberText();
        }

        private void btNum6_Click(object sender, EventArgs e)
        {
            m_strNumber = m_strNumber + btNum6.Text;
            UpdateNumberText();
        }

        private void btNum7_Click(object sender, EventArgs e)
        {
            m_strNumber = m_strNumber + btNum7.Text;
            UpdateNumberText();
        }

        private void btNum8_Click(object sender, EventArgs e)
        {
            m_strNumber = m_strNumber + btNum8.Text;
            UpdateNumberText();
        }

        private void btNum9_Click(object sender, EventArgs e)
        {
            m_strNumber = m_strNumber + btNum9.Text;
            UpdateNumberText();
        }

        private void btNum0_Click(object sender, EventArgs e)
        {
            m_strNumber = m_strNumber + btNum0.Text;
            UpdateNumberText();
        }

        private void btNumDelete_Click(object sender, EventArgs e)
        {
            // Delete the last character
            if (m_strNumber.Length > 0)
            {
                m_strNumber = m_strNumber.Substring(0, m_strNumber.Length - 1);
                UpdateNumberText();
            }
        }

        private void btNumClear_Click(object sender, EventArgs e)
        {
            m_strNumber = "";
            UpdateNumberText();
        }

    }
}
