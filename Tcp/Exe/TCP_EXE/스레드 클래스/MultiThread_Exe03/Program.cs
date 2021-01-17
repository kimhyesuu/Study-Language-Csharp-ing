using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread_Exe03
{
   class Program
   {
      static void Func1()
      {
         for (int i = 0; i < 10; i++)
         {
            Console.WriteLine($"Func1 스레드에서 호출 : {i} : {DateTime.Now.Second}");
            Thread.Sleep(2000);
         }
      }

      static void Func2()
      {
         for (int i = 0; i < 10; i++)
         {
            Console.WriteLine($"Func2 스레드에서 호출 : {i} : {DateTime.Now.Second}");
            Thread.Sleep(1000);
         }
      }

      static void Main(string[] args)
      {
         var thread1 = new Thread(new ThreadStart(Func1));
         var thread2 = new Thread(new ThreadStart(Func2));

         thread1.Start();
         thread2.Start();

         thread1.Join();
         thread2.Join();


         Console.WriteLine("메인 스레드 종료");
         Console.ReadKey();
      }
   }
}
