using HowrashokDescktop.Classes;
using HowrashokDescktop.Model;
using HowrashokDescktop.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HowrashokDescktop.ViewModel
{
    public class AddEditOrdersViewModel : INotifyPropertyChanged
    {
        public Order Order { get; set; }
        public List<Product> ProductsList {  get; set; } 
        public List<Status> StatusList { get; set; }
        public AddEditOrdersViewModel(Order order)
        {
            StatusList = DB.context.Statuses.ToList();
            CheckButtonCommand = new RelayCommand(_ => CheckButtonClick());
            BackButtonCommand = new RelayCommand(_ => BackButtonClick());
            Order = order;
            ProductsList = new();
            foreach(var item in order.TableParts)
            {
                ProductsList.Add(item.Product);
            }
            OnPropertyChanged("ProductsList");
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CheckButtonCommand { get; }
        public ICommand BackButtonCommand { get; }

        private void CheckButtonClick()
        {
            var url = "https://yoomoney.ru/self-employed/receipts";
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });

        }
        private void BackButtonClick()
        {
            try
            {
                DB.context.Orders.Update(Order);
                DB.context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainViewModel;
            mainWindowViewModel.CurrentPage = new OrdersView();
        }
    }
}
