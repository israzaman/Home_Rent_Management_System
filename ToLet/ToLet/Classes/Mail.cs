using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLet.Classes
{
    public class Mail
    {
        private string to, from, message;
        private int mailid;


        public Mail()
        {

        }

        public Mail(string to, string from, string message)
        {
            this.to = to;
            this.from = from;
            this.message = message;
        }

        public int MailId
        {
            set { this.mailid = value; }
            get { return this.mailid; }
        }
        public string To
        {
            set { this.to = value; }
            get { return this.to; }
        }

        public string From
        {
            set { this.from = value; }
            get { return this.from; }
        }

        public string Message
        {
            set { this.message = value; }
            get { return this.message; }
        }
    }
}
