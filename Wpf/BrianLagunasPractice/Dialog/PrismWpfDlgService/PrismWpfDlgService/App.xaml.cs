using PrismWpfDlgService.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using PrismWpfDlgService.ViewModels;
using Prism.Services.Dialogs;

namespace PrismWpfDlgService
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //MyDialogService.cs를 생성하고 만든 서비스입니다. 
            // RegisterSingleton 이 녀석이 머하는 지 살펴보자
            containerRegistry.RegisterSingleton<IDialogService, MyDialogService>();
            containerRegistry.RegisterDialog<MyDialog, MyDialogViewModel>();
        }
    }
}
