﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExample.Dal.DatabaseConnection
{
    public static class DatabaseConnectionClass
    {
        public static SqlConnection connect { get; set; } //database static

        /// <summary>
        /// Check if database connection is open
        /// </summary>
        /// <returns>True if open false if closed</returns>
        public static bool OpenConnection()
        {
            connect = new SqlConnection();

            try
            {
                connect.ConnectionString = "Server=172.21.5.120;Initial Catalog=STG_KWAR_PROMASST_MES_V7.3.0;Persist Security Info=false; User = sa; password=k00lZ@@D";
                connect.Open();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            if (connect.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Close database connection
        /// </summary>
        /// <returns>True if connection is closed false if not</returns>
        public static void CloseConnection()
        {
            connect.Close();
        }
    }
}