using HowrashokDescktop.Classes;
using HowrashokDescktop.View;
using HowrashokDescktop.ViewModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HowrashokDescktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool realExit = false;
        private MainViewModel MainViewModel { get; set; }
        public MainWindow()
        {
            AutorunClass.Autorun(true, Assembly.GetExecutingAssembly().Location);
            WrapClass.Wrap(this);
            Closing += OnWindowClosing;
            InitializeComponent();
            GlobalClass.Photopath = "C:\\Users\\Dmitrii\\Desktop\\Проекты\\HowrashokShop\\HowrashokShop\\wwwroot\\Images\\";
            GlobalClass.ConnectionString = "Data Source=127.0.0.1,1433;User=Dmitrii;Password=Dima005dimon;Initial Catalog=HowrashokShop; TrustServerCertificate=True";
            MainViewModel = new();
            TimerClass timerClass = new TimerClass();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Minimized:
                    WrapClass.Wrap(this);
                    break;
            }
        }

        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            WrapClass.Unwrap(this);
            this.WindowState = WindowState.Normal;
        }

        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!realExit)
            {
                e.Cancel = true;
                WrapClass.Wrap(this);
            }
        }

        private void TreyBar_Click(object sender, RoutedEventArgs e)
        {
            realExit = true;
            this.Close();
        }
    }
}