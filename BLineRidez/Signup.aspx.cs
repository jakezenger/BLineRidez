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
    public partial class SignupForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomerSubmitButton_Click(object sender, EventArgs e)
        {
            string username = CustomerUsernameTextBox.Text;
            string firstName = CustomerFirstNameTextBox.Text;
            string lastName = CustomerLastNameTextBox.Text;
            string email = CustomerEmailTextBox.Text;
            string phone = CustomerPhoneTextBox.Text;
            string password = "";

            Customer customer = new Customer(username, firstName, lastName, email, phone);

            // TODO: Validate customer data fields

            Database db = new Database();
            db.AddCustomer(customer, password);
        }

        protected void DriverSubmitButton_Click(object sender, EventArgs e)
        {
            string username = DriverUsernameTextBox.Text;
            string firstName = DriverFirstNameTextBox.Text;
            string lastName = DriverLastNameTextBox.Text;
            string email = DriverEmailTextBox.Text;
            string phone = DriverPhoneTextBox.Text;
            string password = "";

            string make = CarMakeTextBox.Text;
            string model = CarModelTextBox.Text;
            string color = CarColorTextBox.Text;
            int year = Convert.ToInt32(CarYearTextBox.Text);

            Car car = new Car(make, model, color, year);
            Driver driver = new Driver(car, false, username, firstName, lastName, email, phone);

            //TODO: Validate driver data fields

            Database db = new Database();
            db.AddDriver(driver, password);
        }
    }
}