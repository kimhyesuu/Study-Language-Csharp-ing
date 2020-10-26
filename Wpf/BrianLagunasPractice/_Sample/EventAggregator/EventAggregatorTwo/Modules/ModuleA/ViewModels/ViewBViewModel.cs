using System;
using EventAggregator.Core;
using ModularSample.Core.Dialog;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace ModuleA.ViewModels
{
    public class ViewBViewModel : BindableBase
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
            //_eventAggregator.GetEvent<MessageSendEvent>().Publish(MessageReceivedtwo);
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
            _eventAggregator.GetEvent<MessageSendEvent>().Publish(MessageReceivedtwo);
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
        private IEventAggregator _eventAggregator;
        public ViewBViewModel(IDialogService dialogService, IEventAggregator eventAggregator)
        {
            this._dialogService = dialogService;
            this._eventAggregator = eventAggregator;
            MessageReceivedtwo = "Message to Send";
  
            SendMessageCommand = new DelegateCommand(SendMessage);
            //_eventAggregator.GetEvent<MessageSendEvent>().Subscribe(DialogServiceMessage);
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        private void SendMessage()
        {
            _eventAggregator.GetEvent<MessageSendEvent>().Publish(MessageReceived);
        }

        private void DialogServiceMessage(string parameter)
        {
            MessageReceivedtwo = parameter;
        }
        #endregion
    }


}
