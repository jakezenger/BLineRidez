using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
    }
}