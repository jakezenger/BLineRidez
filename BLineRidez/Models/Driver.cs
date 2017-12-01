using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class Driver : User
    {
        //public int ID { get; set; }
        public Car Car { get; }
        public bool IsActive { get; set; }
        public string Username { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Phone { get; }

        public Driver(Car car, bool isActive, string username, string firstName, string lastName, string email, string phone)
        {
            Car = car;
            IsActive = isActive;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }
    }
}