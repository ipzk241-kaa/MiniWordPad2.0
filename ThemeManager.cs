using System.Drawing;
using System.Windows.Forms;

namespace Lab_6
{
    public class ThemeManager
    {
        private readonly Form mainForm;
        private readonly RichTextBox editor;

        public ThemeManager(Form form, RichTextBox editor)
        {
            this.mainForm = form;
            this.editor = editor;
        }

        public void ApplyDarkTheme()
        {
            mainForm.BackColor = Color.Black;
            mainForm.ForeColor = Color.White;
            editor.BackColor = Color.Black;
            editor.ForeColor = Color.White;
        }
        public void ApplyLightTheme()
        {
            mainForm.BackColor = Color.White;
            mainForm.ForeColor = Color.Black;
            editor.BackColor = Color.White;
            editor.ForeColor = Color.Black;
        }

        public void SetBackgroundColor(Color color)
        {
            mainForm.BackColor = color;
            editor.BackColor = color;
        }

        public void SetForegroundColor(Color color)
        {
            mainForm.ForeColor = color;
            editor.ForeColor = color;
        }
    }
}
