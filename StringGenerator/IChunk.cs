namespace StringGenerator
{
    public interface IChunk
    {
        string Value { get; set; }

        void Reset();

        bool Increment();
    }
}