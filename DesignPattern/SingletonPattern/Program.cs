using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 싱글톤(Singleton)
// 해당 클래스의 인스턴스가 하나만 생성이 되는것을 보장하며 어디서든지 그 인스턴스에 접근이 가능하도록 만드는 패턴

//  1. 전역변수를 사용해서 싱글톤을 사용안 할 수 있지만, 전역변수를 사용하는데서 네임스페이스 충돌을 막을 수 있음 
namespace SingletonPattern
{
   class Singleton
   {
      private static Singleton _instance;

      protected Singleton()
      {
      }

      public static Singleton Intance()
      {
         if(_instance is null)
         {
            _instance = new Singleton();
         }

         return _instance;
      }

   }

   class Program
   {
      static void Main(string[] args)
      {
         Singleton s1 = Singleton.Intance();
         Singleton s2 = Singleton.Intance();

         if(s1 == s2) Console.WriteLine("objects are the same intance");

         Console.ReadKey();
      }
   }
}
