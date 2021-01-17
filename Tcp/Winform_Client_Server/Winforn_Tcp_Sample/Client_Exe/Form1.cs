using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client_Exe
{
   public partial class Form1 : Form
   {
      private TcpListener _tcpListener;
      private TcpClient _tcpClient;
      private NetworkStream _ns;
      private BinaryWriter _bw;
      private BinaryReader _br;

      private int _intValue;
      private float _floatValue;
      private string _strValue;

      public Form1()
      {
         InitializeComponent();

         _tcpListener = null;
         _tcpClient = null;
         _ns = null;
         _bw = null;
         _br = null;

         _intValue = 0;
         _floatValue = 0;
         _strValue = string.Empty;
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         IPAddress iP = IPAddress.Parse("172.30.1.47");
         _tcpListener = new TcpListener(iP,8380);
         _tcpListener.Start();

         IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

         for(int i = 0; i < host.AddressList.Length;i++)
         {
            if(host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
            {
               tb_ServerIp.Text = host.AddressList[i].ToString();
               break;
            }
         }
      }

      private void btn_Connect_Click(object sender, EventArgs e)
      {
         _tcpClient = _tcpListener.AcceptTcpClient();

         if(_tcpClient.Connected)
         {
            //클라이언트의 ip를 가지고 온다.
            tb_UserIp.Text = (_tcpClient.Client.RemoteEndPoint as IPEndPoint).Address.ToString();
         }

         _ns = _tcpClient.GetStream();
         _bw = new BinaryWriter(_ns);
         _br = new BinaryReader(_ns);         
      }

      private void btn_SendAndReceive_Click(object sender, EventArgs e)
      {
         while(true)
         {
            if(_tcpClient.Connected)
            {
               if(DataReceive() == -1)
               {
                  break;
               }
               DataSend();
            }
            else
            {
               AllClose();
               break;
            }
         }
         AllClose();
      }

      private void AllClose()
      {
         if( _bw != null)
         {
            _bw.Close();
            _bw = null;
         }
         if(_br != null)
         {
            _br.Close();
            _br = null;
         }
         if(_ns != null)
         {
            _ns.Close();
            _ns = null;
         }
         if(_tcpClient != null)
         {
            _tcpClient.Close();
            _tcpClient = null;
         }
      }

      private void DataSend()
      {
         _bw.Write(_intValue);
         _bw.Write(_floatValue);
         _bw.Write(_strValue);

         MessageBox.Show("보냈습니다.");
      }

      private int DataReceive()
      {
         _intValue = _br.ReadInt32();

         // 항시 종료될 때 -1 값을 보냄
         if(_intValue == -1)
         {
            return -1;
         }

         _floatValue = _br.ReadSingle();
         _strValue = _br.ReadString();
         string str = _intValue + "/" + _floatValue + "/" + _strValue;
         MessageBox.Show(str);

         return 0;
      }

      private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      {
         AllClose();
         _tcpListener.Stop();
      }
   }
}
