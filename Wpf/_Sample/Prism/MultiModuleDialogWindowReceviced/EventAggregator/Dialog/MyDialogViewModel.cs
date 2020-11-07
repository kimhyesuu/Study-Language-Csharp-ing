using EventAggregator.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.Dialog
{

    public class MyDialogViewModel : BindableBase, IDialogAware
    {
        private DelegateCommand<string> _closeDialogCommand;
        public event Action<IDialogResult> RequestClose;

        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));
        //버튼을 만들기 전에 동작되는 지 확인바람

        private ObservableCollection<string> _messagesManage;

        public ObservableCollection<string> MessagesManage
        {
            get { return _messagesManage; }
            set { SetProperty(ref _messagesManage, value); }
        }

        private void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            var transportParameter = new DialogParameters();
            string parameterValue = string.Empty;

            if (parameter?.ToLower() == "true")
            {
                result = ButtonResult.OK;
                parameterValue = "ButtonResult.OK";
            }

            transportParameter.Add("submessage", parameterValue);
            RaiseRequestClose(result, transportParameter);
        }

        private void RaiseRequestClose(ButtonResult dialogResult, IDialogParameters dialogParameters)
            => RequestClose?.Invoke(new DialogResult(dialogResult, dialogParameters));

        // Determines if the dialog can be closed.
        public bool CanCloseDialog() => true;

        // Called when the dialog is closed.
        public void OnDialogClosed()
        {

        }

        // Called when the dialog is opened.
        public void OnDialogOpened(IDialogParameters parameters)
           => Message = parameters.GetValue<string>("message");

        #region TitleName
        private IHsManager<string> _hsManager;

        public MyDialogViewModel(IHsManager<string> hsManager)
        {
            this._hsManager = hsManager;

            var temp = new ObservableCollection<string>(_hsManager.GetString);
            MessagesManage = temp;
        }

        private string _messageTwo;
        public string MessageTwo
        {
            get => _messageTwo;
            set { SetProperty(ref _messageTwo, value); }
        }
        private string _message;
        public string Message
        {
            get => _message;
            set { SetProperty(ref _message, value); }
        }
        public string ButtonOKTitle { get => "OK"; }
        public string ButtonCancelTitle { get => "Cancel"; }
        public string Title => "MessageDialog";
        #endregion
    }
}
