using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class RideRequest
    {
        public int ID { get; set; }
        public Customer Customer { get; }
        public Address PickupAddress { get; }
        public Address DropoffAddress { get; set; }
        public Driver Driver { get; set; }
        public DateTime RequestSubmissionDate { get; }
        public DateTime PickupDate { get; set; }
        public DateTime DropoffDate { get; set; }

        public RideRequest(int id, Customer customer, Address pickupAddress, Address dropoffAddress, DateTime requestSubmissionDate, DateTime pickupDate, Driver driver = null, DateTime dropoffDate = new DateTime())
        {
            ID = id;
            Customer = customer;
            PickupAddress = pickupAddress;
            DropoffAddress = dropoffAddress;
            Driver = driver;
            RequestSubmissionDate = requestSubmissionDate;
            PickupDate = pickupDate;
            DropoffDate = dropoffDate;
        }
    }
}