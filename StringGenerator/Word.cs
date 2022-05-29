using System.Text;

namespace StringGenerator
{
    public sealed class Word
    {
        private readonly IList<IChunk> _chunks = new List<IChunk>();

        public Word AddChunk(IChunk chunk)
        {
            if (chunk is null) throw new ArgumentNullException(nameof(chunk));

            _chunks.Add(chunk);

            return this;
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
