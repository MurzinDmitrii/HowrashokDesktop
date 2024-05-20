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
    /// Логика взаимодействия для ProductsView.xaml
    /// </summary>
    public partial class ProductsView : Page
    {
        private ProductsViewModel ProductsViewModel { get; set; }
        public ProductsView()
        {
            InitializeComponent();
            ProductsViewModel = new();
        }

        private void DiscountItem_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            var product = item.DataContext as Product;
            Discount discount = new()
            {
                DateOfSetting = DateTime.Now,
                During = 7,
                Size = 10,
                ProductId = product.Id,
                Product = product
            };
            DB.context.Discounts.Add(discount);
            DB.context.SaveChanges();
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            var product = item.DataContext as Product;
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainViewModel;
            mainWindowViewModel.CurrentPage = new AddEditProductView(product);
        }
    }
}
