using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 다중 속성이 가능한 인터페이스
namespace BasicInterface3
{
   interface IRunable
   {
      void Run();
   }

   interface IFlyable
   {
      void Fly();
   }

   class FlyingCar : IRunable, IFlyable
   {
      public void Run()
      {
         Console.WriteLine("Run Run");
      }

      public void Fly()
      {
         Console.WriteLine("Fly Fly");
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         FlyingCar car = new FlyingCar();
         car.Fly();
         car.Run();

         //상속 받은 거라면 as로 캐스팅가능하다
         //변수 선언 후 이 값을 이렇게 사용할 수 있다.
         IRunable runable = car as IRunable;
         runable.Run();

         IFlyable flyable = car as IFlyable;
         flyable.Fly();

      }
   }
}
