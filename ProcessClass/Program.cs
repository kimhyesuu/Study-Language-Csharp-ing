using System;
using System.Diagnostics;

namespace ProcessClass
{
   class Program
   {
      static void Main(string[] args)
      {
         while(true)
         {
            Console.WriteLine("Search it on Google");
            string str = Console.ReadLine();
            SearchOnGoogle(str);
         }     
      }

      private static void SearchOnGoogle(string text)
      {
         var str = $"https://translate.google.co.kr/?hl=en&tab=wT#view=home&op=translate&sl=en&tl=ko&text=" +text;
     
         Process.Start(str);         
      }
   }
}
