using Lab04.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab04.Managers
{
    internal static class SerializationManager
    {
        internal static void Serialize<TObject>(TObject obj, string filePath)
        {
            try
            {
                var file = new FileInfo(filePath);
                if (file.CreateFolderAndCheckFileExistence())
                {
                    file.Delete();
                }
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    formatter.Serialize(stream, obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to serialize data to file {filePath}", ex);
            }
        }

        internal static TObject Deserialize<TObject>(string filePath) where TObject : class
        {
            try
            {
                if (!FileFolderHelper.CreateFolderAndCheckFileExistence(filePath))
                    throw new FileNotFoundException("File doesn't exist.");
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    return (TObject)formatter.Deserialize(stream);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"Failed to Deserialize Data From File {filePath}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Deserialize Data From File {filePath}", ex);
            }
        }
    }
}
