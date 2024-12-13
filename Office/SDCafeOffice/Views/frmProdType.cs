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
        private Color m_ButtonBackColor;
        private Color m_ButtonForeColor;
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
                txt_SortOrder.Text = ptypes[0].SortOrder.ToString();
                check_Liquor.Checked = ptypes[0].IsLiquor;
                check_Restaurant.Checked = ptypes[0].IsRestaurant;
                check_Donation.Checked = ptypes[0].IsBatchDonation;
                check_Discount.Checked = ptypes[0].IsBatchDiscount;

                if (string.IsNullOrEmpty(ptypes[0].ForeColor))
                {
                    picForeColor.BackColor = Color.Black;
                    m_ButtonForeColor = Color.Black;
                }
                else
                {
                    // convert prods[0].ForeColor rgb string to color
                    picForeColor.BackColor = Color.FromArgb(int.Parse(ptypes[0].ForeColor));
                    m_ButtonForeColor = Color.FromArgb(int.Parse(ptypes[0].ForeColor));
                }
                if (string.IsNullOrEmpty(ptypes[0].BackColor))
                {
                    picBackColor.BackColor = Color.White;
                    m_ButtonBackColor = Color.White;
                }
                else
                {
                    // convert prods[0].BackColor rgb string to color
                    picBackColor.BackColor = Color.FromArgb(int.Parse(ptypes[0].BackColor));
                    m_ButtonBackColor = Color.FromArgb(int.Parse(ptypes[0].BackColor));
                }
                btButtonColor.BackColor = m_ButtonBackColor;
                btButtonColor.ForeColor = m_ButtonForeColor;
                btButtonColor.Text = ptypes[0].TypeName;
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
            int iId = 0;
            int iSortOrder = 0;
            try
            {
                iId = int.Parse(txt_TypeID.Text);
            }
            catch (Exception ex)
            {
                iId = 0;
            }
            try
            {
                iSortOrder = int.Parse(txt_SortOrder.Text);
            }
            catch (Exception ex)
            {
                iSortOrder = 0;
            }
            ptypes.Clear();
            ptypes.Add(new POS_ProductTypeModel()
            {
                Id = iId,
                TypeName = txt_TypeName.Text,
                IsLiquor = check_Liquor.Checked,
                SortOrder = iSortOrder,
                IsRestaurant = check_Restaurant.Checked,
                IsBatchDonation = check_Donation.Checked,
                IsBatchDiscount = check_Discount.Checked,
                ForeColor = m_ButtonForeColor.ToArgb().ToString(),
                BackColor = m_ButtonBackColor.ToArgb().ToString()
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
            int iId = 0;
            int iSortOrder = 0;
            try
            {
                iId = int.Parse(txt_TypeID.Text);
            }
            catch (Exception ex)
            {
                iId = 0;
            }
            try
            {
                iSortOrder = int.Parse(txt_SortOrder.Text);
            }
            catch (Exception ex)
            {
                iSortOrder = 0;
            }
            ptypes.Clear();
            ptypes.Add(new POS_ProductTypeModel()
            {
                Id = iId,
                TypeName = txt_TypeName.Text,
                IsLiquor = check_Liquor.Checked,
                SortOrder = iSortOrder,
                IsRestaurant = check_Restaurant.Checked,
                IsBatchDonation = check_Donation.Checked,
                IsBatchDiscount = check_Discount.Checked,
                ForeColor = m_ButtonForeColor.ToArgb().ToString(),
                BackColor = m_ButtonBackColor.ToArgb().ToString()
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
            DataAccessPOS dbPOS = new DataAccessPOS();
            int iSelectedProdTypeId = Convert.ToInt32(txt_TypeID.Text);
            int iAssociatedProds =   dbPOS.Get_All_Products_By_ProdType(iSelectedProdTypeId).Count;
            if (iAssociatedProds > 0)
            {
                // Cannot delete Product Type which has associated products
                txtMessage.Text = "Cannot delete Product Type which has associated products ! " + iAssociatedProds.ToString();
                return;
            }
            if (iSelectedProdTypeId > 0)
            {
                dbPOS.Delete_ProductType_By_Id(iSelectedProdTypeId);
                bt_Exit.PerformClick();
            }
        }

        private void picForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog clrDialog = new ColorDialog();

            //show the colour dialog and check that user clicked ok
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                //save the colour that the user chose
                m_ButtonForeColor = clrDialog.Color;
                picForeColor.BackColor = m_ButtonForeColor;
            }
            btButtonColor.ForeColor = m_ButtonForeColor;
        }

        private void picBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog clrDialog = new ColorDialog();

            //show the colour dialog and check that user clicked ok
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                //save the colour that the user chose
                m_ButtonBackColor = clrDialog.Color;
                picBackColor.BackColor = m_ButtonBackColor;
            }
            btButtonColor.BackColor = m_ButtonBackColor;
        }
    }
}
