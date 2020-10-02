using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UsingExpressionTree
{
   class Program
   {
      static void Main(string[] args)
      {
         Expression const1 = Expression.Constant(1); // 상수 1
         Expression const2 = Expression.Constant(2); // 상수 2

         Expression leftExp = Expression.Multiply(const1,const2); // 1*2

         Expression param1 = Expression.Parameter(typeof(int)); // x를 위한 변수
         Expression param2 = Expression.Parameter(typeof(int)); // y를 위한 변수

         Expression rigtExp = Expression.Subtract(param1, param2); //x-y

         Expression exp = Expression.Add(leftExp,rigtExp);

         //이해가 안댐
         Expression<Func<int, int, int>> expression = Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>
            (
               exp, new ParameterExpression[]
               {
                  param1 as ParameterExpression,
                  param2 as ParameterExpression
               }
            );

         Func<int, int, int> func = expression.Compile();

         Console.WriteLine($"1*2+{7}-{8} = {func(7,8)}");
      }
   }
}
