using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using CommandLine;
using Microsoft.Win32;

namespace SetPath
{
    class Program
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SendMessageTimeout(
          IntPtr hWnd,
          int Msg,
          int wParam,
          string lParam,
          int fuFlags,
          int uTimeout,
          out int lpdwResult
        );

        public const int HWND_BROADCAST = 0xffff;
        public const int WM_SETTINGCHANGE = 0x001A;
        public const int SMTO_NORMAL = 0x0000;
        public const int SMTO_BLOCK = 0x0001;
        public const int SMTO_ABORTIFHUNG = 0x0002;
        public const int SMTO_NOTIMEOUTIFNOTHUNG = 0x0008;

        static void Main(string[] args)
        {
            var options = new Options();
            ICommandLineParser parser = new CommandLineParser();
            if (parser.ParseArguments(args, options))
            {
                // Remove
                const string regPath = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment";
                const string variableName = "Path";
                var r = (String)Registry.GetValue(regPath, variableName, "");
                var temp = new List<String>();
  
                Console.WriteLine("Checking Path values");
                var t = options.RemoveFromPath.ToLower();

                    
                foreach (var p in r.Split(Convert.ToChar(";")))
                {
                    if (p.ToLower().Contains(t) || p.Equals(options.AddToPath, StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine("Removing: {0}", p);
                    else
                        temp.Add(p);
                }

                // Add
                if (!String.IsNullOrEmpty(options.AddToPath))
                {
                    Console.WriteLine("Adding: {0}", options.AddToPath);
                    temp.Add(options.AddToPath);
                }

                if (temp.Count > 0)
                {
                    temp.Sort();
                    var rfinal = String.Join(";", temp);

                    if (!r.Equals(rfinal))
                    {
                        Registry.SetValue(regPath, variableName, rfinal, RegistryValueKind.String);

                        BroadcastEnvironment();
                        Console.WriteLine("Variable was modified.");
                    }
                }
            }
        }

        static void BroadcastEnvironment()
        {
            int result;
            SendMessageTimeout((IntPtr)HWND_BROADCAST, WM_SETTINGCHANGE, 0, "Environment",
              SMTO_BLOCK | SMTO_ABORTIFHUNG | SMTO_NOTIMEOUTIFNOTHUNG, 5000, out result);
        }
    }

    class Options
    {
        [Option("a", "add", Required = false, HelpText = "Element to add to the path.")]
        public String AddToPath { get; set; }

        [Option("r", "remove", Required = false, HelpText = "Elements to remove to the path.")]
        public String RemoveFromPath { get; set; }
    } 

}
