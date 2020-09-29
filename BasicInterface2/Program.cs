using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 인터페이스를 상속하는 인터페이스
// 두 가지 종류
// 1. 상속하려는 인터페이스가 소스 코드가 아닌 어셈블리만 제공되는 경우
// 2. 상속하려는 인터페이스의 소스코드를 갖고 있어도 이미 인터페이스를 상속하는 클래스들이 존재할 경우 
namespace BasicInterface2
{
   interface ILogger
   {
      void WriteLog(string message);
   }

   interface IFormattableLogger : ILogger
   {
      void WriteLog(string format, params object[] args);
   }

   class ConsoleLogger2 : IFormattableLogger
   {
      public void WriteLog(string message)
      {
         Console.WriteLine("{0} {1}",DateTime.Now.ToLocalTime(), message);
      }

      public void WriteLog(string format, params object[] args)
      {
         //string.format에는 {0} + {1} = {2} 이부분을 해석하고 args의 value를 받아드린다.
         string message = String.Format(format,args);
         Console.WriteLine("{0} {1}",DateTime.Now.ToLocalTime(),message);
      }
   }


   class Program
   {
      static void Main(string[] args)
      {
         IFormattableLogger logger = new ConsoleLogger2();
         logger.WriteLog("The world is not flat.");
         logger.WriteLog("{0}+{1} ={2}",1,2,3);

      }
   }
}
