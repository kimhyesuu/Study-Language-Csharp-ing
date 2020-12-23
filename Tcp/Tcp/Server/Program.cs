using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
   class Program
   {
      static void Main(string[] args)
      {
         if(args.Length < 1)
         {
            Console.WriteLine($"사용법 : {Process.GetCurrentProcess().ProcessName} < Bind IP>");
            return;
         }

         string bindIp = args[0];
         const int bindPort = 8380;
         TcpListener server = null;

         try
         {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(bindIp), bindPort);
            server = new TcpListener(iPEndPoint);
            server.Start();
            Console.WriteLine("server start");


            while(true)
            {
               TcpClient client = server.AcceptTcpClient();
               Console.WriteLine($"클라이언트 접속 : {((IPEndPoint)client.Client.RemoteEndPoint).ToString()}");

               var stream = client.GetStream();

               int length;
               string data = null;
               byte[] bytes = new byte[256];

               while((length = stream.Read(bytes, 0,bytes.Length)) != 0)
               {
                  data = Encoding.Default.GetString(bytes,0,bytes.Length);
                  Console.WriteLine(string.Format("수신: {0}",data));

                  byte[] msg = Encoding.Default.GetBytes(data);
                  stream.Write(msg, 0 , msg.Length);
                  Console.WriteLine(string.Format("송신 {0}",data));

               }

               stream.Close();
               client.Close();
              
            }
         }
         catch (SocketException e)
         {
            Console.WriteLine(e);
         }
         finally
         {
            server.Stop();
         }


         Console.WriteLine("서버를 종료합니다.");
      }
   }
}
