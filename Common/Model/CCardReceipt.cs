using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class CCardReceipt
    {
        public int Id { get; set; }
        public string ReceiptInformation { get; set; }
        public string SeqNo { get; set; }
        public string TransactionType { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionTime { get; set; }
        public string TransactionAmount { get; set; }
        public string TipAmount { get; set; }
        public string CashBackAmount { get; set; }
        public string SurchargeAmount { get; set; }
        public string TaxAmount { get; set; }
        public string TotalAmount { get; set; }
        public string InvoiceNo { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string ReferenceNo { get; set; }
        public string TransactionSequenceNo { get; set; }
        public string TicketNo { get; set; }
        public string VoucherNo { get; set; }
        public string ClerkId { get; set; }
        public string GiftCardReferenceNo { get; set; }
        public string OriginalTransactionType { get; set; }
        public string CustomerCardType { get; set; }
        public string CustomerCardDescription { get; set; }
        public string CustomerAccountNumber { get; set; }
        public string CustomerLanguage { get; set; }
        public string CustomerAccountType { get; set; }
        public string CustomerCardEntryMode { get; set; }
        public string EmvAid { get; set; }
        public string EmvTvr { get; set; }
        public string EmvTsi { get; set; }
        public string EMVApplicationLabel { get; set; }
        public string CVMResult { get; set; }
        public string AuthorizationNo { get; set; }
        public string HostResponseCode { get; set; }
        public string HostResponseText { get; set; }
        public string HostResponseISOCode { get; set; }
        public string RetrievalReferenceNo { get; set; }
        public string AmountDue { get; set; }
        public string TraceNo { get; set; }
        public string CardBalance { get; set; }
        public string HostTransactionRefNbr { get; set; }
        public string BatchNumber { get; set; }
        public string TerminalId { get; set; }
        public string DemoMode { get; set; }
        public string MerchId { get; set; }
        public string MerchCurrencyCode { get; set; }
        public string ReceiptHeader1 { get; set; }
        public string ReceiptHeader2 { get; set; }
        public string ReceiptHeader3 { get; set; }
        public string ReceiptHeader4 { get; set; }
        public string ReceiptHeader5 { get; set; }
        public string ReceiptHeader6 { get; set; }
        public string ReceiptHeader7 { get; set; }
        public string ReceiptFooter1 { get; set; }
        public string ReceiptFooter2 { get; set; }
        public string ReceiptFooter3 { get; set; }
        public string ReceiptFooter4 { get; set; }
        public string ReceiptFooter5 { get; set; }
        public string ReceiptFooter6 { get; set; }
        public string ReceiptFooter7 { get; set; }
        public string EndorsementLine1 { get; set; }
        public string EndorsementLine2 { get; set; }
        public string EndorsementLine3 { get; set; }
        public string EndorsementLine4 { get; set; }
        public string EndorsementLine5 { get; set; }
        public string EndorsementLine6 { get; set; }
        public string EmvRespCode { get; set; }
        public string TransactionData { get; set; }
        public int CreateInvoiceNo { get; set; }
        public string CreateDate { get; set; }
        public string CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public string CreateStation { get; set; }

    }
}
