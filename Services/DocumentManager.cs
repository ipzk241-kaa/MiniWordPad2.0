using System;
using System.IO;
using System.Windows.Forms;

namespace Lab_6
{
    public class DocumentManager
    {
        private const string OpenFileFilter = "Markdown Files (*.md)|*.md|Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|All files (*.*)|*.*";
        private const string SaveFileFilter = "Markdown Files (*.md)|*.md|Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";

        private readonly RichTextBox _editor;

        public string OpenedDocumentPath { get; private set; } = string.Empty;
        public bool IsOpened => !string.IsNullOrEmpty(OpenedDocumentPath);
        public bool IsUnsaved { get; private set; } = false;
        public string DefaultSaveDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public DocumentManager(RichTextBox editor)
        {
            _editor = editor ?? throw new ArgumentNullException(nameof(editor));
        }

        public void CreateNewDocument()
        {
            _editor.Clear();
            OpenedDocumentPath = string.Empty;
            IsUnsaved = false;
        }

        public void OpenDocument()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = OpenFileFilter;
                dialog.Title = "Open File";
                dialog.InitialDirectory = DefaultSaveDirectory;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        LoadFile(dialog.FileName);
                        OpenedDocumentPath = dialog.FileName;
                        IsUnsaved = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void SaveDocument()
        {
            if (IsOpened)
            {
                try
                {
                    SaveFile(OpenedDocumentPath);
                    IsUnsaved = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                SaveDocumentAs();
            }
        }

        public void SaveDocumentAs()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = SaveFileFilter;
                dialog.Title = "Save As";
                dialog.InitialDirectory = DefaultSaveDirectory;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        SaveFile(dialog.FileName);
                        OpenedDocumentPath = dialog.FileName;
                        IsUnsaved = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void MarkUnsaved()
        {
            IsUnsaved = true;
        }

        private void LoadFile(string path)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();
            if (ext == ".txt" || ext == ".md")
            {
                _editor.Text = File.ReadAllText(path);
            }
            else
            {
                _editor.LoadFile(path);
            }
        }

        private void SaveFile(string path)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();
            if (ext == ".txt" || ext == ".md")
            {
                File.WriteAllText(path, _editor.Text);
            }
            else
            {
                _editor.SaveFile(path);
            }
        }
    }
}
