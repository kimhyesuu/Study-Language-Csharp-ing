using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_Exe
{
   class Program
   {
      static void Main(string[] args)
      {
         // 현재 이 컴퓨터가 서버 역할을 하기 때문에 주소 안넣어도 댐
         IPAddress iP = IPAddress.Parse("192.168.219.120");
         int port = 8380;
         // ip같은 경우 자동적으로 갖고 있기 떄문에 
         // 안 써줘도 무방
         TcpListener tcpListener = new TcpListener(iP, port);
         tcpListener.Start();
         Console.WriteLine("대기 상태 시작");
         // AcceptTcpClient : A System.Net.Sockets.TcpClient used to send and receive data.
         TcpClient tcpClient = tcpListener.AcceptTcpClient(); // -> 대기상태
         // NetworkStream 사용
         // 1. 클라이언트 단에서 값이 온 것을 받음
         NetworkStream ns = tcpClient.GetStream();
         // 2. 바이트 객체 생성
         // 100 의미는 서버와 클라이언트 간의 소통으로 약속 
         byte[] ReceiveMessage = new byte[100];
         // 3. NetworkStream 읽기 버퍼
         // 0 배열의 인덱스
         ns.Read(ReceiveMessage, 0, 100);
         // 4. 변환 후 출력
         string strMessage = Encoding.ASCII.GetString(ReceiveMessage);
         Console.WriteLine(strMessage);
         // 5. 오키 받았어
         string EchoMessage = "Hi Client, I Received a Message";
         byte[] sendMessage = Encoding.ASCII.GetBytes(EchoMessage);
         // 6. NetworkStream 쓰기 버퍼
         ns.Write(sendMessage, 0,sendMessage.Length);
         // 7. NetworkStream 종료
         ns.Close();
         // 8. tcpclient 종료
         tcpClient.Close();
         Console.WriteLine("대기 상태 종료");
         tcpListener.Stop();
         Console.ReadKey();
      }
   }
}
