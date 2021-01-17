using System;
using System.Threading;

namespace Thread_Exe02
{
   class Test
   {
      public void Print()
      {
         Console.WriteLine("Test Class");
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         var test = new Test();
         var thread = new Thread(new ThreadStart(test.Print));

         thread.Start();

         Console.ReadKey();

      }
   }
}
