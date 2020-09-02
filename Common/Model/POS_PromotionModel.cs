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
        public float PromoValue { get; set; }
        public int PromoQTY { get; set; }
        public DateTime PromoStartDttm { get; set; }
        public DateTime PromoEndDttm { get; set; }
    }
}
