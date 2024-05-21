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
using Microsoft.Data.SqlClient;

namespace HowrashokDescktop.ViewModel
{
    internal class MaterialViewModel : INotifyPropertyChanged
    {
        private Product product;
        public List<AddEditMaterialClass> Materials { get; set; }
        public MaterialViewModel(int productId)
        {
            this.product = DB.context.Products.FirstOrDefault(c => c.Id == productId);
            product.Materials = DB.context.Materials.Where(c => c.Ids.FirstOrDefault(c => c.Id == productId).Id == productId).ToList();
            Load();
            BackButtonCommand = new RelayCommand(_ => BackButtonClick());
        }

        private void Load()
        {
            Materials = new();
            foreach (var material in DB.context.Materials)
            {
                bool t = product.Materials.FirstOrDefault(c => c.Id == material.Id) != null;
                Materials.Add(new() { Name =  material.Name, Has = t });
            }
            OnPropertyChanged(nameof(Materials));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand BackButtonCommand { get; }

        private void BackButtonClick()
        {
            string sqlExpressionClient = "exec ClearProductMaterial @id = " + product.Id;
            using (SqlConnection connection = new SqlConnection(GlobalClass.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpressionClient, connection);
                int result = command.ExecuteNonQuery();
            }
            foreach (var material in Materials)
            {
                if (material.Has)
                {
                    product.Materials.Add(DB.context.Materials.FirstOrDefault(c => c.Name == material.Name));
                }
                else
                {
                    product.Materials.Remove(DB.context.Materials.FirstOrDefault(c => c.Name == material.Name));
                }
            }
            try
            {
                DB.context.Products.Update(product);
                DB.context.SaveChanges();
            }
            catch(Exception ex) 
            {

            }
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainViewModel;
            mainWindowViewModel.CurrentPage = new AddEditProductView(product);
        }
    }
}