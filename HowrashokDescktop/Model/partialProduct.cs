﻿using HowrashokDescktop.Classes;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HowrashokDescktop.Model
{
    partial class Product
    {
        public string MainPhoto { 
            get {
                string photopath = WorkWithJson.LoadJson().Photopath;
                if (Photos.Count != 0)
             {
                 return photopath + Photos.FirstOrDefault().Photopath;
             }
             else
             {
                 return photopath + "no-image.jpg";
             }
            } 
        }

        public string MainCost
        {
            get
            {
                if(Costs.Count != 0)
                {
                    return Math.Round(Costs.OrderByDescending(c => c.DateOfSetting).FirstOrDefault().Size, 2).ToString() + "₽";
                }
                else
                {
                    return "Цена не назначена";
                }
            }
        }public string ArhiveColor
        {
            get
            {
                if (Arhived == true) return "#5893B9";
                else return "#C7E3F4";
            }
        }
    }
}
