using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
   //System.Exception 클래스는 모든 예외의 조상
   // 1. ArgumentNullException
   // 2. IndexOutOfRangeException
   // 3. 
   class Program
   {
      static void Main(string[] args)
      {
        
         Console.ReadKey();
      }

      private static void IndexExceptionEx()
      {
         int[] array = new[] { 1, 2, 3 };
         int index = 4;
         int value = array[index >= 0 && index < 3 ? index : throw new IndexOutOfRangeException()];
      }

      private static void ExpressionException()
      {
         int? a = null;
         int b = a ?? throw new ArgumentNullException();
      }

      private static void MultiFunctionException()
      {
         int arg = 9;
         try
         {
            DoSomething(1);
            DoSomething(2);
            DoSomething(3);
            DoSomething(4);
            DoSomething(13);
            DoSomething(14);
         }
         catch (Exception e)
         {
            Console.WriteLine(e.Message);
         }
      }

      private static void FunctionException()
      {
         int arg = 9;
         try
         {
            DoSomething(arg);
         }
         catch (Exception e)
         {
            Console.WriteLine(e.Message);
         }
      }

      private static void DoSomething(int arg)
      {
         if (arg < 10)
            Console.WriteLine(arg);
         else
            throw new Exception("arg가 10보다 큽니다.");
      }

      private static void ThrowExe1()
      {
         try
         {
            throw new Exception("예외를 던집니다.");
         }
         catch (Exception e)
         {
            Console.WriteLine(e.Message);
         }
      }

      private static void Ex1()
      {
         int[] arr = { 1, 2, 3 };

         try
         {
            for (int i = 0; i < 5; i++)
            {
               Console.WriteLine(arr[i]);
            }

         }
         //IndexOutOfRangeException의 조상은 Exception이기때문에 다 받을 수 있음
         //Exception은 모든 예외를 받는 것이 아니기때문에 방심은 금물
         catch (Exception e)
         {
            Console.WriteLine(e.Message);
         }
      }
   }
}
