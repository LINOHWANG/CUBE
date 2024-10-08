using SDCafeCommon.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDCafeSales.Views
{
    public partial class frmManualPrice : Form
    {
        frmSalesMain FrmSalesMain;

        Utility util = new Utility();
        public CustomButton selectedBTN;
        public String strNewPrice;
        public String strManualName;
        public double dblManualPrice = 0;
        public bool bTax1 = true, bTax2 = false, bTax3 = false;
        public bool bEditNow;
        public float p_Amount { get; set; }
        public string p_PName { get; set; }

        public bool p_IsTax1 { get; set; }
        public bool p_IsTax2 { get; set; }
        public bool p_IsTax3 { get; set; }

        public Color[] btColor =
{
            Color.Crimson,
            Color.SeaGreen,
            Color.DarkOrange, // Num buttons
            Color.OrangeRed,
            Color.MediumPurple,
            Color.SaddleBrown,
            Color.LimeGreen
           // 238,79,82 0X00524FEE,
           // 50,185,87 0x0057B932,
           //35,118,199 0x00C77623,
           // 243,157,33 0x00219DF3,
           // 136,60,219 0x00DB3C88,
           //47,74,126 0x007E4A2F,
           // 0,102,0 0x00006600
        };
        private Process proc;

        public frmManualPrice(frmSalesMain _FrmSalesMain)
        {
            InitializeComponent();
            this.FrmSalesMain = _FrmSalesMain;
            strNewPrice = String.Empty;
            bEditNow = false;
        }
        public void Set_Amount(double pAmount)
        {
            p_Amount = (float)pAmount;
            txt_ManualPrice.Text = pAmount.ToString("C2");
        }
        public void Set_ProductName(string pPName)
        {
            p_PName = pPName;
            txt_ManualName.Text = p_PName;
        }

        private void cb_tax1_Changed(object sender, EventArgs e)
        {
            bTax1 = cb_Tax1.Checked;
        }

        private void cb_tax2_Changed(object sender, EventArgs e)
        {
            bTax2 = cb_Tax2.Checked;
        }

        private void cb_Tax3_Changed(object sender, EventArgs e)
        {
            bTax3 = cb_Tax3.Checked;
        }

        private void txt_ManualName_Click(object sender, EventArgs e)
        {
            //run on screen keyboard
            proc = Process.Start("osk.exe");
            txt_ManualName.SelectAll();
        }

        private void frmManualPrice_Load(object sender, EventArgs e)
        {
            //this.Top = Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - (this.Height / 2);
            //this.Left = Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - (this.Width / 2);
            //lbl_Titie.Text = "Welcom to AB SD Cafeteria Office Module";
            int xPos = 2;
            int yPos = 2;
            int iLines = 0;
            //////////////////////////////////////////////////////
            // Declare and assign number of buttons = 20 
            //System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[30];
            CustomButton[] btnNums = new CustomButton[13];
            //////////////////////////////////////////////////////
            // Create (20) Buttons: 
            for (int i = 0; i < 13; i++)
            {
                // Initialize one variable 
                //btnArray[i] = new System.Windows.Forms.Button();
                btnNums[i] = new CustomButton();
            }
            int n = 0;
            int iSpace = 2;
            int btWidth = pnlNums.Width - (iSpace * 3);
            int btHeight = pnlNums.Height - (iSpace * 5);
            while (n < 13)
            {
                btnNums[n].Tag = n + 1; // Tag of button 
                btnNums[n].Width = btWidth / 3; // Width of button 
                btnNums[n].Height = btHeight / 5; // Height of button
                btnNums[n].Font = new Font("Arial", 28, FontStyle.Bold);
                //btnArray[n].BackColor = Color.LightSteelBlue;
                btnNums[n].ForeColor = Color.WhiteSmoke;
                btnNums[n].CornerRadius = 30;
                //btnNums[n].RoundCorners = Corners.TopLeft | Corners.TopRight | Corners.BottomLeft;
                btnNums[n].RoundCorners = Corners.All;
                //btnArray[n].AutoSize = true;
                /////////////////////////////////////////////////////
                // 4 Buttons in one line
                /////////////////////////////////////////////////////
                if (n >= 3) // Location of second line of buttons: 
                {
                    if (n % 3 == 0)
                    {
                        xPos = 2;
                        yPos = yPos + btnNums[n].Height + iSpace;
                        iLines++;
                    }
                }
                if (n + 1 == 13)
                {
                    btnNums[n].Width = btWidth;
                }
                btnNums[n].BackColor = btColor[2];
                // Location of button: 
                btnNums[n].Left = xPos;
                btnNums[n].Top = yPos;
                // Add buttons to a Panel: 
                pnlNums.Controls.Add(btnNums[n]);  // Let panel hold the Buttons 
                xPos = xPos + btnNums[n].Width + iSpace;    // Left of next button 
                                                            // Write English Character: 
                /* **************************************************************** 
                    Menu item button text
                //**************************************************************** */

                //btnArray[n].Text = ((char)(n + 65)).ToString() + (n+1).ToString();
                btnNums[n].Text = (n + 1).ToString();
                if (n + 1 == 10)
                {
                    btnNums[n].Text = "OK";
                    btnNums[n].BackColor = Color.ForestGreen;
                    btnNums[n].ForeColor = Color.White;
                }
                if (n + 1 == 11)
                {
                    btnNums[n].Text = "0";
                }
                if (n + 1 == 12)
                {
                    btnNums[n].Text = "DEL";
                    btnNums[n].BackColor = Color.Maroon;
                    btnNums[n].ForeColor = Color.White;
                }
                if (n + 1 == 13)
                {
                    btnNums[n].Text = "EXIT";
                    btnNums[n].BackColor = Color.Gray;
                    btnNums[n].ForeColor = Color.White;
                }
                // the Event of click Button 
                btnNums[n].Click += new System.EventHandler(ClickNumberButton);
                n++;
            }
            txt_ManualPrice.Focus();
            pnlNums.Enabled = true; // not need now to this button now 

            bTax1 = p_IsTax1;
            bTax2 = p_IsTax2;
            bTax3 = p_IsTax3;

            cb_Tax1.Checked = bTax1;
            cb_Tax2.Checked = bTax2;
            cb_Tax3.Checked = bTax3;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.BringToFront();
            this.TopMost = true;
            this.TopMost = false;
        }
        private void ClickNumberButton(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            CustomButton btn = (CustomButton)sender;
            btn.BackColor = Color.Yellow;
            btn.ForeColor = Color.DarkBlue;
            if (selectedBTN != null)
            {
                selectedBTN.BackColor = btColor[2];
                selectedBTN.ForeColor = Color.Black;
            }
            //selectedBTN = (Button)sender;
            selectedBTN = (CustomButton)sender;
            if (btn.Text == "OK")  // OK
            {
                //this.Show();
                strManualName = txt_ManualName.Text;
                strNewPrice = txt_ManualPrice.Text;
                dblManualPrice = Convert.ToDouble(strNewPrice);
                bTax1 = cb_Tax1.Checked;
                bTax2 = cb_Tax2.Checked;
                bTax3 = cb_Tax3.Checked;
                bEditNow = true;
                this.Close();
                return;
            }
            if (btn.Text == "DEL")  // DELETE
            {
                strNewPrice = string.Empty;
                txt_ManualPrice.Text = strNewPrice;
                dblManualPrice = 0;
                bEditNow = false;
                return;
            }
            if (btn.Text == "EXIT")  // OK
            {
                strNewPrice = string.Empty;
                dblManualPrice = 0;
                bEditNow = false;
                this.Close();
                return;
            }

            txt_ManualPrice.Text = strNewPrice + btn.Text;
            //if ((txt_NewPrice.Text.Length > 2) && (txt_NewPrice.Text.IndexOf('.') < 0))
            if (txt_ManualPrice.Text.Length > 2)
            {
                string strTemp = strNewPrice + btn.Text;
                int i = strTemp.IndexOf('.');
                if (strTemp.IndexOf('.') > -1)
                {
                    strTemp = strTemp.Remove(strTemp.IndexOf('.'), 1);
                }
                txt_ManualPrice.Text = strTemp.Insert(strTemp.Length - 2, ".");
            }
            strNewPrice = txt_ManualPrice.Text;
        }
    }
}
