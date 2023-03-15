namespace SQLiteTurbo
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCloseComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mniGenerateChangeScriptLeftToRight = new System.Windows.Forms.ToolStripMenuItem();
            this.mniGenerateChangeScriptRightToLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mniExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCopyFromLeftDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCopyFromRightDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mniEditSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniGotoNextDifference = new System.Windows.Forms.ToolStripMenuItem();
            this.mniGotoPreviousDifference = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCompare = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNextDiff = new System.Windows.Forms.ToolStripButton();
            this.btnPreviousDiff = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopyFromLeftDB = new System.Windows.Forms.ToolStripButton();
            this.btnCopyFromRightDB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditSelectedDifference = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportDataDifferences = new System.Windows.Forms.ToolStripButton();
            this.pnlContents = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AccessibleName = "MenuStrip";
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.mergeToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(878, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.AccessibleName = "File";
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniCompare,
            this.mniCloseComparison,
            this.toolStripSeparator4,
            this.mniGenerateChangeScriptLeftToRight,
            this.mniGenerateChangeScriptRightToLeft,
            this.toolStripSeparator6,
            this.mniExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mniCompare
            // 
            this.mniCompare.AccessibleName = "Compare";
            this.mniCompare.Image = ((System.Drawing.Image)(resources.GetObject("mniCompare.Image")));
            this.mniCompare.Name = "mniCompare";
            this.mniCompare.Size = new System.Drawing.Size(276, 22);
            this.mniCompare.Text = "&Compare...";
            this.mniCompare.Click += new System.EventHandler(this.mniCompare_Click);
            // 
            // mniCloseComparison
            // 
            this.mniCloseComparison.AccessibleName = "Close";
            this.mniCloseComparison.Image = ((System.Drawing.Image)(resources.GetObject("mniCloseComparison.Image")));
            this.mniCloseComparison.Name = "mniCloseComparison";
            this.mniCloseComparison.Size = new System.Drawing.Size(276, 22);
            this.mniCloseComparison.Text = "C&lose comparison";
            this.mniCloseComparison.Click += new System.EventHandler(this.mniCloseComparison_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(273, 6);
            // 
            // mniGenerateChangeScriptLeftToRight
            // 
            this.mniGenerateChangeScriptLeftToRight.AccessibleName = "GenerateChangeScriptLeftToRight";
            this.mniGenerateChangeScriptLeftToRight.Image = ((System.Drawing.Image)(resources.GetObject("mniGenerateChangeScriptLeftToRight.Image")));
            this.mniGenerateChangeScriptLeftToRight.Name = "mniGenerateChangeScriptLeftToRight";
            this.mniGenerateChangeScriptLeftToRight.Size = new System.Drawing.Size(276, 22);
            this.mniGenerateChangeScriptLeftToRight.Text = "Generate change script (left -> right)...";
            this.mniGenerateChangeScriptLeftToRight.Click += new System.EventHandler(this.mniGenerateChangeScriptLeftToRight_Click);
            // 
            // mniGenerateChangeScriptRightToLeft
            // 
            this.mniGenerateChangeScriptRightToLeft.AccessibleName = "GenerateChangeScriptRightToLeft";
            this.mniGenerateChangeScriptRightToLeft.Image = ((System.Drawing.Image)(resources.GetObject("mniGenerateChangeScriptRightToLeft.Image")));
            this.mniGenerateChangeScriptRightToLeft.Name = "mniGenerateChangeScriptRightToLeft";
            this.mniGenerateChangeScriptRightToLeft.Size = new System.Drawing.Size(276, 22);
            this.mniGenerateChangeScriptRightToLeft.Text = "Generate change script (right -> left)...";
            this.mniGenerateChangeScriptRightToLeft.Click += new System.EventHandler(this.mniGenerateChangeScriptRightToLeft_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(273, 6);
            // 
            // mniExit
            // 
            this.mniExit.AccessibleName = "Exit";
            this.mniExit.Name = "mniExit";
            this.mniExit.Size = new System.Drawing.Size(276, 22);
            this.mniExit.Text = "E&xit";
            this.mniExit.Click += new System.EventHandler(this.mniExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.AccessibleName = "Edit";
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniCopyFromLeftDB,
            this.mniCopyFromRightDB,
            this.toolStripSeparator5,
            this.mniEditSelection});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // mniCopyFromLeftDB
            // 
            this.mniCopyFromLeftDB.Image = ((System.Drawing.Image)(resources.GetObject("mniCopyFromLeftDB.Image")));
            this.mniCopyFromLeftDB.Name = "mniCopyFromLeftDB";
            this.mniCopyFromLeftDB.Size = new System.Drawing.Size(213, 22);
            this.mniCopyFromLeftDB.Text = "Copy object from left DB";
            this.mniCopyFromLeftDB.Click += new System.EventHandler(this.mniCopyFromLeftDB_Click);
            // 
            // mniCopyFromRightDB
            // 
            this.mniCopyFromRightDB.Image = ((System.Drawing.Image)(resources.GetObject("mniCopyFromRightDB.Image")));
            this.mniCopyFromRightDB.Name = "mniCopyFromRightDB";
            this.mniCopyFromRightDB.Size = new System.Drawing.Size(213, 22);
            this.mniCopyFromRightDB.Text = "Copy object from right DB";
            this.mniCopyFromRightDB.Click += new System.EventHandler(this.mniCopyFromRightDB_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(210, 6);
            // 
            // mniEditSelection
            // 
            this.mniEditSelection.AccessibleName = "EditSelectedItem";
            this.mniEditSelection.Image = ((System.Drawing.Image)(resources.GetObject("mniEditSelection.Image")));
            this.mniEditSelection.Name = "mniEditSelection";
            this.mniEditSelection.Size = new System.Drawing.Size(213, 22);
            this.mniEditSelection.Text = "Edit current difference...";
            this.mniEditSelection.Click += new System.EventHandler(this.mniEditSelection_Click);
            // 
            // mergeToolStripMenuItem
            // 
            this.mergeToolStripMenuItem.AccessibleName = "View";
            this.mergeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniGotoNextDifference,
            this.mniGotoPreviousDifference,
            this.toolStripSeparator7,
            this.refreshToolStripMenuItem});
            this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
            this.mergeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.mergeToolStripMenuItem.Text = "&View";
            // 
            // mniGotoNextDifference
            // 
            this.mniGotoNextDifference.AccessibleName = "NextDiff";
            this.mniGotoNextDifference.Image = ((System.Drawing.Image)(resources.GetObject("mniGotoNextDifference.Image")));
            this.mniGotoNextDifference.Name = "mniGotoNextDifference";
            this.mniGotoNextDifference.Size = new System.Drawing.Size(207, 22);
            this.mniGotoNextDifference.Text = "Go to next difference";
            this.mniGotoNextDifference.Click += new System.EventHandler(this.mniGotoNextDifference_Click);
            // 
            // mniGotoPreviousDifference
            // 
            this.mniGotoPreviousDifference.AccessibleName = "PrevDiff";
            this.mniGotoPreviousDifference.Image = ((System.Drawing.Image)(resources.GetObject("mniGotoPreviousDifference.Image")));
            this.mniGotoPreviousDifference.Name = "mniGotoPreviousDifference";
            this.mniGotoPreviousDifference.Size = new System.Drawing.Size(207, 22);
            this.mniGotoPreviousDifference.Text = "Go to previous difference";
            this.mniGotoPreviousDifference.Click += new System.EventHandler(this.mniGotoPreviousDifference_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(204, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.AccessibleName = "Refresh";
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.mniRefresh_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.AccessibleName = "Help";
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniCheckForUpdates,
            this.mniReport,
            this.toolStripSeparator8,
            this.mniAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // mniCheckForUpdates
            // 
            this.mniCheckForUpdates.Image = ((System.Drawing.Image)(resources.GetObject("mniCheckForUpdates.Image")));
            this.mniCheckForUpdates.Name = "mniCheckForUpdates";
            this.mniCheckForUpdates.Size = new System.Drawing.Size(284, 22);
            this.mniCheckForUpdates.Text = "Check for updates...";
            this.mniCheckForUpdates.Click += new System.EventHandler(this.mniCheckForUpdates_Click);
            // 
            // mniReport
            // 
            this.mniReport.Image = ((System.Drawing.Image)(resources.GetObject("mniReport.Image")));
            this.mniReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mniReport.Name = "mniReport";
            this.mniReport.Size = new System.Drawing.Size(284, 22);
            this.mniReport.Text = "Report a bug / Suggest improvements...";
            this.mniReport.Click += new System.EventHandler(this.mniReport_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(281, 6);
            // 
            // mniAbout
            // 
            this.mniAbout.AccessibleName = "About";
            this.mniAbout.Image = ((System.Drawing.Image)(resources.GetObject("mniAbout.Image")));
            this.mniAbout.Name = "mniAbout";
            this.mniAbout.Size = new System.Drawing.Size(284, 22);
            this.mniAbout.Text = "About...";
            this.mniAbout.Click += new System.EventHandler(this.mniAbout_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleName = "ToolStrip";
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCompare,
            this.toolStripSeparator1,
            this.btnNextDiff,
            this.btnPreviousDiff,
            this.toolStripSeparator2,
            this.btnCopyFromLeftDB,
            this.btnCopyFromRightDB,
            this.toolStripSeparator3,
            this.btnEditSelectedDifference,
            this.toolStripSeparator9,
            this.btnExportDataDifferences});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(878, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCompare
            // 
            this.btnCompare.AccessibleName = "Compare";
            this.btnCompare.Image = ((System.Drawing.Image)(resources.GetObject("btnCompare.Image")));
            this.btnCompare.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(93, 28);
            this.btnCompare.Text = "Compare...";
            this.btnCompare.ToolTipText = "Compare... (Ctrl+O)";
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnNextDiff
            // 
            this.btnNextDiff.AccessibleName = "NextDiff";
            this.btnNextDiff.Image = ((System.Drawing.Image)(resources.GetObject("btnNextDiff.Image")));
            this.btnNextDiff.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNextDiff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNextDiff.Name = "btnNextDiff";
            this.btnNextDiff.Size = new System.Drawing.Size(80, 28);
            this.btnNextDiff.Text = "Next diff";
            this.btnNextDiff.ToolTipText = "Next diff (Alt+Down)";
            this.btnNextDiff.Click += new System.EventHandler(this.btnNextDiff_Click);
            this.btnNextDiff.EnabledChanged += new System.EventHandler(this.toolStripButton_EnabledChanged);
            // 
            // btnPreviousDiff
            // 
            this.btnPreviousDiff.AccessibleName = "PrevDiff";
            this.btnPreviousDiff.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviousDiff.Image")));
            this.btnPreviousDiff.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPreviousDiff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreviousDiff.Name = "btnPreviousDiff";
            this.btnPreviousDiff.Size = new System.Drawing.Size(79, 28);
            this.btnPreviousDiff.Text = "Prev diff";
            this.btnPreviousDiff.ToolTipText = "Prev diff (Alt+Up)";
            this.btnPreviousDiff.Click += new System.EventHandler(this.btnPreviousDiff_Click);
            this.btnPreviousDiff.EnabledChanged += new System.EventHandler(this.toolStripButton_EnabledChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // btnCopyFromLeftDB
            // 
            this.btnCopyFromLeftDB.AccessibleName = "CopyLeftToRight";
            this.btnCopyFromLeftDB.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyFromLeftDB.Image")));
            this.btnCopyFromLeftDB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCopyFromLeftDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyFromLeftDB.Name = "btnCopyFromLeftDB";
            this.btnCopyFromLeftDB.Size = new System.Drawing.Size(130, 28);
            this.btnCopyFromLeftDB.Text = "Copy from left DB";
            this.btnCopyFromLeftDB.ToolTipText = "Copy from left DB (Alt+Right)";
            this.btnCopyFromLeftDB.Click += new System.EventHandler(this.btnCopyFromLeftDB_Click);
            // 
            // btnCopyFromRightDB
            // 
            this.btnCopyFromRightDB.AccessibleName = "CopyRightToLeft";
            this.btnCopyFromRightDB.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyFromRightDB.Image")));
            this.btnCopyFromRightDB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCopyFromRightDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyFromRightDB.Name = "btnCopyFromRightDB";
            this.btnCopyFromRightDB.Size = new System.Drawing.Size(138, 28);
            this.btnCopyFromRightDB.Text = "Copy from right DB";
            this.btnCopyFromRightDB.ToolTipText = "Copy from right DB (Alt+Left)";
            this.btnCopyFromRightDB.Click += new System.EventHandler(this.btnCopyFromRightDB_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // btnEditSelectedDifference
            // 
            this.btnEditSelectedDifference.AccessibleName = "EditSelectedItem";
            this.btnEditSelectedDifference.Image = ((System.Drawing.Image)(resources.GetObject("btnEditSelectedDifference.Image")));
            this.btnEditSelectedDifference.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditSelectedDifference.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditSelectedDifference.Name = "btnEditSelectedDifference";
            this.btnEditSelectedDifference.Size = new System.Drawing.Size(137, 28);
            this.btnEditSelectedDifference.Text = "Edit selected item...";
            this.btnEditSelectedDifference.ToolTipText = "Edit selected item... (Alt+Enter)";
            this.btnEditSelectedDifference.Click += new System.EventHandler(this.btnEditSelectedDifference_Click);
            this.btnEditSelectedDifference.EnabledChanged += new System.EventHandler(this.toolStripButton_EnabledChanged);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 31);
            // 
            // btnExportDataDifferences
            // 
            this.btnExportDataDifferences.AccessibleName = "ExportDataDiffs";
            this.btnExportDataDifferences.Image = ((System.Drawing.Image)(resources.GetObject("btnExportDataDifferences.Image")));
            this.btnExportDataDifferences.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExportDataDifferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportDataDifferences.Name = "btnExportDataDifferences";
            this.btnExportDataDifferences.Size = new System.Drawing.Size(164, 28);
            this.btnExportDataDifferences.Text = "Export data differences...";
            this.btnExportDataDifferences.Click += new System.EventHandler(this.btnExportDataDifferences_Click);
            this.btnExportDataDifferences.EnabledChanged += new System.EventHandler(this.toolStripButton_EnabledChanged);
            // 
            // pnlContents
            // 
            this.pnlContents.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContents.Location = new System.Drawing.Point(0, 55);
            this.pnlContents.Name = "pnlContents";
            this.pnlContents.Size = new System.Drawing.Size(878, 581);
            this.pnlContents.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 658);
            this.Controls.Add(this.pnlContents);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SQLite Compare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel pnlContents;
        private System.Windows.Forms.ToolStripMenuItem mniCompare;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mniCloseComparison;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mniExit;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem mniGotoNextDifference;
        private System.Windows.Forms.ToolStripMenuItem mniGotoPreviousDifference;
        private System.Windows.Forms.ToolStripMenuItem mniCopyFromRightDB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mniEditSelection;
        private System.Windows.Forms.ToolStripMenuItem mniAbout;
        private System.Windows.Forms.ToolStripMenuItem mniCopyFromLeftDB;
        private System.Windows.Forms.ToolStripMenuItem mniReport;
        private System.Windows.Forms.ToolStripMenuItem mniGenerateChangeScriptLeftToRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mniGenerateChangeScriptRightToLeft;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem mniCheckForUpdates;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnCompare;
        private System.Windows.Forms.ToolStripButton btnNextDiff;
        private System.Windows.Forms.ToolStripButton btnPreviousDiff;
        private System.Windows.Forms.ToolStripButton btnCopyFromLeftDB;
        private System.Windows.Forms.ToolStripButton btnCopyFromRightDB;
        private System.Windows.Forms.ToolStripButton btnEditSelectedDifference;
        private System.Windows.Forms.ToolStripButton btnExportDataDifferences;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}