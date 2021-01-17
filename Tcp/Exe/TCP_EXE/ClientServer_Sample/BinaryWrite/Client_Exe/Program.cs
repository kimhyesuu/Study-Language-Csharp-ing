namespace Client_Exe
{
   using System;
   using System.IO;
   using System.Net.Sockets;

   class Program
   {
      static void Main(string[] args)
      {
         bool yes;
         int number;
         float pi;
         string message;

         TcpClient tcpClient = new TcpClient("192.168.219.105", 8380);
         NetworkStream ns = tcpClient.GetStream();

         using (BinaryReader br = new BinaryReader(ns))
         {
            yes = br.ReadBoolean();
            number = br.ReadInt32();
            pi = br.ReadSingle();
            message = br.ReadString();
         }

         ns.Close();
         tcpClient.Close();

         Console.WriteLine(yes);
         Console.WriteLine(number);
         Console.WriteLine(pi);
         Console.WriteLine(message);


         Console.ReadKey();
      }
   }
}
