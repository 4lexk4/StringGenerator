namespace StringGenerator.Chunks
{
    internal sealed class FileChunk : IChunk
    {
        private readonly IList<string> _rows = new List<string>();
        private int _rowIndex;

        public FileChunk(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException($"'{nameof(fileName)}' cannot be null or whitespace.", nameof(fileName));
            if (!File.Exists(fileName)) throw new ArgumentException($"File '{fileName}' doesn't exist", nameof(fileName));

            _rows = File.ReadAllLines(fileName);
        }

        public string Value => _rows[_rowIndex];

        public bool Increment()
        {
            _rowIndex++;
            if (_rowIndex >= _rows.Count)
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
