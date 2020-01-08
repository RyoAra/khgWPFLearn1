using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
