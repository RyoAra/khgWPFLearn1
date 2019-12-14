using MahApps.Metro.Controls;

namespace khgWPFLearn1.NavigateControl
{
    public class GrobalNavigate: HamburgerMenuGlyphItem
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private string _toControlView;

        public string ToControlView
        {
            get { return _toControlView; }
            set { _toControlView = value; }
        }
    }
}
