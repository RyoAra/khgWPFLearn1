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

        public virtual bool CanCloseDialog()
        {
            return true;
            //throw new NotImplementedException();
        }

        public virtual void OnDialogClosed()
        {
            RequestClose?.Invoke(new DialogResult());
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
