using EventAggregator.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {
        private DelegateCommand _showDialogCommand;
        public DelegateCommand ShowDialogCommand =>
            _showDialogCommand ?? (_showDialogCommand = new DelegateCommand(ShowDialog));

        private DelegateCommand _showDialogCopyCommand;
        public DelegateCommand ShowDialogCopyCommand =>
            _showDialogCopyCommand ?? (_showDialogCopyCommand = new DelegateCommand(ShowDialogCopy));
        //버튼을 만들기 전에 동작되는 지 확인바람

        private void ShowDialogCopy()
        {
            _dialogService.ShowMessageDialog("MyDialog", r =>
            {
                //ex. 2
                if (IsNullOrParameter(r.Parameters))
                {
                    MessageReceived = r.Parameters.GetValue<string>("submessage");
                }
                else
                {
                    MessageReceived = "No";
                }
            });
        }

        private void ShowDialog()
        {
            _dialogService.ShowMessageDialog("MyDialog", r =>
            {
                //ex. 2
                if (IsNullOrParameter(r.Parameters))
                {
                    MessageReceived = r.Parameters.GetValue<string>("submessage");
                }
                else
                {
                    MessageReceived = "No";
                }
            });
        }

        private bool IsNullOrParameter(IDialogParameters parameters)
        {
            return parameters.GetValue<string>("submessage") != string.Empty;
        }

        #region TitleName Property

        private string _messageReceivedtwo = "Good";
        public string MessageReceivedtwo
        {
            get { return _messageReceivedtwo; }
            set { SetProperty(ref _messageReceivedtwo, value); }
        }

        private string _messageReceived;
        public string MessageReceived
        {
            get { return _messageReceived; }
            set { SetProperty(ref _messageReceived, value); }
        }
        public string ButtonTitle { get => "Show Dialog"; }

        #endregion

        #region IDialogService
        private IDialogService _dialogService;
    
        public ShellWindowViewModel(IDialogService dialogService)
        {
            this._dialogService = dialogService;
  
           
        }
   
        #endregion

        public string WindowTitle { get => "KimHyesu"; }
    }



}
