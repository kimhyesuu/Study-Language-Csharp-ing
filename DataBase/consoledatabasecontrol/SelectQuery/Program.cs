using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectQuery
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


         string _connectSql = string.Format($"server={_address};" +
                                       $"port={_port};" +
                                       $"Uid={_uid};" +
                                       $"pwd={_pwd};" +
                                       $"Database={_database};" +
                                       $"CHARSET={_charset}");

         _connection = new MySqlConnection(_connectSql);

         try
         {
            _connection.Open();
            string selectQuery = "SELECT * FROM PERSON";
            //ExecuteReader를 이용하여
            //연결 모드로 데이타 가져오기
            MySqlCommand cmd = new MySqlCommand(selectQuery, _connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
               Console.WriteLine("{0} {1}", reader["name"], reader["age"]);
            }

            reader.Close();
         }
         catch (Exception ex)
         {
            Console.WriteLine("실패");
            Console.WriteLine(ex.ToString());
         }
         

      
         _connection.Close();
         Console.WriteLine("클로즈 성공");
      }
   }
}
