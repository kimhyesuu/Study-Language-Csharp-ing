using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_14_LINQ_query_deferred_execution
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.ReadKey();
      }

      private static void ImmediateGreedyOperators()
      {
         var studentList = Student.GetAllStudents();

         //ToList() 작성 시 확정내면서 result에 add된 부분이 안들어감
         // count, average, min, max, ToList 
         var result = (from student in studentList
                       where student.TotalMarks == 800
                       select student).ToList();

         //result값이 들어갔음에도 불구하고 
         // 다음 seq에서 add할 시 그 값이 result에도 들어간ㄷㅏ.;
         studentList.Add(
            new Student
            {
               StudentId = 110,
               Name = "kimhyesu",
               TotalMarks = 800
            });

         foreach (var s in result)
         {
            Console.WriteLine($"{s.StudentId}\t{s.Name}\t{s.TotalMarks}");
         }

      }

      private static void DeferredOrLazyOperators()
      {
    
         var studentList = Student.GetAllStudents();

         // select, where, take, skip
         var result = from student in studentList
                      where student.TotalMarks == 800
                      select student;

         //result값이 들어갔음에도 불구하고 
         // 다음 seq에서 add할 시 그 값이 result에도 들어갑니다;
         studentList.Add(
            new Student
            {
               StudentId = 110,
               Name = "kimhyesu",
               TotalMarks = 800
            });

         foreach (var s in result)
         {
            Console.WriteLine($"{s.StudentId}\t{s.Name}\t{s.TotalMarks}");
         }
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
               StudentId = 104, Name = "John" , TotalMarks = 800
            },
            new Student
            {
               StudentId = 105, Name = "Brian" , TotalMarks = 700
            },
            new Student
            {
               StudentId = 106, Name = "Jade" , TotalMarks = 750
            },
            new Student
            {
               StudentId = 107, Name = "Ron" , TotalMarks = 850
            },
            new Student
            {
               StudentId = 108, Name = "Alex" , TotalMarks = 750
            },
            new Student
            {
               StudentId = 109, Name = "Susan" , TotalMarks = 860
            },
         };

         return listStudents;

      }
   }
}
