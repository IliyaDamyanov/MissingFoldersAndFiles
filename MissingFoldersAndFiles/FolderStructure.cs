using MissingFoldersAndFiles.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;

namespace MissingFoldersAndFiles
{
    public class FolderStructure
    {
        private readonly IWriter writer;
        private IDictionary<string, string> paths;
        private readonly int preFolderPathLenght;

        public FolderStructure(IWriter writer, int preFolderPathLenght)
        {
            this.paths = new Dictionary<string, string>();
            this.writer = writer;
            this.preFolderPathLenght = preFolderPathLenght;
        }

        public IDictionary<string, string> AllPathsFinder(string entryFolder)
        {
            string currentFolder = entryFolder;

            try
            {
                foreach (string folder in Directory.GetDirectories(currentFolder))
                {
                    int lastSlashIndex = currentFolder.LastIndexOf('\\');
                    paths.Add(folder.Substring(lastSlashIndex, this.preFolderPathLenght - 1), "folder");
                    foreach (string file in Directory.GetFiles(folder))
                    {
                        paths.Add(file.Substring(lastSlashIndex, this.preFolderPathLenght - 1), "file");
                    }
                    AllPathsFinder(folder);
                }
            }
            catch (Exception exception)
            {
                this.writer.Write(exception.Message);

                throw new Exception("FolderStructure exception");
            }

            return paths;
        }
    }
}
