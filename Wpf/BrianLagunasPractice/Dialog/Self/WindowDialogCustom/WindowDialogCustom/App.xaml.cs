using System.Windows;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism.Unity;
using WindowDialogCustom.Dialogs;
using WindowDialogCustom.Views;
using DialogWindow = WindowDialogCustom.Dialogs.DialogWindow;

namespace WindowDialogCustom
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

        protected override void OnInitialized()
        {
            var rm = Container.Resolve<IRegionManager>();
            //등록을 먼저한사람이 이기네
            rm.RegisterViewWithRegion("pleaseCopyRegion", typeof(ViewB));
            rm.RegisterViewWithRegion("pleaseRegion", typeof(ViewA));
     

            Current.MainWindow.Show();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            
            
   
            //MyDialogService.cs를 생성하고 만든 서비스입니다. 
            // RegisterSingleton 이 녀석이 머하는 지 살펴보자
            // containerRegistry.RegisterSingleton<IDialogService, DialogService>();
            containerRegistry.RegisterDialog<MyDialog, MyDialogViewModel>();
            containerRegistry.RegisterDialog<ViewCDialog, ViewCDialogViewModel>();
            containerRegistry.RegisterDialogWindow<MyDialogWindow>();
            
        }
    }
}
