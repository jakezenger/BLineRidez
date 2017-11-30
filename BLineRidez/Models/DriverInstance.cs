using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class DriverInstance
    {
        Driver Driver { get; }
        List<RideRequest> UnfullfilledRequests { get; set; }
        RideRequest CurrentRideRequest { get; set; }

        public DriverInstance(Driver driver)
        {
            Driver = driver;
        }

        public DriverInstance(Driver driver, List<RideRequest> unfullfilledRequests)
        {
            Driver = driver;
            UnfullfilledRequests = unfullfilledRequests;
        }
    }
}