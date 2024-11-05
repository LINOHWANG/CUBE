using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS1_InventoryLogModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int LogTypeId { get; set; }
        // 1 : Recieving, 2 : Sales, 3 : Void, 4 : Refund, 5: Force Update
        public float BeforeQTY { get; set; }
        public float AfterQTY { get; set; }
        public string CreateStation { get; set; }
        public string CreatePassCode { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}
