﻿using HowrashokDescktop.Classes;
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

namespace HowrashokDescktop.ViewModel
{
    public class AddEditProductViewModel: INotifyPropertyChanged
    {
        public Product Product { get; set; }
        public List<Category> CategoryList { get
            {
                return DB.context.Categories.ToList();
            } 
        }
        public List<Theme> ThemeList
        {
            get
            {
                return DB.context.Themes.ToList();
            }
        }
        public string CostSet { get; set; }
        public AddEditProductViewModel(Product? product)
        {
            this.Product = product;

            if(product.Photos == null)
                product.Photos = new List<Photo>();
            if(product.Costs == null)
                product.Costs = new List<Cost>();

            SaveButtonCommand = new RelayCommand(_ => SaveButtonClick());
            PhotoButtonCommand = new RelayCommand(_ => PhotoButtonClick());
            try
            {
                CostSet = Math.Round(DB.context.
                                    Costs.
                                    OrderByDescending(c => c.DateOfSetting).
                                    FirstOrDefault(c => c.ProductId == Product.Id).Size, 2).ToString();
            }
            catch
            {
                CostSet = Math.Round(0.00, 2).ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SaveButtonCommand { get; }
        public ICommand PhotoButtonCommand { get; }

        private void PhotoButtonClick()
        {
            SaveButtonClick();
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainViewModel;
            mainWindowViewModel.CurrentPage = new PhotosView(Product.Id);
        }

        private void SaveButtonClick()
        {
            try
            {
                if (Product.Id == 0)
                {
                    DB.context.Products.Add(Product);
                }
                else
                {
                    DB.context.Products.Update(Product);
                }
                DB.context.SaveChanges();
                try
                {
                    DB.context.Costs.Add(new Cost()
                    {
                        DateOfSetting = DateTime.Now,
                        Size = Convert.ToDecimal(CostSet),
                        ProductId = Product.Id
                    });
                }
                catch
                {
                    DB.context.Costs.Add(new Cost()
                    {
                        DateOfSetting = DateTime.Now,
                        Size = 100,
                        ProductId = Product.Id
                    });
                }
                DB.context.SaveChanges();
                var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainViewModel;
                mainWindowViewModel.CurrentPage = new ProductsView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Заполните поля корректно","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
