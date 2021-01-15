namespace IPEndPoint_Exe
{
   using System;
   using System.Net;

   class Program
   {
      public const string DefaultIp = "127.0.0.1"; 

      static void Main(string[] args)
      {
         // ip와 port 설정
         IPAddress ipInfo = IPAddress.Parse(DefaultIp);
         int Port = 13;

         // 목적지 설정
         IPEndPoint endPointInfo = new IPEndPoint(ipInfo, Port);

         // 분리되서 출력
         Console.WriteLine($"ip : {endPointInfo.Address} port : {endPointInfo.Port}");

         // 전체 출력
         Console.WriteLine($"{endPointInfo.ToString()}");

         Console.ReadKey();

      }
   }
}
