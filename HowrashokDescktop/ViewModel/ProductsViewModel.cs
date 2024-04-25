using HowrashokDescktop.Classes;
using HowrashokDescktop.Model;
using HowrashokDescktop.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace HowrashokDescktop.ViewModel
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        public List<Product> ProductsList { get; set; }
        public ProductsViewModel()
        {
            Load();
            AddButtonCommand = new RelayCommand(_ => AddButtonClick());
        }

        private void Load()
        {
            ProductsList = DB.context.Products.ToList();
            foreach (var product in ProductsList)
            {
                product.Costs = DB.context.Costs.Where(c => c.ProductId == product.Id).ToList();
                product.Photos = DB.context.Photos.Where(c => c.ProductId == product.Id).ToList();
                product.Category = DB.context.Categories.FirstOrDefault(c => c.Id == product.CategoryId);
            }
            OnPropertyChanged("ProductsList");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand AddButtonCommand { get; }

        private void AddButtonClick()
        {
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainViewModel;
            mainWindowViewModel.CurrentPage = new AddEditProductView(null);
        }
    }
}
