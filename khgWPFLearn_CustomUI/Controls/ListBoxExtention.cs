using System.Windows;
using System.Windows.Controls;

namespace khgWPFLearn_CustomUI.Controls
{
    /// <summary>
    /// このカスタム コントロールを XAML ファイルで使用するには、手順 1a または 1b の後、手順 2 に従います。
    ///
    /// 手順 1a) 現在のプロジェクトに存在する XAML ファイルでこのカスタム コントロールを使用する場合
    /// この XmlNamespace 属性を使用場所であるマークアップ ファイルのルート要素に
    /// 追加します:
    ///
    ///     xmlns:MyNamespace="clr-namespace:khgWPFLearn_CustomUI.Behavior"
    ///
    ///
    /// 手順 1b) 異なるプロジェクトに存在する XAML ファイルでこのカスタム コントロールを使用する場合
    /// この XmlNamespace 属性を使用場所であるマークアップ ファイルのルート要素に
    /// 追加します:
    ///
    ///     xmlns:MyNamespace="clr-namespace:khgWPFLearn_CustomUI.Behavior;assembly=khgWPFLearn_CustomUI.Behavior"
    ///
    /// また、XAML ファイルのあるプロジェクトからこのプロジェクトへのプロジェクト参照を追加し、
    /// リビルドして、コンパイル エラーを防ぐ必要があります:
    ///
    ///     ソリューション エクスプローラーで対象のプロジェクトを右クリックし、
    ///     [参照の追加] の [プロジェクト] を選択してから、このプロジェクトを参照し、選択します。
    ///
    ///
    /// 手順 2)
    /// コントロールを XAML ファイルで使用します。
    ///
    ///     <MyNamespace:ListBoxExtention/>
    ///
    /// </summary>
    public class ListBoxExtention : Control
    {

        public static string GetSelectedItemText(DependencyObject obj)
        {
            return (string)obj.GetValue(SelectedItemTextProperty);
        }
        public static void SetSelectedItemText(DependencyObject obj, string value)
        {
            obj.SetValue(SelectedItemTextProperty, value);
        }

        public static readonly DependencyProperty SelectedItemTextProperty =
        DependencyProperty.RegisterAttached("SelectedItemText", typeof(string), typeof(ListBoxExtention), new UIPropertyMetadata(null,new PropertyChangedCallback(OnPropertyChanged)));

        public static void OnPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs value)
        {

        }

        public ListBoxExtention()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ListBoxExtention), new FrameworkPropertyMetadata(typeof(ListBoxExtention)));
        }
    }
}
