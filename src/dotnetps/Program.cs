using System;
using System.Diagnostics;

namespace dotnetps
{
    class Program
    {
        static void Main(string[] args)
        {
            var (output, success) = "pgrep dotnet | xargs ps -p".Bash();
            if(success)
                Console.WriteLine(output);
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something very bad (and sad 😢) happened.");
                Console.WriteLine(output);
            }
        }
    }

    public static class ShellHelper
    {
        public static (string, bool) Bash(this string cmd)
        {
            try
            {
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "/bin/bash",
                        Arguments = $"-c \"{cmd}\"",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };
                process.Start();
                var result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return (result, true);
            }
            catch (Exception ex)
            {
                return (ex.Message, false);
            }
        }
    }
}
