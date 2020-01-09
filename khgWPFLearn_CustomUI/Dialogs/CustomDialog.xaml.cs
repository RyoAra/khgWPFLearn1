using MahApps.Metro.Controls;
using Prism.Services.Dialogs;


namespace khgWPFLearn_CustomUI.Dialogs
{
    /// <summary>
    /// CustomDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class CustomDialog : MetroWindow, IDialogWindow
    {
        public CustomDialog()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}
