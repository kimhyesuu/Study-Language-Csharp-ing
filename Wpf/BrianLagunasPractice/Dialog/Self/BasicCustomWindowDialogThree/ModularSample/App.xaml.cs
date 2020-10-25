namespace ModularSample
{
    using ModularSample.Dialog;
    using ModularSample.Views;
    using ModuleA.Models.Module;
    using ModuleA.Views;
    using ModuleB;
    using ModuleB.Views;
    using Prism.DryIoc;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using System.Windows;


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        protected override void OnInitialized()
        {
            var rm = Container.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion("PleaseRegion", typeof(ViewB));
            rm.RegisterViewWithRegion("PleaseRegion",typeof(ViewA));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<MessageDialog, MessageDialogViewModel>();
            containerRegistry.RegisterDialogWindow<MyWindowDialog>();
            //containerRegistry.RegisterDialog<MessageDialog, MessageDialogViewModel>("MyCustomDialog");
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<ModuleAModule>();
            moduleCatalog.AddModule<ModuleBModule>();
        }
    }
}
