namespace Server_Exe
{
   using System;
   using System.Net;
   using System.Net.Sockets;
   using System.Text;

   class Program
   {
      // Server
      static void Main(string[] args)
      {
         // 현재 이 컴퓨터가 서버 역할을 하기 때문에 주소 안넣어도 댐
         IPAddress ip = IPAddress.Parse("192.168.219.121");
         int port = 8380;
         TcpListener tcpListener = new TcpListener(ip, port);
         //TcpListener tcpListener = new TcpListener( IPAddress.Any, port);
         tcpListener.Start();

         // 망에 대한 상태에 따라서 달라짐
         byte[] buffer = new byte[1024];
         int totalByteCount = 0;
         int readByteCount = 0;

         Console.WriteLine("서버");

         // 대기 상태에 있다가 연결 수락 요청을 받아들여지면,
         // NetworkStream으로 넘어가게 댐
         TcpClient tcpClient = tcpListener.AcceptTcpClient();
         NetworkStream ns = tcpClient.GetStream();

         // Echo 서버에 가장 기본적인 형태
         // client에 요청했을 시 server에서 대답하는 형식
         while(true)
         {
            // read하면서 기다리고 있음. 
            readByteCount = ns.Read(buffer, 0, buffer.Length);

            // return : 0 시 읽을 내용이 없다.
            if (readByteCount == 0)
               break;

            totalByteCount += readByteCount;
            ns.Write(buffer, 0, readByteCount); // 읽은 수만큼 다시 보낸다.
            Console.WriteLine(Encoding.ASCII.GetString(buffer));
         }

         // 연결 해제
         ns.Close();
         tcpClient.Close();
         tcpListener.Stop();

         Console.ReadKey();
      }
   }
}
