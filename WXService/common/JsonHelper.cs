using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace WXService.common
{
    public class JsonHelper
    {
        public static List<T> JsonStringToList<T>(string jsonStr)
        {
            var serializer = new JavaScriptSerializer();
            var objs = serializer.Deserialize<List<T>>(jsonStr);
            return objs;
        }
        public static string Serialize(object o)
        {
            var sb = new StringBuilder();
            var json = new JavaScriptSerializer();
            json.Serialize(o, sb);
            return sb.ToString();
        }
        public static T Deserialize<T>(string json)
        {
            var obj = Activator.CreateInstance<T>();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }

        public static string ConvertJobjecToString(Newtonsoft.Json.Linq.JToken j)
        {
            string result = j == null ? string.Empty : j.ToString();
            return result;
        }
    }
}