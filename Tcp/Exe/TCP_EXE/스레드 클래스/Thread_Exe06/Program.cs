using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Exe06
{
   class Program
   {
      static void Main(string[] args)
      {
         var thread = new Thread(new ThreadStart(ThreadProc1));
         thread.Start();

         Console.WriteLine($"Main : {Thread.CurrentThread.GetHashCode()}");
         Console.WriteLine("Main 종료");
      }

      private static void ThreadProc1()
      {
         Console.WriteLine($"ThreadProc1 스레드 {Thread.CurrentThread.GetHashCode()}");
         
         //스레드 안에 스레드 
         // 스레드는 독립적
         var thread = new Thread(new ThreadStart(ThreadProc2));
         thread.Start();

         for (int i = 0; i < 10; i++)
         {
            Console.WriteLine($"ThreadProc1 : {i}");
            Thread.Sleep(1000);

            if(i >= 3)
            {
               Console.WriteLine("ThreadProc1 종료");
               Thread.CurrentThread.Abort();
            }
         }
      }

      private static void ThreadProc2()
      {
         Console.WriteLine($"ThreadProc2 스레드 {Thread.CurrentThread.GetHashCode()}");

         for (int i = 0; i < 10; i++)
         {
            Console.WriteLine($"ThreadProc2 : {i}");
            Thread.Sleep(1000);
         }
      }
   }
}
