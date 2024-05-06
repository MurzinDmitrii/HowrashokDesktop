using HowrashokDescktop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace HowrashokDescktop.Classes
{
    /// <summary>
    /// Класс для вызова метода PostData через определенные промежутки времени
    /// </summary>
    /// <see cref="M:Cifra.ApiHelper.ApiHelperClass.PostData()"/>
    internal class TimerClass
    {
        public TimerClass() 
        {
            try
            {
                System.Timers.Timer aTimer = new System.Timers.Timer(1000 * 60 * 15);
                aTimer.Elapsed += OnTimedEvent;
                aTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }


        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                using (var context = new HowrashokShopContext())
                {
                    var backupFileName = string.Format("C:/tmp/HowrashokShop[{0:dd.MM.yyy-HH:mm:ss.fff}].bak", DateTime.Now);
                    context.Database.ExecuteSqlRaw($"BACKUP DATABASE HowrashokShop TO DISK = '{backupFileName}'");
                }
            }
            catch(Exception ex)
            {
                Log.Write(ex);
            }
        }
    }
}
