using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToLet.Properties;

namespace ToLet
{
    public partial class MainUI : Form
    {
        Start start;
        public string user, pass;
        Classes.PropertyDetails property = new Classes.PropertyDetails();

        string imageLocation = "";
        OpenFileDialog opnfdlg = new OpenFileDialog();


        public MainUI()
        {
            InitializeComponent();
        }

        public MainUI(Start start,string username)
        {
            InitializeComponent();
            this.start = start;
            accountLBL.Text = username;   
            HomeTab2TAB.Controls.Add(accountLBL);
          
        }

        public  void GetData()
        {
            ToLet.DBDataProvider.DBDataProvider.getUnpublishedPropertyData(this, user);
            ToLet.DBDataProvider.DBDataProvider.getPublishedPropertyData(this, user);
            ToLet.DBDataProvider.DBDataProvider.getInRentPropertyData(this, user);
            ToLet.DBDataProvider.DBDataProvider.getMailData(this, user);
            ToLet.DBDataProvider.DBDataProvider.getInboxData(this, user);
            ToLet.DBDataProvider.DBDataProvider.getTenantData(this, user);
            ToLet.DBDataProvider.DBDataProvider.getMyRentData(this, user);
            ToLet.DBDataProvider.DBDataProvider.getMyLandlordData(this, user);



        }

        public void controlInRentFLPANEL()
        {
            PictureBox p1 = new PictureBox();
            p1.Height = 50;
            p1.Width = 50;
            p1.SizeMode = PictureBoxSizeMode.StretchImage;
            p1.BackColor = Color.Black;

            
            
        }

        public void controlUnpublishedFLPANEL()
        {
            PictureBox p1 = new PictureBox();
            p1.Height = 300;
            p1.Width = 300;
            p1.SizeMode = PictureBoxSizeMode.StretchImage;
            p1.BackColor = Color.Black;

        }

        private void HomeBTN_Click(object sender, EventArgs e)
        {
            MainUITabControl.SelectedTab = HomeTAB;
            HomeTabTabControl.SelectedTab = HomeTab2TAB;
            
        }

        private void ProfileBTN_Click(object sender, EventArgs e)
        {
            MainUITabControl.SelectedTab = ProfileTAB;
            ToLet.Classes.User u = ToLet.DBDataProvider.DBDataProvider.getUserInfo(user, pass);
            Image propic = ToLet.DBDataProvider.DBDataProvider.getProPic(user, pass);
            UserNameTB.Text = u.UserName;
            FirstNameTB.Text = u.FirstName;
            FirstNameTB.BackColor = Color.BurlyWood;
            LastNameTB.Text = u.LastName;
            LastNameTB.BackColor = Color.BurlyWood;
            MobileTB.Text = "0" + u.MobileNo.ToString();
            EmailTB.Text = u.Email;

            NidTB.Text = u.NidNo;
            NidTB.BackColor = Color.BurlyWood;
            AddressTB.Text = u.Address;
            DateOfBirthTB.Text = u.DOB;
            DateOfBirthTB.BackColor = Color.BurlyWood;
            ProfilePicPB.Image = propic;
            
            EditPasswordTB.Text = u.Password;
            ConfirmEditPasswordTB.Text = u.Password;

            SaveBTN.Visible = false;
            EditProfileBTN.Visible = true;
            BrowseNewProPicBTN.Visible = false;

            EditPasswordLBL.Visible = false;
            EditPasswordTB.Visible = false;

            ConfirmEditPasswordLBL.Visible = false;
            ConfirmEditPasswordTB.Visible = false; 
           

        }

        private void MailBoxBTN_Click(object sender, EventArgs e)
        {
           

            DataClasses1DataContext ctx = new DataClasses1DataContext();
            ToLet.Database.DBConnectionProvider.getDBConnection();



            GetData();
            MainUITabControl.SelectedTab = MailBoxTAB;
        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {
            TenantCategoryCB.SelectedIndex = -1;
            HomeCategoryCB.SelectedIndex = -1;
            LocationCB.SelectedIndex = -1;
            RoomCountCB.SelectedIndex = -1;
            DurationCB.SelectedIndex = -1;
            PriceRangeCB.SelectedIndex = -1;
            
            MainUITabControl.SelectedTab = SearchTAB;
        }

        private void AboutBTN_Click(object sender, EventArgs e)
        {
            MainUITabControl.SelectedTab = AboutTAB;
        }


        private void MainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        int i = 0;
        private void SwitchPB_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                SwitchPB.Image = Resources.powerRED;
                BattiPB.Image = Resources.lightbulbon;
                BattiPB.SizeMode = PictureBoxSizeMode.StretchImage;

                i = 1;
            }
            else
            {
                SwitchPB.Image = Resources.powerBLUE;
                BattiPB.Image = Resources.lightbulboff;
                BattiPB.SizeMode = PictureBoxSizeMode.StretchImage;
                i = 0;
 
            }
        }

