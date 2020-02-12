using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace khgWPFLearn_CustomUI.Behavior
{
    public class ListBoxItemBehavior : Behavior<ListBoxItem>
    {
        public static string GetSelectedItemText(DependencyObject obj)
        {
            return (string)obj.GetValue(SelectedItemTextProperty);
        }
        public static void SetSelectedItemText(DependencyObject obj, string value)
        {
            obj.SetValue(SelectedItemTextProperty, value);
        }

        private static readonly DependencyProperty SelectedItemTextProperty =
        DependencyProperty.Register("SelectedItemText", typeof(string), typeof(ListBoxItemBehavior), new UIPropertyMetadata(null));

        public ListBoxItemBehavior()
        {
        }

        // 要素にアタッチされたときの処理。大体イベントハンドラの登録処理をここでやる
        protected override void OnAttached()
        {
            base.OnAttached();
        }

        // 要素にデタッチされたときの処理。大体イベントハンドラの登録解除をここでやる
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}
