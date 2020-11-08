using ChatApp.Contracts;
using System;
using System.ServiceModel;

namespace ChatApp.Service
{
   class Program
   {
      static void Main(string[] args)
      {
         var uris = new Uri[1];
         string addr = "net.tcp://localhost:8733/MessageService";
         uris[0] = new Uri(addr);

         IMessageService service = new MessageService();
         ServiceHost serviceHost = new ServiceHost(service, uris);

         var binding = new NetTcpBinding(SecurityMode.None);
         serviceHost.AddServiceEndpoint(typeof(IMessageService), binding, string.Empty);
         serviceHost.Opened += ServiceHost_Opened;
         serviceHost.Open();
         Console.ReadLine();
      }

      private static void ServiceHost_Opened(object sender, EventArgs e)
      {
         Console.WriteLine("Service Opened");
      }
   }
}
