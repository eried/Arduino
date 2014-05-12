using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ArduinoDriverInstaller.Properties;

namespace ArduinoDriverInstaller
{
    public partial class FormMain : Form
    {
        List<String> _drivers;
        public FormMain()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            InitializeComponent();

            // Load drivers
            bool showHint = false;
            _drivers = new List<string>();
            foreach (var d in Directory.GetFiles(".", "*.inf", SearchOption.AllDirectories))
            {
                var f = Path.GetFullPath(d);
                var filename = Path.GetFileNameWithoutExtension(d);

                checkedListBoxDrivers.Items.Add(AddInformation(filename), true);
                buttonInstall.Enabled = true;
                _drivers.Add(f);
            }

            // Tip
            if (Settings.Default.ShowHint > 0)
            {
                Settings.Default.ShowHint--;
                Settings.Default.Save();
            }
            else
            {
                groupBoxHint.Visible = false;
                this.Height -= 50;
                panelForm.Height += 50;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private String AddInformation(string infFile)
        {
            foreach (var s in from string s in Settings.Default.INFDescriptions where s.StartsWith(infFile, StringComparison.InvariantCultureIgnoreCase) select s)
            {
                return s.Split(new[] { '|' }, 2)[1];
            }
            return infFile;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Depending on your operative system and settings you may view (and allow) some actions/warnings." + 
                Environment.NewLine + Environment.NewLine + "Are you sure you want to install the checked drivers?", "Install drivers", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                UpdateGUI(false);

                labelOK.Text = "Starting";
                labelOK.Visible = true;
                Dictionary<int, string> list = checkedListBoxDrivers.CheckedIndices.Cast<int>().ToDictionary(d => d, d => _drivers[d]);
                backgroundWorkerInstall.RunWorkerAsync(list);
            }
        }

        private void UpdateGUI(bool b)
        {
            checkedListBoxDrivers.Enabled = b;
            buttonCancel.Enabled = b;
            buttonInstall.Enabled = b && checkedListBoxDrivers.CheckedIndices.Count > 0;
        }

        private static bool InstallDriver(string infFile)
        {
            var args = "dp_add \"" + infFile + "\"";
            var p = RunDevCon(args);
            
            return !(p.StandardOutput.ReadToEnd() + p.StandardError.ReadToEnd()).ToLower().Contains("failed");
        }

        private static Process RunDevCon(string args)
        {
            var p = new Process() { StartInfo = new ProcessStartInfo("devcon" + (Environment.Is64BitOperatingSystem ? "64" : "86") + ".exe", args) 
            { CreateNoWindow = true, RedirectStandardOutput = true, RedirectStandardError = true, UseShellExecute = false } };
            p.Start();
            p.WaitForExit();
            return p;
        }

        private void checkedListBoxDrivers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var newState = false;
            if (e.NewValue == CheckState.Checked)
                newState = true;
            else
            {
                newState = checkedListBoxDrivers.CheckedIndices.Count > 1;
            }

            buttonInstall.Enabled = newState;
        }

        private void backgroundWorkerInstall_DoWork(object sender, DoWorkEventArgs e)
        {
            var status = new InstallStatus();
            
            foreach (var d in (Dictionary<int,string>)e.Argument)
            {
                if (InstallDriver(d.Value))
                    status.Installed.Add(d.Key);
                else
                    status.Failed.Add(d.Key);

                backgroundWorkerInstall.ReportProgress(0, status);
                Thread.Sleep(100);
            }

            backgroundWorkerInstall.ReportProgress(100, status);
            RunDevCon("rescan");
        }

        

        private void backgroundWorkerInstall_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelOK.Text = "Installation complete.";
            MessageBox.Show(checkedListBoxDrivers.CheckedIndices.Count > 0 ? ("Some drivers failed to install. Remember to allow the warnings, check the driver list for the checked ones. " +
            "Unchecked ones were installed properly." /*+ (checkBoxInstallCert.Checked ? "" : " Also you may try to disable the 'Driver Signature Enforcement' for your system.")*/) : "All the checked drivers should be properly installed now." + Environment.NewLine + Environment.NewLine + 
                "You can close this window now. Enjoy!", "Installation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            buttonCancel.Text = "Close";
            UpdateGUI(true);
        }

        private void backgroundWorkerInstall_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var s = (InstallStatus)e.UserState;
            var f = s.Failed.Count;
            labelOK.Text = String.Format("{0} driver(s) installed{1}.{2}", s.Installed.Count, f>0? (" (" + f + " failed)"):"", e.ProgressPercentage < 100 ? " Installing next..." : "");

            if (e.ProgressPercentage == 100)
            {
                labelOK.Text = "Scanning hardware...";

                foreach (var i in s.Installed)
                    this.checkedListBoxDrivers.SetItemChecked(i, false);
            }
        }

        private static Process RunExe(string bcdedit, string args)
        {
            return Process.Start(new ProcessStartInfo(bcdedit, args) { CreateNoWindow = true, 
                RedirectStandardOutput = true, RedirectStandardError = true, UseShellExecute = false });
        }
    }

    internal class InstallStatus
    {
        public List<int> Failed;
        public List<int> Installed;

        public InstallStatus()
        {
            Failed = new List<int>();
            Installed = new List<int>();
        }
    }
}
