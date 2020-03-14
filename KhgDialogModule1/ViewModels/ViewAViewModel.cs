using khgWPFLearn_CustomUI.BindingBase;
using khgLearnCommon.Common;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.ComponentModel;


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

        public ReactiveCollection<string> ListTest { get; set; } = new ReactiveCollection<string>();
        public ReactiveProperty<string> SelectedTest { get; set; } = new ReactiveProperty<string>();

        public ReactiveCollection<DataGridTest> GridTest { get; set; } = new ReactiveCollection<DataGridTest>();
        public ReactiveProperty<DataGridTest> GridSelectTest { get; set; } = new ReactiveProperty<DataGridTest>();
        public ViewAViewModel()
        {
            Message = "View A from your Prism Module";
            this.Title = "なぜか動かないのじゃ？";

            ListTest.Add("一こめ");
            ListTest.Add("２こめ");
            ListTest.Add("３こめ");

            GridTest.Add(new DataGridTest() { No = 1, Column1 = "いち-1", Column2 = "いち-2" });
            GridTest.Add(new DataGridTest() { No = 2, Column1 = "に-1", Column2 = "に-2" });
            GridTest.Add(new DataGridTest() { No = 3, Column1 = "さん-1", Column2 = "さん-2" });
            GridTest.Add(new DataGridTest() { No = 4, Column1 = "よｎ-1", Column2 = "よん-2" });

            OkbuttonClick.Subscribe(_ => { CloseDialog(new Prism.Services.Dialogs.DialogResult(Prism.Services.Dialogs.ButtonResult.OK)); }).AddTo(Disposer);
        }
    }


    public class DataGridTest : KHGBindingBase
    {

        private int no;


        private string column1;


        private string column2;

        [DisplayName("番号")]
        public int No
        {
            get => no;
            set
            {
                SetProperty(ref no, value);
            }
        }

        [DisplayName("その1")]
        public string Column1
        {
            get => column1; set
            {
                SetProperty(ref column1, value);
            }
        }

        [DisplayName("その2")]
        public string Column2
        {
            get => column2; set
            {
                SetProperty(ref column2, value);
            }
        }
    }
}
