using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using AvrDudeFix.Properties;

namespace AvrDudeFix
{
    public partial class FormMain : Form
    {
        private readonly bool _kill;

        public FormMain(bool kill)
        {
            _kill = kill;
            InitializeComponent();
            Environment.ExitCode = 0; // Cancel
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void ExitApplication()
        {
            if (_kill)
                Environment.Exit(Environment.ExitCode);
            else
                this.Close();
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            Environment.ExitCode = 2;
            ExitApplication();
        }

        private void buttonFix_Click(object sender, EventArgs e)
        {
            this.buttonFix.Enabled = false;
            this.buttonSkip.Enabled = false;
            this.buttonCancel.Enabled = false;
            backgroundWorkerFix.RunWorkerAsync();
        }

        private void backgroundWorkerFix_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Environment.ExitCode = 9;
            ExitApplication();
        }

        private void backgroundWorkerFix_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var p = new Process()
                            {
                                StartInfo = new ProcessStartInfo("DeviceFixer.exe", "-d" + Settings.Default.UsbDevices) { CreateNoWindow = true, UseShellExecute=true }
                            };
                p.Start();
                p.WaitForExit();
            }
            catch
            {
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExitApplication();
        }
    }
}
