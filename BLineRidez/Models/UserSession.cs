using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class UserSession
    {
        public User User { get; }
        public RideRequest RideRequest { get; set; }

        public UserSession(User user)
        {
            User = user;
        }

        public UserSession(User user, RideRequest rideRequest)
        {
            User = user;
            RideRequest = rideRequest;
        }
    }
}