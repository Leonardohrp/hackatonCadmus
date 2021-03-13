using cadmus.monster.src;
using System;
using System.Reflection;

namespace cadmus.monster
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                var versionString = Assembly.GetEntryAssembly()
                                        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                        .InformationalVersion
                                        .ToString();

                Console.WriteLine($"Monster v{versionString}");
                Console.WriteLine("-------------");
                CreateFile.GenerateFile();

                return;
            } 
            else
            {
                Console.WriteLine("VIA PARAMENTRO COMANDO");
                CreateFile.GenerateFile();
            }
        }
    }
}
