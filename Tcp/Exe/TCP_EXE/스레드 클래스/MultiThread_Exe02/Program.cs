using System;
using System.Threading;

namespace MultiThread_Exe02
{
   class Test
   {
      public void Print(object number)
      {
         Console.WriteLine($"Test Class{number}");
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         int number = 5;
         var test1 = new Test();
         var test2 = new Test();

         var thread1 = new Thread(new ParameterizedThreadStart(test1.Print));
         var thread2 = new Thread(new ParameterizedThreadStart(test2.Print));

         thread1.Start(number);
         number++;
         thread2.Start(number);

         Console.ReadKey();

      }
   }
}
