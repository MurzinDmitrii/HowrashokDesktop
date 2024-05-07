using HowrashokDescktop.Model;
using HowrashokDescktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HowrashokDescktop.View
{
    /// <summary>
    /// Логика взаимодействия для OrdersView.xaml
    /// </summary>
    public partial class OrdersView : Page
    {
        private OrdersViewModel OrdersViewModel { get; set; }
        public OrdersView()
        {
            InitializeComponent();
            this.OrdersViewModel = new();
            this.DataContext = OrdersViewModel;
            FilterComboBox.SelectedIndex = 4;
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrdersViewModel.Load(FilterComboBox.SelectedItem as Status);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var item = (MenuItem)sender;
            var order = (Order)item.DataContext;
            var orderTrue = DB.context.Orders.FirstOrDefault(c => c.Id == order.Id);
            orderTrue.TableParts = DB.context.TableParts.Where(c => c.OrderId == order.Id).ToList();
            OrdersViewModel.MenuClick(orderTrue);
        }
    }
}
