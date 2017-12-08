using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLineRidez.Models;
using BLineRidez.SharedCode;

namespace BLineRidez
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string firstName = BillingFirstNameTextBox.Text;
            string lastName = BillingLastNameTextBox.Text;
            string cardNumber = BillingCardNumTextBox.Text;
            string secCode = BillingSecCodeTextBox.Text;
            string line1 = BillingLine1TextBox.Text;
            string line2 = BillingLine2TextBox.Text;
            string city = BillingCityTextBox.Text;
            string state = BillingStateTextBox.Text;
            string zip = BillingZipTextBox.Text;

            Address billingAddress = new Address(line1, line2, city, state, int.Parse(zip));
            PaymentDetails payDetails = new PaymentDetails(cardNumber, secCode, billingAddress, firstName, lastName);

            Database db = new Database();

            db.AddPaymentDetails(payDetails, 1232); //This needs to be changed throughout the stack
        }
    }
}