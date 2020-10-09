using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PrismOutlook.Core.Region
{
   public class OutlookGroupRegionAdapter : RegionAdapterBase<ListBox>
   {
      public OutlookGroupRegionAdapter(IRegionBehaviorFactory factory)
         : base(factory)   
      {

      }

      protected override void Adapt(IRegion region, ListBox regionTarget)
      {
         region.ActiveViews.CollectionChanged += ((x, y) =>
         {
            switch(y.Action)
            {
               case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                  {
                     foreach(var group in y.NewItems)
                     {
                        //여기서 멀하고싶은거냐
                        
                        //if(regionTarget.Groups)
                     }
                     break;
                  }
            }
         });
      }

      protected override IRegion CreateRegion()
      {
         return new SingleActiveRegion();
      }
   }
}
