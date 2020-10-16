using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Prism.Sample.ModuleB.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Sample.ModuleB
{
    public class BModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry = null;

        public BModule(IRegionViewRegistry regionViewRegistry)
        {
            _regionViewRegistry = regionViewRegistry;
        }
        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion("LeftRegion", typeof(BView));
        }
    }
}
