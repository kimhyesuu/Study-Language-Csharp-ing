using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 클래스는 복합 데이터 형식입니다. 
// 클래스는 여러 관점에서 그 의미를 이해해야한다. 
// 객체 지향적인 관점에서 보면 클래스는 객체를 위한 청사진인 동시에 데이터와 메소드를 묶는
// 집합
namespace BasicClass
{
   public class Cat
   {
      private string name;
      private string color;

      public void Name(string name)
      {
         this.name = name;
      }

      public void Color(string color)
      {
         this.color = color;
      }

      public void Meow()
      {
         Console.WriteLine($"{color}인 {name} : 야옹");
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         Cat kitty = new Cat();
         kitty.Name("키티");
         kitty.Color("화이트");
         kitty.Meow();

         Cat nero = new Cat();
         nero.Name("네로");
         nero.Color("검정");
         nero.Meow();
      }
   }
}
