using System;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class Connection
   {

      public static string Conn { get; set; } = conn();


      public static string conn()
      {        
         try
         {
            string connectString = "Server=(localDB)\\MSSQLLocalDB;" +
                                   "Integrated Security=true";

            var builder = new SqlConnectionStringBuilder(connectString);

            builder.AttachDBFilename = @"C:\Users\juid0\OneDrive\바탕 화면\ProjectManagement\Test\Csharpsyntax\Wpf\_Sample\3-tier\DataAccessLayer\PersonDB.mdf";

            return builder.ConnectionString;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);

            return string.Empty;
         }     
      }
   }
}
