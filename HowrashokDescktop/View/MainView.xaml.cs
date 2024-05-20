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
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        private MainViewViewModel MainViewViewModel { get; set; }
        public MainView()
        {
            InitializeComponent();
            MainViewViewModel = new();
            this.DataContext = MainViewViewModel;
        }

        private void StatisticText_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainViewModel;
            mainWindowViewModel.CurrentPage = new CommentsView();
        }

        private void SectionBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainViewViewModel != null)
            {
                MainViewViewModel.Load(SectionBox.SelectedIndex);
            }
        }
    }
}
