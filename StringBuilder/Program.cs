using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderExe
{
   class Program
   {
      static void Main(string[] args)
      {
         // stringbulder is a class in c# which means it has properties and methods
         // stringbuilder uses the System.Text
         // We use StringBuilder to change strings.
         // StringBuilder is more efficient in terms of memory than using String methods
         var sb = new StringBuilder();

         sb.Append('-', 6);
         sb.Append("Here is a title!");

         sb.AppendLine();
         sb.Append("happy");
         sb.Replace("happy", "goood");

         sb.Remove(0,3);
         string s = "ddd";
         sb.AppendLine();
         sb.AppendFormat($"{s}");
         sb.Append(string.Join(string.Empty, s));
         sb.EnsureCapacity(1);
        
         Console.WriteLine(sb);
         Console.WriteLine(Exe2());

         

         Console.ReadLine();
      }

      private static string Exe2()
      {
         StringBuilder stringb = new StringBuilder();

         stringb.Append("Cornsilk DarkSalman Gold Gray Green");

         string temp = "stringbuilder: " + stringb.ToString();

         string[] stringArray = stringb.ToString().Split(' ').ToArray();

         temp += "<br /><br />loop through string array...............";
         foreach (string s in stringArray)
         {
            temp += "<br />" + s;
         }

         for (int i = 0 ; i < stringArray.Length ; i++ )
         {
            Console.WriteLine(stringArray[i]);
         }

         return stringArray[0];
      }
   }

  

}
