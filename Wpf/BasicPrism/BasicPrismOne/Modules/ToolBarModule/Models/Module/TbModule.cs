using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBarModule.Views;

namespace ToolBarModule.Models.Module
{
    public class TbModule : IModule, INotifyPropertyChanged
    {
        // 두개를 하려면 IRegionManager
        private readonly IRegionViewRegistry _regionViewRegistry = null;

        //첫번째 생성됨
        public TbModule(IRegionViewRegistry regionViewRegistry)
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
