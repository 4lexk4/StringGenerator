namespace StringGenerator.Chunks
{
    internal sealed class DictionaryChunk<T> : GenericCollectionChunk<T>
    {
        public DictionaryChunk(params T[] values) : base(values)
        {
        }
    }
}
