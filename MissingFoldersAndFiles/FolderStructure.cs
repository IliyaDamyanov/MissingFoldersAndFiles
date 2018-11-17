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

        public FolderStructure(IWriter writer)
        {
            this.paths = new Dictionary<string, string>();
            this.writer = writer;
        }

        public IDictionary<string, string> AllPathsFinder(string entryFolder)
        {
            string currentFolder = entryFolder;

            try
            {
                foreach (string folder in Directory.GetDirectories(currentFolder))
                {
                    paths.Add(folder, "folder");
                    foreach (string file in Directory.GetFiles(folder))
                    {
                        paths.Add(file, "file");
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
