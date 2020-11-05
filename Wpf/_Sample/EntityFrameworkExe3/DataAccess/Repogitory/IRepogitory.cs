using System.Collections.Generic;

namespace DataAccess.Repogitory
{
   public interface IRepogitory<TEntity>
   {
      IEnumerable<TEntity> GetAll();
      TEntity GetById(object id);
      TEntity Insert(TEntity parameter);
      void Update(TEntity parameter);
      void Delete(TEntity parameter);
   }
}
