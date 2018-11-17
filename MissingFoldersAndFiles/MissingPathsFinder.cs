using MissingFoldersAndFiles.Abstractions;
using System;
using System.Collections.Generic;

namespace MissingFoldersAndFiles
{
    public class MissingPathsFinder
    {
        private readonly IWriter writer;
        private readonly ICollection<string> originalPaths;
        IDictionary<string, string> copiedPaths;
        private readonly string originalPreFolderPath;

        public MissingPathsFinder(IWriter writer, ICollection<string> originalPaths, IDictionary<string, string> copiedPaths, string originalPreFolderPath)
        {
            this.writer = writer;
            this.originalPaths = originalPaths;
            this.copiedPaths = copiedPaths;
            this.originalPreFolderPath = originalPreFolderPath;
        }

        private string AllMissingPaths()
        {
            string allPaths = string.Empty;
            // da se otreje ot stringa chastta predi foldera
            foreach (string path in originalPaths)
            {
                
                if (!copiedPaths.ContainsKey(path))
                {
                    allPaths += (this.originalPreFolderPath + path + Environment.NewLine);
                }
            }

            return allPaths;
        }

        private string InnerPathDuplicationClean()
        {
            string[] missingPaths = this.AllMissingPaths().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string finalMissingPaths = missingPaths[0];
            string currentRootMissingPath = missingPaths[0];
            for (int i = 1; i < missingPaths.Length; i++)
            {
                if (missingPaths[i].Contains(currentRootMissingPath))
                {
                    continue;
                }
                else
                {
                    finalMissingPaths += (Environment.NewLine + missingPaths[i]);
                    currentRootMissingPath = missingPaths[i];
                }
            }

            return finalMissingPaths;
        }

        public void MissingPathsPrint()
        {
            this.writer.Write(InnerPathDuplicationClean());
        }
    }
}
