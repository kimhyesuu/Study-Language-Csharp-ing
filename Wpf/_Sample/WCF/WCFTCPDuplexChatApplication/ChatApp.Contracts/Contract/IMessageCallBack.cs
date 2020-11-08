using ChatApp.Contracts.Domain;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace ChatApp.Contracts
{
   public interface IMessageCallBack
   {
      [OperationContract(IsOneWay = true)]
      void ForwardToClient(Message message);

      [OperationContract(IsOneWay = true)]
      void UserConnected(ObservableCollection<User> users);
   }

}
