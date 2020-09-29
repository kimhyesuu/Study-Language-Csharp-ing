using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace property2
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

   public class Program
   {
      static void Main(string[] args)
      {
         BirthdayInfo birthday = new BirthdayInfo()
         {
            Name = "서현",
            Birthday = new DateTime(1991, 6, 28)
         };

         Console.WriteLine($"Name: {birthday.Name}");
         Console.WriteLine($"Birthday : {birthday.Birthday.ToShortDateString()}");
         Console.WriteLine($"Age : {birthday.Age}");
      }
   }
}
