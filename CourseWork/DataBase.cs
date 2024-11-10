using System;
using System.Data;
using System.Data.SqlClient;

namespace ServiceCenterApp
{
    public class DatabaseConnection
    {
        public static string GetConnection()
        {
            return "Server=DESKTOP-K2ID4TF;Database=ServiceCenter;User Id=user1;Password=user1;"; 
        }
    }
}