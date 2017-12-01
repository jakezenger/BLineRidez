using BLineRidez.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace BLineRidez.SharedCode
{
    public enum LoginValidationResult { Invalid = 0, ValidDriver = 1, ValidCustomer = 2};

    public class Database
    {
        private string CONNECTION_STRING;
        

        public Database()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "b-lineridez.database.windows.net";
            builder.UserID = "jakezenger";
            builder.Password = "orangeChicken17";
            builder.InitialCatalog = "BLineRidezDB";

            CONNECTION_STRING = builder.ConnectionString.ToString();
        }

        public bool AddCustomer(Customer customer, string password)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    string cmdString = String.Format("SELECT dbo.fnCheckUserNameAvailability({0})", customer.Username);
                    SqlCommand checkUsernameAvailabilityCmd = new SqlCommand(cmdString, connection);

                    bool usernameIsAvailable = (bool)checkUsernameAvailabilityCmd.ExecuteScalar();

                    if (usernameIsAvailable)
                    {
                        SqlCommand insertCmd = new SqlCommand("spInsertCustomer", connection);
                        insertCmd.CommandType = CommandType.StoredProcedure;
                        insertCmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = customer.Username;
                        insertCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = customer.FirstName;
                        insertCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = customer.LastName;
                        insertCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                        insertCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = customer.Email;
                        insertCmd.Parameters.Add("@PhoneNum", SqlDbType.NVarChar).Value = customer.Phone;

                        insertCmd.ExecuteNonQuery();

                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
        }

        public bool AddDriver(Driver driver, Car car, string password)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    string cmdString = String.Format("SELECT dbo.fnCheckUserNameAvailability({0})", driver.Username);
                    SqlCommand checkUsernameAvailabilityCmd = new SqlCommand(cmdString, connection);

                    bool usernameIsAvailable = (bool)checkUsernameAvailabilityCmd.ExecuteScalar();

                    if (usernameIsAvailable)
                    {
                        SqlCommand insertCmd = new SqlCommand("spInsertDriver", connection);
                        insertCmd.CommandType = CommandType.StoredProcedure;
                        insertCmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = driver.Username;
                        insertCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = driver.FirstName;
                        insertCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = driver.LastName;
                        insertCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                        insertCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = driver.Email;
                        insertCmd.Parameters.Add("@PhoneNum", SqlDbType.NVarChar).Value = driver.Phone;
                        insertCmd.Parameters.Add("@CarMake", SqlDbType.NVarChar).Value = car.Make;
                        insertCmd.Parameters.Add("@CarColor", SqlDbType.NVarChar).Value = car.Color;
                        insertCmd.Parameters.Add("@CarModel", SqlDbType.NVarChar).Value = car.Model;
                        insertCmd.Parameters.Add("@CarYear", SqlDbType.NVarChar).Value = car.Year;

                        insertCmd.ExecuteNonQuery();

                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
        }

        public void AddRequest(RideRequest rideRequest)
        {
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    SqlCommand insertCmd = new SqlCommand("spInsertRequest", connection);
                    insertCmd.CommandType = CommandType.StoredProcedure;

                    insertCmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = rideRequest.Customer.ID;
                    insertCmd.Parameters.Add("@PickUpDate", SqlDbType.NVarChar).Value = rideRequest.PickupDate;

                    // Pickup address parameters...
                    insertCmd.Parameters.Add("@PickUpLine1", SqlDbType.NVarChar).Value = rideRequest.PickupAddress.Line1;
                    insertCmd.Parameters.Add("@PickUpLine2", SqlDbType.NVarChar).Value = rideRequest.PickupAddress.Line2;
                    insertCmd.Parameters.Add("@PickUpCity", SqlDbType.NVarChar).Value = rideRequest.PickupAddress.City;
                    insertCmd.Parameters.Add("@PickUpState", SqlDbType.NVarChar).Value = rideRequest.PickupAddress.State;
                    insertCmd.Parameters.Add("@PickUpZipCode", SqlDbType.NVarChar).Value = rideRequest.PickupAddress.Zip;

                    // Destination address parameters...
                    insertCmd.Parameters.Add("@DestinationLine1", SqlDbType.NVarChar).Value = rideRequest.DropoffAddress.Line1;
                    insertCmd.Parameters.Add("@DestinationLine2", SqlDbType.NVarChar).Value = rideRequest.DropoffAddress.Line2;
                    insertCmd.Parameters.Add("@DestinationCity", SqlDbType.NVarChar).Value = rideRequest.DropoffAddress.City;
                    insertCmd.Parameters.Add("@DestinationState", SqlDbType.NVarChar).Value = rideRequest.DropoffAddress.State;
                    insertCmd.Parameters.Add("@DestinationZipCode", SqlDbType.NVarChar).Value = rideRequest.DropoffAddress.Zip;

                    insertCmd.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public LoginValidationResult ValidateLogin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    string cmdString = String.Format("SELECT dbo.fnValidateLogin('{0}', '{1}')", username, password);
                    SqlCommand validateLoginCmd = new SqlCommand(cmdString, connection);

                    int serverReturned = (int)validateLoginCmd.ExecuteScalar();

                    connection.Close();
                    return (LoginValidationResult)serverReturned;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    connection.Close();
                    return LoginValidationResult.Invalid;
                }
            }
    }
}