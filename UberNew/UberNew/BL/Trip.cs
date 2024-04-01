using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberNew.BL
{
    internal class Trip
    {
        public static List<Trip> Trips = new List<Trip>();
        private string PickupLocation;
        private string DropoffLocation;
        private double Fare;
        private Driver driver;
        private Rider client;
        private double DistanceCovered;
        private bool TripStatus = true; //trip is active i.e no driver has responded yet
        public string getPickupLocation() { return PickupLocation; }
        public string getDropoffLocation() { return DropoffLocation; }
        public Driver getDriver() { return driver; }
        public Rider getRider() { return client; }
        public double getFare() { return Fare; }
        public double getDistanceCovered() { return DistanceCovered; }
        public bool getTripStatus() { return TripStatus; }
        public void setFare(double Fare) { this.Fare = Fare; }
        public void setPickupLocation(string PickupLocation) { this.PickupLocation = PickupLocation; }
        public void setDropoffLocation(string DropoffLocation) { this.DropoffLocation = DropoffLocation; }
        public void setDriver(Driver driver) { this.driver = driver; }
        public void setRider(Rider client) { this.client = client; }
        public void setDistanceCovered(double dis) { this.DistanceCovered = dis; }
        public void setTripStatus(bool status) { this.TripStatus = status; }
        public Trip()
        {

        }
        public double CalculateFare(double distance)
        {
            double fare;
            fare = 1.5 * distance;
            return fare;
        }

    }
}
