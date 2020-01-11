using khgWPFLearn_CustomUI.Dialogs;
using khgWPFLearn_Module1.Models;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Disposables;

namespace khgWPFLearn_Module1.ViewModels
{
    public class KhgLearnUserControl1ViewModel : BindableBase
    {
        private CompositeDisposable _disposables = new CompositeDisposable();
        public ReactiveProperty<string> TestText { get; private set; }

        public ReactiveCommand DialogTest { get; set; } = new ReactiveCommand();

        KhgLearnTestModel Model;

        private readonly IDialogService dialogService = null;

        public KhgLearnUserControl1ViewModel(IDialogService dialog)
        {
            Model = new KhgLearnTestModel();
            dialogService = dialog;

            TestText = Model.ToReactivePropertyAsSynchronized(m => m.TestText).AddTo(_disposables);


            DialogTest.Subscribe(_ => { OpenWindow(); }).AddTo(_disposables) ;
        }

        private void OpenWindow()
        {
            if (dialogService.ShowDialog("ViewA") == ButtonResult.OK)
            {
                System.Windows.MessageBox.Show("OKボタン戻り");
            }
        }
        
    }
}
