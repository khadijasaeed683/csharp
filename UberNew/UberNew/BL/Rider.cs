using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberNew
{
    internal class Rider
    {
        private string Name;
        private string email;
        private string Password;
        private string HomeAddress;
        // private string OfficeAddress;
        private string PhoneNumber;
        public string getName() { return Name; }
        public string getEmail() { return email; }
        public string getPassword() { return Password; }
        public string getAddress() { return HomeAddress; }
        //  public string getOfficeAddress() { return OfficeAddress;}
        public string getPhoneNumber() { return PhoneNumber; }
        public void setName(string name) { Name = name; }
        public void setEmail(string idCard) { email = idCard; }
        public void setPassword(string password) { Password = password; }
        public void setAddress(string homeAddAddress) { HomeAddress = homeAddAddress; }
        //  public void setOfficeAddress(string  officeAddress) {  OfficeAddress = officeAddress;}
        public void setPhoneNumber(string phoneNumber) { PhoneNumber = phoneNumber; }

        public Rider()
        {

        }
        public Rider(string name, string em, string pass, string homeAdd, string PhoneNo)
        {
            Name = name;
            email = em;
            Password = pass;
            HomeAddress = homeAdd;
            // OfficeAddress = officeAdd;
            PhoneNumber = PhoneNo;
        }
        public Rider(string name, string em, string pass, string PhoneNo)
        {
            Name = name;
            email = em;
            Password = pass;
            PhoneNumber = PhoneNo;
        }
        public Rider(string name, string pass)
        {
            Name = name;
            Password = pass;
        }
    }
}
