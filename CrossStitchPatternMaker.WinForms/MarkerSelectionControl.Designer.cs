namespace CrossStitchPatternMaker.WinForms
{
    partial class MarkerSelectionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mListBoxMarkers = new System.Windows.Forms.ListBox();
            this.mGroupBoxSearch = new System.Windows.Forms.GroupBox();
            this.mTextBoxSearch = new System.Windows.Forms.TextBox();
            this.mGroupBoxMarkers = new System.Windows.Forms.GroupBox();
            this.mGroupBoxSearch.SuspendLayout();
            this.mGroupBoxMarkers.SuspendLayout();
            this.SuspendLayout();
            // 
            // mListBoxMarkers
            // 
            this.mListBoxMarkers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mListBoxMarkers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.mListBoxMarkers.FormattingEnabled = true;
            this.mListBoxMarkers.IntegralHeight = false;
            this.mListBoxMarkers.ItemHeight = 26;
            this.mListBoxMarkers.Location = new System.Drawing.Point(6, 19);
            this.mListBoxMarkers.Name = "mListBoxMarkers";
            this.mListBoxMarkers.Size = new System.Drawing.Size(274, 368);
            this.mListBoxMarkers.TabIndex = 0;
            this.mListBoxMarkers.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxMarkers_DrawItem);
            this.mListBoxMarkers.SelectedIndexChanged += new System.EventHandler(this.ListBoxMarkers_SelectedIndexChanged);
            // 
            // mGroupBoxSearch
            // 
            this.mGroupBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mGroupBoxSearch.Controls.Add(this.mTextBoxSearch);
            this.mGroupBoxSearch.Location = new System.Drawing.Point(3, 3);
            this.mGroupBoxSearch.Name = "mGroupBoxSearch";
            this.mGroupBoxSearch.Size = new System.Drawing.Size(286, 45);
            this.mGroupBoxSearch.TabIndex = 1;
            this.mGroupBoxSearch.TabStop = false;
            this.mGroupBoxSearch.Text = "Search";
            // 
            // mTextBoxSearch
            // 
            this.mTextBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBoxSearch.Location = new System.Drawing.Point(6, 19);
            this.mTextBoxSearch.Name = "mTextBoxSearch";
            this.mTextBoxSearch.Size = new System.Drawing.Size(274, 20);
            this.mTextBoxSearch.TabIndex = 0;
            // 
            // mGroupBoxMarkers
            // 
            this.mGroupBoxMarkers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mGroupBoxMarkers.Controls.Add(this.mListBoxMarkers);
            this.mGroupBoxMarkers.Location = new System.Drawing.Point(3, 54);
            this.mGroupBoxMarkers.Name = "mGroupBoxMarkers";
            this.mGroupBoxMarkers.Size = new System.Drawing.Size(286, 393);
            this.mGroupBoxMarkers.TabIndex = 2;
            this.mGroupBoxMarkers.TabStop = false;
            this.mGroupBoxMarkers.Text = "Markers";
            // 
            // MarkerSelectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mGroupBoxMarkers);
            this.Controls.Add(this.mGroupBoxSearch);
            this.Name = "MarkerSelectionControl";
            this.Size = new System.Drawing.Size(292, 450);
            this.mGroupBoxSearch.ResumeLayout(false);
            this.mGroupBoxSearch.PerformLayout();
            this.mGroupBoxMarkers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox mListBoxMarkers;
        private System.Windows.Forms.GroupBox mGroupBoxSearch;
        private System.Windows.Forms.TextBox mTextBoxSearch;
        private System.Windows.Forms.GroupBox mGroupBoxMarkers;
    }
}
