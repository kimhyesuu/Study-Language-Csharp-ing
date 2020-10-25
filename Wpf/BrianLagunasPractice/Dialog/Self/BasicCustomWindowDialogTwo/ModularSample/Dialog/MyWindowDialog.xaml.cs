using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ModularSample.Dialog
{
    /// <summary>
    /// Interaction logic for MyWindowDialog.xaml
    /// </summary>
    public partial class MyWindowDialog : Window, IDialogWindow
    {
        public MyWindowDialog()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}
