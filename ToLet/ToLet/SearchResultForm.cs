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
    public partial class SearchResultForm : Form
    {
        Classes.PropertyDetails pd = new Classes.PropertyDetails();
        MainUI m;
        Classes.User user = new Classes.User();
        public SearchResultForm()
        {
            InitializeComponent();
        }
        public SearchResultForm(MainUI m,Classes.PropertyDetails pd)
        {
            InitializeComponent();
            this.pd = pd;
            this.m = m;
        }

        private void SeeResultDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string value1 = "";
            foreach (DataGridViewRow row in SeeResultDG.SelectedRows)
            {
                value1 = row.Cells[2].Value.ToString();
                

            }
          
            user = ToLet.Database.DBDataList.getUserProfile(value1);

            Image pic = ToLet.Database.DBDataList.getUserPic(value1);

            this.SeeResultTabControl.SelectedTab = this.UserProfileTAB;
            FirstNameTB.Text = user.FirstName;
            LastNameTB.Text = user.LastName;
            MobileTB.Text = user.MobileNo.ToString();
            EmailTB.Text = user.Email;
            NidTB.Text = user.NidNo;
            AddressTB.Text = user.Address;
            DateOfBirthTB.Text = user.DOB;
            ProfilePicPB.Image = pic;
            UserNameTB.Text = user.UserName;
        }

       

        private void BackResultBTN_Click_1(object sender, EventArgs e)
        {
            SeeResultTabControl.SelectedTab = SeeResultTAB;
        }

        private void AcceptBTN_Click(object sender, EventArgs e)
        {
            ToLet.Database.DBDataList.setInRentProperty(pd,m);
            this.AcceptBTN.Hide();
            MessageBox.Show("Request accepted");
            SeeResultTabControl.SelectedTab = SeeResultTAB;

            ToLet.Database.DBDataList.setTenant(user,pd,m);
            ToLet.Database.DBDataList.setMyRent(user,pd,m);
            ToLet.Database.DBDataList.setMyLandlord(user, pd, m);

        }
    }
}
