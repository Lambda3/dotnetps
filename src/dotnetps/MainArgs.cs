using DocoptNet;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace dotnetps
{
    public class MainArgs
    {
        private const string usage = @"dnx - The .NET Runner tool

Usage:
  dotnetps [options]

Options:
  --version, -v                     Show version number
";

        public MainArgs(string[] argv)
        {
            var version = Assembly.GetEntryAssembly().GetName().Version.ToString();
            var args = new Docopt().Apply(usage, argv, version: version, exit: true);
            Arguments = args["<arguments>"].AsList.Cast<ValueObject>().Select(d => d.ToString()).ToArray();
            Version = args["--version"]?.ToString();
        }
        
        public string[] Arguments { get; }
        
        public string Version { get; }
        public bool IsVersionRequest => !string.IsNullOrEmpty(Version);
    }
}