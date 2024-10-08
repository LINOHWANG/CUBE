using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    // 20211108
    public class POS_TimeTableModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? DateTimeStarted { get; set; }
        public DateTime? DateTimeFinished { get; set; }
        public int InCount { get; set; }
        public float Wage { get; set; }
    }
}
