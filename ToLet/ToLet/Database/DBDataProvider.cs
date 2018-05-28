using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToLet.Database;
using System.IO;
using System.Drawing;
using System.Data.Linq;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ToLet.DBDataProvider
{
    public class DBDataProvider
    {
        public static bool LogInCheck(string usernameTextbox, string passwordTextbox)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            var qry = from m in cntx.Users where m.UserName == usernameTextbox && m.Password == passwordTextbox select m;
            if (qry.Count() > 0)
            {
                return true;
            }
            else
                return false;
        }

        public static void InsertOnDB(ToLet.Classes.User u,byte[] arrpic)
        {
            bool b = false;
           
            try
            {
                DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
                List<string> usernamelist = DBDataList.checkDoubleusername(u.UserName);

                foreach (var values in usernamelist)
                {
                    if (values == u.UserName)
                    {

                        System.Windows.Forms.MessageBox.Show("Username already exists");
                        b = true;
                      
                        break;

                    }
                }
                if (b == false)
                {
                    User user = new User();
                    user.UserName = u.UserName;
                    user.Password = u.Password;
                    user.UserCategory = "user";

                    UserInfo userinfo = new UserInfo();
                    userinfo.First_Name = u.FirstName;
                    userinfo.Last_Name = u.LastName;
                    userinfo.MobileNo = u.MobileNo;
                    userinfo.Email = u.Email;
                    userinfo.Nid_No = u.NidNo;
                    userinfo.Address = u.Address;
                    userinfo.Date_of_Birth = u.DOB;
                    userinfo.Gender = u.Gender;

                    userinfo.Profile_Pic = arrpic;

                    cntx.Users.InsertOnSubmit(user);
                    user.UserInfos.Add(userinfo);
                    cntx.SubmitChanges();
                    System.Windows.Forms.MessageBox.Show("Congratulations!!!You have successfully registered");
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
         

        }

        public static void UpdateUser(ToLet.Classes.EditProfile ep, string username, byte[] arrpic)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            User user = cntx.Users.SingleOrDefault(x => x.UserName == username);
            user.Password = ep.Password;

            int id = user.UserId;

            UserInfo uinfo = cntx.UserInfos.SingleOrDefault(y => y.UserId == id);
            uinfo.MobileNo = ep.MobileNo;
            uinfo.Email = ep.Email;
            uinfo.Address = ep.Address;
            uinfo.Profile_Pic = arrpic;

            cntx.SubmitChanges();

        }

        public static void DeletMail(int id, string si)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();


            if (si == "SentItem")
            {
                MailTable mailtable = cntx.MailTables.SingleOrDefault(x => x.Id == id);
                mailtable.deletto = 1;
                cntx.SubmitChanges();
 
            }
            else if (si == "Inbox")
            {
                MailTable mailtable = cntx.MailTables.SingleOrDefault(x => x.Id == id);
                mailtable.delefrom = 1;
                cntx.SubmitChanges();
 
            }
 
        }


        public static ToLet.Classes.User getUserInfo(string user, string pass)
        {

            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
          var info=from p in cntx.UserInfos
                   join c in cntx.Users
                   on p.UserId equals c.UserId 
                   where c.UserName==user && c.Password==pass
                   select new
                   {
                       p.First_Name,
                       p.Last_Name,
                       p.MobileNo,
                       p.Nid_No,
                       p.Email,
                       p.Address,
                       p.Date_of_Birth,
                       c.UserName

                   };
    

            ToLet.Classes.User u = new ToLet.Classes.User();

            foreach (var item in info)
            {
                u.FirstName=item.First_Name;
                u.LastName = item.Last_Name;
                u.MobileNo = item.MobileNo;
                u.NidNo = item.Nid_No;
                u.Email = item.Email;
                u.Address = item.Address;
                u.DOB = item.Date_of_Birth;
                u.UserName = item.UserName;

            }

           
            return u;
        }
        public static  Image getProPic(string user, string pass)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            var pic = (from p in cntx.UserInfos
                      join c in cntx.Users
                      on p.UserId equals c.UserId
                      where c.UserName == user && c.Password == pass
                      select p.Profile_Pic).Single();
                  
            Binary bpic=pic;
            byte[] b=bpic.ToArray();
          
            MemoryStream ms=new MemoryStream(b);
          
            Image img=Image.FromStream(ms);

            return img;
            
            
        }

        public static Image getPropertyPic(string s1, string s2)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            var propertypic = (from p in cntx.Properties
                               where p.Location == s1 && p.Detailed_Address == s2
                               select p.PropertyImage).SingleOrDefault();

            Image img;
            if (propertypic != null)
            {
                Binary bpic = propertypic;
                byte[] b = bpic.ToArray();

                MemoryStream ms = new MemoryStream(b);

                 img = Image.FromStream(ms);
                return img;
            }
            else
            {
                img = null;
                return img;
            }
        }

        public static void setProperty(ToLet.Classes.PropertyDetails pd,byte[] arrpic,string user,string pass)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            Property p = new Property();

            p.HomeCategory=pd.HomeCategory;
            p.TenantCategory=pd.TenantCategory;
            p.Location=pd.Location;
            p.RoomCount=int.Parse(pd.RoomCount);
            p.RentRangeId=int.Parse(pd.RentRange);
            p.Detailed_Address = pd.DetailedAddress;
            p.Additional_Comments = pd.AdditionalComment;
            p.Duration = pd.Duration;
            p.PropertyStatus = "unpublished";
            p.PropertyImage = arrpic;

            var qry = (from u in cntx.Users
                      where u.UserName == user && u.Password == pass
                      select u).SingleOrDefault();

            p.UserId = qry.UserId;


            cntx.Properties.InsertOnSubmit(p);
            cntx.SubmitChanges();


            System.Windows.Forms.MessageBox.Show("Successfully inserted");
            
          
        }

        public static void setPublishedProperty(Classes.PropertyDetails pd)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var setproperty = (from p in cntx.Properties
                              where p.TenantCategory == pd.TenantCategory && p.HomeCategory == pd.HomeCategory && p.Location == pd.Location && p.RoomCount == int.Parse(pd.RoomCount)
                              && p.Detailed_Address == pd.DetailedAddress && p.Additional_Comments == pd.AdditionalComment && p.RentRangeId == int.Parse(pd.RentRange)
                              select p).SingleOrDefault();

            string s = setproperty.PropertyStatus;

            Property r = new Property();

            if (s != null)
            {
                setproperty.PropertyStatus = "published";
                System.Windows.Forms.MessageBox.Show("This is now for ToLet");

            }
            else
            {

            }

            
            cntx.SubmitChanges();
            
        }

        public static void getUnpublishedPropertyData(MainUI m,string user)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var userid=(from u in cntx.Users
                       where u.UserName==user
                       select u).SingleOrDefault();

            var info = from p in cntx.Properties
                       where p.PropertyStatus=="unpublished" && p.UserId==userid.UserId
                       select new
                       {
                           p.Location,
                           p.Detailed_Address
                       };

            m.UnpublishedDG.DataSource = info;
           
        }

        public static void getPublishedPropertyData(MainUI m,string user)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var userid = (from u in cntx.Users
                          where u.UserName == user
                          select u).SingleOrDefault();

            var info = from p in cntx.Properties
                       where p.PropertyStatus == "published" && p.UserId == userid.UserId
                       select new
                       {
                           p.Location,
                           p.Detailed_Address,
                           p.Request_for_rent
                       };

            m.PublishedDG.DataSource = info;

        }

        public static void getInRentPropertyData(MainUI m, string user)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var userid = (from u in cntx.Users
                          where u.UserName == user
                          select u).SingleOrDefault();

            var info = from p in cntx.Properties
                       where p.PropertyStatus == "inrent" && p.UserId == userid.UserId
                       select new
                       {
                           p.Location,
                           p.Detailed_Address
                       };

            m.InRentDG.DataSource = info;

        }
        public static Classes.PropertyDetails getPropertyInfo(string s1, string s2)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var details = from p in cntx.Properties
                          where p.Location==s1 && p.Detailed_Address==s2 
                          select new
                          {
                              p.TenantCategory,
                              p.HomeCategory,
                              p.Location,
                              p.RoomCount,
                              p.Detailed_Address,
                              p.Additional_Comments,
                              p.RentRangeId
                          };

            Classes.PropertyDetails pd = new Classes.PropertyDetails();

            foreach (var item in details)
            {
                pd.TenantCategory = item.TenantCategory;
                pd.HomeCategory = item.HomeCategory;
                pd.Location = item.Location;
                pd.RoomCount = item.RoomCount.ToString();
                pd.DetailedAddress = item.Detailed_Address;
                pd.AdditionalComment = item.Additional_Comments;
                pd.RentRange = item.RentRangeId.ToString();

            }

            return pd;
        }

        public static Classes.PropertyDetails getPublishedPropertyInfo(string home,string tenant,string roomcount,string rent,string loc)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var details = from p in cntx.Properties
                          where p.HomeCategory == home && p.TenantCategory == tenant && p.RoomCount == int.Parse(roomcount) && p.RentRangeId==int.Parse(rent) && p.Location==loc
                          select new
                          {
                              p.TenantCategory,
                              p.HomeCategory,
                              p.Location,
                              p.RoomCount,
                              p.Detailed_Address,
                              p.Additional_Comments,
                              p.RentRangeId
                          };

            Classes.PropertyDetails pd = new Classes.PropertyDetails();

            foreach (var item in details)
            {
                pd.TenantCategory = item.TenantCategory;
                pd.HomeCategory = item.HomeCategory;
                pd.Location = item.Location;
                pd.RoomCount = item.RoomCount.ToString();
                pd.DetailedAddress = item.Detailed_Address;
                pd.AdditionalComment = item.Additional_Comments;
                pd.RentRange = item.RentRangeId.ToString();

            }

            return pd;
        }

        public static void getSearchAsGuestResult(Start s,Classes.PropertyDetails pd)
        {
            
                DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
                try
                {
                    string[] numbers = Regex.Split(pd.RentRange, @"\D+");


                    var details = (from p in cntx.Properties
                                   where p.TenantCategory == pd.TenantCategory && p.HomeCategory == pd.HomeCategory && p.Location == pd.Location && p.RoomCount == int.Parse(pd.RoomCount)
                                   && (p.RentRangeId >= int.Parse(numbers[0]) && p.RentRangeId <= int.Parse(numbers[1])) && p.Duration == pd.Duration && p.PropertyStatus == "published"
                                   select new
                                   {
                                       p.Location,
                                       p.Detailed_Address,
                                       p.HomeCategory,
                                       p.TenantCategory,
                                       p.RoomCount,
                                       p.RentRangeId,
                                       p.Duration

                                   }).ToList();


                   
                    if (details.Count<0)
                    {
                        MessageBox.Show("No results Found");
                    }
                    else
                    {
                        s.SearchAsGuestResultsDG.DataSource = details;
                    }
                }
                catch(Exception)
                {

                }

        }

        public static void getSearchResult(MainUI m,Classes.PropertyDetails pd)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            try
            {
                string[] numbers = Regex.Split(pd.RentRange, @"\D+");


                var details = (from p in cntx.Properties
                               where p.TenantCategory == pd.TenantCategory && p.HomeCategory == pd.HomeCategory && p.Location == pd.Location && p.RoomCount == int.Parse(pd.RoomCount)
                               && (p.RentRangeId >= int.Parse(numbers[0]) && p.RentRangeId <= int.Parse(numbers[1])) && p.Duration == pd.Duration && p.PropertyStatus == "published"
                               select new
                               {
                                   p.Location,
                                   p.Detailed_Address,
                                   p.HomeCategory,
                                   p.TenantCategory,
                                   p.RoomCount,
                                   p.RentRangeId,
                                   p.Duration

                               }).ToList();



                if (details.Count < 0)
                {
                    MessageBox.Show("No results Found");
                }
                else
                {
                    m.LogInSearchResultDG.DataSource = details;
                }
            }
            catch (Exception)
            {

            }
        }

        public static Classes.PropertyDetails getForTenantResult(Classes.PropertyDetails pd)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            
                var result = (from p in cntx.Properties
                              where p.TenantCategory == pd.TenantCategory && p.PropertyStatus=="published"
                              select new
                              {
                                  p.HomeCategory,
                                  p.Location,
                                  p.RentRangeId,
                                  p.RoomCount,
                                  p.Duration
                              }).FirstOrDefault();
            try{
                pd.HomeCategory = result.HomeCategory;
                pd.Location = result.Location;
                pd.RentRange = result.RentRangeId.ToString();
                pd.RoomCount = result.RoomCount.ToString();
                pd.Duration = result.Duration;

                return pd;
            }
            catch (Exception)
            {
                pd.HomeCategory = "";
                pd.Location = "";
                pd.RentRange = "";
                pd.RoomCount = "";
                pd.Duration = "";
                return pd;
            }

          
        }

        public static Classes.PropertyDetails getForHomeResult(Classes.PropertyDetails pd)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var result = (from p in cntx.Properties
                          where p.TenantCategory == pd.TenantCategory && p.HomeCategory==pd.HomeCategory && p.PropertyStatus=="published"
                          select new
                          {
                             
                              p.Location,
                              p.RentRangeId,
                              p.RoomCount,
                              p.Duration
                          }).FirstOrDefault();
          

            try
            {
              
                pd.Location = result.Location;
                pd.RentRange = result.RentRangeId.ToString();
                pd.RoomCount = result.RoomCount.ToString();
                pd.Duration = result.Duration;

                return pd;
            }
            catch (Exception)
            {
               
                pd.Location = "";
                pd.RentRange = "";
                pd.RoomCount = "";
                pd.Duration = "";
                return pd;
            }
        }

        public static  Classes.PropertyDetails getForLocResult(Classes.PropertyDetails pd)
        {
             DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var result = (from p in cntx.Properties
                          where p.TenantCategory == pd.TenantCategory && p.HomeCategory==pd.HomeCategory && p.Location==pd.Location && p.PropertyStatus=="published"
                          select new
                          {
                              p.RentRangeId,
                              p.RoomCount,
                              p.Duration
                          }).FirstOrDefault();
          

            try
            {
                pd.RentRange = result.RentRangeId.ToString();
                pd.RoomCount = result.RoomCount.ToString();
                pd.Duration = result.Duration;

                return pd;
            }
            catch (Exception)
            {
                pd.RentRange = "";
                pd.RoomCount = "";
                pd.Duration = "";
                return pd;
            }
        }

        public static Classes.PropertyDetails getForRoomResult(Classes.PropertyDetails pd)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var result = (from p in cntx.Properties
                          where p.TenantCategory == pd.TenantCategory && p.HomeCategory == pd.HomeCategory && p.Location == pd.Location && p.RoomCount==int.Parse(pd.RoomCount) && p.PropertyStatus == "published"
                          select new
                          {
                              p.RentRangeId,
                             
                              p.Duration
                          }).FirstOrDefault();


            try
            {
                pd.RentRange = result.RentRangeId.ToString();
               
                pd.Duration = result.Duration;

                return pd;
            }
            catch (Exception)
            {
                pd.RentRange = "";
               
                pd.Duration = "";
                return pd;
            }
        }

        public static Classes.PropertyDetails getForDurResult(Classes.PropertyDetails pd)
        {
             DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var result = (from p in cntx.Properties
                          where p.TenantCategory == pd.TenantCategory && p.HomeCategory == pd.HomeCategory && p.Location == pd.Location && p.RoomCount==int.Parse(pd.RoomCount) && p.Duration==pd.Duration && p.PropertyStatus == "published"
                          select new
                          {
                              p.RentRangeId,                 
                          }).FirstOrDefault();


            try
            {
                pd.RentRange = result.RentRangeId.ToString();

                return pd;
            }
            catch (Exception)
            {
                pd.RentRange = "";
               
                pd.Duration = "";
                return pd;
            }
        }

        public static void InsertOnMailTable(ToLet.Classes.Mail mail)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            MailTable mailtable = new MailTable();
            mailtable.to = mail.To;
            mailtable.fromu = mail.From;
            mailtable.message = mail.Message;
            mailtable.delefrom = 0;
            mailtable.deletto = 0;

            cntx.MailTables.InsertOnSubmit(mailtable);
            cntx.SubmitChanges();
        }


        public static void getMailData(MainUI m, string user)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();


            var mail = from n in cntx.MailTables
                       where n.fromu == user && n.deletto ==0
                       select new Classes.Mail
                       {
                           MailId=n.Id,
                           To=n.to,
                          Message= n.message

                       };
           

            m.SentItemDG.DataSource = mail;
            m.SentItemDG.Columns[0].Visible = false;
            m.SentItemDG.Columns[2].Visible = false;


        }


        public static void getInboxData(MainUI m, string user)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var inbox = from n in cntx.MailTables
                        where n.to == user && n.delefrom == 0
                        select new Classes.Mail
                        {
                         MailId=n.Id,
                            From=n.fromu,
                            Message=n.message
                        };
           
            
            m.InboxDG.DataSource = inbox;
            m.InboxDG.Columns[0].Visible = false;
            m.InboxDG.Columns[1].Visible = false;
        }

        public static void getTenantData(MainUI m, string landlord)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var landlordid = (from l in cntx.Users
                              where l.UserName == landlord
                              select l.UserId).SingleOrDefault();

            var propertyid = (from p in cntx.Properties
                              where p.UserId == landlordid
                              select p.PropertyId).ToList();

            List<Classes.TenantClass> tlist = new List<Classes.TenantClass>();
            foreach (var item in propertyid)
            {
                tlist.AddRange(d(item));
            }
            m.TenantsDG.DataSource = tlist;
            m.TenantsDG.Columns[0].Visible= false;
            m.TenantsDG.Columns[1].Visible = false;
            m.TenantsDG.Columns[2].Visible = false;
            m.TenantsDG.Columns[4].Visible = false;
            m.TenantsDG.Columns[5].Visible = false;
            m.TenantsDG.Columns[6].Visible = false;
            m.TenantsDG.Columns[8].Visible = false;
            m.TenantsDG.Columns[9].Visible = false;
            m.TenantsDG.Columns[10].Visible = false;

    
        }
        public static List<Classes.TenantClass> d(int item)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            var tenant = (from t in cntx.Tenants
                          join u in cntx.Users on t.UserId equals u.UserId
                          join p in cntx.Properties on t.PropertyId equals p.PropertyId
                          where t.PropertyId == item
                          select new Classes.TenantClass
                          {
                              UserName=u.UserName,
                              Address = p.Detailed_Address,
                           
                          }).ToList();
            return tenant;
        }
        public static void getMyRentData(MainUI m,string user)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var userid = (from l in cntx.Users
                              where l.UserName == user
                              select l.UserId).SingleOrDefault();
            var tenantuserid = (from t in cntx.Tenants
                                where t.UserId == userid
                                select t.UserId).SingleOrDefault();

            var propertyid = (from p in cntx.Tenants
                              where p.UserId == tenantuserid
                              select p.PropertyId).ToList();

            List<Classes.PropertyDetails> plist = new List<Classes.PropertyDetails>();
            foreach (var item in propertyid)
            {
                plist.AddRange(p(item));
            }
            m.MyRentsDG.DataSource = plist;

            m.MyRentsDG.Columns[0].Visible = false;
            m.MyRentsDG.Columns[3].Visible = false;
            m.MyRentsDG.Columns[5].Visible = false;
            m.MyRentsDG.Columns[6].Visible = false;
            m.MyRentsDG.Columns[7].Visible = false;
            m.MyRentsDG.Columns[8].Visible = false;
        }

        public static List<Classes.PropertyDetails> p(int item)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            var property = (from t in cntx.Properties                        
                          where t.PropertyId == item
                          select new Classes.PropertyDetails
                          {
                              HomeCategory=t.HomeCategory,
                              Location=t.Location,
                              RoomCount=t.RoomCount.ToString(),
                              DetailedAddress=t.Detailed_Address,
                              AdditionalComment=t.Additional_Comments,



                          }).ToList();
            return property;
        }
        public static void getMyLandlordData(MainUI m,string user)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var userid = (from l in cntx.Users
                          where l.UserName == user
                          select l.UserId).SingleOrDefault();

            var propertyid = (from p in cntx.Tenants
                              where p.UserId == userid
                              select p.PropertyId).SingleOrDefault();
            var landlord = (from c in cntx.Properties
                            where c.PropertyId == propertyid
                            select c.UserId).ToList();
            List<Classes.User> ulist = new List<Classes.User>();
            foreach (var item in landlord)
            {
                ulist.AddRange(l(item));
            }
            m.MyLandlordDG.DataSource = ulist;

            m.MyLandlordDG.Columns[0].Visible = false;
            m.MyLandlordDG.Columns[1].Visible = false;
            m.MyLandlordDG.Columns[3].Visible = false;
            m.MyLandlordDG.Columns[4].Visible = false;
            m.MyLandlordDG.Columns[5].Visible = false;
            m.MyLandlordDG.Columns[7].Visible = false;
            m.MyLandlordDG.Columns[8].Visible = false;
            m.MyLandlordDG.Columns[9].Visible = false;
        }
        public static List<Classes.User> l(int item)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            var info = (from i in cntx.UserInfos
                        join u in cntx.Users
                        on i.UserId equals u.UserId
                        where i.UserId == item
                        select new Classes.User
                        {
                            UserName = u.UserName,
                            Address = i.Address
                        }).ToList();
            return info;
        }

        
    }

  
}
