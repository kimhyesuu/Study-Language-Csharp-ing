using HostWCFTCP.Contracts;
using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading;
//https://www.youtube.com/watch?v=L80PJtmECvs
namespace HostWCFTCP.Client
{
   class Program
   {
      static void Main(string[] args)
      {
         int i = 0;

         var location = new[] { "Korea", "Korea", "Korea", "Korea", "Korea" 
                               ,"Korea" ,"Korea" ,"Korea" ,"Korea" ,"Korea" };
         if(Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Count() <= 2)
         {
            Process.Start("HostWCFTCP.Client.exe");
         }

         i = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Count();

         string loc = location[i];

         new Program().DisplayStockDetails(loc);

      }

      private void DisplayStockDetails(string loc)
      {
         Console.WriteLine("PressKey");
         Console.ReadLine();
         var uri = "net.tcp://localhost:8733/StockService";
         var bindin = new NetTcpBinding(SecurityMode.None);
         var channel = new ChannelFactory<IService1>(bindin);
         var endPoint = new EndpointAddress(uri);
         var proxy = channel.CreateChannel(endPoint);

         if(proxy != null )
         {
            Timer tim = new Timer(obj => 
            {
               var stock = GetStock(loc);
               Console.ForegroundColor = (ConsoleColor)new Random().Next(10);
               Console.WriteLine($"Sending ====> {loc} {stock.TimeSent:T} {stock.Name} {stock.Price:C}");
               proxy.PostStockDetils(stock);
            }, null, TimeSpan.FromSeconds(0.54), TimeSpan.FromSeconds(0.54));
         }

         Console.ReadLine();
      }

      private Stock GetStock(string loc)
      {
         var rnd = new Random();
         var stock = new Stock()
         {
            TimeSent = DateTime.UtcNow,
            Name = GetStockName(),
            Price = rnd.Next(13, 120) + rnd.NextDouble(),
            City = loc
         };

         return stock;
      }

      private string GetStockName()
      {
         char[] stp = "ABCDEFGHIJKLMNOPQRSTFSUFSD".ToCharArray();
         string name = string.Empty;
         var rn = new Random();

         for(int i = 0; i < 4; i ++)
         {
            //stp.Length  
            name += stp.GetValue(rn.Next(1,26)-1);
         }

         return name;
      }
   }
}
