using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 1. 추상 클래스는 인터페이스와는 달리 "구현"을 가질 수 있음
// 2. 클래스와는 달리 인스턴스를 가질 수 없음
// 3. 
namespace abstractInterfaceAndClass
{
   abstract class AbstractBase
   {
      protected void PrivateMethodA()
      {
         Console.WriteLine("AbstractBase.PrivateMethodA");
      }

      public void PublicMethodA()
      {
         Console.WriteLine("AbstractBase.PublicMethodA");
      }

      public abstract void AbstractMethodA();
   }

   class Derived : AbstractBase
   {
      public override void AbstractMethodA()
      {
         Console.WriteLine("Derived.AbstractMethodA()");
         PrivateMethodA();
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         // base obj는 derived 파생 클래스를 대입
         AbstractBase obj = new Derived();
         // obj 내 
         obj.AbstractMethodA();
         obj.PublicMethodA();

      }
   }
}
