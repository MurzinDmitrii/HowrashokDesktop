using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace HowrashokDescktop.Classes
{
    /// <summary>
    /// Класс для реализации автозагрузки приложения
    /// </summary>
    internal class AutorunClass
    {
        public static bool Autorun(bool autorun, string path)
        {
            const string name = "run";
            string exePath = path;
            exePath = exePath.Replace(".dll", ".exe");
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            try
            {
                if (autorun)
                {
                    reg.SetValue(name, exePath);
                }
                else
                {
                    reg.DeleteValue(name);
                    reg.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;

        }
    }
}
