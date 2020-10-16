using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySample
{
   class Program
   {
      static void Main(string[] args)
      {
         int[] scores = new int[5];
         scores[0] = 1;
         scores[1] = 2;
         scores[2] = 3;
         scores[3] = 4;
         scores[4] = 5;

         foreach(int score in scores)
         {
            Console.WriteLine(score);
         }

         int sum = 0;

         foreach(var score in scores)
         {
            sum += score;
         }

         int average = sum / scores.Length;

         Console.WriteLine($"Average Score : {average}");


      }
   }
}
