using khgWPFLearn_CustomUI.BindingBase;

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

        public ViewAViewModel()
        {
            Message = "View A from your Prism Module";
            this.Title = "なぜか動かないのじゃ？";
        }
    }
}