        private void SearchPB_MouseHover(object sender, EventArgs e)
        {
            SearchMUIPB.Image = Resources.woodsearchRED;
        }

        private void SearchPB_MouseLeave(object sender, EventArgs e)
        {
            SearchMUIPB.Image = Resources.woodensearch1;
        }

        private void MyPropertiesBTN_Click(object sender, EventArgs e)
        {
            HomeTabTabControl.SelectedTab = MyPropertiesTAB;
            GetData();   
        }

        
        private void MyTenantsBTN_Click(object sender, EventArgs e)
        {
            HomeTabTabControl.SelectedTab = MyTenantsTAB;
            GetData();
        }

        private void MyRentsBTN_Click(object sender, EventArgs e)
        {
            HomeTabTabControl.SelectedTab = MyRentsTAB;
            GetData();

        }

        private void MyLandlordsBTN_Click(object sender, EventArgs e)
        {
            HomeTabTabControl.SelectedTab = MyLandlordsTAB;
            GetData();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            List<string> tenantCategoryList = new List<string>();
            tenantCategoryList = ToLet.Database.DBDataList.getTenantCategoryList();
            foreach (var values in tenantCategoryList)
            {
                TenantCategoryCB.Items.AddRange(new object[] { values });
            }

            List<string> homeCategoryList = new List<string>();
            homeCategoryList = ToLet.Database.DBDataList.getHomeCategoryList();
            foreach (var values in homeCategoryList)
            {
                HomeCategoryCB.Items.AddRange(new object[] { values });
            }

            List<string> LocationList = new List<string>();
            LocationList = ToLet.Database.DBDataList.getLocationList();
            foreach (var values in LocationList)
            {
                LocationCB.Items.AddRange(new object[] { values });
            }

            List<string> rentRangeList = new List<string>();
            rentRangeList = ToLet.Database.DBDataList.getRentRangeList();
            foreach (var values in rentRangeList)
            {
                PriceRangeCB.Items.AddRange(new object[] { values });
            }

            List<int> roomCountList = new List<int>();
            roomCountList = ToLet.Database.DBDataList.getRoomCountList();
            foreach (var values in roomCountList)
            {
                RoomCountCB.Items.AddRange(new object[] { values });

            }

            List<string> durationList = new List<string>();
            durationList = ToLet.Database.DBDataList.getDurationList();
            foreach (var values in durationList)
            {
                DurationCB.Items.AddRange(new object[] { values });
            }

           
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //controlUnpublishedFLPANEL();

            AddNewProperty anp = new AddNewProperty(this,user,pass);
            
            anp.Show();
           
        }

