using System.Reactive.Disposables;

namespace khgWPFLearn_CustomUI.BindingBase
{
    public class DisposeBindbleBase: Dialogs.KHGBindingBase
    {
        public CompositeDisposable Disposer = new CompositeDisposable();


        ~DisposeBindbleBase()
        {
            Disposer.Dispose();
            base.Dispose();
        }

    }
}
