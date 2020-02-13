using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace khgWPFLearn_CustomUI.Behavior
{
    public class NumericTextBoxBehavior : Behavior<TextBox>
    {
        #region メッセージプロパティ
        public decimal? MaxValue
        {
            get { return (decimal?)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public decimal? MinValue
        {
            get { return (decimal?)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public string DisplayFormat
        {
            get { return (string)GetValue(DisplayFormatProperty); }
            set { SetValue(DisplayFormatProperty, value); }
        }

        public string InputFormat
        {
            get { return (string)GetValue(InputFormatProperty); }
            set { SetValue(InputFormatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(decimal?), typeof(NumericTextBoxBehavior), new UIPropertyMetadata(null));

        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(decimal?), typeof(NumericTextBoxBehavior), new UIPropertyMetadata(null));

        public static readonly DependencyProperty DisplayFormatProperty =
            DependencyProperty.Register("DisplayFormat", typeof(string), typeof(NumericTextBoxBehavior), new UIPropertyMetadata(null));

        public static readonly DependencyProperty InputFormatProperty =
            DependencyProperty.Register("InputFormat", typeof(string), typeof(NumericTextBoxBehavior), new UIPropertyMetadata(null));
        #endregion

        public NumericTextBoxBehavior()
        {
        }

        // 要素にアタッチされたときの処理。大体イベントハンドラの登録処理をここでやる
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PreviewTextInput += OnPreviewTextInput;
            this.AssociatedObject.LostFocus += DisplayFormatSubmit;
            this.AssociatedObject.GotFocus += InputFormatSubmit;
            this.AssociatedObject.TextChanged += TextChanged;
        }

        // 要素にデタッチされたときの処理。大体イベントハンドラの登録解除をここでやる
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.PreviewTextInput -= OnPreviewTextInput;
            this.AssociatedObject.LostFocus -= DisplayFormatSubmit;
            this.AssociatedObject.GotFocus -= InputFormatSubmit;
            this.AssociatedObject.TextChanged -= TextChanged;
        }

        /// <summary>
        /// テキスト取得時の処理イベント
        /// </summary>
        /// <param name="sender">TextBox</param>
        /// <param name="e">入力内容データ</param>
        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string tmp = "";
            TextBox textBox = sender as TextBox;
            // 整数値に変換できない場合は処理をキャンセル
            e.Handled = !CheckTextInput(sender, e.Text, ref tmp);
            if (!e.Handled == true)
            {
                e.Handled = !MaxValueCheck(sender, tmp);
            }
            else
            {
                //textBox.Undo();
                return;
            }
            if (!e.Handled == true)
            {
                e.Handled = !MinValueCheck(sender, tmp);
            }
            else
            {
                //textBox.Undo();
                return;
            }


        }

        private void TextChanged(object sender,TextChangedEventArgs e)
        {
            string tmp = "";
            TextBox textBox = sender as TextBox;
            e.Handled = !CheckTextInput(sender, textBox.Text, ref tmp);
            if (e.Handled)
            {
                textBox.Text = "";
            }
        }

        /// <summary>入力した内容で数値となるかチェック</summary>
        /// <param name="sender">TextBox</param>
        /// <param name="addText">追加文字</param>
        /// <returns>
        /// true : 数値OK
        /// false : 数値NG
        /// </returns>
        private bool CheckTextInput(object sender, string addText, ref string resText)
        {

            if (sender is TextBox textBox)
            {

                // カーソル位置より前の文字列
                var part1 = textBox.SelectionStart.Equals(0) ? "" : textBox.Text.Substring(0, textBox.SelectionStart);

                // カーソル位置＋選択文字より後の文字列
                var part2 = textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength);

                // part1とpart2の間に入力された文字を追加
                var text = resText = part1 + addText + part2;

                // 作成した文字列が整数に変換できるか
                var result = decimal.TryParse(text, out decimal value);
                return result;
            }
            else
            {

                return false;

            }

        }

        private bool MaxValueCheck(object sender, string addText)
        {
            if (MaxValue != null)
            {
                var tmp = decimal.TryParse(addText, out decimal value);
                if (tmp == false)
                {
                    return false;
                }

                if (value > MaxValue)
                {
                    return false;
                }

            }
            return true;
        }

        private bool MinValueCheck(object sender, string addText)
        {
            if (MinValue != null)
            {
                var tmp = decimal.TryParse(addText, out decimal value);
                if (tmp == false)
                {
                    return false;
                }

                if (value < MinValue)
                {
                    return false;
                }

            }
            return true;
        }

        private void DisplayFormatSubmit(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DisplayFormat))
            {
                if (sender is TextBox textBox)
                {
                    if (decimal.TryParse(textBox.Text, out decimal value))
                    {
                        textBox.Text = value.ToString(DisplayFormat);
                    }

                }
            }
        }

        private void InputFormatSubmit(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InputFormat))
            {
                if (sender is TextBox textBox)
                {
                    if (decimal.TryParse(textBox.Text, out decimal value))
                    {
                        textBox.Text = value.ToString(InputFormat);
                    }

                }
            }
        }

    }
}

