using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MissingFoldersAndFiles
{
    public class Program
    {
        static void Main(string[] args)
        {
            FolderStructure originalStructure = new FolderStructure();
            ICollection originalPathsKeys = originalStructure.DirSearch(@"C:\Users\IliyaDamyanov\Desktop\New folder (5)").Keys;
            IList<string> originalPaths = new List<string>(originalPathsKeys.Count);
            foreach (var pathString in originalPathsKeys)
            {
                originalPaths.Add(pathString.ToString());
            }


            FolderStructure copiedStructure = new FolderStructure();
            Hashtable copiedPathsHashTable = copiedStructure.DirSearch("");
            foreach (var path in originalPaths)
            {
                if (!copiedPathsHashTable.ContainsKey(path))
                {
                    IWriter txtWriter = new FileWriter();
                    txtWriter.Write(path);
                }
            }

            InnerPathDuplicationCleaner innerPathDuplicationCleaner = new InnerPathDuplicationCleaner();
            innerPathDuplicationCleaner.Clean();
        }
    }
}
