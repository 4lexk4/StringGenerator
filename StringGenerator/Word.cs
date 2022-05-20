using System.Text;

namespace StringGenerator
{
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

        public void Reset()
        {
            foreach (var chunkSet in _chunks)
            {
                chunkSet.Reset();
            }
        }

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
