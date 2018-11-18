using MissingFoldersAndFiles.Utils;
using System;

namespace MissingFoldersAndFiles
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleWriter consoleWriter = new ConsoleWriter();
            ConsoleReader consoleReader = new ConsoleReader();
            consoleWriter.Write("Enter the original path.");
            //string originalPath = consoleReader.Read();
            string originalPath = @"C:\Users\IliyaDamyanov\Desktop\CopyTesting";
            consoleWriter.Write("Enter the copied path.");
            //string copiedPath = consoleReader.Read();
            string copiedPath = @"C:\Users\IliyaDamyanov\Desktop\New folder (2)\CopyTesting";

            Engine engine = new Engine(consoleWriter, new FileWriter("MissingPaths.txt"), consoleReader, originalPath, copiedPath);
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
