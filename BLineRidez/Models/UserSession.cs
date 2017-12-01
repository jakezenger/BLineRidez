using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class UserSession
    {
        public User User { get; set; }
        public bool IsLoggedIn { get; set; };

        public UserSession()
        {
            IsLoggedIn = false;
        }

        public UserSession(User user)
        {
            User = user;
            IsLoggedIn = true;
        }
    }
}