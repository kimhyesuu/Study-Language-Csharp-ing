using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Prism.Sample.ModuleC.View;

namespace Prism.Sample.ModuleC
{
    public class CModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry = null;

        public CModule(IRegionViewRegistry regionViewRegistry)
        {
            _regionViewRegistry = regionViewRegistry;
        }
        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion("MainRegion", typeof(CView));
        }
    }
}
