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
using System.ComponentModel;

namespace HowrashokDescktop.ViewModel
{
    public class MainViewViewModel: INotifyPropertyChanged
    {
        public SeriesCollection AroundChartData { get; set; }
        public SeriesCollection StatisticCharData { get; set; }
        public MainViewViewModel()
        {
            Load(0);
        }
        public void Load(int? Selection)
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
                foreach (var item in context.Categories.ToList())
                {
                    LineSeries series = new();
                    series.Title = item.Name;
                    series.Values = new ChartValues<double>();
                    if (Selection == 0)
                    {
                        for (int i = -2; i <= 0; i++)
                        {
                            series.Values.Add(Convert.ToDouble(context.TableParts.Where(d => d.Product.CategoryId == item.Id).Count(c => c.Order.DateOrder.Month == DateTime.Now.AddMonths(i).Month)));
                        }
                    }
                    if (Selection == 1)
                    {
                        for (int i = -5; i <= 0; i++)
                        {
                            series.Values.Add(Convert.ToDouble(context.TableParts.Where(d => d.Product.CategoryId == item.Id).Count(c => c.Order.DateOrder.Month == DateTime.Now.AddMonths(i).Month)));
                        }
                    }
                    if (Selection == 2)
                    {
                        for (int i = -11; i <= 0; i++)
                        {
                            series.Values.Add(Convert.ToDouble(context.TableParts.Where(d => d.Product.CategoryId == item.Id).Count(c => c.Order.DateOrder.Month == DateTime.Now.AddMonths(i).Month)));
                        }
                    }
                    StatisticCharData.Add(series);
                }
            }
            OnPropertyChanged(nameof(StatisticCharData));
            OnPropertyChanged(nameof(AroundChartData));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
