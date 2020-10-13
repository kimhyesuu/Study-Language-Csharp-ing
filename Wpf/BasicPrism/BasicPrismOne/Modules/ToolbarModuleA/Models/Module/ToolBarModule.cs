using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolbarModuleA.Views;

namespace ToolbarModuleA.Models.Module
{
    public class ToolBarModule : IModule, INotifyPropertyChanged
    {
        // 두개를 하려면 IRegionManager
        private readonly IRegionViewRegistry _regionViewRegistry = null;

        //첫번째 생성됨
        public ToolBarModule(IRegionViewRegistry regionViewRegistry)
        {
            this._regionViewRegistry = regionViewRegistry;
        }

        public void Initialize()
        {
            this._regionViewRegistry.RegisterViewWithRegion("HeaderRegion", typeof(ToolBarView));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
