﻿using BLineRidez.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace BLineRidez.SharedCode
{
    public enum LoginValidationResult { Invalid = 0, ValidDriver = 1, ValidCustomer = 2 };

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

                    string cmdString = String.Format("SELECT dbo.fnCheckUserNameAvailability('{0}')", customer.Username);
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

        public bool AddDriver(Driver driver, string password)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    string cmdString = String.Format("SELECT dbo.fnCheckUserNameAvailability('{0}')", driver.Username);
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
                        insertCmd.Parameters.Add("@CarMake", SqlDbType.NVarChar).Value = driver.Car.Make;
                        insertCmd.Parameters.Add("@CarColor", SqlDbType.NVarChar).Value = driver.Car.Color;
                        insertCmd.Parameters.Add("@CarModel", SqlDbType.NVarChar).Value = driver.Car.Model;
                        insertCmd.Parameters.Add("@CarYear", SqlDbType.Int).Value = driver.Car.Year;
                        insertCmd.Parameters.Add("@CarLicensePlate", SqlDbType.NChar).Value = driver.Car.LicensePlate;

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

        public void AddPaymentDetails(PaymentDetails paymentDetails, int requestID)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    SqlCommand insertCmd = new SqlCommand("spAddPaymentDetails", connection);
                    insertCmd.CommandType = CommandType.StoredProcedure;
                    insertCmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = requestID;
                    insertCmd.Parameters.Add("@BillingFirstName", SqlDbType.NVarChar).Value = paymentDetails.FirstName;
                    insertCmd.Parameters.Add("@BillingLastName", SqlDbType.NVarChar).Value = paymentDetails.LastName;
                    insertCmd.Parameters.Add("@CardNum", SqlDbType.NChar).Value = paymentDetails.CardNum;
                    insertCmd.Parameters.Add("@SecurityCode", SqlDbType.NChar).Value = paymentDetails.SecurityCode;
                    insertCmd.Parameters.Add("@BillingAddressLine1", SqlDbType.NVarChar).Value = paymentDetails.BillingAddress.Line1;
                    insertCmd.Parameters.Add("@BillingAddressLine2", SqlDbType.NVarChar).Value = paymentDetails.BillingAddress.Line2;
                    insertCmd.Parameters.Add("@BillingAddressCity", SqlDbType.NVarChar).Value = paymentDetails.BillingAddress.City;
                    insertCmd.Parameters.Add("@BillingAddressState", SqlDbType.NVarChar).Value = paymentDetails.BillingAddress.State;
                    insertCmd.Parameters.Add("@BillingAddressZipCode", SqlDbType.NVarChar).Value = paymentDetails.BillingAddress.Zip;

                    insertCmd.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    connection.Close();
                }
            }
        }

        public int AddRequest(RideRequest rideRequest)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                int requestID = 0;

                try
                {
                    connection.Open();

                    SqlCommand insertCmd = new SqlCommand("spInsertRequest", connection);
                    insertCmd.CommandType = CommandType.StoredProcedure;

                    insertCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = rideRequest.Customer.ID;
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

                    using (var reader = insertCmd.ExecuteReader())
                    {
                        reader.Read();

                        if ((int)reader["newRequestID"] > 0)
                            requestID = (int)reader["newRequestID"];
                    }

                    connection.Close();

                    return requestID;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return requestID;
                }
            }
        }

        public void FulfillRideRequest(int driverID, int requestID, DateTime driverETA)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    SqlCommand fulfillCmd = new SqlCommand("spFulfillRideRequest", connection);
                    fulfillCmd.CommandType = CommandType.StoredProcedure;
                    fulfillCmd.Parameters.Add("@RequestID", SqlDbType.Int).Value = requestID;
                    fulfillCmd.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;
                    fulfillCmd.Parameters.Add("@DriverETA", SqlDbType.DateTime).Value = driverETA;

                    fulfillCmd.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    connection.Close();
                }
            }
        }

        public IList<RideRequest> GetUnfulfilledRequests()
        {
            IList<RideRequest> requests = new List<RideRequest>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    SqlCommand GetCustomerCmd = new SqlCommand("spGetUnfulfilledRequests", connection);
                    GetCustomerCmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = GetCustomerCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = GetCustomer((int)reader["CustomerID"]);
                            Address pickupAddress = GetAddress((int)reader["PickUpAddressID"]);
                            Address destinationAddress = GetAddress((int)reader["DestinationAddressID"]);
                            DateTime submissionDate = (DateTime)reader["SubmissionDate"];
                            DateTime pickupDate = (DateTime)reader["PickUpDate"];
                            int requestID = (int)reader["RequestID"];

                            RideRequest request = new RideRequest(customer, pickupAddress, destinationAddress, submissionDate, pickupDate, requestID);
                            requests.Add(request);
                        }

                        connection.Close();
                        return requests;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    connection.Close();
                    return requests;
                }
            }
        }

        public bool IsRequestFulfilled(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                bool fulfilled = false;

                try
                {
                    connection.Open();

                    string cmdString = String.Format("SELECT dbo.fnCheckRequestFulfilled({0})", id);
                    SqlCommand checkFulfilledCmd = new SqlCommand(cmdString, connection);

                    fulfilled = (bool)checkFulfilledCmd.ExecuteScalar();
                    connection.Close();
                    return fulfilled;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    connection.Close();
                    return fulfilled;
                }
            }
        }

        public Customer GetCustomer(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                Customer customer = new Customer();

                try
                {
                    connection.Open();

                    SqlCommand GetCustomerCmd = new SqlCommand("spGetCustomer", connection);
                    GetCustomerCmd.CommandType = CommandType.StoredProcedure;
                    GetCustomerCmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = username;
                    GetCustomerCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;

                    using (var reader = GetCustomerCmd.ExecuteReader())
                    {
                        reader.Read();

                        customer = new Customer((string)reader["UserName"], (string)reader["FirstName"], (string)reader["LastName"],
                            (string)reader["Email"], (string)reader["PhoneNum"], (int)reader["ID"]);

                        connection.Close();
                        return customer;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    connection.Close();
                    return customer;
                }
            }
        }

        public Address GetAddress(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                Address address = new Address();

                try
                {
                    connection.Open();

                    SqlCommand GetCustomerCmd = new SqlCommand("spGetAddressFromID", connection);
                    GetCustomerCmd.CommandType = CommandType.StoredProcedure;
                    GetCustomerCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (var reader = GetCustomerCmd.ExecuteReader())
                    {
                        reader.Read();

                        address = new Address((string)reader["Line1"], (string)reader["Line2"], (string)reader["City"], (string)reader["State"], GetZipCode((int)reader["ZipCodeID"]));

                        connection.Close();
                        return address;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    connection.Close();
                    return address;
                }
            }
        }

        public int GetZipCode(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                int zipCode = 0;

                try
                {
                    connection.Open();

                    SqlCommand GetCustomerCmd = new SqlCommand("spGetZipCodeFromID", connection);
                    GetCustomerCmd.CommandType = CommandType.StoredProcedure;
                    GetCustomerCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (var reader = GetCustomerCmd.ExecuteReader())
                    {
                        reader.Read();

                        zipCode = (int)reader["ZipCode"];

                        connection.Close();
                        return zipCode;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    connection.Close();
                    return zipCode;
                }
            }
        }

        public RideRequest GetFulfilledRequest(int customerID)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                RideRequest rideRequest = new RideRequest();

                try
                {
                    connection.Open();

                    SqlCommand GetDriverCmd = new SqlCommand("spGetMostRecentFulfilledRequest", connection);
                    GetDriverCmd.CommandType = CommandType.StoredProcedure;
                    GetDriverCmd.Parameters.Add("@customerID", SqlDbType.Int).Value = customerID;


                    using (var reader = GetDriverCmd.ExecuteReader())
                    {
                        reader.Read();
                        int requestID = (int)reader["RequestID"];

                        if (IsRequestFulfilled(requestID))
                        {
                            Customer customer = GetCustomer((int)reader["CustomerID"]);
                            Address pickupAddress = GetAddress((int)reader["PickUpAddressID"]);
                            Address destinationAddress = GetAddress((int)reader["DestinationAddressID"]);
                            DateTime submissionDate = (DateTime)reader["SubmissionDate"];
                            DateTime pickupDate = (DateTime)reader["PickUpDate"];

                            Driver driver = GetDriver((int)reader["DriverID"]);

                            DateTime driverETA = (DateTime)reader["DriverETA"];
                            DateTime dropOffDate = new DateTime();


                            rideRequest = new RideRequest(requestID, customer, pickupAddress, destinationAddress, submissionDate, pickupDate, driver, dropOffDate, driverETA);
                        }

                        connection.Close();
                        return rideRequest;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    connection.Close();
                    return rideRequest;
                }
            }
        }

        public Driver GetDriver(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                Driver driver = new Driver();

                try
                {
                    connection.Open();

                    SqlCommand GetDriverCmd = new SqlCommand("spGetDriver", connection);
                    GetDriverCmd.CommandType = CommandType.StoredProcedure;
                    GetDriverCmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = username;
                    GetDriverCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;


                    using (var reader = GetDriverCmd.ExecuteReader())
                    {
                        reader.Read();

                        driver = new Driver(GetCar((int)reader["CarID"]), (bool)reader["IsActive"], (string)reader["UserName"],
                            (string)reader["FirstName"], (string)reader["LastName"], (string)reader["Email"], (string)reader["PhoneNum"], (int)reader["ID"]);

                        connection.Close();
                        return driver;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    connection.Close();
                    return driver;
                }
            }
        }

        public Driver GetDriver(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                Driver driver = new Driver();

                try
                {
                    connection.Open();

                    SqlCommand GetDriverCmd = new SqlCommand("spGetDriverFromID", connection);
                    GetDriverCmd.CommandType = CommandType.StoredProcedure;
                    GetDriverCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;


                    using (var reader = GetDriverCmd.ExecuteReader())
                    {
                        reader.Read();

                        driver = new Driver(GetCar((int)reader["CarID"]), (bool)reader["IsActive"], (string)reader["UserName"],
                            (string)reader["FirstName"], (string)reader["LastName"], (string)reader["Email"], (string)reader["PhoneNum"], (int)reader["ID"]);

                        connection.Close();
                        return driver;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    connection.Close();
                    return driver;
                }
            }
        }

        private Car GetCar(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                Car car = new Car();

                try
                {
                    connection.Open();

                    SqlCommand GetCarCmd = new SqlCommand("spGetCar", connection);
                    GetCarCmd.CommandType = CommandType.StoredProcedure;
                    GetCarCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (var reader = GetCarCmd.ExecuteReader())
                    {
                        reader.Read();

                        car = new Car((string)reader["Make"], (string)reader["Model"], (string)reader["Color"], (int)reader["Year"], (string)reader["LicensePlate"]);

                        connection.Close();
                        return car;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    connection.Close();
                    return car;
                }
            }
        }

        private Customer GetCustomer(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                Customer customer = new Customer();

                try
                {
                    connection.Open();

                    SqlCommand GetCarCmd = new SqlCommand("spGetCustomerFromID", connection);
                    GetCarCmd.CommandType = CommandType.StoredProcedure;
                    GetCarCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (var reader = GetCarCmd.ExecuteReader())
                    {
                        reader.Read();

                        customer = new Customer();

                        connection.Close();
                        return customer;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    connection.Close();
                    return customer;
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
}