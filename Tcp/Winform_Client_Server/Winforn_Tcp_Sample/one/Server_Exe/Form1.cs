using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Server_Exe
{
   public partial class Form1 : Form
   {
      private TcpListener _tcpListener;
    
      public Form1()
      {
         InitializeComponent();

         _tcpListener = null;
      
      }

      private void Form1_Load(object sender, System.EventArgs e)
      {
         IPAddress iP = IPAddress.Parse("172.30.1.19");

         // 중요 
         _tcpListener = new TcpListener(iP, 8380);
         _tcpListener.Start();

         IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

         for (int i = 0; i < host.AddressList.Length; i++)
         {
            if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
            {
               tb_server.Text = host.AddressList[i].ToString();
               break;
            }
         }
      }

      private void btn_StartServer_Click(object sender, System.EventArgs e)
      {
         var thread = new Thread(new ThreadStart(AcceptClient));
         // background 설정 true
         thread.IsBackground = true;
         thread.Start();
      }

      // 클라이언트 요구 
      // 반환
      private void AcceptClient()
      {
         while(true)
         {
            var tcpClient = _tcpListener.AcceptTcpClient();

            if(tcpClient.Connected)
            {
               string str = (tcpClient.Client.RemoteEndPoint as IPEndPoint).Address.ToString();
               ltb_clientList.Items.Add(str);
            }

            var echoServer = new EchoServer(tcpClient);
            var thread = new Thread(new ThreadStart(echoServer.Process));
            thread.IsBackground = true;
            thread.Start();            
         }
      }

      private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      {
         if(_tcpListener != null)
         {
            _tcpListener.Stop();
            _tcpListener = null;
         }
      }
   }

   public class EchoServer
   {
      private TcpClient _refClient;
      private BinaryWriter _bw;
      private BinaryReader _br;

      private int _intValue;
      private float _floatValue;
      private string _strValue;

      public EchoServer(TcpClient tcpClient)
      {
         this._refClient = tcpClient;
         _bw = null;
         _br = null;

         _intValue = 0;
         _floatValue = 0;
         _strValue = string.Empty;
      }

      public void Process()
      {
         NetworkStream ns = _refClient.GetStream();

         try
         {
            _br = new BinaryReader(ns);
            _bw = new BinaryWriter(ns);

            while(true)
            {
               _intValue = _br.ReadInt32();
               _floatValue = _br.ReadSingle();
               _strValue = _br.ReadString();

               _bw.Write(_intValue);
               _bw.Write(_floatValue);
               _bw.Write(_strValue);
            }
         }
         catch(SocketException se)
         {
            _br.Close();
            _bw.Close();
            ns.Close();
            ns = null;
            _refClient.Close();
            MessageBox.Show(se.Message);
            Thread.CurrentThread.Abort();
         }
         catch(IOException ex)
         {
            // 연결이 끈어져서 읽을 수가 없을 때 처리 
            _br.Close();
            _bw.Close();
            ns.Close();
            ns = null;
            _refClient.Close();
            MessageBox.Show(ex.Message);
            Thread.CurrentThread.Abort();
         }
      }
   }
}
