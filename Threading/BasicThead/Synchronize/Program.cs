using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Synchronize
{
   class Counter
   {
      const int LOOP_COUNT = 1000;

      readonly object thislock;

      private int _count;
      public int Count { get => _count; }

      public Counter()
      {
         thislock = new object();
         _count = 0;
      }

      public void Increase()
      {
         int loopCount = LOOP_COUNT;

         while (loopCount-- > 0)
         {
            lock (thislock)
            {
               _count++;
            }

            Thread.Sleep(1);
         }
      }

      public void Decrease()
      {
         int loopCount = LOOP_COUNT;

         while (loopCount-- > 0)
         {

            // 크리티컬섹션이 없을 시 다르게 나오네 
            lock (thislock)
            {
               _count--;
            }

            Thread.Sleep(1);
         }
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         var counter = new Counter();

         var inc = new Thread(new ThreadStart(counter.Increase));
         var dec = new Thread(new ThreadStart(counter.Decrease));

         inc.Start();
         dec.Start();

         inc.Join();
         dec.Join();

         Console.WriteLine(counter.Count);
         Console.ReadKey();

      }
   }
}
