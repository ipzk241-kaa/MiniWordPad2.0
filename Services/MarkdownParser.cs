using Markdig.Parsers;
using Markdig;

namespace Lab_6
{
    public interface IMarkdownParser
    {
        string Parse(string markdown);
    }
    public class MarkdownParser : IMarkdownParser
    {
        public string Parse(string markdown)
        {
            return Markdown.ToHtml(markdown);
        }
    }
}
