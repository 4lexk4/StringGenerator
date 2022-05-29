namespace StringGenerator.Chunks
{
    public abstract class GenericChunk<T> : IChunk where T : IEquatable<T>
    {
        public abstract bool Increment();

        public abstract void Reset();

        public abstract T Value { get; set; }

        string IChunk.Value => Value?.ToString() ?? string.Empty;
    }
}
