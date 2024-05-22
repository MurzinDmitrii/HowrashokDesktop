using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HowrashokDescktop.Classes
{
    public class WorkWithJson
    {
        public static object Properties { get; private set; }

        public static GlobalClass LoadJson()
        {
            try
            {
                using (StreamReader r = new StreamReader("Config.txt"))
                {
                    string json = r.ReadToEnd();
                    GlobalClass item = JsonConvert.DeserializeObject<GlobalClass>(json);
                    return item;
                }
            }
            catch (Exception ex)
            {
                return new();
            }
        }
    }
}
