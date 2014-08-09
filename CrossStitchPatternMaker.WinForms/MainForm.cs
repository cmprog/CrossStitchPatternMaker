using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CrossStitchPatternMaker.WinForms
{
    public partial class MainForm : Form
    {
        #region Instance Fields --------------------------------------------------------

        private CrossStitchPattern mActivePattern;
        private string mCurrentFilePath;

        #endregion

        #region Constructors -----------------------------------------------------------

        public MainForm()
        {
            InitializeComponent();

            this.ActivePattern = new CrossStitchPattern();

            var lApplicationDataDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var lCrossStitchDirectoryPath = Path.Combine(lApplicationDataDirectoryPath, "CrossStitchPatternMaker");
            var lMarkerDirectoryPath = Path.Combine(lCrossStitchDirectoryPath, "Markers");
            Directory.CreateDirectory(lMarkerDirectoryPath);
            this.mMarkerSelectionControl.Repository = new StitchMarkerRepository(lMarkerDirectoryPath);
        }

        #endregion

        #region Instance Properties ----------------------------------------------------

        public CrossStitchPattern ActivePattern
        {
            get { return this.mActivePattern; }
            set
            {
                this.mActivePattern = value;
                this.mStitchPatternControl.Grid =
                    (this.mActivePattern == null)
                        ? null : this.mActivePattern.Grid;
            }
        }

        private string CurrentFilePath
        {
            get { return this.mCurrentFilePath; }
            set
            {
                this.mCurrentFilePath = value;
                
                var lTitleBuilder = new StringBuilder();
                lTitleBuilder.Append("Cross Stitch Pattern Mater");
                if (!string.IsNullOrWhiteSpace(this.mCurrentFilePath))
                {
                    lTitleBuilder.Append(" | ");
                    lTitleBuilder.Append(Path.GetFileNameWithoutExtension(this.CurrentFilePath));
                }
                this.Text = lTitleBuilder.ToString();
            }
        }

        #endregion

        #region Instance Methods -------------------------------------------------------

        private void ToolStripMenuItemFileSaveAs_Click(object sender, EventArgs e)
        {
            using (var lSaveFileDialog = new SaveFileDialog())
            {
                lSaveFileDialog.OverwritePrompt = true;
                lSaveFileDialog.Filter = "Cross Stitch Pattern Files (*.cspatt)|*.cspatt|All Files (*.*)|*.*";

                if (lSaveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.ActivePattern.SaveAs(lSaveFileDialog.FileName);
                    this.CurrentFilePath = lSaveFileDialog.FileName;
                }
            }
        }

        private void ToolStripMenuItemFileNew_Click(object sender, System.EventArgs e)
        {
            this.ActivePattern = new CrossStitchPattern();
            this.CurrentFilePath = string.Empty;
        }

        private void ToolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            using (var lOpenFileDialog = new OpenFileDialog())
            {
                lOpenFileDialog.Filter = "Cross Stitch Pattern Files (*.cspatt)|*.cspatt|All Files (*.*)|*.*";
                
                if (lOpenFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.ActivePattern = CrossStitchPattern.CreateFromFile(
                        lOpenFileDialog.FileName, this.mMarkerSelectionControl.Repository);
                    this.CurrentFilePath = lOpenFileDialog.FileName;
                }
            }
        }

        private void MarkerSelectionControl_SelectedMarkerChanged(object sender, EventArgs e)
        {
            this.mStitchPatternControl.ActiveMarker = this.mMarkerSelectionControl.SelectedMarker;
        }

        private void ToolStripMenuItemFile_DropDownOpening(object sender, EventArgs e)
        {
            this.mToolStripMenuItemFileSave.Enabled = !string.IsNullOrWhiteSpace(this.CurrentFilePath);
        }

        private void ToolStripMenuItemFileSave_Click(object sender, EventArgs e)
        {
            this.ActivePattern.SaveAs(this.CurrentFilePath);
        }

        private void ToolStripMenuItemFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripMenuItemEditClear_Click(object sender, EventArgs e)
        {
            if (this.ActivePattern == null) return;
            this.ActivePattern.Grid.Clear();
            this.mStitchPatternControl.Invalidate();
        }

        #endregion
    }
}
