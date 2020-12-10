using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Behavior.ViewModels
{
   public class MainViewModel : INotifyPropertyChanged
   {
      private List<Student> _students;
      public List<Student> students
      {
         get => _students;
         set
         {
            _students = value;
            OnPropertyChanged(nameof(students));
         }
      }

      public MainViewModel()
      {
         students = new List<Student>();
         students.Add(new Student() { Id = 1, Name = "KimHyesu" });
         students.Add(new Student() { Id = 2, Name = "KimHyesu" });
         students.Add(new Student() { Id = 3, Name = "KimHyesu" });
         students.Add(new Student() { Id = 4, Name = "KimHyesu" });
         students.Add(new Student() { Id = 5, Name = "KimHyesu" });

      }

      public event PropertyChangedEventHandler PropertyChanged;

      protected void OnPropertyChanged([CallerMemberName] string name = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }

  
   }

   public class Student
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Details
      {
         get
         {
            return string.Format($"{Id}=>this is row id and {Name}=> this is row name");
         }
      }
   }
}
