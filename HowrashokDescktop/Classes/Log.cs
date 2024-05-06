using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowrashokDescktop.Classes
{
    /// <summary>
    /// Класс для логирования
    /// </summary>
    public class Log
    {
        private static object sync = new object();
        /// <summary>
        /// Для логирования ошибок
        /// </summary>
        /// <param name="ex">Ошибка</param>
        public static void Write(Exception ex)
        {
            try
            {
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog);
                string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
                AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
                string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] [{1}.{2}()] {3} {4}\r\n",
                DateTime.Now, ex.TargetSite.DeclaringType, ex.TargetSite.Name, ex.Message, ex.InnerException);
                lock (sync)
                {
                    File.AppendAllText(filename, fullText, Encoding.GetEncoding("UTF-8"));
                }
            }
            catch
            {
                
            }
        }

        public static void Write(string ex)
        {
            try
            {
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog);
                string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
                AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
                string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}]{1}\r\n",
                DateTime.Now, ex);
                lock (sync)
                {
                    File.AppendAllText(filename, fullText, Encoding.GetEncoding("UTF-8"));
                }
            }
            catch
            {

            }
        }

        public static void DeleteLog()
        {
            string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
            AppDomain.CurrentDomain.FriendlyName, DateTime.Now.AddDays(-7)));
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            string a = ""; 
        }
    }
}
