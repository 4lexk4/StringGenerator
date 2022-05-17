using NUnit.Framework;

namespace StringGenerator.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Increment_GoesThrowAllDictionaryValues_WhenCalls()
        {
            var word = new Word(Chunk.Collection<char>(new char[] { 'a', 'b' }), Chunk.Collection<int>(new int[] { 1, 2, 3 }));
            var expectedValues = new string[] { "a1", "a2", "a3", "b1", "b2", "b3" };

            for(var i = 0; i < expectedValues.Length; i++)
            {
                Assert.AreEqual(expectedValues[i], word.Value);
                Assert.AreEqual(i == expectedValues.Length - 1, word.Increment());
            }
        }

        [Test]
        public void Increment_GoesThrowAllIntervalValues_WhenCalls()
        {
            var word = new Word(Chunk.FromTo(1, 2), Chunk.FromTo(3, 4));
            var expectedValues = new string[] { "13", "14", "23", "24" };

            for (var i = 0; i < expectedValues.Length; i++)
            {
                Assert.AreEqual(expectedValues[i], word.Value);
                Assert.AreEqual(i == expectedValues.Length - 1, word.Increment());
            }
        }

        [Test]
        public void Increment_GoesThrowAllFileValues_WhenCalls()
        {
            using(var tempFile1 = new TempFile())
            {
                using (var tempFile2 = new TempFile())
                {
                    tempFile1.WriteAllLines("row00", "row01", "row02");
                    tempFile2.WriteAllLines("row10", "row11");

                    var word = new Word(Chunk.File(tempFile1.FileName), Chunk.File(tempFile2.FileName));
                    var expectedValues = new string[] { "row00row10", "row00row11", "row01row10", "row01row11", "row02row10", "row02row11" };

                    for (var i = 0; i < expectedValues.Length; i++)
                    {
                        Assert.AreEqual(expectedValues[i], word.Value);
                        Assert.AreEqual(i == expectedValues.Length - 1, word.Increment());
                    }
                }
            }
        }
    }
}