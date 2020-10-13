using BasicPrism.Views;
using Microsoft.Practices.Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrism.Common
{
    public class BootStrapper : UnityBootstrapper // using Prism.Unity;
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return this.Container.TryResolve<MainWindow>();
        }
        protected override void InitializeModules()
        {
            base.InitializeModules();
            App.Current.MainWindow = this.Shell as MainWindow;
            App.Current.MainWindow.Show();
        }
        protected override void ConfigureModuleCatalog()
        {
            //모듈 추가 했으니깐 카탈로그 모듈 필요하겠지?
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.ad


            //base.ConfigureModuleCatalog();
            //this.ModuleCatalog.AddModule(null); // (Placeholder)  
        }
    }
}
