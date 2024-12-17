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
    public partial class frmPromotion : Form
    {
        private string strPromoId;
        List<POS_PromotionModel> ppromos = new List<POS_PromotionModel>();
        List<POS_PromoTypelkupModel> ppTypes = new List<POS_PromoTypelkupModel>();
        List<POS_ProductModel> prods = new List<POS_ProductModel>();
        List<POS_ProductTypeModel> ptypes = new List<POS_ProductTypeModel>();
        List<POS_PromoProductsModel> pprods = new List<POS_PromoProductsModel>();


        public frmPromotion()
        {
            InitializeComponent();
        }
        public frmPromotion(string strPromoId)
        {
            InitializeComponent();
            txt_PromoID.Text = strPromoId;
            txt_PromoID.Enabled = false;
            Load_PromoType_Combo_Contents();
            
            Load_AllProducts_DataGrid();
            Load_PromoProducts_DataGrid();

            if (String.IsNullOrEmpty(txt_PromoID.Text))
            {
                txtMessage.Text = "No Promotion was selected. Insert(Save) mode is on!";
                bt_Delete.Enabled = false;
                bt_AddOne.Enabled = false;
            }
            else
            {
                txtMessage.Text = "Selected Promotion ID : " + strPromoId;
                Load_Promotion_Info(strPromoId);
            }
        }

        private void Load_AllProducts_DataGrid()
        {
            dgvDataFrom_Initialize();
            

            DataAccessPOS dbPOS = new DataAccessPOS();
            prods = dbPOS.Get_All_Products();
            lbl_AllProds.Text = "All Products ( " + prods.Count.ToString() + " )";
            if (prods.Count > 0)
            {
                foreach (var prod in prods)
                {
                    if (!prod.IsManualItem)
                    {
                        this.dgvDataFrom.Rows.Add(new String[] { prod.Id.ToString(),
                                                         dbPOS.Get_ProductTypeName_By_Id(prod.ProductTypeId),
                                                         prod.ProductName,
                                                         prod.OutUnitPrice.ToString()
                        });

                        /* if (ptype.IsBatchDonation)
                         {
                             this.dgvData.Rows[dgvData.RowCount - 2].Cells[3].Style.BackColor = Color.Green;
                         }
                         if (ptype.IsBatchDiscount)
                         {
                             this.dgvData.Rows[dgvData.RowCount - 2].Cells[4].Style.BackColor = Color.Green;
                         }*/
                        this.dgvDataFrom.FirstDisplayedScrollingRowIndex = dgvDataFrom.RowCount - 1;
                    }

                }
            }
        }
        private void Load_PromoProducts_DataGrid()
        {
            dgvDataTo_Initialize();

            if (txt_PromoID.Text != "")
            {
                DataAccessPOS dbPOS = new DataAccessPOS();
                int iSelectedPromoId = Convert.ToInt32(txt_PromoID.Text);
                if (iSelectedPromoId > 0)
                {
                    pprods = dbPOS.Get_PromoProducts_By_PromoId(iSelectedPromoId);

                    lbl_SelectedProds.Text = "Selected Products ( " + pprods.Count.ToString() + " )";
                    if (pprods.Count > 0)
                    {
                        foreach (var pprod in pprods)
                        {
                            prods = dbPOS.Get_Product_By_ID(pprod.ProdId);
                            if (prods.Count > 0)
                            {
                                this.dgvDataTo.Rows.Add(new String[] { prods[0].Id.ToString(),
                                                             dbPOS.Get_ProductTypeName_By_Id(prods[0].ProductTypeId),
                                                             prods[0].ProductName,
                                                             prods[0].OutUnitPrice.ToString()
                            });
                                /* if (ptype.IsBatchDonation)
                                 {
                                     this.dgvData.Rows[dgvData.RowCount - 2].Cells[3].Style.BackColor = Color.Green;
                                 }
                                 if (ptype.IsBatchDiscount)
                                 {
                                     this.dgvData.Rows[dgvData.RowCount - 2].Cells[4].Style.BackColor = Color.Green;
                                 }*/
                                this.dgvDataTo.FirstDisplayedScrollingRowIndex = dgvDataTo.RowCount - 1;
                            }

                        }
                    }
                }
            }
        }

        private void Load_PromoType_Combo_Contents()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            ppTypes.Clear();
            ppTypes = dbPOS.Get_All_PromoTypelkups();
            if (ppTypes.Count > 0)
            {
                int i = 0;
                foreach (var pptype in ppTypes)
                {
                    cb_PromoType.Items.Add(pptype.PromoTypeName);
                }
            }
        }
        private void Load_Promotion_Info(string strPromoId)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            ppromos.Clear();
            ppromos = dbPOS.Get_Promotion_By_ID(int.Parse(strPromoId));
            if (ppromos.Count == 1)
            {
                txt_PromoID.Text = ppromos[0].Id.ToString();
                txt_PromoName.Text = ppromos[0].PromoName;
                cb_PromoType.SelectedIndex = cb_PromoType.FindStringExact(dbPOS.Get_PromoTypelkupName_By_Id(ppromos[0].PromoType));
                txt_PromoValue.Text = ppromos[0].PromoValue.ToString();
                txt_PromoQTY.Text = ppromos[0].PromoQTY.ToString();
                dttm_PromoStart.Text = ppromos[0].PromoStartDttm.ToString();
                dttm_PromoEnd.Text = ppromos[0].PromoEndDttm.ToString();
                bt_AddOne.Enabled = true;
                bt_Delete.Enabled = true;
            }
            else
            {
                bt_AddOne.Enabled = false;
                bt_Delete.Enabled = false;
            }
        }
        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_PromoID.Text))
            {
                Insert_Promotion_From_View();
            }
            else
            {
                Update_Promotion_From_View();
            }
        }
        private void Update_Promotion_From_View()
        {
            float fValuePrice = 0;
            int iQTY = 0;
            DataAccessPOS dbPOS = new DataAccessPOS();

            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigDesc.Text)) txt_ConfigDesc.Text = "";
            int ipTypeId = 0;
            if (cb_PromoType.SelectedItem != null)
            {
                ppTypes = dbPOS.Get_PromoTypelkup_By_PromoTypeName(cb_PromoType.SelectedItem.ToString());
                if (ppTypes.Count == 1)
                {
                    ipTypeId = ppTypes[0].Id;
                }
            }
            ppromos.Clear();
            if (txt_PromoValue.Text != "")
            {
                fValuePrice = float.Parse(txt_PromoValue.Text);
            }
            if (txt_PromoQTY.Text != "")
                iQTY = int.Parse(txt_PromoQTY.Text);
            ppromos.Add(new POS_PromotionModel()
            {
                Id = int.Parse(txt_PromoID.Text),
                PromoName = txt_PromoName.Text,
                PromoType = ipTypeId,
                PromoValue = (float)Math.Round(fValuePrice,2),
                PromoQTY = iQTY,
                PromoStartDttm = dttm_PromoStart.Value,
                PromoEndDttm = dttm_PromoEnd.Value
            });
            int iCnt = dbPOS.Update_Promotion(ppromos[0]);
            // Need to rebuild PromoProducts table for the promotion
            // Remove existing promoproducts and add again from dgvPromoTo
            //xxx
            txtMessage.Text = "Promotion successfully Updated : " + txt_PromoName.Text;
            txtMessage.ForeColor = Color.White;
        }

        private void Insert_Promotion_From_View()
        {
            DataAccessPOS dbPOS = new DataAccessPOS();
            float fValuePrice = 0;
            int iQTY = 0;
            //if (String.IsNullOrEmpty(txt_ConfigName.Text)) txt_ConfigName.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigValue.Text)) txt_ConfigValue.Text = "";
            //if (String.IsNullOrEmpty(txt_ConfigDesc.Text)) txt_ConfigDesc.Text = "";
            int ipTypeId = 0;
            if (cb_PromoType.SelectedItem != null)
            {
                ppTypes = dbPOS.Get_PromoTypelkup_By_PromoTypeName(cb_PromoType.SelectedItem.ToString());
                if (ppTypes.Count == 1)
                {
                    ipTypeId = ppTypes[0].Id;
                }
            }
            ppromos.Clear();
            if (txt_PromoValue.Text != "")
            {
                fValuePrice = float.Parse(txt_PromoValue.Text);
            }
            if (txt_PromoQTY.Text != "")
                iQTY = int.Parse(txt_PromoQTY.Text);
            ppromos.Add(new POS_PromotionModel()
            {
                Id = 0,
                PromoName = txt_PromoName.Text,
                PromoType = ipTypeId,
                PromoValue = (float)Math.Round(fValuePrice,2),
                PromoQTY = iQTY,
                PromoStartDttm = dttm_PromoStart.Value,
                PromoEndDttm = dttm_PromoEnd.Value
            });
            int iPromoId = dbPOS.Insert_Promotion(ppromos[0]);
            if (iPromoId > 0)
            {
                txt_PromoID.Text = iPromoId.ToString();
                bt_AddOne.Enabled = true;
                AddPromotionProducts(iPromoId);
            }
            txtMessage.Text = "Promotion successfully Added : " + txt_PromoName.Text;
            txtMessage.ForeColor = Color.White;

        }

        private void AddPromotionProducts(int p_iPromoId)
        {
            if (dgvDataTo.RowCount > 1)
            {
                foreach(DataGridViewRow row in dgvDataTo.Rows)
                {
                    if (row.IsNewRow) continue;
                    pprods.Clear();
                    pprods.Add(new POS_PromoProductsModel()
                    {
                        PromoId = p_iPromoId,
                        ProdId = Convert.ToInt32(row.Cells[0].Value.ToString())
                    });
                    DataAccessPOS dbPOS = new DataAccessPOS();
                    dbPOS.Insert_PromoProduct(pprods[0]);
                }
            }
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
            DataAccessPOS dbPOS = new DataAccessPOS();
            bool bIsPromoExist = dbPOS.Check_Assorted_PromotionName(txt_PromoName.Text);
            if (bIsPromoExist)
            {
                MessageBox.Show("Promotion Name already exists. Please use another name!");
                return;
            }
            Insert_Promotion_From_View();
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            int iSelectedPromoId = Convert.ToInt32(txt_PromoID.Text);
            if (iSelectedPromoId > 0)
            {
                DataAccessPOS dbPOS = new DataAccessPOS();
                dbPOS.Delete_Promotion_By_Id(iSelectedPromoId);
                dbPOS.Delete_PromoProducts_By_PromoId(iSelectedPromoId);
                bt_Exit.PerformClick();
            }
        }
        private void dgvDataFrom_Initialize()
        {
            this.dgvDataFrom.AutoSize = false;
            dgvDataFrom.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            this.dgvDataFrom.MultiSelect = true;
            this.dgvDataFrom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataFrom.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDataFrom.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvDataFrom.ColumnCount = 4;
            this.dgvDataFrom.Columns[0].Name = "Id";
            this.dgvDataFrom.Columns[0].Width = 60;
            this.dgvDataFrom.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataFrom.Columns[1].Name = "Type Name";
            this.dgvDataFrom.Columns[1].Width = 100;
            this.dgvDataFrom.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataFrom.Columns[2].Name = "Product Name";
            this.dgvDataFrom.Columns[2].Width = 150;
            this.dgvDataFrom.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataFrom.Columns[3].Name = "Price";
            this.dgvDataFrom.Columns[3].Width = 70;
            this.dgvDataFrom.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvDataFrom.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
            this.dgvDataFrom.EnableHeadersVisualStyles = false;
            this.dgvDataFrom.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvDataFrom.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataFrom.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvDataFrom.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDataFrom.AllowUserToResizeRows = false;
            dgvDataFrom.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvDataFrom.RowTemplate.MinimumHeight = 40;
        }
        private void dgvDataTo_Initialize()
        {
            this.dgvDataTo.AutoSize = false;
            dgvDataTo.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvDataTo.MultiSelect = true;
            this.dgvDataTo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataTo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDataTo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvDataTo.ColumnCount =4;
            this.dgvDataTo.Columns[0].Name = "Id";
            this.dgvDataTo.Columns[0].Width = 60;
            this.dgvDataTo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataTo.Columns[1].Name = "Type Name";
            this.dgvDataTo.Columns[1].Width = 100;
            this.dgvDataTo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataTo.Columns[2].Name = "Product Name";
            this.dgvDataTo.Columns[2].Width = 150;
            this.dgvDataTo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataTo.Columns[3].Name = "Price";
            this.dgvDataTo.Columns[3].Width = 70;
            this.dgvDataTo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvDataTo.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
            this.dgvDataTo.EnableHeadersVisualStyles = false;
            this.dgvDataTo.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16F, GraphicsUnit.Pixel);
            this.dgvDataTo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDataTo.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvDataTo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDataTo.AllowUserToResizeRows = false;
            dgvDataTo.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvDataTo.RowTemplate.MinimumHeight = 40;
        }

        private void bt_Add_All_Click(object sender, EventArgs e)
        {

        }

        private void bt_AddOne_Click(object sender, EventArgs e)
        {
            String strSelProdId = String.Empty;
            String strSelProdPrice = String.Empty;


            Int32 selectedRowCount = dgvDataFrom.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    sb.Append("Row: ");
                    sb.Append(dgvDataFrom.SelectedRows[i].Index.ToString());
                    sb.Append(Environment.NewLine);
                }

                sb.Append("Total: " + selectedRowCount.ToString());
                txtMessage.Text = sb.ToString() + "Selected Rows";

                for (int i = 0; i < selectedRowCount; i++)
                { 
                    if (dgvDataFrom.Rows[dgvDataFrom.SelectedRows[i].Index].Cells[0].Value == null)
                    {
                        strSelProdId = String.Empty;
                    }
                    else
                    {
                        strSelProdId = dgvDataFrom.Rows[dgvDataFrom.SelectedRows[i].Index].Cells[0].Value.ToString();
                        strSelProdPrice = dgvDataFrom.Rows[dgvDataFrom.SelectedRows[i].Index].Cells[3].Value.ToString();
                        Move_dgvDataFrom_dgvDataTo(dgvDataFrom.SelectedRows[i].Index, strSelProdId, Convert.ToDouble(strSelProdPrice));
                    }
                }

                //Load_PromoProducts_DataGrid();
            }
        }

        private void Move_dgvDataFrom_dgvDataTo(int iFromRowIndex, string strSelProdId, double dblProdPrice)
        {
            // copy the selected row to the other datagridview
            dgvDataTo.Rows.Add(new String[] { dgvDataFrom.Rows[iFromRowIndex].Cells[0].Value.ToString(),
                                                         dgvDataFrom.Rows[iFromRowIndex].Cells[1].Value.ToString(),
                                                         dgvDataFrom.Rows[iFromRowIndex].Cells[2].Value.ToString(),
                                                         dgvDataFrom.Rows[iFromRowIndex].Cells[3].Value.ToString()
            });

        }

        private void bt_DelOne_Click(object sender, EventArgs e)
        {
            String strSelProdId = String.Empty;


            Int32 selectedRowCount = dgvDataTo.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    sb.Append("Row: ");
                    sb.Append(dgvDataTo.SelectedRows[i].Index.ToString());
                    sb.Append(Environment.NewLine);
                    strSelProdId = dgvDataTo.Rows[dgvDataTo.SelectedRows[i].Index].Cells[0].Value.ToString();
                    Move_dgvDataTod_gvDataFrom(strSelProdId, i);
                }

                sb.Append("Total: " + selectedRowCount.ToString());
                txtMessage.Text = "Selected Rows = " + selectedRowCount.ToString();
                for (int i = 0; i < selectedRowCount; i++)
                {
                    if (dgvDataTo.Rows[dgvDataTo.SelectedRows[i].Index].Cells[0].Value == null)
                    {
                        strSelProdId = String.Empty;
                    }
                    else
                    {
                        //strSelProdId = dgvDataTo.Rows[dgvDataFrom.SelectedRows[i].Index].Cells[0].Value.ToString();
                        dgvDataTo.Rows.RemoveAt(dgvDataTo.SelectedRows[i].Index);


                    }
                }
            }
            //Load_PromoProducts_DataGrid();
        }
        private void Move_dgvDataTod_gvDataFrom(string strSelProdId, int i)
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            int iSelectedPromoId = Convert.ToInt32(txt_PromoID.Text);
            pprods.Clear();
            pprods.Add(new POS_PromoProductsModel()
            {
                PromoId = iSelectedPromoId,
                ProdId = Convert.ToInt32(strSelProdId)
            });

            if (dbPOS.Check_PromoProducts(pprods[0]))
            {
                dbPOS.Delete_PromoProducts(pprods[0]);
            }
            //dgvDataFrom.Rows.RemoveAt(dgvDataFrom.SelectedRows[i].Index);
        }

        private void bt_DelAll_Click(object sender, EventArgs e)
        {

        }


    }
}
