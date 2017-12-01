using BLineRidez.SharedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Phone { get; }

        public User()
        {

        }

        public User(int id, string username, string firstName, string lastName, string email, string phone)
        {
            ID = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }
    }
}