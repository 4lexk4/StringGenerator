namespace StringGenerator.Chunks
{
    internal sealed class DictionaryChunk<T> : GenericCollectionChunk<T> where T : IEquatable<T>
    {
        public DictionaryChunk(params T[] values) : base(values)
        {
        }
    }
}
