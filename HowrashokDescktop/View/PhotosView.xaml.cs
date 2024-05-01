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
    /// Логика взаимодействия для PhotosView.xaml
    /// </summary>
    public partial class PhotosView : Page
    {
        private PhotosViewModel PhotosViewModel { get; set; }
        public PhotosView(int id)
        {
            InitializeComponent();
            this.PhotosViewModel = new PhotosViewModel(id);
            this.DataContext = this.PhotosViewModel;
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            var photo = item.DataContext as Photo;
            PhotosViewModel.DeletePhoto(photo);
        }
    }
}
