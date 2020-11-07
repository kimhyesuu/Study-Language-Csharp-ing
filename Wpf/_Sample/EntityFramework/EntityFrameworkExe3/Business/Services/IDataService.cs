using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public interface IDataService<TEntity>
   {
      IEnumerable<TEntity> GetAll();
      TEntity Insert(TEntity parameter);
      void Update(TEntity parameter);
      void Delete(TEntity parameter);
   }
}
