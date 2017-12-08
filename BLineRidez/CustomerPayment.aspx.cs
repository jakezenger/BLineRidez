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
        Database db = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserSession session = (UserSession)Session["userSession"];
            RideRequest request = db.GetFulfilledRequest(session.User.ID);
            
            {
                string infoStr = String.Format(
                    "{0} is on their way!\n" +
                    "Driving a {1} {2} {3}\n" +
                    "License Plate: {4}\n" +
                    "ETA: {5}\n"
                    , request.Driver.FirstName + " " + request.Driver.LastName, request.Driver.Car.Color, request.Driver.Car.Make, request.Driver.Car.Model, request.Driver.Car.LicensePlate, request.DriverETA.ToString()
                    );

                RequestDetailsTextBox.Text = infoStr;
            }
            
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            int reqID = Convert.ToInt32(Request.QueryString["id"]);
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


            db.AddPaymentDetails(payDetails, reqID); 
        }
    }
}