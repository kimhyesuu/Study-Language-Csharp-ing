using System;
using System.Collections.Generic;
using System.Linq;

namespace Part_12_Partitioning_Operators_in_LINQ
{
   class Program
   {
      static void Main(string[] args)
      {    
         Console.ReadKey();
      }

      private static void SkipWhileExe()
      {
         string[] countries = { "Australia", "Germany", "Germany", "US"
         , "India", "UK", "Italy"};

         //길이가 3이하인 value는 스킵하자 
         IEnumerable<string> result = (from country in countries
                                       select country).SkipWhile(s => s.Length > 3);

         foreach (var country in result)
         {
            Console.WriteLine(country);
         }
      }

      private static void BeforeTakeWhileExe()
      {
         string[] countries = { "Australia", "Germany", "Germany", "US"
         , "India", "UK", "Italy"};

         //길이가 3이상인 value를 가져와라
         IEnumerable<string> result = (from country in countries
                                       select country).TakeWhile(s => s.Length > 3);

         foreach (var country in result)
         {
            Console.WriteLine(country);
         }
      }

      private static void AfterTakeWhileExe()
      {
         string[] countries = { "Australia", "Germany", "Germany", "US"
         , "India", "UK", "Italy"};

         //길이가 3이상인 value를 가져와라
         IEnumerable<string> result = countries.TakeWhile(s => s.Length > 3);

         foreach (var country in result)
         {
            Console.WriteLine(country);
         }
      }

      private static void AfterSkipExe()
      {
         string[] countries = { "Australia", "Germany", "Germany", "US"
         , "India", "UK", "Italy"};

         //세개만 나오네
         IEnumerable<string> result = countries.Skip(3);

         foreach (var country in result)
         {
            Console.WriteLine(country);
         }
      }

      private static void BeforeSkipExe()
      {
         string[] countries = { "Australia", "Germany", "Germany", "US"
         , "India", "UK", "Italy"};

         //세개만 나오네
         IEnumerable<string> result = (from country in countries
                                       select country).Take(3);

         foreach (var country in result)
         {
            Console.WriteLine(country);
         }
      }

      private static void BeforeTakeExe()
      {
         string[] countries = { "Australia", "Germany", "Germany", "US"
         , "India", "UK", "Italy"};

         //세개만 나오네
         IEnumerable<string> result = (from country in countries
                                      select country).Take(3);

         foreach (var country in result)
         {
            Console.WriteLine(country);
         }
      }

      private static void AfterTakeExe()
      {
         string[] countries = { "Australia", "Germany", "Germany", "US"
         , "India", "UK", "Italy"};

         //세개만 나오네
         IEnumerable<string> result = countries.Take(3).Skip(1);

         foreach (var country in result)
         {
            Console.WriteLine(country);
         }
      }
   }
}
