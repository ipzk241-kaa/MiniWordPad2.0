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
        private TextColorManager textColorManager;
        private TextAlignmentManager textAlignmentManager;
        private WindowResizeHandler resizeHandler;
        private ThemeManager themeManager;

        public MainForm()
        {
            InitializeComponent();
            InitializeFonts();
            documentManager = new DocumentManager(RichTextBoxEditor);
            fontManager = new FontManager(RichTextBoxEditor);
            textColorManager = new TextColorManager(RichTextBoxEditor);
            textAlignmentManager = new TextAlignmentManager(RichTextBoxEditor);
            resizeHandler = new WindowResizeHandler(this);
            themeManager = new ThemeManager(this, RichTextBoxEditor);
            RichTextBoxEditor.ContextMenuStrip = CreateContextMenu();
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

                FontColorPickerButton.FlatAppearance.BorderColor = RichTextBoxEditor.SelectionColor;
                FontBackColorPickerButton.FlatAppearance.BorderColor = RichTextBoxEditor.SelectionBackColor;

                checkBoxTextBoxAlignLeft.Checked = false;
                checkBoxTextBoxAlignCenter.Checked = false;
                checkBoxTextBoxAlignRight.Checked = false;

                switch (RichTextBoxEditor.SelectionAlignment)
                {
                    case HorizontalAlignment.Left:
                        checkBoxTextBoxAlignLeft.Checked = true;
                        break;
                    case HorizontalAlignment.Center:
                        checkBoxTextBoxAlignCenter.Checked = true;
                        break;
                    case HorizontalAlignment.Right:
                        checkBoxTextBoxAlignRight.Checked = true;
                        break;
                }
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

        private void FontColorPickerButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    textColorManager.SetTextColor(colorDialog.Color);
                }
            }
        }

        private void checkBoxTextBoxAlignLeft_CheckedChanged(object sender, EventArgs e)
        {
            textAlignmentManager.SetAlignment(HorizontalAlignment.Left);
        }

        private void checkBoxTextBoxAlignCenter_CheckedChanged(object sender, EventArgs e)
        {
            textAlignmentManager.SetAlignment(HorizontalAlignment.Center);
        }

        private void checkBoxTextBoxAlignRight_CheckedChanged(object sender, EventArgs e)
        {
            textAlignmentManager.SetAlignment(HorizontalAlignment.Right);
        }
        protected override void WndProc(ref Message m)
        {
            if (resizeHandler != null && resizeHandler.HandleWndProc(ref m))
            {
                return;
            }

            base.WndProc(ref m);
        }
        // Все що нижче потрібне для того щоб перетягувати вікно так як я повністю забрав края
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void WindowDrag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void whiteColorMenuItem_Click(object sender, EventArgs e)
        {
            themeManager.ApplyLightTheme();
        }

        private void blackThemeMenuItem_Click(object sender, EventArgs e)
        {
            themeManager.ApplyDarkTheme();
        }

        private void BackColorSelector_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    themeManager.SetBackgroundColor(colorDialog.Color);
                }
            }
        }

        private void BackColorPickerMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    themeManager.SetForegroundColor(colorDialog.Color);
                }
            }
        }
        private ContextMenuStrip CreateContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Копіювати");
            ToolStripMenuItem cutMenuItem = new ToolStripMenuItem("Вирізати");
            ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("Вставити");
            ToolStripMenuItem fontMenuItem = new ToolStripMenuItem("Шрифт");

            copyMenuItem.Click += CopyMenuItem_Click;
            cutMenuItem.Click += CutMenuItem_Click;
            pasteMenuItem.Click += PasteMenuItem_Click;
            fontMenuItem.Click += FontMenuItem_Click;

            contextMenu.Items.Add(copyMenuItem);
            contextMenu.Items.Add(cutMenuItem);
            contextMenu.Items.Add(pasteMenuItem);
            contextMenu.Items.Add(fontMenuItem);

            return contextMenu;
        }
        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxEditor.Copy();
        }

        private void CutMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxEditor.Cut();
        }

        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxEditor.Paste();
        }
        private void FontMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    RichTextBoxEditor.SelectionFont = fontDialog.Font;
                }
            }
        }

        private void PastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                RichTextBoxEditor.Paste();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RichTextBoxEditor.SelectionLength > 0)
                RichTextBoxEditor.Copy();
        }

        private void CutoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RichTextBoxEditor.SelectionLength > 0)
                RichTextBoxEditor.Cut();
        }

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxEditor.Undo();
        }

        private void RepitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (RichTextBoxEditor.CanRedo == true)
                if (RichTextBoxEditor.RedoActionName != "Delete")
                    RichTextBoxEditor.Redo();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxEditor.SelectAll();
        }
    }
}
