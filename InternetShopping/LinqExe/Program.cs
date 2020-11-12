using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExe
{
   class Person
   {
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

      public void SameIEnumarble()
      {
         // var mergedList = (accounts ?? Enumerable.Empty<DAccountInfo>()).Concat(contacts ?? Enumerable.Empty<DContact>());

      }

      public void IEnumarbleExe()
      {
         IEnumerable<int> Values = from value in Enumerable.Range(1, 10) select value;
         foreach (int a in Values)
         {
            Console.WriteLine(a);
         }
         Console.ReadLine();
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
         Person person = new Person();

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
         //"01023375515","01155458855","024462346","032555485" };
         string phone = "01023375515";
         var phoneArray = new string[4];

         var temp = phone.ToCharArray();
         int j = 0 , k = 1;

         for(int i = 0; i < temp.Length; i++)
         {
            phoneArray[j] = temp[i].ToString();

            if(i > 3 && i <= 7)
            {
               j++;
            }else if(i > 7)
            {
               j++;
            }
         }

      

         Console.ReadLine();
      }
   } 
}
