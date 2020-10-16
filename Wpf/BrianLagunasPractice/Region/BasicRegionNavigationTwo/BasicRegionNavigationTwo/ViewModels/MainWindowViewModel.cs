using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace BasicRegionNavigationTwo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
       // private DelegateCommand<string> _navigateCommand;
       // private IRegionManager _regionManager;

       // public MainWindowViewModel(IRegionManager regionManager)
       // {
       //     this._regionManager = regionManager;
       //    //2. NavigateCommand2 = new DelegateCommand<string>(CurrentView);
       // }

       // public string Title { get => "Prism Application"; }

       // public DelegateCommand<string> NavigateCommand =>
       //     _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(CurrentView));

       //// set에 private이 되어야 되는 데 왜 안되지 
       //// 2. private DelegateCommand<string> NavigateCommand2 { get; set; }

       // private void CurrentView(string obj)
       // {
       //     if (obj is null) return;
       //     _regionManager.RequestNavigate("ContentRegion", obj, Callback);
       //     //1. _regionManager.RequestNavigate("ContentRegion", obj);
       // }

       // private void Callback(NavigationResult result)
       // {
       //     if (result.Error is null) return; 

       //     //handle error
       // }
    }
}
