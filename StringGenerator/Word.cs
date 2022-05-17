using System.Text;

namespace StringGenerator
{
    /// <summary>
    /// Represents the word that can be incremented. Contains parts (chunks) that can be changed.
    /// First chunk is in the beginning of the word.
    /// </summary>
    public sealed class Word
    {
        private readonly IReadOnlyList<IChunk> _chunks;

        public Word(IReadOnlyList<IChunk> chunks)
        {
            if (chunks == null) throw new ArgumentNullException(nameof(chunks));
            if (chunks.Count == 0) throw new ArgumentException("Collection of chunks cannot be empty", nameof(chunks));

            _chunks = chunks;
        }

        public Word(params IChunk[] chunks) : this(chunks?.ToList() ?? new List<IChunk>())
        {
        }

        /// <summary>
        /// Gets the string value of the word by getting string value for each word.
        /// </summary>
        public string Value
        {
            get
            {
                var sb = new StringBuilder();

                foreach(var chunkSet in _chunks)
                {
                    sb.Append(chunkSet.Value);
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Sets the word value to default.
        /// </summary>
        public void Reset()
        {
            foreach (var chunkSet in _chunks)
            {
                chunkSet.Reset();
            }
        }

        /// <summary>
        /// Increments the word by incrementing it's last chunk value by 1.
        /// </summary>
        /// <returns>true, if the new value is out of range. In this case all chunks are set to first value</returns>
        public bool Increment()
        {
            bool Increment(int index)
            {
                if (index < 0) return true;

                return _chunks[index].Increment() ? Increment(index - 1) : false;
            }

            return Increment(_chunks.Count - 1);
        }
    }
}
