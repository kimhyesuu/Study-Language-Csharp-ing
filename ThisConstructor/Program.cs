using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisConstructor
{
   class MyClass
   {
      int a, b, c;

      public MyClass()
      {
         this.a = 5425;
         Console.WriteLine("MyClass()");
      }

      public MyClass(int b) : this()
      {
         this.b = 5425;
         Console.WriteLine($"MyClass({b})");
      }

      public MyClass(int b, int c) : this(b)
      {
         this.c = 5425;
         Console.WriteLine($"MyClass({b},{c})");
      }

      public void PrintFields()
      {
         Console.WriteLine($"a:{a}, b:{b}, c:{c}");
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         MyClass a = new MyClass();
         a.PrintFields();

         MyClass b = new MyClass(1);
         b.PrintFields();

         MyClass c = new MyClass(10,20);
         c.PrintFields();
      }
   }
}
