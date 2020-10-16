using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
   //2. Methods Should Do One Thing
   //3. Keep It Simple
   //4. Be Consistent
   //5. Use Curly Braces For If Statements
   //6. Concatenate String using $"" 
   //7. Avoid Global Variables
   //8. Use Public Modifier Only When Necessary

   //Never Trust the User

   class Program
   {
      private static List<Person> people = new List<Person>();

      static void Main(string[] args)
      {
         // capturing a number of people's names
         // Loop through and say hi to them
         StringDemoMethod();
         //SetUpSampleData();

         //GreetAllThePeople();


         Console.ReadKey();
      }

      private static void StringDemoMethod()
      {
         string s = string.Empty;
         StringBuilder sb = new StringBuilder();

         Console.WriteLine(DateTime.Now.ToLongTimeString());

         for(int i = 0; i < 10000; i++)
         {
            s += "HI ";
            sb.Append("HI  ");
         }

         Console.WriteLine(DateTime.Now.ToLongTimeString());
      }

      private static void SetUpSampleData()
      {
         people.Add(new Person { FirstName = "Tim", LastName = "ysu" });
         people.Add(new Person { FirstName = "kim", LastName = "ysu" });
         people.Add(new Person { FirstName = "kim", LastName = "ysu" });
      }

      private static void GreetAllThePeople()
      {
         foreach (var person in people)
         {
            if(person.FirstName == "Tim")
            {
               Console.WriteLine($"Hello {person.LastName}");
            }
            else
            {
               Console.WriteLine($"Hello {person.FirstName} {person.LastName}");
            }
           
         }
      }
   }
}
