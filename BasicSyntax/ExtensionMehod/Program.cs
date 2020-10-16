using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExtension;

// 확장 메서드는 기존 클래스의 기능을 확장하는 기법
// 확장 메서드 선언방법
// 1. 메서드를 선언하되, Static 한정자 수식해야함
// 2. 첫번째 매개변수는 반드시 this 키워드와 함께 확장하고자 하는 클래스의 인스턴스여야 함
// 3. 매개 변수 목록이 실제로 확장 메서드를 호출할 때 입력되는 매개 변수여야 함

namespace MyExtension
{
   public static class IntegerExtension
   {
      // this int myInt : value.Square -> 매개변수 : value
      public static int Square(int myInt)
      {
         return myInt * myInt;
      }

      public static int Power(this int myInt, int exponent)
      {
         int result = myInt;
         for (int index = 0; index < exponent; index++)
            result = result * myInt;

         return result;
      }
   }

}

//이해가 안되는 부분이지만 
namespace ExtensionMehod
{
   class Program
   {
      static void Main(string[] args)
      {
         int value = 3;
         Console.WriteLine($"{IntegerExtension.Square(4)}");
         Console.WriteLine($"{value.Power(4)}");
      }
   }
}
