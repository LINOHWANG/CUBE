using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SDCafeCommon.Model
{
    [XmlRoot(ElementName = "TRANS")]
    public class POS_PmTreeRespModel
    {
        public int Id { get; set; }
        public string PAYLinqTransID { get; set; }
        public string reqtransid { get; set; }
        public string CheckNumber { get; set; }
        public string TransRespCode { get; set; }
        public string TransRespMsg { get; set; }
        public string CardNo { get; set; }
        public string CardTypeUsed { get; set; }
        public string InvoiceNumber { get; set; }
        public string ProviderTransID { get; set; }
        public string CardBalance { get; set; }
        public string CardExpDate { get; set; }
        public string ProcessedAmount { get; set; }
        public string cardentrymode { get; set; }
        public string CardCode { get; set; }
        public string MerchantReceipt { get; set; }
        public string CustomerReceipt { get; set; }
        public string ServerNumber { get; set; }
        public string TipAmt { get; set; }
        public string Signature { get; set; }
        public string MimeType { get; set; }
        public string EmvName { get; set; }
        public string EmvAid { get; set; }
        public string EmvTvr { get; set; }
        public string EmvTsi { get; set; }
        public string Trace { get; set; }
        public string MEndorse { get; set; }
        public string CEndorse { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Account { get; set; }
        public string CustLang { get; set; }
        public string Token { get; set; }
        public string TokenExp { get; set; }
        public string TransactionCode { get; set; }
        public string SurCharge { get; set; }
        public string SignatureReq { get; set; }
        public string CvmResult { get; set; }
        public string CustomerReference { get; set; }
        public string DebitRRN { get; set; }
        public string DeviceID { get; set; }
        public string TableNumber { get; set; }
        public string TransactionStatus { get; set; }
        public string TerminalReference { get; set; }
        public string HostResponseMsg { get; set; }
        public string HostResponseCode { get; set; }
        public string BatchNo { get; set; }
        public string TerminalId { get; set; }
        public string MerchantID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCardDescription { get; set; }
        public string SequenceNumber { get; set; }
        public string TransactionReferenceNumber { get; set; }

    }
}
