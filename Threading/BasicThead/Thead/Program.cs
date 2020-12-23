using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
   class Program
   {
      static bool done;


      static void Main(string[] args)
      {
        
         Console.ReadKey();
      }

      private static void Go2()
      {
         lock (locker)
         {
            if (!done) { Console.WriteLine("Done"); done = true; }
         }
      }

      private static void GO()
      {
         for (int cycles = 0; cycles < 5; cycles++) Console.Write('?');
      }

      static void BasicThread()
      {
         int cntX = 0;
         Thread t = new Thread(WriteY);

         t.Start();

         while (true)
         {
            Console.Write("X");
            if (cntX > 5)
            {
               break;
            }

            cntX++;

         }

         Console.Read();
      }

      static void WriteY()
      {
         int cntY = 0;

         while (true)
         {
            Console.Write("Y");
            if (cntY > 5)
            {
               break;
            }

            cntY++;
         }
      }
   }
}
