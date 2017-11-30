using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Customer(int customerID, string username, string firstName, string lastName, string email, string phone)
        {
            CustomerID = customerID;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }
    }
}