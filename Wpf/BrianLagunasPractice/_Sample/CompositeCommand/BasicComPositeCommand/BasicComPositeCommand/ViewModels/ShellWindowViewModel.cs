using BasicCompositeCommand.Core;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicComPositeCommand.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {    
        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set => SetProperty(ref _applicationCommands, value);
        }


        public ShellWindowViewModel(IApplicationCommands applicationCommands)
        {
            ApplicationCommands = applicationCommands;
        }
    }
}
