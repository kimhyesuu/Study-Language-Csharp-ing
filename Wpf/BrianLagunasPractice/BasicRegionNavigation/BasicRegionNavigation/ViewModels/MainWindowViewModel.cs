using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace BasicRegionNavigation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        
        private IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
        }

        public string Title { get => "Prism Application"; }

        private DelegateCommand<string> _navigateCommand;

        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(CurrentView));

        private void CurrentView(string obj)
        {
            if (obj is null) return; 
            _regionManager.RequestNavigate("ContentRegion", obj);
        }

    
    }
}
