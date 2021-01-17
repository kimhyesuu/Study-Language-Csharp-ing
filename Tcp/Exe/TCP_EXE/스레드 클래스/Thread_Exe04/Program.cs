using System;
using System.Threading;

namespace Thread_Exe04
{
   class Program
   {
      static void ThreadProc()
      {
         Console.WriteLine($"스레드 id : {Thread.CurrentThread.GetHashCode()}");
      }

      static void Main(string[] args)
      {
         Thread thread1 = new Thread(new ThreadStart(ThreadProc));
         Thread thread2 = new Thread(new ThreadStart(ThreadProc));


         thread1.Start();
         thread2.Start();

         // 하나의 스레드가 끝날 때까지 기다리는 것
         thread1.Join();
         thread2.Join();

         Console.WriteLine($"Main 스레드 id : {Thread.CurrentThread.GetHashCode()}");
         Console.ReadKey();
      }
   }
}
