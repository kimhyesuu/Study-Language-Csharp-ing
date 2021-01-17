using System;
using System.Threading;

namespace MultiThread_Exe
{
   class Program
   {
      static void Func()
      {
         Console.WriteLine("스레드1 호출");
      }

      static void Func2()
      {
         Console.WriteLine("스레드2 호출");
      }

      static void Main(string[] args)
      {
         // 순차적으로 출력되지 않고 다르게 나옴
         var thread1 = new Thread(new ThreadStart(Func));
         var thread2 = new Thread(new ThreadStart(Func2));

         thread1.Start();
         thread2.Start();

         Console.WriteLine("성공");
         Console.ReadKey();
      }
   }
}
