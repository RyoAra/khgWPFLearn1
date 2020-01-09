using Prism.Services.Dialogs;
using System.Windows;


namespace khgWPFLearn_CustomUI.Dialogs
{
    /// <summary>
    /// CustomDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class CustomDialog : Window, IDialogWindow
    {
        public CustomDialog()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}
