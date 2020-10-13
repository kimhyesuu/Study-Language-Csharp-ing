using BasicRegionPractice.Core.Regions;
using BasicRegionPractice.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace BasicRegionPractice
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
        #region OnInitialized() Initialize() 차이점
        //  OnInitialized() : Contains actions that should occur last.
        //  Initialize(); : Runs the initialization sequence to configure the Prism application.
        #endregion
        protected override void OnInitialized()
        {
            var rm = Container.Resolve<IRegionManager>();
            ////버튼 생성하고
            //var button = new Button()
            //{
            //    Content = "Hello",
            //    Width = 200,
            //    Height = 300
            //};

            // prism:RegionManager.RegionName="ContentRegion" 의 타입은 button이다...
            #region RegisterViewWithRegion와 ServiceLocator 설명
            // RegisterViewWithRegion

            // View를 Region과 함께 연관시켜서 등록합니다...
            // Displayed this Type은 ServiceLocator를 사용하여 구체적인 
            // 인스턴스가 Region의 Views Collection에 추가된다...


            // ServiceLocator

            // app의 주변 Container를 제공합니다. 
            // 프레임워크가 이러한 주변 컨테이너를 정의하고
            // ServiceLocator.current를 사용하여 가져온다.
            #endregion
            rm.RegisterViewWithRegion("ContentRegion", typeof(Button));

        
             Current.MainWindow.Show();


        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(null);

        }

        //IContainerRegistry : Prism.Ioc(의존성 주입)
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }




        #region ConfigureRegionAdapterMappings 설명
        //

        // 응용 프로그램에서 사용할 기본 지역 어댑터 매핑을 구성합니다.
        // XAML에 정의 된 UI 컨트롤을 조정하여 지역을 사용하고 자동으로 등록합니다.
        // 파생 클래스에서 덮어 써서 필요한 특정 매핑을 추가 할 수 있습니다.

        // Summary:
        //     Configures the default region adapter mappings to use in the application, in
        //     order to adapt UI controls defined in XAML to use a region and register it automatically.
        //     May be overwritten in a derived class to add specific mappings required by the
        //     application.
        //
        // Returns:
        //     The Prism.Regions.RegionAdapterMappings instance containing all the mappings.
        #endregion

        #region RegionAdapterMappings 설명
        //

        // Summary:
        //     Registers the mapping between a type and an adapter.
        //
        // Parameters:
        //   controlType:
        //     The type of the control.
        //
        //   adapter:
        //     The adapter to use with the controlType type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     When any of controlType or adapter are null.
        //
        //   T:System.InvalidOperationException:
        //     If a mapping for controlType already exists.
        #endregion
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {

            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            
            //개체를 해결하는 데 사용되는 종속성 주입 컨테이너
            regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
        }
    }
}
