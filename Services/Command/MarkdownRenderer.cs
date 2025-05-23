using System.Windows.Forms;

namespace Lab_6
{
    public class MarkdownRenderer
    {
        private readonly IMarkdownParser _parser;

        public MarkdownRenderer(IMarkdownParser parser)
        {
            _parser = parser;
        }

        public void Render(string markdown, WebBrowser browser)
        {
            string html = _parser.Parse(markdown);
            browser.DocumentText = html;
        }
    }
}
