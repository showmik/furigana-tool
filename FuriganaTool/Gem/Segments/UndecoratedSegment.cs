namespace Gem.Segments
{
    public class UndecoratedSegment : ISegment
    {
        private readonly string _baseText;

        public UndecoratedSegment(string baseText)
        {
            _baseText = baseText;
        }

        public string ReadingHtml => _baseText;
    }
}