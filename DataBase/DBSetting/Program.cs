using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBSetting
{
   class Program
   {
      static void Main(string[] args)
      {
         try
         {
            string connectString =
                "Server=(localDB)\\MSSQLLocalDB;" +
                "Integrated Security=true";
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(connectString);
            Console.WriteLine("Original: " + builder.ConnectionString);
            Console.WriteLine("AttachDBFileName={0}", builder.AttachDBFilename);

            builder.AttachDBFilename = @"C:\Users\juid0\OneDrive\바탕 화면\ProjectManagement\Test\Csharpsyntax\DataBase\DBSetting\PersonThree.mdf";
            Console.WriteLine("Modified: " + builder.ConnectionString);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
               connection.Open(); 
               // Now use the open connection.
               Console.WriteLine("Database = " + connection.Database);
            }
            Console.WriteLine("Press any key to finish.");
            Console.ReadLine();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }

       
      }
   }
}
