using HowrashokDescktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowrashokDescktop.ViewModel
{
    public class CommentsViewModel : INotifyPropertyChanged
    {
        public List<Comment> Comments {  get; set; }
        public CommentsViewModel()
        {
            Load(0);
        }

        public void Load(int? item)
        {
            if(item > 0)
            {
                Comments = DB.context.Comments.Where(c => c.Mark == 6-item).ToList();
            }
            else
            {
                Comments = DB.context.Comments.ToList();
            }
            OnPropertyChanged(nameof(Comments));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
