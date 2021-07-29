using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Accounting.dbSource
{
    public class UserInfoManager
    {
        public static string Getconnectionstring()
        {
            string val = ConfigurationManager.ConnectionStrings["Default Connection"].ConnectionString;
            return val;
        }
        public static DataRow GetUserInfoListbyAccount(string account)
        {
            string connectionstring = Getconnectionstring();
            string dbCommandstring = @"SELECT [ID], [Account], [PWD],
                                              [Name], [Email]
                                       FROM   [UserInfo]
                                       WHERE  [Account] = @account";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(dbCommandstring, connection))
                {
                    command.Parameters.AddWithValue("@account", account);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();

                        if (dt.Rows.Count == 0)
                            return null;
                        DataRow dr = dt.Rows[0];
                        return dr;
                    }
                    catch (Exception ex)
                    {
                        Logger.Writelog(ex);
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
            }
        }
    }
}
