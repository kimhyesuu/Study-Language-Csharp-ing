using BasicPrismOne.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;

namespace BasicPrismOne.Core.Common
{
    public class BootStrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.TryResolve<ShellWindow>();
        }
        protected override void InitializeModules()
        {
            base.InitializeModules();
            App.Current.MainWindow = this.Shell as ShellWindow;
            App.Current.MainWindow.Show();
        }
        protected override void ConfigureModuleCatalog()
        {
            //모듈 추가 했으니깐 카탈로그 모듈 필요하겠지?
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = this.ModuleCatalog as ModuleCatalog;
            moduleCatalog.AddModule(typeof(ToolbarModuleA.Models.Module.ToolBarModule));

            //base.ConfigureModuleCatalog();
            //this.ModuleCatalog.AddModule(null); // (Placeholder)  
        }
    }
}
