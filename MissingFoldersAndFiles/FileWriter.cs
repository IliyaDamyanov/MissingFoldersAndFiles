using System.IO;

namespace MissingFoldersAndFiles
{
    public class FileWriter : IWriter
    {
        public void Write(string text)
        {
            using (StreamWriter streamWriter = new StreamWriter("paths.txt"))
            {
                streamWriter.WriteLine(text);
            }
        }
    }
}
