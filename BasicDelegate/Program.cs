using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//델리게이트는 인스턴스가 아니라 형식type입니다.
namespace BasicDelegate
{
   class Program
   {
      delegate int MyDelegate(int a, int b);

      class Calculator
      {
         public int Plus(int a, int b)
         {
            return a + b;
         }

         public static int Minus(int a, int b)
         {
            return a - b;
         }
      }

      static void Main(string[] args)
      {
         Calculator calc = new Calculator();
         MyDelegate Callback;

         Callback = new MyDelegate(calc.Plus);
         Console.WriteLine(Callback(3,4));
      }
   }
}
