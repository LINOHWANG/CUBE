using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS_LoginUserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public DateTime DOB { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Grade { get; set; }
        public float Wage { get; set; }
        public string PassWord { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
