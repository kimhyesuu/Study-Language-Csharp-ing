using Behavior.ViewModels;
using System.Windows;

namespace Behavior
{

   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
         this.DataContext = new MainViewModel();
      }
   }
}
