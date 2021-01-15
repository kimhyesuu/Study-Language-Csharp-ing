namespace Client_Exe
{
   using System;
   using System.Net.Sockets;
   using System.Text;

   class Program
   {
      static void Main(string[] args)
      {
         int port = 8380;

         // TcpClient(string hostname, int port)
         TcpClient tcpClient = new TcpClient("192.168.219.120", port);

         // 연결되냐?
         if (tcpClient.Connected)
         {
            Console.WriteLine("서버 연결 성공");

            // NetworkStream 사용
            // 1. 클라이언트 단에서 값이 온 것을 받음
            NetworkStream ns = tcpClient.GetStream();

            // 2. Message 보낼 때 쓴다.
            string Message = "Hello World";
            byte[] SendByteMessage = Encoding.ASCII.GetBytes(Message);
            ns.Write(SendByteMessage, 0, SendByteMessage.Length);

            // 3. 메시지를 받을 때 쓴다.
            byte[] ReceiveByteMessage = new byte[32];
            ns.Read(ReceiveByteMessage, 0, 32);
            string ReceiveMessage = Encoding.ASCII.GetString(ReceiveByteMessage);

            // 4. 출력 후 닫기 
            Console.WriteLine(ReceiveMessage);
            ns.Close();

         }
         else
         {
            Console.WriteLine("서버 연결 실패");
         }

         // 닫아줘라
         tcpClient.Close();
         Console.ReadKey();
      }
   }
}
