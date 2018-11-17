using MissingFoldersAndFiles.Abstractions;
using System.IO;

namespace MissingFoldersAndFiles.Utils
{
    public class FileWriter : IWriter
    {
        private readonly string filePath;

        public FileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public void Write(string text)
        {
            using (StreamWriter streamWriter = new StreamWriter(this.filePath))
            {
                streamWriter.WriteLine(text);
            }
        }
    }
}
