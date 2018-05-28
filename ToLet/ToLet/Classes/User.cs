using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLet.Classes
{
    public class User
    {

        private string firstName, lastName, userName, password, email, gender, dob, nidNo, address;
        private int mobileNo;

        public User()
        {
        }
        public User(string firstName, string lastName, string userName, string password,string email, string gender, string dob, string nidNo,string address,int mobileNo)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.gender = gender;
            this.dob = dob;
            this.nidNo = nidNo;
            this.address = address;
            this.mobileNo = mobileNo;
        }

        public string FirstName
        {
            set { this.firstName = value; }
            get { return this.firstName; }
        }

        public string LastName
        {
            set { this.lastName = value; }
            get { return this.lastName; }
        }

        public string UserName
        {
            set { this.userName = value; }
            get { return this.userName; }
        }

       

        public string Email
        {
            set { this.email = value; }
            get { return this.email; }
        }

       

        public string DOB
        {
            set { this.dob = value; }
            get { return this.dob; }
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

        public string Password
        {
            set { this.password = value; }
            get { return this.password; }
        }
        public string Gender
        {
            set { this.gender = value; }
            get { return this.gender; }
        }
      
    }
}
