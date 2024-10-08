using SDCafeCommon.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDCafeKitchen.Views
{
    public partial class frmPrintCount : Form
    {
        frmRegisterMain FrmRegisterMain;

        Utility util = new Utility();
        public CustomButton selectedBTN;
        public String strQTY;
        public bool bPrintNow;

        public Color[] btColor =
        {
            Color.Crimson,
            Color.SeaGreen,
            Color.MidnightBlue,
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
        public frmPrintCount(frmRegisterMain _FrmRegisterMain)
        {
            InitializeComponent();
            this.FrmRegisterMain = _FrmRegisterMain;
            strQTY = String.Empty;
            bPrintNow = false;
        }

        private void bt_RecallOrder_Click(object sender, EventArgs e)
        {

        }

        private void frmRecallOrder_Load(object sender, EventArgs e)
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
            txt_QTY.Focus();
            txt_QTY.Text = "1";
            txt_QTY.SelectAll();
            pnlNums.Enabled = true; // not need now to this button now 

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
                strQTY = txt_QTY.Text;
                bPrintNow = true;
                this.Close();
                return;
            }
            if (btn.Text == "DEL")  // DELETE
            {
                strQTY = string.Empty;
                txt_QTY.Text = strQTY;
                bPrintNow = false;
                return;
            }
            if (btn.Text == "EXIT")  // OK
            {
                strQTY = string.Empty;
                bPrintNow = false;
                this.Close();
                return;
            }

            txt_QTY.Text = strQTY + btn.Text;
            strQTY = txt_QTY.Text;
        }
    }
}
