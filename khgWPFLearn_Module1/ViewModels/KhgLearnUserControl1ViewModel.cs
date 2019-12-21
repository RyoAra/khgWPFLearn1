﻿using khgWPFLearn_Module1.Models;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Disposables;

namespace khgWPFLearn_Module1.ViewModels
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
