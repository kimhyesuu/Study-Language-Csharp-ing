using PrismOutlookTwo.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using PrismOutlookTwo.Module.Mail;
using Prism.Regions;
using System.Windows.Controls.Ribbon;
using PrismOutlookTwo.Core.Regions;

namespace PrismOutlookTwo
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App
   {
      protected override Window CreateShell()
      {
         // 3. createshell 
         // Summary:
         //     Creates the shell or main window of the application.
         //
         // Returns:
         //     The shell of the application.

         //컨테이너는 바로 컨테이너입니다. 매핑을 저장할 수 있습니다.
         //"Resolve"는 인터페이스를 
         //특정 인터페이스 구현의 구체적인 인스턴스로 확인합니다. 
         //그러나 해당 인터페이스에서만 작동하므로 구현을 교환 할 수 있습니다 

         return Container.Resolve<MainWindow>();
      }

      protected override void RegisterTypes(IContainerRegistry containerRegistry)
      {
         // 1. RegisterTypes을 먼저 검사한다. 

         //애플리케이션에서 사용할 컨테이너에 유형을 등록하는 데 사용됩니다.

         //"RegisterType"을 사용하면 일반적으로 인터페이스에 대한 구체적인 클래스를 등록 할 수 있습니다. 
         //그래서 당신은 기본적으로 "이것은 인터페이스입니다. 누군가이 인터페이스가 해결되도록 요청하면
         //구체적인 클래스의 인스턴스를 반환합니다"라고 말합니다. 보시다시피 기본 및 명명 된 유형 매핑을 가질 수 있습니다.
      }

      // IModuleCatalog : Prism.Modularity.IModuleCatalog에있는 모든 Prism.Modularity.IModuleInfo 클래스를 가져옵니다.
      protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
      {
         // 2. ConfigureModuleCatalog 두번째로 무슨 모듈을 먼저 설정할지 본다.
         // Prism에서 사용하는 Prism.Modularity.IModuleCatalog를 설정합니다.
         // moduleCatalog
         // Summary:
         //     Adds a Prism.Modularity.IModuleInfo to the Prism.Modularity.IModuleCatalog.
         //
         // Parameters:
         //   moduleInfo:
         //     The Prism.Modularity.IModuleInfo to add.
         //
         // Returns:
         //     The Prism.Modularity.IModuleCatalog for easily adding multiple modules.
         moduleCatalog.AddModule<MailModule>();

      }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(Ribbon), Container.Resolve<RibbonGroupRegionAdapter>());
        }
    }
}
