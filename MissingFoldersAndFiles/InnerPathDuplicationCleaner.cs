using System;

namespace MissingFoldersAndFiles
{
    public class InnerPathDuplicationCleaner
    {
        public void Clean()
        {
            FileReader fileReader = new FileReader();
            string[] missingPaths = fileReader.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
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

            FileWriter fileWriter = new FileWriter();
            fileWriter.Write(finalMissingPaths);
        }
    }
}
