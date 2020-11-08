using System;
using System.ServiceModel;

namespace HostWCFTCP.Contracts
{
   [ServiceContract]
   public interface IService1
   {
      [OperationContract]
      void PostStockDetils(Stock stock);
   }

   public class Stock
   {
      public DateTime TimeSent { get; set; }
      public string Name { get; set; }
      public double Price { get; set; }
      public string City { get; set; }
   }
}
