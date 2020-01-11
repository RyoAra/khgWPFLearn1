using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Input;

namespace khgWPFLearn_CustomUI.Behavior
{
    public class NumericTextBoxBehavior : Behavior<TextBox>
    {
        #region メッセージプロパティ
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public decimal? MaxValue
        {
            get { return (decimal?)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(NumericTextBoxBehavior), new UIPropertyMetadata(null));

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(decimal?), typeof(NumericTextBoxBehavior), new UIPropertyMetadata(null));
        #endregion

        public NumericTextBoxBehavior()
        {
        }

        // 要素にアタッチされたときの処理。大体イベントハンドラの登録処理をここでやる
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PreviewTextInput += OnPreviewTextInput;
            //this.AssociatedObject.KeyDown += InputValueCheck;
        }

        // 要素にデタッチされたときの処理。大体イベントハンドラの登録解除をここでやる
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.PreviewTextInput -= OnPreviewTextInput;
            //this.AssociatedObject.KeyDown -= InputValueCheck;
        }

        // メッセージが入力されていたらメッセージボックスを出す
        private void Alert(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Message))
            {
                return;
            }

            MessageBox.Show(this.Message);
        }
        /// <summary>
        /// テキスト取得時の処理イベント
        /// </summary>
        /// <param name="sender">TextBox</param>
        /// <param name="e">入力内容データ</param>
        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string tmp = "";
            // 整数値に変換できない場合は処理をキャンセル
            e.Handled = !CheckTextInput(sender, e.Text,ref tmp);
            if (!e.Handled == true)
            {
                e.Handled = !MaxValueCheck(sender, tmp);
            }


        }

        //private void InputValueCheck(object sender, KeyEventArgs e)
        //{
        //    if (MaxValue != null)
        //    {
        //        var tmp = e.Source as long?;
        //        if (tmp == null)
        //        {
        //            e.Handled = true;
        //        }

        //        if (tmp > MaxValue)
        //        {
        //            e.Handled = true;
        //        }

        //    }

        //    e.Handled = false;
        //}

        /// <summary>入力した内容で数値となるかチェック</summary>
        /// <param name="sender">TextBox</param>
        /// <param name="addText">追加文字</param>
        /// <returns>
        /// true : 数値OK
        /// false : 数値NG
        /// </returns>
        private bool CheckTextInput(object sender, string addText,ref string resText)
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
                return decimal.TryParse(text, out decimal value);
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

    }
}

