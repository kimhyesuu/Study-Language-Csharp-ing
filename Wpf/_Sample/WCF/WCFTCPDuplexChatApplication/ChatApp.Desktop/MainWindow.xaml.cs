using ChatApp.Desktop.Views;
using System.Windows;

namespace ChatApp.Desktop
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
    

      public MainWindow()
      {
         InitializeComponent();
      }

      public Main MainView { get; set; }
   }
}
