using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCafeCommon.Model
{
    public class POS_PmTreeTranModel
    {
        public int Id { get; set; }
        public string Client_Id { get; set; }
        public string Location { get; set; }
        public string Register { get; set; }
        public string Cashier   { get; set; }
        public string Req_Trans_Id  { get; set; }
        public string Tran_Id_To_Void { get; set; }
        public string Request_Type { get; set; }
        public string Action_Type { get; set; }
        public int Amount { get; set; }
        public string Token { get; set; }
        public string Dynamic_Ip { get; set; }
        public int Dynamic_Port { get; set; }
    }
}
