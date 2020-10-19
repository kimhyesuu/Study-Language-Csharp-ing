using Prism.Ioc;
using Prism.Services.Dialogs;
using System.Collections.Generic;

namespace PrismWpfDlgService
{
    public class MyDialogService : DialogService
    {
        Dictionary<object, IDialogWindow> _window = new Dictionary<object, IDialogWindow>();

        public MyDialogService(IContainerExtension containerExtension) 
            : base(containerExtension)
        {
        }

        
        
    }
}
