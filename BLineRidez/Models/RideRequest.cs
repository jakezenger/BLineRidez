using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class RideRequest
    {
        public Customer Customer { get; }
        public Address PickupAddress { get; }
        public Address DropoffAddress { get; set; }
        public Driver Driver { get; set; }
        public DateTime RequestSubmissionDate { get; }
        public DateTime PickupDate { get; set; }
        public DateTime DropoffDate { get; set; }

        public RideRequest(Customer customer, Address pickupAddress, Address dropoffAddress, Driver driver, DateTime requestSubmissionDate, DateTime pickupDate, DateTime dropoffDate)
        {
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