namespace ChatApp.Service
{
   using System;
   using System.Collections.Generic;
   using System.Collections.ObjectModel;
   using System.Linq;
   using System.ServiceModel;
   using ChatApp.Contracts;
   using ChatApp.Contracts.Domain;

   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
   public class MessageService : IMessageService
   {
      private IMessageCallBack _callBack;
      private ObservableCollection<User> _users;
      private Dictionary<string, IMessageCallBack> _client;
      // ReadOnlyDictionary를 먼저 사용함

      public MessageService()
      {
         _callBack = null;
         _users = new ObservableCollection<User>();
         _client = new Dictionary<string, IMessageCallBack>();
      }

      public void Connect(User user)
      {
         _callBack = OperationContext.Current.GetCallbackChannel<IMessageCallBack>();
         if(_callBack != null)
         {
            _client.Add(user.UserId, _callBack);
            _users.Add(user);
            _client?.ToList().ForEach(c=>c.Value.UserConnected(_users));
            Console.WriteLine($"{user.Name} just Connected");
         }
      }

      public ObservableCollection<User> GetConnectUser()
      {
         return _users;
      }

      public void SendMessage(Message message)
      {
         var sendTo = _client?.First(c => c.Key == message.ToUserId).Value;
         if(sendTo != null)
         {
            sendTo.ForwardToClient(message);
         }
      }
   }
}
