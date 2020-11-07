using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
   public class DogRepogitory : IDogRepogitory
   {
      public void Delete(Dog dog)
      {
         using (LUCYEntities db = new LUCYEntities())
         {
            db.Dog.Attach(dog);
            db.Dog.Remove(dog);
            db.SaveChanges();
         }
      }
      //이제 해보자 

      public List<Dog> GetAll()
      {
         using (LUCYEntities db = new LUCYEntities())
         {
            return db.Dog.ToList();
         }
      }

      public Dog GetById(int id)
      {
         using (LUCYEntities db = new LUCYEntities())
         {
            return db.Dog.Find(id);
         }
      }

      public Dog Insert(Dog dog)
      {
         using (LUCYEntities db = new LUCYEntities())
         {
            db.Dog.Add(dog);
            db.SaveChanges();
            return dog;
         }
      }

      public void Update(Dog dog)
      {
         using (LUCYEntities db = new LUCYEntities())
         {
            db.Dog.Attach(dog);
            db.Entry(dog).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
         }
      }

    
   }
}
