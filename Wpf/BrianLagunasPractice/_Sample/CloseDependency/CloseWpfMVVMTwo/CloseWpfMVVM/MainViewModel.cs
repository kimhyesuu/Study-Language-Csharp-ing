using Prism.Commands;
using System;
using System.Windows;

namespace CloseWpfMVVM
{

    //공통 인터페이스로 묵고
    public class MainViewModel : IWindowResource
    {        
        private DelegateCommand _closeCommand;

        public DelegateCommand CloseCommand =>
            _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));

        public Action Close { get; set; }

        public bool CanClose()
        {
            return true;
        }

        private void CloseWindow()
        {
            Close?.Invoke();
        }
    }
    //dependency로 해결
}
