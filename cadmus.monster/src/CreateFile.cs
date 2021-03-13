using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace cadmus.monster.src
{
    public static class CreateFile
    {
        public static void GenerateFile()
        {
            string folderName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            string pathString = Path.Combine(folderName, "Repository");

            Directory.CreateDirectory(pathString);

            string fileName = "MyNewFile2.cs";

            pathString = Path.Combine(pathString, fileName);

            Console.WriteLine("Path to my file: {0}\n", pathString);

            if (!File.Exists(pathString))
            {
                using (FileStream fs = File.Create(pathString))
                {
                    var name = "Professor";
                    var write = new WriteFile();
                    var lista = new List<string>();
                    lista.Add("Name");
                    lista.Add("Idade");
                    lista.Add("Salario");
                    var text = write.WriteClass(name, lista);
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
