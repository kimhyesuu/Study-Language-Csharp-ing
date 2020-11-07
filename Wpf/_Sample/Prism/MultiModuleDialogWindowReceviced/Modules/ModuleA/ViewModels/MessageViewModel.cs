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

        private string _message;

        #endregion

        #region Construtor

        private IHsManager<string> _hsManager;
        private IEventAggregator _eventAggregator;
        public MessageViewModel(IHsManager<string> hsManager, IEventAggregator eventAggregator)
        {
            Message = "Message to Send";
            this._eventAggregator = eventAggregator;
            this._hsManager = hsManager;
            _hsManager.Add(Message);
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
            _hsManager.Add(Message);
           _eventAggregator.GetEvent<MessageSendEvent>().Publish(Message);
        }

        #endregion

    }
}
