using BasicCompositeCommand.Core;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class TabButtonViewModel : BindableBase
    {
        private bool _canUpdate = true;
        private string _updateText;

        public DelegateCommand UpdateCommand { get; private set; }


        public TabButtonViewModel(IApplicationCommands applicationCommands)
        {
            //CanUpdate가 true면 UpdateCommand 명령하달이 떨어지게 해주며,
            //CanUpdate가 false면 UpdateCommand를 inEnabled = false하게 만들어줌
            UpdateCommand = new DelegateCommand(Update).ObservesCanExecute(()=>CanUpdate);
            //체크가 다 되어있으면 되는 구나
            applicationCommands.SaveAllCommand.RegisterCommand(UpdateCommand);
        }

        public bool CanUpdate
        {
            get { return _canUpdate; }
            set { SetProperty(ref _canUpdate, value); }
        }

        public string UpdateText
        {
            get { return _updateText; }
            set { SetProperty(ref _updateText, value); }
        }

        private void Update()
        {
            UpdateText = $"Update : {DateTime.Now}";
        }

        #region Title
        private string _title;
        public string Title
        {
            get => _title; 
            set => SetProperty(ref _title, value); 
        }

        #endregion

    }
}
