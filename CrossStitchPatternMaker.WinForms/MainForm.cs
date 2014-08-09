using System;
using System.Drawing;
using System.Drawing.Printing;
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
            var lCrossStitchDirectoryPath = Path.Combine(lApplicationDataDirectoryPath, "Cross Stitch Pattern Maker");
            var lMarkerDirectoryPath = Path.Combine(lCrossStitchDirectoryPath, "Markers");
            Directory.CreateDirectory(lMarkerDirectoryPath);
            this.mMarkerSelectionControl.Repository = new StitchMarkerRepository(lMarkerDirectoryPath);
        }

        public MainForm(string filePath)
            : this()
        {
            this.ActivePattern = CrossStitchPattern.CreateFromFile(
                filePath, this.mMarkerSelectionControl.Repository);
            this.CurrentFilePath = filePath;
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
            this.mToolStripMenuItemFilePrint.Enabled = (this.ActivePattern != null);
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

        private void ToolStripMenuItemFilePrint_Click(object sender, EventArgs e)
        {
            using (var lPrintDocument = new PrintDocument())
            {
                lPrintDocument.PrintPage += this.PrintDocument_PrintPage;
                lPrintDocument.DefaultPageSettings.Margins.Top = 50; // hundredths of an inch
                lPrintDocument.DefaultPageSettings.Margins.Bottom = 50;
                lPrintDocument.DefaultPageSettings.Margins.Right = 50;
                lPrintDocument.DefaultPageSettings.Margins.Left = 50;
                lPrintDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            this.mStitchPatternControl.DrawGrid(e.Graphics, e.MarginBounds);
            e.HasMorePages = false;
        }

        #endregion
    }
}
