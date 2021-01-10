using System;
using System.Collections.Generic;

namespace IComparableExe
{
   // IComparable은 값을 정렬하거나 정렬 할 수 있는 형식으로 구형 가능
   // 인터페이스를 구현하려면 compareTo 메서드가 필요
   // 
   class Employee : IComparable<Employee>
   {
      public string Name { get; set; }
      public int Salary { get; set; }

      public int CompareTo(Employee other)
      {
         if (this.Salary < other.Salary)
         {
            return 1;
         }
         else if (this.Salary > other.Salary)
         {
            return -1;
         }
         else
         {
            return 0;
         }
      }

      public override string ToString()
      {

         return $"{this.Name} {this.Salary}";
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         var employees = new List<Employee>();
         employees.Add(new Employee() { Name = "John Doe", Salary = 1230 });
         employees.Add(new Employee() { Name = "Lucy Novak", Salary = 670 });
         employees.Add(new Employee() { Name = "Robin Brown", Salary = 2300 });
         employees.Add(new Employee() { Name = "Joe Draker", Salary = 1190 });
         employees.Add(new Employee() { Name = "Janet Does", Salary = 980 });

         employees.Sort();

         employees.ForEach(employee => Console.WriteLine(employee));

         Console.ReadKey();
      }
   }
}
