using EventAggregator.Core;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class MessageViewModel : BindableBase
    {
        #region Field
        private IEventAggregator _eventAggregator;
        private string _message;

        #endregion

        #region Construtor

        public MessageViewModel(IEventAggregator eventAggregator)
        {
            _message = "Message to Send";
            _eventAggregator = eventAggregator;
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        #endregion

        #region Property

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        #endregion

        #region Command

        public DelegateCommand SendMessageCommand { get; private set; }

        #endregion

        #region private Method

        private void SendMessage()
        {
            _eventAggregator.GetEvent<MessageSendEvent>().Publish(Message);
        }

        #endregion

    }
}
