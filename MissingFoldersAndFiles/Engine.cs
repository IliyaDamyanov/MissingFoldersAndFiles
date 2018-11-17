using MissingFoldersAndFiles.Abstractions;
using System.Collections.Generic;

namespace MissingFoldersAndFiles
{
    public class Engine
    {
        private readonly IReader consoleReader;
        private readonly IWriter consoleWriter;
        private readonly IWriter fileWriter;

        public Engine(IWriter consoleWriter, IWriter fileWriter, IReader consoleReader)
        {
            this.consoleWriter = consoleWriter;
            this.fileWriter = fileWriter;
            this.consoleReader = consoleReader;
        }

        public void Start()
        {
            FolderStructure originalStructure = new FolderStructure(this.consoleWriter);
            this.consoleWriter.Write("Enter the original path.");
            ICollection<string> originalPaths = originalStructure.AllPathsFinder(this.consoleReader.Read()).Keys;

            FolderStructure copiedStructure = new FolderStructure(this.consoleWriter);
            this.consoleWriter.Write("Enter the copied path.");
            IDictionary<string, string> copiedPaths = copiedStructure.AllPathsFinder(this.consoleReader.Read());

            MissingPathsFinder missingPathsFinder = new MissingPathsFinder(this.fileWriter, originalPaths, copiedPaths);
            missingPathsFinder.MissingPathsPrint();
        }
    }
}
