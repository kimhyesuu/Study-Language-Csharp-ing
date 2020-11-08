using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Contracts.Domain
{
   public class User
   {
      public User()
      {
         //모름
         UserId = Guid.NewGuid().ToString().Split('-')[4];
      }

      public string UserId  { get; set; }
      public string Name { get; set; }
      public DateTime TimeCreated { get; set; }

      public ObservableCollection<Message> UserMessages { get; set; }
   }
}
