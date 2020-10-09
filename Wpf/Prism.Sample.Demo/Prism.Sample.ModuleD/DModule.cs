using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Prism.Sample.ModuleD.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Sample.ModuleD
{
    public class DModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry = null;

        public DModule(IRegionViewRegistry regionViewRegistry)
        {
            _regionViewRegistry = regionViewRegistry;
        }
        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion("BottomRegion", typeof(DView));
        }
    }
}
