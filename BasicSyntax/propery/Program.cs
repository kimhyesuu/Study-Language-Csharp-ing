using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace property
{
   class BirthdayInfo
   {
      private string name;
      private DateTime birthday;

      public string Name
      {
         get => name;
         set { name = value; }

      }

      public DateTime Birthday
      {
         get => birthday;
         set
         {
            birthday = value;
         }
      }

      public int Age
      {
         get => new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year;
      }

   }

   class Program
   {
      static void Main(string[] args)
      {
         BirthdayInfo birth = new BirthdayInfo();
         birth.Name = "서현";
         birth.Birthday = new DateTime(1993,9,10);

         Console.WriteLine($"Name : {birth.Name}");
         Console.WriteLine($"Birthday : {birth.Birthday.ToShortDateString()}");
         Console.WriteLine($"Age : {birth.Age}");
      }
   }
}
