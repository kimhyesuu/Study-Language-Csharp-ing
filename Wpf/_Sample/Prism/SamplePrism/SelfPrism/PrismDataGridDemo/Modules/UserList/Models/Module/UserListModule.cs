using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismListViewDemo.Core;
using UserList.Views;

namespace UserList.Models.Module
{
    public class UserListModule : IModule
    {
        private IRegionManager _regionManager;

        public UserListModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion,typeof(UserListView));
        }


        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
        }
    }
}
