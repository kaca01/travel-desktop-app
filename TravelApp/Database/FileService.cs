using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TravelApp.Database
{
    class FileService
    {
        public static void Serialize<T>(string _filename, List<T> items)
        {
            using (StreamWriter writer = new StreamWriter(_filename))
            {
                writer.Write(JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented));
            }
        }
        public static List<T> Deserialize<T>(string _filename)
        {
            using (StreamReader reader = new StreamReader(_filename))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }
    }
}
