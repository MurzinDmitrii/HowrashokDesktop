﻿using HowrashokDescktop.ViewModel;
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
    /// Логика взаимодействия для MaterialView.xaml
    /// </summary>
    public partial class MaterialView : Page
    {
        private MaterialViewModel MaterialViewModel { get; set; }
        public MaterialView(int id)
        {
            InitializeComponent();
            this.MaterialViewModel = new MaterialViewModel(id);
            this.DataContext = this.MaterialViewModel;
        }
    }
}
