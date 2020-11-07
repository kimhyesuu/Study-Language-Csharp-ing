using System;
using System.ServiceModel;
using TcpBinding.Contract;

namespace TcpBinding.Server
{
   class Program
   {
      static void Main(string[] args)
      {
         var uris = new Uri[1];
         string addr = "net.tcp://localhost:8733/ProductService";
         uris[0] = new Uri(addr);

         IService1 service = new ProductService();
         ServiceHost serviceHost = new ServiceHost(service, uris);

         var binding = new NetTcpBinding(SecurityMode.None);
         serviceHost.AddServiceEndpoint(typeof(IService1), binding, "");
         serviceHost.Opened += ServiceHost_Opened;
         serviceHost.Open();
         Console.ReadKey();
      }

      private static void ServiceHost_Opened(object sender, EventArgs e)
      {
         Console.WriteLine("wcf service is started");
      }
   }
}
