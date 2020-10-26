using EventAggregator.Core;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.Dlg
{
    //먼저 되는지 확인하고 옮기는 습관

    public class MyDialogViewModel : BindableBase, IDialogAware
    {
        private DelegateCommand<string> _closeDialogCommand;
        public event Action<IDialogResult> RequestClose;

        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));
        //버튼을 만들기 전에 동작되는 지 확인바람

        private void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            var transportParameter = new DialogParameters();
            string parameterValue = string.Empty;

            if (parameter?.ToLower() == "true")
            {
                result = ButtonResult.OK;
               // _eventAggregator.GetEvent<MessageSendEvent>().Publish(MessageTwo);
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

        private IEventAggregator _eventAggregator;

        public MyDialogViewModel()
        {
            //this._eventAggregator = eventAggregator;
            //같은 이걸 쓰게 되면 count add가 계속 되네
            //_eventAggregator.GetEvent<MessageSendEvent>().Subscribe(ReceivedMessage);
        }

        private void ReceivedMessage(string parameter)
        {
            MessageTwo = parameter;
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
