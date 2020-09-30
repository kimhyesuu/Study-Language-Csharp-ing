using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Collection(Hashtable)
// 키와 값의 쌍으로 이루어진 데이터를 다룰 때 사용
// 장점 : 탐색 속도 빠르고 사용 편함. 
namespace BasicCollection2
{
   class Program
   {
      static void Main(string[] args)
      {
         //딕셔너리 초기자 생성 방법
         Hashtable ht = new Hashtable()
         {
            // {"하나",1} 이렇게도 가능
            ["하나"] = "one",
            ["둘"] = "two",
            ["셋"] = "three",
            ["넷"] = "four",
            ["다섯"] = "five",
            ["여섯"] = "six",
         };

         Console.Write($"{ht["하나"]}");
      }
   }
}
