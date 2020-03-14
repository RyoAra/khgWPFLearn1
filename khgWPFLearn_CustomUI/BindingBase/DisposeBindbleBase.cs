using System.Reactive.Disposables;
using khgLearnCommon.Common;

namespace khgWPFLearn_CustomUI.BindingBase
{
    public class DisposeBindbleBase: KHGBindingBase
    {
        public CompositeDisposable Disposer = new CompositeDisposable();


        ~DisposeBindbleBase()
        {
            Disposer.Dispose();
            base.Dispose();
        }

    }
}
