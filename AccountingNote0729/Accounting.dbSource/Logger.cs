using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.dbSource
{
    public class Logger
    {
        public static void Writelog (Exception ex)
        {
            string msg = DateTime.Now.ToString("G") + ex.ToString();
            string logpath = "D:\\Practice\\Webform0729\\Log.log";

            if (!System.IO.File.Exists(logpath))
                System.IO.File.Create(logpath);

            System.IO.File.AppendAllText(logpath ,msg);

            throw ex;
        }
    }
}
