namespace AcceptTcpClient_Exe
{
   using System;
   using System.Net;
   using System.Net.Sockets;

   class Program
   {
      //server
      static void Main(string[] args)
      {
         IPAddress iP = IPAddress.Parse("192.168.219.120");
         int port = 8380;

         // ip같은 경우 자동적으로 갖고 있기 떄문에 
         // 안 써줘도 무방
         TcpListener tcpListener = new TcpListener(iP, port);

         tcpListener.Start();

         Console.WriteLine("대기 상태 시작");

         // AcceptTcpClient : A System.Net.Sockets.TcpClient used to send and receive data.
         TcpClient tcpClient = tcpListener.AcceptTcpClient(); // -> 대기상태

         Console.WriteLine("대기 상태 종료");

         tcpListener.Stop();

         Console.ReadKey();
      }
   }
}
