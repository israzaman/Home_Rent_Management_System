using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToLet
{
    public partial class MailBox : Form
    {
        MainUI m;
        public MailBox()
        {
            InitializeComponent();
        }
        public MailBox(MainUI m)
        {
            InitializeComponent();
            this.m = m;
        }

        private void DeletMailBTN_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            ToLet.Database.DBConnectionProvider.getDBConnection();


            string id = MailIdLBL.Text;
            int mid = Convert.ToInt32(id);

            string mt = MailTypeLBL.Text;
            ToLet.DBDataProvider.DBDataProvider.DeletMail(mid, mt);
            MessageBox.Show("Successfully deleted!!!");
            m.GetData();
        }

        

        
    }
}
