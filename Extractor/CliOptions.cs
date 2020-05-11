using CommandLine;

namespace Extractor
{
    public class CliOptions
    {
        [Option('d', "directory", Default = ".", HelpText = "The directory to start looking for .cat files.")]
        public string Directory { get; set; }
        [Option('o', "output", Default = "unpacked", HelpText = "The directory in which to store the extracted files.")]
        public string OutputDirectory { get; set; }
        [Option("cat-tool", Default = "XRCatTool", HelpText = "The location of the XRCatTool.exe. If you added the directory where you stored the file to path, you shouldn't need to provide this yourself.")]
        public string CatToolPath { get; set; }
        [Option("executor", Default = "cmd.exe", HelpText = "The CLI to execute XRCatTool.exe. If not on Windows, you should adjust the default value.")]
        public string Executor { get; set; }
    }
}