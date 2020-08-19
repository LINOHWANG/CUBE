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
    public class DataAccessCard
    {
        Utility util = new Utility();
        public int Insert_CardReceipt(CCardReceipt pos_CardReceiptModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO CardReceipt (ReceiptInformation,SeqNo,TransactionType,TransactionStatus,TransactionDate,TransactionTime, " +
                                "TransactionAmount,TipAmount,CashBackAmount,SurchargeAmount,TaxAmount,TotalAmount,InvoiceNo,PurchaseOrderNo,ReferenceNo," +
                                "TransactionSequenceNo,TicketNo,VoucherNo,ClerkId,GiftCardReferenceNo,OriginalTransactionType,"+
                                "CustomerCardType,CustomerCardDescription,CustomerAccountNumber,CustomerLanguage,CustomerAccountType,CustomerCardEntryMode,"+
                                "EmvAid,EmvTvr,EmvTsi,EMVApplicationLabel,CVMResult,AuthorizationNo,HostResponseCode,HostResponseText,HostResponseISOCode,"+
                                "RetrievalReferenceNo,AmountDue,TraceNo,CardBalance,HostTransactionRefNbr,BatchNumber,TerminalId,DemoMode,MerchId,MerchCurrencyCode,"+
                                "ReceiptHeader1,ReceiptHeader2,ReceiptHeader3,ReceiptHeader4,ReceiptHeader5,ReceiptHeader6,ReceiptHeader7,"+
                                "ReceiptFooter1,ReceiptFooter2,ReceiptFooter3,ReceiptFooter4,ReceiptFooter5,ReceiptFooter6,ReceiptFooter7,"+
                                "EndorsementLine1,EndorsementLine2,EndorsementLine3,EndorsementLine4,EndorsementLine5,EndorsementLine6,"+
                                "EmvRespCode,TransactionData,CreateInvoiceNo,CreateDate,CreateTime,CreateUserId,CreateUserName,CreateStation)"+
                                "VALUES (@ReceiptInformation,@SeqNo,@TransactionType,@TransactionStatus,@TransactionDate,@TransactionTime,@TransactionAmount,"+
                                "@TipAmount,@CashBackAmount,@SurchargeAmount,@TaxAmount,@TotalAmount,@InvoiceNo,@PurchaseOrderNo,@ReferenceNo," +
                                "@TransactionSequenceNo,@TicketNo,@VoucherNo,@ClerkId,@GiftCardReferenceNo,@OriginalTransactionType," +
                                "@CustomerCardType,@CustomerCardDescription,@CustomerAccountNumber,@CustomerLanguage,@CustomerAccountType,@CustomerCardEntryMode," +
                                "@EmvAid,@EmvTvr,@EmvTsi,@EMVApplicationLabel,@CVMResult,@AuthorizationNo,@HostResponseCode,@HostResponseText,@HostResponseISOCode," +
                                "@RetrievalReferenceNo,@AmountDue,@TraceNo,@CardBalance,@HostTransactionRefNbr,@BatchNumber,@TerminalId,@DemoMode,@MerchId,@MerchCurrencyCode," +
                                "@ReceiptHeader1,@ReceiptHeader2,@ReceiptHeader3,@ReceiptHeader4,@ReceiptHeader5,@ReceiptHeader6,@ReceiptHeader7," +
                                "@ReceiptFooter1,@ReceiptFooter2,@ReceiptFooter3,@ReceiptFooter4,@ReceiptFooter5,@ReceiptFooter6,@ReceiptFooter7," +
                                "@EndorsementLine1,@EndorsementLine2,@EndorsementLine3,@EndorsementLine4,@EndorsementLine5,@EndorsementLine6," +
                                "@EmvRespCode,@TransactionData,@CreateInvoiceNo,@CreateDate,@CreateTime,@CreateUserId,@CreateUserName,@CreateStation)";
                var count = connection.Execute(query, pos_CardReceiptModel);
                return count;
            }
        }
        public int Insert_CardTran(CCardTran pos_CardTranModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                string query = "INSERT INTO CardTran (TransactionStatus,MultiTranFlag,TransactionType,TransactionDate,TransactionTime,TransactionAmount," +
                                "TipAmount,CashBackAmount,SurchargeAmount,TaxAmount,TotalAmount,InvoiceNo,PurchaseOrderNo,ReferenceNo," +
                                "TransactionSequenceNo, TicketNo, VoucherNo, ClerkId, GiftCardReferenceNo, OriginalTransactionType," +
                                "CustomerCardType, CustomerAccountNumber, CustomerCardEntryMode, CardNotPresent, AuthorizationNo, HostResponseCode, HostResponseText," +
                                "HostResponseISOCode, AmountDue, CardBalance, HostTransactionRefNbr, TerminalId, DemoMode, TransactionData," +
                                "CreateInvoiceNo, CreateDate, CreateTime, CreateUserId, CreateUserName, CreateStation) "+
                                "VALUES (@TransactionStatus,@MultiTranFlag,@TransactionType,@TransactionDate,@TransactionTime,@TransactionAmount," +
                                "@TipAmount,@CashBackAmount,@SurchargeAmount,@TaxAmount,@TotalAmount,@InvoiceNo,@PurchaseOrderNo,@ReferenceNo," +
                                "@TransactionSequenceNo, @TicketNo, @VoucherNo, @ClerkId, @GiftCardReferenceNo, @OriginalTransactionType," +
                                "@CustomerCardType,@CustomerAccountNumber,@CustomerCardEntryMode,@CardNotPresent,@AuthorizationNo,@HostResponseCode,@HostResponseText," +
                                "@HostResponseISOCode,@AmountDue,@CardBalance,@HostTransactionRefNbr,@TerminalId,@DemoMode,@TransactionData," +
                                "@CreateInvoiceNo,@CreateDate,@CreateTime,@CreateUserId,@CreateUserName,@CreateStation)";
                var count = connection.Execute(query, pos_CardTranModel);
                return count;
            }
        }

        public float Get_TenderAmount(int iInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<CCardReceipt>($"select * from CardReceipt where CreateInvoiceNo = {iInvNo}").ToList();
                float fTenderAmount = 0;
                if (output.Count > 0)
                {
                    fTenderAmount = (float)System.Convert.ToDouble(output[0].TransactionAmount)/100;
                }
                return fTenderAmount;
            }
        }

        public float Get_TipAmount(int iInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<CCardReceipt>($"select * from CardReceipt  where CreateInvoiceNo = {iInvNo}").ToList();
                float fTipAmount = 0;
                if (output.Count > 0)
                {
                    fTipAmount = (float)System.Convert.ToDouble(output[0].TipAmount) / 100;
                }
                return fTipAmount;
            }
        }

        public List<CCardReceipt> Get_Approved_CardReceipt_By_InvoiceNo(int iInvNo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("POS")))
            {
                var output = connection.Query<CCardReceipt>($"select * from CardReceipt where CreateInvoiceNo  = {iInvNo} and TransactionStatus ='00'").ToList();
                return output;
            }
        }
    }
}
