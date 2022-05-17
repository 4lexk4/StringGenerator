using NUnit.Framework;
using System;

namespace StringGenerator.Tests.Chunks
{
    [TestFixture]
    public class IntervalChunkTest
    {
        [Test]
        public void Constructor_ThrowsException_IfFromBiggerThanTo()
        {
            Assert.Throws<ArgumentException>(() => Chunk.FromTo(2, 1));
        }

        [Test]
        public void Increment_GoesThrowAllValues_AfterCalls()
        {
            var intervalChunk = Chunk.FromTo(0, 2);

            for (var i = 0; i < 3; i++)
            {
                Assert.AreEqual(i.ToString(), intervalChunk.Value);
                Assert.AreEqual(i == 2, intervalChunk.Increment());
            }
        }

        [Test]
        public void Increment_HandlesMaxValue_IfReached()
        {
            var intervalChunk = Chunk.FromTo(int.MaxValue, int.MaxValue);

            Assert.AreEqual(int.MaxValue.ToString(), intervalChunk.Value);
            Assert.IsTrue(intervalChunk.Increment());
            Assert.AreEqual(int.MaxValue.ToString(), intervalChunk.Value);
        }
    }
}
