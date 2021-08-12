using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace tryWebAPI0811
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherDataReader.ReadData();

            Console.ReadLine();
        }
        #region Temp
        public class temp
        {
            public bool success { get; set; }
            public temp2 result { get; set; }
        }
        public class temp2
        {
            public string resource_id { get; set; }
            public List<temp3> records { get; set; }
        }
        public class temp3
        {
            public string 年度 { get; set; }
        }
        #endregion
        public class Rootobject
        {
            public bool success { get; set; }
            public Result result { get; set; }
        }

        public class Result
        {
            public string resource_id { get; set; }
            public Record[] records { get; set; }
        }

        public class Record
        {
            public string 年度 { get; set; }
            public string 平均年齡男 { get; set; }
            public string 平均年齡女 { get; set; }
        }

    }
}
