using System;

namespace HamburgerMenu
{

    [AttributeUsage(AttributeTargets.All)]
    public sealed class HamburgerMenuItemAttribute : Attribute
    {
        public HamburgerMenuItemAttribute()
        {

        }

        public HamburgerMenuItemAttribute(string Text)
        {
            this.Text = Text;
            
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private Type _moduleType;
        public Type ModuleType
        {
            get { return _moduleType; }
            set { _moduleType = value; }
        }

        private string _glyph;

        public string Glyph
        {
            get { return _glyph; }
            set { _glyph = value; }
        }


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
