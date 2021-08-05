using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cadmus.monster.src
{
    public static class CreateFile
    {
        public static void GenerateFile(string className, List<string> propertys)
        {
            string folderName = Environment.CurrentDirectory;

            string pathString = Path.Combine(folderName, "Repository");

            Directory.CreateDirectory(pathString);

            var classNameTemp = className.Split(".").First();

            string fileName = String.Format("{0}Repository.cs", classNameTemp);

            pathString = Path.Combine(pathString, fileName);

            if (!File.Exists(pathString))
            {
                using (FileStream fs = File.Create(pathString))
                {
                    var write = new WriteFile();
                    var text = write.WriteClass(classNameTemp, propertys);
                    byte[] bytes = Encoding.UTF8.GetBytes(text);

                    fs.Write(bytes, 0, bytes.Length);
                }
                Console.WriteLine("Arquivo \"{0}\" criado com sucesso. :)", fileName);
            }
            else
            {
                Console.WriteLine("Arquivo \"{0}\" já existe.", fileName);
                return;
            }
        }
    }
}
