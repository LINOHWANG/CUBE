using Dapper;
using SDCafeCommon.Model;
using SDCafeCommon.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SDCafeCommon.DataAccess
{
    public class DataAccessPOS
    {
        Utility util = new Utility();
        public List<POS_LoginUserModel> UserLogin(string passWord)
        {
            ////////////////////////////////////////////////////
            // To connect to SQL Server
            // Open the door to the database
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                try
                {
                    var output = connection.Query<POS_LoginUserModel>($"select * from LoginUser where PassWord = '{passWord}'").ToList();
                    return output;
                }
                catch (System.Data.SqlTypes.SqlTypeException ex)
                {
                    util.Logger(ex.Message);
                }
                catch (SqlException ex)
                {
                    util.Logger(ex.Message);
                }
                catch (Exception ex)
                {
                    util.Logger(ex.Message);
                }
                return null;
            }
        }
        public List<POS_PromotionModel> Get_Promotion_By_ID(int iPromoId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_PromotionModel>($"select * from Promotion where id = {iPromoId}").ToList();
                return output;
            }
        }

        public List<POS_PromoTypelkupModel> Get_All_PromoTypelkups()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_PromoTypelkupModel>($"select * from PromoTypelkup").ToList();
                return output;
            }
        }

        public List<POS_PromoTypelkupModel> Get_PromoTypelkup_By_ID(int iPromoTypeId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_PromoTypelkupModel>($"select * from PromoTypelkup where id = {iPromoTypeId}").ToList();
                return output;
            }
        }
        public string Get_PromoTypelkupName_By_Id(int iPromoTypeId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_PromoTypelkupModel>($"SELECT * FROM PromoTypelkup WHERE id= {iPromoTypeId} ").ToList();
                if (output.Count > 0)
                {
                    return output[0].PromoTypeName;
                }
                return "";
            }
        }

        public List<POS_PromoProductsModel> Get_PromoProducts_By_PromoId(int iPromoId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_PromoProductsModel>($"select * from PromoProducts where PromoId = {iPromoId}").ToList();
                return output;
            }
        }

        public List<POS_ProductTypeModel> Get_ProductType_By_ID(int iTypeID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductTypeModel>($"select * from ProductType where id = {iTypeID}").ToList();
                return output;
            }
        }

        public List<POS_PromoTypelkupModel> Get_PromoTypelkup_By_PromoTypeName(string strPromoTypeName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_PromoTypelkupModel>($"select * from PromoTypelkup where PromoTypeName = '{strPromoTypeName}'").ToList();
                return output;
            }
        }

        public List<POS_LoginUserModel> Get_LoginUser_By_ID(int iLoginUserID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_LoginUserModel>($"select * from LoginUser where id = {iLoginUserID}").ToList();
                return output;
            }
        }

        public int Update_Promotion(POS_PromotionModel pOS_PromotionModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "UPDATE Promotion SET PromoName = @PromoName, PromoType=@PromoType, PromoValue1=CAST(@PromoValue1 as decimal(10,2)), PromoQTY1=@PromoQTY1, " +
                                "PromoValue2=CAST(@PromoValue2 as decimal(10,2)), PromoQTY2=@PromoQTY2, " +
                                "PromoStartDttm=@PromoStartDttm, PromoEndDttm = @PromoEndDttm " +
                                "WHERE Id=@Id";
                var count = connection.Execute(query, pOS_PromotionModel);
                return count;
            }
        }

        public List<POS_StationModel> Get_Station_By_Station(string p_Station)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_StationModel>($"select * from Station where Station = '{p_Station}'").ToList();
                return output;
            }
        }

        public List<POS_SysConfigModel> Get_SysConfig_By_ID(int iConfigID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_SysConfigModel>($"select * from SysConfig where id = {iConfigID}").ToList();
                return output;
            }
        }
        public List<POS_SysConfigModel> Get_SysConfig_By_NameContains(string strConfigName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_SysConfigModel>($"select * from SysConfig where ConfigName like '%{strConfigName}%'").ToList();
                return output;
            }
        }
        public List<POS_SysConfigModel> Get_SysConfig_By_Name(string strConfigName)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
                {
                    var output = connection.Query<POS_SysConfigModel>($"select * from SysConfig where ConfigName = '{strConfigName}'").ToList();
                    if (output.Count == 0)
                    {
                        if (strConfigName.Contains("IS_"))
                            Insert_SysConfig(new POS_SysConfigModel { ConfigName = strConfigName, ConfigValue = "TRUE", ConfigDesc = "", IsActive = true });
                        else
                            Insert_SysConfig(new POS_SysConfigModel { ConfigName = strConfigName, ConfigValue = "99", ConfigDesc = "", IsActive = true });
                        output = connection.Query<POS_SysConfigModel>($"select * from SysConfig where ConfigName = '{strConfigName}'").ToList();
                    }
                    return output;
                }
            }
            catch (Exception ex)
            {
                util.Logger(ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
            return null;
        }
        public List<POS_SysConfigModel> Get_SysConfig_By_NamePart(string strConfigName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                // change strConfigName to capital letter
                strConfigName = strConfigName.ToUpper();
                var output = connection.Query<POS_SysConfigModel>($"select * from SysConfig where ConfigName like '%{strConfigName}%'").ToList();
                return output;
            }
        }
        public int Insert_Promotion(POS_PromotionModel pOS_PromotionModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO Promotion (PromoName, PromoType, PromoValue1, PromoQTY1,PromoValue2, PromoQTY2, PromoStartDttm, PromoEndDttm) " +
                                    "VALUES (@PromoName, @PromoType, CAST(@PromoValue1 as decimal(10,2)), @PromoQTY1, CAST(@PromoValue2 as decimal(10,2)), @PromoQTY2, " +
                                    "@PromoStartDttm, @PromoEndDttm);" +
                                    "SELECT CAST(SCOPE_IDENTITY() as int)";
                //var id = connection.Execute(query, pOS_PromotionModel);
                var id = connection.QuerySingle<int>(query, pOS_PromotionModel);
                return id;
            }
        }

        public int Delete_Promotion_By_Id(int iSelectedPromoId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "DELETE from Promotion WHERE id=" + iSelectedPromoId;
                var count = connection.Execute(query);
                return count;
            }
        }

        public string Get_ProductTypeName_By_Id(int productTypeId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductTypeModel>($"SELECT * FROM ProductType WHERE id= {productTypeId} ").ToList();
                if (output.Count > 0)
                {
                    return output[0].TypeName;
                }
                return "";
            }
        }
        public string Get_CategoryName_By_Id(int p_catId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_CategoryModel>($"SELECT * FROM Category WHERE id= {p_catId} ").ToList();
                if (output.Count > 0)
                {
                    return output[0].CategoryName;
                }
                return "";
            }
        }
        public int Update_ProductType(POS_ProductTypeModel pOS_ProductTypeModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "UPDATE ProductType SET TypeName = @TypeName, IsLiquor=@IsLiquor, SortOrder=@SortOrder , IsRestaurant=@IsRestaurant, " +
                                "IsBatchDonation=@IsBatchDonation, IsBatchDiscount=@IsBatchDiscount, " +
                                "ForeColor=@ForeColor, BackColor=@BackColor " +
                                "WHERE Id=@Id";
                var count = connection.Execute(query, pOS_ProductTypeModel);
                return count;
            }
        }

        public int Update_Station(POS_StationModel pos_StationModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                if (pos_StationModel.Client_Id.Length > 10)
                {
                    pos_StationModel.Client_Id = pos_StationModel.Client_Id.Substring(0, 10);
                }
                if (pos_StationModel.Location.Length > 6)
                {
                    pos_StationModel.Location = pos_StationModel.Location.Substring(0, 6);
                }
                if (pos_StationModel.Register.Length > 6)
                {
                    pos_StationModel.Register = pos_StationModel.Register.Substring(0, 6);
                }
                string query = "UPDATE Station SET Station = @Station, StationName=@StationName, IP_Addr=@IP_Addr, StationNo=@StationNo, IPS_Port = @IPS_Port, Enabled=@Enabled, " +
                                "IsPaymentree = @IsPaymentree, Client_Id = @Client_Id, Location = @Location, Register = @Register " +
                                "WHERE ComputerName=@ComputerName";
                var count = connection.Execute(query, pos_StationModel);
                return count;
            }
        }

        public List<POS_ProductModel> Get_All_Products()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"select * from Product").ToList();
                return output;
            }
        }
        //public List<POS_ProductModel> Get_All_Products_Sortby_Name(bool p_bIsManual, bool p_bIsMainSales, bool p_bIsSales)
        public List<POS_ProductModel> Get_All_Products_Sortby_Name(bool p_bIsManual)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = $"select * from Product ";
                string strWhere = "";
                if (p_bIsManual)
                    strWhere += " Where ISNULL(IsManualItem,0) = " + (p_bIsManual ? "1" : "0");
                //" OR ISNULL(IsMainSalesButton,0) = " + (p_bIsMainSales ? "1" : "0") +
                //" OR ISNULL(IsSalesButton,0) = " + (p_bIsSales ? "1" : "0");
                string strOrderby = " Order By IsManualItem Desc, ProductName";
                query += strWhere + strOrderby;
                var output = connection.Query<POS_ProductModel>(query).ToList();
                return output;
            }
        }

        public int Delete_PromoProducts_By_PromoId(int iSelectedPromoId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "DELETE from PromoProducts WHERE Promoid=" + iSelectedPromoId;
                var count = connection.Execute(query);
                return count;
            }
        }

        public List<POS_ProductModel> Get_All_Products_OrderBy_Type_ProdName()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"SELECT *  FROM Product order by ProductTypeId, ProductName").ToList();
                return output;
            }
        }
        public int Insert_ProductType(POS_ProductTypeModel pOS_ProductTypeModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO ProductType (TypeName, IsLiquor, SortOrder, IsRestaurant, IsBatchDonation, IsBatchDiscount, ForeColor, BackColor) " +
                                    "VALUES (@TypeName, @IsLiquor, @SortOrder, @IsRestaurant, @IsBatchDonation, @IsBatchDiscount, @ForeColor, @BackColor)";
                var count = connection.Execute(query, pOS_ProductTypeModel);
                return count;
            }
        }

        public List<POS_TimeTableModel> Get_Today_ClockInOut(int iUserId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string strNow = DateTime.Now.ToString("yyyy/MM/dd") + " 00:00:00";
                string query = "select * from TimeTable where UserId = " + iUserId.ToString() + " And DateTimeStarted >= '" + strNow + "' And DateTimeFinished Is NULL";
                var output = connection.Query<POS_TimeTableModel>(query).ToList();
                return output;
            }
        }
        public List<POS_TimeTableModel> Get_All_Today_ClockInOut()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string strNow = DateTime.Now.ToString("yyyy/MM/dd") + " 00:00:00";
                string query = "select * from TimeTable where DateTimeStarted >= '" + strNow + "' And DateTimeFinished Is NULL order by DateTimeStarted desc;";
                var output = connection.Query<POS_TimeTableModel>(query).ToList();
                return output;
            }
        }
        public List<POS_TimeTableModel> Get_TimeTable_by_Date(string strStartDate, string strEndDate, bool m_blnUnresolved)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "";
                if (m_blnUnresolved)
                    query = $"select * from TimeTable where DateTimeStarted >= '{strStartDate}' and DateTimeStarted <= '{strEndDate}'  " +
                                            "And DateTimeFinished Is NULL " +
                                            "order by DateTimeStarted, UserId";
                else
                    query = $"select * from TimeTable where DateTimeStarted >= '{strStartDate}' and DateTimeStarted <= '{strEndDate}' " +
                                            "And DateTimeFinished Is NOT NULL " +
                                            "order by DateTimeStarted, UserId";
                var output = connection.Query<POS_TimeTableModel>(query).ToList();
                return output;
            }
        }
        public List<POS_TimeTableModel> Get_TimeTable_by_Date_UserId(string strStartDate, string strEndDate, int iUserId, bool m_blnUnresolved)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "";
                if (m_blnUnresolved)
                    query = $"select * from TimeTable where UserId = " + iUserId.ToString() +
                                          "And DateTimeStarted >= '" + strStartDate + "' and DateTimeStarted <= '" + strEndDate + "' " +
                                          "And DateTimeFinished Is NULL " +
                                          "order by DateTimeStarted";
                else
                    query = $"select * from TimeTable where UserId = " + iUserId.ToString() +
                                          "And DateTimeStarted >= '" + strStartDate + "' and DateTimeStarted <= '" + strEndDate + "' " +
                                          "And DateTimeFinished Is NOT NULL " +
                                          "order by DateTimeStarted";
                var output = connection.Query<POS_TimeTableModel>(query).ToList();
                return output;
            }
        }
        public int Insert_TimeTable(POS_TimeTableModel pos_TimeTableModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO TimeTable (UserId, DateTimeStarted, DateTimeFinished, InCount, Wage) " +
                                    "VALUES (@UserId, @DateTimeStarted, @DateTimeFinished, @InCount, @Wage)";
                var count = connection.Execute(query, pos_TimeTableModel);
                return count;
            }
        }
        public int Update_TimeTable(POS_TimeTableModel pos_TimeTableModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "UPDATE TimeTable Set DateTimeStarted=@DateTimeStarted, DateTimeFinished=@DateTimeFinished " +
                                    "WHERE UserId=@UserId";
                var count = connection.Execute(query, pos_TimeTableModel);
                return count;
            }
        }

        public int Insert_Station(POS_StationModel pOS_StationModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO Station (ComputerName, Station, StationName, IP_Addr, StationNo, IPS_Port, Enabled, IsPaymenree, Client_Id, Location, Register) " +
                                    "VALUES (@ComputerName, @Station, @StationName, @IP_Addr, @StationNo, @IPS_Port, @Enabled, @IsPaymenree, @Client_Id, @Location, @Register)";
                var count = connection.Execute(query, pOS_StationModel);
                return count;
            }
        }


        public List<POS_ProductModel> Get_Product_By_ID(int prodID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"select * from Product where id = {prodID}").ToList();
                return output;
            }
        }

        public POS_ProductModel Get_One_Product_By_ID(int prodID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"select * from Product where id = {prodID}").ToList();
                if (output.Count > 0)
                    return output[0];
                else
                    return null;
            }
        }

        public List<POS_ProductModel> Get_Product_By_BarCode(string strBarCode)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"select * from Product where BarCode = '{strBarCode}'").ToList();
                return output;
            }
        }


        public List<POS_StationModel> Get_Station_By_HostName(string pHostName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_StationModel>($"select * from Station where ComputerName = '{pHostName}'").ToList();
                return output;
            }
        }

        public List<POS_ProductTypeModel> Get_All_ProductTypes()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductTypeModel>($"select * from ProductType order by SortOrder, TypeName").ToList();
                return output;
            }
        }
        public List<POS_TaxModel> Get_All_Tax()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_TaxModel>($"select * from Tax").ToList();
                return output;
            }
        }

        public int Update_LoginUser(POS_LoginUserModel pos_LoginUserModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "UPDATE LoginUser SET FirstName = @FirstName, LastName=@LastName, NickName=@NickName, " +
                                "DOB=@DOB, MobilePhone=@MobilePhone, Address=@Address, Department=@Department, Grade=@Grade, Wage=@Wage, " +
                                "PassWord=@PassWord, DateTimeCreated=@DateTimeCreated, DateTimeUpdated=@DateTimeUpdated, " +
                                "IsActive=@IsActive WHERE Id=@Id";
                var count = connection.Execute(query, pos_LoginUserModel);
                return count;
            }
        }
        public List<POS_OrdersModel> Get_All_Orders_by_Station(string strStation)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where CreateStation = '{strStation}'").ToList();
                return output;
            }
        }
        public List<POS_OrdersModel> Get_ParentOrders_by_Station(string strStation)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where CreateStation = '{strStation}' and ParentId = 0").ToList();
                return output;
            }
        }
        public List<POS_OrdersModel> Get_ChildOrders_by_Station(string strStation, int iParentId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where ParentId = {iParentId}").ToList();
                return output;
            }
        }
        public int Update_SysConfig(POS_SysConfigModel pos_SysConfigModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "UPDATE SysConfig SET ConfigName = @ConfigName, ConfigValue=@ConfigValue, ConfigDesc=@ConfigDesc, " +
                                "IsActive=@IsActive WHERE Id=@Id";
                var count = connection.Execute(query, pos_SysConfigModel);
                return count;
            }
        }

        public int Insert_LoginUser(POS_LoginUserModel pos_LoginUserModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO  LoginUser(FirstName, LastName, NickName,DOB, MobilePhone, Address, Department, " +
                                "Grade, Wage, PassWord, DateTimeCreated, DateTimeUpdated,IsActive) " +
                                "VALUES (@FirstName,@LastName,@NickName,@DOB,@MobilePhone,@Address,@Department,@Grade,@Wage,@PassWord, " +
                                "@DateTimeCreated,@DateTimeUpdated,@IsActive)";
                var count = connection.Execute(query, pos_LoginUserModel);
                return count;
            }
        }

        public int Insert_SysConfig(POS_SysConfigModel pos_SysConfigModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO SysConfig (ConfigName, ConfigValue, ConfigDesc, IsActive) " +
                                "VALUES (@ConfigName,@ConfigValue,@ConfigDesc,@IsActive)";
                var count = connection.Execute(query, pos_SysConfigModel);
                return count;
            }
        }

        public bool Check_PromoProducts(POS_PromoProductsModel pPromoProd)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_RFIDTagsModel>($"select * from PromoProducts where PromoId = {pPromoProd.PromoId} and ProdId = {pPromoProd.ProdId}").ToList();
                if (output.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        public double Get_The_First_Product_Price_From_PromoProduct(int iSelectedPromoId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                double dblUnitPrice = 0;
                string query = "SELECT * FROM PRODUCT WHERE Id = (Select top 1 ProdId from PromoProducts where promoid=" + iSelectedPromoId + ")";
                var output = connection.Query<POS_ProductModel>(query).ToList();
                if (output.Count > 0)
                {
                    dblUnitPrice = (double)output[0].OutUnitPrice;
                }
                return dblUnitPrice;
            }
        }

        public int Insert_PromoProduct(POS_PromoProductsModel pOS_PromoProductsModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO PromoProducts (PromoId, ProdId) " +
                                "VALUES (@PromoId, @ProdId)";
                var count = connection.Execute(query, pOS_PromoProductsModel);
                return count;
            }
        }

        public int Delete_Product_By_Id(int iSelectedProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "DELETE from Product WHERE id=" + iSelectedProdId;
                var count = connection.Execute(query);
                return count;
            }
        }

        public int Delete_ProductType_By_Id(int iSelectedProdTypeId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "DELETE from ProductType WHERE id=" + iSelectedProdTypeId;
                var count = connection.Execute(query);
                return count;
            }
        }

        public int Delete_PromoProducts(POS_PromoProductsModel pPromoProd)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "DELETE from PromoProducts WHERE PromoId=" + pPromoProd.PromoId + " And ProdId=" + pPromoProd.ProdId;
                var count = connection.Execute(query);
                return count;
            }
        }

        public List<POS_ProductTypeModel> Get_ProductTypeId_By_TypeName(string prodTypeName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductTypeModel>($"select * from ProductType where TypeName = '{prodTypeName}'").ToList();
                return output;
            }

        }

        public List<POS_LoginUserModel> Get_All_LoginUsers()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_LoginUserModel>($"select * from LoginUser").ToList();
                return output;
            }
        }

        public int Insert_Product(POS_ProductModel pos_ProductModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                if (pos_ProductModel.ProductName.Length > 100)
                {
                    pos_ProductModel.ProductName = pos_ProductModel.ProductName.Substring(0, 100);
                }
                if (pos_ProductModel.SecondName.Length > 100)
                {
                    pos_ProductModel.SecondName = pos_ProductModel.SecondName.Substring(0, 100);
                }
                string query = "INSERT INTO Product (ProductName, SecondName, ProductTypeId, " +
                            "InUnitPrice, OutUnitPrice, IsTax1, IsTax2, IsTax3, IsTaxInverseCalculation, " +
                            "PromoStartDate, PromoEndDate, PromoDay1, PromoDay2, PromoDay3, " +
                            "IsPrinter1, IsPrinter2, IsPrinter3, IsPrinter4, IsPrinter5, " +
                            "PromoPrice1, PromoPrice2, PromoPrice3, IsSoldOut, Deposit, RecyclingFee, ChillCharge, MemoText, BarCode, TaxCode, " +
                            "IsManualItem, Balance,IsMainSalesButton, IsSalesButton, ForeColor, BackColor, " +
                            "CategoryId, IsButtonInButton, Brand, Size, IsPromoExactQty ) " +
                            "VALUES(@ProductName,@SecondName,@ProductTypeId,CAST(@OutUnitPrice as decimal(10,2)),CAST(@OutUnitPrice as decimal(10,2)),@IsTax1,@IsTax2,@IsTax3,@IsTaxInverseCalculation, " +
                            "@PromoStartDate,@PromoEndDate,@PromoDay1,@PromoDay2,@PromoDay3,@IsPrinter1,@IsPrinter2,@IsPrinter3,@IsPrinter4,@IsPrinter5," +
                            "CAST(@PromoPrice1 as decimal(10,3)),CAST(@PromoPrice2 as decimal(10,3)),CAST(@PromoPrice3 as decimal(10,3)),@IsSoldOut," +
                            "CAST(@Deposit as decimal(10,2)),CAST(@RecyclingFee as decimal(10,2)),CAST(@ChillCharge as decimal(10,2)), @MemoText, @BarCode, @TaxCode, " +
                            "@IsManualItem, @Balance, @IsMainSalesButton,@IsSalesButton, @ForeColor,  " +
                            "@BackColor, @CategoryId, @IsButtonInButton , @Brand, @Size, @IsPromoExactQty); " +
                            "SELECT CAST(SCOPE_IDENTITY() as int)";
                //var count = connection.Execute(query, pos_ProductModel);
                var id = connection.QuerySingle<int>(query, pos_ProductModel);
                return id;
            }

        }

        public int Update_Product(POS_ProductModel pos_ProductModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                if (pos_ProductModel.ProductName.Length > 100)
                {
                    pos_ProductModel.ProductName = pos_ProductModel.ProductName.Substring(0, 100);
                }
                if (pos_ProductModel.SecondName.Length > 100)
                {
                    pos_ProductModel.SecondName = pos_ProductModel.SecondName.Substring(0, 100);
                }
                string query = "UPDATE Product SET ProductName = @ProductName, SecondName=@SecondName, ProductTypeId=@ProductTypeId, " +
                                "InUnitPrice=CAST(@InUnitPrice as decimal(10,2)),OutUnitPrice=CAST(@OutUnitPrice as decimal(10,2)), IsTax1=@IsTax1, IsTax2=@IsTax2, IsTax3=@IsTax3, IsTaxInverseCalculation=@IsTaxInverseCalculation, " +
                                "PromoStartDate=@PromoStartDate, PromoEndDate=@PromoEndDate, PromoDay1=@PromoDay1, PromoDay2=@PromoDay2, PromoDay3=@PromoDay3, " +
                                "IsPrinter1=@IsPrinter1, IsPrinter2=@IsPrinter2, IsPrinter3=@IsPrinter3, IsPrinter4=@IsPrinter4, IsPrinter5=@IsPrinter5, " +
                                "PromoPrice1=CAST(@PromoPrice1 as decimal(10,3)), PromoPrice2=CAST(@PromoPrice2 as decimal(10,3)), PromoPrice3=CAST(@PromoPrice3 as decimal(10,3)), IsSoldOut=@IsSoldOut, " +
                                "Deposit=CAST(@Deposit as decimal(10,2)), RecyclingFee=CAST(@RecyclingFee as decimal(10,2)),ChillCharge=CAST(@ChillCharge as decimal(10,2)), MemoText=@MemoText, " +
                                "BarCode=@BarCode, TaxCode=@TaxCode, IsManualItem=@IsManualItem, Balance=@Balance,IsMainSalesButton = @IsMainSalesButton, IsSalesButton=@IsSalesButton, ForeColor = @ForeColor, BackColor = @BackColor,  " +
                                "CategoryId=@CategoryId, IsButtonInButton=@IsButtonInButton, Brand=@Brand, Size = @Size, IsPromoExactQty = @IsPromoExactQty  " +
                                "WHERE Id = @Id";
                var count = connection.Execute(query, pos_ProductModel);
                return count;
            }
        }

        public List<POS_SysConfigModel> Get_All_SysConfigs()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_SysConfigModel>($"select * from SysConfig").ToList();
                return output;
            }
        }

        public List<POS_RFIDTagsModel> Get_All_RFIDTags()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_RFIDTagsModel>($"select * from RFIDTags").ToList();
                return output;
            }
        }

        public List<POS_RFIDTagsModel> Get_All_UnUsed_RFIDTags()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_RFIDTagsModel>($"select * from RFIDTags where IsUsed=0").ToList();
                return output;
            }
        }


        public bool Check_ProdType_AbleTo_Donate(int iProdTypeId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductTypeModel>($"select * from ProductType where id = {iProdTypeId} and IsBatchDonation=1 ").ToList();
                if (output.Count > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool Check_ProdType_AbleTo_Discount(int iProdTypeId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductTypeModel>($"select * from ProductType where id = {iProdTypeId} and IsBatchDiscount=1 ").ToList();
                if (output.Count > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool Check_RFIDTag_Exists(string strUid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_RFIDTagsModel>($"select * from RFIDTags where SerialNo = '{strUid}'").ToList();
                if (output.Count > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool Check_RFIDTag_Exists_ById(int iId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_RFIDTagsModel>($"select * from RFIDTags where Id = '{iId}'").ToList();
                if (output.Count > 0)
                    return true;
                else
                    return false;
            }
        }
        public int Insert_RFIDTag(POS_RFIDTagsModel pos_RFIDTagsModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO RFIDTags (ProductId, SerialNo, IsUsed, DateTimeRegistered) " +
                            "VALUES(@ProductId,@SerialNo,0,@DateTimeRegistered) ";
                var count = connection.Execute(query, pos_RFIDTagsModel);
                return count;
            }
        }

        public int Update_RFIDTag(POS_RFIDTagsModel pos_RFIDTagsModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "UPDATE RFIDTags SET ProductId =@ProductId, SerialNo=@SerialNo, IsUsed=@IsUsed, DateTimeRegistered=@DateTimeRegistered, DateTimeUsed=@DateTimeUsed, InvoiceNo=@InvoiceNo " +
                                                " , DiscountRate=@DiscountRate, DateTimeDiscount=@DateTimeDiscount, IsDonation=@IsDonation, DateTimeDonation=@DateTimeDonation " +
                                                " WHERE SerialNo=@SerialNo";
                var count = connection.Execute(query, pos_RFIDTagsModel);
                return count;
            }
        }

        public int Set_RFIDTag_Donation_ByID(POS_RFIDTagsModel pos_RFIDTagsModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "UPDATE RFIDTags SET IsUsed=1, IsDonation=1, DateTimeDonation='" + pos_RFIDTagsModel.DateTimeDonation + "' " +
                               "WHERE Id=" + pos_RFIDTagsModel.Id;
                var count = connection.Execute(query);
                return count;
            }
        }

        public int Set_RFIDTag_Discount_ByID(POS_RFIDTagsModel pos_RFIDTagsModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "UPDATE RFIDTags SET DiscountRate=" + pos_RFIDTagsModel.DiscountRate + ", DateTimeDiscount='" + pos_RFIDTagsModel.DateTimeDiscount + "' " +
                               "WHERE Id=" + pos_RFIDTagsModel.Id;
                var count = connection.Execute(query);
                return count;
            }
        }
        public int Reset_RFIDTag_ByID(int iID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "UPDATE RFIDTags SET IsUsed=0, InvoiceNo=0, DateTimeUsed='' " +
                                " WHERE Id=" + iID;
                var count = connection.Execute(query);
                return count;
            }
        }
        public List<POS_RFIDTagsModel> Get_RFIDTags_By_SerialNo(string strUid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_RFIDTagsModel>($"select * from RFIDTags where SerialNo = '{strUid}'").ToList();
                return output;
            }
        }


        public List<POS_OrdersModel> Get_Order_By_ProdId(int iNewInvNo, int productId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where ProductId = {productId} and InvoiceNo = {iNewInvNo} ").ToList();
                return output;
            }
        }

        public float Get_Order_Amount_By_OrderId(int iNewInvNo, int iOrdersId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"SELECT SUM(Amount) As Amount, SUM(Tax1) As Tax1, SUM(Tax2) As Tax2,SUM(tax3) As Tax3 FROM Orders WHERE InvoiceNo= {iNewInvNo} and Id={iOrdersId}").ToList();
                float fTotalAmount = 0;
                if (output.Count > 0)
                {
                    fTotalAmount = output[0].Amount;
                }
                return fTotalAmount;
            }
        }
        public List<POS_OrdersModel> Get_NonRFID_Order_By_ProdId(int iNewInvNo, int productId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where ProductId = {productId} and InvoiceNo = {iNewInvNo} and RFTagId < 1").ToList();
                return output;
            }
        }
        public List<POS_OrdersModel> Get_NonRFID_NonFixed_Order_By_ProdId(int iNewInvNo, int productId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where ProductId = {productId} and InvoiceNo = {iNewInvNo} and RFTagId < 1 and IsFixedOrder = 0").ToList();
                return output;
            }
        }
        public List<POS_OrdersModel> Get_NonRFID_Fixed_Order_By_ProdId(int iNewInvNo, int productId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where ProductId = {productId} and InvoiceNo = {iNewInvNo} and RFTagId < 1 and IsFixedOrder = 1").ToList();
                return output;
            }
        }
        public List<POS_OrdersModel> Get_NonRFID_Order_By_OrderId(int iNewInvNo, int iOrderId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where Id = {iOrderId} and InvoiceNo = {iNewInvNo} and RFTagId < 1").ToList();
                return output;
            }
        }
        public List<POS_OrdersModel> Get_Order_By_Invoice_RFTagId(int iNewInvNo, int rfTagId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where RFTagId = {rfTagId} and InvoiceNo = {iNewInvNo} ").ToList();
                return output;
            }
        }
        public int Delete_Order_By_RFTagID(int iNewInvNo, int iRFTagId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "DELETE from Orders WHERE RFTagId=" + iRFTagId + " and InvoiceNo = " + iNewInvNo;
                var count = connection.Execute(query);
                return count;
            }
        }
        public int Update_Orders_Amount_Qty(POS_OrdersModel pos_OrdersModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "UPDATE Orders SET OutUnitPrice = CAST(@OutUnitPrice as decimal(10,3)), Quantity =@Quantity, Amount=CAST(@Amount as decimal(10,2)), " +
                                        "Tax1=CAST(@Tax1 as decimal(10,2)), " +
                                        "Tax2=CAST(@Tax2 as decimal(10,2)), " +
                                        "Tax3=CAST(@Tax3 as decimal(10,2)), " +
                                        "IsTax1=@IsTax1, " +
                                        "IsTax2=@IsTax2, " +
                                        "IsTax3=@IsTax3, " +
                                        "OrderCategoryId=@OrderCategoryId, " +
                                        "IsFixedOrder=@IsFixedOrder " +
                            " WHERE Id=@Id";
                var count = connection.Execute(query, pos_OrdersModel);

                return count;
            }
        }

        public int Insert_Order(POS_OrdersModel pos_OrdersModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO Orders (TranType	,ProductId	,ProductName	,SecondName	,ProductTypeId	, " +
                                "InUnitPrice	,OutUnitPrice	,IsTax1	,IsTax2	,IsTax3	,UnitCategoryId	,  " +
                                "Deposit	,RecyclingFee	,ChillCharge	,IsPointException	,IsManualPrice	, " +
                                "IsTaxInverseCalculation	,Tare	,Quantity	,Amount	,Tax1Rate	,Tax2Rate	, " +
                                "Tax3Rate	,Tax1	,Tax2	,Tax3	,InvoiceNo	,IsPaidComplete	,CompleteDate	, " +
                                "CompleteTime	,CreateDate	,CreateTime	,CreateUserId	,CreateUserName	,CreateStation	, " +
                                "LastModDate	,LastModTime	,LastModUserId	,LastModUserName	,LastModStation, RFTagID, " +
                                "ParentId, OrderCategoryId, IsDiscounted, BarCode, IsFixedOrder , PromoId, PromoIndex) " +
                                " OUTPUT INSERTED.[Id] " +
                                "VALUES (@TranType	,@ProductId	,@ProductName	,@SecondName	,@ProductTypeId	,  " +
                                "CAST(@InUnitPrice as decimal(10,2)), CAST(@OutUnitPrice as decimal(10,3))	,@IsTax1	,@IsTax2	,@IsTax3	,@UnitCategoryId	, " +
                                "CAST(@Deposit as decimal(10,2)) ,CAST(@RecyclingFee as decimal(10,2))	,CAST(@ChillCharge as decimal(10,2))	,@IsPointException	,@IsManualPrice	, " +
                                "@IsTaxInverseCalculation	,@Tare	,@Quantity	,CAST(@Amount as decimal(10,2))	,CAST(@Tax1Rate as decimal(10,2))	,CAST(@Tax2Rate as decimal(10,2))	, " +
                                "CAST(@Tax3Rate as decimal(10,2))	,CAST(@Tax1 as decimal(10,2))	,CAST(@Tax2 as decimal(10,2))	,CAST(@Tax3 as decimal(10,2))	,@InvoiceNo	,@IsPaidComplete	,@CompleteDate	, " +
                                "@CompleteTime	,@CreateDate	,@CreateTime	,@CreateUserId	,@CreateUserName	,@CreateStation	, " +
                                "@LastModDate	,@LastModTime	,@LastModUserId	,@LastModUserName	,@LastModStation, @RFTagID, " +
                                "@ParentId, @OrderCategoryId, @IsDiscounted, @BarCode, @IsFixedOrder , @PromoId, @PromoIndex) ";
                //var count = connection.Execute(query, pos_OrdersModel);
                //if (count == 1) return true;
                //return false;
                int iNewId = connection.QuerySingle<int>(query, pos_OrdersModel);
                return iNewId;
            }
        }

        public List<POS_OrdersModel> Get_Orders_by_InvoiceNo(int iNewInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where InvoiceNo = {iNewInvNo} ").ToList();
                return output;
            }
        }
        public List<POS_OrdersModel> Get_Fixed_Order_By_InvoiceNo(int iNewInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where InvoiceNo = {iNewInvNo} and IsFixedOrder = 1 ").ToList();
                return output;
            }
        }
        public int Get_Tag_Count_by_ProdId(int iProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from RFIDTags where ProductId = {iProdId} ").ToList();
                return output.Count;
            }
        }

        public int Get_Latest_OrderId_by_InvoiceNo_ProductId(int iInvoiceNo, int iProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where InvoiceNo = {iInvoiceNo} and ProductId = {iProdId} order by Id DESC").ToList();
                if (output.Count > 0)
                {
                    return output[0].Id;
                }
                else
                {
                    return 0;
                }
            }
        }
        public int Get_UsedTag_Count_by_ProdId(int iProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from RFIDTags where ProductId = {iProdId} and IsUsed=1 ").ToList();
                return output.Count;
            }
        }

        public List<POS_StationModel> Get_All_Station()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_StationModel>($"select * from Station").ToList();
                return output;
            }
        }

        public int Delete_Order_By_OrderId(int iNewInvNo, int OrderId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                List<POS_OrdersModel> orders = new List<POS_OrdersModel>();
                List<POS_OrdersModel> childOrders = new List<POS_OrdersModel>();
                orders = Get_Order_By_OrderId(OrderId);
                if (orders.Count > 0)
                {
                    if ((orders[0].ParentId > 0) && (orders[0].OrderCategoryId == 4))   // Discount
                    {
                        // Update the Parent Order to IsDiscounted = false
                        Update_Order_IsDiscounted(orders[0].InvoiceNo, orders[0].ParentId, false);
                    }
                    childOrders = Get_Child_Order_By_OrderId(iNewInvNo, OrderId);
                    if (childOrders.Count > 0)
                    {
                        foreach (POS_OrdersModel childOrder in childOrders)
                        {
                            Delete_Order_By_OrderId(iNewInvNo, childOrder.Id);
                        }
                    }
                }
                string query = "DELETE from Orders WHERE id=" + OrderId + " and InvoiceNo = " + iNewInvNo;
                var count = connection.Execute(query);
                return count;
            }
        }

        public int Get_Used_RFIDTags_Count_By_ProdID_InvNo(int iNewInvNo, int iSelectedProdId)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_RFIDTagsModel>($"select * from RFIDTags WHERE IsUsed = 1 and ProductId=" + iSelectedProdId + " and InvoiceNo = " + iNewInvNo).ToList();
                return output.Count;
            }
        }

        public float Get_Total_Due_Amount(int iNewInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"SELECT SUM(Amount) As Amount, SUM(Tax1) As Tax1, SUM(Tax2) As Tax2,SUM(tax3) As Tax3 FROM Orders WHERE InvoiceNo= {iNewInvNo} ").ToList();
                float fTotalAmount = 0;
                float fTotTax1 = 0;
                float fTotTax2 = 0;
                float fTotTax3 = 0;
                if (output.Count > 0)
                {
                    fTotalAmount = output[0].Amount;
                    fTotTax1 = output[0].Tax1;
                    fTotTax2 = output[0].Tax2;
                    fTotTax3 = output[0].Tax3;
                }
                return fTotalAmount + fTotTax1 + fTotTax2 + fTotTax3;
            }
        }
        //This is only for Discount
        public float Get_Total_Amount(int iNewInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"SELECT SUM(Amount) As Amount, SUM(Tax1) As Tax1, SUM(Tax2) As Tax2,SUM(tax3) As Tax3 FROM Orders WHERE InvoiceNo= {iNewInvNo} and OrderCategoryId=0").ToList();
                float fTotalAmount = 0;
                if (output.Count > 0)
                {
                    fTotalAmount = output[0].Amount;
                }
                return fTotalAmount;
            }
        }
        //This is only for Discount
        public float Get_Total_Tax1(int iNewInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"SELECT SUM(Amount) As Amount, SUM(Tax1) As Tax1, SUM(Tax2) As Tax2,SUM(tax3) As Tax3 FROM Orders WHERE InvoiceNo= {iNewInvNo} and OrderCategoryId=0").ToList();
                float fTotTax1 = 0;
                if (output.Count > 0)
                {
                    fTotTax1 = output[0].Tax1;
                }
                return fTotTax1;
            }
        }
        //This is only for Discount
        public float Get_Total_Tax2(int iNewInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"SELECT SUM(Amount) As Amount, SUM(Tax1) As Tax1, SUM(Tax2) As Tax2,SUM(tax3) As Tax3 FROM Orders WHERE InvoiceNo= {iNewInvNo} and OrderCategoryId=0").ToList();
                float fTotTax2 = 0;
                if (output.Count > 0)
                {
                    fTotTax2 = output[0].Tax2;
                }
                return fTotTax2;
            }
        }
        //This is only for Discount
        public float Get_Total_Tax3(int iNewInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"SELECT SUM(Amount) As Amount, SUM(Tax1) As Tax1, SUM(Tax2) As Tax2,SUM(tax3) As Tax3 FROM Orders WHERE InvoiceNo= {iNewInvNo} and OrderCategoryId=0").ToList();
                float fTotTax3 = 0;
                if (output.Count > 0)
                {
                    fTotTax3 = output[0].Tax3;
                }
                return fTotTax3;
            }
        }
        //This is only for Discount
        public float Get_Orders_Amount(int iOrderId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"SELECT SUM(Amount) As Amount, SUM(Tax1) As Tax1, SUM(Tax2) As Tax2,SUM(tax3) As Tax3 FROM Orders WHERE Id= {iOrderId} and OrderCategoryId=0").ToList();
                float fTotalAmount = 0;
                if (output.Count > 0)
                {
                    fTotalAmount = output[0].Amount;
                }
                return fTotalAmount;
            }
        }
        //This is only for Discount
        public float Get_Orders_Tax1(int iOrderId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"SELECT SUM(Amount) As Amount, SUM(Tax1) As Tax1, SUM(Tax2) As Tax2,SUM(tax3) As Tax3 FROM Orders WHERE Id= {iOrderId} and OrderCategoryId=0").ToList();
                float fTotTax1 = 0;
                if (output.Count > 0)
                {
                    fTotTax1 = output[0].Tax1;
                }
                return fTotTax1;
            }
        }
        //This is only for Discount
        public float Get_Orders_Tax2(int iOrderId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"SELECT SUM(Amount) As Amount, SUM(Tax1) As Tax1, SUM(Tax2) As Tax2,SUM(tax3) As Tax3 FROM Orders WHERE Id= {iOrderId} and OrderCategoryId=0").ToList();
                float fTotTax2 = 0;
                if (output.Count > 0)
                {
                    fTotTax2 = output[0].Tax2;
                }
                return fTotTax2;
            }
        }
        //This is only for Discount
        public float Get_Orders_Tax3(int iOrderId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"SELECT SUM(Amount) As Amount, SUM(Tax1) As Tax1, SUM(Tax2) As Tax2,SUM(tax3) As Tax3 FROM Orders WHERE Id= {iOrderId} and OrderCategoryId=0").ToList();
                float fTotTax3 = 0;
                if (output.Count > 0)
                {
                    fTotTax3 = output[0].Tax3;
                }
                return fTotTax3;
            }
        }
        public int Get_ProductTypeId_By_ProductID(int iProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"SELECT ProductTypeId FROM Product WHERE Id= {iProdId} ").ToList();

                if (output.Count > 0)
                {
                    return output[0].ProductTypeId;
                }
                else
                {
                    return 0;
                }
            }
        }
        public List<POS_ProductModel> Get_All_Products_By_ProdType(int iSelectedProdTypeID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"select * from Product WHERE ProductTypeId = {iSelectedProdTypeID} Order by IsManualItem Desc, ProductName").ToList();
                return output;
            }
        }
        public List<POS_ProductModel> Get_All_Products_By_BIBProdId(int p_int_ProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"select * from Product WHERE id in (Select ProductId FROM ButtonInButtons WHERE ButtonProdId = {p_int_ProdId}) Order by IsManualItem Desc, ProductName").ToList();
                return output;
            }
        }
        public List<POS_ProductModel> Get_All_Products_NonBIB()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"select * from Product WHERE IsNull(IsButtonInButton,0) = 0 Order by IsManualItem Desc, ProductName").ToList();
                return output;
            }
        }

        public List<POS_ProductModel> Get_All_Products_By_ProdType_NonBIB(int iSelectedProdTypeID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"select * from Product WHERE ProductTypeId = {iSelectedProdTypeID} And IsNull(IsButtonInButton,0) = 0  Order by IsManualItem Desc, ProductName").ToList();
                return output;
            }
        }
        public List<POS_ProductModel> Get_All_Products_By_Category(int iSelectedCatID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"select * from Product WHERE CategoryId = {iSelectedCatID} Order by IsManualItem Desc, ProductName").ToList();
                return output;
            }
        }
        public List<POS_ProductModel> Get_All_Products_By_ProdType_Sortby_Price(int iSelectedProdTypeID, int iTop)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"select Top {iTop} * from Product WHERE ProductTypeId = {iSelectedProdTypeID} Order by IsManualItem Desc, OutUnitPrice").ToList();
                return output;
            }
        }
        public List<POS_ProductModel> Get_All_Products_By_ProdType_SortOrder(int iSelectedProdTypeID, int iTop, string p_strSortOrder)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"select Top {iTop} * from Product WHERE ProductTypeId = {iSelectedProdTypeID} Order by {p_strSortOrder}").ToList();
                return output;
            }
        }
        public List<POS_ProductModel> Get_All_DefaultSales_Products(string p_strSortOrder)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                //var output = connection.Query<POS_ProductModel>($"select * from Product WHERE ISNULL(IsMainSalesButton,0) = 1 Order by IsManualItem Desc, OutUnitPrice").ToList();
                string strSQL = $"select * from Product WHERE ISNULL(IsMainSalesButton,0) = 1 Order by IsManualItem Desc, OutUnitPrice";
                if (p_strSortOrder != "")
                {
                    strSQL = $"select * from Product WHERE ISNULL(IsMainSalesButton,0) = 1 Order by {p_strSortOrder}";
                }
                var output = connection.Query<POS_ProductModel>(strSQL).ToList();
                return output;
            }
        }
        //        public List<POS_ProductModel> Get_All_Products_By_BarCode(string p_strBarCode, bool p_bIsManual, bool p_bIsMainSales, bool p_bIsSales)
        public List<POS_ProductModel> Get_All_Products_By_BarCode(string p_strBarCode, bool p_bIsManual)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                //$"select * from Product WHERE BarCode = '{p_strBarCode.Trim()}'"
                string query = $"select * from Product ";
                string strWhere = $" Where BarCode = '{p_strBarCode.Trim()}'";
                if (p_bIsManual)
                    strWhere += " And ISNULL(IsManualItem,0) = " + (p_bIsManual ? "1" : "0");
                //                    " And ISNULL(IsMainSalesButton,0) = " + (p_bIsMainSales ? "1" : "0") +
                //                    " And ISNULL(IsSalesButton,0) = " + (p_bIsSales ? "1" : "0");
                string strOrderby = " Order By ProductName";
                query += strWhere + strOrderby;
                var output = connection.Query<POS_ProductModel>(query).ToList();
                return output;
            }

        }

        //public List<POS_ProductModel> Get_All_Products_By_ProdName(string p_strProdName, bool p_bIsManual, bool p_bIsMainSales, bool p_bIsSales)
        public List<POS_ProductModel> Get_All_Products_By_ProdName(string p_strProdName, bool p_bIsManual)
        {
            // find any single quote in the string and replace it with two single quotes
            p_strProdName = p_strProdName.Replace("'", "''");
            p_strProdName = '%' + p_strProdName.Trim() + '%';
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = $"select * from Product ";
                string strWhere = $" Where ProductName like '%{p_strProdName}%' Or SecondName like '%{p_strProdName}%'";
                if (p_bIsManual)
                    strWhere += " And ISNULL(IsManualItem,0) = " + (p_bIsManual ? "1" : "0");
                //" And ISNULL(IsMainSalesButton,0) = " + (p_bIsMainSales ? "1" : "0") +
                //" And ISNULL(IsSalesButton,0) = " + (p_bIsSales ? "1" : "0");
                string strOrderby = " Order By ProductName";
                query += strWhere + strOrderby;
                var output = connection.Query<POS_ProductModel>(query).ToList();
                return output;
            }

        }
        public List<POS_ProductModel> Get_All_Products_By_ProdName_Price(string p_strProdName, double p_UnitPrice)
        {
            p_strProdName = '%' + p_strProdName.Trim() + '%';
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = $"select * from Product ";
                string strWhere = $" Where (ProductName like '%{p_strProdName}%' Or SecondName like '%{p_strProdName}%')";
                if (p_UnitPrice > 0)
                    strWhere += " And ISNULL(OutUnitPrice,0) >= " + p_UnitPrice.ToString();
                //" And ISNULL(IsMainSalesButton,0) = " + (p_bIsMainSales ? "1" : "0") +
                //" And ISNULL(IsSalesButton,0) = " + (p_bIsSales ? "1" : "0");
                string strOrderby = " Order By ProductName";
                query += strWhere + strOrderby;
                var output = connection.Query<POS_ProductModel>(query).ToList();
                return output;
            }

        }
        public List<POS_PromotionModel> Get_All_Promotions()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_PromotionModel>($"select * from Promotion").ToList();
                return output;
            }
        }

        public int Get_Product_Count_by_ProdTypeId(int iProdTypeId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"select * from Product where ProductTypeId = {iProdTypeId} ").ToList();
                return output.Count;
            }
        }

        public string Get_ProductName_By_Id(int iSelected_ProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"SELECT * FROM Product WHERE id= {iSelected_ProdId} ").ToList();
                if (output.Count > 0)
                {
                    return output[0].ProductName;
                }
                return "";
            }
        }
        public float Get_ProductPrice_By_Id(int iSelected_ProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"SELECT * FROM Product WHERE id= {iSelected_ProdId} ").ToList();
                if (output.Count > 0)
                {
                    return output[0].OutUnitPrice;
                }
                return 0;
            }
        }
        public string Get_ProductMemo_By_Id(int iSelected_ProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"SELECT * FROM Product WHERE id= {iSelected_ProdId} ").ToList();
                if (output.Count > 0)
                {
                    if (output[0].MemoText != null)
                    {
                        return output[0].MemoText;
                    }
                }
                return "";
            }
        }
        public string Get_ProductBarCode_By_Id(int iSelected_ProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"SELECT * FROM Product WHERE id= {iSelected_ProdId} ").ToList();
                if (output.Count > 0)
                {
                    if (output[0].BarCode != null)
                    {
                        return output[0].BarCode;
                    }
                }
                return "";
            }
        }
        public List<POS_RFIDTagsModel> Get_All_UnUsed_RFIDTags_by_ProdId(int iSelected_ProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_RFIDTagsModel>($"select * from RFIDTags where IsUsed=0 and ProductId = {iSelected_ProdId} ").ToList();
                return output;
            }
        }
        public int Delete_All_UnUsed_RFIDTags_by_ProdId(int iSelected_ProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "DELETE from RFIDTags where IsUsed=0 and ProductId = " + iSelected_ProdId.ToString();
                var count = connection.Execute(query);
                return count;
            }
        }

        public int Insert_SavedOrders(POS_SavedOrdersModel pos_SavedOrdersModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO SavedOrders (TranType,ProductId,ProductName,SecondName,ProductTypeId,InUnitPrice,OutUnitPrice," +
                                "IsTax1,IsTax2,IsTax3,UnitCategoryId,Deposit,RecyclingFee,ChillCharge,IsPointException," +
                                "IsManualPrice,IsTaxInverseCalculation,Tare,Quantity,Amount,Tax1Rate,Tax2Rate,Tax3Rate," +
                                "Tax1,Tax2,Tax3,InvoiceNo,IsPaidComplete,CompleteDate,CompleteTime,CreateDate,CreateTime," +
                                "CreateUserId,CreateUserName,CreateStation,LastModDate,LastModTime,LastModUserId,LastModUserName,LastModStation, RFTagID," +
                                "ParentId, OrderCategoryId, IsDiscounted, BarCode) " +
                                "VALUES (" +
                                "@TranType, @ProductId, @ProductName, @SecondName, @ProductTypeId, CAST(@InUnitPrice as decimal(10,2)), CAST(@OutUnitPrice as decimal(10,2))," +
                                "@IsTax1, @IsTax2, @IsTax3, @UnitCategoryId, CAST(@Deposit as decimal(10,2)), CAST(@RecyclingFee as decimal(10,2)), CAST(@ChillCharge as decimal(10,2)), @IsPointException," +
                                "@IsManualPrice, @IsTaxInverseCalculation, @Tare, @Quantity, CAST(@Amount as decimal(10,2)), CAST(@Tax1Rate as decimal(10,2)), CAST(@Tax2Rate as decimal(10,2)), CAST(@Tax3Rate as decimal(10,2))," +
                                "CAST(@Tax1 as decimal(10,2)),CAST(@Tax2 as decimal(10,2)),CAST(@Tax3 as decimal(10,2)), @InvoiceNo, @IsPaidComplete, @CompleteDate, @CompleteTime, @CreateDate, @CreateTime," +
                                "@CreateUserId, @CreateUserName, @CreateStation, @LastModDate, @LastModTime, @LastModUserId, @LastModUserName, @LastModStation, @RFTagID," +
                                "@ParentId, @OrderCategoryId, @IsDiscounted, @BarCode)";
                var count = connection.Execute(query, pos_SavedOrdersModel);
                return count;
            }
        }

        public List<POS_SavedOrdersModel> Get_SavedOrders_by_InvoiceNo(int iNewInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_SavedOrdersModel>($"select * from SavedOrders where InvoiceNo = {iNewInvNo} ").ToList();
                return output;
            }
        }

        public int Get_SavedOrders_NextInvoiceNo()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_SavedOrdersModel>($"select MAX(InvoiceNo) As InvoiceNo from SavedOrders").ToList();
                int iNewInvNo = 1000;
                if (output.Count > 0)
                {
                    iNewInvNo = output[0].InvoiceNo + 1;
                }
                return iNewInvNo;
            }
        }

        public int Delete_SavedOrder_By_OrderId(int invoiceNo, int OrderId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "DELETE from SavedOrders WHERE id=" + OrderId + " and InvoiceNo = " + invoiceNo;
                var count = connection.Execute(query);
                return count;
            }
        }
        public List<POS_PromotionModel> Get_All_Effective_Promotions()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_PromotionModel>($"SELECT *  FROM Promotion where PromoStartDttm <= GETDATE() And PromoEndDttm >= GETDATE()").ToList();
                return output;
            }
        }

        public int Get_Order_QTY_By_MutipleProductIds(string strStation, string strSQLWhere)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                float iQTYSUM = 0;
                string query = "SELECT Sum(Quantity) AS Quantity from Orders WHERE OrderCategoryId = 0 And ProductId in (" + strSQLWhere + ") And CreateStation = '" + strStation + "'";
                var output = connection.Query<POS_OrdersModel>(query).ToList();
                if (output.Count > 0)
                {
                    iQTYSUM = output[0].Quantity;
                }
                return (int)iQTYSUM;
            }
        }

        public double Get_Orders_Average_Amount_By_MultipleProdId(string strStation, string strSQLWhere)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                double dblAverageAmt = 0;
                string query = "SELECT Sum(Amount)/Sum(Quantity) As Amount from Orders WHERE OrderCategoryId = 0 And ProductId in (" + strSQLWhere + ") And CreateStation = '" + strStation + "'";
                var output = connection.Query<POS_OrdersModel>(query).ToList();
                if (output.Count > 0)
                {
                    dblAverageAmt = output[0].Amount;
                }
                return dblAverageAmt;
            }
        }
        public PromoDiscOrderModel Get_Orders_PromoOrder_By_MultipleProdId(string strStation, string strSQLWhere)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                PromoDiscOrderModel pDiscOrder = new PromoDiscOrderModel();
                string query = "SELECT * from Orders WHERE OrderCategoryId = 0 And ProductId in (" + strSQLWhere + ") And CreateStation = '" + strStation + "'";
                var output = connection.Query<POS_OrdersModel>(query).ToList();
                if (output.Count > 0)
                {
                    pDiscOrder.Qty = output.FindAll(ord => ord.ProductId > 0).Sum(x => x.Quantity);
                    pDiscOrder.Amount = output.FindAll(ord => ord.ProductId > 0).Sum(x => x.Amount);

                    pDiscOrder.OutUnitPrice = output[0].OutUnitPrice;
                    pDiscOrder.IsTax1 = output[0].IsTax1;
                    pDiscOrder.IsTax2 = output[0].IsTax2;
                    pDiscOrder.IsTax3 = output[0].IsTax3;

                }
                return pDiscOrder;
            }
        }

        public int Delete_Promotion_Discount_Orders(string strStation, int p_PromoId, int p_PromoIndex)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = $"DELETE from Orders WHERE OrderCategoryId=4 And IsDiscounted=1 And CreateStation = '" + strStation + $"' And PromoId = {p_PromoId} And PromoIndex = {p_PromoIndex}";
                var count = connection.Execute(query);
                return count;
            }
        }
        public int Delete_ALL_Promotion_Discount_Orders(string strStation, int p_PromoId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = $"DELETE from Orders WHERE OrderCategoryId=4 And IsDiscounted=1 And CreateStation = '" + strStation + $"' And PromoId = {p_PromoId} ";
                var count = connection.Execute(query);
                return count;
            }
        }
        public List<POS_OrdersModel> Get_Order_By_OrderId(int iSelectedOrderId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "SELECT * from Orders WHERE Id = " + iSelectedOrderId.ToString();
                var output = connection.Query<POS_OrdersModel>(query).ToList();
                return output;
            }
        }

        public int Get_ProductId_By_ProdName(string strProdName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"SELECT * FROM Product WHERE ProductName= '{strProdName}' ").ToList();
                if (output.Count > 0)
                {
                    return output[0].Id;
                }
                return 0;
            }
        }

        public List<POS_OrdersModel> Get_NonRFID_Order_By_BarCode(int iNewInvNo, string strBarCode)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where BarCode = '{strBarCode}' and InvoiceNo = {iNewInvNo} and RFTagId < 1").ToList();
                return output;
            }
        }
        public List<POS_OrdersModel> Get_NonRFID_NonFixed_Order_By_BarCode(int iNewInvNo, string strBarCode)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where BarCode = '{strBarCode}' and InvoiceNo = {iNewInvNo} and RFTagId < 1 and IsFixedOrder = 0").ToList();
                return output;
            }
        }
        public int Get_Orders_Count_by_InvoiceNo(int iNewInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where InvoiceNo = {iNewInvNo} and ParentId=0").ToList();
                return output.Count;
            }
        }

        public List<POS_OrdersModel> Get_Child_Order_By_OrderId(int iNewInvNo, int orderid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_OrdersModel>($"select * from Orders where parentid = {orderid} and InvoiceNo = {iNewInvNo} and RFTagId < 1").ToList();
                return output;
            }
        }

        public int Update_Product_Balance(POS_ProductModel pos_ProductModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "UPDATE Product SET Balance = @Balance " +
                                "WHERE Id = @Id";
                var count = connection.Execute(query, pos_ProductModel);
                return count;
            }
        }

        public bool Check_Assorted_PromotionName(string p_PromoName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_PromotionModel>($"select * from Promotion where PromoName = '{p_PromoName}' ").ToList();
                if (output.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        public string Get_Tax_Name(int p_iTax)
        {
            string strConfigName = "Tax" + p_iTax.ToString();
            List<POS_SysConfigModel> sysConfigs = new List<POS_SysConfigModel>();
            sysConfigs = Get_SysConfig_By_Name(strConfigName);
            if (sysConfigs.Count > 0)
            {
                return sysConfigs[0].ConfigValue;
            }
            return "Unkown";
        }
        public List<POS_TaxModel> Get_Tax_By_Code(string p_strTaxCode)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_TaxModel>($"select * from Tax Where Code = '{p_strTaxCode}'").ToList();
                return output;
            }
        }
        public bool Update_Product_Inventory(POS_ProductModel p_ProductModel, int p_iLogTypeId, float fBeforeQTY, float fAfterQTY, string p_PassCode, string p_Station)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "UPDATE Product SET Balance = @Balance " +
                            "WHERE Id = @Id";
                var count = connection.Execute(query, p_ProductModel);

                if (count > 0)
                {
                    DataAccessPOS1 dbPOS1 = new DataAccessPOS1();
                    dbPOS1.Insert_ProductInventoryLog(p_ProductModel, p_iLogTypeId, fBeforeQTY, fAfterQTY, p_PassCode, p_Station);
                    return true;
                }
                return false;

            }
        }

        public List<POS_TimeTableModel> Get_Last_ClockIn(int p_UserId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_TimeTableModel>($"select * from TimeTable where UserId = {p_UserId} And DateTimeFinished IS NULL;").ToList();
                return output;
            }
        }

        public POS_TimeTableModel Get_TimeTable_by_Id(int p_iTimeTableId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "";

                query = $"select * from TimeTable where Id = " + p_iTimeTableId.ToString() + ";";
                var output = connection.QuerySingle<POS_TimeTableModel>(query);
                return output;
            }
        }

        public bool Delete_TimeTable(int p_iSelectedId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "DELETE from TimeTable WHERE id=" + p_iSelectedId;
                var count = connection.Execute(query);
                if (count > 0)
                    return true;
                else
                    return false;
            }
        }

        public int Update_Tax(POS_TaxModel pos_Tax)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                int bIsTax3IncTax = pos_Tax.IsTax3IncTax1 ? 1 : 0;
                string query = $"UPDATE Tax SET Tax1 = {pos_Tax.Tax1}, Tax2 = {pos_Tax.Tax2}, Tax3 = {pos_Tax.Tax3}, IsTax3IncTax1 = {bIsTax3IncTax.ToString()} " +
                                $"WHERE Code = '" + pos_Tax.Code + "'";
                var count = connection.Execute(query);
                return count;
            }
        }

        public int Insert_Tax(POS_TaxModel pos_Tax)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                int bIsTax3IncTax = pos_Tax.IsTax3IncTax1 ? 1 : 0;
                string query = $"INSERT INTO Tax (Code, Tax1, Tax2, Tax3, IsTax3IncTax1) VALUES " +
                                $"('{pos_Tax.Code}', {pos_Tax.Tax1},{pos_Tax.Tax2},{pos_Tax.Tax3}, {bIsTax3IncTax} );";
                var count = connection.Execute(query);
                return count;
            }
        }

        public bool Check_Tax_Exists(string strTaxCode)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_TaxModel>($"select * from Tax where Code = '{strTaxCode}'").ToList();
                if (output.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool Delete_Tax(string strTaxCode)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = $"DELETE from Tax WHERE Code= '{strTaxCode}';";
                var count = connection.Execute(query);
                if (count > 0)
                    return true;
                else
                    return false;
            }
        }

        public List<POS_CategoryModel> Get_Category_By_ID(int p_Id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_CategoryModel>($"select * from Category where id = {p_Id}").ToList();
                return output;
            }
        }

        public int Update_Category(POS_CategoryModel pOS_CategoryModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "UPDATE Category SET CategoryName = @CategoryName, IsSeparateReport=@IsSeparateReport, IsDCException=@IsDCException " +
                                "WHERE Id=@Id";
                var count = connection.Execute(query, pOS_CategoryModel);
                return count;
            }
        }

        public int Insert_Category(POS_CategoryModel pOS_CategoryModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO Category (CategoryName, IsSeparateReport, IsDCException) " +
                                    "VALUES (@CategoryName, @IsSeparateReport, @IsDCException)";
                var count = connection.Execute(query, pOS_CategoryModel);
                return count;
            }
        }

        public int Delete_Category_By_Id(int iSelectedId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "DELETE from Category WHERE id=" + iSelectedId;
                var count = connection.Execute(query);
                return count;
            }
        }

        public List<POS_CategoryModel> Get_All_Categories()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_CategoryModel>($"select * from Category").ToList();
                return output;
            }
        }

        public List<POS_CategoryModel> Get_Category_By_Name(string p_strName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_CategoryModel>($"select * from Category where CategoryName = '{p_strName}'").ToList();
                return output;
            }
        }

        public int Delete_LoginUser(int iSelectedId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "DELETE from LoginUser WHERE id=" + iSelectedId;
                var count = connection.Execute(query);
                return count;
            }
        }

        public int Delete_ButtonInButtons(int p_iParentProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "DELETE from ButtonInButtons WHERE ButtonProdId = " + p_iParentProdId;
                var count = connection.Execute(query);
                return count;
            }
        }

        public List<POS_BIBListModel> Get_All_ButtonInButtons_List()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                List<POS_BIBListModel> bibList = new List<POS_BIBListModel>();
                var bibProds = connection.Query<POS_ProductModel>($"select * from Product WHERE IsButtonInButton = 1").ToList();
                if (bibProds.Count > 0)
                {
                    List<POS_ButtonInButtonsModel> bibs = new List<POS_ButtonInButtonsModel>();
                    foreach (POS_ProductModel bib in bibProds)
                    {
                        var output = connection.Query<POS_ButtonInButtonsModel>($"select * from ButtonInButtons WHERE ButtonProdId = {bib.Id}").ToList();
                        if (output.Count > 0)
                        {
                            //public string PTypeName { get; set; }
                            //public int ButtonProdId { get; set; }
                            //public string ButtonName { get; set; }
                            //List<POS_ProductModel> ProductList { get; set; }
                            bibList.Add(
                                new POS_BIBListModel
                                {
                                    PTypeName = Get_ProductTypeName_By_Id(bib.ProductTypeId),
                                    ButtonProdId = bib.Id,
                                    ButtonName = bib.ProductName,
                                    ProdCount = output.Count
                                }
                            );
                        }
                        else
                        {
                            bibList.Add(
                                new POS_BIBListModel
                                {
                                    PTypeName = Get_ProductTypeName_By_Id(bib.ProductTypeId),
                                    ButtonProdId = bib.Id,
                                    ButtonName = bib.ProductName,
                                    ProdCount = 0
                                }
                            );
                        }
                    }
                    return bibList;
                }
                return null;
            }
        }

        public List<POS_ProductModel> Get_All_BIB_Products_By_ButtonProductId(int p_int_ProductId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_ProductModel>($"select * from Product WHERE Id in (Select ProductId From ButtonInButtons WHERE ButtonProdId = {p_int_ProductId})").ToList();
                return output;
            }
        }

        public int Add_ButtonInButton(POS_ButtonInButtonsModel p_bib)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO ButtonInButtons (ButtonProdId, ButtonName, ProductId, SortOrder) " +
                                    "VALUES (@ButtonProdId, @ButtonName, @ProductId, @SortOrder)";
                var count = connection.Execute(query, p_bib);
                return count;
            }
        }

        public bool Update_Order_IsDiscounted(int iNewInvNo, int iOrderId, bool bIsDiscounted)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = $"UPDATE Orders SET IsDiscounted = {(bIsDiscounted ? 1 : 0)} ";
                string strWhere = "WHERE ProductId > 0 ";
                if (iOrderId > 0)
                    strWhere += $"And Id = {iOrderId} ";
                if (iNewInvNo > 0)
                    strWhere += $"And InvoiceNo = {iNewInvNo} ";
                query = query + strWhere;
                var count = connection.Execute(query);
                return count > 0;
            }
        }

        public List<POS_SalesButtonModel> Get_All_SalesButton()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_SalesButtonModel>($"select * from SalesButton").ToList();
                return output;
            }
        }

        public int Delete_All_SalesButton()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "DELETE from SalesButton";
                var count = connection.Execute(query);
                return count;
            }
        }

        public int Insert_SalesButton(POS_SalesButtonModel p_salesButton)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO SalesButton (Row, Col, ButtonLeft, ButtonTop, Width, Height, FontName, FontSize, FontStyle, ForeColor, BackColor, ProductId, IsVisible, IsBIB) " +
                                    "VALUES (@Row, @Col, @ButtonLeft, @ButtonTop, @Width, @Height, @FontName, @FontSize, @FontStyle, @ForeColor,@BackColor, @ProductId, @IsVisible, @IsBIB)";
                var count = connection.Execute(query, p_salesButton);
                return count;
            }
        }

        public bool Check_SalesButton_By_ProductId(int p_ProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_SalesButtonModel>($"select * from SalesButton where ProductId  = {p_ProdId} and IsBIB = 0").ToList();
                if (output.Count > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool Check_SalesButton_By_BIBProductId(int p_ProdId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_SalesButtonModel>($"select * from SalesButton where ProductId  = {p_ProdId} and IsBIB = 1").ToList();
                if (output.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        public List<POS_SysConfigModel> Get_SysConfig_By_Desc(string p_strFormat)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<POS_SysConfigModel>($"select * from SysConfig where ConfigDesc  = '{p_strFormat}'").ToList();
                return output;
            }
        }
    }
}
