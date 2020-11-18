using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_6_Restriction_Operators_in_Linq
{
   //https://www.youtube.com/watch?v=DTtRC_b8YOA&list=PL6n9fhu94yhWi8K02Eqxp3Xyh_OmQ0Rp6&index=6
   class Program
   {
      static void Main(string[] args)
      {

         // Ex1();
         // Ex2();
         // Ex3();
         // Ex4();
        
         Console.ReadKey();
      }

      private static void Ex4()
      {
         List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

         var result = numbers //numbers의 배열값을 가져와서
            .Select((num, index) => new { Number = num, Index = index }) //이를 내가 원하는 값으로 가져와서
            .Where(x => x.Number % 2 == 0) //필터링을 해주고
            .Select(x => x.Index);// 필터링 된 것에서 인덱스만 찾아라

         foreach (var i in result)
         {
            Console.WriteLine(i);
         }

      }

      private static void Ex3()
      {
         List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

         IEnumerable<int> evenNumbers = from num in numbers
                                        where num % 2 == 0
                                        select num;

         foreach (int i in evenNumbers)
         {
            Console.WriteLine(i);
         }

      }

      #region Ex2

      private static void Ex2()
      {
         List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

         IEnumerable<int> evenNumbers = numbers.Where(num => IsEven(num));

         foreach (int i in evenNumbers)
         {
            Console.WriteLine(i);
         }

      }

      private static bool IsEven(int number)
      {
         return number % 2 == 0; 
      }
      #endregion

      private static void Ex1()
      {
         List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

         Func<int, bool> predicate = x => x % 2 == 0;

         Action<List<int>> action = (x) =>
         {
            foreach (var temp in x)
            {
               if (temp % 2 == 0)
               {
                  Console.WriteLine(temp);
               }
            }
         };

         IEnumerable<int> evenNumbers = numbers.Where(x => x % 2 == 0);
         action(numbers);
         foreach (int i in evenNumbers)
         {
            Console.WriteLine(i);
         }
      }
   }
}
