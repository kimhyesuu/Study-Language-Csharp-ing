namespace Server_Exe
{
   using System;
   using System.IO;
   using System.Net;
   using System.Net.Sockets;

   class Program
   {
      static void Main(string[] args)
      {
         // 현재 이 컴퓨터가 서버 역할을 하기 때문에 주소 안넣어도 댐
         IPAddress ip = IPAddress.Parse("192.168.219.105");
         int port = 8380;

         TcpListener tcpListener = new TcpListener(ip, port);
         tcpListener.Start(); 
         Console.WriteLine("서버");

         bool yes = false;
         int val1 = 12;
         float pi = 3.14f;
         string message = "Hello World";

         // 대기 상태에 있다가 연결 수락 요청을 받아들여지면,
         // NetworkStream으로 넘어가게 댐
         TcpClient tcpClient = tcpListener.AcceptTcpClient();
         NetworkStream ns = tcpClient.GetStream();

         using (BinaryWriter bw = new BinaryWriter(ns))
         {
            bw.Write(yes);
            bw.Write(val1);
            bw.Write(pi);
            bw.Write(message);
         }

            // 연결 해제
         ns.Close();
         tcpClient.Close();
         tcpListener.Stop();

         Console.ReadKey();
      }
   }
}
