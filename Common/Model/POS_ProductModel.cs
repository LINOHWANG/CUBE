using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS_ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string SecondName { get; set; }
        public int ProductTypeId { get; set; }
        public float InUnitPrice { get; set; }
        public float OutUnitPrice { get; set; }

        public float Balance { get; set; }
        public bool IsTax1 { get; set; }
        public bool IsTax2 { get; set; }
        public bool IsTax3 { get; set; }
        public bool IsTaxInverseCalculation { get; set; }

        public string Unit { get; set; }
        public bool IsPrinter1 { get; set; }
        public bool IsPrinter2 { get; set; }
        public bool IsPrinter3 { get; set; }
        public bool IsPrinter4 { get; set; }
        public bool IsPrinter5 { get; set; }
        public string PromoStartDate { get; set; }
        public string PromoEndDate { get; set; }
        public int PromoDay1 { get; set; }
        public int PromoDay2 { get; set; }
        public int PromoDay3 { get; set; }
        public float PromoPrice1 { get; set; }
        public float PromoPrice2 { get; set; }
        public float PromoPrice3 { get; set; }
        public bool IsSoldOut { get; set; }
        public float Deposit { get; set; }
        public float RecyclingFee { get; set; }
        public float ChillCharge { get; set; }
        public string MemoText { get; set; }
        public string BarCode { get; set; }
        public string TaxCode { get; set; }
        public bool IsManualItem { get; set; }
        public bool IsMainSalesButton { get; set; }
        public bool IsSalesButton { get; set; }

        public string ForeColor { get; set; }
        public string BackColor { get; set; }

        public int CategoryId { get; set; }
        public bool IsButtonInButton { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }

        public bool IsPromoExactQty { get; set; }

    }
}
