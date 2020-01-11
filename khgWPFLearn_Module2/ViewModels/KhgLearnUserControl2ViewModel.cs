using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using khgWPFLearn_Module2.Models;
using System.Reactive.Disposables;

namespace khgWPFLearn_Module2.ViewModels
{
    public class KhgLearnUserControl2ViewModel : BindableBase
    {
        private CompositeDisposable _disposables = new CompositeDisposable();
        public ReactiveProperty<string> TestText { get; private set; }

        public ReactiveProperty<int?> NumericTest { get; private set; } = new ReactiveProperty<int?>();

        KhgLearnTestModel Model;
        public KhgLearnUserControl2ViewModel()
        {
            Model = new KhgLearnTestModel();

            TestText = Model.ToReactivePropertyAsSynchronized(m => m.TestText).AddTo(_disposables);

        }

        
    }
}
