using DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

//anys 사용방법 배우기 
namespace DataAccess.Repogitory
{
   public class ERPRepogitary<TEntity> : IRepogitory<TEntity> where TEntity : class
   {
      private ERPDemoEntities _context;
      //private DbSet<TEntity> _table;

      public ERPRepogitary(ERPDemoEntities context)
      {
         this._context = context;
        // _table = _context.Set<TEntity>();
      }

      public IEnumerable<TEntity> GetAll()
      {
         try
         {
            var list = _context.Set<TEntity>().Select(a=>a).ToList();
          
            return list;
         }
         catch (Exception e)
         {
            Console.WriteLine(e.InnerException.Message);
            return null;
         }
      }

      public TEntity GetById(object id)
      {
         return _context.Set<TEntity>().Find(id);
      }

      public TEntity Insert(TEntity parameter)
      {
         //여기서 savechange때 안받아짐 
         try
         {
            var para = _context.Set<TEntity>().Add(parameter);
            //_context.SaveChanges();
            return para;

         }
         catch (DbUpdateException e)
         {
            Console.WriteLine(e.InnerException.Message);
            return null;
         }
      }

      public void Update(TEntity parameter)
      {
         _context.Set<TEntity>().Attach(parameter);
         _context.Entry(parameter).State = EntityState.Modified;
        // _context.SaveChanges();
      }

      public void Delete(TEntity parameter)
      {
         if (_context.Entry(parameter).State == EntityState.Detached)
         {
            _context.Set<TEntity>().Attach(parameter);
         }

         _context.Set<TEntity>().Remove(parameter);
         //_context.SaveChanges();
      }
   }
}
