using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Ionic.Zip;
using LibraryManager.Properties;

namespace LibraryManager
{
    public partial class FormMain : Form
    {
        private const String DisabledPrefix = "__disabled_", LibraryFolderName = "libraries";
        private readonly String[] _libraries;
        private readonly String _libraryDirectory;
        private bool _updateLibraries, _changes;
        private int _previuslySelected = -2;

        public FormMain()
        {
            InitializeComponent();
            // Tip
            if (Settings.Default.ShowHint > 0)
            {
                Settings.Default.ShowHint--;
                Settings.Default.Save();
            }
            else
            {
                groupBoxHint.Visible = false;
                Height -= 50;
                panelForm.Height += 50;
            }

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 2)
            {
                _libraryDirectory = args[args.Length - 2];
                _libraries = args[args.Length - 1].ToLower().Split(new[] {'|'});
            }
            else
            {
                if (args.Length > 1)
                    _libraryDirectory = args[args.Length - 1];
            }

            if (!_libraryDirectory.ToLower().Contains(LibraryFolderName))
                _libraryDirectory = "";

            if (String.IsNullOrEmpty(_libraryDirectory))
                Close();

            fileSystemWatcherLibraries.Path = _libraryDirectory;
            fileSystemWatcherLibraries.EnableRaisingEvents = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _updateLibraries = true;
            Close();
        }

        private void UpdateLibraries()
        {
            // Update libraries
            fileSystemWatcherLibraries.EnableRaisingEvents = false;
            checkedListBoxLibraries.Enabled = false;
            int i = 0;
            foreach (object item in checkedListBoxLibraries.Items)
            {
                try
                {
                    var name = (String) item;
                    bool isChecked = checkedListBoxLibraries.GetItemChecked(i++);

                    if (!_updateLibraries)
                    {
                        if (IsNewLibrary(name))
                            isChecked = false;
                        else
                            continue;
                    }

                    string fixedName = FixLibraryName(name), enabledDirectory = Path.Combine(_libraryDirectory, name), 
                        disabledDirectory = Path.Combine(_libraryDirectory, DisabledPrefix + name), realDirectory = "", destinationDirectory;

                    var shouldFixName = !fixedName.Equals(name);

                    if (isChecked)
                    {
                        destinationDirectory = Path.Combine(_libraryDirectory, fixedName);
                        if (Directory.Exists(disabledDirectory))
                        {
                            Directory.Move(disabledDirectory, destinationDirectory);
                            shouldFixName = false;
                        }
                        else
                            realDirectory = enabledDirectory;
                    }
                    else
                    {
                        destinationDirectory = Path.Combine(_libraryDirectory, DisabledPrefix + name);
                        if (Directory.Exists(enabledDirectory))
                        {
                            Directory.Move(enabledDirectory, destinationDirectory);
                            shouldFixName = false;
                        }
                        else
                            realDirectory = disabledDirectory;
                    }

                    if (shouldFixName)
                        Directory.Move(realDirectory, destinationDirectory);
                }
                catch
                {
                }
            }
        }

        private static string FixLibraryName(string name)
        {
            var t = "";
            foreach (var c in name.ToCharArray())
            {
                if (t.Length == 0)
                {
                    if (IsLetter(c))
                        t += c;
                }
                else
                {
                    if (IsLetter(c) || (c >= '0' && c <= '9'))
                        t += c;
                }
            }
            return t.Length == 0 ? name : t;
        }

