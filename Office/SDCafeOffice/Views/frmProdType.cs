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
    public partial class frmProdType : Form
    {
        private string strTypeId;
        List<POS_ProductTypeModel> ptypes = new List<POS_ProductTypeModel>();
        public frmProdType()
        {
            InitializeComponent();
        }

        public frmProdType(string strTypeId)
        {
            InitializeComponent();
            txt_TypeID.Text = strTypeId;
            txt_TypeID.Enabled = false;
            if (String.IsNullOrEmpty(txt_TypeID.Text))
            {
                txtMessage.Text = "No Product Type was selected. Insert(Save) mode is on!";
            }
            else
            {
                txtMessage.Text = "Selected Type ID : " + strTypeId;
                Load_ProdType_Info(strTypeId);
            }
        }

        private void Load_ProdType_Info(string strTypeId)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            ptypes.Clear();
            ptypes = dbPOS.Get_ProductType_By_ID(int.Parse(strTypeId));
            if (ptypes.Count == 1)
            {
                txt_TypeID.Text = ptypes[0].Id.ToString();
                txt_TypeName.Text = ptypes[0].TypeName;
                check_Liquor.Checked = ptypes[0].IsLiquor;
                check_Restaurant.Checked = ptypes[0].IsRestaurant;
                check_Donation.Checked = ptypes[0].IsBatchDonation;
                check_Discount.Checked = ptypes[0].IsBatchDiscount;
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_TypeID.Text))
            {
                Insert_ProdType_From_View();
            }
            else
            {
                Update_ProdType_From_View();
            }
        }

        private void Update_ProdType_From_View()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigDesc.Text)) txt_ConfigDesc.Text = "";

            ptypes.Clear();
            ptypes.Add(new POS_ProductTypeModel()
            {
                Id = int.Parse(txt_TypeID.Text),
                TypeName = txt_TypeName.Text,
                IsLiquor = check_Liquor.Checked,
                IsRestaurant = check_Restaurant.Checked,
                IsBatchDonation = check_Donation.Checked,
                IsBatchDiscount = check_Discount.Checked
            });
            int iCnt = dbPOS.Update_ProductType(ptypes[0]);
            txtMessage.Text = "Type successfully Updated : " + txt_TypeName.Text;
            txtMessage.ForeColor = Color.White;
        }

        private void Insert_ProdType_From_View()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigDesc.Text)) txt_ConfigDesc.Text = "";

            ptypes.Clear();
            ptypes.Add(new POS_ProductTypeModel()
            {
                TypeName = txt_TypeName.Text,
                IsLiquor = check_Liquor.Checked,
                IsRestaurant = check_Restaurant.Checked,
                IsBatchDonation = check_Donation.Checked,
                IsBatchDiscount = check_Discount.Checked
            });
            int iCnt = dbPOS.Insert_ProductType(ptypes[0]);
            txtMessage.Text = "Type successfully Added : " + txt_TypeName.Text;
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
            Insert_ProdType_From_View();
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            int iSelectedProdTypeId = Convert.ToInt32(txt_TypeID.Text);
            if (iSelectedProdTypeId > 0)
            {
                DataAccessPOS dbPOS = new DataAccessPOS();
                dbPOS.Delete_ProductType_By_Id(iSelectedProdTypeId);
                bt_Exit.PerformClick();
            }
        }
    }
}
