using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLineRidez.Models
{
    public class PaymentDetails
    {
        public int ID { get; set; }
        public string CardNum { get; set; }
        public string SecurityCode { get; set; }
        public Address BillingAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PaymentDetails()
        {

        }

        public PaymentDetails(string cardNum, string securityCode, Address billingAddress, string firstName, string lastName, int id = 0)
        {
            CardNum = cardNum;
            SecurityCode = securityCode;
            BillingAddress = billingAddress;
            FirstName = firstName;
            LastName = lastName;
            ID = id;
        }
    }
}