using HostWCFTCP.Contracts;
using System;
using System.ServiceModel;

namespace HostWCFTCP.Server
{
   [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
   public class StockService : IService1
   {
      public void PostStockDetils(Stock stock)
      {
         Console.ForegroundColor = (ConsoleColor)new Random().Next(10);
         Console.WriteLine($"Received <----------- {stock.City} \t {stock.TimeSent.ToString("F").Split(',')[0]} {stock.TimeSent:T}  {stock.Name} {stock.Price}");
      }
   }
}
