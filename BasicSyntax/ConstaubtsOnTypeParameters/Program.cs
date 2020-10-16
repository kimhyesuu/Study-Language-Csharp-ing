using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstaubtsOnTypeParameters
{
   class StructArray<T> where T:struct
   {
      public T[] Array { get; set; }
      public StructArray(int size)
      {
         Array = new T[size];
      }
   }

   class RefArray<T> where T:class
   {
      public T[] Array { get; set; }
      public RefArray(int size)
      {
         Array = new T[size];
      }
   }

   class Base { }
   class Derived : Base { }
   class BaseArray<U> where U : Base
   {
      public U[] Array { get; set; }
      public BaseArray(int size)
      {
         Array = new U[size];
      }

      public void CopyArray<T>(T[] Source) where T : U
      {
         Source.CopyTo(Array , 0);
      }
   }

   class Program
   {

      public static T CreateInstance<T>() where T : new()
      {
         return new T();
      }

      static void Main(string[] args)
      {
         StructArray<int> a = new StructArray<int>(3);
         for (int i = 0; i < 3; i++)
            a.Array[i] = i;

         //이해가 안댐
         RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
         for (int i = 0; i < 3; i++)
         {
            b.Array[i] = new StructArray<double>(i);
         }

         BaseArray<Base> c = new BaseArray<Base>(3);
         c.Array[0] = new Base();
         c.Array[1] = new Derived();
         c.Array[2] = CreateInstance<Base>();

         BaseArray<Derived> d = new BaseArray<Derived>(3);
         d.Array[0] = new Derived();
         d.Array[1] = CreateInstance<Derived>();
         d.Array[2] = CreateInstance<Derived>();


         for(int i = 0; i < 3; i++)
         {
            Console.Write(a.Array[i] + " ");
         }
         Console.WriteLine();
         for (int i = 0; i < 3; i++)
         {
            Console.Write(b.Array[i] + " ");
         }
         Console.WriteLine();
         for (int i = 0; i < 3; i++)
         {
            Console.Write(c.Array[i] + " ");
         }
         Console.WriteLine();
         for (int i = 0; i < 3; i++)
         {
            Console.Write(d);
         }
         Console.WriteLine();
      }
   }
}
