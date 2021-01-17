using System;
using System.Threading;

namespace Thread_Exe03
{
   class Program
   {
      static void Func()
      {
         int i = 0;

         for( ; true ;  )
         {
            Console.WriteLine($"Sub : {i++}");
            Thread.Sleep(300); //  0.3초
         }
      }

      static void Main(string[] args)
      {
         Thread thread = new Thread(new ThreadStart(Func));
         thread.IsBackground = true;
         thread.Start();

         // 이 방식은 foreground 스레드 형식
         //Thread thread = new Thread(new ThreadStart(Func));
         //thread.Start();

         for(int i = 0; i < 10; i++)
         {
            Console.WriteLine($"Main : {i}");
            Thread.Sleep(300);
         }

         Console.WriteLine("Main 종료");
      }
   }
}
