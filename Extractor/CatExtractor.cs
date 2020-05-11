using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Extractor
{
    public class CatExtractor
    {
        private readonly IEnumerable<FileInfo> _catFiles;
        private readonly string _executor;
        private readonly string _extractor;
        private readonly string _outputDirectory;

        public CatExtractor(CliOptions options)
        {
            var targetDirectory = new DirectoryInfo(options.Directory);
            var catFiles = targetDirectory.EnumerateFiles("*.cat", SearchOption.AllDirectories);
            _catFiles = catFiles.Where(file => !file.Name.Contains("_sig.cat"));
            _executor = options.Executor;
            _extractor = options.CatToolPath;
            _outputDirectory = options.OutputDirectory;
        }

        public IEnumerable<CommandModel> BuildExtractionCommands()
        {
            var commands = new List<CommandModel>();
            foreach (var directoryCatFiles in _catFiles.GroupBy(file => file.DirectoryName))
            {
                Console.WriteLine($"Found {directoryCatFiles.Count()} files in {directoryCatFiles.Key}.");
                var command = $"/C {_extractor} ";
                command = directoryCatFiles.Aggregate(
                    command,
                    (current, directoryCatFile) => current + $"-in \"{directoryCatFile.FullName}\" ");

                var outputDirectory = new DirectoryInfo(Path.Combine(directoryCatFiles.Key, _outputDirectory));
                command += $"-out \"{outputDirectory.FullName}\"";
                commands.Add(new CommandModel
                {
                    Command = command,
                    OutputDirectory = outputDirectory
                });
            }

            return commands;
        }

        public void Extract(IEnumerable<CommandModel> models)
        {
            foreach (var commandModel in models)
            {
                Directory.CreateDirectory(commandModel.OutputDirectory.FullName);
                var process = new Process();
                var startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = _executor;
                startInfo.Arguments = commandModel.Command;
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }
        }
    }
}