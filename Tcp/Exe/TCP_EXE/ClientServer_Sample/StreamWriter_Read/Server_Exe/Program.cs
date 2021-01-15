namespace Server_Exe
{
   using System;
   using System.IO;
   using System.Net;
   using System.Net.Sockets;

   class Program
   {
      // Server
      static void Main(string[] args)
      {
         IPAddress ip = IPAddress.Parse("192.168.219.121");

         TcpListener tcpListener = new TcpListener(ip, 8380);
         tcpListener.Start();
         TcpClient tcpClient = tcpListener.AcceptTcpClient();

         bool yes = false;
         int val1 = 12;
         float pi = 3.14f;
         string message = "Hello World";

         NetworkStream ns = tcpClient.GetStream();

         using (StreamWriter sw = new StreamWriter(ns))
         {
            sw.AutoFlush = true; // writeline 하고 나서 버퍼를 비워주는 역할
            sw.WriteLine(yes);
            sw.WriteLine(val1);
            sw.WriteLine(pi);
            sw.WriteLine(message);
         }

         ns.Close();
         tcpClient.Close();
         tcpListener.Stop();

         Console.ReadKey();

      }
   }
}
