namespace StringGenerator.Chunks
{
    public abstract class GenericCollectionChunk<T> : IChunk
    {
        private readonly T[] _rows;
        private int _rowIndex;

        protected GenericCollectionChunk(params T[] rows)
        {
            if (rows == null) throw new ArgumentNullException(nameof(rows));
            if (rows.Length == 0) throw new ArgumentException("Collection of rows cannot be empty", nameof(rows));

            _rows = rows;
        }

        public string Value
        {
            get
            {
                return _rows[_rowIndex]?.ToString() ?? string.Empty;
            }
            set
            {
                for(_rowIndex = 0; _rowIndex < _rows.Length; _rowIndex++)
                {
                    if (string.Equals(_rows[_rowIndex]?.ToString(), value, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return;
                    }
                }
                throw new ArgumentException($"{value} doesn't belong to collection");
            }
        }

        public bool Increment()
        {
            _rowIndex++;
            if (_rowIndex >= _rows.Length)
            {
                _rowIndex = 0;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _rowIndex = 0;
        }
    }
}
