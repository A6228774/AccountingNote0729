using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WebApplication0809
{
    public class WeatherDataReader
    {
        public static WeatherDataModel ReadData()
        {
            string url = "https://opendata.cwb.gov.tw/fileapi/v1/opendataapi/F-B0053-037?Authorization=CWB-261FD690-AAE0-478A-969B-B2E1D5ACD451&downloadType=WEB&format=JSON";

            WebClient client = new WebClient();
            byte[] scourcebyte = client.DownloadData(url);
            string jsontxt = Encoding.UTF8.GetString(scourcebyte);

            Rootobject obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(jsontxt);

            var locationList = obj.cwbopendata.dataset.locations.location;
            var retObject = new WeatherDataModel();
            retObject.Name = "太魯閣國家公園太魯閣遊客中心";

            foreach (var item in locationList)
            {
                if (string.Compare("太魯閣國家公園太魯閣遊客中心", item.locationName, true) == 0)
                {
                    foreach (var weatherItem in item.weatherElement)
                    {
                        if (weatherItem.elementName == "T")
                        {
                            var eleVal = weatherItem.time[0].elementValue;
                            var tJsontxt = Newtonsoft.Json.JsonConvert.SerializeObject(eleVal);
                            MeasureObject measure = Newtonsoft.Json.JsonConvert.DeserializeObject<MeasureObject>(tJsontxt);

                            retObject.T = Convert.ToInt32(measure.value);
                        }
                        if (weatherItem.elementName == "PoP24h")
                        {
                            var eleVal = weatherItem.time[0].elementValue;
                            var tJsontxt = Newtonsoft.Json.JsonConvert.SerializeObject(eleVal);
                            MeasureObject measure = Newtonsoft.Json.JsonConvert.DeserializeObject<MeasureObject>(tJsontxt);

                            retObject.Pop = Convert.ToInt32(measure.value);
                        }
                    }
                }
            }
            return retObject;
        }
        public class MeasureObject
        {
            public string value { get; set; }
            public string measure { get; set; }
        }
        public class Rootobject
        {
            public Cwbopendata cwbopendata { get; set; }
        }

        public class Cwbopendata
        {
            public string xmlns { get; set; }
            public string identifier { get; set; }
            public string sender { get; set; }
            public DateTime sent { get; set; }
            public string status { get; set; }
            public string scope { get; set; }
            public string msgType { get; set; }
            public string dataid { get; set; }
            public string source { get; set; }
            public Dataset dataset { get; set; }
        }

        public class Dataset
        {
            public Datasetinfo datasetInfo { get; set; }
            public Locations locations { get; set; }
        }

        public class Datasetinfo
        {
            public string datasetDescription { get; set; }
            public string datasetLanguage { get; set; }
            public DateTime issueTime { get; set; }
            public Validtime validTime { get; set; }
            public DateTime update { get; set; }
        }

        public class Validtime
        {
            public DateTime startTime { get; set; }
            public DateTime endTime { get; set; }
        }

        public class Locations
        {
            public string[] locationsName { get; set; }
            public Location[] location { get; set; }
        }

        public class Location
        {
            public string locationName { get; set; }
            public string geocode { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }
            public Parameterset parameterSet { get; set; }
            public Weatherelement[] weatherElement { get; set; }
        }

        public class Parameterset
        {
            public Parameter parameter { get; set; }
        }

        public class Parameter
        {
            public string parameterName { get; set; }
            public string parameterValue { get; set; }
        }

        public class Weatherelement
        {
            public string elementName { get; set; }
            public string description { get; set; }
            public Time[] time { get; set; }
        }

        public class Time
        {
            public DateTime startTime { get; set; }
            public DateTime endTime { get; set; }
            public object elementValue { get; set; }
        }
    }
}
