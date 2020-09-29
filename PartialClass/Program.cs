using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 분할 클래스란 여러 번에 나눠서 구현하는 클래스
// 목적 : 클래스 구현시 길어지는 경우를 방지하고자 만들었음.
namespace PartialClass
{
   partial class MyClass
   {
      public void Method1()
      {
         Console.WriteLine("Method1");
      }

      public void Method2()
      {
         Console.WriteLine("Method2");
      }
   }

   partial class MyClass
   {
      public void Method3()
      {
         Console.WriteLine("Method3");
      }

      public void Method4()
      {
         Console.WriteLine("Method4");
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         MyClass obj = new MyClass();
         obj.Method1();
         obj.Method2();
         obj.Method3();
         obj.Method4();
      }
   }
}
