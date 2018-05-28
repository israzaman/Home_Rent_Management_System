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
using ToLet.DBDataProvider;
using System.IO;




namespace ToLet
{
    public partial class Start : Form
    {
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Munna\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlCommand command;
        string imageLocation = "";
        OpenFileDialog opnfdlg = new OpenFileDialog();
        Classes.PropertyDetails property = new Classes.PropertyDetails();

        MainUI mainui;
        
        public Start()
        {
            InitializeComponent();
            
        }

        public Start(MainUI mainui)
        {
            InitializeComponent();
         
            this.mainui = mainui;
        }

      

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.Exit1;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.Exit2;
        }

        private void SubmitPB_MouseHover(object sender, EventArgs e)
        {
            SubmitPB.Image = Resources.submit2;
        }

        private void SubmitPB_MouseLeave(object sender, EventArgs e)
        {
            SubmitPB.Image = Resources.submit1;
        }

        private void SignupPB_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = SignupTAB;
        }

        private void SubmitPB_Click(object sender, EventArgs e)
        {
           
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            UserImagePB.Image.Save(ms, UserImagePB.Image.RawFormat);
            //Image imag = Image.FromFile(opnfdlg.FileName);
            //imag.Save(ms, UserImagePB.Image.RawFormat);
            byte[] arrpic = ms.GetBuffer();

            ToLet.Database.DBConnectionProvider.getDBConnection();
            if (PassSUPTB.Text != CPassSUPTB.Text)
            {
                PassSUPTB.Text = "";
                CPassSUPTB.Text = "";
                MessageBox.Show("Password not matched");
            }
            int parsedValue;
           
            if (this.SignupPANEL.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            {

                MessageBox.Show("Please fill up the form properly");
              
            }
            else if (!int.TryParse(MobileTB.Text, out parsedValue))
            {
                MessageBox.Show("MobileNo is a number only field");
                return;
            }

            else
            {
                if (MaleRB.Checked == true)
                {
                   
                    ToLet.Classes.User u = new ToLet.Classes.User(FirstNameTB.Text, LastNameTB.Text, UNameSUPTB.Text, PassSUPTB.Text, EmailTB.Text, MaleRB.Text, DateOfBirthDTP.Text, NidTB.Text, AddressTB.Text, int.Parse(MobileTB.Text));
                    ToLet.DBDataProvider.DBDataProvider.InsertOnDB(u,arrpic);
                }
                else if (FemaleRB.Checked == true)
                {
                    
                    ToLet.Classes.User u = new ToLet.Classes.User(FirstNameTB.Text, LastNameTB.Text, UNameSUPTB.Text, PassSUPTB.Text, EmailTB.Text, FemaleRB.Text, DateOfBirthDTP.Text, NidTB.Text, AddressTB.Text, int.Parse(MobileTB.Text));
                    ToLet.DBDataProvider.DBDataProvider.InsertOnDB(u,arrpic);
                }
                             
                
                    tabControl1.SelectedTab = LoginTAB;
                    foreach (Control c in SignupPANEL.Controls)
                    {
                        if (c is TextBox)
                        {
                            c.Text=string.Empty;
                        }
                    }
                    FemaleRB.Checked = false;
                    MaleRB.Checked = false;
                    UserImagePB.Image = Resources._019005_glossy_waxed_wood_icon_symbols_shapes_smiley_happy2;

            }
           
            
        }

        private void ExitPB_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExitPB_MouseHover(object sender, EventArgs e)
        {
            ExitPB.Image = Resources.Exit1;
        }

        private void ExitPB_MouseLeave(object sender, EventArgs e)
        {
            ExitPB.Image = Resources.Exit2;
        }

        private void LoginPB_MouseHover(object sender, EventArgs e)
        {
            LoginPB.Image = Resources.loginwooden2;
        }

        private void LoginPB_MouseLeave(object sender, EventArgs e)
        {
            LoginPB.Image = Resources.loginwooden;
        }

        private void SignupPB_MouseHover(object sender, EventArgs e)
        {
            SignupPB.Image = Resources.Signupwooden2;
        }

        private void SignupPB_MouseLeave(object sender, EventArgs e)
        {
            SignupPB.Image = Resources.Signupwooden1;
        }

        private void LoginPB_Click(object sender, EventArgs e)
        {
            ToLet.Database.DBConnectionProvider.getDBConnection();

            ToLet.Classes.User u = new ToLet.Classes.User();

            u.UserName =UsernameTB.Text;
            u.Password= PasswordTB.Text;

            bool b = ToLet.DBDataProvider.DBDataProvider.LogInCheck(u.UserName, u.Password);

            if (b)
            {
                this.Hide();
               
                this.mainui = new MainUI(this,u.UserName);
                Image propic = ToLet.DBDataProvider.DBDataProvider.getProPic(u.UserName, u.Password);
                mainui.ProPB.Image = propic;
                mainui.ProPB.SizeMode = PictureBoxSizeMode.StretchImage;
                mainui.accountLBL.Text = u.UserName;
                mainui.MainUIButtonPANEL.Controls.Add(mainui.accountLBL);
               mainui.setuserpass(u.UserName, u.Password);
                mainui.Show();
            }
            else
            {
                if (u.UserName == "")
                {
                    LoginPANEL.Controls.Add(userNameLBL2);
                }
                if (u.Password == "")
                {
                    LoginPANEL.Controls.Add(passwordLBL2);
                }
                else
                MessageBox.Show("Invalid username or password");
            }
         }

        private void SearchAsGuestPB_MouseHover(object sender, EventArgs e)
        {
            SearchAsGuestPB.Image = Resources.searchasguestRED;
        }

        private void SearchAsGuestPB_MouseLeave(object sender, EventArgs e)
        {
            SearchAsGuestPB.Image = Resources.searchasguestBLACK;
        }

        private void SearchAsGuestPB_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = SearchAsGuestTAB;
            TenantCategoryCB.SelectedIndex = -1;
            HomeCategoryCB.SelectedIndex = -1;
            LocationCB.SelectedIndex = -1;
            RoomCountCB.SelectedIndex = -1;
            DurationCB.SelectedIndex = -1;
            PriceRangeCB.SelectedIndex = -1;
            //TenantCategoryCB.Text = "";
           // HomeCategoryCB.Text = "";
            //LocationCB.Text = "";
           // RoomCountCB.Text = "";
            //DurationCB.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = LoginTAB;
        }

        private void Back1BTN_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = LoginTAB;
            UsernameTB.Text = "";
            PasswordTB.Text = "";
        }

        private void Exit3PB_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Exit3PB_MouseHover(object sender, EventArgs e)
        {
            Exit3PB.Image = Resources.Exit1;
        }

        private void Exit3PB_MouseLeave(object sender, EventArgs e)
        {
            Exit3PB.Image = Resources.Exit2;
        }

        private void BrowseBTN_Click(object sender, EventArgs e)
        {
            try
            {
                opnfdlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All Files(*.*)|*.*";
                opnfdlg.Title = "Select Image";
                if (opnfdlg.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = opnfdlg.FileName.ToString();
                    UserImagePB.ImageLocation = imageLocation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    
        private void SearchPB_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = SearchAsGuestResultsTAB;
           

                property.RentRange = PriceRangeCB.SelectedItem.ToString();

                ToLet.DBDataProvider.DBDataProvider.getSearchAsGuestResult(this,property);

   
            }

            catch (Exception )
            {
                tabControl1.SelectedTab = SearchAsGuestTAB;
                MessageBox.Show("Choose Category to search");
              
            }
        }

        private void ExitSearchResultsPB_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UsernameTB_MouseClick(object sender, MouseEventArgs e)
        {
            LoginPANEL.Controls.Remove(userNameLBL2);
        }

        private void PasswordTB_MouseClick(object sender, MouseEventArgs e)
        {
            LoginPANEL.Controls.Remove(passwordLBL2);
        }

        private void Start_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void FillComboBox()
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = SearchAsGuestTAB;

            
            TenantCategoryCB.SelectedIndex = -1;
            HomeCategoryCB.SelectedIndex = -1;
            LocationCB.SelectedIndex = -1;
            RoomCountCB.SelectedIndex = -1;
            DurationCB.SelectedIndex = -1;
            PriceRangeCB.SelectedIndex = -1;


            /*foreach (Control c in SearchAsGuestTAB.Controls)
            {
                if (c is ComboBox)
                {
                    c.Text = string.Empty;
                }
            }
             * */

        }

        private void SearchAsGuestResultsDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string value1 = "", value2 = "";
            foreach (DataGridViewRow row in SearchAsGuestResultsDG.SelectedRows)
            {
                value1 = row.Cells[0].Value.ToString();
                value2 = row.Cells[1].Value.ToString();

            }
            Classes.PropertyDetails pd = new Classes.PropertyDetails();
            pd = ToLet.DBDataProvider.DBDataProvider.getPropertyInfo(value1, value2);

            Image propertypic = ToLet.DBDataProvider.DBDataProvider.getPropertyPic(value1, value2);

            if (SearchAsGuestResultsDG.Focused)
            {

                PropertyDetailsForm pdf = new PropertyDetailsForm();
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

        private void SearchPB_MouseHover(object sender, EventArgs e)
        {
            SearchPB.Image = Resources.woodsearchRED;
        }

        private void SearchPB_MouseLeave(object sender, EventArgs e)
        {
            SearchPB.Image = Resources.woodensearch1;
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

        private void PasswordTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToLet.Database.DBConnectionProvider.getDBConnection();

                ToLet.Classes.User u = new ToLet.Classes.User();

                u.UserName = UsernameTB.Text;
                u.Password = PasswordTB.Text;

                bool b = ToLet.DBDataProvider.DBDataProvider.LogInCheck(u.UserName, u.Password);

                if (b)
                {
                    this.Hide();

                    this.mainui = new MainUI(this, u.UserName);
                    Image propic = ToLet.DBDataProvider.DBDataProvider.getProPic(u.UserName, u.Password);
                    mainui.ProPB.Image = propic;
                    mainui.ProPB.SizeMode = PictureBoxSizeMode.StretchImage;
                    mainui.accountLBL.Text = u.UserName;
                    mainui.MainUIButtonPANEL.Controls.Add(mainui.accountLBL);
                    mainui.setuserpass(u.UserName, u.Password);
                    mainui.Show();
                }
                else
                {
                    if (u.UserName == "")
                    {
                        LoginPANEL.Controls.Add(userNameLBL2);
                    }
                    if (u.Password == "")
                    {
                        LoginPANEL.Controls.Add(passwordLBL2);
                    }
                    else
                        MessageBox.Show("Invalid username or password");
                }
            }
        }

        

     
 
    }
}
