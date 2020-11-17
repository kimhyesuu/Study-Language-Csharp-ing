using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExe
{
    class LinqPractice
   {
      #region 객체를 활용한 linq
      private string myName = "N/A";
      private int myAge = 0;

      // Declare a Name property of type string:
      public string Name
      {
         get
         {
            return myName;
         }
         set
         {
            myName = value;
         }
      }

      // Declare an Age property of type int:
      public int Age
      {
         get
         {
            return myAge;
         }
         set
         {
            myAge = value;
         }
      }
      public override string ToString()
      {
         return "Name = " + Name + ", Age = " + Age;
      }

      public void Temp()
      {
         List<int> values = new List<int>()
         {
             9, 26, 77, 75, 73, 77,
             59, 93, 9, 13, 64, 50
         };

         // Loop through the collection in reversed order
         foreach (int value in values.Select(x => x).Reverse())
         {
            Console.Write(value + " ");
         }


         #region Person Exe
         Console.WriteLine("Simple Properties");

         // Create a new Person object:
         LinqPractice person = new LinqPractice();

         // Print out the name and the age associated with the person:
         Console.WriteLine("Person details - {0}", person);

         // Set some values on the person object:
         person.Name = "Joe";
         person.Age = 99;
         Console.WriteLine("Person details - {0}", person);

         // Increment the Age property:
         person.Age += 1;
         Console.WriteLine("Person details - {0}", person);


         #endregion
      }
      #endregion

      public void IEnumarbleExe()
      {
         IEnumerable<int> Values = from value in Enumerable.Range(1, 10) select value;
         foreach (int a in Values)
         {
            Console.WriteLine(a);
         }
         Console.ReadLine();
      }

      public void SameIEnumarble()
      {
         // var mergedList = (accounts ?? Enumerable.Empty<DAccountInfo>()).Concat(contacts ?? Enumerable.Empty<DContact>());
      }

      public void Merged()
      {
         var b = from value in Enumerable.Range(1, 10) select value;
         var c = from value in Enumerable.Range(1, 10) select value;
         var list = new List<int>();

         var result = b.Zip(c, (i, s) => new { i, s });
         foreach (var item in result)
         {
            Console.WriteLine($"{item.i} {item.s}");
            // Do something with the kvp
         }
      }

      public void PhoneNumberCombin()
      {
         //"01023375515","01155458855","024462346","032555485" };
         string phone = "01023375515";
         var phoneArray = new string[4];

         var temp = phone.ToCharArray();
         int j = 0, k = 1;

         for (int i = 0; i < temp.Length; i++)
         {
            phoneArray[j] = temp[i].ToString();

            if (i > 3 && i <= 7)
            {
               j++;
            }
            else if (i > 7)
            {
               j++;
            }
         }
      }

      public void MinNumber()
      {
         int[] Number = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
         double? sum = 0;
         double? result = 0;
         int? total = 0;

         //int? result = 0;

         foreach (var i in Number)
         {
            sum += i;
            total += 1;
         }

         result = sum / total;
         //foreach (var i in Number)
         //{
         //   result += i;
         //}

         //result value : 10
         //foreach (var i in Number)
         //{
         //   if (i % 2 == 0)
         //   {
         //      if (!result.HasValue || i > result)
         //      {
         //         result = i;
         //      }
         //   }
         //}

         //result value : 2
         //foreach (var i in Number)
         //{
         //   if(i % 2 == 0)
         //   {
         //      if (!result.HasValue || i < result)
         //      {
         //         result = i;
         //      }
         //   }        
         //}


         //reult value : 1
         //foreach (var i in Number)
         //{
         //   if (!result.HasValue || i < result)
         //   {
         //      result = i;
         //   }
         //}

         Console.WriteLine(result);

      }

      public void MinNumber2()
      {
         int[] Number = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

         double? result = Number.Where(o => o % 2 == 0).Average();

         //int? result = Number.Where(o => o % 2 == 0).Sum();

         //int? result = Number.Sum();

         //int? result = Number.Max();

         //int? result = Number.Where(n => n % 2 == 0).Min();

         //int? result = Number.Min();


         Console.WriteLine(result);

      }

      public void MinLength()
      {
         string[] countries = { "India", "USA" , "UK" };

         int? result = null;

         foreach(var s in countries)
         {
            if(!result.HasValue || s.Length < result)
            {
               result = s.Length;
            }
         }

         Console.WriteLine(result);
      }

      public void MinLength2()
      {
         string[] countries = { "India", "USA", "UK" };

         int minCount = countries.Min(x => x.Length);
         int maxCount = countries.Max(x => x.Length);

         Console.WriteLine(minCount);
         Console.WriteLine(maxCount);
      }
   }

   public static class IEnumerableExtensionForEach
   {
      public static void ForEach<T>(this IEnumerable<T> list, Action<T> block)
      {
         foreach (var item in list)
         {
            block(item);
         }
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         // Aggregate, Generation, Grouping
         // Query Execution Restriction join
         // projection
         var p = new LinqPractice();

         p.MinLength();
         p.MinLength2();

         Console.ReadLine();
      }
   } 
}
