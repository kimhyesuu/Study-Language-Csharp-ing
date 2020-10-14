using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomRegionAdapter.Core.Regions
{
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        #region Seq_3 StackPanelRegionAdapter 설명
        // Constructor로 넘어와서 RegionAdapterBase에게 regionBehaviorFactory을 보내서 사용해도 되는가
        #endregion
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        #region Seq_7 Adapt 설명
        // 초기화할 것 있는 지 확인한다.
        #endregion
        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    //FrameworkElement는 var로 받을 수 없네
                    foreach (FrameworkElement element in e.NewItems)
                    {
                        regionTarget.Children.Add(element);
                    }
                }
                else if(e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach(FrameworkElement element in e.OldItems)
                    {
                        regionTarget.Children.Add(element);
                    }
                }
            };
        }

        #region Seq_6 CreateRegion 설명
        // container.Resolve -> 생성자 -> CreateRegion으로 옴 
        #endregion
        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
