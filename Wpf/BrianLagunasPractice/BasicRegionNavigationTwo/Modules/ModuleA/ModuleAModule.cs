using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private IRegionManager _regionManager;
        public ModuleAModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("ContentRegion",typeof(PersonList));
            // param : IRegionManager
            // regionManager.RegisterViewWithRegion("ContentRegion", typeof(PersonList));
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
            //var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(PersonList));

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PersonDetail>();
        }
    }
}