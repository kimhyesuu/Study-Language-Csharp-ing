using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.Core
{
    public static class IDialogServiceExtension
    {
        public static void ShowMessageDialog(this IDialogService dialogService, string message, Action<IDialogResult> callback)
        {
            var p = new DialogParameters();
            p.Add("message", message);
            dialogService.ShowDialog("MyDialog", p, callback);
        }

      
        public static void ShowPersonDialog(this IDialogService dialogService, string message, Action<IDialogResult> callback)
        {
            var p = new DialogParameters();
            p.Add("message", message);

            dialogService.ShowDialog("MyDialog", p, callback);
        }

    }
}
