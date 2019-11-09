using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Reflection;

namespace HamburgerMenu
{

    [AttributeUsage(AttributeTargets.All)]
    public sealed class HamburgerMenuItemAttribute : Attribute
    {
        public HamburgerMenuItemAttribute(string Text, string ToControlView)
        {
            this.Text = Text;
            this.ToControlView = ToControlView;
            //this.ModuleType = ModuleType;
            //SetText(Text);
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(HamburgerMenuItemAttribute), new FrameworkPropertyMetadata(typeof(HamburgerMenuItemAttribute)));
        }

        //public static string GetText(DependencyObject obj)
        //{
        //    return (string)obj.GetValue(TextProperty);
        //}
        //public static void SetText(DependencyObject obj, string value)
        //{
        //    obj.SetValue(TextProperty, value);
        //}
        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        //public static readonly DependencyProperty TextProperty =
        //    DependencyProperty.Register("Text", typeof(string), typeof(HamburgerMenuItemAttribute), new PropertyMetadata(String.Empty));

        private Type _moduleType;
        public Type ModuleType
        {
            get { return _moduleType; }
            set { _moduleType = value; }
        }

        //public static ImageSource GetIcon(DependencyObject obj)
        //{
        //    return (ImageSource)obj.GetValue(IconProperty);
        //}
        //public static void SetIcon(DependencyObject obj, ImageSource value)
        //{
        //    obj.SetValue(IconProperty, value);
        //}
        ////public ImageSource Icon
        ////{
        ////    get { return (ImageSource)GetValue(IconProperty); }
        ////    set { SetValue(IconProperty, value); }
        ////}

        //public static readonly DependencyProperty IconProperty =
        //    DependencyProperty.Register("Icon", typeof(ImageSource), typeof(HamburgerMenuItemAttribute), new PropertyMetadata(null));

        //public static Brush GetSelectionIndicatorColor(DependencyObject obj)
        //{
        //    return (Brush)obj.GetValue(SelectionIndicatorColorProperty);
        //}
        //public static void SetSelectionIndicatorColor(DependencyObject obj, Brush value)
        //{
        //    obj.SetValue(SelectionIndicatorColorProperty, value);
        //}

        ////public Brush SelectionIndicatorColor
        ////{
        ////    get { return (Brush)GetValue(SelectionIndicatorColorProperty); }
        ////    set { SetValue(SelectionIndicatorColorProperty, value); }
        ////}

        //public static readonly DependencyProperty SelectionIndicatorColorProperty =
        //    DependencyProperty.Register("SelectionIndicatorColor", typeof(Brush), typeof(HamburgerMenuItemAttribute), new PropertyMetadata(Brushes.Blue));


        //public static ICommand GetSelectionCommand(DependencyObject obj)
        //{
        //    return (ICommand)obj.GetValue(SelectionCommandProperty);
        //}
        //public static void SetSelectionCommand(DependencyObject obj, ICommand value)
        //{
        //    obj.SetValue(SelectionCommandProperty, value);
        //}
        ////public ICommand SelectionCommand
        ////{
        ////    get { return (ICommand)GetValue(SelectionCommandProperty); }
        ////    set { SetValue(SelectionCommandProperty, value); }
        ////}

        //public static readonly DependencyProperty SelectionCommandProperty =
        //    DependencyProperty.Register("SelectionCommand", typeof(ICommand), typeof(HamburgerMenuItemAttribute), new PropertyMetadata(null));


        ////public static string GetToControlView(DependencyObject obj)
        ////{
        ////    return (string)obj.GetValue(ToControlViewProperty);
        ////}
        ////public static void SetToControlView(DependencyObject obj, string value)
        ////{
        ////    obj.SetValue(ToControlViewProperty, value);
        //}
        private string _toControlView;

        public string ToControlView
        {
            get { return _toControlView; }
            set { _toControlView = value; }
        }

        //public static readonly DependencyProperty ToControlViewProperty =
        //DependencyProperty.Register("ToControlView", typeof(string), typeof(HamburgerMenuItemAttribute), new PropertyMetadata(String.Empty));
    }
}
