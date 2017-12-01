using BLineRidez.SharedCode;
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

        public Driver() : base()
        {

        }

        public Driver(Car car, bool isActive, string username, string firstName, string lastName, string email, string phone, int id = 0) : base(id, username, firstName, lastName, email, phone)
        {
            Car = car;
            IsActive = isActive;
        }
    }
}