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

        const string ESC = "\u001B";
        const string p = "\u0070";
        const string m = "\u0000";
        const string t1 = "\u0025";
        const string t2 = "\u0250";
        const string openTillCommand = ESC + p + m + t1 + t2;

        //float p_TenderAmt;
        //float p_TipAmt;
        int p_InvoiceNo;
        string p_Station;
        string p_UserName;
        string strCashAmount = "";
        //Feature #1552
        string strTipAmount = "";
        private float fCashAmount = 0;
        List<POS_StationModel> stations = new List<POS_StationModel>();
        List<POS_SysConfigModel> sysConfigs = new List<POS_SysConfigModel>();
        public Boolean bPaymentComplete;
        //Feature #1552
        public Boolean bAddTip;
        public string strPaymentType { get; set; }

        public float m_fCashDue;
        public float m_fCashRounding { get; set; }
        public float p_TipAmt { get; set; }

        public float p_TenderAmt { get; set; }

        public float p_CashAmt { get; set; }

        public float p_ChequeAmt { get; set; }
        public float p_ChargeAmt { get; set; }

        public float p_ChangeAmt { get; set; }

        public float p_TotalAmount { get; set; }
        public float p_DebitAmt { get; set; }
        public float p_VisaAmt { get; set; }
        public float p_MasterAmt { get; set; }
        public float p_AmexAmt { get; set; }
        public float p_OthersAmt { get; set; }

        public frmCardPayment FrmCardPay;

        private float fUSDRate;
        private float fUSDCashMarkupRate;
        private bool bUSDEnable;
        private float p_CashAmtUSD;
        private float m_fEnterChequeAmt;

        public frmCashPayment(frmSalesMain _FrmSalesMain)
        {
            InitializeComponent();
            lbl_ConvRate.Visible = false;
            this.FrmSalesMain = _FrmSalesMain;
            bUSDEnable = false;
        }
        public void Set_TenderAmt(double pTenderAmt)
        {
            p_TenderAmt = (float)pTenderAmt;
            txt_TotalDue.Text = pTenderAmt.ToString("C2");

            // Rounding for Cash Payment
            m_fCashDue = (float)(Math.Round((p_TenderAmt / 0.05)) * 0.05);
            m_fCashRounding = (float)Math.Round(m_fCashDue - p_TenderAmt, 2);
            util.Logger("frmCashPayment Loading ... Rounding ? " + m_fCashRounding.ToString());
            txt_CashDue.Text = m_fCashDue.ToString("C2");
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
            p_DebitAmt = 0;
            p_VisaAmt = 0;
            p_MasterAmt = 0;
            p_AmexAmt = 0;
            p_OthersAmt = 0;
            p_ChequeAmt = 0;
            p_ChargeAmt = 0;

            strPaymentType = "";
            strCashAmount = "";
            strTipAmount = "";

            p_TipAmt = 0;

            m_fEnterChequeAmt = 0;

            timer1.Interval = 2000;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            strPaymentType = strPaymentType.ToUpper();
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
            util.Logger("Cash Payment Rounding Amount : " + m_fCashRounding);


            // Set amount info to frmMain
            if (p_CashAmt >= p_TenderAmt)
            {
                // Exact Cash Amount Payment
                strPaymentType = "CASH";
                bPaymentComplete = true;
                bt_Exit.PerformClick();
            }
            else
            {
                // Exact Cash Amount Payment
                if (p_CashAmt == 0)
                {
                    strPaymentType = "CASH";
                    //p_CashAmt = p_TenderAmt;
                    p_CashAmt = m_fCashDue;
                    bPaymentComplete = true;
                    bt_Exit.PerformClick();
                    return;
                }
                p_TotalAmount = (float)Math.Round((double)(p_CashAmt + p_ChequeAmt + p_ChargeAmt + p_DebitAmt + p_VisaAmt + p_MasterAmt + p_AmexAmt),2);
                util.Logger("Multi tender : p_TotalAmount = " + p_TotalAmount.ToString() + " vs p_TenderAmt = " + p_TenderAmt.ToString());
                if (p_TotalAmount >= p_TenderAmt)
                {
                    //strPaymentType = "Cash/Debit";
                    bPaymentComplete = true;
                    bt_Exit.PerformClick();
                }
                else
                {
                    // DONE button is pressed as Multi Tendering
                    bPaymentComplete = true;
                    //MessageBox.Show("Please check Cash Amount ! ");
                    bt_PayCash.Text = "DONE";
                    strPaymentType = "Multi";
                    lblPartialPay.Text = "Multi Tendering";
                    lblPartialPay.Visible = true;
                    labelTipOrCard.Text = "Card :";
                    txt_CardAmount.Visible = true;
                    txt_TipAmount.Visible = false;
                    txt_CardAmount.Top = txt_TipAmount.Top;
                    txt_CardAmount.Left = txt_TipAmount.Left;
                    bt_Exit.PerformClick();
                }
            }
        }
        private void bt_PayCheque_Click(object sender, EventArgs e)
        {
            util.Logger("Cheque Payment Cheque Amount : " + p_ChequeAmt);
            util.Logger("Cheque Payment Change Amount : " + p_ChangeAmt);
            util.Logger("Cheque Payment Rounding Amount : " + m_fCashRounding);

            using (var FrmEnterAmount = new frmEnterAmount(this.FrmSalesMain))
            {
                this.TopMost = false;
                FrmEnterAmount.p_Title = "Please Confirm Cheque Amount !";
                FrmEnterAmount.StartPosition = FormStartPosition.CenterScreen;
                //if (trancolSelected != null)
                if (p_TenderAmt > 0)
                {
                    FrmEnterAmount.p_TenderAmt = p_TenderAmt; // trancolSelected.TotalPaid;
                }
                else
                {
                    return;
                }
                FrmEnterAmount.TopLevel = true;
                FrmEnterAmount.ShowDialog();
                this.TopMost = true;
                m_fEnterChequeAmt = FrmEnterAmount.p_NewAmt;
            }

            // Set amount info to frmMain
            if (p_ChequeAmt >= p_TenderAmt)
            {
                // Exact Cheque Amount Payment
                strPaymentType = "CHEQUE";
                bPaymentComplete = true;
                bt_Exit.PerformClick();
            }
            else
            {
                // Exact Cheque Amount Payment
                p_ChequeAmt = m_fEnterChequeAmt;
                //p_TotalAmount = p_CashAmt + p_ChequeAmt + p_ChargeAmt + p_DebitAmt + p_VisaAmt + p_MasterAmt + p_AmexAmt;
                p_TotalAmount = (float)Math.Round((double)(p_CashAmt + p_ChequeAmt + p_ChargeAmt + p_DebitAmt + p_VisaAmt + p_MasterAmt + p_AmexAmt), 2);
                if (p_CashAmt == 0)
                {
                    strPaymentType = "CHEQUE";
                    //p_ChequeAmt = p_TenderAmt;
                    m_fCashRounding = 0;
                    p_ChangeAmt = p_TenderAmt - p_TotalAmount;
                    bPaymentComplete = true;
                    bt_Exit.PerformClick();
                    return;
                }
                strPaymentType = "MULTI";
                if (p_TotalAmount >= p_TenderAmt)
                {
                    m_fCashRounding = 0;
                    p_ChangeAmt = p_TenderAmt - p_TotalAmount;
                    bPaymentComplete = true;
                    bt_Exit.PerformClick();
                }
                else
                {
                    /*p_ChequeAmt = p_ChangeAmt - m_fCashRounding;
                    m_fCashRounding = 0;
                    p_ChangeAmt = p_TenderAmt - p_TotalAmount;
                    bPaymentComplete = true;
                    bt_Exit.PerformClick();
                    return;
                    */
                    strPaymentType = "MULTI";
                    labelTipOrCard.Text = "Cheque :";
                    p_ChequeAmt = p_ChangeAmt; // - m_fCashRounding;
                    m_fCashRounding = 0;
                    p_ChangeAmt = p_TenderAmt - p_TotalAmount;
                    txt_Changes.Text = p_ChangeAmt.ToString("C2");
                    txt_CardAmount.Text = p_ChequeAmt.ToString("C2");
                    bt_IPSPayment.Visible = false;
                    bt_PayCash.Text = "DONE";
                    Disable_Card_Buttons();
                }
            }
        }

        private void bt_PayCharge_Click(object sender, EventArgs e)
        {
            util.Logger("Charge Payment Charge Amount : " + p_ChargeAmt);
            util.Logger("Charge Payment Change Amount : " + p_ChangeAmt);
            //util.Logger("Charge Payment Rounding Amount : " + m_fChargeRounding);


            // Set amount info to frmMain
            if (p_ChargeAmt >= p_TenderAmt)
            {
                // Exact Charge Amount Payment
                strPaymentType = "CHARGE";
                bPaymentComplete = true;
                bt_Exit.PerformClick();
            }
            else
            {
                // Exact Charge Amount Payment
                if (p_CashAmt == 0)
                {
                    strPaymentType = "CHARGE";
                    //p_ChargeAmt = p_TenderAmt;
                    p_ChargeAmt = p_TenderAmt;
                    bPaymentComplete = true;
                    bt_Exit.PerformClick();
                    return;
                }
                //p_TotalAmount = p_CashAmt + p_ChequeAmt + p_ChargeAmt + p_DebitAmt + p_VisaAmt + p_MasterAmt + p_AmexAmt;
                p_TotalAmount = (float)Math.Round((double)(p_CashAmt + p_ChequeAmt + p_ChargeAmt + p_DebitAmt + p_VisaAmt + p_MasterAmt + p_AmexAmt), 2);

                if (p_TotalAmount >= p_TenderAmt)
                {
                    //strPaymentType = "Charge/Debit";
                    bPaymentComplete = true;
                    bt_Exit.PerformClick();
                }
                else
                {
                    /*
                    p_ChargeAmt = p_ChangeAmt - m_fCashRounding;
                    m_fCashRounding = 0;
                    p_ChangeAmt = 0;
                    strPaymentType = "MULTI";
                    bPaymentComplete = true;
                    bt_Exit.PerformClick();
                    return;
                    */
                    strPaymentType = "MULTI";
                    labelTipOrCard.Text = "Charge :";
                    p_ChargeAmt = p_ChangeAmt; // - m_fCashRounding;
                    m_fCashRounding = 0;
                    p_ChangeAmt = 0;
                    txt_Changes.Text = p_ChangeAmt.ToString("C2");
                    txt_CardAmount.Text = p_ChargeAmt.ToString("C2");
                    bt_IPSPayment.Visible = false;
                    bt_PayCash.Text = "DONE";
                    Disable_Card_Buttons();
                }
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
            lblPartialPay.Text = strCashAmount;
            string strTemp = strCashAmount.Replace("$", "");
            if (bUSDEnable)
            {
                p_CashAmtUSD = float.Parse(strTemp);
                p_CashAmt = p_CashAmtUSD / fUSDRate;
                txt_CashAmountUSD.Text = p_CashAmtUSD.ToString("C2");
                txt_CashAmount.Text = p_CashAmt.ToString("C2");
            }
            else
            {
                p_CashAmt = float.Parse(strTemp);
                txt_CashAmount.Text = p_CashAmt.ToString("C2");
            }

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

            //p_ChangeAmt = p_TenderAmt - p_CashAmt + p_TipAmt;
            p_ChangeAmt = m_fCashDue - p_CashAmt + p_TipAmt;

            //Feature #2904 ---------------------------------------
            if (p_ChangeAmt <= 0)
            {
                lbl_Changes.Text = "Changes :";
                lbl_Short.Visible = false;
                bt_PayCash.Enabled = true;
                bt_PayCheque.Enabled = false;
                bt_PayCharge.Enabled = false;
                bt_PayDebit.Enabled = false;
                bt_PayVisa.Enabled = false;
                bt_PayMaster.Enabled = false;
                bt_PayAmex.Enabled = false;
            }
            else
            {
                lbl_Changes.Text = "Need more :";
                lbl_Short.Visible = true;
                bt_PayCash.Enabled = false;
                bt_PayCheque.Enabled = true;
                bt_PayCharge.Enabled = true;
                bt_PayDebit.Enabled = true;
                bt_PayVisa.Enabled = true;
                bt_PayMaster.Enabled = true;
                bt_PayAmex.Enabled = true;
            }
            //Feature #2904 ---------------------------------------
            if (p_ChangeAmt != 0)
            {
                if ((p_CashAmt > 0) && (p_CashAmt < p_TenderAmt))
                {
                    p_ChangeAmt = p_TenderAmt - p_CashAmt + p_TipAmt;
                }
                else
                {
                    p_ChangeAmt = m_fCashDue - p_CashAmt + p_TipAmt;
                }
                bt_IPSPayment.Visible = true;
            }
            else
            {
                bt_IPSPayment.Visible = false;
            }
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
            txt_CardAmount.Text = "$0.00";
            //txt_CardAmount.Visible = false;
            p_CashAmt = 0;
            p_DebitAmt = 0;
            p_VisaAmt = 0;
            p_MasterAmt = 0;
            p_AmexAmt = 0;
            p_ChangeAmt = 0;

            bAddTip = true;

            CashAmountUpdate();

            bAddTip = false;

            txt_TipAmount.BackColor = Color.LightSalmon;
            bt_IPSPayment.Visible = false;
            
            Enable_Card_Buttons();

            bUSDEnable = false;
        }

        private void btNumSame_Click(object sender, EventArgs e)
        {
            strCashAmount = p_TenderAmt.ToString("F2");
            p_CashAmt = p_TenderAmt;
            CashAmountUpdate();
        }

        private void bt_5_Click(object sender, EventArgs e)
        {
            if (p_CashAmt > 0)
            {
                if (bUSDEnable)
                {
                    p_CashAmt = p_CashAmtUSD + 5;
                }
                else
                {
                    p_CashAmt = p_CashAmt + 5;
                }
                strCashAmount = p_CashAmt.ToString("C2");
            }
            else
            {
                strCashAmount = "5.00";
                p_CashAmt = 5;
            }
            CashAmountUpdate();
        }

        private void bt_10_Click(object sender, EventArgs e)
        {
            //strCashAmount = "10.00";
            if (p_CashAmt > 0)
            {
                if (bUSDEnable)
                {
                    p_CashAmt = p_CashAmtUSD + 10;
                }
                else
                {
                    p_CashAmt = p_CashAmt + 10;
                }
                strCashAmount = p_CashAmt.ToString("C2");
            }
            else
            {
                strCashAmount = "10.00";
                p_CashAmt = 10;
            }
            CashAmountUpdate();
        }

        private void bt_20_Click(object sender, EventArgs e)
        {
            //strCashAmount = "20.00";
            if (p_CashAmt > 0)
            {
                if (bUSDEnable)
                {
                    p_CashAmt = p_CashAmtUSD + 20;
                }
                else
                {
                    p_CashAmt = p_CashAmt + 20;
                }
                strCashAmount = p_CashAmt.ToString("C2");
            }
            else
            {
                strCashAmount = "20.00";
                p_CashAmt = 20;
            }
            CashAmountUpdate();
        }

        private void bt_50_Click(object sender, EventArgs e)
        {
            //strCashAmount = "50.00";
            if (p_CashAmt > 0)
            {
                if (bUSDEnable)
                {
                    p_CashAmt = p_CashAmtUSD + 50;
                }
                else
                {
                    p_CashAmt = p_CashAmt + 50;
                }
                strCashAmount = p_CashAmt.ToString("C2");
            }
            else
            {
                strCashAmount = "50.00";
                p_CashAmt = 50;
            }
            CashAmountUpdate();
        }

        private void bt_100_Click(object sender, EventArgs e)
        {
            //strCashAmount = "100.00";
            if (p_CashAmt > 0)
            {
                if (bUSDEnable)
                {
                    p_CashAmt = p_CashAmtUSD + 100;
                }
                else
                {
                    p_CashAmt = p_CashAmt + 100;
                }
                strCashAmount = p_CashAmt.ToString("C2");
            }
            else
            {
                strCashAmount = "100.00";
                p_CashAmt = 100;
            }
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
        private void Disable_Card_Buttons()
        {
            bt_PayCash.Enabled = true;
            bt_PayDebit.Enabled = false;
            bt_PayVisa.Enabled = false;
            bt_PayMaster.Enabled = false;
            bt_PayAmex.Enabled = false;
        }
        private void Enable_Card_Buttons()
        {
            bt_PayCash.Enabled = true;
            bt_PayDebit.Enabled = true;
            bt_PayVisa.Enabled = true;
            bt_PayMaster.Enabled = true;
            bt_PayAmex.Enabled = true;
        }
        private void bt_PayDebit_Click(object sender, EventArgs e)
        {
            util.Logger("Manual Debit Payment Amount : " + p_CashAmt);
            util.Logger("Manual Debit Payment Change Amount : " + p_ChangeAmt);
            // Set amount info to frmMain
            if (p_CashAmt >= p_TenderAmt)
            {
                strPaymentType = "Debit";
                p_DebitAmt = p_TenderAmt;
                bPaymentComplete = true;
                bt_Exit.PerformClick();
            }
            else
            {
                if (p_CashAmt == 0)
                {
                    strPaymentType = "Debit";
                    p_DebitAmt = p_TenderAmt;
                    bPaymentComplete = true;
                    bt_Exit.PerformClick();
                }
                else
                {
                    bPaymentComplete = false;
                    //MessageBox.Show("Please check Amount ! ");
                    strPaymentType = "MULTI";
                    labelTipOrCard.Text = "Debit :";
                    p_DebitAmt = p_ChangeAmt; // - m_fCashRounding;
                    p_ChangeAmt = 0;
                    txt_Changes.Text = p_ChangeAmt.ToString("C2");
                    txt_CardAmount.Text = p_DebitAmt.ToString("C2");
                    bt_IPSPayment.Visible = false;
                    bt_PayCash.Text = "DONE";
                    Disable_Card_Buttons();
                }
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
                p_VisaAmt = p_TenderAmt;
                bPaymentComplete = true;
                bt_Exit.PerformClick();
            }
            else
            {
                if (p_CashAmt == 0)
                {
                    strPaymentType = "Visa";
                    p_VisaAmt = p_TenderAmt;
                    bPaymentComplete = true;
                    bt_Exit.PerformClick();
                }
                else
                {
                    bPaymentComplete = false;
                    //MessageBox.Show("Please check Amount ! ");
                    strPaymentType = "MULTI";
                    labelTipOrCard.Text = "Visa :";
                    //p_VisaAmt = p_ChangeAmt - m_fCashRounding;
                    p_VisaAmt = p_ChangeAmt;
                    p_ChangeAmt = 0;
                    txt_Changes.Text = p_ChangeAmt.ToString("C2");
                    txt_CardAmount.Text = p_VisaAmt.ToString("C2");
                    bt_IPSPayment.Visible = false;
                    bt_PayCash.Text = "DONE";
                    Disable_Card_Buttons();
                }
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
                p_MasterAmt = p_TenderAmt;
                bPaymentComplete = true;
                bt_Exit.PerformClick();
            }
            else
            {
                if (p_CashAmt == 0)
                {
                    strPaymentType = "Master";
                    p_MasterAmt = p_TenderAmt;
                    bPaymentComplete = true;
                    bt_Exit.PerformClick();
                }
                else
                {
                    bPaymentComplete = false;
                    //MessageBox.Show("Please check Amount ! ");
                    strPaymentType = "MULTI";
                    labelTipOrCard.Text = "Master :";
                    p_MasterAmt = p_ChangeAmt;// - m_fCashRounding;
                    p_ChangeAmt = 0;
                    txt_Changes.Text = p_ChangeAmt.ToString("C2");
                    txt_CardAmount.Text = p_MasterAmt.ToString("C2");
                    bt_IPSPayment.Visible = false;
                    bt_PayCash.Text = "DONE";
                    Disable_Card_Buttons();
                }
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
                p_AmexAmt = p_TenderAmt;
                bPaymentComplete = true;
                bt_Exit.PerformClick();
            }
            else
            {
                if (p_CashAmt == 0)
                {
                    strPaymentType = "Amex";
                    p_AmexAmt = p_TenderAmt;
                    bPaymentComplete = true;
                    bt_Exit.PerformClick();
                }
                else
                {
                    bPaymentComplete = false;
                    //MessageBox.Show("Please check Amount ! ");
                    strPaymentType = "MULTI";
                    labelTipOrCard.Text = "Amex :";
                    p_AmexAmt = p_ChangeAmt; // - m_fCashRounding;
                    p_ChangeAmt = 0;
                    txt_Changes.Text = p_ChangeAmt.ToString("C2");
                    txt_CardAmount.Text = p_AmexAmt.ToString("C2");
                    bt_IPSPayment.Visible = false;
                    bt_PayCash.Text = "DONE";
                    Disable_Card_Buttons();
                }
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

        private void bt_IPSPayment_Click(object sender, EventArgs e)
        {
            /*float fCash = 0;
            float fDebit = 0;
            float fVisa = 0;
            float fMaster = 0;
            float fAmex = 0;*/
            p_DebitAmt = 0;
            p_VisaAmt = 0;
            p_MasterAmt = 0;
            p_AmexAmt = 0;
            p_OthersAmt = 0;
            util.Logger("bt_IPSPayment_Click start !" + p_InvoiceNo.ToString());

            using (var FrmCardPay = new frmCardPayment(this.FrmSalesMain))
            {
                FrmCardPay.Set_TenderAmt(p_ChangeAmt);
                FrmCardPay.Set_InvoiceNo(p_InvoiceNo);// iNewInvNo);
                FrmCardPay.Set_Station(p_Station); // strStation);
                FrmCardPay.Set_UserName(p_UserName); // strUserName);
                FrmCardPay.p_strTranType = "Purchase";
                FrmCardPay.ShowDialog();

                //strPaymentType = "Cash";
                bPaymentComplete = FrmCardPay.bPaymentComplete;
                //bCashPayment = FrmCardPay.bCashPayment;

                if (FrmCardPay.bPaymentComplete)
                {
                    util.Logger("Card Payment completed !" + FrmCardPay.strPaymentType);
                    // Move Orders to OrderComplete
                    // Add collection table
                    p_ChangeAmt = 0;
                    switch (FrmCardPay.strPaymentType)
                    {
                        case "Cash":
                        case "CASH":
                            //fCash = FrmCardPay.p_TenderAmt;
                            break;
                        case "Debit":
                        case "DEBIT":
                            p_DebitAmt = FrmCardPay.p_TenderAmt;
                            strPaymentType = "DEBIT";
                            break;
                        case "Visa":
                        case "VISA":
                            p_VisaAmt = FrmCardPay.p_TenderAmt;
                            strPaymentType = "VISA";
                            break;
                        case "Master": case "MasterCard": case "M/C":
                        case "MASTER":
                        case "MASTERCARD":
                            p_MasterAmt = FrmCardPay.p_TenderAmt;
                            strPaymentType = "MASTER";
                            break;
                        case "Amex":
                        case "AMEX":
                            p_AmexAmt = FrmCardPay.p_TenderAmt; 
                            strPaymentType = "AMEX";
                            break;
                        default:
                            p_OthersAmt = FrmCardPay.p_TenderAmt;
                            strPaymentType = FrmCardPay.strPaymentType;
                            util.Logger("Unknown Card Type !" + FrmCardPay.strPaymentType);
                            break;
                    }
                    if ((p_CashAmt > 0) && FrmCardPay.bPaymentComplete)
                        strPaymentType = "MULTI";

                    bt_Exit.PerformClick();
                }
                else
                {
                    //txtSelectedMenu.Text = "######### Payment is not yet completed : Invoice# " + iNewInvNo.ToString();
                    util.Logger("Payment is not done yet!");

                }
            }
        }

        private void bt_ShowUSD_Click(object sender, EventArgs e)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            List<POS_SysConfigModel> sysConfigsCashMarkup = dbPOS.Get_SysConfig_By_Name("CADUSD_CASH_MARKUP_RATE");
            sysConfigs = dbPOS.Get_SysConfig_By_Name("CADUSD_CONVERSION_RATE");
            util.Logger("CADUSD_CONVERSION_RATE Count = " + sysConfigs.Count.ToString());
            bUSDEnable = false;
            string strUSDRate = "";
            string strCashMarkupRate = "";
            if (sysConfigs.Count > 0)
            {
                strUSDRate = sysConfigs[0].ConfigValue.Trim();
                util.Logger("CADUSD_CONVERSION_RATE = " + strUSDRate);
                try
                {
                    //Feature #3654
                    fUSDCashMarkupRate = 0;
                    if (sysConfigsCashMarkup.Count > 0)
                    {
                        strCashMarkupRate = sysConfigsCashMarkup[0].ConfigValue.Trim();
                        util.Logger("CADUSD_CASH_MARKUP_RATE = " + strCashMarkupRate);
                        fUSDCashMarkupRate = 1 + (float)System.Convert.ToDouble(strCashMarkupRate) / 100;
                    }
                    else
                    {
                        strCashMarkupRate = "0";
                        util.Logger("CADUSD_CASH_MARKUP_RATE = Not Set : " + strCashMarkupRate);
                    }

                    fUSDRate = 0;
                    fUSDRate = (float)System.Convert.ToDouble(strUSDRate);
                    fUSDRate = fUSDRate * fUSDCashMarkupRate;
                    fUSDRate = (float)Math.Round(fUSDRate, 4);
                    bUSDEnable = true;
                }
                catch (Exception ex)
                {
                    strUSDRate = "NOT SET";
                }
            }
            else
            {
            }


            lbl_ConvRate.Text = "CAD:USD = 1:" + fUSDRate.ToString();
            lbl_ConvRate.Visible = true;
            float fUSDDueAmount = p_TenderAmt * fUSDRate;
            txt_TotalDueUSD.Text = fUSDDueAmount.ToString("C2");
            if (bUSDEnable)
            {
                txt_CashAmountUSD.Visible = true;
                txt_CashAmountUSD.ForeColor = Color.DarkRed;
                txt_CashAmountUSD.BackColor = Color.LightSalmon;
            }
            else
            {
                txt_CashAmountUSD.Visible = false;
                txt_CashAmountUSD.ForeColor = Color.Black;
                txt_CashAmountUSD.BackColor = Color.LightGreen;
            }
        }

        private void bt_OpenCD_Click(object sender, EventArgs e)
        {
            RawPrinterHelper.SendStringToPrinter("EPSON-1", openTillCommand);
        }


    }
    /// <summary>
    /// Server receive state
    /// </summary>
}
