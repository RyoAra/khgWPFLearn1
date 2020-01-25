using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace khgWPFLearn_CustomUI.Behavior
{
    public class ButtonBehavior : Behavior<Button>
    {

        public static bool GetSubmitButtonFlag(DependencyObject obj)
        {
            return (bool)obj.GetValue(SubmitButtonFlagProperty);
        }
        public static void SetSubmitButtonFlag(DependencyObject obj, bool value)
        {
            obj.SetValue(SubmitButtonFlagProperty, value);
        }

        private static readonly DependencyProperty SubmitButtonFlagProperty =
        DependencyProperty.Register("SubmitButtonFlag", typeof(bool), typeof(ButtonBehavior), new UIPropertyMetadata(null));

        public ButtonBehavior()
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
