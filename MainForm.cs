using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_6
{
    public partial class MainForm : Form
    {
        private DocumentManager documentManager;
        private FontManager fontManager;
        List<string> _FontsName = new List<string>();
        List<float> _FontSize = new List<float>();
        public MainForm()
        {
            InitializeComponent();
            documentManager = new DocumentManager(RichTextBoxEditor);
            fontManager = new FontManager(RichTextBoxEditor);
            InitializeFonts();
        }
        private void CreateFileMenuButton_Click(object sender, EventArgs e)
        {
            documentManager.CreateNewDocument();
        }

        private void OpenFileMenuButton_Click(object sender, EventArgs e)
        {
            documentManager.OpenDocument();
        }

        private void SaveMenuButton_Click(object sender, EventArgs e)
        {
            documentManager.SaveDocument();
        }

        private void SaveAsMenuButton_Click(object sender, EventArgs e)
        {
            documentManager.SaveDocumentAs();
        }

        private void RichTextBoxEditor_TextChanged(object sender, EventArgs e)
        {
            documentManager.MarkUnsaved();
        }
        private void CloseWindowButton_Click(object sender, EventArgs e)
        {
            if (documentManager.IsUnsaved)
            {
                DialogResult savePrompt = MessageBox.Show("Ви хочете зберегти ваші зміни?", "MiniWordPad", MessageBoxButtons.YesNoCancel);

                switch (savePrompt)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.No:
                        Close();
                        break;
                    case DialogResult.Yes:
                        SaveMenuButton_Click(sender, e);
                        if (!documentManager.IsUnsaved) Close();
                        break;
                }
            }
            else
            {
                Close();
            }
        }
        private void InitializeFonts()
        {
            FontFamily[] fontList = new System.Drawing.Text.InstalledFontCollection().Families;
            foreach (var item in fontList)
                _FontsName.Add(item.Name);

            FontSelectorComboBox.DataSource = _FontsName;
            FontSelectorComboBox.SelectedIndex = 10;
            for (int i = 1; i < 50; i++)
                _FontSize.Add(i);
            FontSizeComboBox.DataSource = _FontSize;
            FontSizeComboBox.SelectedIndex = 10;

        }
        private void FontSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FontSelectorComboBox.SelectedItem != null)
            {
                fontManager.SetFontFamily(FontSelectorComboBox.SelectedItem.ToString());
            }
        }
        private void FontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (float.TryParse(FontSizeComboBox.SelectedItem.ToString(), out float size))
            {
                fontManager.SetFontSize(size);
            }
        }
        private int GetFontIndex(string name)
        {
            return _FontsName.IndexOf(name);
        }
        private void RichTextBoxEditor_SelectionChanged(object sender, EventArgs e)
        {
            if (RichTextBoxEditor.SelectionFont != null)
            {
                checkBoxBold.Checked = RichTextBoxEditor.SelectionFont.Bold;
                checkBoxItalic.Checked = RichTextBoxEditor.SelectionFont.Italic;
                checkBoxUnderline.Checked = RichTextBoxEditor.SelectionFont.Underline;
                checkBoxStrikeout.Checked = RichTextBoxEditor.SelectionFont.Strikeout;

                FontSelectorComboBox.SelectedIndex = GetFontIndex(RichTextBoxEditor.SelectionFont.FontFamily.Name);
                FontSizeComboBox.SelectedItem = RichTextBoxEditor.SelectionFont.Size;
            }
        }

        private void checkBoxBold_CheckedChanged(object sender, EventArgs e)
        {
            fontManager.ToggleBold();
        }

        private void checkBoxItalic_CheckedChanged(object sender, EventArgs e)
        {
            fontManager.ToggleItalic();
        }

        private void checkBoxUnderline_CheckedChanged(object sender, EventArgs e)
        {
            fontManager.ToggleUnderline();
        }

        private void checkBoxStrikeout_CheckedChanged(object sender, EventArgs e)
        {
            fontManager.ToggleStrikeout();
        }

    }
}
