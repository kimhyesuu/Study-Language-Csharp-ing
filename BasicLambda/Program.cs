using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 람다 
// 매개_변수_목록 => 식 
// => : 입력 연산자
//대리자와 람다식 같은 개념이지만 대리자 2.0, 람다식 3.0에서 나왔기 때문에 혼용할 수 밖에 없습니다.
namespace BasicLambda
{  
   class Program
   {
      delegate int Calculate(int a, int b);

      static void Main(string[] args)
      {
         Calculate calculate = (a, b) => a + b;

         Console.WriteLine($"3 + 4 = {calculate(3,4)}");
      }
   }
}
