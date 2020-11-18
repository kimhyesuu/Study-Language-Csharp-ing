using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_8_SelectMany_Operator_in_LINQ
{
   //https://www.youtube.com/watch?v=zQnkh8GpUQU&list=PL6n9fhu94yhWi8K02Eqxp3Xyh_OmQ0Rp6&index=8
   class Program
   {
      static void Main(string[] args)
      {
         // Ex1();
         // Ex2();
         // Ex3();
         // Ex4();
         // Ex5();
         // Ex6();

         Console.ReadLine();
      }

      private static void Ex6()
      {
         var after = Student.GetAllStudents()
           .SelectMany(student => student.Subjects, (student, subject) => new { Student = student.Name, Subject = subject })
           .Distinct();

         var before = from student in Student.GetAllStudents()
                      from subject in student.Subjects
                      select new { Student = student.Name, Subject = subject };

         foreach (var subject in after)
         {
            Console.WriteLine($"{subject.Student} {subject.Subject}");
         }

         Console.WriteLine();

         foreach (var subject in before)
         {
            Console.WriteLine($"{subject.Student} {subject.Subject}");
         }
      }

      private static void Ex5()
      {
         IEnumerable<string> allsubject = (from student in Student.GetAllStudents()
                                           from subject in student.Subjects
                                           select subject).Distinct();

         foreach (string subject in allsubject)
         {
            Console.WriteLine(subject);
         }
      }

      private static void Ex4()
      {
         string[] stringArray =
        {
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            "0123456789"
         };

         IEnumerable<char> charEnum = from s in stringArray
                                      from c in s
                                      select (c);

         foreach (var c in charEnum)
         {
            Console.WriteLine(c);
         }
      }

      private static void Ex3()
      {
         string[] stringArray =
        {
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            "0123456789"
         };

         IEnumerable<char> charEnum = stringArray.SelectMany(c => c);

         foreach (var c in charEnum)
         {
            Console.WriteLine(c);
         }

      }

      private static void Ex2()
      {
         IEnumerable<string> subjects = from student in Student.GetAllStudents()
                                        from subject in student.Subjects
                                        select subject;

         foreach (string subject in subjects)
         {
            Console.WriteLine(subject);
         }
      }

      private static void Ex1()
      {
         IEnumerable<string> subjects = Student.GetAllStudents().SelectMany(s => s.Subjects);

         foreach (string subject in subjects)
         {
            Console.WriteLine(subject);
         }

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
