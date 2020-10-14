using CustomRegionAdapter.Core.Regions;
using CustomRegionAdapter.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace CustomRegionAdapter
{
    /// <summary>
    /// Seq 초기화 : RegisterTypes -> ConfigureRegionAdapterMappings -> StackPanelRegionAdapter(Construtor)
    ///             CreateShell -> MainWindow(Constructor) -> CreateRegion -> Adapt  -> windowprogram.run
    ///           
    /// Event 발생 시 : Event(ex. button Click)->  Adapt -> rotation 
    /// </summary>
    public partial class App
    {
        #region Seq_4 CreateShell 설명
        // 타입과 맵핑을 정했고, 이제 container는 MainWindow로 해결
        #endregion
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        #region Seq_1 RegisterTypes 설명
        //1. RegisterTypes에서 IContainerRegistry라는 인터페이스를 파라미터로 받았습니다
        //2. PrismApplicationBase 에는 IContainerProvider을 받는 구간이 있음
        //3. base에 IContainerExtension ->  IContainerExtension : IContainerProvider, IContainerRegistry 상속을 받았으며
        //4. containerRegistry(IContainerRegistry)에서 RegisterForNavigation(IContainerExtension)로 연결이 가능하게 만들었음
        //의문점 인터페이스의 Method.인터페이스 Method가 가능한거니 찾아볼것
        //5. RegisterForNavigation에서 ViewA라는 Object로 등록했음
        #endregion
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
                    
            containerRegistry.RegisterForNavigation<ViewA>();
        }

        #region Seq_2 ConfigureRegionAdapterMappings 설명
        // 1. ConfigureRegionAdapterMappings : Region 개조를 어떤 식으로 Mapping할지 궁리해라
        // 2. RegionAdapterMappings의 파라미터를 받고 이 값을 base에 보낸다.
        // 3. base.ConfigureRegionAdapterMappings에 파라미터를 보낸다.
        // 응용 프로그램에서 사용할 기본 지역 어댑터 매핑을 구성합니다.
        // XAML에 정의 된 UI 컨트롤을 조정하여 지역을 사용하고 자동으로 등록합니다.
        // 파생 클래스에서 덮어 써서 필요한 특정 매핑을 추가 할 수 있습니다.
        // 4. regionAdapterMappings.RegisterMapping : 맵핑할 것을 등록해야댄다. ui타입은 stackpanel로 등록했고 이를 StackPanelRegionAdapter라는 걸로
        // 어떤 걸로 변할 지 만들어주는 것입니다.  
        #endregion
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(StackPanel),  Container.Resolve<StackPanelRegionAdapter>());
            // IRegionAdapter adapter = Container.Resolve<StackPanelRegionAdapter>();
            // IContainerProvider의 Container의  인터페이스 adapter

        }
    }
}
