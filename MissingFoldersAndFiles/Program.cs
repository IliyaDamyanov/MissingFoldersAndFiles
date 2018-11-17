using MissingFoldersAndFiles.Utils;
using System;

namespace MissingFoldersAndFiles
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleWriter consoleWriter = new ConsoleWriter();
            Engine engine = new Engine(consoleWriter, new FileWriter("MissingPaths.txt"), new ConsoleReader());
            try
            {
                engine.Start();
            }
            catch (Exception exception)
            {
                consoleWriter.Write(exception.Message);
            }
        }
    }
}
