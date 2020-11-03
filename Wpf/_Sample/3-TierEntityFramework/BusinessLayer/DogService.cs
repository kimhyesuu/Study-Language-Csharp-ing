using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public static class DogService
   {
      static IDogRepogitory _dogRepogitory;

      static DogService()
      {
         _dogRepogitory = new DogRepogitory();
      }

      public static List<Dog> GetAll()
      {
         return _dogRepogitory.GetAll();
      }

      public static Dog GetById(int id)
      {
         return _dogRepogitory.GetById(id);
      }

      public static Dog Insert(Dog dog)
      {
         return _dogRepogitory.Insert(dog);
      }

      public static void Update(Dog dog)
      {
         _dogRepogitory.Update(dog);
      }

      public static void Delete(Dog dog)
      {
         _dogRepogitory.Delete(dog);
      }
   }
}
