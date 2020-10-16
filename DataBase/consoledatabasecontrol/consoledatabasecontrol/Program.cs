using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoledatabasecontrol
{
   class Program
   {
      private static readonly string _address = "127.0.0.1";
      private static readonly string _uid = "root";
      private static readonly string _port = "3306";
      private static readonly string _pwd = "1234";
      private static readonly string _database = "kimhyesu";
      private static readonly string _charset = "UTF8";

      static void Main(string[] args)
      {
         MySqlConnection _connection;
         string insertQuery = "INSERT INTO PERSON(name,age) VALUES('kimhyesu',28)";

         string _connectSql = string.Format($"server={_address};" +
                                       $"port={_port};" +
                                       $"Uid={_uid};" +
                                       $"pwd={_pwd};" +
                                       $"Database={_database};" +
                                       $"CHARSET={_charset}");

         _connection = new MySqlConnection(_connectSql);
         _connection.Open();

         MySqlCommand command = new MySqlCommand(insertQuery, _connection);

         if (command.ExecuteNonQuery() == 1)
         {
            Console.WriteLine("인서트 성공");
         }
         else
         {
            Console.WriteLine("인서트 실패");
         }

         _connection.Close();
         Console.WriteLine("클로즈 성공");

      }
   }
}
