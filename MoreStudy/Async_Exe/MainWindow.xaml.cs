using System;
using System.Windows;


namespace Async_Exe
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Timer timer = null;

		public MainWindow()
		{
			InitializeComponent();
			
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			timer = new Timer();


		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			AsyncExe();
		}

		private void AsyncExe()
		{
			throw new NotImplementedException();
		}
	}
}
