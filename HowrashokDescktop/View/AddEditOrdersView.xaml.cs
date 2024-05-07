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
    /// Логика взаимодействия для AddEditOrdersView.xaml
    /// </summary>
    public partial class AddEditOrdersView : Page
    {
        private AddEditOrdersViewModel AddEditOrdersViewModel {  get; set; }
        public AddEditOrdersView(Order order)
        {
            InitializeComponent();
            this.AddEditOrdersViewModel = new(order);
            this.DataContext = this.AddEditOrdersViewModel;
        }
    }
}
