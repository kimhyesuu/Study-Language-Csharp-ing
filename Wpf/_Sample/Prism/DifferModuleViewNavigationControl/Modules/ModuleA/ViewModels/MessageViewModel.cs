using EventAggregator.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModuleA.ViewModels
{
    public class MessageViewModel : BindableBase
    {
        #region ViewNavigation
        private IRegionManager _regionManager;

        public DelegateCommand<object> NavigationCommand { get; private set; }


        private void OnNavigation(object parameter)
        {
            if (parameter is null) return;

            var para = parameter as FrameworkElement;

            _regionManager.RequestNavigate("RightRegion", para.Name);

            #region EX.1

            //if (Commandparameter.MessageList == para.Name)
            //{
            //    _regionManager.RequestNavigate("RightRegion", Commandparameter.MessageList);
            //}
            //else
            //{
            //    _regionManager.RequestNavigate("RightRegion", Commandparameter.ViewB);
            //}
            #endregion

        }

        #endregion


        #region Field

        private string _message;

        #endregion

        #region Construtor

        public MessageViewModel(IRegionManager regionManager)
        {
            _message = "Message to Send";
            this._regionManager = regionManager;
            NavigationCommand = new DelegateCommand<object>(o => OnNavigation(o));
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

        }

        #endregion

    }
}
