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
            System.IO.File.AppendAllText("D:\\Practice\\Webform0729\\Log.log" ,msg);

            throw ex;
        }
    }
}
