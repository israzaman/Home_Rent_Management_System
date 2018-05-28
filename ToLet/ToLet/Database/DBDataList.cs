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

namespace ToLet.Database
{
    public class DBDataList
    {

        public static List<string> checkDoubleusername(string username)
        {
            List<string> usernamelist = new List<string>();
            try
            {
                DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
                usernamelist = (from c in cntx.Users
                                select c.UserName).ToList();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            return usernamelist;
        }

        public static List<string> getTenantCategoryList()
        {
            List<string> TenantCategoryList = new List<string>();
            try
            {
                DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
                TenantCategoryList = (from c in cntx.Tenant_Categories
                                select c.Tenant_Category1).ToList();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            return TenantCategoryList;

        }

        public static List<string> getHomeCategoryList()
        {
            List<string> HomeCategoryList = new List<string>();
            try
            {
                DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
                HomeCategoryList = (from c in cntx.Home_Categories
                                      select c.Home_Category1).ToList();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            return HomeCategoryList;

        }

        public static List<string> getLocationList()
        {
            List<string> LocationList = new List<string>();
            try
            {
                DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
                LocationList = (from c in cntx.Locations
                                    select c.Location_Name).ToList();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            return LocationList;

        }

        public static List<string> getRentRangeList()
        {
            List<string> rentRangeList = new List<string>();
            try
            {
                DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
                rentRangeList = (from c in cntx.Rent_Ranges
                                select c.Rent_Range1).ToList();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            return rentRangeList;

        }

        public static List<int> getRoomCountList()
        {
            List<int> roomCountList = new List<int>(); ;
            try
            {
                DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
                roomCountList = (from c in cntx.RoomCountTables
                                 select (int) c.Room_Count).ToList();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            return roomCountList;

        }

        public static List<string> getDurationList()
        {
            List<string> durationList = new List<string>(); ;
            try
            {
                DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
                durationList = (from c in cntx.DurationTables
                                 select c.Duration).ToList();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            return durationList;

        }

        public static int getRequestedProperty(Classes.PropertyDetails pd)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

            var info = (from p in cntx.Properties
                        where p.TenantCategory == pd.TenantCategory && p.HomeCategory == pd.HomeCategory && p.Location == pd.Location && p.RoomCount == int.Parse(pd.RoomCount)
                        && p.Detailed_Address == pd.DetailedAddress && p.Additional_Comments == pd.AdditionalComment && p.RentRangeId == int.Parse(pd.RentRange)
                        select p.PropertyId).SingleOrDefault();

            int propertyId = info;

            return propertyId;

        }

      

        public static int setReq(int propertyId, string user)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            var userid = (from u in cntx.Users
                          where u.UserName == user
                          select u.UserId).SingleOrDefault();

            var qry = (from r in cntx.Requests
                       where r.UserId == userid && r.PropertyId == propertyId
                       select r).ToList();

           
            if (qry.Count > 0)
            {

                MessageBox.Show("You have already requested");
               
            }
            else
            {
                Request r = new Request();
                r.PropertyId = propertyId;
                r.UserId = userid;

                cntx.Requests.InsertOnSubmit(r);
                cntx.SubmitChanges();

                var set = (from p in cntx.Properties
                           where p.PropertyId == propertyId
                           select p).SingleOrDefault();

                set.Request_for_rent = ++set.Request_for_rent;

                cntx.SubmitChanges();
              
            }
    
            return userid;
        }

        public static List<int> getRequestResult(Classes.PropertyDetails pd)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();

             var propertyId = (from p in cntx.Properties
                        where p.TenantCategory == pd.TenantCategory && p.HomeCategory == pd.HomeCategory && p.Location == pd.Location && p.RoomCount == int.Parse(pd.RoomCount)
                        && p.Detailed_Address == pd.DetailedAddress && p.Additional_Comments == pd.AdditionalComment && p.RentRangeId == int.Parse(pd.RentRange)
                        select p.PropertyId).SingleOrDefault();

             List<int> useridlist = (from r in cntx.Requests
                                    where r.PropertyId == propertyId
                                    select r.UserId).ToList();

          
             return useridlist;
        }
        public static List<Classes.User> getUserRequestInfo(int userid,SearchResultForm srf)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
         

            var k = (from p in cntx.UserInfos
                        join c in cntx.Users
                        on p.UserId equals c.UserId
                        where p.UserId == userid
                        select new Classes.User
                        {
                           
                            FirstName = p.First_Name,
                            LastName=p.Last_Name,
                            MobileNo=p.MobileNo,
                            NidNo=p.Nid_No,
                            Email=p.Email,
                            Address=p.Address,
                            DOB= p.Date_of_Birth,
                            UserName=c.UserName
                        }).ToList();
          
               return k;
 
        }
        public static Image getUserPic(string username)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            var pic = (from p in cntx.UserInfos
                       join c in cntx.Users
                       on p.UserId equals c.UserId
                       where c.UserName==username
                       select p.Profile_Pic).Single();

            Binary bpic = pic;
            byte[] b = bpic.ToArray();

            MemoryStream ms = new MemoryStream(b);

            Image img = Image.FromStream(ms);

            return img;
        }
        public static Classes.User getUserProfile(string user)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            var info = from p in cntx.UserInfos
                       join c in cntx.Users
                       on p.UserId equals c.UserId
                       where c.UserName == user 
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
                u.FirstName = item.First_Name;
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

        public static void setInRentProperty(Classes.PropertyDetails pd,MainUI m)
        {
             DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
             var info=(from p in cntx.Properties
                       where p.TenantCategory == pd.TenantCategory && p.HomeCategory == pd.HomeCategory && p.Location == pd.Location && p.RoomCount == int.Parse(pd.RoomCount)
                       && p.Detailed_Address == pd.DetailedAddress && p.Additional_Comments == pd.AdditionalComment && p.RentRangeId == int.Parse(pd.RentRange)
                       select p).SingleOrDefault();
             info.PropertyStatus = "inrent";
             info.Request_for_rent = 0;

             cntx.SubmitChanges();
             m.GetData();
            
        }

        public static void setTenant(Classes.User tenant,Classes.PropertyDetails pd,MainUI m)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
           

           var info = (from p in cntx.Properties
                        where p.TenantCategory == pd.TenantCategory && p.HomeCategory == pd.HomeCategory && p.Location == pd.Location && p.RoomCount == int.Parse(pd.RoomCount)
                        && p.Detailed_Address == pd.DetailedAddress && p.Additional_Comments == pd.AdditionalComment && p.RentRangeId == int.Parse(pd.RentRange)
                        select p).SingleOrDefault();
           
            var userid = (from q in cntx.Users
                          where q.UserName == tenant.UserName
                          select q).SingleOrDefault();
          
            
            Tenant t = new Tenant();
            t.UserId = userid.UserId;
            t.PropertyId = info.PropertyId;

            cntx.Tenants.InsertOnSubmit(t);
            cntx.SubmitChanges();
            m.GetData();
           
            
        }
        public static void setMyRent(Classes.User tenant, Classes.PropertyDetails pd, MainUI m)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            m.GetData();
        }

        public static void setMyLandlord(Classes.User tenant, Classes.PropertyDetails pd, MainUI m)
        {
            DataClasses1DataContext cntx = ToLet.Database.DBConnectionProvider.getDBConnection();
            m.GetData();
        }
      


    }
 
}
