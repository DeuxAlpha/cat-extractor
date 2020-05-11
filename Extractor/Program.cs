using System;
using System.Linq;
using CommandLine;

namespace Extractor
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CliOptions>(args).WithParsed(options =>
            {
                var extractor = new CatExtractor(options);

                var commands = extractor.BuildExtractionCommands().ToList();

                if (!commands.Any())
                {
                    Console.WriteLine("No files were found.");
                    return;
                }

                Console.WriteLine("The following commands will be executed if you proceed:");
                foreach (var command in commands) Console.WriteLine(command.Command.Replace("/C ", ""));
                Console.WriteLine("Proceed? Y/N");
                if (Console.ReadKey().Key != ConsoleKey.Y)
                {
                    Console.WriteLine("Execution cancelled. Program is closing.");
                    return;
                }

                extractor.Extract(commands);

                Console.WriteLine("Program finished successfully.");
            });
        }
    }
}