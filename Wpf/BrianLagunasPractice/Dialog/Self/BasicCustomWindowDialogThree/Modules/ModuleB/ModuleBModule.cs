using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Diagnostics;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {

        private IRegionManager _regionManager;

        public ModuleBModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("RegisterRegion", typeof(ViewB));
            _regionManager.RegisterViewWithRegion("RegisterRegion", typeof(ViewC));
            //_regionManager.RegisterViewWithRegion("RegisterRegion", typeof(ViewB));
            //_regionManager.RegisterViewWithRegion("RegisterRegion", typeof(ViewC));

            Debug.WriteLine(_regionManager.RegisterViewWithRegion("RegisterRegion", typeof(ViewB)));
            Debug.WriteLine(_regionManager.RegisterViewWithRegion("RegisterRegion", typeof(ViewC)));
            //IRegion registerRegion = regionManager.Regions["RegisterRegion"];
            ////InboxView view = this.container.Resolve<InboxView>();
            //registerRegion.Add(typeof(ViewB));
            //registerRegion.Add(typeof(ViewC));
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<ViewC>();
        }
    }
}