        private static bool IsLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c=='_';
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            PopulateInstalledLibraries();
        }

        private void PopulateInstalledLibraries()
        {
            buttonOK.Enabled = false;
            groupBoxInstalledLibraries.Enabled = false;

            // Check current items and save state
            var checkedItems = (from object i in checkedListBoxLibraries.CheckedItems select checkedListBoxLibraries.GetItemText(i)).ToList();
            var allItems = (from object t in checkedListBoxLibraries.Items select checkedListBoxLibraries.GetItemText(t)).ToList();
            var previousSelectedItem = "";

            if (checkedListBoxLibraries.SelectedIndex > -1)
                previousSelectedItem = checkedListBoxLibraries.GetItemText(checkedListBoxLibraries.Items[checkedListBoxLibraries.SelectedIndex]);

            // Populate
            checkedListBoxLibraries.Items.Clear();
            foreach (string n in Directory.GetDirectories(_libraryDirectory).Select(Path.GetFileNameWithoutExtension))
            {
                var name = n.Replace(DisabledPrefix, String.Empty);
                checkedListBoxLibraries.Items.Add(name, checkedItems.Count > 0 ? checkedItems.Contains(name) : !(IsNewLibrary(name) || n.Contains(DisabledPrefix)));
            }

            // Select new items
            if (allItems.Count > 0)
                for (int i = 0; i < checkedListBoxLibraries.Items.Count; i++)
                    if (!allItems.Contains(checkedListBoxLibraries.GetItemText(checkedListBoxLibraries.Items[i])))
                    {
                        checkedListBoxLibraries.SelectedIndex = i;
                        break;
                    }

            // Check if something was selected
            if (checkedListBoxLibraries.SelectedIndex == -1 && previousSelectedItem.Length > 0)
                for (int i = 0; i < checkedListBoxLibraries.Items.Count; i++)
                    if (checkedListBoxLibraries.GetItemText(checkedListBoxLibraries.Items[i]).Equals(previousSelectedItem))
                    {
                        checkedListBoxLibraries.SelectedIndex = i;
                        break;
                    }

            checkedListBoxLibraries.Sorted = true;
            groupBoxInstalledLibraries.Enabled = true;
            buttonOK.Enabled = true;
            UpdateGui();
            _changes = false;
        }

        private bool IsNewLibrary(string name)
        {
            if (_libraries != null)
            {
                name = name.ToLower().Trim();
                return _libraries.Select(l => l.ToLower().Trim()).Where(s => !String.IsNullOrEmpty(s)).All(s => !s.Equals(name));
            }
            return true;
        }

        private bool OpenDirectory(string s)
        {
            try
            {
                if (Directory.Exists(s))
                {
                    Process.Start(s);
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        private void CheckAll(bool b)
        {
            for (int i = 0; i < checkedListBoxLibraries.Items.Count; i++)
                checkedListBoxLibraries.SetItemChecked(i, b);

            UpdateGui();
        }

        private void linkLabelEnableAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckAll(true);
        }

        private void linkLabelEnableNone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckAll(false);
        }

        private void linkLabelBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenDirectory(_libraryDirectory);
        }

        private void linkLabelBrowseSelected_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenSelectedLibraryDirectory();
        }

        private void OpenSelectedLibraryDirectory()
        {
            int i = checkedListBoxLibraries.SelectedIndex;
            if (i < 0) return;

            if (!OpenDirectory(Path.Combine(_libraryDirectory,
                                            DisabledPrefix + (String) checkedListBoxLibraries.Items[i])))
                OpenDirectory(Path.Combine(_libraryDirectory, (String) checkedListBoxLibraries.Items[i]));
        }

        private void checkedListBoxLibraries_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGui();
        }

        private void UpdateGui()
        {
            linkLabelBrowseSelected.Enabled = checkedListBoxLibraries.SelectedIndex != -1;
            linkLabelEnableAll.Enabled = checkedListBoxLibraries.CheckedItems.Count !=
                                         checkedListBoxLibraries.Items.Count;
            linkLabelEnableNone.Enabled = checkedListBoxLibraries.CheckedItems.Count != 0;

            if (_previuslySelected > -2)
            {
                if (!_changes)
                    _changes = _previuslySelected != checkedListBoxLibraries.CheckedItems.Count;
            }
            _previuslySelected = checkedListBoxLibraries.CheckedItems.Count;
        }

        private void fileSystemWatcherLibraries_Created(object sender, FileSystemEventArgs e)
        {
            PopulateInstalledLibraries();
        }

        private void fileSystemWatcherLibraries_Deleted(object sender, FileSystemEventArgs e)
        {
            PopulateInstalledLibraries();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateLibraries();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Enabled = false;
            fileSystemWatcherLibraries.EnableRaisingEvents = true;
            AddNewLibrary();
            checkedListBoxLibraries.Enabled = true;
            Enabled = true;
        }

        private void AddNewLibrary()
        {
            if (openFileDialogLibrary.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Prepare a temporal folder
                    string suggestedLibraryName;
                    var tempFolder = Path.GetTempFileName();
                    File.Delete(tempFolder);
                    Directory.CreateDirectory(tempFolder);

                    string inputFile = openFileDialogLibrary.FileName;

                    // Check library
                    if (ZipFile.IsZipFile(inputFile))
                    {
                        suggestedLibraryName = Path.GetFileNameWithoutExtension(inputFile);
                        var z = new ZipFile(inputFile);
                        z.ExtractAll(tempFolder, ExtractExistingFileAction.OverwriteSilently);
                    }
                    else
                    {
                        string libFolder = Path.GetDirectoryName(inputFile);
                        suggestedLibraryName = Path.GetFileName(libFolder);

                        long size = 0;
                        foreach (
                            FileInfo fi in
                                Directory.GetFiles(libFolder, "*.*", SearchOption.AllDirectories).Select(
                                    f => new FileInfo(f)))
                        {
                            size += fi.Length;

                            if (size <= 4194304) continue;
                            if (MessageBox.Show(Resources.MsgBigLibraryText, Resources.MsgBigLibraryCaption,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                            break;
                        }

                        CopyDirectory(libFolder, tempFolder);
                    }

                    // Now check all the files for old versions
                    var fixTheseFiles = Directory.GetFiles(tempFolder, "*.*", SearchOption.AllDirectories).Where(file => file.EndsWith(".cpp") || file.EndsWith(".h") || file.EndsWith(".c")).ToList();
                    var filesNeedFix = fixTheseFiles.Any(f => { var fc = File.ReadAllText(f); return fc.Contains("\"WProgram.h\"") && !fc.Contains("\"Arduino.h\""); });

                    if (filesNeedFix)
                    {
                        switch (MessageBox.Show("There are some references to 'WProgram.h' in the library files so it may not work with current Arduino IDE.\n\nCheck the author's website to get more information if the library does not work properly, or to check for a newer version.\n\nDo you want to add it anyway?", Resources.MsgOldLibraryCaption,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            /*case DialogResult.Yes:
                                // Fix the library
                                if (!currentLibrary.FixLibraryFiles())
                                {
                                    MessageBox.Show(Resources.MsgErrorFixingLibraryText, Resources.MsgErrorCaption, MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                                }

                                break;*/
                            case DialogResult.Yes:
                                break;
                            default:
                                return;
                        }
                    }
                    
                    /*var currentLibrary = new LibraryUpdater(Directory.GetFiles(tempFolder, "*.*", SearchOption.AllDirectories).Where(file => file.EndsWith(".cpp") || file.EndsWith(".h") || file.EndsWith(".c")).ToList());

                    if (currentLibrary.NeedsToBeFixed)
                    {
                        switch (MessageBox.Show(String.Format(Resources.MsgOldLibraryText, currentLibrary.GetVerboseProblems), Resources.MsgOldLibraryCaption,
                            MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:
                                // Fix the library
                                if (!currentLibrary.FixLibraryFiles())
                                {
                                    MessageBox.Show(Resources.MsgErrorFixingLibraryText, Resources.MsgErrorCaption, MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                                }

                                break;
                            case DialogResult.No:
                                break;
                            default:
                                return;
                        }
                    }*/

                    // Check if the first folder has cpp or h files
                    var tmp = GetRealLibraryFolder(tempFolder, suggestedLibraryName);

                    if (!String.IsNullOrEmpty(tmp.Folder))
                    {
                        var destinationFolder = CreateFolder(_libraryDirectory, tmp.SuggestedName);
                        CopyDirectory(tmp.Folder, destinationFolder);
                    }
                    else
                    {
                        MessageBox.Show(Resources.MsgErrorInvalidLibraryText, Resources.MsgErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // Done
                }
                catch
                {
                    MessageBox.Show(Resources.MsgErrorAddingLibraryText, Resources.MsgErrorCaption, MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            this.Enabled = true;
        }

        private static string CreateFolder(string libraryDirectory, string suggestedLibraryName)
        {
            string d1, d2;
            var i = 0;
            do
            {
                var dt = suggestedLibraryName + (i > 0 ? "_" + i : "");
                d1 = Path.Combine(libraryDirectory, dt);
                d2 = Path.Combine(libraryDirectory, DisabledPrefix + dt);

                i++;
            }
            while (Directory.Exists(d1) || Directory.Exists(d2));

            Directory.CreateDirectory(d1);
            return d1;
        }

        private static FolderAndName GetRealLibraryFolder(string tempFolder, string suggestedLibraryName)
        {
            // Check if current library has .c, .cpp or .h files
            if (Directory.GetFiles(tempFolder, "*.*", SearchOption.TopDirectoryOnly).Any(file => file.EndsWith(".cpp") || file.EndsWith(".h") || file.EndsWith(".c")))
                return new FolderAndName() { Folder = tempFolder, SuggestedName = FixLibraryName(suggestedLibraryName) };
            
            // Search
            foreach (var d in Directory.GetDirectories(tempFolder))
            {
                var name = Path.GetFileName(d);
                if (!name.Equals("examples", StringComparison.OrdinalIgnoreCase))
                {
                    var t = GetRealLibraryFolder(d, name);
                    if (!String.IsNullOrEmpty(t.Folder))
                        return t;
                }
            }

            return new FolderAndName();
        }

        private void CopyDirectory(string sourcePath, string destinationPath)
        {
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*",
                                                                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));

            //Copy all the files 
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*",
                                                          SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(sourcePath, destinationPath));
        }

        private void fileSystemWatcherLibraries_Renamed(object sender, RenamedEventArgs e)
        {
            PopulateInstalledLibraries();
        }

        private void checkedListBoxLibraries_KeyUp(object sender, KeyEventArgs e)
        {
            var i = checkedListBoxLibraries.SelectedIndex;
            if (i != -1)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected library?", "Delete Library", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            Directory.Delete(
                                            Path.Combine(_libraryDirectory,
                                                         (String)checkedListBoxLibraries.Items[i]), true);
                        }
                        catch
                        {
                        }

                        try
                        {
                            Directory.Delete(
                                Path.Combine(_libraryDirectory,
                                             DisabledPrefix + (String)checkedListBoxLibraries.Items[i]), true);
                        }
                        catch
                        {
                        }

                        //PopulateInstalledLibraries();
                    }
                }
            }
        }

        private void checkedListBoxLibraries_DoubleClick(object sender, EventArgs e)
        {
            OpenSelectedLibraryDirectory();
        }
    }

    internal struct FolderAndName
    {
        public String Folder;
        public String SuggestedName;
    }
}