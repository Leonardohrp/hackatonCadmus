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
            var versionString = Assembly.GetEntryAssembly()
                                     .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                     .InformationalVersion
                                     .ToString();
            if (args.Length == 0)
            {
                Console.WriteLine($"Monster v{versionString}");
                Console.WriteLine("-------------");
                CreateFile.GenerateFile();

                return;
            }
            else if (args.Contains("--className") || args.Contains("-cn"))
            {
                int index = Array.IndexOf(args, "-className");
                ReadFile.ReadClassFile(args[index + 1]);
            }
            else if (args.Contains("-a") || args.Contains("--about"))
            {
                string slogan = @"
                                                   dddddddd                                                           
        CCCCCCCCCCCCC                              d::::::d                                                           
     CCC::::::::::::C                              d::::::d                                                           
   CC:::::::::::::::C                              d::::::d                                                           
  C:::::CCCCCCCC::::C                              d:::::d                                                            
 C:::::C       CCCCCC  aaaaaaaaaaaaa       ddddddddd:::::d    mmmmmmm    mmmmmmm   uuuuuu    uuuuuu      ssssssssss   
C:::::C                a::::::::::::a    dd::::::::::::::d  mm:::::::m  m:::::::mm u::::u    u::::u    ss::::::::::s  
C:::::C                aaaaaaaaa:::::a  d::::::::::::::::d m::::::::::mm::::::::::mu::::u    u::::u  ss:::::::::::::s 
C:::::C                         a::::a d:::::::ddddd:::::d m::::::::::::::::::::::mu::::u    u::::u  s::::::ssss:::::s
C:::::C                  aaaaaaa:::::a d::::::d    d:::::d m:::::mmm::::::mmm:::::mu::::u    u::::u   s:::::s  ssssss 
C:::::C                aa::::::::::::a d:::::d     d:::::d m::::m   m::::m   m::::mu::::u    u::::u     s::::::s      
C:::::C               a::::aaaa::::::a d:::::d     d:::::d m::::m   m::::m   m::::mu::::u    u::::u        s::::::s   
 C:::::C       CCCCCCa::::a    a:::::a d:::::d     d:::::d m::::m   m::::m   m::::mu:::::uuuu:::::u  ssssss   s:::::s 
  C:::::CCCCCCCC::::Ca::::a    a:::::a d::::::ddddd::::::ddm::::m   m::::m   m::::mu:::::::::::::::uus:::::ssss::::::s
   CC:::::::::::::::Ca:::::aaaa::::::a  d:::::::::::::::::dm::::m   m::::m   m::::m u:::::::::::::::us::::::::::::::s 
     CCC::::::::::::C a::::::::::aa:::a  d:::::::::ddd::::dm::::m   m::::m   m::::m  uu::::::::uu:::u s:::::::::::ss  
        CCCCCCCCCCCCC  aaaaaaaaaa  aaaa   ddddddddd   dddddmmmmmm   mmmmmm   mmmmmm    uuuuuuuu  uuuu  sssssssssss    
";
                slogan += "\n\n";
                slogan += @"
                      _                 _   _          _   _            _              _                                            
  __ _   __ _   ___  (_)  ___        __| | (_)  __ _  (_) | |_   __ _  (_)  ___       | |_    _  _   _ __    __ _   _ _    ___   ___
 / _` | / _` | / -_) | | (_-<  _    / _` | | | / _` | | | |  _| / _` | | | (_-<  _    | ' \  | || | | '  \  / _` | | ' \  / _ \ (_-<
 \__,_| \__, | \___| |_| /__/ ( )   \__,_| |_| \__, | |_|  \__| \__,_| |_| /__/ ( )   |_||_|  \_,_| |_|_|_| \__,_| |_||_| \___/ /__/
        |___/                 |/               |___/                            |/                                                  
";
                Console.Clear();
                Console.WriteLine(slogan +
                    $"\n\n\tMONSTER - Gerador de Códigos - versão {versionString}\n\n" +
                    " Desenvolvido por:\n" +
                    " - João Rabelo\n" +
                    " - Leonardo Pinheiro\n" +
                    " - Pedro Tortello\n" +
                    " - Rafael Fernandes\n" +
                    " - Rafael Tadioto\n"
                );
            }
            else if (args.Contains("-h") || args.Contains("--help"))
            {
                Console.WriteLine($"Monster v{versionString}\n" +
                    "Uso: monster [Argumentos] [classname.cs]\n\n" +
                    "Argumentos:\n" +
                    " -a|--about\t\tExibe informações do Monster.\n" +
                    " -h|--help\t\tExibe a ajuda da linha de comando.\n" +
                    " -v|--version\t\tExibe a versão em uso.\n\n"
                );
            }
            else if (args.Contains("-v") || args.Contains("--version"))
            {
                Console.WriteLine($"Monster v{versionString}\n");
            }
            else
            {
                Console.WriteLine("Comando inválido.\nExecute 'monster --help' para obter ajuda.\n");
            }
        }
    }
}
