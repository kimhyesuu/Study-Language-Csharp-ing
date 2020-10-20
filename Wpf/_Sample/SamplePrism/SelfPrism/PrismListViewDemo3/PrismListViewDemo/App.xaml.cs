using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using PrismListViewDemo.Views;
using UserList.Models.Module;

namespace PrismListViewDemo
{
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
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<UserListModule>();
        }
    }
}
