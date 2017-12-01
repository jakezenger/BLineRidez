using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class Driver : User
    {
        public Car Car { get; }
        public bool IsActive { get; set; }


        public Driver(Car car, bool isActive, string username, string firstName, string lastName, string email, string phone) : base(username, firstName, lastName, email, phone)
        {
            Car = car;
            IsActive = isActive;
        }
    }
}