using PrismOutlook.Modules.Contact.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Modules.Contact.Menus;

namespace PrismOutlook.Modules.Contact
{
   public class ContactModule : IModule
   {
      private readonly IRegionManager _regionManager;

      public ContactModule(IRegionManager regionManager)
      {
         this._regionManager = regionManager;
      }

      public void OnInitialized(IContainerProvider containerProvider)
      {
         _regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(ContactsGroup));
      }

      public void RegisterTypes(IContainerRegistry containerRegistry)
      {

      }
   }
}