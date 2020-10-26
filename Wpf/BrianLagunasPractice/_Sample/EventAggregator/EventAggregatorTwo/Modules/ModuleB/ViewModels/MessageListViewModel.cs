using EventAggregator.Core;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        private ObservableCollection<string> _messages;

        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }


        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            _messages = new ObservableCollection<string>();
            eventAggregator.GetEvent<MessageSendEvent>().Subscribe(MessageReceived);
        }

        private void MessageReceived(string paremeter)
        {
            Messages.Add(paremeter);

        }
    }
}
