﻿using StringGenerator.Chunks;

namespace StringGenerator
{
    public sealed class Chunk
    {
        public static IChunk Create<T>(IReadOnlyList<T> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (collection.Count == 0) throw new ArgumentException("Collection cannot be empty", nameof(collection));

            return new DictionaryChunk<T>(collection);
        }

        public static IChunk Create(int from, int to)
        {
            if (from > to) throw new ArgumentException($"From ({from}) cannot be grater than to ({to})", nameof(from));

            return new IntervalChunk(from, to);
        }

        public static IChunk Create(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException($"'{nameof(fileName)}' cannot be null or whitespace.", nameof(fileName));
            if (!File.Exists(fileName)) throw new ArgumentException($"File '{fileName}' doesn't exist", nameof(fileName));

            return new FileChunk(fileName);
        }
    }
}