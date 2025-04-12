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
using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
using SDCafeCommon.Utilities;
using static System.Net.WebRequestMethods;

namespace SDCafeOffice.Views
{
    public partial class frmTax : Form
    {
        List<POS_TaxModel> taxes = new List<POS_TaxModel>();
        Utility util = new Utility();
        private bool m_blnNew;
        frmMain FrmMain;
        public frmTax()
        {
            InitializeComponent();
        }
        public frmTax(frmMain _frmMain,String p_strTaxCode, string p_strTax1, string p_strTax2, string p_strTax3)
        {
            InitializeComponent();
            this.FrmMain = _frmMain;

            m_blnNew = false;

            txt_TaxCode.Text = p_strTaxCode;
            txt_TaxCode.Enabled = false;
            lalTax1.Text = p_strTax1;
            lalTax2.Text = p_strTax2;
            lalTax3.Text = p_strTax3;

            if (String.IsNullOrEmpty(txt_TaxCode.Text))
            {
                txtMessage.Text = "No Tax was selected. Insert(Save) mode is on!";
                txt_TaxCode.Enabled = true;

                txt_Tax1.Text = "0";
                txt_Tax2.Text = "0";
                txt_Tax3.Text = "0";
                chkTax3IncTax1.Checked = false;

                m_blnNew = true;
            }
            else
            {
                txtMessage.Text = "Selected Tax Code : " + p_strTaxCode;
                Load_Tax_Info(p_strTaxCode);
            }
        }

        private void Load_Tax_Info(string p_strTaxCode)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            taxes.Clear();
            taxes = dbPOS.Get_Tax_By_Code(p_strTaxCode);
            if (taxes.Count == 1)
            {
                txt_TaxCode.Text = taxes[0].Code;
                txt_Tax1.Text = taxes[0].Tax1.ToString();
                txt_Tax2.Text = taxes[0].Tax2.ToString();
                txt_Tax3.Text = taxes[0].Tax3.ToString();
                chkTax3IncTax1.Checked = taxes[0].IsTax3IncTax1;
                chkTax3IncTax1.Text = lalTax1.Text + " include " + lalTax1.Text + "?";
                txt_Tax1Name.Text = taxes[0].Tax1Name;
                txt_Tax2Name.Text = taxes[0].Tax2Name;
                txt_Tax3Name.Text = taxes[0].Tax3Name;
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_TaxCode.Text))
            {
                MessageBox.Show("Tax Code is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_TaxCode.Focus();
            }
            else
            {
                if (m_blnNew)
                {
                    Insert_Tax_From_View();
                }
                else
                {
                    Update_Tax_From_View();
                }
            }
        }

        private void Update_Tax_From_View()
        {
            float fT1, fT2, fT3 = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();

            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigDesc.Text)) txt_ConfigDesc.Text = "";
            try
            {
                fT1 = float.Parse(txt_Tax1.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                txt_Tax1.Focus();
                return;
            }
            try
            {
                fT2 = float.Parse(txt_Tax2.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                txt_Tax2.Focus();
                return;
            }
            try
            {
                fT3 = float.Parse(txt_Tax3.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                txt_Tax3.Focus();
                return;
            }
            taxes.Clear();
            taxes.Add(new POS_TaxModel()
            {
                Code = txt_TaxCode.Text,
                Tax1 = fT1,
                Tax2 = fT2,
                Tax3 = fT3,
                IsTax3IncTax1 = chkTax3IncTax1.Checked,
                Tax1Name = txt_Tax1Name.Text,
                Tax2Name = txt_Tax2Name.Text,
                Tax3Name = txt_Tax3Name.Text
            });
            int iTaxCnt = dbPOS.Update_Tax(taxes[0]);
        }

        private void Insert_Tax_From_View()
        {
            float fT1, fT2, fT3 = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();

            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigDesc.Text)) txt_ConfigDesc.Text = "";
            bool blnExist = dbPOS.Check_Tax_Exists(txt_TaxCode.Text);

            if (blnExist)
            {
                MessageBox.Show("Tax Code already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_TaxCode.Focus();
                return;
            }
            taxes.Clear();

            try
            {
                fT1 = float.Parse(txt_Tax1.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                txt_Tax1.Focus();
                return;
            }
            try
            {
                fT2 = float.Parse(txt_Tax2.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                txt_Tax2.Focus();
                return;
            }
            try
            {
                fT3 = float.Parse(txt_Tax3.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                txt_Tax3.Focus();
                return;
            }

            taxes.Add(new POS_TaxModel()
            {
                Code = txt_TaxCode.Text,
                Tax1 = fT1,
                Tax2 = fT2,
                Tax3 = fT3,
                IsTax3IncTax1 = chkTax3IncTax1.Checked,
                Tax1Name = txt_Tax1Name.Text,
                Tax2Name = txt_Tax2Name.Text,
                Tax3Name = txt_Tax3Name.Text
            });
            int iTaxCnt = dbPOS.Insert_Tax(taxes[0]);
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            List<POS_SysConfigModel> sysConfig = new List<POS_SysConfigModel>();

            using (var FrmYesNo = new frmYesNo(this.FrmMain))
            {
                FrmYesNo.Set_Title("Delete Tax");

                FrmYesNo.Set_Message("Delete Tax ?");
                //FrmYesNo.Set_Message("Set/Unset All selected Invoice ?" + strSelInvNo);
                FrmYesNo.StartPosition = FormStartPosition.Manual; // FormStartPosition.CenterScreen; //
                FrmYesNo.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                FrmYesNo.ShowDialog();

                if (FrmYesNo.bYesNo)
                {
                    sysConfig = dbPOS.Get_SysConfig_By_Name("DEFAULT_TAXCODE");
                    if (sysConfig.Count > 0)
                    {
                        if (sysConfig[0].ConfigValue == txt_TaxCode.Text)
                        {
                            MessageBox.Show("Default Tax Code cannot be deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    bool blnDeleted = dbPOS.Delete_Tax(txt_TaxCode.Text);
                    if (blnDeleted)
                    {
                        txtMessage.Text = "Tax Code : " + txt_TaxCode.Text + " was deleted!";
                        txt_TaxCode.Text = "";
                        txt_Tax1.Text = "";
                        txt_Tax2.Text = "";
                        txt_Tax3.Text = "";
                        chkTax3IncTax1.Checked = false;
                        txt_Tax1Name.Text = "";
                        txt_Tax2Name.Text = "";
                        txt_Tax3Name.Text = "";
                    }
                    else
                    {
                        txtMessage.Text = "Tax Code : " + txt_TaxCode.Text + " was not deleted!";
                    }
                }
            }
        }
    }
}
