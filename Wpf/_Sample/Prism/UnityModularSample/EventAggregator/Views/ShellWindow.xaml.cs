using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EventAggregator.Views
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : Window
    {
      IModuleManager _moduleManager;

      public ShellWindow(IModuleManager moduleManager)
        {
            InitializeComponent();
         _moduleManager = moduleManager;
      }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         _moduleManager.LoadModule("ModuleBModule");
      }
   }
}
