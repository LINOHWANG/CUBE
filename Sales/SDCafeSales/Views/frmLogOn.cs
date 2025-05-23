﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDCafeCommon.Model;
using SDCafeCommon.DataAccess;
using SDCafeCommon.Utilities;
using SDCafeSales.Properties;
using SDCafeSales.Views;
using System.Threading;

namespace SDCafeSales
{
    public partial class frmLogOn : Form
    {
        List<POS_LoginUserModel> loginUsers = new List<POS_LoginUserModel>();
        List<POS_SysConfigModel> sysConfigs = new List<POS_SysConfigModel>();
        
        List<POS_TimeTableModel> timeTables = new List<POS_TimeTableModel>();
        POS_TimeTableModel timeTable = new POS_TimeTableModel();

        Utility util = new Utility();
        public CustomButton selectedBTN;
        public String strPassCode;
        public frmSalesMain FrmSalesMain;
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

        //////////////////////////////////////////////////////
        // Declare and assign number of buttons = 20 
        //System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[30];
        private CustomButton[] btnNums = new CustomButton[13];
        private ImageList m_ImageList;
        private string m_strStationName;
        private bool m_bIsLicensed;
        private bool m_bln_DBConnection;

        public frmLogOn()
        {
            InitializeComponent();
        }

        private void frmLogOn_Load(object sender, EventArgs e)
        {
            //this.Top = Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - (this.Height / 2);
            //this.Left = Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - (this.Width / 2);
            //lbl_Titie.Text = "Welcom to AB SD Cafeteria Office Module";
            Load_ImageList();
            Load_Configuration();
            Initialize_Buttons();
            Initialize_ClockInOut_List();
            Check_License();
            txtPassCode.Focus();

        }

        private void Load_Configuration()
        {
            m_bln_DBConnection = true;
            DataAccessPOS dbPOS = new DataAccessPOS();
            sysConfigs = dbPOS.Get_SysConfig_By_Name("SCREEN_LOGO_IMAGE");
            if (sysConfigs != null)
            {
                if (sysConfigs.Count > 0)
                {
                    pictureBoxLogo.Image = Image.FromFile(sysConfigs[0].ConfigValue);
                }
            }
            sysConfigs = dbPOS.Get_SysConfig_By_Name("BIZ_TITLE");
            if (sysConfigs != null)
            {
                if (sysConfigs.Count > 0)
                {
                    textBoxBizTitle.Text = sysConfigs[0].ConfigValue;
                }
            }
            else
            {
                textBoxBizTitle.Text = "DB OR CONFIG ERROR !";
                m_bln_DBConnection = false;
                return;
            }

                txtMessage.Text = "Please press Pass Code & OK to login!";

            this.StartPosition = FormStartPosition.CenterScreen;
            this.BringToFront();
            this.TopMost = true;
            this.TopMost = false;

            List<POS_StationModel> stations = dbPOS.Get_Station_By_HostName(Environment.MachineName);

            if (stations.Count > 0)
            {
                m_strStationName = stations[0].StationName;
            }
            else
            {
                m_strStationName = "Unknown";
            }
            lblStationName.Text = m_strStationName;

        }
        private void Check_License()
        {
            m_bIsLicensed = util.IsLicensed(m_strStationName);
        }
        private void Load_ImageList()
        {
            m_ImageList = new ImageList();
            m_ImageList.ImageSize = new Size(40, 40);
            m_ImageList.ColorDepth = ColorDepth.Depth32Bit;
            m_ImageList.Images.Add(Properties.Resources.Card_Terminal_POS_100x100);
            m_ImageList.Images.Add(Properties.Resources.logout_40dp);
        }

