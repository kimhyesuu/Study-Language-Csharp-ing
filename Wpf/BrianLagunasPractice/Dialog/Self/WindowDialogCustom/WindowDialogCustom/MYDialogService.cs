using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowDialogCustom
{
    public class MYDialogService : DialogService
    {
        Dictionary<object, IDialogWindow> _window = new Dictionary<object, IDialogWindow>();
  
        public MYDialogService(IContainerExtension containerExtension) : base(containerExtension)
        {
        }


       
    }
}
