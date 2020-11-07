using System.ServiceModel;

namespace TcpBinding.Contract
{
   [ServiceContract]
   public interface IService1
   {
      [OperationContract]
      string[] Getstrings();
   }  
}
