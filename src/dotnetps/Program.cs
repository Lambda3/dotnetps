using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace dotnetps
{
    class Program
    {
        static ConsoleColor DEFAULT_CONSOLE_COLOR = Console.ForegroundColor;
        
        static void Main(string[] args)
        {
            var (output, success) = RunCommand();

            if (success)
                Console.WriteLine(output);
            else
                PrintErrorMessage(output);
        }

        static (string, bool) RunCommand()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = "-c \"pgrep dotnet | xargs ps -p\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            if (IsWindows())
                PrepareWindowsProccess(startInfo);

            var process = new Process { StartInfo = startInfo };

            try
            {
                process.Start();
                var output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return (output, process.ExitCode == 0);
            }
            catch (System.Exception ex)
            {
                return (ex.Message, false);
            }
        }
        static bool IsWindows() =>
            System.Runtime.InteropServices.RuntimeInformation
                                               .IsOSPlatform(OSPlatform.Windows);

        static void PrepareWindowsProccess(ProcessStartInfo startInfo)
        {
            startInfo.FileName = "Powershell.exe";
            startInfo.Arguments = "Get-Process dotnet | Format-List *";
        }

        static void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Something very bad (and sad 😢) happened.");
            Console.WriteLine(message);
            Console.ForegroundColor = DEFAULT_CONSOLE_COLOR;
        }
    }
}