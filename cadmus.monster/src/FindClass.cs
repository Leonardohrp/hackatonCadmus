using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace cadmus.monster.src
{
    public class FindClass
    {
        public static string FindClassByName(string className)
        {
            try
            {
                string folderName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

                string[] filePaths = Directory.GetFiles(folderName, "*.cs", SearchOption.AllDirectories);

                foreach (string filePath in filePaths)
                {
                    if (filePath.Contains(className))
                    {
                        return filePath;
                    }
                }
                return "Arquivo não encontrado";
            } 
            catch (IOException e)
            {
                Console.WriteLine("Exception: " + e);
                throw;
            }
        }
    }
}