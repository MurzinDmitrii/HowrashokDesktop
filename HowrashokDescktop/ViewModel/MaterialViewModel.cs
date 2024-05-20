using HowrashokDescktop.Classes;
using HowrashokDescktop.Model;
using HowrashokDescktop.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HowrashokDescktop.ViewModel
{
    internal class MaterialViewModel : INotifyPropertyChanged
    {
        private int productId;
        public MaterialViewModel(int productId)
        {
            this.productId = productId;
            Load();
            BackButtonCommand = new RelayCommand(_ => BackButtonClick());
        }

        private void Load()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand BackButtonCommand { get; }

        private void BackButtonClick()
        {
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainViewModel;
            mainWindowViewModel.CurrentPage = new AddEditProductView(DB.context.Products.FirstOrDefault(c => c.Id == productId));
        }
    }
}