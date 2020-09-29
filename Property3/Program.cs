using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//무명 형식 
// 그 형식의 이름을 이용해서 인스턴스를 만들기 때문
// 1. 무명 형식은 선언과 동시에 인스턴스 할당 
// 2. linq랑 쓰면 완전 좋음
namespace Property3
{
   class Program
   {
      static void Main(string[] args)
      {
         var a = new { Name = "김혜수", Age = 28 };
         Console.WriteLine($"Name:{a.Name}, Age:{a.Age}");

         var b = new { Subject = "수학", Scores = new int[] { 90,80,70,60 } };
         Console.Write($"Subject:{b.Subject}, Score ");
         foreach(var Score in b.Scores)
         {
            Console.Write($"{Score}");
         }

         Console.WriteLine();
      }
   }
}
