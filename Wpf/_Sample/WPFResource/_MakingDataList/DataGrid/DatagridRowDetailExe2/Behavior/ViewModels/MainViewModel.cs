using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Behavior.ViewModels
{
   public class MainViewModel : INotifyPropertyChanged
   {
      private List<Employee> _employees;
      public List<Employee> Employees
      {
         get => _employees;
         set
         {
            _employees = value;
            OnPropertyChanged(nameof(Employees));
         }
      }

      private Employee _selected;

      public Employee SelectedEmployee
      {
         get => _selected;
         set
         {
            _selected = value;
            OnPropertyChanged(nameof(SelectedEmployee));
         }
      }

      public MainViewModel()
      {
         var detail1 = new EmployeeDetails() { ManagerID = 11, ManagerName = "11 Name", ManagerMobile = "123456" };
         var detail2 = new EmployeeDetails() { ManagerID = 12, ManagerName = "12 Name", ManagerMobile = "123456" };
         var detail3 = new EmployeeDetails() { ManagerID = 13, ManagerName = "13 Name", ManagerMobile = "123456" };

         var detail4 = new EmployeeDetails() { ManagerID = 11, ManagerName = "11 Name", ManagerMobile = "123456" };
         var detail5 = new EmployeeDetails() { ManagerID = 12, ManagerName = "12 Name", ManagerMobile = "123456" };
         var detail6 = new EmployeeDetails() { ManagerID = 13, ManagerName = "13 Name", ManagerMobile = "123456" };

         var detail7 = new EmployeeDetails() { ManagerID = 11, ManagerName = "11 Name", ManagerMobile = "123456" };
         var detail8 = new EmployeeDetails() { ManagerID = 12, ManagerName = "12 Name", ManagerMobile = "123456" };
         var detail9 = new EmployeeDetails() { ManagerID = 13, ManagerName = "13 Name", ManagerMobile = "123456" };

         var details1 = new List<EmployeeDetails>();
         details1.Add(detail1);
         details1.Add(detail2);
         details1.Add(detail3);

         var details2 = new List<EmployeeDetails>() { detail4, detail5, detail6 };
         var details3 = new List<EmployeeDetails>() { detail7, detail8, detail9 };

         Employees = new List<Employee>();
         Employees.Add(new Employee() { ID = 1, Name = "Name1", Details = details1 });
         Employees.Add(new Employee() { ID = 2, Name = "Name2", Details = details2 });
         Employees.Add(new Employee() { ID = 3, Name = "Name3", Details = details3 });

         SelectedEmployee = Employees[1];

      }

      public event PropertyChangedEventHandler PropertyChanged;

      protected void OnPropertyChanged([CallerMemberName] string name = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }

  
   }

   public class Employee
   {
      public int ID { get; set; }
      public string Name { get; set; }
      public List<EmployeeDetails> Details { get; set; }
   }

   public class EmployeeDetails
   {
      public int ManagerID { get; set; }
      public string ManagerName { get; set; }
      public string ManagerMobile { get; set; }

   }
}
