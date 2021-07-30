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

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userid", userid));
            list.Add(new SqlParameter("@userid", userid));
            list.Add(new SqlParameter("@caption", caption));
            list.Add(new SqlParameter("@amount", amount));
            list.Add(new SqlParameter("@actType", actType));
            list.Add(new SqlParameter("@date", DateTime.Today));


            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(dbCommandstring, connection))
                {
                    try
                    {
                        dbHelper.CreateData(connectionstring, dbCommandstring, list);
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

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            list.Add(new SqlParameter("@userid", userid));
            list.Add(new SqlParameter("@caption", caption));
            list.Add(new SqlParameter("@amount", amount));
            list.Add(new SqlParameter("@actType", actType));
            list.Add(new SqlParameter("@date", DateTime.Today));
            list.Add(new SqlParameter("@body", body));
            
                    try
                    {
                        int effectRowsCnt = dbHelper.ModifyData(connectionstring, dbCommandstring, list);

                        if (effectRowsCnt == 1)
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
        public static DataRow GetAccounting(int id, string userid)
        {
            string connectionstring = dbHelper.Getconnectionstring();
            string dbCommandstring = @"SELECT [ID], [Caption], [Amount],
                                              [ActType], [CreateDate], [Body]
                                       FROM   [Accouting]
                                       WHERE  [ID] = @id AND [UserID] = @userid";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            list.Add(new SqlParameter("@userid", userid));

            try
            {
                return dbHelper.ReadDataRow(connectionstring, dbCommandstring, list);
            }
            catch (Exception ex)
            {
                Logger.Writelog(ex);
                return null;
            }
        }
        public static void DeleteAccounting(int id)
        {
            string connectionstring = dbHelper.Getconnectionstring();
            string dbCommandstring = @"DELETE [Accouting]
                                       WHERE  [ID] = @id";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));

            try
            {
                int effectRowsCnt = dbHelper.ModifyData(connectionstring, dbCommandstring, list);
            }
            catch (Exception ex)
            {
                Logger.Writelog(ex);
            }
        }
    }
}
