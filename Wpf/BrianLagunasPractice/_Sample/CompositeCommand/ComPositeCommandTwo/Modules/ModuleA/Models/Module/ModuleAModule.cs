using BasicCompositeCommand.Core.Enum;
using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA.Models.Module
{
    public class ModuleAModule : IModule
    {
        private IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
          // _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(TabButton));
        }


        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegion region = _regionManager.Regions[RegionNames.ContentRegion];

            var tabA = containerProvider.Resolve<TabButton>();
            SetTitle(tabA, "Tab A");
            region.Add(tabA);

            var tabB = containerProvider.Resolve<TabButton>();
            SetTitle(tabB, "Tab B");
            region.Add(tabB);

            var tabC = containerProvider.Resolve<TabButton>();
            SetTitle(tabC, "Tab C");
            region.Add(tabC);
        }

        private void SetTitle(TabButton tabButton, string title)
        {
            (tabButton.DataContext as TabButtonViewModel).Title = title;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
