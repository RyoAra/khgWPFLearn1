using System.Windows.Controls;
using System.Windows.Interactivity;

namespace khgWPFLearn_CustomUI.Behavior
{
    public class ListBoxItemBehavior : Behavior<ListBoxItem>
    {

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
