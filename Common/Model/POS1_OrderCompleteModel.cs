using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS1_OrderCompleteModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string TranType { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SecondName { get; set; }
        public int ProductTypeId { get; set; }
        public float InUnitPrice { get; set; }
        public float OutUnitPrice { get; set; }
        public bool IsTax1 { get; set; }
        public bool IsTax2 { get; set; }
        public bool IsTax3 { get; set; }
        public int UnitCategoryId { get; set; }
        public float Deposit { get; set; }
        public float RecyclingFee { get; set; }
        public float ChillCharge { get; set; }
        public bool IsPointException { get; set; }
        public bool IsManualPrice { get; set; }
        public bool IsTaxInverseCalculation { get; set; }
        public float Tare { get; set; }
        public float Quantity { get; set; }
        public float Amount { get; set; }
        public float Tax1Rate { get; set; }
        public float Tax2Rate { get; set; }
        public float Tax3Rate { get; set; }
        public float Tax1 { get; set; }
        public float Tax2 { get; set; }
        public float Tax3 { get; set; }
        public int InvoiceNo { get; set; }
        public bool IsPaidComplete { get; set; }
        public string CompleteDate { get; set; }
        public string CompleteTime { get; set; }
        public string CreateDate { get; set; }
        public string CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public string CreateStation { get; set; }
        public string LastModDate { get; set; }
        public string LastModTime { get; set; }
        public int LastModUserId { get; set; }
        public string LastModUserName { get; set; }
        public string LastModStation { get; set; }
        public int RFTagId { get; set; }
        public int ParentId { get; set; }
        public int OrderCategoryId { get; set; }

        public bool IsVoid { get; set; }
        public string VoidDate { get; set; }
        public string VoidTime { get; set; }
        public bool IsDiscounted { get; set; }
        public string BarCode { get; set; }
    }
}
