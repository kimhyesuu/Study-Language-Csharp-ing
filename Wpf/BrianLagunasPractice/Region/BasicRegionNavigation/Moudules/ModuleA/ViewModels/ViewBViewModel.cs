using Prism.Mvvm;
using Prism.Regions;
using System;

namespace ModuleA.ViewModels
{
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        #region Construtor

        public ViewBViewModel()
        {

        }

        #endregion

        #region property
        public string Message { get => "ViewB"; }


        private int _pageViews;
        public int PageViews
        {
            get { return _pageViews; }
            set { SetProperty(ref _pageViews, value); }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViews++;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
      
        }
        #endregion
    }
}

