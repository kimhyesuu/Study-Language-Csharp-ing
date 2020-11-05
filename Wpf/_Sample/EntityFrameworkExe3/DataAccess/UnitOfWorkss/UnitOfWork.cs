using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbContexts;
using DataAccess.Models;
using DataAccess.Repogitory;

namespace DataAccess.UnitOfWorkss
{
   public class UnitOfWork : IUnitOfWork
   {
      private ERPRepogitary<DAccountInfo> _accounts;
      private ERPRepogitary<DProductInfo> _products;
      private ERPRepogitary<DOrder> _orders;

      private ERPDemoEntities _eRPDemoEntities;

      public UnitOfWork()
      {
         _eRPDemoEntities = new ERPDemoEntities();
      }

      public IRepogitory<DAccountInfo> Accounts
      {
         get => _accounts ?? (_accounts = new ERPRepogitary<DAccountInfo>(_eRPDemoEntities));
      }

      public IRepogitory<DProductInfo> Products
      {
         get => _products ?? (_products = new ERPRepogitary<DProductInfo>(_eRPDemoEntities));
      }

      public IRepogitory<DOrder> Orders
      {
         get => _orders ?? (_orders = new ERPRepogitary<DOrder>(_eRPDemoEntities));
      }

      public void Save()
      {
         try
         {
            _eRPDemoEntities.SaveChanges();
         }
         catch (Exception e)
         {
            Console.WriteLine(e.InnerException.Message);
         }
        
      }
   }
}
