using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodHiding
{
   class Base
   {
      public void MyMethod()
      {
         Console.WriteLine("Base.MyMethod");
      }
   }

   class Derived : Base
   {
      public new void MyMethod()
      {
         Console.WriteLine("Derived.MyMethod");
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         Base baseobj = new Base();
         baseobj.MyMethod();

         Derived derivedObj = new Derived();
         derivedObj.MyMethod();

         // Base.MyMethod와 Derived.MyMethod이 나타날 시 Base.MyMethod 출력
         // 다형성이 부족
         Base baseOrDerived = new Derived();
         baseOrDerived.MyMethod();
      }
   }
}
