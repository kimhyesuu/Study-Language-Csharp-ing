using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace DataAccessLayer
{
   public interface IDogRepogitory
   {
      List<Dog> GetAll();
      Dog GetById(int id);
      Dog Insert(Dog dog);
      void Update(Dog dog);
      void Delete(Dog dog);
   }
}
