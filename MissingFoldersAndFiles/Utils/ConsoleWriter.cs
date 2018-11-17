using MissingFoldersAndFiles.Abstractions;
using System;

namespace MissingFoldersAndFiles.Utils
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
