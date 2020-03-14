using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace khgWPFLearn_CustomUI.Behavior
{
    public class DataGridExtention : Behavior<DataGrid>
    {

        public DataGridExtention()
        {
        }

        // 要素にアタッチされたときの処理。大体イベントハンドラの登録処理をここでやる
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.AutoGeneratingColumn += dataGrid_AutoGeneratingColumn;

        }

        // 要素にデタッチされたときの処理。大体イベントハンドラの登録解除をここでやる
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.AutoGeneratingColumn -= dataGrid_AutoGeneratingColumn;

        }

        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs eventArgs)
        {
            if (eventArgs.PropertyDescriptor is PropertyDescriptor descriptor)
            {
                eventArgs.Column.Header = descriptor.DisplayName ?? descriptor.Name;
            }
            else
            {
                eventArgs.Cancel = true;
            }
        }
    }
}
