namespace ModularSample.Core.Dialog
{
    using Prism.Services.Dialogs;
    using System;

    public static class IDialogServiceExtension
    {
        public static void ShowMessageDialog(this IDialogService dialogService, string message, Action<IDialogResult> callback)
        {
            var p = new DialogParameters();
            p.Add("message", message);

            dialogService.ShowDialog("MessageDialog", p, callback);

        }

        // 여러 개 쓸 수 있음
        // string message => Person id
        public static void ShowPersonDialog(this IDialogService dialogService, string message, Action<IDialogResult> callback)
        {
            var p = new DialogParameters();
            p.Add("message", message);

            dialogService.ShowDialog("MessageDialog", p, callback);

        }
    }
}
