using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_7_Projection_Operators_in_LINQ
{
   // https://www.youtube.com/watch?v=UHbjfJYRxjc&list=PL6n9fhu94yhWi8K02Eqxp3Xyh_OmQ0Rp6&index=7
   class Program
   {
      static void Main(string[] args)
      {
         // Ex1();
         // Ex2();                 
         // Ex3();
       
         Console.Read();
      }

      private static void Ex3()
      {
         var result = Employee.GetEmployees().Where(x => x.AnnualSalary > 50000)
          .Select(emp =>
          new
          {
             FullName = emp.FirstName + " " + emp.LastName,
             emp.AnnualSalary,
             MonthlySalary = emp.AnnualSalary / 12,
             Bonus = emp.AnnualSalary * .01
          });

         foreach (var id in result)
         {
            Console.WriteLine($"{id.FullName} \n {id.AnnualSalary} \n {id.MonthlySalary} \n {id.Bonus}");
         }
      }

      private static void Ex2()
      {
         var result = Employee.GetEmployees().Select(emp => new { FullName = emp.FirstName + " " + emp.LastName, Gender = emp.Gender });

         foreach (var id in result)
         {
            Console.WriteLine($"{id.FullName} \n {id.Gender}");
         }
      }

      private static void Ex1()
      {
         IEnumerable<int> result = Employee.GetEmployees().Select(emp => emp.EmployeeID);

         foreach (var id in result)
         {
            Console.WriteLine(id);
         }
      }
   }

   class Employee
   {
      public int EmployeeID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Gender { get; set; }
      public int AnnualSalary { get; set; }

      public static List<Employee> GetEmployees()
      {
         List<Employee> listEmployees = new List<Employee>
         {
            new Employee
            {
               EmployeeID = 101,
               FirstName = "Tom",
               LastName = "Daely",
               Gender = "Male",
               AnnualSalary = 60000
            },

             new Employee
            {
               EmployeeID = 102,
               FirstName = "Mike",
               LastName = "Mist",
               Gender = "Male",
               AnnualSalary = 72000
            },

             new Employee
            {
               EmployeeID = 103,
               FirstName = "Mary",
               LastName = "Lambeth",
               Gender = "Female",
               AnnualSalary = 48000
            },

            new Employee
            {
               EmployeeID = 104,
               FirstName = "Pam",
               LastName = "Penny",
               Gender = "Femal",
               AnnualSalary = 82000
            }
         };

         return listEmployees;
      }
   }
}
