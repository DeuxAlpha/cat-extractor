using System.IO;

namespace Extractor
{
    public class CommandModel
    {
        public DirectoryInfo OutputDirectory { get; set; }
        public string Command { get; set; }
    }
}