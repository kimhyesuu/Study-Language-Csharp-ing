using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {

        public ShellWindowViewModel()
        {

        }


        public string WindowTitle { get => "KimHyesu";  }
    }
}
