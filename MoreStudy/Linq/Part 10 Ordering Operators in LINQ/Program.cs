using System;
using System.Collections.Generic;
using System.Linq;

namespace Part_10_Ordering_Operators_in_LINQ
{
   // OrderingOperators

   // OrderBy
   // OrderByDescending
   // ThenBy
   // ThenByDescending
   // Reverse

   class Program
   {
      static void Main(string[] args)
      {
         Console.Read();
      }

      private static void SortStudentReverse()
      {
         IEnumerable<Student> students = Student.GetAllStudents();

         Console.WriteLine("Before calling Reverse Method");

         foreach(var s in students)
         {
            Console.WriteLine($"{s.StudentId} {s.Name} {s.TotalMarks}");
         }

         Console.WriteLine();

         IEnumerable<Student> result = students.Reverse();

         Console.WriteLine("After calling Reverse Method");

         foreach (var s in result)
         {
            Console.WriteLine($"{s.StudentId} {s.Name} {s.TotalMarks}");
         }

         Console.ReadKey();
      }

      private static void AfterSortStudentInThenBy()
      {
         // 1. 먼저 OrderByDescending로 결정하고 이 then 이름으로 그다음 id값으로 정렬시키는 역할입니다.
         IEnumerable<Student> aresult = Student.GetAllStudents().OrderBy(o => o.TotalMarks)
           .ThenBy(s => s.Name).ThenByDescending(s => s.StudentId);

         foreach (Student student in aresult)
         {
            Console.WriteLine($"{student.StudentId} {student.Name} {student.TotalMarks}");
         }
      }

      private static void BeforeSortStudentInThenBy()
      {
         IOrderedEnumerable<Student> result = from s in Student.GetAllStudents()
                                              orderby s.TotalMarks, s.Name, s.StudentId descending
                                              select s;
         foreach (Student student in result)
         {
            Console.WriteLine($"{student.StudentId} {student.Name} {student.TotalMarks}");
         }

      }

      private static void BeforeSortStudentByNameInDescendingOrder()
      {
         IEnumerable<Student> result = from student in Student.GetAllStudents()
                                       orderby student.Name descending
                                       select student;

         foreach (Student student in result)
         {
            Console.WriteLine(student.Name);
         }
      }

      private static void AfterSortStudentByNameInDescendingOrder()
      {
         IEnumerable<Student> result = Student.GetAllStudents().OrderByDescending(o => o.Name);

         foreach (Student student in result)
         {
            Console.WriteLine(student.Name);
         }

      }

      private static void BeforeSortStudentByNameInAscendingOrder()
      {
         IEnumerable<Student> result = from student in Student.GetAllStudents()
                                       orderby student.Name
                                       select student;

         foreach (Student student in result)
         {
            Console.WriteLine(student.Name);
         }
      }

      private static void AfterSortStudentByNameInAscendingOrder()
      {
         // Sort Student by Name in ascending order
         IEnumerable<Student> result = Student.GetAllStudents().OrderBy(o => o.Name);

         foreach (Student student in result)
         {
            Console.WriteLine(student.Name);
         }
      }

      class Student
      {
         public int StudentId { get; set; }
         public string Name { get; set; }
         public int TotalMarks { get; set; }

         public static List<Student> GetAllStudents()
         {
            var listStudents = new List<Student>
         {
            new Student
            {
               StudentId = 101, Name = "Tom" , TotalMarks = 800  
            },
            new Student
            {
               StudentId = 102, Name = "Mike" , TotalMarks = 900      
            },
            new Student
            {
               StudentId = 103, Name = "Pam" , TotalMarks = 800               
            },
             new Student
            {
               StudentId = 104, Name = "Gugi" , TotalMarks = 800
            },
         };

            return listStudents;

         }
      }
   }
}
