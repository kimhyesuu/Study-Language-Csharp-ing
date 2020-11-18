using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_9_Difference_between_Select_and_SelectMany
{
   // https://www.youtube.com/watch?v=9tgz3aVNblM&list=PL6n9fhu94yhWi8K02Eqxp3Xyh_OmQ0Rp6&index=9
   class Program
   {
      static void Main(string[] args)
      {
         IEnumerable<List<string>> before = Student.GetAllStudents()
                                            .Select(student => student.Subjects);

         foreach(var stringResult in before)
         {
            Console.WriteLine(stringResult);
            foreach(var str in stringResult)
            {
               Console.WriteLine(str);
            }
         }

         Console.WriteLine();

         IEnumerable<string> after = Student.GetAllStudents()
                                       .SelectMany(student => student.Subjects);

         foreach (var stringResult in after)
         {
            Console.WriteLine(stringResult);
          
         }

         Console.Read();                                  
      }
   }

   class Student
   {
      public string Name { get; set; }
      public string Gender { get; set; }
      public List<string> Subjects { get; set; }

      public static List<Student> GetAllStudents()
      {
         var listStudents = new List<Student>
         {
            new Student
            {
               Name = "Tom", Gender = "Male",  Subjects = new List<string> { ".NET", "C#"}
            },
            new Student
            {
               Name = "Mike", Gender = "Male",  Subjects = new List<string> { ".NET", "C#","AJAX"}
            },
            new Student
            {
               Name = "Pam", Gender = "Female",  Subjects = new List<string> { "WCF","SQL Server","C#"}
            },
             new Student
            {
               Name = "Mary", Gender = "Female",  Subjects = new List<string> { "WPF","LINQ",".NET"}
            },
         };

         return listStudents;

      }
   }
}
