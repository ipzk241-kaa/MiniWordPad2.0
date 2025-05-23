using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class MarkdownPreview
    {
        private readonly IMarkdownSource _source;
        private readonly IMarkdownTarget _target;
        private readonly IMarkdownParser _parser;

        public MarkdownPreview(IMarkdownSource source, IMarkdownTarget target, IMarkdownParser parser)
        {
            _source = source;
            _target = target;
            _parser = parser;
        }

        public void Execute()
        {
            string markdown = _source.GetMarkdownText();
            string html = _parser.Parse(markdown);
            _target.ShowHtml(html);
        }
    }
}
