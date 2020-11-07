using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFirstDemo
{
   class Program
   {
      static void Main(string[] args)
      {
         var context = new DatabaseFirstDemoEntities1();

         var post = new Table()
         {
            Body = "Body",
            DatePublished = DateTime.Now,
            Title = "Title",
            PostId = 1
         };

         context.Table.Add(post);
         context.SaveChanges();

         context.Table.Select<Table>();
      }
   }
}
