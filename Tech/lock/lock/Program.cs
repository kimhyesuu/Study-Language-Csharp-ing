using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @lock
{
   public class HongsStack<T>
   {
      private List<T> data;

      public HongsStack()
      {
         data = new List<T>();
      }

      //데이터 넣기
      public bool Push(T _value)
      {
         try
         {
            //쓰레드 안전
            lock (data)
            {
               this.data.Add(_value);
               return true;
            }
         }
         catch (Exception)
         {

            return false;
         }
      }

      //데이터 출력
      public T Pop()
      {
         try
         {
            lock (data)
            {
               if (this.data.Count.Equals(0))
               {
                  return default(T);
               }

               T returnData = this.data[this.data.Count - 1];
               //RemoveAt는 요소 갯수를 나타내는 것 
               this.data.RemoveAt(this.data.Count - 1);
               return returnData;
            }
         }
         catch (Exception)
         {
            throw;
         }
      }
      //스택 카운트 확인
      public int GetStackCount()
      {
         try
         {
            lock (data)
            {
               return this.data.Count;
            }
         }
         catch (Exception)
         {
            throw;
         }
      }

   }

   class Program
   {
      static void Main(string[] args)
      {
         HongsStack<int> intStack = new HongsStack<int>();
         intStack.Push(1);
         intStack.Push(2);
         intStack.Push(3);
         Console.WriteLine(intStack.Pop().ToString());
         Console.WriteLine(intStack.Pop().ToString());
         intStack.Push(4);
         Console.WriteLine(intStack.GetStackCount().ToString());


         HongsStack<string> stringStatck = new HongsStack<string>();
         stringStatck.Push("홍진현");
         stringStatck.Push("NET");
         stringStatck.Push("C#");
         Console.WriteLine(stringStatck.Pop());
         Console.WriteLine(stringStatck.Pop());
         stringStatck.Push("ForMVP");
         Console.WriteLine(stringStatck.GetStackCount().ToString());

      }
   }
}
