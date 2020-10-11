using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;

namespace PrismOutlookTwo.Core.Regions
{
    public class RibbonGroupRegionAdapter : RegionAdapterBase<Ribbon>
    {
        public RibbonGroupRegionAdapter(IRegionBehaviorFactory behaviorFactory)
           : base(behaviorFactory)
        {
        }


        protected override void Adapt(IRegion region, Ribbon regionTarget)
        {
            if (region is null) throw new ArgumentNullException(nameof(region));
            if (regionTarget is null) throw new ArgumentNullException(nameof(regionTarget));

            region.Views.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (var view in e.NewItems)
                        {
                            AddViewToRegion(view,regionTarget);                            
                        }
                        break;

                    case NotifyCollectionChangedAction.Remove:
                        foreach (var view in e.OldItems)
                        {
                            RemoveViewToRegion(view, regionTarget);
                        }
                        break;
                }
            };


        } 

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }


        private static void RemoveViewToRegion(object view, Ribbon regionTarget)
        {
            if (view is null) return;
            regionTarget.Items.Add(view);
        }

        private static void AddViewToRegion(object view, Ribbon regionTarget)
        {
            if (view is null) return;
            regionTarget.Items.Remove(view);
        }
    }
}
