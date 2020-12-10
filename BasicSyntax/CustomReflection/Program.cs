using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomReflection
{
   [CustomAttribute("str", varTmp = "TMP")]
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("CustomAttribute");
         

         Console.ReadKey();
      }
   }

   class CustomAttribute : System.Attribute
   {
      private string str;
      private string tmp;

      public CustomAttribute(string str)
      {
         this.str = str;
      }

      public string varTmp { get => tmp; set => tmp = value; }
   }
}
