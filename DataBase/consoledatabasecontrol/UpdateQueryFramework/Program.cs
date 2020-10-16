using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateQueryFramework
{
   // update 구문 

      // 그 값이 일치하는 조건값일 때 한 열뿐만아니라 일치하는 열 전부 바뀐다.    

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
         string name = "안녕하세요";
         int age = 28;
         //This is my connection string i have assigned the database file address path  
         string _connectSql = string.Format($"server={_address};" +
                                     $"port={_port}; " +
                                     $"Uid={_uid}; " +
                                     $"pwd={_pwd}; " +
                                     $"Database={_database}; " +
                                     $"CHARSET={_charset}");


         //This is my update query in which i am taking input from the user through windows forms and update the record.  
         //UPDATE [테이블] SET [열] = '변경할값' WHERE [조건]
         string updateQuery = string.Format($"update PERSON set name='{name}' where age={age};");
         //This is  MySqlConnection here i have created the object and pass my connection string.  
         _connection = new MySqlConnection(_connectSql);
         MySqlCommand cmd = new MySqlCommand(updateQuery, _connection);
         MySqlDataReader reader;
         _connection.Open();
         reader = cmd.ExecuteReader();
         _connection.Close();//Connection closed here  
         Console.WriteLine("성공");
      }
   }
}
