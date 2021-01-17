using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Exe05
{
   class Program
   {
      static void Func()
      {
         for(int i = 0; i < 30; i++ )
         {
            Console.WriteLine($"{i}");
            Thread.Sleep(200);
         }
      }

      static void Main(string[] args)
      {
         var thread = new Thread(new ThreadStart(Func));
         thread.Start();


         // 이를 사용하면 대기하도록 만들구나
         thread.Join();

         Console.WriteLine("Main 종료");
      }
   }
}
