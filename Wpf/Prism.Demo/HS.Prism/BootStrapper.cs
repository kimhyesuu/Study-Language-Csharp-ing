
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HS.Prism.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Unity;

namespace HS.Prism
{
   public class BootStrapper : UnityBootstrapper
   {
      public override void Run(bool runWithDefaultConfiguration)
      {
         base.Run(runWithDefaultConfiguration);
      }

      //Create the shell
      //show the shell window
      protected override DependencyObject CreateShell()
      {
         return Container.Resolve<HSView>();
      }

      protected override void InitializeShell()
      {
         //Set Main window for prism
         App.Current.MainWindow = Shell as Window;
         App.Current.MainWindow.Show();

      }

      protected override void ConfigureModuleCatalog()
      {
         //user once we create a module
         base.ConfigureModuleCatalog();
      }
   }
}
