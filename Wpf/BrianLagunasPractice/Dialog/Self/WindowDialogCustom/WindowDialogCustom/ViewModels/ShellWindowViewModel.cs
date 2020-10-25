using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowDialogCustom.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        private DelegateCommand _showDialogCommand;

        public DelegateCommand ShowDialogCommand =>
            _showDialogCommand ?? (_showDialogCommand = new DelegateCommand(ExecuteShowDialogCommand));

        private void ExecuteShowDialogCommand()
        {
            _regionManager.RequestNavigate("pleaseRegion", "ViewA");

           _dialogService.Show("MyDialog", null, r =>
            {

            });

       


            //var window = _dialogService.Show("MyDialog", null, r =>
            //{

            //});

            //window.Active();
        }


        private DelegateCommand _showDialogCopyCommand;

        public DelegateCommand ShowDialogCopyCommand =>
            _showDialogCopyCommand ?? (_showDialogCopyCommand = new DelegateCommand(ExecuteShowDialogCopyCommand));

        private void ExecuteShowDialogCopyCommand()
        {
            _regionManager.RequestNavigate("pleaseCopyRegion", "ViewB");

            _dialogService.ShowDialog("ViewCDialog", null, r =>
            {

            });


        }

        //2번째a
        private IDialogService _dialogService;
        private IRegionManager _regionManager;
        public ShellWindowViewModel(IDialogService dialogService, IRegionManager regionManager)
        {
            this._dialogService = dialogService;
            this._regionManager = regionManager;
        }
    }
}
