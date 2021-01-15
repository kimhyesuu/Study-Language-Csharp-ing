namespace Client_Exe
{
   using System;
   using System.IO;
   using System.Net.Sockets;

   class Program
   {
      // Client
      static void Main(string[] args)
      {
         char[] buffer = new char[100];
         TcpClient tcpClient = new TcpClient("192.168.219.121",8380);
         NetworkStream ns = tcpClient.GetStream();

         using (StreamReader sr = new StreamReader(ns))
         {
            string str = sr.ReadLine();
            Console.WriteLine(str);
            str = sr.ReadLine();
            Console.WriteLine(str);
            str = sr.ReadLine();
            Console.WriteLine(str);
            str = sr.ReadLine();
            Console.WriteLine(str);
         }

         ns.Close();
         tcpClient.Close();

         Console.ReadKey();
      }
   }
}
