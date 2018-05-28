using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace ToLet
{
    public partial class AddNewProperty : Form
    {
        MainUI m;
        string imageLocation = "";
        string user, pass;

        public AddNewProperty()
        {
            InitializeComponent();
        }

        public AddNewProperty(MainUI m,string user,string pass)
        {
            InitializeComponent();
            this.m = m;
            this.user = user;
            this.pass = pass;
        }

        private void AddNewProperty_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void FillComboBox()
        {
            List<string> tenantCategoryList = new List<string>();
            tenantCategoryList = ToLet.Database.DBDataList.getTenantCategoryList();
            foreach (var values in tenantCategoryList)
            {
                AddTenantCategoryCB.Items.AddRange(new object[] { values });
            }

            List<string> homeCategoryList = new List<string>();
            homeCategoryList = ToLet.Database.DBDataList.getHomeCategoryList();
            foreach (var values in homeCategoryList)
            {
                AddHomeCategoryCB.Items.AddRange(new object[] { values });
            }

            List<string> LocationList = new List<string>();
            LocationList = ToLet.Database.DBDataList.getLocationList();
            foreach (var values in LocationList)
            {
                AddLocationCB.Items.AddRange(new object[] { values });
            }

           

            List<int> roomCountList = new List<int>();
            roomCountList = ToLet.Database.DBDataList.getRoomCountList();
            foreach (var values in roomCountList)
            {
                AddRoomCountCB.Items.AddRange(new object[] { values });

            }

            List<string> durationList = new List<string>();
            durationList = ToLet.Database.DBDataList.getDurationList();
            foreach (var values in durationList)
            {
                DurationCB.Items.AddRange(new object[] { values });

            }


           

        }

        private void BrowsePropertyImageBTN_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opnfdlg = new OpenFileDialog();
                opnfdlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All Files(*.*)|*.*";
                opnfdlg.Title = "Select Image";
                if (opnfdlg.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = opnfdlg.FileName.ToString();
                    AddPropertyImagePB.ImageLocation = imageLocation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SavePropertyBTN_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                AddPropertyImagePB.Image.Save(ms, AddPropertyImagePB.Image.RawFormat);
                byte[] arrpic = ms.GetBuffer();


                if (arrpic == null)
                {
                    ToLet.Classes.PropertyDetails pd = new Classes.PropertyDetails(AddTenantCategoryCB.SelectedItem.ToString(), AddHomeCategoryCB.SelectedItem.ToString(), AddLocationCB.SelectedItem.ToString(), AddRoomCountCB.SelectedItem.ToString(), AddDetaiedAddressTB.Text, AddAdditionalCommentsTB.Text, AddPriceTB.Text,DurationCB.SelectedItem.ToString());

                    ToLet.DBDataProvider.DBDataProvider.setProperty(pd, null,user,pass);
                }
                else
                {
                    ToLet.Classes.PropertyDetails pd = new Classes.PropertyDetails(AddTenantCategoryCB.SelectedItem.ToString(), AddHomeCategoryCB.SelectedItem.ToString(), AddLocationCB.SelectedItem.ToString(), AddRoomCountCB.SelectedItem.ToString(), AddDetaiedAddressTB.Text, AddAdditionalCommentsTB.Text, AddPriceTB.Text,DurationCB.SelectedItem.ToString());
                    ToLet.DBDataProvider.DBDataProvider.setProperty(pd, arrpic,user,pass);
                }
               m.GetData();

               this.Hide();
            }
            catch (Exception)
            {
               
               MessageBox.Show("Please fill up the form propely");
                /* https://www.youtube.com/watch?v=BqyAAGMfTD8 */
            }


        }
    }
}
