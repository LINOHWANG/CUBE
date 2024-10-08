using System;
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
                                "@IsTax1, @IsTax2, @IsTax3, @UnitCategoryId, @Deposit, @RecyclingFee, @ChillCharge, @IsPointException,"+
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
                                "CreateStation,LastModDate,LastModTime,LastModPasswordCode,LastModPasswordName,LastModStation, OthersTip) " +
                                "VALUES (" +
                                "@ReceiptNo,@InvoiceNo,@SplitId,@TableId,@TableName,@NumOfPeople,CAST(@Amount as decimal(10,2)),CAST(@Tax1 as decimal(10,2)),CAST(@Tax2 as decimal(10,2)),CAST(@Tax3 as decimal(10,2))," +
                                "CAST(@TotalDue as decimal(10,2)),@CollectionType,@IsOnline,CAST(@Cash as decimal(10,2)),CAST(@Debit as decimal(10,2)),"+
                                "CAST(@Visa as decimal(10,2)),CAST(@Master as decimal(10,2)),CAST(@Amex as decimal(10,2)),CAST(@Giftcard as decimal(10,2)),CAST(@Others as decimal(10,2))," +
                                "CAST(@CashTip as decimal(10,2)),CAST(@DebitTip as decimal(10,2)),CAST(@VisaTip as decimal(10,2)),CAST(@MasterTip as decimal(10,2)),"+
                                "CAST(@AmexTip as decimal(10,2)),CAST(@DebitFee as decimal(10,2)),CAST(@VisaFee as decimal(10,2)),CAST(@MasterFee as decimal(10,2)),"+
                                "CAST(@AmexFee as decimal(10,2)),CAST(@DebitTipFee as decimal(10,2)),CAST(@VisaTipFee as decimal(10,2))," +
                                "CAST(@MasterTipFee as decimal(10,2)),CAST(@AmexTipFee as decimal(10,2)),CAST(@TotalPaid as decimal(10,2)),CAST(@TotalTip as decimal(10,2)),"+
                                "CAST(@Change as decimal(10,2)),@CreateDate,@CreateTime,@CreatePasswordCode,@CreatePasswordName," +
                                "@CreateStation,@LastModDate,@LastModTime,@LastModPasswordCode,@LastModPasswordName,@LastModStation, CAST(@OthersTip as decimal(10,2)))";
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
                                "@EndorsementLine6,@EmvRespCode,@TransactionData,@CreateInvoiceNo,@CreateDate,@CreateTime,@CreateUserId,@CreateUserName,@CreateStation)"; var count = connection.Execute(query, pos1_CardReceiptCompleteModel);
                return count;
            }
        }

        public List<POS1_OrderCompleteModel> Get_OrderComplete_by_InvoiceNo(int iNewInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                var output = connection.Query<POS1_OrderCompleteModel>($"select * from OrderComplete where InvoiceNo = {iNewInvNo}").ToList();
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
        public List<POS1_TranCollectionModel> Get_TranCollection_by_DateTimeRange(string strStartDate, string strStartTime, string strEndDate, string strEndTime)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS1")))
            {
                string query = "select * from TranCollection where CreateDate >= '" + strStartDate + "' and CreateDate <= '" + strEndDate + "' " +
                               " And CreateTime >= '" + strStartTime + "' and CreateTime <= '" + strEndTime + "' " +
                               " And (Isvoid < 1 or IsVoid Is NULL) " +
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
                                                                           " And (Isvoid < 1 or IsVoid Is NULL) " +
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
                                                                           " And (IsVoid Is NULL) " +
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
                string[] strTenders = connection.Query<string>($"Select distinct CollectionType FROM [db1SSShop].[dbo].[TranCollection] " +
                                                                $"where CollectionType not like '%/%' And CollectionType <> '' Order By CollectionType").ToArray();
                if (strTenders.Length > 0)
                    return strTenders;
                else
                    return null;
            }
        }
    }
}
