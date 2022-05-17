using NUnit.Framework;
using System;
using System.Collections.Generic;

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
            Assert.Throws<ArgumentException>(() => Chunk.Collection<int>(new List<int> {}));
        }

        [Test]
        public void Increment_GoesThrowAllValues_AfterCalls()
        {
            var dictionaryChunk = Chunk.Collection<int>(new List<int> { 0, 1, 2 });

            for (var i = 0; i < 3; i++)
            {
                Assert.AreEqual(i.ToString(), dictionaryChunk.Value);
                Assert.AreEqual(i == 2, dictionaryChunk.Increment());
            }
        }
    }
}
