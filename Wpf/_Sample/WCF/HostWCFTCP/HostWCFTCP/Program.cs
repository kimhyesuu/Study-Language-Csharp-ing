using HostWCFTCP.Contracts;
using System;
using System.ServiceModel;

namespace HostWCFTCP.Server
{
   class Program
   {
      static void Main(string[] args)
      {
         var uris = new Uri[1];
         string addr = "net.tcp://localhost:8733/StockService";
         uris[0] = new Uri(addr);
         IService1 service = new StockService();
         ServiceHost host = new ServiceHost(service , uris);
         var binding = new NetTcpBinding(SecurityMode.None);
         host.AddServiceEndpoint(typeof(IService1), binding, "");
         host.Opened += Host_Opened;

         try
         {
            host.Open();
            Console.ReadLine();
         }
         catch(Exception e)
         {
            Console.WriteLine(e.Message);
         }       
      }

      private static void Host_Opened(object sender, EventArgs e)
      {
         Console.WriteLine("Services up and running");
      }
   }
}
