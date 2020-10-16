

namespace BasicRegionPractice.Core.Regions
{
    using System.Collections.Specialized;
    using System.Windows;
    using System.Windows.Controls;
    using Prism.Regions;

    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        #region base 키워드 설명 및 RegionAdapterBase 설명
        //StackPanelRegionAdapter 클래스를 생성할 때 StackPanelRegionAdapter 의 부모 클래스인 RegionAdapterBase 클래스의 생성자를 호출하여 값을 초기화한다는 의미입니다.

        //1. StackPanelRegionAdapter 클래스의 새 개체를 생성함(Instance 를 만든다고 하죠)

        //2. StackPanelRegionAdapter 클래스의 생성자를 호출.....하다가 : base 를 발견합니다.

        //3. RegionAdapterBase 클래스의 생성자를 호출합니다.

        //4. StackPanelRegionAdapter 클래스의 생성자 본문을 실행합니다.

        //5. StackPanelRegionAdapter 클래스의 새 개체가 생성됩니다. (끝)

        // Summary:
        //     Initializes a new instance of Prism.Regions.RegionAdapterBase`1.
        //
        // Parameters:
        //   regionBehaviorFactory:
        //     The factory used to create the region behaviors to attach to the created regions
        #endregion
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }



        #region  Adapt 설명
        //
        // Summary:
        //     Initializes a new instance of Prism.Regions.RegionAdapterBase`1.
        //
        // Parameters:
        //   regionBehaviorFactory:
        //     The factory used to create the region behaviors to attach to the created regions.

        // Parameters:
        //   region:
        //     The region being used.
        //
        //   regionTarget:
        //     The object to adapt.
        #endregion
        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            #region Views ActiveViews 차이점 설명
            // Occurs when the collection changes.
            // Views
            // ActiveViews : CreateRegion() AllActiveRegion(ex> ListView), SingleActiveRegion(ex> Tab)

            //    그러니 그렇게 생각하십시오.
            //    이제 이것은 영역 동작을 시작할 때 유용합니다.
            //    또는 활성 뷰에 반응하고 싶을 때 
            //    활성 뷰와 같은 일을 할 때 유용합니다.
            #endregion
            region.Views.CollectionChanged += (s, e) =>
            {
                #region NotifyCollectionChangedAction enum Type 설명
                //  using System.Collections.Specialized;
                // Summary:
                //     An item was added to the collection.
                //    Add = 0,
                //
                // Summary:
                //     An item was removed from the collection.
                // Remove = 1,
                //
                // Summary:
                //     An item was replaced in the collection.
                //  Replace = 2,
                //
                // Summary:
                //     An item was moved within the collection.
                // Move = 3,
                //
                // Summary:
                //     The content of the collection was cleared.
                //Reset = 4
                #endregion
                if (e.Action == NotifyCollectionChangedAction.Add)
                {

                    #region FrameworkElement 설명
                    //   using System.Windows;
                    // window resource를 가지고 있는 자원
                    #endregion
                    foreach (FrameworkElement element in e.NewItems)
                    {
                        #region regionTarget.Children.Add(element); 설명
                        // regionTarget - stackpanel 
                        // Children : 패널의 자식 요소의 UiElementCollection를 가져와라
                        // stackpanel의 요소를 더하기위해서만 사용하는 것

                        // Add : 가져온 UiElementCollection를 특정 요소에 더해라
                        #endregion
                        regionTarget.Children.Add(element);
                    }
                    //implement remove
                }
                else if(e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (FrameworkElement element in e.OldItems)
                    {                      
                        regionTarget.Children.Remove(element);
                    }
                }
            };
        }


        // Summary:
        //     Template method to create a new instance of Prism.Regions.IRegion that will be
        //     used to adapt the object.
        protected override IRegion CreateRegion()
        {
            #region Region SingleActiveRegion AllActiveRegion 차이점

            //질문: 무슨 차이냐

            //-SingleActiveRegion 
            // tabcontrol처럼 하나만 액티브할 때 필요
            // Marks the specified view as active. - 지정된 View를 활성화시켜줍니다.

            // Parameters:
            //   view:
            //     The view to activate.
            // Remarks:
            //     If there is an active view before calling this method, that view will be deactivated
            //     automatically.

            //- AllActiveRegion : Deactive is not valid in this Region.
            // Listview 처럼 여러가지 액티브될 때 필요
            //This method will always throw System.InvalidOperationException.
            // - 이 Region에선 항상 활성화되어야합니다.

            //예시
            //public void DeactivateThrows()
            //{
            //    IRegion region = new AllActiveRegion();
            //    var view = new object();
            //    region.Add(view);

            //    region.Deactivate(view);
            //}

            // Parameters:
            //   view:
            //     The view to deactivate.

            // This method will always throw System.InvalidOperationException.
            //- Region : Initializes a new instance of Prism.Regions.Region.
            #endregion
            return new Region();
          
        }
    }
}
