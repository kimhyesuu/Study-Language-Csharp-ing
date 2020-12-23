using System;
using System.Threading;

namespace Creating_and_Starting_Threads
{
   class SideTask
   {
      int _count;

      public SideTask(int count)
      {
         this._count = count;
      }

      public void KeepAlive()
      {
         try
         {
            while(_count > 0)
            {
               Console.WriteLine($"count : {_count--} left");
               Thread.Sleep(10);
            }

            Console.WriteLine("count : 0");
         }
         catch(ThreadAbortException e)
         {
            Console.WriteLine(e);
            Thread.ResetAbort();
         }
         finally
         {
            Console.WriteLine("Clearing resource..");
         }
      }
   }

   public class counter
   {
      public int count = 0;
      private readonly object thislock = new object();

      public void Increase()
      {
         // lock 키워드와 중괄호로 둘러싼 이 부분은 크리티컬 섹션이 됩니다. 한 스레드가 이코드를 실행하다가 
         // lock 블록이 끝나는 괄호를 만나기 전까지 다른 스레드는 이 영역을 침범할 수 없음 
         lock (thislock)
         {
            count = count + 1;
         }
      }
   }

   class Program
   {

      static void Main(string[] args)
      {
         var count = new counter();

         var t1 = new Thread(new ThreadStart(count.Increase));
         var t2 = new Thread(new ThreadStart(count.Increase));
         var t3 = new Thread(new ThreadStart(count.Increase));


         t1.Start();
         t2.Start();
         t3.Start();

         t1.Join();
         t2.Join();
         t3.Join();

         Console.WriteLine(count.count);

         Console.ReadKey();
      }

     

      #region 이거이 c#이다 Sample code
      private static void SampleStartJoin()
      {
         var worker = new Thread(new ThreadStart(Dosomthing));

         Console.WriteLine("Starting Threading..");
         // worker 스레드가 실행되어 메인 스레드에서 분기됩니다.
         worker.Start();

         for (int i = 0; i < 20; i++)
         {
            Console.WriteLine($"Main : {i}");
            Thread.Sleep(1000);
         }

         Console.WriteLine("Waiting until thread stops...");
         // 스레드가 완전히 정지할 때까지 대기합니다, join 메소드가 반환되고 프로그램의 흐름은 다시 메인 스레드 하나로 합쳐집
         worker.Join();

         Console.WriteLine("Finished");

         Console.ReadLine();
      }
      private static void ExternAbortExe()
      {
         var task = new SideTask(100);
         var worker = new Thread(new ThreadStart(task.KeepAlive));

         Console.WriteLine("Starting Thread");
         worker.Start();

         Thread.Sleep(500);

         Console.WriteLine("Abort");
         worker.Abort();

         Console.WriteLine("End Join");
         worker.Join();
      }
      private static void Dosomthing()
      {
         for(int i = 0; i < 20; i ++)
         {
            Console.WriteLine($"Dosomthing : {i}");
            Thread.Sleep(1000);
         }
      }
      #endregion


      public bool upper;

      private static void DelegateThread()
      {
         //Thread worker = new Thread(delegate () { Console.ReadLine(); });
         //if (args.Length > 0) worker.IsBackground = true;
         //worker.Start();
      }

      private static void LambdaThread()
      {
         Thread t = new Thread(delegate () { WriteText("Hello"); });
         //Thread t = new Thread(() => { WriteText("Hello"); });
         t.Start();
      }
      private static void WriteText(string text)
      {
         Console.WriteLine(text);
      }

      private static void ParameterizedThreadStartGOEXE()
      {
         //Thread t = new Thread(ParameterizedThreadStartGO);
         //t.Start(true); // == Go (true)
         //ParameterizedThreadStartGO(false);

         Thread t = new Thread(new ParameterizedThreadStart(ParameterizedThreadStartGO));
         t.Start(true);
      }

      private static void ParameterizedThreadStartGO(object upperCase)
      {
         bool upper = (bool)upperCase;
         Console.WriteLine(upper ? "HELLO!" : "hello!");
      }

      private static void ThreadStartExe()
      {
         Thread t = new Thread(new ThreadStart(Go));
         t.Start(); // Run Go() on the new thread.
         Go(); // Simultaneously run Go() in the main thread

      }

      public static void Go()
      {
         Console.WriteLine("Hello from " + Thread.CurrentThread.Name);
      }
   }
}