        private void Initialize_Buttons()
        {
            int xPos = 2;
            int yPos = 2;
            int iLines = 0;
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
                if (!m_bln_DBConnection)
                {
                    btnNums[n].Enabled = false;
                }

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
                    if (!m_bln_DBConnection)
                    {
                        btnNums[n].Enabled = false;
                    }
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
                    btnNums[n].ImageList = m_ImageList;
                    btnNums[n].ImageIndex = 1;
                    btnNums[n].ImageAlign = ContentAlignment.MiddleLeft;

                    btnNums[n].Enabled = true;
                }
                // the Event of click Button 
                btnNums[n].Click += new System.EventHandler(ClickNumberButton);
                n++;
            }
            pnlNums.Enabled = true; // not need now to this button now 

 
        }

        public void ClickNumberButton(Object sender, System.EventArgs e)
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
                if ((UserLoginWithPassCode(txtPassCode.Text)) && m_bIsLicensed)
                {
                    this.Hide();
                    FrmSalesMain = new frmSalesMain();
                    FrmSalesMain.Set_PassCode(txtPassCode.Text);
                    //FrmSalesMain.Show();
                    FrmSalesMain.ShowDialog();
                    //FrmSalesMain.Close();
                    // We get here when newform's DialogResult gets set
                    //this.Show();
                    strPassCode = string.Empty;
                    txtPassCode.Text = strPassCode;
                    //this.Close();
                }
                else
                {
                    txtMessage.Text = "Login Failed ! Please check your passcode or License !";
                    strPassCode = string.Empty;
                    txtPassCode.Text = strPassCode;
                    Console.Beep(3000, 1000);

                }

                //this.Show();
                return;
            }
            if (btn.Text == "DEL")  // DELETE
            {
                strPassCode = string.Empty;
                txtPassCode.Text = strPassCode;
                txtPassCode.Focus();
                return;
            }
            if (btn.Text == "EXIT")  // OK
            {
                this.Close();
                Application.Exit();
                return;
            }

            txtPassCode.Text = strPassCode + btn.Text;
            strPassCode = txtPassCode.Text;
            // txtSelectedMenu.Text = "You have now selected button [ " + btn.Text + " ]";
            //bt_Stop.PerformClick();
            //bt_Start.PerformClick();
            //Reset_NumButtons();
            txtPassCode.Focus();
        }

        private bool UserLoginWithPassCode(string strPassCode)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            try
            {
                loginUsers = dbPOS.UserLogin(strPassCode);

                if (loginUsers.Count == 1)
                {
                    // If User is not clock in, then clock in
                    timeTables = dbPOS.Get_Last_ClockIn(loginUsers[0].Id);
                    if (timeTables.Count == 0)
                    {
                        timeTable.UserId = loginUsers[0].Id;
                        timeTable.DateTimeStarted = DateTime.Now;
                        timeTable.DateTimeFinished = null;
                        timeTable.InCount = 1;
                        timeTable.Wage = loginUsers[0].Wage;
                        dbPOS.Insert_TimeTable(timeTable);
                    }
                    return true;
                }
                util.Logger("UserLogin Failed with PassCode :" + strPassCode);
            }
            catch (Exception e)
            {
                util.Logger("UserLogin Error :" + e.Message);
                return false;
            }
            return false;
        }

        private void frmLogOn_Shown(object sender, EventArgs e)
        {
            txtPassCode.Focus();
        }

        private void txtPassCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (UserLoginWithPassCode(txtPassCode.Text))
                {
                    this.Hide();
                    FrmSalesMain = new frmSalesMain();
                    FrmSalesMain.Set_PassCode(txtPassCode.Text);
                    FrmSalesMain.Show();
                    strPassCode = string.Empty;
                    txtPassCode.Text = strPassCode;
                }
                else
                {
                    txtMessage.Text = "Login Failed ! Please check your passcode !";
                    strPassCode = string.Empty;
                    txtPassCode.Text = strPassCode;
                    Console.Beep(3000, 1000);

                }

                //this.Show();
                return;
            }
        }

        private void bt_ClockIn_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessPOS dbPOS = new DataAccessPOS();
                loginUsers = dbPOS.UserLogin(strPassCode);

                if (loginUsers.Count == 1)
                {
                    timeTables = dbPOS.Get_Last_ClockIn(loginUsers[0].Id);
                    if (timeTables.Count == 0)
                    {
                        timeTable.UserId = loginUsers[0].Id;
                        timeTable.DateTimeStarted = DateTime.Now;
                        timeTable.DateTimeFinished = null;
                        timeTable.InCount = 1;
                        timeTable.Wage = loginUsers[0].Wage;
                        dbPOS.Insert_TimeTable(timeTable);
                        txtMessage.Text = "Clock In Success ! " + loginUsers[0].FirstName ;
                    }
                    else
                    {
                        txtMessage.Text = "Already Clock In ! " + loginUsers[0].FirstName;
                    }

                    //util.Logger("UserLogin Failed with PassCode :" + strPassCode);
                }
                else
                {
                    txtMessage.Text = "User Does Not Exists! Please check PassCode!";
                }
            }
            catch (Exception ex)
            {
                txtMessage.Text = "Error! " + ex.Message;
                util.Logger("UserLogin Error :" + ex.Message);
            }

            strPassCode = string.Empty;
            txtPassCode.Text = strPassCode;
            Reset_NumButtons();
            Initialize_ClockInOut_List();
            txtPassCode.Focus();
        }

        private void bt_ClockOut_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessPOS dbPOS = new DataAccessPOS();
                loginUsers = dbPOS.UserLogin(strPassCode);

                if (loginUsers.Count == 1)
                {
                    timeTables = dbPOS.Get_Last_ClockIn(loginUsers[0].Id);
                    if (timeTables.Count > 0)
                    {
                        timeTable.UserId = loginUsers[0].Id;
                        timeTable.DateTimeStarted = timeTables[0].DateTimeStarted;
                        if (timeTables[0].DateTimeFinished == null)
                        {
                            timeTable.DateTimeFinished = DateTime.Now;
                            timeTable.InCount = 1;
                            timeTable.Wage = loginUsers[0].Wage;
                            dbPOS.Update_TimeTable(timeTable);
                            txtMessage.Text = "Clock Out Success ! " + loginUsers[0].FirstName;
                        }
                        else
                        {
                            txtMessage.Text = "Already Clock Out ! " + loginUsers[0].FirstName + " " + timeTables[0].DateTimeFinished;
                        }
                    }
                    else
                    {
                        txtMessage.Text = "Clock In Does Not Exist ! " + loginUsers[0].FirstName;
                    }

                    //util.Logger("UserLogin Failed with PassCode :" + strPassCode);
                }
                else
                {
                    txtMessage.Text = "User Does Not Exists! Please check PassCode!";
                }
            }
            catch (Exception ex)
            {
                txtMessage.Text = "Error! " + ex.Message;
                util.Logger("UserLogin Error :" + ex.Message);
            }
            strPassCode = string.Empty;
            txtPassCode.Text = strPassCode;
            Reset_NumButtons();
            Initialize_ClockInOut_List();
            txtPassCode.Focus();
        }
        private void Initialize_ClockInOut_List()
        {
            listBoxClockInOut.Items.Clear();
            //listBoxClockInOut.MultiColumn = true;
            //String columns = "{0, -25}{1, -25}";
            try
            {
                DataAccessPOS dbPOS = new DataAccessPOS();
                timeTables = dbPOS.Get_All_Today_ClockInOut();
                if (timeTables.Count > 0)
                {
                    foreach (var tt in timeTables)
                    {
                        loginUsers = dbPOS.Get_LoginUser_By_ID(tt.UserId);
                        if (loginUsers.Count > 0)
                        {
                            string strUserName = loginUsers[0].FirstName + " " + loginUsers[0].LastName;
                            string strStartTime = tt.DateTimeStarted.ToString();
                            listBoxClockInOut.Items.Add(strStartTime + " " + strUserName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtMessage.Text = "Error! " + ex.Message;
               //util.Logger("UserLogin Error :" + ex.Message);
            }

        }
        private void Reset_NumButtons()
        {
            int n = 0;
            int iSpace = 2;
            while (n < 13)
            {
                btnNums[n].BackColor = btColor[2];
                btnNums[n].ForeColor = Color.White;
                if (n + 1 == 10)
                {
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
                n++;
            }
        }
    }
}
