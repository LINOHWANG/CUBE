using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SDCafeCommon.Utilities;
using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;

namespace SDCafeSales.Views
{
    public partial class frmCashPayment : Form
    {
        frmSalesMain FrmSalesMain;
        Utility util = new Utility();

        //float p_TenderAmt;
        //float p_TipAmt;
        int p_InvoiceNo;
        string p_Station;
        string p_UserName;
        string strCashAmount = "";
        //Feature #1552
        string strTipAmount = "";
        float fCashAmount = 0;
        List<POS_StationModel> stations = new List<POS_StationModel>();
        public Boolean bPaymentComplete;
        //Feature #1552
        public Boolean bAddTip;
        public string strPaymentType { get; set; }

        public float p_TipAmt { get; set; }

        public float p_TenderAmt { get; set; }

        public float p_CashAmt { get; set; }

        public float p_ChangeAmt { get; set; }

        public frmCashPayment(frmSalesMain _FrmSalesMain)
        {
            InitializeComponent();
            this.FrmSalesMain = _FrmSalesMain;
        }
        public void Set_TenderAmt(double pTenderAmt)
        {
            p_TenderAmt = (float)pTenderAmt;
            txt_TotalDue.Text = pTenderAmt.ToString("C2");
        }
        public void Set_InvoiceNo(int pInvoiceNo)
        {
            p_InvoiceNo = pInvoiceNo;
            lblInvoiceNo.Text = "Invoice # : " + p_InvoiceNo.ToString("D6");
        }
        public void Set_Station(string pStation)
        {
            p_Station = pStation;
            lblStation.Text = "Station # : " + pStation;
        }
        public void Set_UserName(string pUserName)
        {
            p_UserName = pUserName;
            lblUerName.Text = "Served by : " + pUserName;
        }
        //public Boolean bPaymentComplete { get; private set; }
        private void frmCashPayment_Load(object sender, EventArgs e)
        {
            bPaymentComplete = false;
            bAddTip = false;

            fCashAmount = 0;
            p_CashAmt = 0;
            p_ChangeAmt = 0;

            strPaymentType = "";
            strCashAmount = "";
            strTipAmount = "";

            p_TipAmt = 0;
            timer1.Interval = 2000;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            if (bPaymentComplete)
            {
                util.Logger("frmCashPayment Exiting ... with PaymentComplete");
            }
            this.Close();
            //Application.ExitThread();
            //Application.Exit();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            //util.Logger("------------------ Card Transaction timer invoked ------------------" + bPaymentComplete);

        }


        private void bt_PayCash_Click(object sender, EventArgs e)
        {
            util.Logger("Cash Payment Cash Amount : " + p_CashAmt);
            util.Logger("Cash Payment Change Amount : " + p_ChangeAmt);
            // Set amount info to frmMain
            if (p_CashAmt >= p_TenderAmt)
            {
                strPaymentType = "Cash";
                bPaymentComplete = true;
                bt_Exit.PerformClick();
            }
            else
            {
                bPaymentComplete = false;
                MessageBox.Show("Please check Cash Amount ! ");
            }
        }
        private void CashAmountUpdate()
        {
            // ------------- Cash Amount ---------------------
            if (strCashAmount.Length < 3)
            {
                strCashAmount = "0." + strCashAmount;
            }
            else if (strCashAmount.Length == 4)
            {
                // Do nothing
            }
            else
            {
                strCashAmount = strCashAmount.Replace(".", "");
                if (strCashAmount.Substring(0,1)=="0")
                {
                    strCashAmount = strCashAmount.Substring(1);
                }
                strCashAmount = strCashAmount.Substring(0, strCashAmount.Length - 2) + "." + strCashAmount.Substring(strCashAmount.Length - 2, 2);
            }
            
            lblTest.Text = strCashAmount;
            p_CashAmt = float.Parse(strCashAmount);
            txt_CashAmount.Text = p_CashAmt.ToString("C2");

            // ------------- Tip ---------------------
            //Feature #1552
            if (bAddTip)
            {
                if (strTipAmount.Length < 3)
                {
                    strTipAmount = "0." + strTipAmount;
                }
                else if (strTipAmount.Length == 4)
                {
                    // Do nothing
                }
                else
                {
                    strTipAmount = strTipAmount.Replace(".", "");
                    if (strTipAmount.Substring(0, 1) == "0")
                    {
                        strTipAmount = strTipAmount.Substring(1);
                    }
                    strTipAmount = strTipAmount.Substring(0, strTipAmount.Length - 2) + "." + strTipAmount.Substring(strTipAmount.Length - 2, 2);
                }

                p_TipAmt = float.Parse(strTipAmount);
                txt_TipAmount.Text = p_TipAmt.ToString("C2");
            }

            p_ChangeAmt = p_TenderAmt - p_CashAmt + p_TipAmt;
            txt_Changes.Text = p_ChangeAmt.ToString("C2");
        }
        private void btNum1_Click(object sender, EventArgs e)
        {
            //Feature #1552
            if (bAddTip)
            {
                strTipAmount = strTipAmount + btNum1.Text;
            }   
            else
            {
                strCashAmount = strCashAmount + btNum1.Text;
            }
            CashAmountUpdate();
        }

