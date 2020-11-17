using System.Windows;
using EventAggregator.Views;
using ModuleA.Models.Module;
using ModuleB.Models.Module;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

namespace EventAggregator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
          
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            var moduleAType = typeof(ModuleBModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
               ModuleName = moduleAType.Name,
               ModuleType = moduleAType.AssemblyQualifiedName,
               InitializationMode = InitializationMode.OnDemand
            });
         }
    }
}
