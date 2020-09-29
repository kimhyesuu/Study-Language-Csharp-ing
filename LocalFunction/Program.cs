using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 로컬 함수는 메소드 안에서 선언되고, 선언된 메소드 안에서만 사용할 수 있는 특별 함수
namespace LocalFunction
{
   class Program
   {
      static void Main(string[] args)
      {
         int count = 0;
         SomeLocalFunction();
         SomeLocalFunction();
         SomeLocalFunction();

         // 클래스의 멤버가 아니기 때문에 메소드가 아니라 함수라고 부름
         void SomeLocalFunction(int a=1, int b=2)
         {
            Console.WriteLine($"count : {++count}");
         }
      }
   }
}
