using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvertBooleanToVisibilityConverter
{
    public class MainWindowViewModel
    {
        private bool _showButton;

        public MainWindowViewModel()
        {
            _showButton = false;
        }

        public bool ShowButton
        {
            get { return _showButton; }
        }
    }
}
