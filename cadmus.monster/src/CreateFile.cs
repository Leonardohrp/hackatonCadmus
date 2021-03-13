using System;
using System.IO;
using System.Reflection;

namespace cadmus.monster.src
{
    public static class CreateFile
    {
        public static void GenerateFile()
        {
            string folderName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            string pathString = Path.Combine(folderName, "Repository");

            Directory.CreateDirectory(pathString);

            string fileName = "MyNewFile.cs";

            pathString = Path.Combine(pathString, fileName);

            Console.WriteLine("Path to my file: {0}\n", pathString);

            if (!File.Exists(pathString))
            {
                using (FileStream fs = File.Create(pathString))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }
        }
    }
}
