using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolbarModuleA.Models.Module;

namespace ToolbarModuleA.ViewModels
{
    public class ToolBarViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private ToolBarModule _TM;
        public ToolBarModule TM
        {
            get
            {
                return _TM;
            }
            set
            {
                _TM = value;
                RaisePropertyChanged("_TM");
            }
        }
    }
}
