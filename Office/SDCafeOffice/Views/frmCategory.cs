using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;

namespace SDCafeOffice.Views
{
    public partial class frmCategory : Form
    {
        private string strCategoryId;
        List<POS_CategoryModel> categories = new List<POS_CategoryModel>();
        frmMain FrmMain;
        public frmCategory()
        {
            InitializeComponent();
        }

        public frmCategory(string p_strCategoryId, frmMain _FrmMain)
        {
            FrmMain = _FrmMain;
            InitializeComponent();
            txt_CategoryID.Text = p_strCategoryId;
            txt_CategoryID.Enabled = false;
            strCategoryId = p_strCategoryId;
            if (String.IsNullOrEmpty(txt_CategoryID.Text))
            {
                txtMessage.Text = "No Product Category was selected. Insert(Save) mode is on!";
            }
            else
            {
                txtMessage.Text = "Selected Category ID : " + strCategoryId;
                Load_Category_Info(strCategoryId);
            }
        }

        private void Load_Category_Info(string p_strCategoryId)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            categories.Clear();
            categories = dbPOS.Get_Category_By_ID(int.Parse(p_strCategoryId));
            if (categories.Count == 1)
            {
                txt_CategoryID.Text = categories[0].Id.ToString();
                txt_CategoryName.Text = categories[0].CategoryName;
                check_SeparateReport.Checked = categories[0].IsSeparateReport;
                check_DCException.Checked = categories[0].IsDCException;
            }
            if (categories[0].Id < 3)
            {
                bt_Add.Enabled = false;
                bt_Delete.Enabled = false;
                bt_Save.Enabled = false;
                txtMessage.Text = "System Categories (Sales/Payout) can not be changed or deleted!";
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_CategoryID.Text))
            {
                Insert_Category_From_View();
            }
            else
            {
                Update_Category_From_View();
            }
        }

        private void Update_Category_From_View()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigDesc.Text)) txt_ConfigDesc.Text = "";
            int iCatId = 0;
            try
            {
                iCatId = int.Parse(txt_CategoryID.Text);
            }
            catch (Exception ex)
            {
                iCatId = 0;
            }
            categories.Clear();
            categories.Add(new POS_CategoryModel()
            {
                Id = iCatId,
                CategoryName = txt_CategoryName.Text,
                IsSeparateReport = check_SeparateReport.Checked,
                IsDCException = check_DCException.Checked
            });
            int iCnt = dbPOS.Update_Category(categories[0]);
            txtMessage.Text = "Type successfully Updated : " + txt_CategoryName.Text;
            txtMessage.ForeColor = Color.White;
        }

        private void Insert_Category_From_View()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigDesc.Text)) txt_ConfigDesc.Text = "";
            int iCatId = 0;
            try
            {
                iCatId = int.Parse(txt_CategoryID.Text);
            }
            catch (Exception ex)
            {
                iCatId = 0;
            }

            categories.Clear();
            categories.Add(new POS_CategoryModel()
            {
                Id = iCatId,
                CategoryName = txt_CategoryName.Text,
                IsSeparateReport = check_SeparateReport.Checked,
                IsDCException = check_DCException.Checked
            });
            int iCnt = dbPOS.Insert_Category(categories[0]);
            txtMessage.Text = "Type successfully Added : " + txt_CategoryName.Text;
            txtMessage.ForeColor = Color.White;
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_Save.PerformClick();
            }
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            Insert_Category_From_View();
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            int iSelectedId = Convert.ToInt32(txt_CategoryID.Text);
            int iAssociatedProds = dbPOS.Get_All_Products_By_Category(iSelectedId).Count;
            if (iAssociatedProds > 0)
            {
                // Cannot delete Product Type which has associated products
                txtMessage.Text = "Cannot delete Category which has associated products ! " + iAssociatedProds.ToString();
                return;
            }

            if (iSelectedId > 0)
            {
                using (var FrmYesNo = new frmYesNo(FrmMain))
                {
                    FrmYesNo.Set_Title("Product");
                    FrmYesNo.Set_Message("Do you want to delete this Product ?");
                    FrmYesNo.StartPosition = FormStartPosition.Manual; // FormStartPosition.CenterScreen; //
                    FrmYesNo.Location = new System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                              (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                    FrmYesNo.ShowDialog();

                    if (FrmYesNo.bYesNo)
                    {
                        dbPOS.Delete_Category_By_Id(iSelectedId);
                        bt_Exit.PerformClick();
                    }
                }
            }
        }
    }
}
