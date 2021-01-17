using System;
using System.Threading;

namespace Thread_Exe
{
   public class Program
   {
      static void Func()
      {
         Console.WriteLine("스레드에서 호출");
      }

      static void ParameterizedFunc2(object obj)
      {
         var intData = (int)obj;
         for(int i = 0; i < intData; i++)
         {
            Console.WriteLine($"parameterized 스레드에서 호출 : {i}");
            Thread.Sleep(1000);
         }
      }

      static void Main(string[] args)
      {
         // var thread = new Thread(new ThreadStart(Func));
         // ThreadStart thStart = new ThreadStart(Func);
         // Thread thread = new Thread(thStart);

         // 1회만 호출
         // thread.Start();

         int number = 5;
         var thread2 =
            new Thread(new ParameterizedThreadStart(ParameterizedFunc2));

         thread2.Start(number);

         Console.ReadKey();
      }
   }
}
