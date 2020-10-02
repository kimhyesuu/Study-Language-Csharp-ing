using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 문 형식의 람다식은 말 그래로 식 형식을 하고 있었습니다.
// 반환없는 문 형식은 안된다.
namespace BasicLambda2
{
   class Program
   {
      //델리게이트 선언
      delegate string Concatenate(string[] args);

      static void Main(string[] args)
      {
         //이 함수에 람다식으로 만들어주기 
         Concatenate concat = (arr) =>
         {
            string result = string.Empty;
            foreach (string s in arr)
            {
               result += s;
            }

            return result;
         };
      }
   }
}
