using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS_SysConfigModel
    {
        public int Id { get; set; }
        public string ConfigName { get; set; }
        public string ConfigDesc { get; set; }
        public string ConfigValue { get; set; }
        public bool IsActive { get; set; }
    }
}