        private void btNum2_Click(object sender, EventArgs e)
        {
            //Feature #1552
            if (bAddTip)
            {
                strTipAmount = strTipAmount + btNum2.Text;
            }
            else
            {
                strCashAmount = strCashAmount + btNum2.Text;
            }
            CashAmountUpdate();
        }

        private void btNum3_Click(object sender, EventArgs e)
        {
            //Feature #1552
            if (bAddTip)
            {
                strTipAmount = strTipAmount + btNum3.Text;
            }
            else
            {
                strCashAmount = strCashAmount + btNum3.Text;
            }
            CashAmountUpdate();
        }

        private void btNum4_Click(object sender, EventArgs e)
        {
            //Feature #1552
            if (bAddTip)
            {
                strTipAmount = strTipAmount + btNum4.Text;
            }
            else
            {
                strCashAmount = strCashAmount + btNum4.Text;
            }
            CashAmountUpdate();
        }

        private void btNum5_Click(object sender, EventArgs e)
        {
            //Feature #1552
            if (bAddTip)
            {
                strTipAmount = strTipAmount + btNum5.Text;
            }
            else
            {
                strCashAmount = strCashAmount + btNum5.Text;
            }
            CashAmountUpdate();
        }

        private void btNum6_Click(object sender, EventArgs e)
        {
            //Feature #1552
            if (bAddTip)
            {
                strTipAmount = strTipAmount + btNum6.Text;
            }
            else
            {
                strCashAmount = strCashAmount + btNum6.Text;
            }
            CashAmountUpdate();
        }

        private void btNum7_Click(object sender, EventArgs e)
        {
            //Feature #1552
            if (bAddTip)
            {
                strTipAmount = strTipAmount + btNum7.Text;
            }
            else
            {
                strCashAmount = strCashAmount + btNum7.Text;
            }
            CashAmountUpdate();
        }

        private void btNum8_Click(object sender, EventArgs e)
        {
            //Feature #1552
            if (bAddTip)
            {
                strTipAmount = strTipAmount + btNum8.Text;
            }
            else
            {
                strCashAmount = strCashAmount + btNum8.Text;
            }
            CashAmountUpdate();
        }

        private void btNum9_Click(object sender, EventArgs e)
        {
            //Feature #1552
            if (bAddTip)
            {
                strTipAmount = strTipAmount + btNum8.Text;
            }
            else
            {
                strCashAmount = strCashAmount + btNum9.Text;
            }
            CashAmountUpdate();
        }

        private void btNum0_Click(object sender, EventArgs e)
        {
            //Feature #1552
            if (bAddTip)
            {
                strTipAmount = strTipAmount + btNum0.Text;
            }
            else
            {
                strCashAmount = strCashAmount + btNum0.Text;
            }
            CashAmountUpdate();
        }

        private void btNumReset_Click(object sender, EventArgs e)
        {

            strCashAmount = "0";
            strTipAmount = "0";

            bAddTip = true;

            CashAmountUpdate();

            bAddTip = false;

            txt_TipAmount.BackColor = Color.LightSalmon;
        }

        private void btNumSame_Click(object sender, EventArgs e)
        {
            strCashAmount = p_TenderAmt.ToString("F2");
            CashAmountUpdate();
        }

