using System;
using System.Data;
using System.Data.SqlClient;

namespace ServiceCenterApp
{
    public class DatabaseConnection
    {
        private readonly string connectionString = "Server=DESKTOP-K2ID4TF;Database=ServiceCenter;User Id=user1;Password=user1;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}