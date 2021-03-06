﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLineRidez.Models;
using BLineRidez.SharedCode;

namespace BLineRidez
{
    public partial class CustomerRideRequestForm : System.Web.UI.Page
    {
        public static int counter = 0;
        Database db = new Database();
        int requestID;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserSession session = (UserSession)Session["userSession"];

            if (session != null)
            {
                if (!session.IsLoggedIn)
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
            }
            else
                Response.Redirect("~/Pages/Login.aspx");
        }

        protected void RequestRideButton_Click(object sender, EventArgs e)
        {
            string pickupLine1 = PickupLine1TextBox.Text;
            string pickupLine2 = PickupLine2TextBox.Text;
            string pickupCity =  PickupCityTextBox.Text;
            string pickupState = PickupStateTextBox.Text;
            int pickupZip = int.Parse(PickupZipTextBox.Text);

            Address pickupAddress = new Address(pickupLine1, pickupLine2, pickupCity, pickupState, pickupZip);

            string dropoffLine1 = DropoffLine1TextBox.Text;
            string dropoffLine2 = DropoffLine2TextBox.Text;
            string dropoffCity =  DropoffCityTextBox.Text;
            string dropoffState = DropoffStateTextBox.Text;
            int dropoffZip = int.Parse(DropoffZipTextBox.Text);

            Address dropoffAddress = new Address(dropoffLine1, dropoffLine2, dropoffCity, dropoffState, dropoffZip);

            UserSession userSession = (UserSession)Session["userSession"];

            DateTime pickupDate = Convert.ToDateTime(PickupTimeTextBox.Text);
            RideRequest rideRequest = new RideRequest((Customer)userSession.User, pickupAddress, dropoffAddress, DateTime.Now, pickupDate);
            
            //db = new Database();
            requestID = db.AddRequest(rideRequest);

            RideRequestStatusLabel.Text = "Waiting for Driver";
            RideStatusTimer.Enabled = true;        
            
        }

        protected void AsapButton_Click(object sender, EventArgs e)
        {
            PickupTimeTextBox.Text = DateTime.Now.ToString();
        }

        protected void RideStatusTimer_Tick(object sender, EventArgs e)
        {
            if (!db.IsRequestFulfilled(requestID))
            {
                counter = ++counter % 4;
                string requestStatusStr = "Waiting for Driver" + new String('.', counter);
                RideRequestStatusLabel.Text = requestStatusStr;
            }
            else
            {
                RideRequestStatusLabel.BackColor = System.Drawing.Color.Green;
                RideRequestStatusLabel.ForeColor = System.Drawing.Color.Magenta;
                RideRequestStatusLabel.Text = "Your Driver is on their way!";
                RideStatusTimer.Enabled = false;
            }
        }
    }
}