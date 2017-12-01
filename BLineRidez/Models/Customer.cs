using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class Customer : User
    {
        public Customer(string username, string firstName, string lastName, string email, string phone) : base(username, firstName, lastName, email, phone)
        {

        }
    }
}