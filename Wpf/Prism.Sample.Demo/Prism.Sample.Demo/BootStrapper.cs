using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Prism.Sample.ModuleA;
using Prism.Sample.ModuleB;
using Prism.Sample.ModuleC;
using Prism.Sample.ModuleD;
using System.Windows;

namespace Prism.Sample.Demo
{
    public class BootStrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<PrismShell>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            Application.Current.MainWindow = (PrismShell)Shell;
            Application.Current.MainWindow.Show();
        }
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(AModule));
            moduleCatalog.AddModule(typeof(BModule));
            moduleCatalog.AddModule(typeof(CModule));
            moduleCatalog.AddModule(typeof(DModule));
        }
    }
}
