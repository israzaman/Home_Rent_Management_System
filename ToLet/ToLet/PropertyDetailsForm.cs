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
    public partial class PropertyDetailsForm : Form
    {
        MainUI m;

 
        public PropertyDetailsForm()
        {
            InitializeComponent();
        }

        public PropertyDetailsForm(MainUI m)
        {
            InitializeComponent();
            this.m = m;
        }


        private void PublishBTN_Click(object sender, EventArgs e)
        {
            Classes.PropertyDetails pd = new Classes.PropertyDetails();

            pd.TenantCategory = textBox1.Text;
            pd.HomeCategory = textBox2.Text;
            pd.Location = textBox3.Text;
            pd.RoomCount = textBox4.Text;
            pd.DetailedAddress = AddDetaiedAddressTB.Text;
            pd.AdditionalComment = AddAdditionalCommentsTB.Text;
            pd.RentRange = AddPriceTB.Text;

            ToLet.DBDataProvider.DBDataProvider.setPublishedProperty(pd);

            m.GetData();

            this.Hide();
        }

        private void RequestBTN_Click(object sender, EventArgs e)
        {
                 
                this.Hide();

                Classes.PropertyDetails pd = new Classes.PropertyDetails();

                pd.TenantCategory = textBox1.Text;
                pd.HomeCategory = textBox2.Text;
                pd.Location = textBox3.Text;
                pd.RoomCount = textBox4.Text;
                pd.DetailedAddress = AddDetaiedAddressTB.Text;
                pd.AdditionalComment = AddAdditionalCommentsTB.Text;
                pd.RentRange = AddPriceTB.Text;

                int propertyId=ToLet.Database.DBDataList.getRequestedProperty(pd);


                int userid=ToLet.Database.DBDataList.setReq(propertyId,m.user);

           
                
        }

        private void SeeRequestBTN_Click(object sender, EventArgs e)
        {
           

            Classes.PropertyDetails pd = new Classes.PropertyDetails();

            pd.TenantCategory = textBox1.Text;
            pd.HomeCategory = textBox2.Text;
            pd.Location = textBox3.Text;
            pd.RoomCount = textBox4.Text;
            pd.DetailedAddress = AddDetaiedAddressTB.Text;
            pd.AdditionalComment = AddAdditionalCommentsTB.Text;
            pd.RentRange = AddPriceTB.Text;

           
            Classes.User u = new Classes.User();
            List<int> useridlist = new List<int>();
            List<Classes.User> cu = new List<Classes.User>();
            
            useridlist = ToLet.Database.DBDataList.getRequestResult(pd);

            SearchResultForm srf = new SearchResultForm(m,pd);
            foreach (var item in useridlist)
            {
                cu.AddRange(ToLet.Database.DBDataList.getUserRequestInfo(item, srf));

            }
            srf.SeeResultDG.DataSource = cu;
            srf.SeeResultDG.Columns[0].Visible = false;
            srf.SeeResultDG.Columns[1].Visible = false;
            srf.SeeResultDG.Columns[3].Visible = false;
            srf.SeeResultDG.Columns[4].Visible = false;
            srf.SeeResultDG.Columns[5].Visible = false;
            srf.SeeResultDG.Columns[8].Visible = false;
            srf.SeeResultDG.Columns[9].Visible = false;




            this.Hide();
            srf.Show();
        }

     
    }
}
