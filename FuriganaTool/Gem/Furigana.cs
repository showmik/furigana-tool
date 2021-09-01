using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gem
{
    public class Furigana
    {
        private string ReadingHtml => Concat(x => x.ReadingHtml);
        public string RubySyntaxResult => $"<ruby>{ReadingHtml}</ruby>";

        private readonly IEnumerable<ISegment> _segments;

        public Furigana(string reading)
        {
            _segments = reading != null ?
                new FuriganaParser(reading).Parse() :
                Enumerable.Empty<ISegment>();
        }

        private string Concat(Func<ISegment, string> f)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (string text in _segments.Select(f))
            {
                stringBuilder.Append(text);
            }
            return stringBuilder.ToString();
        }
    }
}