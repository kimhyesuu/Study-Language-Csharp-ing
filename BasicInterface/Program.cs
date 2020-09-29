using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 인터페이스 선언이란
// 1. 클래스와 비슷해보이지만, 메서드, 이벤트, 인덱서, 프로퍼티만을 가질 수 있다는 차이점이 있음
// 2. 구현부가 없음
// 3. 접근 제한 한정자에서는 public만 사용이 가능
// 4. 인터페이스는 참조는 만들지 못하지만, 참조는 만들 수있음( 참조 : 파생클래스의 객체 위치를 담는 것) 
// 즉 인터페이스에 상속받은 클래스의 객체는 인터페이스의 객체로 취급 가능
// 5. 인터페이스 활용시 Naming 시 첫 글자를 I로 시작하는 관례가 있음
namespace BasicInterface
{
   interface ILogger
   {
       void WriteLog(string Message);
   }

   class ConsoleLogger : ILogger
   {
      public void WriteLog(string message)
      {
         Console.WriteLine("{0} {1}",DateTime.Now.ToLocalTime(), message);
      }
   }

   class FileLogger : ILogger
   {
      private StreamWriter writer;

      public FileLogger(string path)
      {
         writer = File.CreateText(path);
         writer.AutoFlush = true; //이해안댐
      }

      public void WriteLog(string message)
      {
         writer.WriteLine("{0} {1}", DateTime.Now.ToShortDateString(), message);
      }
   }

   class ClimateMonitor
   {
      private ILogger logger;

      public ClimateMonitor(ILogger logger)
      {
         this.logger = logger;
      }

      public void Start()
      {
         while(true)
         {
            Console.Write("온도를 입력해주세요. : ");
            string temp = Console.ReadLine();
            if (temp == "")
               break;

            logger.WriteLog("현재 온도 :" + temp);
         }
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         ClimateMonitor monitor = new ClimateMonitor(new FileLogger("MyLog.txt"));

         monitor.Start();
        
      }
   }
}
