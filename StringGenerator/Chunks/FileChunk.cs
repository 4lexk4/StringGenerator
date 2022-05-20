namespace StringGenerator.Chunks
{
    internal sealed class FileChunk : GenericCollectionChunk<string>
    {
        public FileChunk(string fileName) : base(File.ReadAllLines(fileName))
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException($"'{nameof(fileName)}' cannot be null or whitespace.", nameof(fileName));
            if (!File.Exists(fileName)) throw new ArgumentException($"File '{fileName}' doesn't exist", nameof(fileName));
        }
    }
}
