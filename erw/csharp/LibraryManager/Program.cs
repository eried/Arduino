using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManager
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
            try
            {
                var parent = ParentProc.FindParentProcess();
                var f = new FormMain();

                if (parent.MainWindowTitle.Contains("Arduino"))
                {
                    f.ShowDialog(new WindowWrapper(parent.MainWindowHandle));
                    f.Dispose();
                    Environment.Exit(Environment.ExitCode);
                }
                else
                    Application.Run(f);
            }
            catch
            {
            }
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
