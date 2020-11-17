using System;
using System.Linq;

namespace Part3_Aggregate_Functions
{
   class Program
   {
      static void Main(string[] args)
      {
         var numbers = StringObject();

         var result = numbers.Aggregate((a, b) => a + "-" + b);
         // numbers.Aggregate((a, b) => a * b);
         // Before(countries, result);

         Console.WriteLine(result);
         Console.ReadLine();
      }

      private static int[] IntObject()
      {
         return new int[] { 1,2,3,4,5};
      }

      private static string[] StringObject()
      {
         return new string[]{ "010", "2337" , "2346"};
      }

      private static string After(string[] countries)
      {
         return countries.Aggregate((a,b) => a + "," + b);
      }

      private static string Before(string[] countries)
      {
         var result = string.Empty;

         foreach (string str in countries)
         {
            result += str + ", ";
         }

         int lastIndex = result.LastIndexOf(",");
         result.Remove(lastIndex);
         return result;
      }

   }
}
