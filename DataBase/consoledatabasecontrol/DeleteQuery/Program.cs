using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteQuery
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
         int age = 28;
         //This is my connection string i have assigned the database file address path  
         string _connectSql = string.Format($"server={_address};" +
                                     $"port={_port}; " +
                                     $"Uid={_uid}; " +
                                     $"pwd={_pwd}; " +
                                     $"Database={_database}; " +
                                     $"CHARSET={_charset}");

         string deleteQuety = string.Format($"delete from PERSON where age=@age;");

         _connection = new MySqlConnection(_connectSql);
         _connection.Open();
         MySqlCommand deleteCommand = new MySqlCommand(deleteQuety, _connection);

         deleteCommand.Parameters.Add("@age", MySqlDbType.Int32);
         deleteCommand.Parameters[0].Value = age;

         deleteCommand.ExecuteNonQuery();
         // DB 닫기
         _connection.Close();
         Console.WriteLine("끝");
      }
   }
}


//  using(MySqlConnection myConnection = new MySqlConnection(@"Data Source=[DB서버];Database=[DB테이블];User ID=[DB접속ID];Password=[DB접속PW]"))
//            {
//                // DB 열기
//                myConnection.Open();
 
//                // 데이터 삽입
//                MySqlCommand insertCommand = new MySqlCommand();
//insertCommand.Connection = myConnection;
//                insertCommand.CommandText = "INSERT INTO test(name, sub) VALUES(@name, @sub)";
 
//                insertCommand.Parameters.Add("@name", MySqlDbType.VarChar, 10);
//                insertCommand.Parameters.Add("@sub", MySqlDbType.VarChar, 20);
 
//                insertCommand.Parameters[0].Value = "정강원";
//                insertCommand.Parameters[1].Value = "무직";
 
//                insertCommand.ExecuteNonQuery();
 
 
//                // 데이터 업데이트
//                MySqlCommand updateCommand = new MySqlCommand();
//updateCommand.Connection = myConnection;
//                updateCommand.CommandText = "UPDATE test SET sub=@sub WHERE name=@name";
 
//                updateCommand.Parameters.Add("@sub", MySqlDbType.VarChar, 20);
//                updateCommand.Parameters.Add("@name", MySqlDbType.VarChar, 10);
                 
//                updateCommand.Parameters[0].Value = "직장인";
//                updateCommand.Parameters[1].Value = "정강원";
 
//                updateCommand.ExecuteNonQuery();
 
 
//                // 데이터 검색
//                MySqlCommand selectCommand = new MySqlCommand();
//selectCommand.Connection = myConnection;
//                selectCommand.CommandText = "SELECT * FROM test";
 
//                DataSet ds = new DataSet();
//MySqlDataAdapter da = new MySqlDataAdapter("SELECT *FROM test", myConnection);
//da.Fill(ds);
 
//                foreach (DataRow row in ds.Tables[0].Rows)
//                {
//                    Console.WriteLine(string.Format("이름 : {0} \n비고 : {1}", row["name"], row["sub"]));
//                }
                 
 
//                // 데이터 삭제
//                MySqlCommand deleteCommand = new MySqlCommand();
//deleteCommand.Connection = myConnection;
//                deleteCommand.CommandText = "DELETE FROM test WHERE name=@name";
 
//                deleteCommand.Parameters.Add("@name", MySqlDbType.VarChar, 10);
//                deleteCommand.Parameters[0].Value = "정강원";
 
//                deleteCommand.ExecuteNonQuery();
 
 
//                // DB 닫기
//                myConnection.Close();

   
