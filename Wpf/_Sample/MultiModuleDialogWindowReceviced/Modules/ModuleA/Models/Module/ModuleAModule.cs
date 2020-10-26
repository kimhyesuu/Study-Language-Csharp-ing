using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;

namespace ModuleA.Models.Module
{
    public class ModuleAModule : IModule
    {
        private IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("LeftRegion",typeof(MessageView));
        }


        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
