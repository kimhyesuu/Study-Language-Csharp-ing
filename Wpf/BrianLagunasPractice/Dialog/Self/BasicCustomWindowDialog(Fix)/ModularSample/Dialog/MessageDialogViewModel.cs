namespace ModularSample.Dialog
{
    using ModularSample.Core;
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;
    using Prism.Services.Dialogs;
    using System;

    public class MessageDialogViewModel : BindableBase, IDialogAware
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

            if (parameter?.ToLower() == BoolType.Coretrue)
            {
                result = ButtonResult.OK;
                parameterValue = "ButtonResult.OK";
            }
 
            #region EX.2
            //if (parameter?.ToLower() == BoolType.Coretrue)
            //{
            //    result = ButtonResult.OK;
            //    parameterValue = "ButtonResult.OK";
            //}
            //else
            //{
            //    parameterValue = "ButtonResult.No";
            //}
            #endregion

            #region EX.1
            //if (parameter?.ToLower() == BoolType.Coretrue)
            //{
            //    result = ButtonResult.OK;
            //    parameterValue = "ButtonResult.OK";
            //}   
            //else if (parameter?.ToLower() == BoolType.Corefalse)
            //{
            //    result = ButtonResult.Cancel;
            //    parameterValue = "ButtonResult.Cancel";
            //}
            #endregion
            transportParameter.Add("submessage", parameterValue);
            RaiseRequestClose(result , transportParameter);
        }

        private void RaiseRequestClose(ButtonResult dialogResult , IDialogParameters dialogParameters )
            => RequestClose?.Invoke(new DialogResult(dialogResult, dialogParameters));
 
        // Determines if the dialog can be closed.
        public bool CanCloseDialog() => true;

        // Called when the dialog is closed.
        public void OnDialogClosed()
        {
           
        }

        // Called when the dialog is opened.
        public void OnDialogOpened(IDialogParameters parameters)
           /=> Message = parameters.GetValue<string>("message");

        #region TitleName
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
