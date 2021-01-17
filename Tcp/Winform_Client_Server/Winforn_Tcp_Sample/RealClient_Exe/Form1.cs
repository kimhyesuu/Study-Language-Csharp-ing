using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealClient_Exe
{
   public partial class Form1 : Form
   {
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

      }

      private void btn_ConnectAddress_Click(object sender, EventArgs e)
      {
         _tcpClient = new TcpClient(tb_Address.Text,8380);

         if(_tcpClient.Connected)
         {
            _ns = _tcpClient.GetStream();
            _br = new BinaryReader(_ns);
            _bw = new BinaryWriter(_ns);
            MessageBox.Show("서버 접속 성공");
         }
         else
         {
            MessageBox.Show("서버 접속 실패");
         }
      }

      private void btn_SendAndReceive_Click(object sender, EventArgs e)
      {
         //쓰기
         _bw.Write(int.Parse(tb_intData.Text));
         _bw.Write(float.Parse(tb_floatData.Text));
         _bw.Write(tb_strData.Text);

         _intValue = _br.ReadInt32();
         _floatValue = _br.ReadSingle();
         _strValue = _br.ReadString();

         string str = $"{_intValue} /" +
            $" {_floatValue} /" +
            $" {_strValue}";

         MessageBox.Show(str);
      }

      private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      {
         _bw.Write(-1);
         _bw.Close();
         _br.Close();
         _ns.Close();
         _tcpClient.Close();
      }
   }
}
