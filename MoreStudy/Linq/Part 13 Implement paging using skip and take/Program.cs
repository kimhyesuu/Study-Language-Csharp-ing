using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_13_Implement_paging_using_skip_and_take
{
   class Program
   {
      static void Main(string[] args)
      {
         IEnumerable<Student> students = Student.GetAllStudents();

         Console.WriteLine("Please enter Page Number - 1, 2, 3 or 4 ");

         int pageNumber = 0;

         if(int.TryParse(Console.ReadLine(), out pageNumber))
         {
            if(pageNumber >= 1 && pageNumber < 4)
            {
               // pageNumber - 1 배열이기 때문에 0부터 시작한다는 의미이며, page넘버를 받을 시
               // 넘기는것을 보여주는 것 
               IEnumerable<Student> result = students.Skip((pageNumber - 1)*3).Take(3);

               Console.WriteLine();

               foreach (var s in result)  
               {
                  Console.WriteLine($"{s.StudentId}\t{s.Name}\t{s.TotalMarks}");
               }

               Console.WriteLine("Displaying Page" + pageNumber);
               Console.WriteLine();
            }
            else
            {
               Console.WriteLine("Page number must be an integer between 1 and 4");
            }
         }
         else
         {
            Console.WriteLine("Page number must be an integer between 1 and 4");
         }

         Console.ReadKey();
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
