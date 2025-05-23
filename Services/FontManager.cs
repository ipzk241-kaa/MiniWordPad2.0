using System.Drawing;
using System.Windows.Forms;

namespace Lab_6
{
    public class FontManager
    {
        private readonly RichTextBox _editor;

        public FontManager(RichTextBox editor)
        {
            _editor = editor;
        }

        public void SetFontFamily(string fontFamily)
        {
            if (_editor.SelectionFont != null)
            {
                var currentFont = _editor.SelectionFont;
                _editor.SelectionFont = new Font(fontFamily, currentFont.Size, currentFont.Style);
            }
        }

        public void SetFontSize(float size)
        {
            if (_editor.SelectionFont != null)
            {
                var currentFont = _editor.SelectionFont;
                _editor.SelectionFont = new Font(currentFont.FontFamily, size, currentFont.Style);
            }
        }

        public void ToggleBold()
        {
            if (_editor.SelectionFont != null)
            {
                var currentFont = _editor.SelectionFont;
                var newStyle = currentFont.Style ^ FontStyle.Bold;
                _editor.SelectionFont = new Font(currentFont, newStyle);
            }
        }

        public void ToggleItalic()
        {
            if (_editor.SelectionFont != null)
            {
                var currentFont = _editor.SelectionFont;
                var newStyle = currentFont.Style ^ FontStyle.Italic;
                _editor.SelectionFont = new Font(currentFont, newStyle);
            }
        }

        public void ToggleUnderline()
        {
            if (_editor.SelectionFont != null)
            {
                var currentFont = _editor.SelectionFont;
                var newStyle = currentFont.Style ^ FontStyle.Underline;
                _editor.SelectionFont = new Font(currentFont, newStyle);
            }
        }
        public void ToggleStrikeout()
        {
            if (_editor.SelectionFont != null)
            {
                var currentFont = _editor.SelectionFont;
                var newStyle = currentFont.Style ^ FontStyle.Strikeout;
                _editor.SelectionFont= new Font(currentFont, newStyle);
            }
        }
    }
}
