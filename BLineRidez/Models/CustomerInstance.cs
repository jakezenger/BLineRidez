using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class CustomerInstance
    {
        public Customer Customer { get; }
        public RideRequest RideRequest { get; set; }

        public CustomerInstance(Customer customer)
        {
            Customer = customer;
        }

        public CustomerInstance(Customer customer, RideRequest rideRequest)
        {
            Customer = customer;
            RideRequest = rideRequest;
        }
    }
}