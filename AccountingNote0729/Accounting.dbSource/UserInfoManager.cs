using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using AccountingNoteORM.DBModels;

namespace Accounting.dbSource
{
    public class UserInfoManager
    {
        public static UserInfo GetUserInfoListbyAccount_ORM(string account)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query = (from item in context.UserInfo
                                 where item.Account == account
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
    }
}
