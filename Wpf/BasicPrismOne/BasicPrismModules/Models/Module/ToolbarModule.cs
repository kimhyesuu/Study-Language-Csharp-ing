using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrismModules.Models.Module
{
    using BasicPrismModules.Views;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    
    using System.ComponentModel;

    public class ToolbarModule : IModule, INotifyPropertyChanged
    {
        // 두개를 하려면 IRegionManager
        private readonly IRegionManager _regionManager = null;

        //첫번째 생성됨
        public ToolbarModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
        }


        public void Initialize()
        {
            this._regionManager.RegisterViewWithRegion("HeaderRegion", typeof(ToolbarView));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
