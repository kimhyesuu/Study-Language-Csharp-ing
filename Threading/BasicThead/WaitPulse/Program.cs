using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaitPulse
{
   class Counter
   {
      const int LOOP_COUNT = 1000;

      readonly object thislock;
      bool lockedCount = false;

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
               while (_count > 0 || lockedCount)
                  Monitor.Wait(thislock);

               lockedCount = true;
               _count++;
               lockedCount = false;

               Monitor.Pulse(thislock);
            }
         }
      }

      public void Decrease()
      {
         int loopCount = LOOP_COUNT;

         while (loopCount-- > 0)
         {
            while (_count < 0 || lockedCount)
               Monitor.Wait(thislock);

            lockedCount = true;
            _count--;
            lockedCount = false;

            Monitor.Pulse(thislock);
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
