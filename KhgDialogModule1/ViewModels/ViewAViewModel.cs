using khgWPFLearn_CustomUI.BindingBase;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;

namespace KhgDialogModule1.ViewModels
{
    public class ViewAViewModel : KHGDialogBindingBase
    {
        

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ReactiveCommand OkbuttonClick { get; set; } = new ReactiveCommand();

        public ViewAViewModel()
        {
            Message = "View A from your Prism Module";
            this.Title = "なぜか動かないのじゃ？";

            OkbuttonClick.Subscribe(_ => { CloseDialog(new Prism.Services.Dialogs.DialogResult(Prism.Services.Dialogs.ButtonResult.OK)); }).AddTo(Disposer);
        }
    }
}
