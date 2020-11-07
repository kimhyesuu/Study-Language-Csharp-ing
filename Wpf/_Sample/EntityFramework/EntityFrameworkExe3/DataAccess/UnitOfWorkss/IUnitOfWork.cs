using DataAccess.Models;
using DataAccess.Repogitory;

namespace DataAccess.UnitOfWorkss
{
   public interface IUnitOfWork
   {
      IRepogitory<DAccountInfo> Accounts { get; }

      IRepogitory<DProductInfo> Products { get; }

      IRepogitory<DOrder> Orders { get; }

      void Save();
   }
}
