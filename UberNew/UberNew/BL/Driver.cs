using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberNew
{
    internal class Driver
    {
        private string DriverName;
        private string DriverIdCard;
        private int DriverID;
        private string PhoneNumber;
        private string CarModel;
        private string License;
        private bool AvailabilityStatus = true;
        private DateTime JoiningDate;

        public Driver(string nm, string phnNmbr, string carModel, string license, string driverIdCard)
        {
            this.DriverName = nm;
            this.PhoneNumber = phnNmbr;
            this.CarModel = carModel;
            License = license;
            DriverIdCard = driverIdCard;
        } 
        public Driver(string nm, string driverIdCard)
        {
            this.DriverName = nm;
            DriverIdCard = driverIdCard;
        }


        public Driver()
        {

        }
        public void setDriverName(string driverName)
        {
            this.DriverName = driverName;
        }
        public void setDriverID(int driverID)
        {
            this.DriverID = driverID;
        }
        public void setPhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }
        public void setCarModel(string carModel)
        {
            this.CarModel = carModel;
        }
        public void SetJoiningDate(DateTime JoiningDate)
        {
            this.JoiningDate = JoiningDate;
        }
        public void UpdateAvailibilityStatus(bool s)
        {
            this.AvailabilityStatus = s;
        }

        public string getDriverName()
        {
            return this.DriverName;
        }
        public string getDriverIdCard()
        { return this.DriverIdCard; }
        public string getPhoneNumber() { return this.PhoneNumber; }
        public string getLicense() { return this.License; }
        public string getCarModel() { return this.CarModel; }
        public int getDriverId()
        { return this.DriverID; }
        public bool getAvailibilityStatus()
        {
            return this.AvailabilityStatus;
        }
        public DateTime GetJoiningDate() { return this.JoiningDate; }

    }
}
