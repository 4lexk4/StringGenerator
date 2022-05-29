using NUnit.Framework;
using System;

namespace StringGenerator.Tests.Chunks
{
    [TestFixture]
    public class FileChunkTest
    {
        [Test]
        public void Constructor_ThrowsException_IfParameterIsNull()
        {
            Assert.Throws<ArgumentException>(() => Chunk.FromFile<string>(null));
        }

        [Test]
        public void Constructor_ThrowsException_IfFileDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => Chunk.FromFile<string>("test_filename.txt"));
        }

        [Test]
        public void Increment_GoesThroughAllValues_AfterCalls()
        {
            using(var tempFile = new TempFile())
            {
                tempFile.WriteAllLines(0, 1, 2);

                var fileChunk = Chunk.FromFile<int>(tempFile.FileName);

                for (var i = 0; i < 3; i++)
                {
                    Assert.AreEqual(i, fileChunk.Value);
                    Assert.AreEqual(i == 2, fileChunk.Increment());
                }
            }
        }

        [Test]
        public void Value_CanBeSet_IfPresentInCollection()
        {
            using (var tempFile = new TempFile())
            {
                tempFile.WriteAllLines("row0", "row1", "row2");

                var fileChunk = Chunk.FromFile<string>(tempFile.FileName);

                Assert.AreEqual($"row0", fileChunk.Value);
                fileChunk.Value = "row2";
                Assert.AreEqual($"row2", fileChunk.Value);
            }
        }


        [Test]
        public void SetValue_ThrowsException_IfValueIsNotPresentInCollection()
        {
            using (var tempFile = new TempFile())
            {
                tempFile.WriteAllLines(0, 1, 2);

                var fileChunk = Chunk.FromFile<int>(tempFile.FileName);

                Assert.AreEqual(0, fileChunk.Value);

                Assert.Throws<ArgumentException>(() => 
                { 
                    fileChunk.Value = 4;
                });
            }
        }
    }
}
