using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using khgWPFLearn1.Models;
using System.Reactive.Disposables;

namespace khgWPFLearn1.ViewModels
{
    public class KhgLearnUserControl1ViewModel : BindableBase
    {
        private CompositeDisposable _disposables = new CompositeDisposable();
        public ReactiveProperty<string> TestText { get; private set; }

        KhgLearnTestModel Model;
        public KhgLearnUserControl1ViewModel()
        {
            Model = new KhgLearnTestModel();

            TestText = Model.ToReactivePropertyAsSynchronized(m => m.TestText).AddTo(_disposables);

        }

        
    }
}
