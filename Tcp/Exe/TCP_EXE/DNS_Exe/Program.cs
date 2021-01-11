namespace DNS_Exe
{
   using System;
   using System.Net;

   class Program
   {
      static void Main(string[] args)
      {
         // ip는 해킹 당 할 경우를 대비해서 
         // 지속적으로 ip가 변경된다.
         IPAddress[] ip = Dns.GetHostAddresses("www.naver.com");
         foreach (var hostIp in ip)
         {
            Console.WriteLine($"{hostIp}");
         }

         Console.ReadKey();
      }
   }
}
