
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismModules.Models
{
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using PrismModules.Views;
    using System.ComponentModel;

    public class ToolbarModule : IModule, INotifyPropertyChanged
    {
        // 두개를 하려면 IRegionManager
        private readonly IRegionViewRegistry _regionViewRegistry = null;

        //첫번째 생성됨
        public ToolbarModule(IRegionViewRegistry regionViewRegistry)
        {
            this._regionViewRegistry = regionViewRegistry;
        }

    
        public void Initialize()
        {
            this._regionViewRegistry.RegisterViewWithRegion("HeaderRegion", typeof(ToolbarWindow));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
