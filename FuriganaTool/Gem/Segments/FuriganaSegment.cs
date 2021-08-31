namespace Gem.Segments
{
    public class FuriganaSegment : ISegment
    {
        private readonly string _baseText;
        private readonly string _furigana;

        public FuriganaSegment(string baseText, string furigana)
        {
            _baseText = baseText;
            _furigana = furigana;
        }

        public string ReadingHtml => $"<rb>{_baseText}</rb><rt>{_furigana}</rt>";
    }
}