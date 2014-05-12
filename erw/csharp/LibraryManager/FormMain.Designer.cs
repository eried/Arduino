namespace LibraryManager
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.fileSystemWatcherLibraries = new System.IO.FileSystemWatcher();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabelBrowse = new System.Windows.Forms.LinkLabel();
            this.linkLabelBrowseSelected = new System.Windows.Forms.LinkLabel();
            this.groupBoxHint = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialogLibrary = new System.Windows.Forms.OpenFileDialog();
            this.panelForm = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupBoxInstalledLibraries = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelEnableNone = new System.Windows.Forms.LinkLabel();
            this.linkLabelEnableAll = new System.Windows.Forms.LinkLabel();
            this.checkedListBoxLibraries = new System.Windows.Forms.CheckedListBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherLibraries)).BeginInit();
            this.groupBoxHint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelForm.SuspendLayout();
            this.groupBoxInstalledLibraries.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcherLibraries
            // 
            this.fileSystemWatcherLibraries.EnableRaisingEvents = true;
            this.fileSystemWatcherLibraries.SynchronizingObject = this;
            this.fileSystemWatcherLibraries.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcherLibraries_Created);
            this.fileSystemWatcherLibraries.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcherLibraries_Deleted);
            this.fileSystemWatcherLibraries.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcherLibraries_Renamed);
            // 
            // linkLabelBrowse
            // 
            this.linkLabelBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelBrowse.AutoSize = true;
            this.linkLabelBrowse.Location = new System.Drawing.Point(253, 285);
            this.linkLabelBrowse.Name = "linkLabelBrowse";
            this.linkLabelBrowse.Size = new System.Drawing.Size(46, 13);
            this.linkLabelBrowse.TabIndex = 6;
            this.linkLabelBrowse.TabStop = true;
            this.linkLabelBrowse.Text = "&Libraries";
            this.linkLabelBrowse.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTipInfo.SetToolTip(this.linkLabelBrowse, "Open the Directory to add or remove Libraries.");
            this.linkLabelBrowse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBrowse_LinkClicked);
            // 
            // linkLabelBrowseSelected
            // 
            this.linkLabelBrowseSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelBrowseSelected.AutoSize = true;
            this.linkLabelBrowseSelected.Enabled = false;
            this.linkLabelBrowseSelected.Location = new System.Drawing.Point(205, 285);
            this.linkLabelBrowseSelected.Name = "linkLabelBrowseSelected";
            this.linkLabelBrowseSelected.Size = new System.Drawing.Size(49, 13);
            this.linkLabelBrowseSelected.TabIndex = 5;
            this.linkLabelBrowseSelected.TabStop = true;
            this.linkLabelBrowseSelected.Text = "&Selected";
            this.linkLabelBrowseSelected.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTipInfo.SetToolTip(this.linkLabelBrowseSelected, "Open the Selected Library directory");
            this.linkLabelBrowseSelected.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBrowseSelected_LinkClicked);
            // 
            // groupBoxHint
            // 
            this.groupBoxHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxHint.Controls.Add(this.pictureBox1);
            this.groupBoxHint.Controls.Add(this.label3);
            this.groupBoxHint.Location = new System.Drawing.Point(-12, 355);
            this.groupBoxHint.Name = "groupBoxHint";
            this.groupBoxHint.Size = new System.Drawing.Size(361, 75);
            this.groupBoxHint.TabIndex = 1;
            this.groupBoxHint.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibraryManager.Properties.Resources.info;
            this.pictureBox1.Location = new System.Drawing.Point(25, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(55, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 43);
            this.label3.TabIndex = 0;
            this.label3.Text = "If you manually add or remove libraries to the Library folder, they will appear a" +
    "utomatically in the list.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialogLibrary
            // 
            this.openFileDialogLibrary.Filter = "Library file (*.zip; *.cpp)|*.zip;*.cpp|All files (*.*)|*.*";
            // 
            // panelForm
            // 
            this.panelForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForm.Controls.Add(this.buttonAdd);
            this.panelForm.Controls.Add(this.groupBoxInstalledLibraries);
            this.panelForm.Controls.Add(this.buttonOK);
            this.panelForm.Controls.Add(this.buttonCancel);
            this.panelForm.Location = new System.Drawing.Point(1, 1);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(335, 353);
            this.panelForm.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(12, 325);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "&Add...";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // groupBoxInstalledLibraries
            // 
            this.groupBoxInstalledLibraries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInstalledLibraries.Controls.Add(this.label2);
            this.groupBoxInstalledLibraries.Controls.Add(this.label1);
            this.groupBoxInstalledLibraries.Controls.Add(this.linkLabelBrowse);
            this.groupBoxInstalledLibraries.Controls.Add(this.linkLabelBrowseSelected);
            this.groupBoxInstalledLibraries.Controls.Add(this.linkLabelEnableNone);
            this.groupBoxInstalledLibraries.Controls.Add(this.linkLabelEnableAll);
            this.groupBoxInstalledLibraries.Controls.Add(this.checkedListBoxLibraries);
            this.groupBoxInstalledLibraries.Location = new System.Drawing.Point(12, 10);
            this.groupBoxInstalledLibraries.Name = "groupBoxInstalledLibraries";
            this.groupBoxInstalledLibraries.Size = new System.Drawing.Size(311, 309);
            this.groupBoxInstalledLibraries.TabIndex = 1;
            this.groupBoxInstalledLibraries.TabStop = false;
            this.groupBoxInstalledLibraries.Text = "User Libraries";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Browse:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enable:";
            // 
            // linkLabelEnableNone
            // 
            this.linkLabelEnableNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabelEnableNone.AutoSize = true;
            this.linkLabelEnableNone.Location = new System.Drawing.Point(68, 285);
            this.linkLabelEnableNone.Name = "linkLabelEnableNone";
            this.linkLabelEnableNone.Size = new System.Drawing.Size(33, 13);
            this.linkLabelEnableNone.TabIndex = 3;
            this.linkLabelEnableNone.TabStop = true;
            this.linkLabelEnableNone.Text = "None";
            this.linkLabelEnableNone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEnableNone_LinkClicked);
            // 
            // linkLabelEnableAll
            // 
            this.linkLabelEnableAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabelEnableAll.AutoSize = true;
            this.linkLabelEnableAll.Location = new System.Drawing.Point(52, 285);
            this.linkLabelEnableAll.Name = "linkLabelEnableAll";
            this.linkLabelEnableAll.Size = new System.Drawing.Size(18, 13);
            this.linkLabelEnableAll.TabIndex = 2;
            this.linkLabelEnableAll.TabStop = true;
            this.linkLabelEnableAll.Text = "All";
            this.linkLabelEnableAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEnableAll_LinkClicked);
            // 
            // checkedListBoxLibraries
            // 
            this.checkedListBoxLibraries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxLibraries.IntegralHeight = false;
            this.checkedListBoxLibraries.Location = new System.Drawing.Point(15, 22);
            this.checkedListBoxLibraries.Name = "checkedListBoxLibraries";
            this.checkedListBoxLibraries.Size = new System.Drawing.Size(281, 260);
            this.checkedListBoxLibraries.TabIndex = 0;
            this.checkedListBoxLibraries.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxLibraries_SelectedIndexChanged);
            this.checkedListBoxLibraries.DoubleClick += new System.EventHandler(this.checkedListBoxLibraries_DoubleClick);
            this.checkedListBoxLibraries.KeyUp += new System.Windows.Forms.KeyEventHandler(this.checkedListBoxLibraries_KeyUp);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(167, 325);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(248, 325);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 415);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.groupBoxHint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 240);
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Libraries";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherLibraries)).EndInit();
            this.groupBoxHint.ResumeLayout(false);
            this.groupBoxHint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.groupBoxInstalledLibraries.ResumeLayout(false);
            this.groupBoxInstalledLibraries.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcherLibraries;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.GroupBox groupBoxHint;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialogLibrary;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.GroupBox groupBoxInstalledLibraries;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelBrowse;
        private System.Windows.Forms.LinkLabel linkLabelBrowseSelected;
        private System.Windows.Forms.LinkLabel linkLabelEnableNone;
        private System.Windows.Forms.LinkLabel linkLabelEnableAll;
        private System.Windows.Forms.CheckedListBox checkedListBoxLibraries;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}

