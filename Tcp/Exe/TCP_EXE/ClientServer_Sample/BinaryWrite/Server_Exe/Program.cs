using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server_Exe
{
   class Program
   {
      static void Main(string[] args)
      {
         // 현재 이 컴퓨터가 서버 역할을 하기 때문에 주소 안넣어도 댐
         IPAddress ip = IPAddress.Parse("192.168.219.121");
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
            sw.AutoFlush = true; // writeline 하고 나서 버퍼를 비워주는 역할
            sw.WriteLine(yes);
            sw.WriteLine(val1);
            sw.WriteLine(pi);
            sw.WriteLine(message);
         }

            // 연결 해제
         ns.Close();
         tcpClient.Close();
         tcpListener.Stop();

         Console.ReadKey();
      }
   }
}
