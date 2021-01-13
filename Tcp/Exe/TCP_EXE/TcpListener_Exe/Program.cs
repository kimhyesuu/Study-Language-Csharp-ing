namespace TcpListener_Exe
{
   using System;
   using System.Net;
   using System.Net.Sockets;

   class Program
   {
      static void Main(string[] args)
      {
         // 대표 로컬 호스트 : 127.0.0.1
         IPAddress ip = IPAddress.Parse("127.0.0.1");
         int port = 13;

         // set up
         TcpListener tcpListener = new TcpListener(ip, port);

         // LocalEndpoint 속성에 IPAddress : port 나타냄
         Console.WriteLine($"{tcpListener.LocalEndpoint.ToString()}");

         Console.ReadKey();

      }
   }
}
