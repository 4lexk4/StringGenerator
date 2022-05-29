namespace StringGenerator
{
    public interface IChunk
    {
        void Reset();

        bool Increment();

        string Value { get; }
    }
}