using System.Windows.Forms;

namespace Lab_6
{
    public class TextAlignmentManager
    {
        private readonly RichTextBox _editor;

        public TextAlignmentManager(RichTextBox editor)
        {
            _editor = editor;
        }

        public void SetAlignment(HorizontalAlignment alignment)
        {
            _editor.SelectionAlignment = alignment;
        }

        public HorizontalAlignment GetCurrentAlignment()
        {
            return _editor.SelectionAlignment;
        }
    }
}
