using HowrashokDescktop.Classes;
using HowrashokDescktop.Model;
using HowrashokDescktop.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HowrashokDescktop.ViewModel
{
    public class PhotosViewModel : INotifyPropertyChanged
    {
        public List<Photo> PhotosList { get; set; }
        private int productId;
        public PhotosViewModel(int productId)
        {
            this.productId = productId;
            Load();
            AddButtonCommand = new RelayCommand(_ => AddButtonClick());
            BackButtonCommand = new RelayCommand(_ => BackButtonClick());
        }

        private void Load()
        {
            PhotosList = DB.context.Photos.Where(c => c.ProductId == productId).ToList();
            OnPropertyChanged(nameof(PhotosList));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand AddButtonCommand { get; }
        public ICommand BackButtonCommand { get; }

        private void AddButtonClick()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                bool? t = openFileDialog.ShowDialog();
                if (t == true)
                {
                    Photo photo = new()
                    {
                        ProductId = productId,
                        Photopath = System.IO.Path.GetFileName(openFileDialog.FileName)
                    };
                    DB.context.Photos.Add(photo);
                    DB.context.SaveChanges();
                    try
                    {
                        File.Copy(openFileDialog.FileName, WorkWithJson.LoadJson().Photopath + System.IO.Path.GetFileName(openFileDialog.FileName));
                    }
                    catch
                    {

                    }
                    Load();
                }
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("The database operation was expected to affect 1 row(s)"))
                {
                    var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainViewModel;
                    mainWindowViewModel.CurrentPage = new ProductsView();
                }
                else
                {
                    MessageBox.Show("Выберите корректное изображение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void DeletePhoto(Photo photo)
        {
            if (MessageBox.Show("Удалить?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DB.context.Photos.Remove(photo);
                    DB.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("The database operation was expected to affect 1 row(s)"))
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("Выберите корректное изображение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            Load();
        }

        private void BackButtonClick()
        {
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainViewModel;
            mainWindowViewModel.CurrentPage = new AddEditProductView(DB.context.Products.FirstOrDefault(c => c.Id == productId));
        }
    }
}
