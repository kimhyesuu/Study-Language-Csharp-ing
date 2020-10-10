using Microsoft.Windows.Controls.Ribbon;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismOutlook.Core.Region
{
    public class RibbonTabRegionAdapter : RegionAdapterBase<Ribbon>
   {
      public RibbonTabRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
          : base(regionBehaviorFactory)
      {
      }

      protected override void Adapt(IRegion region, Ribbon regionTarget)
      {
         if (region == null) throw new ArgumentNullException(nameof(region));
         if (regionTarget == null) throw new ArgumentNullException(nameof(regionTarget));

         region.Views.CollectionChanged += (s, e) =>
         {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
               foreach (var element in e.NewItems)
               {
                  regionTarget.Items.Add(element);
               }

            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
               foreach (var view in e.OldItems)
               {
                  RemoveViewFromRegion(view, regionTarget);
               }
            }
         };
      }

      protected override IRegion CreateRegion()
      {
         return new SingleActiveRegion();
      }

      static void AddViewToRegion(object view, Ribbon regionTarget)
      {
         if (view is RibbonTab ribbonTabItem)
         {
            regionTarget.Items.Add(ribbonTabItem);
         }
      }

      static void RemoveViewFromRegion(object view, Ribbon regionTarget)
      {
         if (view is RibbonTab ribbonTabItem)
         {
            regionTarget.Items.Add(ribbonTabItem);
         }
      }
   }
}
