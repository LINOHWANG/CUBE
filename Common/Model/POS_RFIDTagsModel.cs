using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS_RFIDTagsModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string SerialNo { get; set; }
        public string TagType { get; set; }
        public string Standard { get; set; }
        public bool IsUsed { get; set; }
        public DateTime DateTimeRegistered { get; set; }
        public DateTime DateTimeUsed { get; set; }
        public int InvoiceNo { get; set; }
        public float DiscountRate { get; set; }
        public DateTime DateTimeDiscount { get; set; }
        public bool IsDonation { get; set; }
        public DateTime DateTimeDonation { get; set; }
    }
}
