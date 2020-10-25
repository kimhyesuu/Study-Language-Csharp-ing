using Prism.Regions;

namespace ModularSample.Core
{
    public static class Navigation
    {
        public static void ViewLocation(IRegionManager regionManager, string regionName, string viewName)
        {
            regionManager.RequestNavigate(regionName, viewName);
        }
    }
}
