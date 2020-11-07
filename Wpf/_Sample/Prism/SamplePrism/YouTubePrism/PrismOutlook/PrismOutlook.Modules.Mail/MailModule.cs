using PrismOutlook.Modules.Mail.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismOutlook.Core;
using Prism.Events;
using PrismOutlook.Modules.Mail.Menus;

namespace PrismOutlook.Modules.Mail
{
   public class MailModule : IModule
   {
      private readonly IRegionManager _regionManager;

      public MailModule(IRegionManager regionManager)
      {
         this._regionManager = regionManager;

         // 이 습관은 안좋은 습관입니다.
         //_regionManager = CommonServiceLocator.GetService<ffef>();

      }
      public void OnInitialized(IContainerProvider containerProvider)
      {
         //TODO: remove
         _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ViewA));

         _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(HomeTab));
      }

      public void RegisterTypes(IContainerRegistry containerRegistry)
      {
         
      }
   }
}