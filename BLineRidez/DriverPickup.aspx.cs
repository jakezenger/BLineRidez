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
    public partial class WebForm4 : System.Web.UI.Page
    {
        Database db = new Database();
        UserSession session;
        Driver driver;
        protected void Page_Load(object sender, EventArgs e)
        {
            session = (UserSession)Session["userSession"];
            driver = (Driver)session.User;
        }

        protected void PickupButton_Click(object sender, EventArgs e)
        {
            DateTime pickupTime = DateTime.Now;
            //TODO: Update pickup time in the DB

            PickupButton.Visible = false;
            RideFareLabel.Visible = RideFareTextBox.Visible = DropoffButton.Visible = true;
        }

        protected void DropoffButton_Click(object sender, EventArgs e)
        {
            decimal rideFare = decimal.Parse(RideFareTextBox.Text);
            DateTime dropoffTime = DateTime.Now;
            //TODO: Update dropoff time and ride fare

            Response.Redirect("~/DriverRideRequest.aspx");
        }
    }
}