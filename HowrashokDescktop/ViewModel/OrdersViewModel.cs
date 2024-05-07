using HowrashokDescktop.Model;
using HowrashokDescktop.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HowrashokDescktop.ViewModel
{
    public class OrdersViewModel : INotifyPropertyChanged
    {
        public List<Order> OrdersList { get; set; }
        public List<Status> StatusList { get; set; }
        public OrdersViewModel()
        {
            StatusList = DB.context.Statuses.ToList();
            StatusList.Add(new Status() { Name = "Все" });
            Load(null);
        }

        public void Load(Status? status)
        {
            var Orders = DB.context.Orders.Include(c => c.Client).ToList();
            if(status != null && status.Name != "Все")
            {
                Orders = Orders.Where(c => c.StatusId == status.Id).ToList();
            }
            OrdersList = Orders;
            OnPropertyChanged("OrdersList");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void MenuClick(Order order)
        {
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainViewModel;
            mainWindowViewModel.CurrentPage = new AddEditOrdersView(order);
        }
    }
}
