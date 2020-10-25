namespace ModularSample
{
    using ModularSample.Dialog;
    using ModularSample.Views;
    using ModuleA.Models.Module;
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
            //등록을 먼저한사람이 이기네
            rm.RegisterViewWithRegion("TempRegion", typeof(RegionA));
            rm.RegisterViewWithRegion("TempCopyRegion", typeof(RegionB));


            Current.MainWindow.Show();
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<MessageDialog, MessageDialogViewModel>();
            containerRegistry.RegisterDialog<ViewB, ViewBViewModel>();
            containerRegistry.RegisterDialogWindow<MyWindowDialog>();
            //containerRegistry.RegisterDialog<MessageDialog, MessageDialogViewModel>("MyCustomDialog");
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<ModuleAModule>();
        }
    }
}
