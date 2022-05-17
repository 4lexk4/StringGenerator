namespace StringGenerator.Chunks
{
    internal sealed class DictionaryChunk<T> : IChunk
    {
        private readonly IReadOnlyList<T> _values;
        private int _index;

        public DictionaryChunk(IReadOnlyList<T> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (values.Count == 0) throw new ArgumentException("Collection cannot be empty", nameof(values));

            _values = values;
        }

        public string Value => _values[_index]?.ToString() ?? string.Empty;

        public bool Increment()
        {
            _index++;

            if (_index >= _values.Count)
            {
                _index = 0;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _index = 0;
        }
    }
}
