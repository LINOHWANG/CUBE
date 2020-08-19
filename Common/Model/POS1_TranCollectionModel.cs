using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS1_TranCollectionModel
    {
        public int Id { get; set; }
        public int ReceiptNo { get; set; }
        public int InvoiceNo { get; set; }
        public int SplitId { get; set; }
        public int TableId { get; set; }
        public string TableName { get; set; }
        public int NumOfPeople { get; set; }
        public float Amount { get; set; }
        public float Tax1 { get; set; }
        public float Tax2 { get; set; }
        public float Tax3 { get; set; }
        public float TotalDue { get; set; }
        public string CollectionType { get; set; }
        public bool IsOnline { get; set; }
        public float Cash { get; set; }
        public float Debit { get; set; }
        public float Visa { get; set; }
        public float Master { get; set; }
        public float Amex { get; set; }
        public float GiftCard { get; set; }
        public float Online { get; set; }
        public float CashTip { get; set; }
        public float DebitTip { get; set; }
        public float VisaTip { get; set; }
        public float MasterTip { get; set; }
        public float AmexTip { get; set; }
        public float DebitFee { get; set; }
        public float VisaFee { get; set; }
        public float MasterFee { get; set; }
        public float AmexFee { get; set; }
        public float DebitTipFee { get; set; }
        public float VisaTipFee { get; set; }
        public float MasterTipFee { get; set; }
        public float AmexTipFee { get; set; }
        public float TotalPaid { get; set; }
        public float TotalTip { get; set; }
        public float Change { get; set; }
        public string CreateDate { get; set; }
        public string CreateTime { get; set; }
        public string CreatePasswordCode { get; set; }
        public string CreatePasswordName { get; set; }
        public string CreateStation { get; set; }
        public string LastModDate { get; set; }
        public string LastModTime { get; set; }
        public string LastModPasswordCode { get; set; }
        public string LastModPasswordName { get; set; }
        public string LastModStation { get; set; }
        public bool IsVoid { get; set; }
        public string VoidDate { get; set; }
        public string VoidTime { get; set; }
        public float Rounding { get; set; }
        public bool IsOnline2 { get; set; }
        public float Online2 { get; set; }
        public float GiftCardTip { get; set; }
        public float OnlineCash { get; set; }
        public float Online2Cash { get; set; }
        public int CardTranId { get; set; }

    }

}
