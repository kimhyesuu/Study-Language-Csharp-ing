using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Factory Method Pattern 정의
// 객체를 생성하기 위한 인터페이스를 정의하는데, 어떤 클래스의 인스턴스를
// 만들지는 서브클래스에서 결정 
// 이 패턴을 이용하면 클래스의 인스터스를 만드는 일을 서브 클래스에게 맡기면 된다.

   //사용 목적 및 용도, 장점
   // 객체의 생성을 한 곳에서 관리 가능 
   // 동일한 인터페이스 구현으로 새로운 객체가 추가되더라도 소스의 수정의 거의 없다. 
   // 객체를 여러 곳에서 생성을 각자하면 동일한 생성을 보장 못하지만, 한군데에서 관리하게 되면 동일한 
   // 생성을 보장한다...
namespace FactoryMethod
{
   abstract class Prodcut
   {
   }

   class ConcreteProdctA : Prodcut
   {
   }

   class ConcreteProdctB : Prodcut
   {
   }

   abstract class Creator
   {
      public abstract Prodcut FactoryMethod();
   }

   class ConcreteCreatorA : Creator
   {
      public override Prodcut FactoryMethod()
      {
         return new ConcreteProdctA();
      }
   }

   class ConcreteCreatorB : Creator
   {
      public override Prodcut FactoryMethod()
      {
         return new ConcreteProdctB();
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         Creator[] creators = new Creator[2];

         creators[0] = new ConcreteCreatorA();
         creators[1] = new ConcreteCreatorB();

         foreach(Creator creator in creators)
         {
            Prodcut prodcut = creator.FactoryMethod();
            Console.WriteLine("Created {0}", prodcut.GetType().Name);
         }

         Console.ReadKey();
      }    
   }
}