        private void LogOutBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            start.UsernameTB.Text = "";
            start.PasswordTB.Text = "";
            start.Show();
        }

        private void SearchMUIPB_Click(object sender, EventArgs e)
        {
      

            try
            {
                MainUITabControl.SelectedTab = SearchResultTAB;


                property.RentRange = PriceRangeCB.SelectedItem.ToString();

                ToLet.DBDataProvider.DBDataProvider.getSearchResult(this, property);


            }

            catch (Exception)
            {
                MainUITabControl.SelectedTab = SearchTAB;
                MessageBox.Show("Choose Category to search");

            }

        }

        public void setuserpass(string user,string pass)
        {
            this.user = user;
            this.pass = pass;
        }

        private void UnpublishedDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string value1 = "", value2 = "";
            foreach (DataGridViewRow row in UnpublishedDG.SelectedRows)
            {
                value1 = row.Cells[0].Value.ToString();
                value2 = row.Cells[1].Value.ToString();

            }
            Classes.PropertyDetails pd = new Classes.PropertyDetails();
            pd = ToLet.DBDataProvider.DBDataProvider.getPropertyInfo(value1, value2);

            Image propertypic = ToLet.DBDataProvider.DBDataProvider.getPropertyPic(value1, value2);

            if (UnpublishedDG.Focused)
            {
                PropertyDetailsForm pdf = new PropertyDetailsForm(this);
                pdf.textBox1.Text = pd.TenantCategory;
                pdf.textBox2.Text = pd.HomeCategory;
                pdf.textBox3.Text = pd.Location;
                pdf.textBox4.Text = pd.RoomCount;
                pdf.AddDetaiedAddressTB.Text = pd.DetailedAddress;
                pdf.AddAdditionalCommentsTB.Text = pd.AdditionalComment;
                pdf.AddPriceTB.Text = pd.RentRange;
                pdf.AddPropertyImagePB.Image = propertypic;
                pdf.RequestBTN.Hide();
                pdf.SeeRequestBTN.Hide();
                pdf.Show();
            }
        }

        private void PublishedDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string value1 = "", value2 = "";
            foreach (DataGridViewRow row in PublishedDG.SelectedRows)
            {
                value1 = row.Cells[0].Value.ToString();
                value2 = row.Cells[1].Value.ToString();

            }
            Classes.PropertyDetails pd = new Classes.PropertyDetails();
            pd = ToLet.DBDataProvider.DBDataProvider.getPropertyInfo(value1, value2);

            Image propertypic = ToLet.DBDataProvider.DBDataProvider.getPropertyPic(value1, value2);

            if (PublishedDG.Focused)
            {
                PropertyDetailsForm pdf = new PropertyDetailsForm(this);
                pdf.textBox1.Text = pd.TenantCategory;
                pdf.textBox2.Text = pd.HomeCategory;
                pdf.textBox3.Text = pd.Location;
                pdf.textBox4.Text = pd.RoomCount;
                pdf.AddDetaiedAddressTB.Text = pd.DetailedAddress;
                pdf.AddAdditionalCommentsTB.Text = pd.AdditionalComment;
                pdf.AddPriceTB.Text = pd.RentRange;
                pdf.AddPropertyImagePB.Image = propertypic;

                pdf.PublishBTN.Hide();
                pdf.RequestBTN.Hide();

                pdf.Show();
            }
        }

        private void InRentDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string value1 = "", value2 = "";
            foreach (DataGridViewRow row in InRentDG.SelectedRows)
            {
                value1 = row.Cells[0].Value.ToString();
                value2 = row.Cells[1].Value.ToString();

            }
            Classes.PropertyDetails pd = new Classes.PropertyDetails();
            pd = ToLet.DBDataProvider.DBDataProvider.getPropertyInfo(value1, value2);

            Image propertypic = ToLet.DBDataProvider.DBDataProvider.getPropertyPic(value1, value2);

            if (InRentDG.Focused)
            {
                PropertyDetailsForm pdf = new PropertyDetailsForm(this);
                pdf.textBox1.Text = pd.TenantCategory;
                pdf.textBox2.Text = pd.HomeCategory;
                pdf.textBox3.Text = pd.Location;
                pdf.textBox4.Text = pd.RoomCount;
                pdf.AddDetaiedAddressTB.Text = pd.DetailedAddress;
                pdf.AddAdditionalCommentsTB.Text = pd.AdditionalComment;
                pdf.AddPriceTB.Text = pd.RentRange;
                pdf.AddPropertyImagePB.Image = propertypic;

                pdf.PublishBTN.Hide();
                pdf.RequestBTN.Hide();
                pdf.SeeRequestBTN.Hide();


                pdf.Show();
            }
        }

        private void MailBoxTAB_Click(object sender, EventArgs e)
        {

        }

        private void ComposeBTN_Click(object sender, EventArgs e)
        {
            MailboxTABCTRL.SelectedTab = ComposeTAB;
        }

        private void InboxBTN_Click(object sender, EventArgs e)
        {



            DataClasses1DataContext ctx = new DataClasses1DataContext();
            ToLet.Database.DBConnectionProvider.getDBConnection();



            GetData();

            MailboxTABCTRL.SelectedTab = InboxTAB;
        }

        private void SentItemsBTN_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext ctx = new DataClasses1DataContext();
            ToLet.Database.DBConnectionProvider.getDBConnection();

            MailboxTABCTRL.SelectedTab = SentItemsTAB;
            GetData();
        }

        private void SendMailBTN_Click(object sender, EventArgs e)
        {
            if (ToTB.Text == user)
            {
                MessageBox.Show("Wanna send mail to yourself !!!");
            }
            else
            {

                DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
                ToLet.Database.DBConnectionProvider.getDBConnection();


                ToLet.Classes.Mail mail = new ToLet.Classes.Mail(ToTB.Text, user, ComposeTB.Text);
                ToLet.DBDataProvider.DBDataProvider.InsertOnMailTable(mail);
                MessageBox.Show("Mail Sent Successfully !!");

                ToTB.Text = "";
                ComposeTB.Text = "";

                GetData();
            }
        }

        private void TenantCategoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TenantCategoryCB.SelectedIndex > -1)
            {

                property.TenantCategory = TenantCategoryCB.SelectedItem.ToString();
                property = ToLet.DBDataProvider.DBDataProvider.getForTenantResult(property);


                HomeCategoryCB.SelectedIndex = HomeCategoryCB.FindStringExact(property.HomeCategory);
                LocationCB.SelectedIndex = LocationCB.FindStringExact(property.Location);

                // PriceRangeCB.SelectedIndex = PriceRangeCB.FindStringExact(property.RentRange);
                RoomCountCB.SelectedIndex = RoomCountCB.FindStringExact(property.RoomCount);
                DurationCB.SelectedIndex = DurationCB.FindStringExact(property.Duration);

            }
            else
            {
            }
           
        }

        private void HomeCategoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HomeCategoryCB.SelectedIndex > -1)
            {


                property.HomeCategory = HomeCategoryCB.SelectedItem.ToString();

                property = ToLet.DBDataProvider.DBDataProvider.getForHomeResult(property);


                LocationCB.SelectedIndex = LocationCB.FindStringExact(property.Location);

                // PriceRangeCB.SelectedIndex = PriceRangeCB.FindStringExact(property.RentRange);
                RoomCountCB.SelectedIndex = RoomCountCB.FindStringExact(property.RoomCount);
                DurationCB.SelectedIndex = DurationCB.FindStringExact(property.Duration);



            }
            else
            {
            }
        }

        private void LocationCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LocationCB.SelectedIndex > -1)
            {
                property.Location = LocationCB.SelectedItem.ToString();

                property = ToLet.DBDataProvider.DBDataProvider.getForLocResult(property);

                // PriceRangeCB.SelectedIndex = PriceRangeCB.FindStringExact(property.RentRange);
                RoomCountCB.SelectedIndex = RoomCountCB.FindStringExact(property.RoomCount);
                DurationCB.SelectedIndex = DurationCB.FindStringExact(property.Duration);
            }
            else
            {
            }
        }

        private void RoomCountCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RoomCountCB.SelectedIndex > -1)
            {
                property.RoomCount = RoomCountCB.SelectedItem.ToString();

                property = ToLet.DBDataProvider.DBDataProvider.getForRoomResult(property);

                // PriceRangeCB.SelectedIndex = PriceRangeCB.FindStringExact(property.RentRange);
                DurationCB.SelectedIndex = DurationCB.FindStringExact(property.Duration);

            }
            else
            {
            }
        }

        private void DurationCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DurationCB.SelectedIndex > -1)
            {
                property.Duration = DurationCB.SelectedItem.ToString();

                property = ToLet.DBDataProvider.DBDataProvider.getForDurResult(property);

                // PriceRangeCB.SelectedIndex = PriceRangeCB.FindStringExact(property.RentRange);


            }
            else
            {
            }
        }

        private void LogInSearchResultDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string value1 = "", value2 = "";
            foreach (DataGridViewRow row in LogInSearchResultDG.SelectedRows)
            {
                value1 = row.Cells[0].Value.ToString();
                value2 = row.Cells[1].Value.ToString();

            }
            Classes.PropertyDetails pd = new Classes.PropertyDetails();
            pd = ToLet.DBDataProvider.DBDataProvider.getPropertyInfo(value1, value2);

            Image propertypic = ToLet.DBDataProvider.DBDataProvider.getPropertyPic(value1, value2);

            if (LogInSearchResultDG.Focused)
            {

                PropertyDetailsForm pdf = new PropertyDetailsForm(this);
                pdf.textBox1.Text = pd.TenantCategory;
                pdf.textBox2.Text = pd.HomeCategory;
                pdf.textBox3.Text = pd.Location;
                pdf.textBox4.Text = pd.RoomCount;
                pdf.AddDetaiedAddressTB.Text = pd.DetailedAddress;
                pdf.AddAdditionalCommentsTB.Text = pd.AdditionalComment;
                pdf.AddPriceTB.Text = pd.RentRange;
                pdf.AddPropertyImagePB.Image = propertypic;

                pdf.PublishBTN.Hide();
                pdf.SeeRequestBTN.Hide();
              
                pdf.Show();

            }
        }

        private void BackSearchResultBTN_Click(object sender, EventArgs e)
        {
            TenantCategoryCB.SelectedIndex = -1;
            HomeCategoryCB.SelectedIndex = -1;
            LocationCB.SelectedIndex = -1;
            RoomCountCB.SelectedIndex = -1;
            DurationCB.SelectedIndex = -1;
            PriceRangeCB.SelectedIndex = -1;
            MainUITabControl.SelectedTab = SearchTAB;
          

        }

        private void TenantsDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string value1 = "";
            foreach (DataGridViewRow row in TenantsDG.SelectedRows)
            {
                value1 = row.Cells[3].Value.ToString();


            }
            Classes.User user = new Classes.User();
            user = ToLet.Database.DBDataList.getUserProfile(value1);

            Image pic = ToLet.Database.DBDataList.getUserPic(value1);
            SearchResultForm f = new SearchResultForm();

            f.SeeResultTabControl.SelectedTab = f.UserProfileTAB;

            f.FirstNameTB.Text = user.FirstName;
            f.LastNameTB.Text = user.LastName;
            f.MobileTB.Text = user.MobileNo.ToString();
            f.EmailTB.Text = user.Email;
            f.NidTB.Text = user.NidNo;
            f.AddressTB.Text = user.Address;
            f.DateOfBirthTB.Text = user.DOB;
            f.ProfilePicPB.Image = pic;
            f.UserNameTB.Text = user.UserName;
            f.AcceptBTN.Hide();
            f.BackResultBTN.Hide();
            f.Show();
 
          
        }

        private void MyRentsDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string value1 = "", value2 = "";
            foreach (DataGridViewRow row in MyRentsDG.SelectedRows)
            {
                value1 = row.Cells[2].Value.ToString();
                value2 = row.Cells[4].Value.ToString();
            }
           
            Classes.PropertyDetails pd = new Classes.PropertyDetails();
            pd = ToLet.DBDataProvider.DBDataProvider.getPropertyInfo(value1,value2);
            Image pic = ToLet.DBDataProvider.DBDataProvider.getPropertyPic(value1, value2);

            PropertyDetailsForm pdf = new PropertyDetailsForm();
            pdf.textBox1.Text = pd.TenantCategory;
            pdf.textBox2.Text = pd.HomeCategory;
            pdf.textBox3.Text = pd.Location;
            pdf.textBox4.Text = pd.RoomCount;
            pdf.AddDetaiedAddressTB.Text = pd.DetailedAddress;
            pdf.AddAdditionalCommentsTB.Text = pd.AdditionalComment;
            pdf.AddPriceTB.Text = pd.RentRange;
            pdf.AddPropertyImagePB.Image = pic;

            pdf.SeeRequestBTN.Hide();
            pdf.PublishBTN.Hide();
            pdf.RequestBTN.Hide();
         
            pdf.Show();
        }

        private void MyLandlordDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string value1 = "";
            foreach (DataGridViewRow row in MyLandlordDG.SelectedRows)
            {
                value1 = row.Cells[2].Value.ToString();


            }
            Classes.User user = new Classes.User();
            user = ToLet.Database.DBDataList.getUserProfile(value1);

            Image pic = ToLet.Database.DBDataList.getUserPic(value1);
            SearchResultForm f = new SearchResultForm();

            f.SeeResultTabControl.SelectedTab = f.UserProfileTAB;

            f.FirstNameTB.Text = user.FirstName;
            f.LastNameTB.Text = user.LastName;
            f.MobileTB.Text = user.MobileNo.ToString();
            f.EmailTB.Text = user.Email;
            f.NidTB.Text = user.NidNo;
            f.AddressTB.Text = user.Address;
            f.DateOfBirthTB.Text = user.DOB;
            f.ProfilePicPB.Image = pic;
            f.UserNameTB.Text = user.UserName;
            f.AcceptBTN.Hide();
            f.BackResultBTN.Hide();
            f.Show();
        }

        private void SentItemDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MailBox mb = new MailBox(this);
            string to = "", message = "",id = "";
            mb.label1.Text = "To : ";
            foreach (DataGridViewRow row in SentItemDG.SelectedRows)
            {
                to = row.Cells[1].Value.ToString();
                message = row.Cells[3].Value.ToString();
                id = row.Cells[0].Value.ToString();

            }
            mb.textBox1.Text = to;
            mb.richTextBox1.Text = message;
            mb.MailIdLBL.Text = id;
            mb.DeletMailBTN.Text = "Delet From Sent Items";
            mb.MailTypeLBL.Text = "SentItem";
            mb.Show();
        }

        private void InboxDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MailBox mb = new MailBox(this);
            string from = "", message = "",id = "";
            mb.label1.Text = "From : ";
            foreach (DataGridViewRow row in InboxDG.SelectedRows)
            {
                from = row.Cells[2].Value.ToString();
                message = row.Cells[3].Value.ToString();
                id = row.Cells[0].Value.ToString();


            }
            mb.textBox1.Text = from;
            mb.richTextBox1.Text = message;
            mb.MailIdLBL.Text = id;
            mb.DeletMailBTN.Text = "Delet From Inbox";
            mb.MailTypeLBL.Text = "Inbox";
            mb.Show();
        }

        private void BrowseNewProPicBTN_Click(object sender, EventArgs e)
        {
            try
            {
                opnfdlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All Files(*.*)|*.*";
                opnfdlg.Title = "Select Image";
                if (opnfdlg.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = opnfdlg.FileName.ToString();
                    ProfilePicPB.ImageLocation = imageLocation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditProfileBTN_Click(object sender, EventArgs e)
        {
            ToLet.Classes.User u = ToLet.DBDataProvider.DBDataProvider.getUserInfo(user, pass);

            MessageBox.Show("Except Red Fields");

            FirstNameTB.BackColor = Color.Red;
            LastNameTB.BackColor = Color.Red;
            NidTB.BackColor = Color.Red;
            DateOfBirthTB.BackColor = Color.Red;
            UserNameTB.BackColor = Color.Red;

            MobileTB.ReadOnly = false;
            EmailTB.ReadOnly = false;
            AddressTB.ReadOnly = false;
            BrowseNewProPicBTN.Visible = true;

            EditPasswordLBL.Visible = true;

            EditPasswordTB.Visible = true;
            EditPasswordTB.ReadOnly = false;
            EditPasswordTB.Text = u.Password;

            ConfirmEditPasswordLBL.Visible = true;
            ConfirmEditPasswordTB.Visible = true;
            ConfirmEditPasswordTB.ReadOnly = false;
            ConfirmEditPasswordTB.Text = u.Password;

            SaveBTN.Visible = true;
            EditProfileBTN.Visible = false;
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ProfilePicPB.Image.Save(ms, ProfilePicPB.Image.RawFormat);

            byte[] arrpic = ms.GetBuffer();

            ToLet.Database.DBConnectionProvider.getDBConnection();
            if (EditPasswordTB.Text != ConfirmEditPasswordTB.Text)
            {
                EditPasswordTB.Text = "";
                EditPasswordTB.Text = "";
                MessageBox.Show("Password not matched");
            }
            else if (EditPasswordTB.Text == "" || ConfirmEditPasswordTB.Text == "")
            {
                MessageBox.Show("Invalid PassWord");

            }

            else if (MobileTB.Text == "")
            {
                MessageBox.Show("Invalid Mobile number");

            }

            else if (EmailTB.Text == "")
            {
                MessageBox.Show("Invalid Email");

            }

            else if (AddressTB.Text == "")
            {
                MessageBox.Show("Invalid Address");

            }


            else
            {
                ToLet.Classes.EditProfile ep = new ToLet.Classes.EditProfile(ConfirmEditPasswordTB.Text, EmailTB.Text, NidTB.Text, AddressTB.Text, int.Parse(MobileTB.Text));
                ToLet.DBDataProvider.DBDataProvider.UpdateUser(ep, this.user, arrpic);
                Image propic = ToLet.DBDataProvider.DBDataProvider.getProPic(user, pass);
                ProPB.Image = propic;
                MessageBox.Show("Updated Successfully");

                SaveBTN.Visible = false;
                EditProfileBTN.Visible = true;
                BrowseNewProPicBTN.Visible = false;

                EditPasswordLBL.Visible = false;
                EditPasswordTB.Visible = false;

                ConfirmEditPasswordLBL.Visible = false;
                ConfirmEditPasswordTB.Visible = false;
            }

            
            
        }

        
        
        private void ToTB_TextChanged(object sender, EventArgs e)
        {
           // AutoComplete();
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            ToLet.Database.DBConnectionProvider.getDBConnection();

            ToTB.AutoCompleteMode = AutoCompleteMode.Suggest;
            ToTB.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();

            var x = from q in cntx.Users select q;
            foreach (var item in x)
            {
                ac.Add(item.UserName);
            }
            ToTB.AutoCompleteCustomSource = ac;
            
        }
        


    }
}
