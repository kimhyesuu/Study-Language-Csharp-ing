using Prism.Services.Dialogs;
using System.Windows;

namespace ModularSample.Dialog
{
    /// <summary>
    /// Interaction logic for MyCustomWindow.xaml
    /// </summary>
    public partial class MyCustomWindow : Window, IDialogWindow
    {
        public MyCustomWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}
