namespace TcpClient_Exe
{
   using System;
   using System.Net.Sockets;

   class Program
   {
      // client
      static void Main(string[] args)
      {
         int port = 8380;

         // TcpClient(string hostname, int port)
         TcpClient tcpClient = new TcpClient("192.168.219.120", port);

         // 연결되냐?
         if(tcpClient.Connected)
         {
            Console.WriteLine("서버 연결 성공");
         }
         else
         {
            Console.WriteLine("서버 연결 실패");
         }

         // 닫아줘라
         tcpClient.Close();
         Console.ReadKey();
      }
   }
}
