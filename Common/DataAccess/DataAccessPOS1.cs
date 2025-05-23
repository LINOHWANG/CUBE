﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using SDCafeCommon.Utilities;
using SDCafeCommon.Model;
using System.Data;

namespace SDCafeCommon.DataAccess
{
    public class DataAccessPOS1
    {
        Utility util = new Utility();
        public int Insert_OrderComplete(POS1_OrderCompleteModel pos1_OrderCompleteModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "INSERT INTO OrderComplete (OrderId,TranType,ProductId,ProductName,SecondName,ProductTypeId,InUnitPrice,OutUnitPrice," +
                                "IsTax1,IsTax2,IsTax3,UnitCategoryId,Deposit,RecyclingFee,ChillCharge,IsPointException," +
                                "IsManualPrice,IsTaxInverseCalculation,Tare,Quantity,Amount,Tax1Rate,Tax2Rate,Tax3Rate," +
                                "Tax1,Tax2,Tax3,InvoiceNo,IsPaidComplete,CompleteDate,CompleteTime,CreateDate,CreateTime,"+
                                "CreateUserId,CreateUserName,CreateStation,LastModDate,LastModTime,LastModUserId,LastModUserName,LastModStation, RFTagID," +
                                "ParentId, OrderCategoryId, IsDiscounted, BarCode) " +
                                "VALUES (" +
                                "@OrderId, @TranType, @ProductId, @ProductName, @SecondName, @ProductTypeId, CAST(@InUnitPrice as decimal(10,2)), CAST(@OutUnitPrice as decimal(10,2))," +
                                "@IsTax1, @IsTax2, @IsTax3, @UnitCategoryId, CAST(@Deposit as decimal(10,2)), CAST(@RecyclingFee as decimal(10,2)), CAST(@ChillCharge as decimal(10,2)), @IsPointException," +
                                "@IsManualPrice, @IsTaxInverseCalculation, @Tare, @Quantity, CAST(@Amount as decimal(10,2)), CAST(@Tax1Rate as decimal(10,2)), CAST(@Tax2Rate as decimal(10,2)), CAST(@Tax3Rate as decimal(10,2))," +
                                "CAST(@Tax1 as decimal(10,2)),CAST(@Tax2 as decimal(10,2)),CAST(@Tax3 as decimal(10,2)), @InvoiceNo, @IsPaidComplete, @CompleteDate, @CompleteTime, @CreateDate, @CreateTime," +
                                "@CreateUserId, @CreateUserName, @CreateStation, @LastModDate, @LastModTime, @LastModUserId, @LastModUserName, @LastModStation, @RFTagID,"+
                                "@ParentId, @OrderCategoryId, @IsDiscounted, @BarCode)";
                var count = connection.Execute(query, pos1_OrderCompleteModel);
                return count;
            }
        }
        public int Insert_TranCollection(POS1_TranCollectionModel pos1_TranCollectionModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "INSERT INTO TranCollection (ReceiptNo,InvoiceNo,SplitId,TableId,TableName,NumOfPeople,Amount,Tax1,Tax2,Tax3," +
                                "TotalDue,CollectionType,IsOnline,Cash,Debit,Visa,Master,Amex,GiftCard,Others,CashTip," +
                                "DebitTip,VisaTip,MasterTip,AmexTip,DebitFee,VisaFee,MasterFee,AmexFee,DebitTipFee,VisaTipFee," +
                                "MasterTipFee,AmexTipFee,TotalPaid,TotalTip,Change,CreateDate,CreateTime,CreatePasswordCode,CreatePasswordName," +
                                "CreateStation,LastModDate,LastModTime,LastModPasswordCode,LastModPasswordName,LastModStation, OthersTip, Rounding, Cheque, Charge) " +
                                "VALUES (" +
                                "@ReceiptNo,@InvoiceNo,@SplitId,@TableId,@TableName,@NumOfPeople,CAST(@Amount as decimal(10,2)),CAST(@Tax1 as decimal(10,2)),CAST(@Tax2 as decimal(10,2)),CAST(@Tax3 as decimal(10,2))," +
                                "CAST(@TotalDue as decimal(10,2)),@CollectionType,@IsOnline,CAST(@Cash as decimal(10,2)),CAST(@Debit as decimal(10,2)),"+
                                "CAST(@Visa as decimal(10,2)),CAST(@Master as decimal(10,2)),CAST(@Amex as decimal(10,2)),CAST(@Giftcard as decimal(10,2)),CAST(@Others as decimal(10,2))," +
                                "CAST(@CashTip as decimal(10,2)),CAST(@DebitTip as decimal(10,2)),CAST(@VisaTip as decimal(10,2)),CAST(@MasterTip as decimal(10,2)),"+
                                "CAST(@AmexTip as decimal(10,2)),CAST(@DebitFee as decimal(10,2)),CAST(@VisaFee as decimal(10,2)),CAST(@MasterFee as decimal(10,2)),"+
                                "CAST(@AmexFee as decimal(10,2)),CAST(@DebitTipFee as decimal(10,2)),CAST(@VisaTipFee as decimal(10,2))," +
                                "CAST(@MasterTipFee as decimal(10,2)),CAST(@AmexTipFee as decimal(10,2)),CAST(@TotalPaid as decimal(10,2)),CAST(@TotalTip as decimal(10,2)),"+
                                "CAST(@Change as decimal(10,2)),@CreateDate,@CreateTime,@CreatePasswordCode,@CreatePasswordName," +
                                "@CreateStation,@LastModDate,@LastModTime,@LastModPasswordCode,@LastModPasswordName,@LastModStation, CAST(@OthersTip as decimal(10,2)),"+
                                "CAST(@Rounding as decimal(10, 2)), CAST(@Cheque as decimal(10,2)), CAST(@Charge as decimal(10,2)) " +
                                ")";
                var count = connection.Execute(query, pos1_TranCollectionModel);
                return count;
            }
        }



        public int Insert_CardTranComplete(POS1_CardTranCompleteModel pos1_CardTranCompleteModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "INSERT INTO CardTranComplete (TranId,TransactionStatus,MultiTranFlag,TransactionType,TransactionDate,TransactionTime,TransactionAmount," +
                                "TipAmount,CashBackAmount,SurchargeAmount,TaxAmount,TotalAmount,InvoiceNo,PurchaseOrderNo,ReferenceNo,TransactionSequenceNo," +
                                "TicketNo,VoucherNo,ClerkId,GiftCardReferenceNo,OriginalTransactionType,CustomerCardType,CustomerAccountNumber," +
                                "CustomerCardEntryMode,CardNotPresent,AuthorizationNo,HostResponseCode,HostResponseText,HostResponseISOCode," +
                                "AmountDue,CardBalance,HostTransactionRefNbr,TerminalId,DemoMode,TransactionData,CreateInvoiceNo,CreateDate," +
                                "CreateTime,CreateUserId,CreateUserName,CreateStation) " +
                                                            "VALUES (" +
                                "@TranId,@TransactionStatus,@MultiTranFlag,@TransactionType,@TransactionDate,@TransactionTime,@TransactionAmount,"+
                                "@TipAmount,@CashBackAmount,@SurchargeAmount,@TaxAmount,@TotalAmount,@InvoiceNo,@PurchaseOrderNo,@ReferenceNo," +
                                "@TransactionSequenceNo,@TicketNo,@VoucherNo,@ClerkId,@GiftCardReferenceNo,@OriginalTransactionType,@CustomerCardType,@CustomerAccountNumber," +
                                "@CustomerCardEntryMode,@CardNotPresent,@AuthorizationNo,@HostResponseCode,@HostResponseText,@HostResponseISOCode,@AmountDue,@CardBalance," +
                                "@HostTransactionRefNbr,@TerminalId,@DemoMode,@TransactionData,@CreateInvoiceNo,@CreateDate,@CreateTime,@CreateUserId," +
                                "@CreateUserName,@CreateStation)";
                var count = connection.Execute(query, pos1_CardTranCompleteModel);
                return count;
            }
        }
        public int Insert_CardReceiptComplete(POS1_CardReceiptCompleteModel pos1_CardReceiptCompleteModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "INSERT INTO CardReceiptComplete (TranId,ReceiptInformation,SeqNo,TransactionType,TransactionStatus,TransactionDate,TransactionTime,TransactionAmount," +
                                "TipAmount,CashBackAmount,SurchargeAmount,TaxAmount,TotalAmount,InvoiceNo,PurchaseOrderNo,ReferenceNo,TransactionSequenceNo," +
                                "TicketNo,VoucherNo,ClerkId,GiftCardReferenceNo,OriginalTransactionType,CustomerCardType,CustomerCardDescription,CustomerAccountNumber," +
                                "CustomerLanguage,CustomerAccountType,CustomerCardEntryMode,EmvAid,EmvTvr,EmvTsi,EMVApplicationLabel,CVMResult,AuthorizationNo," +
                                "HostResponseCode,HostResponseText,HostResponseISOCode,RetrievalReferenceNo,AmountDue,TraceNo,CardBalance,HostTransactionRefNbr," +
                                "BatchNumber,TerminalId,DemoMode,MerchId,MerchCurrencyCode,ReceiptHeader1,ReceiptHeader2,ReceiptHeader3,ReceiptHeader4," +
                                "ReceiptHeader5,ReceiptHeader6,ReceiptHeader7,ReceiptFooter1,ReceiptFooter2,ReceiptFooter3,ReceiptFooter4,ReceiptFooter5," +
                                "ReceiptFooter6,ReceiptFooter7,EndorsementLine1,EndorsementLine2,EndorsementLine3,EndorsementLine4,EndorsementLine5," +
                                "EndorsementLine6,EmvRespCode,TransactionData,CreateInvoiceNo,CreateDate,CreateTime,CreateUserId,CreateUserName,CreateStation) " +
                                                            "VALUES (" +
                                "@Id,@TranId,@ReceiptInformation,@SeqNo,@TransactionType,@TransactionStatus,@TransactionDate,@TransactionTime,@TransactionAmount," +
                                "@TipAmount,@CashBackAmount,@SurchargeAmount,@TaxAmount,@TotalAmount,@InvoiceNo,@PurchaseOrderNo,@ReferenceNo,@TransactionSequenceNo," +
                                "@TicketNo,@VoucherNo,@ClerkId,@GiftCardReferenceNo,@OriginalTransactionType,@CustomerCardType,@CustomerCardDescription,@CustomerAccountNumber," +
                                "@CustomerLanguage,@CustomerAccountType,@CustomerCardEntryMode,@EmvAid,@EmvTvr,@EmvTsi,@EMVApplicationLabel,@CVMResult,@AuthorizationNo," +
                                "@HostResponseCode,@HostResponseText,@HostResponseISOCode,@RetrievalReferenceNo,@AmountDue,@TraceNo,@CardBalance,@HostTransactionRefNbr," +
                                "@BatchNumber,@TerminalId,@DemoMode,@MerchId,@MerchCurrencyCode,@ReceiptHeader1,@ReceiptHeader2,@ReceiptHeader3,@ReceiptHeader4," +
                                "@ReceiptHeader5,@ReceiptHeader6,@ReceiptHeader7,@ReceiptFooter1,@ReceiptFooter2,@ReceiptFooter3,@ReceiptFooter4,@ReceiptFooter5," +
                                "@ReceiptFooter6,@ReceiptFooter7,@EndorsementLine1,@EndorsementLine2,@EndorsementLine3,@EndorsementLine4,@EndorsementLine5," +
                                "@EndorsementLine6,@EmvRespCode,@TransactionData,@CreateInvoiceNo,@CreateDate,@CreateTime,@CreateUserId,@CreateUserName,@CreateStation)"; 
                var count = connection.Execute(query, pos1_CardReceiptCompleteModel);
                return count;
            }
        }

        public List<POS1_OrderCompleteModel> Get_OrderComplete_by_InvoiceNo(int iNewInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                var output = connection.Query<POS1_OrderCompleteModel>($"select * from OrderComplete where InvoiceNo = {iNewInvNo} Order by Id").ToList();
                return output;
            }
        }
        public int Get_New_InvoiceNo()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                var output = connection.Query<POS1_OrderCompleteModel>($"select MAX(InvoiceNo) As InvoiceNo from OrderComplete").ToList();
                int iNewInvNo = 1000;
                if (output.Count > 0)
                {
                    iNewInvNo = output[0].InvoiceNo + 1;
                }
                return iNewInvNo;
            }
        }
        public int Get_MaxReceiptNo_TranCollection()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                var output = connection.Query<POS1_TranCollectionModel>($"select MAX(ReceiptNo) As ReceiptNo from TranCollection").ToList();
                int iNewReciptNo = 1000;
                if (output.Count > 0)
                {
                    iNewReciptNo = output[0].ReceiptNo + 1;
                }
                return iNewReciptNo;
            }
        }

        public List<POS1_TranCollectionModel> Get_TranCollection_by_InvoiceNo(int iNewInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                var output = connection.Query<POS1_TranCollectionModel>($"select * from TranCollection where InvoiceNo = {iNewInvNo}").ToList();
                return output;
            }
        }

        public POS1_TranCollectionModel Get_One_TranCollection_by_InvoiceNo(int iNewInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                var output = connection.Query<POS1_TranCollectionModel>($"select * from TranCollection where InvoiceNo = {iNewInvNo}").ToList();
                return output[0];
            }
        }
        public POS1_TranCollectionModel Get_One_TranCollection_by_Id(int p_iId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                var output = connection.Query<POS1_TranCollectionModel>($"select * from TranCollection where Id = {p_iId}").ToList();
                return output[0];
            }
        }
        public List<POS1_TranCollectionModel> Get_TranCollection_by_Date_Tender(string strStartDate, string strEndDate, string strTender)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                strTender = strTender.Trim();
                if (strTender == "All")
                {
                    var output = connection.Query<POS1_TranCollectionModel>($"select * from TranCollection where CreateDate >= '{strStartDate}' and CreateDate <= '{strEndDate}' " +
                                                                                               "order by CreateDate desc, CreateTime desc").ToList();
                    return output;
                }
                else
                {
                    var output = connection.Query<POS1_TranCollectionModel>($"select * from TranCollection where CreateDate >= '{strStartDate}' and CreateDate <= '{strEndDate}' " +
                                                                                               $" And CollectionType like '%{strTender}%' " +
                                                                           "order by CreateDate desc, CreateTime desc").ToList();
                    return output;
                }
            }
        }
        public List<POS1_TranCollectionModel> Get_TranCollection_by_Date_Tender_Void(string strStartDate, string strEndDate, string strTender)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                strTender = strTender.Trim();
                if (strTender == "All")
                {
                    var output = connection.Query<POS1_TranCollectionModel>($"select * from TranCollection where CreateDate >= '{strStartDate}' and CreateDate <= '{strEndDate}' And IsVoid = 1 " +
                                                                                               "order by CreateDate desc, CreateTime desc").ToList();
                    return output;
                }
                else
                {
                    var output = connection.Query<POS1_TranCollectionModel>($"select * from TranCollection where CreateDate >= '{strStartDate}' and CreateDate <= '{strEndDate}' And IsVoid = 1 " +
                                                                                               $" And CollectionType like '%{strTender}%' " +
                                                                           "order by CreateDate desc, CreateTime desc").ToList();
                    return output;
                }
            }
        }
        public List<POS1_TranCollectionModel> Get_TranCollection_by_DateTimeRange(string strStartDate, string strStartTime, string strEndDate, string strEndTime)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "select * from TranCollection where CreateDate >= '" + strStartDate + "' and CreateDate <= '" + strEndDate + "' " +
                               " And CreateTime >= '" + strStartTime + "' and CreateTime <= '" + strEndTime + "' " +
                               " And (IsNull(IsVoid, 0) = 0)  " +
                               "order by CreateDate, CreateTime ";
                var output = connection.Query<POS1_TranCollectionModel>(query).ToList();
                return output;
            }
        }
        public List<POS1_TranCollectionModel> Get_VoidTranCollection_by_DateTimeRange(string strStartDate, string strStartTime, string strEndDate, string strEndTime)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "select * from TranCollection where CreateDate >= '" + strStartDate + "' and CreateDate <= '" + strEndDate + "' " +
                               " And CreateTime >= '" + strStartTime + "' and CreateTime <= '" + strEndTime + "' " +
                               " And (Isvoid = 1) " +
                               "order by CreateDate, CreateTime ";
                var output = connection.Query<POS1_TranCollectionModel>(query).ToList();
                return output;
            }
        }
        public List<POS1_OrderCompleteModel> Get_OrderComplete_by_Date_OrderBy_Type(string strStartDate, string strStartTime, string strEndDate, string strEndTime)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "select * from OrderComplete where CompleteDate >= '" + strStartDate + "' and CompleteDate <= '" + strEndDate + "' " +
                                                                           " And CompleteTime >= '" + strStartTime + "' and CompleteTime <= '" + strEndTime + "' " +
                                                                           " And (IsNull(IsVoid, 0) = 0)  " +
                                                                           " order by ProductTypeId";
                var output = connection.Query<POS1_OrderCompleteModel>(query).ToList();
                return output;
            }
        }
        public List<POS1_OrderCompleteModel> Get_OrderComplete_by_Date_OrderBy_TypeProductId(string strStartDate, string strStartTime, string strEndDate, string strEndTime)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "select * from OrderComplete where CompleteDate >= '" + strStartDate + "' and CompleteDate <= '" + strEndDate + "' " +
                                                                           " And CompleteTime >= '" + strStartTime + "' and CompleteTime <= '" + strEndTime + "' " +
                                                                           " And (IsNull(IsVoid, 0) = 0) " +
                                                                           " order by ProductTypeId, ProductId";
                var output = connection.Query<POS1_OrderCompleteModel>(query).ToList();
                return output;
            }
        }
        public List<POS1_ProductPopModel> Get_ProdPopularity_OrderComp()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                var output = connection.Query<POS1_ProductPopModel>($"select distinct productid, SUM(Quantity) as QTY from OrderComplete group by productid order by QTY desc").ToList();
                return output;
            }
        }

        public static implicit operator DataAccessPOS1(DataAccessPOS v)
        {
            throw new NotImplementedException();
        }
        public int Set_Void_OrderCoplete_by_InvoiceNo(int iSelInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "UPDATE OrderComplete SET IsVoid = 1, VoidDate='" + DateTime.Now.ToString("yyyy-MM-dd") + "', VoidTime='" + DateTime.Now.ToString("hh:mm:ss") + "' " +
                                "WHERE InvoiceNo=" + iSelInvNo.ToString();
                var count1 = connection.Execute(query);

                return count1;
            }
        }
        public int Set_Void_Transaction_by_InvoiceNo(int iSelInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "UPDATE OrderComplete SET IsVoid = 1, VoidDate='" + DateTime.Now.ToString("yyyy-MM-dd") + "', VoidTime='" + DateTime.Now.ToString("hh:mm:ss") + "' " +
                                "WHERE InvoiceNo=" + iSelInvNo.ToString();
                var count1 = connection.Execute(query);

                List<POS1_OrderCompleteModel> pos1_OrderComps = new List<POS1_OrderCompleteModel>();
                POS_ProductModel prod = new POS_ProductModel();

                pos1_OrderComps = Get_OrderComplete_by_InvoiceNo(iSelInvNo);
                foreach (POS1_OrderCompleteModel pos1_OrderComp in pos1_OrderComps)
                {
                    DataAccessPOS dbPOS = new DataAccessPOS();
                    if (pos1_OrderComp.Quantity != 0)
                    {
                        try
                        {
                            prod = dbPOS.Get_Product_By_ID(pos1_OrderComp.ProductId)[0];
                            if (prod != null)
                            {
                                prod.Balance = prod.Balance + pos1_OrderComp.Quantity;
                                // Inventory Balance update
                                dbPOS.Update_Product_Balance(prod);

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

                query = "UPDATE TranCollection SET IsVoid = 1, VoidDate='" + DateTime.Now.ToString("yyyy-MM-dd") + "', VoidTime='" + DateTime.Now.ToString("hh:mm:ss") + "' " +
                                "WHERE InvoiceNo=" + iSelInvNo.ToString();
                var count2 = connection.Execute(query);

                return count1;
            }
        }
        public int UnSet_Void_Transaction_by_InvoiceNo(int iSelInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "UPDATE OrderComplete SET IsVoid = 0, VoidDate='" + DateTime.Now.ToString("yyyy-MM-dd") + "', VoidTime='" + DateTime.Now.ToString("hh:mm:ss") + "' " +
                                "WHERE InvoiceNo=" + iSelInvNo.ToString();
                var count1 = connection.Execute(query);

                List<POS1_OrderCompleteModel> pos1_OrderComps = new List<POS1_OrderCompleteModel>();
                POS_ProductModel prod = new POS_ProductModel();

                pos1_OrderComps = Get_OrderComplete_by_InvoiceNo(iSelInvNo);
                foreach (POS1_OrderCompleteModel pos1_OrderComp in pos1_OrderComps)
                {
                    DataAccessPOS dbPOS = new DataAccessPOS();
                    if (pos1_OrderComp.Quantity != 0)
                    {
                        try
                        {
                            prod = dbPOS.Get_Product_By_ID(pos1_OrderComp.ProductId)[0];
                            if (prod != null)
                            {
                                prod.Balance = prod.Balance - pos1_OrderComp.Quantity;
                                dbPOS.Update_Product_Balance(prod);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

                query = "UPDATE TranCollection SET IsVoid = 0, VoidDate='" + DateTime.Now.ToString("yyyy-MM-dd") + "', VoidTime='" + DateTime.Now.ToString("hh:mm:ss") + "' " +
                                "WHERE InvoiceNo=" + iSelInvNo.ToString();
                var count2 = connection.Execute(query);

                return count1;
            }
        }
        public bool IsVoidCollection(int iSelInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                var output = connection.Query<POS_ProductTypeModel>($"select * from TranCollection where InvoiceNo = {iSelInvNo} And IsVoid = 1 ").ToList();
                if (output.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        public string[] Get_TenderList_FromCollection()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string[] strTenders = connection.Query<string>($"Select distinct CollectionType FROM TranCollection " +
                                                                $"where CollectionType not like '%/%' And CollectionType <> '' Order By CollectionType").ToArray();
                if (strTenders.Length > 0)
                    return strTenders;
                else
                    return null;
            }
        }

        public POS1_OrderCompleteModel Get_OrderComplete_by_Id(int p_iOrderItemId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                if (p_iOrderItemId == 0) return null;
                var output = connection.Query<POS1_OrderCompleteModel>($"select * from OrderComplete where Id = {p_iOrderItemId}").ToList();
                if (output.Count > 0)
                    return output[0];
                else
                    return null;
            }
        }

        public POS1_OrderCompleteModel Get_Refund_OrderComplete_by_InvoiceNo_ProdId(int p_invoiceNo, int p_productId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                if (p_invoiceNo == 0) return null;
                var output = connection.Query<POS1_OrderCompleteModel>($"select * from OrderComplete where InvoiceNo = {p_invoiceNo} and ProductId = {p_productId} and Quantity < 0;").ToList();
                if (output.Count > 0)
                    return output[0];
                else
                    return null;
            }
        }

        public POS1_TranCollectionModel Get_Last_TranCollection()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                var output = connection.Query<POS1_TranCollectionModel>($"SELECT TOP (1) * from TranCollection WHERE ISNULL(IsVoid,0) = 0 order by InvoiceNo Desc").ToList();
                return output[0];
            }
        }

        public void Insert_ProductInventoryLog(POS_ProductModel p_Prod, int p_iLogTypeId, float fBeforeQTY, float fAfterQTY, string p_PassCode, string p_Station)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "INSERT INTO InventoryLog (ProductID, ProductTypeId, LogTypeId, BeforeQTY, AfterQTY, CreateStation, CreatePassCode, DateTimeCreated) VALUES " +
                                "(@ProductID, @ProductTypeId, @LogTypeId, @BeforeQTY, @AfterQTY, @CreateStation, @CreatePassCode, @DateTimeCreated);";

                POS1_InventoryLogModel invLog = new POS1_InventoryLogModel();
                invLog.ProductId = p_Prod.Id;
                invLog.ProductTypeId = p_Prod.ProductTypeId;
                invLog.LogTypeId = p_iLogTypeId;
                invLog.BeforeQTY = fBeforeQTY;
                invLog.AfterQTY = fAfterQTY;
                invLog.CreateStation = p_Station;
                invLog.CreatePassCode = p_PassCode;
                invLog.DateTimeCreated = DateTime.Now;

                var count2 = connection.Execute(query, invLog);
            }
        }

        public List<POS1_DailySalesModel> Get_DailySales(string v1, string v2)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "SELECT Distinct CreateDate As TranDate, " +
                                "Sum(Amount) As Amount, Sum(Tax1) As Tax1, Sum(Tax2) As Tax2, Sum(Tax3) As Tax3, Sum(TotalDue) As TotalSales, " + 
                                "Sum(Cash) As Cash, Sum(Debit) As Debit, Sum(Visa) As Visa, Sum(Master) As Master, Sum(Amex) As Amex, Sum(GiftCard) As GiftCard, Sum(Cheque) As Cheque, Sum(Charge) As Charge, " + 
                                "Count(*)  As Trans " +
                               "from TranCollection where CreateDate >= '" + v1 + "' and CreateDate <= '" + v2 + "' " +
                               "group by CreateDate order by CreateDate";
                var output = connection.Query<POS1_DailySalesModel>(query).ToList();
                return output;
            }
        }
    }
}
