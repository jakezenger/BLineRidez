using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class Address
    {
        public string Line1 { get; }
        public string Line2 { get; }
        public string City { get; }
        public string State { get; }
        public string Zip { get; }

        public Address(string line1, string line2, string city, string state, string zip)
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            State = state;
            Zip = zip;
        }
    }
}