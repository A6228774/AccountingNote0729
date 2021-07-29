using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Accounting.dbSource
{
    public class AccountingManager
    {
        //public static string Getconnectionstring()
        //{
        //    string val = ConfigurationManager.ConnectionStrings["Default Connection"].ConnectionString;
        //    return val;
        //}
        public static DataTable GetAccountingList(string userid)
        {
            string connectionstring = dbHelper.Getconnectionstring();
            string dbCommandstring = @"SELECT [ID], [Caption], [Amount],
                                              [ActType], [CreateDate]
                                       FROM   [Accouting]
                                       WHERE  [UserID] = @userid";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userid", userid));

            try
            {
                return dbHelper.ReadDataTable(connectionstring, dbCommandstring, list);
            }
            catch (Exception ex)
            {
                Logger.Writelog(ex);
                return null;
            }

        }
        public static void CreateAccounting(string userid, string caption, int amount, int actType, string body)
        {
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000.");
            if (actType != 0 && actType != 1)
                throw new ArgumentException("ActType must be 0 or 1.");

            string connectionstring = dbHelper.Getconnectionstring();
            string dbCommandstring = @"INSERT INTO [Accouting]
                                                  ([UserID], [Caption], [Amount],
                                                   [ActType], [CreateDate], [Body])
                                       VALUES     (@userid, @caption, @amount,
                                                   @actType, @date, @body)";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(dbCommandstring, connection))
                {
                    command.Parameters.AddWithValue("@userid", userid);
                    command.Parameters.AddWithValue("@caption", caption);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@actType", actType);
                    command.Parameters.AddWithValue("@date", DateTime.Today);
                    command.Parameters.AddWithValue("@body", body);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Logger.Writelog(ex);
                    }
                }
            }
        }
        public static bool UpdateAccounting(int id, string userid, string caption, int amount, int actType, string body)
        {
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000.");
            if (!(actType == 0 || actType == 1))
                throw new ArgumentException("ActType must be 0 or 1.");

            string connectionstring = dbHelper.Getconnectionstring();
            string dbCommandstring = @"UPDATE [Accouting]
                                       SET    [UserID] = @userid,
                                              [Caption] = @caption,
                                              [Amount] = @amount,
                                              [ActType] = @actType,
                                              [CreateDate] = @date, 
                                              [Body] = @body
                                       WHERE  [ID] = @id";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(dbCommandstring, connection))
                {
                    command.Parameters.AddWithValue("@userid", userid);
                    command.Parameters.AddWithValue("@caption", caption);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@actType", actType);
                    command.Parameters.AddWithValue("@date", DateTime.Today);
                    command.Parameters.AddWithValue("@body", body);
                    command.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();
                        int effectRows = command.ExecuteNonQuery();

                        if (effectRows == 1)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        Logger.Writelog(ex);
                        return false;
                    }
                }
            }
        }
        public static DataRow GetAccounting(int id, string userid)
        {
            string connectionstring = dbHelper.Getconnectionstring();
            string dbCommandstring = @"SELECT [ID], [Caption], [Amount],
                                              [ActType], [CreateDate], [Body]
                                       FROM   [Accouting]
                                       WHERE  [ID] = @id AND [UserID] = @userid";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(dbCommandstring, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@userid", userid);

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
                        return null;
                    }
                }

            }
        }
        public static void DeleteAccounting(int id)
        {
            string connectionstring = dbHelper.Getconnectionstring();
            string dbCommandstring = @"DELETE [Accouting]
                                       WHERE  [ID] = @id";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(dbCommandstring, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();
                        command.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        Logger.Writelog(ex);
                    }
                }

            }
        }
    }
}
