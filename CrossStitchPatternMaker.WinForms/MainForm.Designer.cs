namespace CrossStitchPatternMaker.WinForms
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
            this.mMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.mToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mToolStripMenuItemFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemFileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mToolStripMenuItemFilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mToolStripMenuItemFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemEditClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemCellsPerInch = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemLineMarker = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemChangeGridSize = new System.Windows.Forms.ToolStripMenuItem();
            this.mStitchPatternControl = new CrossStitchPatternMaker.WinForms.StitchPatternControl();
            this.mMarkerSelectionControl = new CrossStitchPatternMaker.WinForms.MarkerSelectionControl();
            this.mMainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mMainMenuStrip
            // 
            this.mMainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mToolStripMenuItemFile,
            this.mToolStripMenuItemEdit,
            this.mToolStripMenuItemView});
            this.mMainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mMainMenuStrip.Name = "mMainMenuStrip";
            this.mMainMenuStrip.Size = new System.Drawing.Size(847, 24);
            this.mMainMenuStrip.TabIndex = 1;
            this.mMainMenuStrip.Text = "menuStrip1";
            // 
            // mToolStripMenuItemFile
            // 
            this.mToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mToolStripMenuItemFileNew,
            this.mToolStripMenuItemFileOpen,
            this.mToolStripMenuItemFileSeparator1,
            this.mToolStripMenuItemFileSave,
            this.mToolStripMenuItemFileSaveAs,
            this.mToolStripMenuItemFileSeparator2,
            this.mToolStripMenuItemFilePrint,
            this.toolStripSeparator1,
            this.mToolStripMenuItemFileExit});
            this.mToolStripMenuItemFile.Name = "mToolStripMenuItemFile";
            this.mToolStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.mToolStripMenuItemFile.Text = "File";
            this.mToolStripMenuItemFile.DropDownOpening += new System.EventHandler(this.ToolStripMenuItemFile_DropDownOpening);
            // 
            // mToolStripMenuItemFileNew
            // 
            this.mToolStripMenuItemFileNew.Name = "mToolStripMenuItemFileNew";
            this.mToolStripMenuItemFileNew.ShortcutKeyDisplayString = "Ctrl+N";
            this.mToolStripMenuItemFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mToolStripMenuItemFileNew.Size = new System.Drawing.Size(196, 22);
            this.mToolStripMenuItemFileNew.Text = "&New Pattern";
            this.mToolStripMenuItemFileNew.Click += new System.EventHandler(this.ToolStripMenuItemFileNew_Click);
            // 
            // mToolStripMenuItemFileOpen
            // 
            this.mToolStripMenuItemFileOpen.Name = "mToolStripMenuItemFileOpen";
            this.mToolStripMenuItemFileOpen.ShortcutKeyDisplayString = "Ctrl+O";
            this.mToolStripMenuItemFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mToolStripMenuItemFileOpen.Size = new System.Drawing.Size(196, 22);
            this.mToolStripMenuItemFileOpen.Text = "&Open Pattern...";
            this.mToolStripMenuItemFileOpen.Click += new System.EventHandler(this.ToolStripMenuItemOpen_Click);
            // 
            // mToolStripMenuItemFileSeparator1
            // 
            this.mToolStripMenuItemFileSeparator1.Name = "mToolStripMenuItemFileSeparator1";
            this.mToolStripMenuItemFileSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // mToolStripMenuItemFileSave
            // 
            this.mToolStripMenuItemFileSave.Name = "mToolStripMenuItemFileSave";
            this.mToolStripMenuItemFileSave.ShortcutKeyDisplayString = "Ctrl+S";
            this.mToolStripMenuItemFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mToolStripMenuItemFileSave.Size = new System.Drawing.Size(196, 22);
            this.mToolStripMenuItemFileSave.Text = "&Save";
            this.mToolStripMenuItemFileSave.Click += new System.EventHandler(this.ToolStripMenuItemFileSave_Click);
            // 
            // mToolStripMenuItemFileSaveAs
            // 
            this.mToolStripMenuItemFileSaveAs.Name = "mToolStripMenuItemFileSaveAs";
            this.mToolStripMenuItemFileSaveAs.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            this.mToolStripMenuItemFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mToolStripMenuItemFileSaveAs.Size = new System.Drawing.Size(196, 22);
            this.mToolStripMenuItemFileSaveAs.Text = "Save &As...";
            this.mToolStripMenuItemFileSaveAs.Click += new System.EventHandler(this.ToolStripMenuItemFileSaveAs_Click);
            // 
            // mToolStripMenuItemFileSeparator2
            // 
            this.mToolStripMenuItemFileSeparator2.Name = "mToolStripMenuItemFileSeparator2";
            this.mToolStripMenuItemFileSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // mToolStripMenuItemFilePrint
            // 
            this.mToolStripMenuItemFilePrint.Name = "mToolStripMenuItemFilePrint";
            this.mToolStripMenuItemFilePrint.ShortcutKeyDisplayString = "Ctrl+P";
            this.mToolStripMenuItemFilePrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mToolStripMenuItemFilePrint.Size = new System.Drawing.Size(196, 22);
            this.mToolStripMenuItemFilePrint.Text = "&Print...";
            this.mToolStripMenuItemFilePrint.Click += new System.EventHandler(this.ToolStripMenuItemFilePrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // mToolStripMenuItemFileExit
            // 
            this.mToolStripMenuItemFileExit.Name = "mToolStripMenuItemFileExit";
            this.mToolStripMenuItemFileExit.ShortcutKeyDisplayString = "Alt+F4";
            this.mToolStripMenuItemFileExit.Size = new System.Drawing.Size(196, 22);
            this.mToolStripMenuItemFileExit.Text = "E&xit";
            this.mToolStripMenuItemFileExit.Click += new System.EventHandler(this.ToolStripMenuItemFileExit_Click);
            // 
            // mToolStripMenuItemEdit
            // 
            this.mToolStripMenuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mToolStripMenuItemEditClear});
            this.mToolStripMenuItemEdit.Name = "mToolStripMenuItemEdit";
            this.mToolStripMenuItemEdit.Size = new System.Drawing.Size(39, 20);
            this.mToolStripMenuItemEdit.Text = "Edit";
            // 
            // mToolStripMenuItemEditClear
            // 
            this.mToolStripMenuItemEditClear.Name = "mToolStripMenuItemEditClear";
            this.mToolStripMenuItemEditClear.Size = new System.Drawing.Size(126, 22);
            this.mToolStripMenuItemEditClear.Text = "Clear Grid";
            this.mToolStripMenuItemEditClear.Click += new System.EventHandler(this.ToolStripMenuItemEditClear_Click);
            // 
            // mToolStripMenuItemView
            // 
            this.mToolStripMenuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mToolStripMenuItemCellsPerInch,
            this.mToolStripMenuItemLineMarker,
            this.mToolStripMenuItemChangeGridSize});
            this.mToolStripMenuItemView.Name = "mToolStripMenuItemView";
            this.mToolStripMenuItemView.Size = new System.Drawing.Size(44, 20);
            this.mToolStripMenuItemView.Text = "View";
            // 
            // mToolStripMenuItemCellsPerInch
            // 
            this.mToolStripMenuItemCellsPerInch.Name = "mToolStripMenuItemCellsPerInch";
            this.mToolStripMenuItemCellsPerInch.Size = new System.Drawing.Size(170, 22);
            this.mToolStripMenuItemCellsPerInch.Text = "Cells Per Inch";
            // 
            // mToolStripMenuItemLineMarker
            // 
            this.mToolStripMenuItemLineMarker.Name = "mToolStripMenuItemLineMarker";
            this.mToolStripMenuItemLineMarker.Size = new System.Drawing.Size(170, 22);
            this.mToolStripMenuItemLineMarker.Text = "Line Marker Every";
            // 
            // mToolStripMenuItemChangeGridSize
            // 
            this.mToolStripMenuItemChangeGridSize.Name = "mToolStripMenuItemChangeGridSize";
            this.mToolStripMenuItemChangeGridSize.Size = new System.Drawing.Size(170, 22);
            this.mToolStripMenuItemChangeGridSize.Text = "Change grid size...";
            this.mToolStripMenuItemChangeGridSize.Click += new System.EventHandler(this.ToolStripMenuItemChangeGridSize_Click);
            // 
            // mStitchPatternControl
            // 
            this.mStitchPatternControl.ActiveMarker = null;
            this.mStitchPatternControl.CellsPerInch = 10F;
            this.mStitchPatternControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mStitchPatternControl.Grid = null;
            this.mStitchPatternControl.Location = new System.Drawing.Point(0, 24);
            this.mStitchPatternControl.Name = "mStitchPatternControl";
            this.mStitchPatternControl.Padding = new System.Windows.Forms.Padding(1);
            this.mStitchPatternControl.Size = new System.Drawing.Size(622, 456);
            this.mStitchPatternControl.TabIndex = 0;
            this.mStitchPatternControl.Text = "stitchPatternControl1";
            this.mStitchPatternControl.ThickLineFrequency = 0;
            // 
            // mMarkerSelectionControl
            // 
            this.mMarkerSelectionControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.mMarkerSelectionControl.Location = new System.Drawing.Point(622, 24);
            this.mMarkerSelectionControl.Name = "mMarkerSelectionControl";
            this.mMarkerSelectionControl.Repository = null;
            this.mMarkerSelectionControl.SelectedMarker = null;
            this.mMarkerSelectionControl.Size = new System.Drawing.Size(225, 456);
            this.mMarkerSelectionControl.TabIndex = 2;
            this.mMarkerSelectionControl.SelectedMarkerChanged += new System.EventHandler(this.MarkerSelectionControl_SelectedMarkerChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 480);
            this.Controls.Add(this.mStitchPatternControl);
            this.Controls.Add(this.mMarkerSelectionControl);
            this.Controls.Add(this.mMainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mMainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Cross Stitch Pattern Maker";
            this.mMainMenuStrip.ResumeLayout(false);
            this.mMainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StitchPatternControl mStitchPatternControl;
        private System.Windows.Forms.MenuStrip mMainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemFileNew;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemFileOpen;
        private System.Windows.Forms.ToolStripSeparator mToolStripMenuItemFileSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemFileSave;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator mToolStripMenuItemFileSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemFileExit;
        private MarkerSelectionControl mMarkerSelectionControl;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemEditClear;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemFilePrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemView;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemCellsPerInch;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemLineMarker;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemChangeGridSize;
    }
}

