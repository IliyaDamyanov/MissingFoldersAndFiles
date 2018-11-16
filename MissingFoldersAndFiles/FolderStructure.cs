using System;
using System.Collections;
using System.IO;

namespace MissingFoldersAndFiles
{
    public class FolderStructure
    {
        private Hashtable paths;

        public FolderStructure()
        {
            this.paths = new Hashtable();
        }

        public Hashtable DirSearch(string entryFolder)
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
                        string filePath = file + Environment.NewLine;
                    }
                    DirSearch(folder);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return paths;
        }
    }
}
