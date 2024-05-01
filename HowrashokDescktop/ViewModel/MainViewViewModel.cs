using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Definitions.Series;
using HowrashokDescktop.Model;
using System.Windows.Input;
using HowrashokDescktop.Classes;
using HowrashokDescktop.View;
using System.Windows;

namespace HowrashokDescktop.ViewModel
{
    public class MainViewViewModel
    {
        public SeriesCollection AroundChartData { get; set; }
        public SeriesCollection StatisticCharData { get; set; }
        public MainViewViewModel()
        {
            AroundChartData = new();
            StatisticCharData = new();
            using (HowrashokShopContext context = new())
            {
                for (int i = 1; i <= 5; i++)
                {
                    AroundChartData.Add(new PieSeries
                    {
                        Values = new ChartValues<int> { context.Comments.Count(c => c.Mark == i) },
                        Title = i.ToString(),
                    });
                }
                foreach(var item in context.Categories.ToList())
                {
                    LineSeries series = new();
                    series.Title = item.Name;
                    series.Values = new ChartValues<double>();
                    for (int i = -3; i <= 0; i++)
                    {
                        series.Values.Add(Convert.ToDouble(context.TableParts.Where(d => d.Product.CategoryId == item.Id).Count(c => c.Order.DateOrder.Month == DateTime.Now.AddMonths(i).Month)));
                    }
                    StatisticCharData.Add(series);
                }
            }
        }
    }
}
