using Prism.Services.Dialogs;

namespace khgWPFLearn_CustomUI.Dialogs
{
    public static class DialogServiceExtensions

    {
        public static ButtonResult ShowDialog(this IDialogService dialogService,string view)
        {
            ButtonResult ret= new ButtonResult();

            dialogService.ShowDialog(view, null, r => ret = r.Result);
            return ret;
        }

        public static ButtonResult ShowDialog(this IDialogService dialogService, string view,DialogParameters param)
        {
            ButtonResult ret = new ButtonResult();

            dialogService.ShowDialog(view, param, r => ret = r.Result);
            return ret;
        }

        public static ButtonResult Show(this IDialogService dialogService, string view)
        {
            ButtonResult ret = new ButtonResult();

            dialogService.Show(view, null, r => ret = r.Result);
            return ret;
        }

        public static ButtonResult Show(this IDialogService dialogService, string view, DialogParameters param)
        {
            ButtonResult ret = new ButtonResult();

            dialogService.Show(view, param, r => ret = r.Result);
            return ret;
        }
    }
}
