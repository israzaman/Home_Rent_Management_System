using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLet.Classes
{
    public class TenantClass: User
    {
        string payment;
        public string PaymentStatus
        {
            set { this.payment = value; }
            get { return this.payment; }
        }
    }
}
