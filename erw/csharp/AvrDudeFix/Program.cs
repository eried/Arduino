using System;
using System.Windows.Forms;

namespace AvrDudeFix
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            const string parentPrefix = "-parent";
            var parent = "";
            var hasParent = false;

            foreach (var arg in Environment.GetCommandLineArgs())
            {
                if (arg.StartsWith(parentPrefix, StringComparison.InvariantCultureIgnoreCase))
                    parent = arg.Remove(0, parentPrefix.Length);
            }

            if (!String.IsNullOrEmpty(parent))
            {
                try
                {
                    var f = new FormMain(false);
                    f.ShowDialog(new WindowWrapper(new IntPtr(int.Parse(parent))));
                    f.Dispose();
                    hasParent = true;
                }
                catch
                {
                }
            }

            if (!hasParent)
                Application.Run(new FormMain(true));
            else
                Environment.Exit(Environment.ExitCode);
        }
    }

    public class WindowWrapper : IWin32Window
    {
        public WindowWrapper(IntPtr handle)
        {
            _hwnd = handle;
        }

        public IntPtr Handle
        {
            get { return _hwnd; }
        }

        private readonly IntPtr _hwnd;
    }
}
