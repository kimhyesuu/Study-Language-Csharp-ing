using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleB.ViewModels
{
    interface IWindowResource
    {
        Action Close { get; set; }
        bool CanClose();
    }

    public class WindowCloseViewModel : BindableBase, IWindowResource
    {

        private DelegateCommand _closeCommand;

        public DelegateCommand CloseCommand =>
            _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));

        //window로 묵고

        public bool CanClose()
        {
            return true;
        }

        public Action Close { get; set; }

        private void CloseWindow()
        {
            Close?.Invoke();
        }

    }
}
