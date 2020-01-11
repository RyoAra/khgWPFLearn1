using Prism.Services.Dialogs;
using Prism.Regions;
using System;

namespace khgWPFLearn_CustomUI.BindingBase
{
    public class KHGDialogBindingBase : khgWPFLearn_CustomUI.Dialogs.KHGBindingBase, IDialogAware,IRegionMemberLifetime
    {
        public string Title { set; get; }

        public bool KeepAlive { set; get; }

        public event Action<IDialogResult> RequestClose;

        private DialogResult res;

        public virtual bool CanCloseDialog()
        {
            return true;
            //throw new NotImplementedException();
        }

        public virtual void OnDialogClosed()
        {
            if (res == null)
            {
                res = new DialogResult(ButtonResult.None); 
            }
            RequestClose?.Invoke(res);
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
        }

        public virtual void CloseDialog(DialogResult result)
        {
            res = result;
            OnDialogClosed();
        }
    }
}
