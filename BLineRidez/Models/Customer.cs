using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Username { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Phone { get; }

        public Customer(string username, string firstName, string lastName, string email, string phone)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }
    }
}