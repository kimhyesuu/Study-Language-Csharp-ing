using PrismOutlookTwo.Module.Mail.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismOutlookTwo.Core;
using PrismOutlookTwo.Module.Mail.Menus;

namespace PrismOutlookTwo.Module.Mail
{
   public class MailModule : IModule
   {
      private readonly IRegionManager _regionManager;

      public MailModule(IRegionManager regionManager)
      {
         this._regionManager = regionManager;
      }

      public void OnInitialized(IContainerProvider containerProvider)
      {
         _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion,typeof(ViewA));
         _regionManager.RegisterViewWithRegion(RegionNames.RibbonGroupRegion, typeof(HomeTab));
            //2
        }

      public void RegisterTypes(IContainerRegistry containerRegistry)
      {
         //1
      }
   }
}