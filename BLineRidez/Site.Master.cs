using BLineRidez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLineRidez
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Instantiate the UserSession if it doesn't already exist
            if (Session["userSession"] == null)
            {
                Session["userSession"] = new UserSession();
            }
            else
            {
                UserSession userSession = (UserSession)Session["userSession"];

                if (userSession.IsLoggedIn)
                {
                    UserGreetingLabel.Text = String.Format("Hello {0}!", userSession.User.FirstName);
                    UserGreetingLabel.Visible = true;
                }
                else
                {
                    UserGreetingLabel.Text = "";
                    UserGreetingLabel.Visible = false;
                }
            }
        }
    }
}