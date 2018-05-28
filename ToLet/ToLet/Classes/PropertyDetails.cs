using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Drawing;
using System.Data.Linq;
using System.Windows.Forms;

namespace ToLet.Classes
{
    public class PropertyDetails
    {
        private string tenantCategory, homeCategory, location, roomCount, detailedAddress, additionalComments, rentRange,duration,propertystat;

        public PropertyDetails()
        {
        }

        public PropertyDetails(string tenantCategory, string homeCategory, string location, string roomCount, string detailedAddress, string additionalComments, string rentRange,string duration)
        {
            this.tenantCategory = tenantCategory;
            this.homeCategory = homeCategory;
            this.location = location;
            this.roomCount = roomCount;
            this.detailedAddress = detailedAddress;
            this.additionalComments = additionalComments;
            this.rentRange = rentRange;
            this.duration = duration;
        }

        public string TenantCategory
        {
            set { this.tenantCategory = value; }
            get { return this.tenantCategory; }
        }

        public string HomeCategory
        {
            set { this.homeCategory = value; }
            get { return this.homeCategory; }
        }

        public string Location
        {
            set { this.location = value; }
            get { return this.location; }
        }

        public string RoomCount
        {
            set { this.roomCount = value; }
            get { return this.roomCount; }
        }

        public string DetailedAddress
        {
            set { this.detailedAddress = value; }
            get { return this.detailedAddress; }
        }

        public string AdditionalComment
        {
            set { this.additionalComments = value; }
            get { return this.additionalComments; }
        }

        public string RentRange
        {
            set { this.rentRange = value; }
            get { return this.rentRange; }
        }

        public string PropertyStatus
        {
            set { this.propertystat = value; }
            get { return this.propertystat; }
        }

        public string Duration
        {
            set { this.duration = value; }
            get { return this.duration; }
        }
    }
}
