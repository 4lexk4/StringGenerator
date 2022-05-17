namespace StringGenerator
{
    /// <summary>
    /// Ordered collection of possible chunk values.
    /// </summary>
    public interface IChunk
    {
        /// <summary>
        /// Get the current value.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Set value to default.
        /// </summary>
        void Reset();

        /// <summary>
        /// Increment value. Returns true, if value after incrementation is out of range. In this case value is set to default.
        /// </summary>
        /// <returns>true, if value after incrementation is out of range</returns>
        bool Increment();
    }
}