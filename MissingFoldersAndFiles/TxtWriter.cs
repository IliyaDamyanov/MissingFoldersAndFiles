using System.IO;

namespace MissingFoldersAndFiles
{
    public class TxtWriter : IWriter
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
