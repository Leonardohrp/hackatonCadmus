using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace cadmus.monster.src
{
    class ReadFile
    {
        public static List<string> ReadClassFile(string className)
        {
            var pathString = FindClass.FindClassByName(className);         

            if(pathString == "Arquivo não encontrado")
            {
                return new List<string> { "Arquivo não encontrado" };
            }
          
            string folderName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            List<string> parametersNames = new List<string>();

            Console.WriteLine("Path to my file: {0}\n", pathString);

            try
            {
                var names = File.ReadLines(pathString)
                      .Select(line => line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                      .Where(split => split.Contains("get;") || split.Contains("set;"))
                      .Where(split => split.Length >= 3)
                      .Select(split => split[2])
                      .ToList();


                foreach (string line in names)
                {
                    parametersNames.Add(line);
                }

                CreateFile.GenerateFile(className, parametersNames);

                return parametersNames;
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: " + e);
                throw;
            }
        }
    }
}
