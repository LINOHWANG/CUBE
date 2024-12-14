using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
using SDCafeCommon.Utilities;

namespace SDCafeOffice.Views
{
    public partial class frmLoginUser : Form
    {
        private string strSelLoginId;
        List<POS_LoginUserModel> loginUsers = new List<POS_LoginUserModel>();
        Utility util = new Utility();
        frmMain frmMain;
        public frmLoginUser()
        {
            InitializeComponent();
        }

        public frmLoginUser(string strSelLoginId, frmMain _FrmMain)
        {
            frmMain = _FrmMain;
            InitializeComponent();
            txt_LoginID.Text = strSelLoginId;
            txt_LoginID.Enabled = false;
            if (String.IsNullOrEmpty(txt_LoginID.Text))
            {
                txtMessage.Text = "No Sysconfig was selected. Insert(Save) mode is on!";
            }
            else
            {
                txtMessage.Text = "Selected LoginUser ID : " + strSelLoginId;
                Load_LoginUser_Info(strSelLoginId);
            }
        }

        private void Load_LoginUser_Info(string strSelLoginId)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            loginUsers.Clear();
            loginUsers = dbPOS.Get_LoginUser_By_ID(int.Parse(strSelLoginId));
            if (loginUsers.Count == 1)
            {
                txt_LoginID.Text = loginUsers[0].Id.ToString();
                txt_FirstName.Text = loginUsers[0].FirstName;
                txt_LastName.Text = loginUsers[0].LastName;
                txt_NickName.Text = loginUsers[0].NickName;
                txt_Dept.Text = loginUsers[0].Department;
                txt_Mobile.Text = loginUsers[0].MobilePhone;
                txt_Addr.Text = loginUsers[0].Address;
                try
                {
                    dtp_DOB.Text = (loginUsers[0].DOB == null) ? "" : loginUsers[0].DOB.ToShortDateString();
                }
                catch (Exception)
                {
                    dtp_DOB.Text = DateTime.Now.ToShortDateString();
                }
                
                txt_Addr.Text = loginUsers[0].Address;
                txt_PassWord.Text = loginUsers[0].PassWord;
                txt_Grade.Text = loginUsers[0].Grade;
                txt_Wage.Text = loginUsers[0].Wage.ToString();
                txt_CreatedDTTM.Text = loginUsers[0].DateTimeCreated.ToString();
                txt_UpdatedDTTM.Text = loginUsers[0].DateTimeUpdated.ToString();
                check_Active.Checked = loginUsers[0].IsActive;
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            // Input data validation 
            if ((Convert.ToInt32(txt_Grade.Text) < 0) || (Convert.ToInt32(txt_Grade.Text) > 5))
            {
                txtMessage.Text = "Check Grade Value : (Value should be between 0~5) !" ;
                txtMessage.ForeColor = Color.Red;
                return;
            }
            // Input data validation 
            if (String.IsNullOrEmpty(txt_LoginID.Text))
            {
                Insert_LoginUser_From_View();
            }
            else
            {
                Update_LoginUser_From_View();
            }
        }

        private void Update_LoginUser_From_View()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigDesc.Text)) txt_ConfigDesc.Text = "";
            if (DateTime.Parse(txt_CreatedDTTM.Text).Year < 2019)
            {
                txt_CreatedDTTM.Text = DateTime.Now.ToString();
            }  

            loginUsers.Clear();
            loginUsers.Add(new POS_LoginUserModel()
            {
                Id = int.Parse(txt_LoginID.Text),
                FirstName = txt_FirstName.Text,
                LastName = txt_LastName.Text,
                NickName = txt_NickName.Text,
                Department = txt_Dept.Text,
                DOB = dtp_DOB.Value,
                MobilePhone = txt_Mobile.Text,
                Address = txt_Addr.Text,
                PassWord = txt_PassWord.Text,
                Grade = txt_Grade.Text,
                Wage = float.Parse(txt_Wage.Text),
                IsActive = check_Active.Checked,
                DateTimeCreated = Convert.ToDateTime(txt_CreatedDTTM.Text),
                DateTimeUpdated = DateTime.Now
                
            });
            int iProdCnt = dbPOS.Update_LoginUser(loginUsers[0]);
            txtMessage.Text = "User successfully Updated : " + txt_LoginID.Text;
            txtMessage.ForeColor = Color.White;
        }

        private void Insert_LoginUser_From_View()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            if (String.IsNullOrEmpty(txt_Wage.Text)) txt_Wage.Text = "0";

            loginUsers.Clear();
            loginUsers.Add(new POS_LoginUserModel()
            {
                //Id = int.Parse(txt_LoginID.Text),
                FirstName = txt_FirstName.Text,
                LastName = txt_LastName.Text,
                NickName = txt_NickName.Text,
                Department = txt_Dept.Text,
                DOB = dtp_DOB.Value,
                MobilePhone = txt_Mobile.Text,
                Address = txt_Addr.Text,
                PassWord = txt_PassWord.Text,
                Grade = txt_Grade.Text,
                Wage = float.Parse(txt_Wage.Text),
                IsActive = check_Active.Checked,
                DateTimeCreated = DateTime.Now,
                DateTimeUpdated = DateTime.Now

            });
            int iProdCnt = dbPOS.Insert_LoginUser(loginUsers[0]);
            txtMessage.Text = "User successfully Added : " + txt_LoginID.Text;
            txtMessage.ForeColor = Color.White;
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            int iSelectedId = Convert.ToInt32(txt_LoginID.Text);
            if (iSelectedId > 0)
            {
                using (var FrmYesNo = new frmYesNo(frmMain))
                {
                    FrmYesNo.Set_Title("User");
                    FrmYesNo.Set_Message("Do you want to delete this user ?");
                    FrmYesNo.StartPosition = FormStartPosition.Manual; // FormStartPosition.CenterScreen; //
                    FrmYesNo.Location = new System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                              (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                    FrmYesNo.ShowDialog();

                    if (FrmYesNo.bYesNo)
                    {
                        DataAccessPOS dbPOS = new DataAccessPOS();
                        dbPOS.Delete_LoginUser(iSelectedId);
                        bt_Exit.PerformClick();
                    }
                }

            }
        }
    }
}
