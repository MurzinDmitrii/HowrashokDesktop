using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowrashokDescktop.Model
{
    partial class Comment
    {
        public string Who
        {
            get
            {
                Client client = DB.context.Clients.FirstOrDefault(c => c.Id == ClientId);
                string who = client.Email + "(" + client.FirstName + " " + client.LastName[0] + ".)";
                return who;
            }
        }
    }
}
