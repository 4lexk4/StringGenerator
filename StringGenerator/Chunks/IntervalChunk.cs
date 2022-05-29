namespace StringGenerator.Chunks
{
    internal sealed class IntervalChunk : GenericChunk<int>
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

        public override int Value 
        { 
            get
            {
                return _currentValue;
            }
            set
            {
                if (value > _to || value < _from) throw new ArgumentOutOfRangeException(nameof(value), $"Value ({value}) must be between From ({_from}) and To ({_to})");

                _currentValue = value;
            }
        }

        public override bool Increment()
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

        public override void Reset()
        {
            _currentValue = _from;
        }
    }
}
