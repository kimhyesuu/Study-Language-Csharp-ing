using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefReturn
{
   class Product
   {
      private int price = 100;

      public ref int GetPrice()
      {
         return ref price;
      }

      public void PrintPrice()
      {
         Console.WriteLine($"Price :{price}");
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         Product carrot = new Product();
         ref int refLocalPrice = ref carrot.GetPrice();
         int normalLocalPrice = carrot.GetPrice();

         carrot.PrintPrice();
         Console.WriteLine($"Ref Local Price :{refLocalPrice}");
         Console.WriteLine($"Normal Local Price :{normalLocalPrice}");

         refLocalPrice = 200;

         carrot.PrintPrice();
         Console.WriteLine($"Ref Local Price :{refLocalPrice}");
         Console.WriteLine($"Normal Local Price :{normalLocalPrice}");

      }
   }
}
