using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivedFromArray
{
   class Program
   {
      static void Main(string[] args)
      {
         int[] arry = new int[] { 10,30,20,7,1 };
         Console.WriteLine($"Type of Arry : {arry.GetType()}");
         Console.WriteLine($"Type of Length : {arry.GetLength(0)}"); //1차 2차
         Console.WriteLine($"Base Type of Arry : {arry.GetType().BaseType}");
         Console.WriteLine($"{arry}");
      }
   }
}
