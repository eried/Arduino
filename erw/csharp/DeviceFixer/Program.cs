using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DeviceFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Environment.CurrentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            const string descriptorPrefix = "-d";
            var descriptor = "";
            foreach (var arg in args.Where(arg => arg.StartsWith(descriptorPrefix, StringComparison.InvariantCultureIgnoreCase)))
            {
                descriptor = arg.Remove(0, descriptorPrefix.Length);
                break;
            }

            ResetDevices(descriptor.Trim().Replace(" ", "\" \""));
        }

        private static void ResetDevices(string descriptor, bool b = false)
        {
            var p = new Process() { StartInfo = new ProcessStartInfo("devcon" + (Environment.Is64BitOperatingSystem ? "64" : "86") + ".exe", String.Format("{0} \"{1}\"",(b ? "enable" : "disable"), descriptor)) { CreateNoWindow = true, UseShellExecute = false } };
            p.Start();
            p.WaitForExit();

            if (!b)
                ResetDevices(descriptor, true);
        }
    }
}
