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
            int lastSlashIndex = currentFolder.LastIndexOf('\\');

            try
            {
                foreach (string folder in Directory.GetDirectories(currentFolder))
                {
                    paths.Add(folder.Substring(lastSlashIndex + 1, folder.Length - lastSlashIndex - 1), "folder");
                    foreach (string file in Directory.GetFiles(folder))
                    {
                        paths.Add(file.Substring(lastSlashIndex + 1, file.Length - lastSlashIndex - 1), "file");
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
