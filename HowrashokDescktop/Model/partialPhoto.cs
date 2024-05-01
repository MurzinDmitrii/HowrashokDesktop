using HowrashokDescktop.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowrashokDescktop.Model
{
    partial class Photo
    {
        public string Path
        {
            get
            {
                string photopath = GlobalClass.Photopath;
                return photopath + Photopath;
            }
        }
    }
}