        private void bt_5_Click(object sender, EventArgs e)
        {
            strCashAmount = "5.00";
            CashAmountUpdate();
        }

        private void bt_10_Click(object sender, EventArgs e)
        {
            strCashAmount = "10.00";
            CashAmountUpdate();
        }

        private void bt_20_Click(object sender, EventArgs e)
        {
            strCashAmount = "20.00";
            CashAmountUpdate();
        }

        private void bt_50_Click(object sender, EventArgs e)
        {
            strCashAmount = "50.00";
            CashAmountUpdate();
        }

        private void bt_100_Click(object sender, EventArgs e)
        {
            strCashAmount = "100.00";
            CashAmountUpdate();
        }

        private void frmCashPayment_Activated(object sender, EventArgs e)
        {
            // Center the form on 1st Monitor
            
            util.Logger("frmCashPayment is now Activated !");
            // Set from start position to Manual
            this.StartPosition = FormStartPosition.Manual; //FormStartPosition.CenterScreen;
            // Get the Primary monitor screen
            Screen screen = GetPrimaryScreen();
            // Set the location to Primary screen
            this.Location = screen.WorkingArea.Location;
            this.CenterToScreen();
            // Set from start position to Center
        }
        public Screen GetPrimaryScreen()
        {
            //if (Screen.AllScreens.Length == 1)
            //{
            //    return null;
            //}

            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Primary == true)
                {
                    return screen;
                }
            }

            return null;
        }

        private void bt_PayDebit_Click(object sender, EventArgs e)
        {
            util.Logger("Manual Debit Payment Amount : " + p_CashAmt);
            util.Logger("Manual Debit Payment Change Amount : " + p_ChangeAmt);
            // Set amount info to frmMain
            if (p_CashAmt >= p_TenderAmt)
            {
                strPaymentType = "Debit";
                bPaymentComplete = true;
                bt_Exit.PerformClick();
            }
            else
            {
                bPaymentComplete = false;
                MessageBox.Show("Please check Amount ! ");
            }

        }

        private void bt_PayVisa_Click(object sender, EventArgs e)
        {
            util.Logger("Manual Visa Payment Amount : " + p_CashAmt);
            util.Logger("Manual Visa Payment Change Amount : " + p_ChangeAmt);
            // Set amount info to frmMain
            if (p_CashAmt >= p_TenderAmt)
            {
                strPaymentType = "Visa";
                bPaymentComplete = true;
                bt_Exit.PerformClick();
            }
            else
            {
                bPaymentComplete = false;
                MessageBox.Show("Please check Amount ! ");
            }
        }

        private void bt_PayMaster_Click(object sender, EventArgs e)
        {
            util.Logger("Manual Master Payment Amount : " + p_CashAmt);
            util.Logger("Manual Master Payment Change Amount : " + p_ChangeAmt);
            // Set amount info to frmMain
            if (p_CashAmt >= p_TenderAmt)
            {
                strPaymentType = "Master";
                bPaymentComplete = true;
                bt_Exit.PerformClick();
            }
            else
            {
                bPaymentComplete = false;
                MessageBox.Show("Please check Amount ! ");
            }
        }

        private void bt_PayAmex_Click(object sender, EventArgs e)
        {
            util.Logger("Manual Amex Payment Amount : " + p_CashAmt);
            util.Logger("Manual Amex Payment Change Amount : " + p_ChangeAmt);
            // Set amount info to frmMain
            if (p_CashAmt >= p_TenderAmt)
            {
                strPaymentType = "Amex";
                bPaymentComplete = true;
                bt_Exit.PerformClick();
            }
            else
            {
                bPaymentComplete = false;
                MessageBox.Show("Please check Amount ! ");
            }
        }

        private void txt_TipAmount_Click(object sender, EventArgs e)
        {
            //Feature #1552
            txt_TipAmount.BackColor = Color.Yellow;
            bAddTip = true;
        }

        private void bt_ChangesToTip_Click(object sender, EventArgs e)
        {
            //Feature #1552
            bAddTip = true;
            p_TipAmt = -p_ChangeAmt;
            strTipAmount = p_TipAmt.ToString("F2");
            CashAmountUpdate();
            bAddTip = false;
        }
    }
    /// <summary>
    /// Server receive state
    /// </summary>
}
