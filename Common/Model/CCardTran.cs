using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class CCardTran
    {
        public int Id { get; set; }
        public string TransactionStatus { get; set; }
        public string MultiTranFlag { get; set; }
        public string TransactionType { get; set; }
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
        public string CustomerAccountNumber { get; set; }
        public string CustomerCardEntryMode { get; set; }
        public string CardNotPresent { get; set; }
        public string AuthorizationNo { get; set; }
        public string HostResponseCode { get; set; }
        public string HostResponseText { get; set; }
        public string HostResponseISOCode { get; set; }
        public string AmountDue { get; set; }
        public string CardBalance { get; set; }
        public string HostTransactionRefNbr { get; set; }
        public string TerminalId { get; set; }
        public string DemoMode { get; set; }
        public string TransactionData { get; set; }
        public int CreateInvoiceNo { get; set; }
        public string CreateDate { get; set; }
        public string CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public string CreateStation { get; set; }

    }
}
