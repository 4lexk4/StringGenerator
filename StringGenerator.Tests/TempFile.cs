using System;
using System.IO;

namespace StringGenerator.Tests
{
    internal sealed class TempFile : IDisposable
    {
        public string FileName { get; } = Path.GetTempFileName();

        public void WriteAllLines(params string[] lines)
        {
            File.WriteAllLines(FileName, lines);
        }

        public string[] ReadAllLines()
        {
            return File.ReadAllLines(FileName);
        }

        public void Dispose()
        {
            File.Delete(FileName);
        }
    }
}
