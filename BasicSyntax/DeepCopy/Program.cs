using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopy
{
   class MyClass
   {
      public int MyField1;
      public int MyField2;

      // 객체를 힙에 새로 할당해서 그곳에 자신의 멤버를 일일이 복사해 넣습니다.
      public MyClass DeepCopy()
      {
         MyClass newCopy = new MyClass();
         newCopy.MyField1 = this.MyField1;
         newCopy.MyField2 = this.MyField2;

         return newCopy;
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Shallow Copy");

         {
            MyClass source = new MyClass();
            source.MyField1 = 10;
            source.MyField2 = 20;

            MyClass target = source;
            target.MyField2 = 30;

            Console.WriteLine($"{source.MyField1} {source.MyField2}");
            Console.WriteLine($"{target.MyField1} {target.MyField2}");
         }

         Console.WriteLine("Deep Copy");

         {
            MyClass source = new MyClass();
            source.MyField1 = 10;
            source.MyField2 = 20;

            MyClass target = source.DeepCopy();
            target.MyField2 = 30;

            Console.WriteLine($"{source.MyField1} {source.MyField2}");
            Console.WriteLine($"{target.MyField1} {target.MyField2}");
         }
      }
   }
}
