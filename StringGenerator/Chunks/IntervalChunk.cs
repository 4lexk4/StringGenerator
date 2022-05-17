namespace StringGenerator.Chunks
{
    internal sealed class IntervalChunk : IChunk
    {
        private readonly int _from;
        private readonly int _to;
        private int _currentValue;

        public IntervalChunk(int from, int to)
        {
            if (from > to) throw new ArgumentException($"From ({from}) cannot be grater than to ({to})", nameof(from));

            _from = from;
            _to = to;

            Reset();
        }

        public string Value => _currentValue.ToString();

        public bool Increment()
        {
            if (_currentValue == int.MaxValue)
            {
                _currentValue = _from;
                return true;
            }

            _currentValue++;

            if (_currentValue > _to)
            {
                _currentValue = _from;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _currentValue = _from;
        }
    }
}
