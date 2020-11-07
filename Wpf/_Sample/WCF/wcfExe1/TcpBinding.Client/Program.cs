using System;
using System.Linq;
using System.ServiceModel;
using TcpBinding.Contract;
//https://www.youtube.com/watch?v=StvQQCY_LNE
namespace TcpBinding.Client
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Press any key to enter");
         Console.ReadKey();
         var uri = "net.tcp://localhost:8733/ProductService";
         NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
         var channel = new ChannelFactory<IService1>(binding);
         var endPoint = new EndpointAddress(uri);
         var proxy = channel.CreateChannel(endPoint);
         proxy?.Getstrings().ToList().ForEach(p => Console.WriteLine(p));
         Console.ReadLine();
      }

   }
}
