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
                        obj.CoverImage = accounting.CoverImage;

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
