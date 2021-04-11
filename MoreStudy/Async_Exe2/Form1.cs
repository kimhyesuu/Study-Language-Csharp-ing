using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async_Exe2
{
	public partial class Form1 : Form
	{
		System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

		public Form1()
		{
			InitializeComponent();
			 
		}

		private void button1_Click(object sender, EventArgs e)
		{
			timer.Tick += Timer_Tick;

			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < 10; i++)
			{
				richTextBox1.AppendText("*");
				Thread.Sleep(50);
			}

			for (int i = 0; i < 10; i++)
			{
				richTextBox1.AppendText(i.ToString());
				Thread.Sleep(50);
			}
		}

		private async void button2_Click(object sender, EventArgs e)
		{
			await AsyncExe();
		}

		private async Task AsyncExe()
		{
			await Task.Run(() => Test());
			await Task.Run(() => Test1());
		}

		private void Test()
		{
			for (int i = 0; i < 10; i++)
			{
				if (richTextBox1.InvokeRequired)
				{
					richTextBox1.BeginInvoke(new Action(() => richTextBox1.AppendText("*")));
				}
				else
				{
					richTextBox1.AppendText("*");
				}

				Thread.Sleep(50);
			}

			for (int i = 0; i < 10; i++)
			{
				if (richTextBox1.InvokeRequired)
				{
					richTextBox1.BeginInvoke(new Action(() => richTextBox1.AppendText(i.ToString())));
				}
				else
				{
					richTextBox1.AppendText(i.ToString());
				}
				Thread.Sleep(50);
			}
		}

		private void Test1()
		{
			for (int i = 0; i < 10; i++)
			{
				if(richTextBox1.InvokeRequired)
				{
					richTextBox1.BeginInvoke(new Action(() => richTextBox1.AppendText(i.ToString())));
				}
				else
				{
					richTextBox1.AppendText(i.ToString());
				}
				Thread.Sleep(50);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			var t1 = new Thread(new ThreadStart(Test));
			var t2 = new Thread(new ThreadStart(Test1));

			t1.IsBackground = false;
			t2.IsBackground = true;
			t2.Start();
			t1.Start();
		}
	}
}
