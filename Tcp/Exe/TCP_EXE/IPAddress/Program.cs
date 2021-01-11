namespace IPAddress_Exe
{
   using System;
   using System.Net;

   class Program
   {
      static void Main(string[] args)
      {
         string Address = Console.ReadLine();
         IPAddress IP = IPAddress.Parse(Address);
         Console.WriteLine($"ip : {IP.ToString()}");
         Console.ReadKey();
      }
   }
}
