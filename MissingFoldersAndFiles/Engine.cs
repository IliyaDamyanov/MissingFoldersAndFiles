using MissingFoldersAndFiles.Abstractions;
using System.Collections.Generic;

namespace MissingFoldersAndFiles
{
    public class Engine
    {
        private readonly IReader consoleReader;
        private readonly IWriter consoleWriter;
        private readonly IWriter fileWriter;
        private readonly string originalPath;
        private readonly string copiedPath;
        private readonly string preFolderPath;


        public Engine(IWriter consoleWriter, IWriter fileWriter, IReader consoleReader, string originalPath, string copiedPath)
        {
            this.consoleWriter = consoleWriter;
            this.fileWriter = fileWriter;
            this.consoleReader = consoleReader;
            this.originalPath = originalPath;
            this.copiedPath = copiedPath;
            this.preFolderPath = this.SeparatingPreFolderPath();
        }

        private string SeparatingPreFolderPath()
        {
            int lastSlashIndex = this.originalPath.LastIndexOf('\\');
            string originalPreFolderPath = this.originalPath.Substring(0, lastSlashIndex + 1);

            return originalPreFolderPath;
        }

        public void Start()
        {
            FolderStructure originalStructure = new FolderStructure(this.consoleWriter, this.preFolderPath.Length);
            ICollection<string> originalPaths = originalStructure.AllPathsFinder(this.originalPath).Keys;

            FolderStructure copiedStructure = new FolderStructure(this.consoleWriter, this.preFolderPath.Length);
            IDictionary<string, string> copiedPaths = copiedStructure.AllPathsFinder(this.copiedPath);

            MissingPathsFinder missingPathsFinder = new MissingPathsFinder(this.fileWriter, originalPaths, copiedPaths, this.preFolderPath);
            missingPathsFinder.MissingPathsPrint();
        }
    }
}
