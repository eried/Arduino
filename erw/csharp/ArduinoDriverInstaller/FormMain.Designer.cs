namespace ArduinoDriverInstaller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.backgroundWorkerInstall = new System.ComponentModel.BackgroundWorker();
            this.groupBoxHint = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelForm = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoxDrivers = new System.Windows.Forms.CheckedListBox();
            this.labelOK = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.groupBoxHint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorkerInstall
            // 
            this.backgroundWorkerInstall.WorkerReportsProgress = true;
            this.backgroundWorkerInstall.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerInstall_DoWork);
            this.backgroundWorkerInstall.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerInstall_ProgressChanged);
            this.backgroundWorkerInstall.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerInstall_RunWorkerCompleted);
            // 
            // groupBoxHint
            // 
            this.groupBoxHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxHint.Controls.Add(this.pictureBox1);
            this.groupBoxHint.Controls.Add(this.label3);
            this.groupBoxHint.Location = new System.Drawing.Point(-27, 290);
            this.groupBoxHint.Name = "groupBoxHint";
            this.groupBoxHint.Size = new System.Drawing.Size(501, 75);
            this.groupBoxHint.TabIndex = 11;
            this.groupBoxHint.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ArduinoDriverInstaller.Properties.Resources.info;
            this.pictureBox1.Location = new System.Drawing.Point(39, 22);
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
            this.label3.Location = new System.Drawing.Point(69, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(405, 43);
            this.label3.TabIndex = 10;
            this.label3.Text = "Installing all the boards is recommended, however you can always call this Board " +
    "Installer later from the icons in your start menu, inside the Arduino folder.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelForm
            // 
            this.panelForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForm.Controls.Add(this.label1);
            this.panelForm.Controls.Add(this.checkedListBoxDrivers);
            this.panelForm.Controls.Add(this.labelOK);
            this.panelForm.Controls.Add(this.buttonCancel);
            this.panelForm.Controls.Add(this.buttonInstall);
            this.panelForm.Location = new System.Drawing.Point(4, 4);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(451, 287);
            this.panelForm.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select the boards you want to use (even if you don\'t have them right now):";
            // 
            // checkedListBoxDrivers
            // 
            this.checkedListBoxDrivers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxDrivers.CheckOnClick = true;
            this.checkedListBoxDrivers.IntegralHeight = false;
            this.checkedListBoxDrivers.Location = new System.Drawing.Point(8, 23);
            this.checkedListBoxDrivers.Name = "checkedListBoxDrivers";
            this.checkedListBoxDrivers.Size = new System.Drawing.Size(435, 227);
            this.checkedListBoxDrivers.TabIndex = 6;
            this.checkedListBoxDrivers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxDrivers_ItemCheck);
            // 
            // labelOK
            // 
            this.labelOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOK.AutoEllipsis = true;
            this.labelOK.Location = new System.Drawing.Point(8, 261);
            this.labelOK.Name = "labelOK";
            this.labelOK.Size = new System.Drawing.Size(273, 13);
            this.labelOK.TabIndex = 8;
            this.labelOK.Text = "status";
            this.labelOK.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(368, 256);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonInstall
            // 
            this.buttonInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstall.Enabled = false;
            this.buttonInstall.Location = new System.Drawing.Point(287, 256);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(75, 23);
            this.buttonInstall.TabIndex = 7;
            this.buttonInstall.Text = "&Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 348);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.groupBoxHint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(262, 155);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Install Board Drivers";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBoxHint.ResumeLayout(false);
            this.groupBoxHint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerInstall;
        private System.Windows.Forms.GroupBox groupBoxHint;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBoxDrivers;
        private System.Windows.Forms.Label labelOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonInstall;
    }
}

