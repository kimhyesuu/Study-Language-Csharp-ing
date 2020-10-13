using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace PrismWpfDlgService.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        //1번째
        private DelegateCommand _showDialogCommand;

        public DelegateCommand ShowDialogCommand =>
            _showDialogCommand ?? (_showDialogCommand = new DelegateCommand(ExecuteShowDialogCommand));

        private void ExecuteShowDialogCommand()
        {
            _dialogService.Show("MyDialog", null, r =>
            {

            });

            
        }

        //2번째
        private IDialogService _dialogService;
        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
    }
}
