using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionBodiedMember
{
   class FriendList
   {
      //전역 
      private List<string> list = new List<string>();

      public void Add(string name) => list.Add(name);
      public void Remove(string name) => list.Remove(name);
      public void PrintAll()
      {
         foreach (var s in list)
            Console.WriteLine(s);
      }

      public FriendList() => Console.WriteLine("Program()");
      ~FriendList() => Console.WriteLine("~Program");

      public int Capacity
      {
         get => list.Capacity;
         set => list.Capacity = value;
      }

      // public string this[int index] => list[index]; 읽기 전용
      public string this[int index]
      {
         get => list[index];
         set => list[index] = value;
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         FriendList obj = new FriendList();
         obj.Add("kim");
         obj.Add("kim");
         obj.Add("kim");
         obj.Add("kam");
         obj.PrintAll();
         obj.Remove("kam");
         obj.PrintAll();
      }
   }
}
