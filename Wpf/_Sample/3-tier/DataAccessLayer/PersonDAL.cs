using System.Data;
using System.Data.SqlClient;
using BusinessLayer;

namespace DataAccessLayer
{
   public class PersonDAL
   {     
      public void add(Person person)
      {
        
         string connectString = "Server=(localDB)\\MSSQLLocalDB;" +
                                 "Integrated Security=true";

         var builder = new SqlConnectionStringBuilder(connectString);

         builder.AttachDBFilename = @"C:\Users\juid0\OneDrive\바탕 화면\ProjectManagement\Test\Csharpsyntax\Wpf\_Sample\3-tier\DataAccessLayer\PersonDB.mdf";

         var conn = new SqlConnection(builder.ConnectionString);
         conn.Open();

         var cmd = new SqlCommand("AddPersonFour", conn);
        
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@PersonId", person.PersonId);
         cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
         cmd.Parameters.AddWithValue("@LastName", person.LastName);

         cmd.ExecuteNonQuery();
         conn.Close();
      }

   }
}
