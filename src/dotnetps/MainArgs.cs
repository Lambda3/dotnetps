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
  dotnetps [-v | --version]

Options:
  --version, -v                     Show version number
";

        public MainArgs(string[] argv)
        {
            var version = Assembly.GetEntryAssembly().GetName().Version.ToString();
            var args = new Docopt().Apply(usage, argv, version: version, exit: true);

            IsVersionRequest = bool.Parse(args["--version"]?.ToString());

            Version = args["--version"]?.ToString();
        }

        public string[] Arguments { get; }

        public string Version { get; }
        public bool IsVersionRequest { get; }
    }
}