using System.Drawing;
using System.Windows.Forms;

namespace Lab_6
{
    public class TextColorManager
    {
        private readonly RichTextBox _editor;

        public TextColorManager(RichTextBox editor)
        {
            _editor = editor;
        }

        public void SetTextColor(Color color)
        {
            _editor.SelectionColor = color;
        }

        public Color GetCurrentTextColor()
        {
            return _editor.SelectionColor;
        }
    }
}
