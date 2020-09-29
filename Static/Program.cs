using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. Static으로 정의한 필드는 프로그램 전체에 하나밖에 없다.
//2. 정적메소드 반대 즉, 비정적 메서드는 동적 메서드가 아니라 인스턴스 메서드입니다.
//3. 
namespace Static
{
   //인스턴스에 소속된 필드의 경우
   class MyClass
   {
      public int a;
      public int b;
   }

   //클래스에 소속된 필드의 경우
   class MyClassStatic
   {
      public static int a;
      public static int b;
   }

   class Program
   {
      static void Main(string[] args)
      {
         MyClass obj = new MyClass();
         obj.a = 1;
         obj.b = 1;

         MyClassStatic.a = 3;
         MyClassStatic.a = 4;
      }
   }
}
