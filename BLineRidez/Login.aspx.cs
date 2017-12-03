using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLineRidez.SharedCode;
using BLineRidez.Models;

namespace BLineRidez
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            Database db = new Database();

            LoginValidationResult validationResult = db.ValidateLogin(username, password);

            switch (validationResult)
            {
                case LoginValidationResult.Invalid:
                    // handle an invalid login
                    break;
                case LoginValidationResult.ValidCustomer:
                    // Set up the customer's user session
                    Session["userSession"] = new UserSession(db.GetCustomer(username, password));

                    UserSession userSession = (UserSession)Session["userSession"];
                    int fulfilledRequestID = db.GetFulfilledRequest(userSession.User.ID).ID;

                    // if (fulfilledRequestID != 0)
                    //    Response.Redirect("~/RequestFulfilled?id=" + fulfilledRequestID.ToString());
                    //else
                        Response.Redirect("~/CustomerRideRequest.aspx");
                    break;
                case LoginValidationResult.ValidDriver:
                    // Set up the driver's user session
                    Session["userSession"] = new UserSession(db.GetDriver(username, password));

                    Response.Redirect("~/DriverRideRequest.aspx");
                    break;
            }
        }
    }
}