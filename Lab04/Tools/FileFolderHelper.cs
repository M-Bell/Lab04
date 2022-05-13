using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04.Tools
{
    internal static class FileFolderHelper
    {

        internal static readonly string StorageFilePath =
            Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\output.txt");

        internal static bool CreateFolderAndCheckFileExistence(string filePath)
        {
            var file = new FileInfo(filePath);
            return file.CreateFolderAndCheckFileExistence();
        }

        internal static bool CreateFolderAndCheckFileExistence(this FileInfo file)
        {
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }
            return file.Exists;
        }
    }
}
