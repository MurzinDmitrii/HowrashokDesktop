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
    /// Логика взаимодействия для AddEditProductView.xaml
    /// </summary>
    public partial class AddEditProductView : Page
    {
        private AddEditProductViewModel AddEditProductViewModel { get; set; }
        public AddEditProductView(Product? product)
        {
            InitializeComponent();
            if(product == null)
            {
                product = new();
            }
            AddEditProductViewModel = new AddEditProductViewModel(product);
            this.DataContext = AddEditProductViewModel;
        }

        private void CostBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(Convert.ToChar(e.Text)) && e.Text != ",")
            {
                e.Handled = true;
            }
        }
    }
}
