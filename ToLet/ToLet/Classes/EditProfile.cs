using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLet.Classes
{
    public class EditProfile
    {

        private string password, email, nidNo, address;
        private int mobileNo;

        public EditProfile(string password, string email, string nidNo, string address, int mobileNo)
        {

            this.password = password;
            this.email = email;
            this.nidNo = nidNo;
            this.address = address;
            this.mobileNo = mobileNo;
        }




        public string Password
        {
            set { this.password = value; }
            get { return this.password; }
        }

        public string Email
        {
            set { this.email = value; }
            get { return this.email; }
        }

        public string NidNo
        {
            set { this.nidNo = value; }
            get { return this.nidNo; }
        }

        public string Address
        {
            set { this.address = value; }
            get { return this.address; }
        }

        public int MobileNo
        {
            set { this.mobileNo = value; }
            get { return this.mobileNo; }
        }
    }
}
