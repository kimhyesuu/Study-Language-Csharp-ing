using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 파생 클래스는 자신만의 고유한 멤버 외에도 기반 클래스로부터 물려받은 멤버를 갖고 있습니다.
// 파생 클래스 생성 과정 : 부모 클래스의 생성자를 호출 -> 파생 클래스 생성자 호출 
// 파생 클래스 소멸 과정 : 파생 클래스 -> 부모 클래스

namespace Inheritance
{
   class Base
   {
      protected string Name; // 필드
     
      public Base(string Name) // construtor
      {
         this.Name = Name;
         Console.WriteLine($"{this.Name}.Base()");
      }

      ~Base() // 소멸자
      {
         Console.WriteLine($"{this.Name}.~Base()");
      }

      public void BaseMethod() // 메서드
      {
         Console.WriteLine($"{this.Name}.BaseMethod()");
      }
   }

   class Derived : Base // 상속
   {
      public Derived(string Name) : base(Name)
      {
         Console.WriteLine($"{this.Name}.Derived()");
      }

      ~Derived()
      {
         Console.WriteLine($"{this.Name}.~Derived()");
      }

      public void DerivedMethod()
      {
         Console.WriteLine($"{Name}.DerivedMethod");
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         Base a = new Base("a");
         a.BaseMethod();

         Derived b = new Derived("b");
         b.BaseMethod();
         b.DerivedMethod();
      }
   }
}
