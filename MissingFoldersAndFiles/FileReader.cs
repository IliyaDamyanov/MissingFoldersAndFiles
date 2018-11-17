using System.IO;

namespace MissingFoldersAndFiles
{
    public class FileReader : IReader
    {
        public string ReadToEnd()
        {
            string text = string.Empty;
            using (StreamReader streamReader = new StreamReader("txt.txt"))
            {
                text = streamReader.ReadToEnd();
            }

            return text;
        }
    }
}
