using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingFinally
{
   // 예외처리에선 return이 오든간에 finally절은 무조건 넘겨준다. 
   class Program
   {
      static void Main(string[] args)
      {
         try
         {
            Console.WriteLine("제수를 입력하세요. :");
            string temp = Console.ReadLine();
            int divisor = Convert.ToInt32(temp);

            Console.WriteLine("피제수를 입력하세요. : ");
            temp = Console.ReadLine();
            int divided = Convert.ToInt32(temp);

            Console.WriteLine($"{divisor}/{divided} = {Divide(divisor,divided)}");       
         }
         catch(FormatException e)
         {
            Console.WriteLine(e.Message);
         }
         catch(DivideByZeroException e)
         {
            Console.WriteLine(e.Message);
         }
         finally
         {
            Console.WriteLine("프로그램을 종료합니다.");
         }

         Console.ReadKey();
      }

      private static object Divide(int divisor, int divided)
      {
         try
         {
            Console.WriteLine("Divide Function 시작");
            return divisor / divided;
         }
         catch(DivideByZeroException e)
         {
            Console.WriteLine("Divide Function 예외 발생");
            throw e;
         }
         finally
         {
            Console.WriteLine("Divide Function 끝");
         }
      }
   }
}
