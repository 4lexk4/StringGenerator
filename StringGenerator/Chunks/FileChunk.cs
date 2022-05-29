namespace StringGenerator.Chunks
{
    internal sealed class FileChunk<T> : GenericCollectionChunk<T> where T : IEquatable<T>
    {
        public FileChunk(string fileName) : base(File.ReadAllLines(fileName).Select(x => Convert.ChangeType(x, typeof(T))).Cast<T>().ToArray())
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException($"'{nameof(fileName)}' cannot be null or whitespace.", nameof(fileName));
            if (!File.Exists(fileName)) throw new ArgumentException($"File '{fileName}' doesn't exist", nameof(fileName));
        }
    }
}
