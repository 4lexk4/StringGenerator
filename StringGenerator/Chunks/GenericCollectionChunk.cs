namespace StringGenerator.Chunks
{
    public abstract class GenericCollectionChunk<T> : GenericChunk<T> where T : IEquatable<T>
    {
        private readonly T[] _rows;
        private int _rowIndex;

        protected GenericCollectionChunk(params T[] rows)
        {
            if (rows == null) throw new ArgumentNullException(nameof(rows));
            if (rows.Length == 0) throw new ArgumentException("Collection of rows cannot be empty", nameof(rows));

            _rows = rows;
        }

        public override T Value
        {
            get
            {
                return _rows[_rowIndex];
            }

            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));

                for(_rowIndex = 0; _rowIndex < _rows.Length; _rowIndex++)
                {
                    if (value.Equals(_rows[_rowIndex])) return;
                }

                throw new ArgumentException($"{value} doesn't belong to collection");
            }
        }

        public override bool Increment()
        {
            _rowIndex++;
            if (_rowIndex >= _rows.Length)
            {
                _rowIndex = 0;
                return true;
            }

            return false;
        }

        public override void Reset()
        {
            _rowIndex = 0;
        }
    }
}
