using MissingFoldersAndFiles.Abstractions;
using System;

namespace MissingFoldersAndFiles.Utils
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}