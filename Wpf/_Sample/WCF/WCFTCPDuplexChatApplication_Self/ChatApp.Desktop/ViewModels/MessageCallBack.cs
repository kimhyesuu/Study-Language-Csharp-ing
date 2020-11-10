using System.Collections.ObjectModel;
using ChatApp.Contracts;
using ChatApp.Contracts.Domain;

namespace ChatApp.Desktop.ViewModels
{
   //콜백은 client에서 받는 것이다.
   public class MessageCallBack : IMessageCallBack
   {
      public void ForwardToClient(Message message)
      {
         
      }

      public void UserConnected(ObservableCollection<User> users)
      {
         
      }
   }
}
