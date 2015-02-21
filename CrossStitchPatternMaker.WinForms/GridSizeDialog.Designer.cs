namespace CrossStitchPatternMaker.WinForms
{
    partial class GridSizeDialog
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
            this.mButtonChange = new System.Windows.Forms.Button();
            this.mLinkLabelCancel = new System.Windows.Forms.LinkLabel();
            this.mLabelWidth = new System.Windows.Forms.Label();
            this.mTextBoxWidth = new System.Windows.Forms.TextBox();
            this.mLabelHeight = new System.Windows.Forms.Label();
            this.mTextBoxHeight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mButtonChange
            // 
            this.mButtonChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mButtonChange.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.mButtonChange.Location = new System.Drawing.Point(85, 72);
            this.mButtonChange.Name = "mButtonChange";
            this.mButtonChange.Size = new System.Drawing.Size(75, 23);
            this.mButtonChange.TabIndex = 4;
            this.mButtonChange.Text = "Change";
            this.mButtonChange.UseVisualStyleBackColor = true;
            // 
            // mLinkLabelCancel
            // 
            this.mLinkLabelCancel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.mLinkLabelCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mLinkLabelCancel.AutoSize = true;
            this.mLinkLabelCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.mLinkLabelCancel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.mLinkLabelCancel.Location = new System.Drawing.Point(12, 77);
            this.mLinkLabelCancel.Name = "mLinkLabelCancel";
            this.mLinkLabelCancel.Size = new System.Drawing.Size(40, 13);
            this.mLinkLabelCancel.TabIndex = 5;
            this.mLinkLabelCancel.TabStop = true;
            this.mLinkLabelCancel.Text = "Cancel";
            this.mLinkLabelCancel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.mLinkLabelCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelCancel_LinkClicked);
            // 
            // mLabelWidth
            // 
            this.mLabelWidth.AutoSize = true;
            this.mLabelWidth.Location = new System.Drawing.Point(12, 15);
            this.mLabelWidth.Name = "mLabelWidth";
            this.mLabelWidth.Size = new System.Drawing.Size(35, 13);
            this.mLabelWidth.TabIndex = 0;
            this.mLabelWidth.Text = "Width";
            // 
            // mTextBoxWidth
            // 
            this.mTextBoxWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBoxWidth.Location = new System.Drawing.Point(56, 12);
            this.mTextBoxWidth.MaxLength = 4;
            this.mTextBoxWidth.Name = "mTextBoxWidth";
            this.mTextBoxWidth.Size = new System.Drawing.Size(104, 20);
            this.mTextBoxWidth.TabIndex = 1;
            this.mTextBoxWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNumber_KeyDown);
            // 
            // mLabelHeight
            // 
            this.mLabelHeight.AutoSize = true;
            this.mLabelHeight.Location = new System.Drawing.Point(12, 41);
            this.mLabelHeight.Name = "mLabelHeight";
            this.mLabelHeight.Size = new System.Drawing.Size(38, 13);
            this.mLabelHeight.TabIndex = 2;
            this.mLabelHeight.Text = "Height";
            // 
            // mTextBoxHeight
            // 
            this.mTextBoxHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBoxHeight.Location = new System.Drawing.Point(56, 38);
            this.mTextBoxHeight.MaxLength = 4;
            this.mTextBoxHeight.Name = "mTextBoxHeight";
            this.mTextBoxHeight.Size = new System.Drawing.Size(104, 20);
            this.mTextBoxHeight.TabIndex = 3;
            // 
            // GridSizeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 107);
            this.Controls.Add(this.mTextBoxHeight);
            this.Controls.Add(this.mLabelHeight);
            this.Controls.Add(this.mTextBoxWidth);
            this.Controls.Add(this.mLabelWidth);
            this.Controls.Add(this.mLinkLabelCancel);
            this.Controls.Add(this.mButtonChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GridSizeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Grid Size";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mButtonChange;
        private System.Windows.Forms.LinkLabel mLinkLabelCancel;
        private System.Windows.Forms.Label mLabelWidth;
        private System.Windows.Forms.TextBox mTextBoxWidth;
        private System.Windows.Forms.Label mLabelHeight;
        private System.Windows.Forms.TextBox mTextBoxHeight;
    }
}