using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInInterface
{
   interface INamedValue
   {
      string Name { get; set; }
      string Value { get; set; }
   }

   class NamedValue : INamedValue
   {
      public string Name { get; set; }
      public string Value { get; set; }
   }

   class Program
   {
      static void Main(string[] args)
      {
         NamedValue name = new NamedValue()
         { Name = "이름", Value = "김혜수"};

         NamedValue height = new NamedValue()
         { Name = "키", Value = "182cm" };

      }
   }
}
