using ChatApp.Contracts.Domain;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace ChatApp.Contracts
{
   [ServiceContract(CallbackContract = typeof(IMessageCallBack),SessionMode = SessionMode.Required)]
   public interface IMessageService
   {
      [OperationContract(IsOneWay = true)]
      void Connect(User value);

      [OperationContract(IsOneWay = true)]
      void SendMessage(Message message);

      [OperationContract(IsOneWay = false)]
      ObservableCollection<User> GetConnectUser();
   }

}
