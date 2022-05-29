using StringGenerator.Chunks;

namespace StringGenerator
{
    public static class Chunk
    {
        public static GenericChunk<T> Collection<T>(params T[] collection) where T : IEquatable<T>
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (collection.Length == 0) throw new ArgumentException("Collection cannot be empty", nameof(collection));

            return new DictionaryChunk<T>(collection);
        }

        public static GenericChunk<int> FromTo(int from, int to)
        {
            if (from > to) throw new ArgumentException($"From ({from}) cannot be grater than to ({to})", nameof(from));

            return new IntervalChunk(from, to);
        }

        public static GenericChunk<T> FromFile<T>(string fileName) where T : IEquatable<T>
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException($"'{nameof(fileName)}' cannot be null or whitespace.", nameof(fileName));
            if (!File.Exists(fileName)) throw new ArgumentException($"File '{fileName}' doesn't exist", nameof(fileName));

            return new FileChunk<T>(fileName);
        }
    }
}
