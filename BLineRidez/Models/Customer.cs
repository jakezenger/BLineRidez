using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class Customer : User
    {
        public Customer() : base()
        {

        }

        public Customer(string username, string firstName, string lastName, string email, string phone, int id = 0) : base(id, username, firstName, lastName, email, phone)
        {

        }
    }
}