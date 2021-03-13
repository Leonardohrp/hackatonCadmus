using cadmus.monster.src;
using System;
using System.Linq;
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
                
                return;
            } 
            else if (args.Contains("-className"))
            {
                int index = Array.IndexOf(args, "-className");
                ReadFile.ReadClassFile(args[index + 1]);
            }
            else
            {
                ReadFile.ReadClassFile(args[0]);
            }
        }
    }
}
