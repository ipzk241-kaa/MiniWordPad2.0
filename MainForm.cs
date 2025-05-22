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
        public MainForm()
        {
            InitializeComponent();
            documentManager = new DocumentManager(RichTextBoxEditor);
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
    }
}
