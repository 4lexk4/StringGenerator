using System;
using System.IO;
using System.Linq;

namespace StringGenerator.Tests
{
    internal sealed class TempFile : IDisposable
    {
        public string FileName { get; } = Path.GetTempFileName();

        public void WriteAllLines<T>(params T[] lines)
        {
            if (lines == null) return;

            File.WriteAllLines(FileName, lines.Select(x => x?.ToString() ?? string.Empty));
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
