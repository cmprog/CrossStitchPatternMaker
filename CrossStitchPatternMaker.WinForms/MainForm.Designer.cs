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
            this.mMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.mToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mToolStripMenuItemFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItemFileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mStitchPatternControl = new CrossStitchPatternMaker.WinForms.StitchPatternControl();
            this.mMarkerSelectionControl = new CrossStitchPatternMaker.WinForms.MarkerSelectionControl();
            this.mMainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mMainMenuStrip
            // 
            this.mMainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mToolStripMenuItemFile});
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
            this.mToolStripMenuItemExit});
            this.mToolStripMenuItemFile.Name = "mToolStripMenuItemFile";
            this.mToolStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.mToolStripMenuItemFile.Text = "File";
            // 
            // mToolStripMenuItemFileNew
            // 
            this.mToolStripMenuItemFileNew.Name = "mToolStripMenuItemFileNew";
            this.mToolStripMenuItemFileNew.Size = new System.Drawing.Size(144, 22);
            this.mToolStripMenuItemFileNew.Text = "New Pattern";
            this.mToolStripMenuItemFileNew.Click += new System.EventHandler(this.ToolStripMenuItemFileNew_Click);
            // 
            // mToolStripMenuItemFileOpen
            // 
            this.mToolStripMenuItemFileOpen.Name = "mToolStripMenuItemFileOpen";
            this.mToolStripMenuItemFileOpen.Size = new System.Drawing.Size(144, 22);
            this.mToolStripMenuItemFileOpen.Text = "Open Pattern";
            // 
            // mToolStripMenuItemFileSeparator1
            // 
            this.mToolStripMenuItemFileSeparator1.Name = "mToolStripMenuItemFileSeparator1";
            this.mToolStripMenuItemFileSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // mToolStripMenuItemFileSave
            // 
            this.mToolStripMenuItemFileSave.Name = "mToolStripMenuItemFileSave";
            this.mToolStripMenuItemFileSave.Size = new System.Drawing.Size(144, 22);
            this.mToolStripMenuItemFileSave.Text = "Save";
            // 
            // mToolStripMenuItemFileSaveAs
            // 
            this.mToolStripMenuItemFileSaveAs.Name = "mToolStripMenuItemFileSaveAs";
            this.mToolStripMenuItemFileSaveAs.Size = new System.Drawing.Size(144, 22);
            this.mToolStripMenuItemFileSaveAs.Text = "Save As";
            // 
            // mToolStripMenuItemFileSeparator2
            // 
            this.mToolStripMenuItemFileSeparator2.Name = "mToolStripMenuItemFileSeparator2";
            this.mToolStripMenuItemFileSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // mToolStripMenuItemExit
            // 
            this.mToolStripMenuItemExit.Name = "mToolStripMenuItemExit";
            this.mToolStripMenuItemExit.Size = new System.Drawing.Size(144, 22);
            this.mToolStripMenuItemExit.Text = "Exit";
            // 
            // mStitchPatternControl
            // 
            this.mStitchPatternControl.ActiveMarker = null;
            this.mStitchPatternControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mStitchPatternControl.Grid = null;
            this.mStitchPatternControl.Location = new System.Drawing.Point(0, 24);
            this.mStitchPatternControl.Name = "mStitchPatternControl";
            this.mStitchPatternControl.Size = new System.Drawing.Size(555, 456);
            this.mStitchPatternControl.TabIndex = 0;
            this.mStitchPatternControl.Text = "stitchPatternControl1";
            // 
            // mMarkerSelectionControl
            // 
            this.mMarkerSelectionControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.mMarkerSelectionControl.Location = new System.Drawing.Point(555, 24);
            this.mMarkerSelectionControl.Name = "mMarkerSelectionControl";
            this.mMarkerSelectionControl.Repository = null;
            this.mMarkerSelectionControl.SelectedMarker = null;
            this.mMarkerSelectionControl.Size = new System.Drawing.Size(292, 456);
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
            this.MainMenuStrip = this.mMainMenuStrip;
            this.Name = "MainForm";
            this.ShowIcon = false;
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
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItemExit;
        private MarkerSelectionControl mMarkerSelectionControl;
    }
}

