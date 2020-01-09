using Prism.Mvvm;
using System;

namespace khgWPFLearn_CustomUI.Dialogs
{
    public class KHGBindingBase : BindableBase,IDisposable
    {
        //private CompositeDisposable _disposables = new CompositeDisposable();
        private bool _dispose;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_dispose)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            _dispose = true;
        }
    }
}
