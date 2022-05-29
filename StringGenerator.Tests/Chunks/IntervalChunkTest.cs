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
                Assert.AreEqual(i, intervalChunk.Value);
                Assert.AreEqual(i == 2, intervalChunk.Increment());
            }
        }

        [Test]
        public void Increment_HandlesMaxValue_IfReached()
        {
            var intervalChunk = Chunk.FromTo(int.MaxValue, int.MaxValue);

            Assert.AreEqual(int.MaxValue, intervalChunk.Value);
            Assert.IsTrue(intervalChunk.Increment());
            Assert.AreEqual(int.MaxValue, intervalChunk.Value);
        }

        [Test]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(4)]
        public void SetValue_CanBeSet(int value)
        {
            var intervalChunk = Chunk.FromTo(0, 4);

            Assert.AreEqual(0, intervalChunk.Value);

            intervalChunk.Value = value;

            Assert.AreEqual(value, intervalChunk.Value);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(5)]
        public void SetValue_ThrowsException_IfValueIsOutsideBorders(int value)
        {
            var intervalChunk = Chunk.FromTo(0, 4);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                intervalChunk.Value = value;
            });
        }
    }
}
