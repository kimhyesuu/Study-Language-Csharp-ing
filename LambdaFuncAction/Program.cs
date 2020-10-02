using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 익명 메소드와 무명 함수는 코드를 보다 간결하게 만들어주는 요소들입니다.
// 매번 별개의 대리자를 선언 
// .NET에서 대리자를 미리 선언 해뒀음 
// FUNC 대리자는 결과를 반환하는 메소드를 참조
// Action 대리자는 결과를 반환하지 않는 메소드를 참조

//FUNC 대리자 
// 1. 17가지 버전의 대리자가 준비 
namespace LambdaFuncAction
{
   class Program
   {
      static void Main(string[] args)
      {
         Func<int> func1 = () => 10;
         Console.WriteLine($"func1() : {func1()}");

         Func<int, int> func2 = (x) => x * 2;
         Console.WriteLine($"func2(4) : {func2(4)}");

         Func<double, double, double> func3 = (x, y) => x / y;
         Console.WriteLine($"func3(22,7) : {func3(22,7)}");
      }
   }
}
