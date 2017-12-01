using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLineRidez.Models;

namespace BLineRidez
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void RequestRideButton_Click(object sender, EventArgs e)
        {
            string pickupLine1 = PickupLine1TextBox.Text;
            string pickupLine2 = PickupLine2TextBox.Text;
            string pickupCity =  PickupCityTextBox.Text;
            string pickupState = PickupStateTextBox.Text;
            int pickupZip = Convert.ToInt32(PickupZipTextBox.Text);

            Address pickupAddress = new Address(pickupLine1, pickupLine2, pickupCity, pickupState, pickupZip);

            string dropoffLine1 = DropoffLine1TextBox.Text;
            string dropoffLine2 = DropoffLine2TextBox.Text;
            string dropoffCity =  DropoffCityTextBox.Text;
            string dropoffState = DropoffStateTextBox.Text;
            int dropoffZip = Convert.ToInt32(DropoffZipTextBox.Text);

            Address dropoffAddress = new Address(dropoffLine1, dropoffLine2, dropoffCity, dropoffState, dropoffZip);

            // TODO: Make and instance of RideRequest and set CustomerInstance.RideRequest to it.
        }
    }
}