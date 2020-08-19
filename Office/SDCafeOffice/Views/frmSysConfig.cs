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
    public partial class frmSysConfig : Form
    {
        List<POS_SysConfigModel> sysCons = new List<POS_SysConfigModel>();
        Utility util = new Utility();
        public frmSysConfig()
        {
            InitializeComponent();
        }
        public frmSysConfig(String strConfigID)
        {
            InitializeComponent();
            txt_ConfigID.Text = strConfigID;
            txt_ConfigID.Enabled = false;
            if (String.IsNullOrEmpty(txt_ConfigID.Text))
            {
                txtMessage.Text = "No Sysconfig was selected. Insert(Save) mode is on!";
            }
            else
            {
                txtMessage.Text = "Selected Config ID : " + strConfigID;
                Load_SysConfig_Info(strConfigID);
            }
        }

        private void Load_SysConfig_Info(string strConfigID)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            sysCons.Clear();
            sysCons = dbPOS.Get_SysConfig_By_ID(int.Parse(strConfigID));
            if (sysCons.Count == 1)
            {
                txt_ConfigID.Text = sysCons[0].Id.ToString();
                txt_ConfigName.Text = sysCons[0].ConfigName;
                txt_ConfigValue.Text = sysCons[0].ConfigValue;
                txt_ConfigDesc.Text = sysCons[0].ConfigDesc;
                check_IsActive.Checked = sysCons[0].IsActive;
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_ConfigID.Text))
            {
                Insert_SysConfig_From_View();
            }
            else
            {
                Update_SysConfig_From_View();
            }
        }

        private void Update_SysConfig_From_View()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigDesc.Text)) txt_ConfigDesc.Text = "";

            sysCons.Clear();
            sysCons.Add(new POS_SysConfigModel()
            {
                Id = int.Parse(txt_ConfigID.Text),
                ConfigName = txt_ConfigName.Text,
                ConfigValue = txt_ConfigValue.Text,
                ConfigDesc = txt_ConfigDesc.Text,
                IsActive = check_IsActive.Checked
            });
            int iProdCnt = dbPOS.Update_SysConfig(sysCons[0]);
        }

        private void Insert_SysConfig_From_View()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigDesc.Text)) txt_ConfigDesc.Text = "";

            sysCons.Clear();
            sysCons.Add(new POS_SysConfigModel()
            {
                //Id = int.Parse(txt_ConfigID.Text),
                ConfigName = txt_ConfigName.Text,
                ConfigValue = txt_ConfigValue.Text,
                ConfigDesc = txt_ConfigDesc.Text,
                IsActive = check_IsActive.Checked
            });
            int iProdCnt = dbPOS.Insert_SysConfig(sysCons[0]);
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }
    }
}
