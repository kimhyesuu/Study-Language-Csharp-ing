using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client_Exe
{
   class Program
   {
      // Client
      static void Main(string[] args)
      {
         TcpClient tcpClient = new TcpClient("192.168.219.121", 8380);
         NetworkStream ns = tcpClient.GetStream();

         Console.WriteLine("클라이언트");

         byte[] buffer = new byte[1024];
         byte[] sendMessage = Encoding.ASCII.GetBytes("Hello World");

         ns.Write(sendMessage, 0 , sendMessage.Length);

         int totalCount = 0;
         int readCount = 0;

         while (totalCount < sendMessage.Length)
         {
            readCount = ns.Read(buffer,0,buffer.Length);
            totalCount += readCount;

            string receivedMessage = Encoding.ASCII.GetString(buffer);
            Console.WriteLine($"receivedMessage : {receivedMessage}");
         }

         Console.WriteLine($"받은 문자열 바이트 수 : {totalCount}");
         ns.Close();
         tcpClient.Close();

         Console.ReadKey();
      }
   }
}
