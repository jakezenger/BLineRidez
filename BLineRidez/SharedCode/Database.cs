using BLineRidez.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace BLineRidez.SharedCode
{
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
                        SqlCommand insertUserCmd = new SqlCommand("spInsertCustomer", connection);
                        insertUserCmd.CommandType = CommandType.StoredProcedure;
                        insertUserCmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = customer.Username;
                        insertUserCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = customer.FirstName;
                        insertUserCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = customer.LastName;
                        insertUserCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                        insertUserCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = customer.Email;
                        insertUserCmd.Parameters.Add("@PhoneNum", SqlDbType.NVarChar).Value = customer.Phone;

                        insertUserCmd.ExecuteNonQuery();

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
                        SqlCommand insertUserCmd = new SqlCommand("spInsertDriver", connection);
                        insertUserCmd.CommandType = CommandType.StoredProcedure;
                        insertUserCmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = driver.Username;
                        insertUserCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = driver.FirstName;
                        insertUserCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = driver.LastName;
                        insertUserCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                        insertUserCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = driver.Email;
                        insertUserCmd.Parameters.Add("@PhoneNum", SqlDbType.NVarChar).Value = driver.Phone;
                        insertUserCmd.Parameters.Add("@CarMake", SqlDbType.NVarChar).Value = car.Make;
                        insertUserCmd.Parameters.Add("@CarColor", SqlDbType.NVarChar).Value = car.Color;
                        insertUserCmd.Parameters.Add("@CarModel", SqlDbType.NVarChar).Value = car.Model;
                        insertUserCmd.Parameters.Add("@CarYear", SqlDbType.NVarChar).Value = car.Year;

                        insertUserCmd.ExecuteNonQuery();

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
    }
}