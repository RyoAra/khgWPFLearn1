using Prism.Mvvm;
using System;

namespace khgLearnCommon.Common
{
    public class KHGBindingBase : BindableBase,IDisposable
    {
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
