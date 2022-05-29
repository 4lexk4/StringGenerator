using NUnit.Framework;
using System;

namespace StringGenerator.Tests.Chunks
{
    [TestFixture]
    public class DictionaryChunkTest
    {
        [Test]
        public void Constructor_ThrowsException_IfParameterIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Chunk.Collection<int>(null));
        }

        [Test]
        public void Constructor_ThrowsException_IfCollectionIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => Chunk.Collection(new int[0]));
        }

        [Test]
        public void Increment_GoesThrowAllValues_AfterCalls()
        {
            var dictionaryChunk = Chunk.Collection(0, 1, 2);

            for (var i = 0; i < 3; i++)
            {
                Assert.AreEqual(i, dictionaryChunk.Value);
                Assert.AreEqual(i == 2, dictionaryChunk.Increment());
            }
        }

        [Test]
        public void Reset_SetsValueToDefault()
        {
            var dictionaryChunk = Chunk.Collection(0, 1, 2, 3, 4);

            dictionaryChunk.Value = 3;
            Assert.AreEqual(3, dictionaryChunk.Value);

            dictionaryChunk.Reset();
            Assert.AreEqual(0, dictionaryChunk.Value);
        }

        [Test]
        public void Value_CanBeSet_IfPresentInCollection()
        {
            var dictionaryChunk = Chunk.Collection(0, 1, 2);

            Assert.AreEqual(0, dictionaryChunk.Value);
            dictionaryChunk.Value = 2;
            Assert.AreEqual(2, dictionaryChunk.Value);
        }

        [Test]
        public void SetValue_ThrowsException_IfValueIsNotPresentInCollection()
        {
            var dictionaryChunk = Chunk.Collection(0, 1, 2);

            Assert.AreEqual(0, dictionaryChunk.Value);
            Assert.Throws<ArgumentException>(() =>
            {
                dictionaryChunk.Value = 3;
            });
        }
    }
}
