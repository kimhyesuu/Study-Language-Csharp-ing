using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// collection
// 같은 성격을 띄는 데이터의 모음을 담는 자료 구조
// ICollection <- System.Array
// 1. ArrayList - Add(), RemoveAt(), Insert()
// Add : 개체를 System.Collections.ArrayList의 끝 부분에 추가합니다.
// RemoveAt :  System.Collections.ArrayList의 지정한 인덱스에서 요소를 제거합니다.
// Insert : 지정된 인덱스에 요소를 삽입합니다.

namespace BasicCollection
{
   class Program
   {
      static void Main(string[] args)
      {
         ArrayList list = new ArrayList();

         for (int index = 1; index < 10; index++)
            list.Add(index);

         foreach (object obj in list)
            Console.Write($"{obj} ");
         Console.WriteLine();

         list.RemoveAt(2);

         foreach (object obj in list)
            Console.Write($"{obj} ");
         Console.WriteLine();

         list.Insert(2,2);

         foreach (object obj in list)
            Console.Write($"{obj} ");
         Console.WriteLine();

         list.Add("add");

         foreach (object obj in list)
            Console.Write($"{obj} ");
         Console.WriteLine();


      }
   }
}
