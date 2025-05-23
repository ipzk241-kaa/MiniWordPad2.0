using Markdig.Renderers;
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
    public partial class MarkdownPreviewForm : Form, IMarkdownTarget
    {
        private MarkdownRenderer _markdownRenderer;
        private WindowResizeHandler resizeHandler;
        public WebBrowser PreviewBrowser => markdownPreviewBrowser;
        public MarkdownPreviewForm()
        {
            InitializeComponent();
            resizeHandler = new WindowResizeHandler(this);
        }
        public void ShowHtml(string html)
        {
            markdownPreviewBrowser.DocumentText = html;
        }
        private void CloseWindowButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override void WndProc(ref Message m)
        {
            if (resizeHandler != null && resizeHandler.HandleWndProc(ref m))
            {
                return;
            }

            base.WndProc(ref m);
        }
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
    }
}
