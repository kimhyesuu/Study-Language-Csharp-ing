using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Prism.Sample.ModuleA.View;

namespace Prism.Sample.ModuleA
{
    public class AModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry=null;

        public AModule(IRegionViewRegistry regionViewRegistry)
        {
            _regionViewRegistry = regionViewRegistry;
        }
        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion("RibbonRegion", typeof(AView));
        }
    }
}
