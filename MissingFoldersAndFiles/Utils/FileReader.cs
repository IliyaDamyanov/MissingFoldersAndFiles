using MissingFoldersAndFiles.Abstractions;
using System.IO;

namespace MissingFoldersAndFiles.Utils
{
    public class FileReader : IReader
    {
        private readonly string filePath;

        public FileReader(string filePath)
        {
            this.filePath = filePath;
        }

        public string Read()
        {
            string text = string.Empty;
            using (StreamReader streamReader = new StreamReader(this.filePath))
            {
                text = streamReader.ReadToEnd();
            }

            return text;
        }
    }
}
