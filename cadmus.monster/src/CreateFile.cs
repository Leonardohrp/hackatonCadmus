using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace cadmus.monster.src
{
    public static class CreateFile
    {
        public static void GenerateFile(string className, List<string> propertys) 
        {
            string folderName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            string pathString = Path.Combine(folderName, "Repository");

            Directory.CreateDirectory(pathString);

            var classNameTemp = className.Split(".").First(); 

            string fileName = String.Format("{0}Repository.cs", classNameTemp);

            pathString = Path.Combine(pathString, fileName);

            Console.WriteLine("Path to my file: {0}\n", pathString);

            if (!File.Exists(pathString))
            {
                using (FileStream fs = File.Create(pathString))
                {
                    var write = new WriteFile();
                    var text = write.WriteClass(classNameTemp, propertys);
                    byte[] bytes = Encoding.UTF8.GetBytes(text);

                    fs.Write(bytes, 0, bytes.Length);
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
