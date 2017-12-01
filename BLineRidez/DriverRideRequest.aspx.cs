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
    public partial class DriverRideRequestForm : System.Web.UI.Page
    {
        public static Database db = new Database();
        List<RideRequest> requestList = (List<RideRequest>)db.GetUnfulfilledRequests();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserSession session = (UserSession)Session["userSession"];

            if (session != null)
            {
                if (!session.IsLoggedIn)
                {
                    Response.Redirect("~/Login.aspx");
                }
                else
                {
                    foreach (RideRequest request in requestList)
                    {
                        // TODO: Add a table header
                        TableRow row = new TableRow();

                        List<TableCell> cellList = new List<TableCell>(5);

                        for (int i = 0; i < 5; i++)
                        {
                            cellList.Add(new TableCell());
                        }
                        cellList[0].Text = request.ID.ToString();
                        cellList[1].Text = request.Customer.FirstName;
                        cellList[2].Text = request.PickupAddress.Line1 + ", " + request.PickupAddress.City;
                        cellList[3].Text = request.DropoffAddress.Line1 + ", " + request.DropoffAddress.City;
                        cellList[4].Text = request.PickupDate.ToString();

                        foreach (TableCell cell in cellList)
                        {
                            row.Cells.Add(cell);
                        }

                        RideRequestTable.Rows.Add(row);
                    }
                }
            }
            else
                Response.Redirect("~/Login.aspx");
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            UserSession session = (UserSession)Session["userSession"];
            db.FulfillRideRequest(session.User.ID, int.Parse(RequestIdTextBox.Text));
            //TODO: Make ETA viewable to Customer
        }
    }
}