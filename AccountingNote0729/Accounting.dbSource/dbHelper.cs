﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.dbSource
{
    public class dbHelper
    {
        public static string Getconnectionstring()
        {
            string val = ConfigurationManager.ConnectionStrings["Default Connection"].ConnectionString;
            return val;
        }
        public static DataTable ReadDataTable(string connectionstring, string dbCommandstring, List<SqlParameter> list)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(dbCommandstring, connection))
                {
                    command.Parameters.AddRange(list.ToArray());

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();

                        return dt;
                }
            }
        }


    }
}