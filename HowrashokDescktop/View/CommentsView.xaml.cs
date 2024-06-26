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
    /// Логика взаимодействия для CommentsView.xaml
    /// </summary>
    public partial class CommentsView : Page
    {
        private CommentsViewModel CommentsViewModel { get; set; }
        public CommentsView()
        {
            InitializeComponent();
            this.CommentsViewModel = new();
            this.DataContext = CommentsViewModel;
        }

        private void FilledComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommentsViewModel.Load(FilledComboBox.SelectedIndex);
        }
    }
}
