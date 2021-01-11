namespace IPHostEntry_Exe
{
   using System;
   using System.Net;

   class Program
   {
      static void Main(string[] args)
      {
         //GetHostEntry로 ipaddress 찾고 hostInfo에 대입
         IPHostEntry hostInfo = Dns.GetHostEntry("www.naver.com");

         // 대입 값 출력
         foreach(var ip in hostInfo.AddressList)
         {
            Console.WriteLine($"{ip}");
         }

         // hostInfo
         Console.WriteLine($"{hostInfo.HostName}");

         Console.ReadKey();
      }
   }
}
