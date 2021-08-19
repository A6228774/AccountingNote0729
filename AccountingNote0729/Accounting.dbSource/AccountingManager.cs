using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AccountingNoteORM.DBModels;

namespace Accounting.dbSource
{
    public class AccountingManager
    {
        public static DataTable GetAccountingList(string userid)
        {
            string connectionstring = dbHelper.Getconnectionstring();
            string dbCommandstring = @"SELECT [ID], [Caption], [Amount],
                                              [ActType], [CreateDate]
                                       FROM   [AccountingNote]
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
        public static List<AccountingNote> GetAccountingList(Guid userid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.AccountingNote
                                 where item.UserID == userid
                                 select item);

                    var list = query.ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.Writelog(ex);
                    return null;
                }
            }
        }
        public static void CreateAccounting(string userid, string caption, int amount, int actType, string body)
        {
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000.");
            if (actType != 0 && actType != 1)
                throw new ArgumentException("ActType must be 0 or 1.");

            string bodyColumnSQL = "";
            string bodyValueSQL = "";

            if (!string.IsNullOrWhiteSpace(body))
            {
                bodyColumnSQL = ", Body";
                bodyValueSQL = ", @Body";
            }

            string connectionstring = dbHelper.Getconnectionstring();
            string dbCommandstring = $@"INSERT INTO [AccountingNote]
                                                  ([UserID], [Caption], [Amount],
                                                   [ActType], [CreateDate], {bodyColumnSQL})
                                       VALUES     (@userid, @caption, @amount,
                                                   @actType, @date, {bodyValueSQL})";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userid", userid));
            list.Add(new SqlParameter("@caption", caption));
            list.Add(new SqlParameter("@amount", amount));
            list.Add(new SqlParameter("@actType", actType));
            list.Add(new SqlParameter("@date", DateTime.Today));

            if (!string.IsNullOrWhiteSpace(body))
                list.Add(new SqlParameter("@body", body));

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
        public static void CreateAccounting(AccountingNote accounting)
        {
            if (accounting.Amount < 0 || accounting.Amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000.");
            if (accounting.ActType != 0 && accounting.ActType != 1)
                throw new ArgumentException("ActType must be 0 or 1.");

            try
            {
                using (ContextModel context = new ContextModel())
                {
                    accounting.CreateDate = DateTime.Now;
                    context.AccountingNote.Add(accounting);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Writelog(ex);
            }
        }
        public static bool UpdateAccounting(int id, string userid, string caption, int amount, int actType, string body)
        {
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000.");
            if (!(actType == 0 || actType == 1))
                throw new ArgumentException("ActType must be 0 or 1.");

            string connectionstring = dbHelper.Getconnectionstring();
            string dbCommandstring = @"UPDATE [AccountingNote]
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
        public static bool UpdateAccounting(AccountingNote accounting)
        {
            if (accounting.Amount < 0 || accounting.Amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000.");
            if (!(accounting.ActType == 0 || accounting.ActType == 1))
                throw new ArgumentException("ActType must be 0 or 1.");

            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var obj = context.AccountingNote.Where(o => o.ID == accounting.ID).FirstOrDefault();

                    if (obj != null)
                    {
                        obj.Caption = accounting.Caption;
                        obj.Amount = accounting.Amount;
                        obj.Body = accounting.Body;
                        obj.ActType = accounting.ActType;

                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Writelog(ex);
                return false;
            }
        }
        public static AccountingNote GetAccounting(int id, Guid userid)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query = (from item in context.AccountingNote
                                 where item.UserID == userid && item.ID == id
                                 select item);

                    var obj = query.FirstOrDefault();
                    return obj;
                }
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
            string dbCommandstring = @"DELETE [AccountingNote]
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
        public static void DeleteAccounting_ORM(int id)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var obj = context.AccountingNote.Where(o => o.ID == id).FirstOrDefault();

                    if (obj != null)
                    {
                        context.AccountingNote.Remove(obj);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Writelog(ex);
            }
        }

    }
}
