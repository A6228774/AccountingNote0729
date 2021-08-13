using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication0809
{
    /// <summary>
    /// WeatherDataHandler 的摘要描述
    /// </summary>
    public class WeatherDataHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string acc = context.Request.QueryString["account"];
            string pwd = context.Request.Form["password"];

            if (acc == "admin" && pwd == "12345678")
            {
                context.Response.ContentType = "application/json";

                WeatherDataModel model = WeatherDataReader.ReadData();
                model.Name += acc;

                string jsontxt = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                context.Response.Write(jsontxt);
            }
            else
            {
                context.Response.StatusCode = 401;
                context.Response.End();
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}