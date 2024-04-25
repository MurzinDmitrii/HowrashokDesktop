using HowrashokDescktop.Classes;
using HowrashokDescktop.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HowrashokDescktop.ViewModel
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public MainViewModel()
        {
            MainButtonColor = mainColor;
            ProductButtonColor = additionalColor;
            OrderButtonColor = additionalColor;

            MainButtonCommand = new RelayCommand(_ => MainButtonClick());
            ProductButtonCommand = new RelayCommand(_ => ProductButtonClick());
            OrderButtonCommand = new RelayCommand(_ => OrderButtonClick());

            CurrentPage = new MainView();
        }

        public ICommand MainButtonCommand { get; }
        public ICommand ProductButtonCommand { get; }
        public ICommand OrderButtonCommand { get; }

        private void MainButtonClick()
        {
            MainButtonColor = mainColor;
            ProductButtonColor = additionalColor;
            OrderButtonColor = additionalColor;
            CurrentPage = new MainView();
        }

        private void ProductButtonClick()
        {
            MainButtonColor = additionalColor;
            ProductButtonColor = mainColor;
            OrderButtonColor = additionalColor;
            CurrentPage = new ProductsView();
        }

        private void OrderButtonClick()
        {
            MainButtonColor = additionalColor;
            ProductButtonColor = additionalColor;
            OrderButtonColor = mainColor;
            CurrentPage = new OrdersView();
        }

        private Page _currentPage;
        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public void SetCurrentPage(Page page)
        {
            CurrentPage = page;
        }

        private string mainColor = "#DEEFFA";
        private string additionalColor = "#5893B9";
        private string _mainButtonColor;
        private string _productButtonColor;
        private string _orderButtonColor;

        public string MainButtonColor
        {
            get { return _mainButtonColor; }
            set
            {
                _mainButtonColor = value;
                OnPropertyChanged("MainButtonColor");
            }
        }

        public string ProductButtonColor
        {
            get { return _productButtonColor; }
            set
            {
                _productButtonColor = value;
                OnPropertyChanged("ProductButtonColor");
            }
        }

        public string OrderButtonColor
        {
            get { return _orderButtonColor; }
            set
            {
                _orderButtonColor = value;
                OnPropertyChanged("OrderButtonColor");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
