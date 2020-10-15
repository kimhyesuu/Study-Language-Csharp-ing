using BasicRegionNavigation.Views;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace BasicRegionNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    
        // 혹은 bootstrapper를 사용
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
        }
    }
}
