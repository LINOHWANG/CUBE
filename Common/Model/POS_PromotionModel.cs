using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS_PromotionModel
    {
        public int Id { get; set; }
        public string PromoName { get; set; }
        public int PromoType { get; set; }
        public float PromoValue1 { get; set; }
        public int PromoQTY1 { get; set; }
        public float PromoValue2 { get; set; }
        public int PromoQTY2 { get; set; }
        public DateTime? PromoStartDttm { get; set; }
        public DateTime? PromoEndDttm { get; set; }
    }
}
