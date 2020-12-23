using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flags
{
   class Program
   {
      static void PrintThreadState(ThreadState threadState)
      {
         Console.WriteLine("{0,-16} : {1}", threadState, (int)threadState);
      }

      static void Main(string[] args)
      {
         PrintThreadState(ThreadState.Initialized);
         PrintThreadState(ThreadState.Ready);
         PrintThreadState(ThreadState.Running);
         PrintThreadState(ThreadState.Standby);
         PrintThreadState(ThreadState.Terminated);
         PrintThreadState(ThreadState.Transition);
         PrintThreadState(ThreadState.Unknown);
         PrintThreadState(ThreadState.Wait);

         Console.ReadKey();
      }
   }
}
