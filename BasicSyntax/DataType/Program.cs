using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataType
{
   class Program
   {
      static void Main(string[] args)
      {
         //문자
         Console.WriteLine("Char");
         Console.WriteLine(sizeof(char));
         Console.WriteLine(sizeof(Char));

         Console.WriteLine();

         //정수
         Console.WriteLine("Uint");
         Console.WriteLine(sizeof(UInt16));
         Console.WriteLine(sizeof(UInt32));
         Console.WriteLine(sizeof(UInt64));

         Console.WriteLine();

         Console.WriteLine("정수");
         Console.WriteLine(sizeof(short));
         Console.WriteLine(sizeof(int));
         Console.WriteLine(sizeof(long));
         Console.WriteLine(sizeof(Int16));
         Console.WriteLine(sizeof(Int32));
         Console.WriteLine(sizeof(Int64));
         
         Console.WriteLine();
         //실수
         Console.WriteLine("실수");
         Console.WriteLine(sizeof(double));
         Console.WriteLine(sizeof(Double));

         Console.WriteLine("주요 제어문자");
         Console.WriteLine("New Line\nCarriage Return\r\nMore");
    
         //stream
         Console.WriteLine("Stream");
         Console.WriteLine(sizeof(Byte));
         

         Console.ReadKey();
      }
   }
}
