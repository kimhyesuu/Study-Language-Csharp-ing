using System.ServiceModel;
using TcpBinding.Contract;

namespace TcpBinding.Server
{
   [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
   public class ProductService : IService1
   {
      public string[] Getstrings()
      {
         return new []{ "server1", "Server2", "server3" };
      }
   }
}
