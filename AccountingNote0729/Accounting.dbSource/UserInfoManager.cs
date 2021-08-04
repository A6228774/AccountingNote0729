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
        public static DataRow GetUserInfoListbyAccount(string account)
        {
            string connectionstring = dbHelper.Getconnectionstring();
            string dbCommandstring = @"SELECT [ID], [Account], [PWD],
                                              [Name], [Email]
                                       FROM   [UserInfo]
                                       WHERE  [Account] = @account";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));

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
    }
}
