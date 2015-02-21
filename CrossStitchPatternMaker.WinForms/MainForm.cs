using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrossStitchPatternMaker.Drawing;

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

            const int lcDefaultCellPerInch = 10;
            for (int lCellPerInch = 5; lCellPerInch <= 12; lCellPerInch++)
            {
                var lToolStripMenuItem = new ToolStripMenuItem();
                lToolStripMenuItem.Text = lCellPerInch.ToString();
                lToolStripMenuItem.Tag = (float)lCellPerInch;
                lToolStripMenuItem.Click += this.ToolStripMenuItemCellsPerInchValue_CheckedChanged;
                lToolStripMenuItem.CheckOnClick = true;
                lToolStripMenuItem.Checked = (lCellPerInch == lcDefaultCellPerInch);
                this.mToolStripMenuItemCellsPerInch.DropDownItems.Add(lToolStripMenuItem);
            }
            this.mStitchPatternControl.CellsPerInch = lcDefaultCellPerInch;

            const int lcDefaultLineMarkerAmount = 10;
            for (int lLineMarkerAmount = 5; lLineMarkerAmount <= 12; lLineMarkerAmount++)
            {
                var lToolStripMenuItem = new ToolStripMenuItem();
                lToolStripMenuItem.Text = lLineMarkerAmount.ToString();
                lToolStripMenuItem.Tag = lLineMarkerAmount;
                lToolStripMenuItem.Click += this.ToolStripMenuItemLineMarkerValue_CheckedChanged;
                lToolStripMenuItem.CheckOnClick = true;
                lToolStripMenuItem.Checked = (lLineMarkerAmount == 10);
                this.mToolStripMenuItemLineMarker.DropDownItems.Add(lToolStripMenuItem);
            }
            this.mStitchPatternControl.ThickLineFrequency = lcDefaultLineMarkerAmount;

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

        private void ToolStripMenuItemCellsPerInchValue_CheckedChanged(object sender, EventArgs e)
        {
            var lToolStripMenuItem = (ToolStripMenuItem) sender;
            if (!lToolStripMenuItem.Checked) return;

            foreach (var lItem in this.mToolStripMenuItemCellsPerInch
                .DropDownItems.OfType<ToolStripMenuItem>().Where(x => x.CheckOnClick))
            {
                if (lItem == lToolStripMenuItem) continue;
                lItem.Checked = false;
            }

            var lValue = (float) lToolStripMenuItem.Tag;
            this.mStitchPatternControl.CellsPerInch = lValue;
        }

        private void ToolStripMenuItemChangeGridSize_Click(object sender, EventArgs e)
        {
            using (var lDialog = new GridSizeDialog())
            {
                lDialog.GridWidth = this.ActivePattern.Grid.Width;
                lDialog.GridHeight = this.ActivePattern.Grid.Height;
                if (lDialog.ShowDialog(this) != DialogResult.OK) return;

                var lSuggestedWidth = lDialog.GridWidth;
                var lSuggestedHeight = lDialog.GridHeight;

                if (this.ActivePattern.Grid.WillSizeChangeResultInDataLoss(lSuggestedWidth, lSuggestedHeight))
                {
                    var lDialogResult = MessageBox.Show(
                        "Are you sure you want to make the grid smaller? This will result in a loss of work.", 
                        "Are you sure...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (lDialogResult != DialogResult.Yes) return;
                }

                this.ActivePattern.Grid.Width = lSuggestedWidth;
                this.ActivePattern.Grid.Height = lSuggestedHeight;
                this.mStitchPatternControl.Invalidate();
            }
        }

        private void ToolStripMenuItemLineMarkerValue_CheckedChanged(object sender, EventArgs e)
        {
            var lToolStripMenuItem = (ToolStripMenuItem)sender;
            if (!lToolStripMenuItem.Checked) return;

            foreach (var lItem in this.mToolStripMenuItemLineMarker
                .DropDownItems.OfType<ToolStripMenuItem>().Where(x => x.CheckOnClick))
            {
                if (lItem == lToolStripMenuItem) continue;
                lItem.Checked = false;
            }

            var lValue = (int) lToolStripMenuItem.Tag;
            this.mStitchPatternControl.ThickLineFrequency = lValue;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var lGridSize = GridRenderer.MeasureGrid(
                e.Graphics, this.ActivePattern.Grid, 
                this.mStitchPatternControl.CellsPerInch);

            GridRenderer.DrawGrid(
                e.Graphics, this.ActivePattern.Grid,
                new Rectangle(Point.Empty, lGridSize),
                this.mStitchPatternControl.ThickLineFrequency);

            e.HasMorePages = false;
        }

        #endregion

        private void ToolStripMenuItemExportPng_Click(object sender, EventArgs e)
        {
            using (var lMeasurementGraphics = this.mMarkerSelectionControl.CreateGraphics())
            {
                var lGridSize = GridRenderer.MeasureGrid(
                    lMeasurementGraphics, this.ActivePattern.Grid,
                    this.mStitchPatternControl.CellsPerInch);

                using (var lBitmap = new Bitmap(lGridSize.Width, lGridSize.Height, lMeasurementGraphics))
                using (var lBitmapGraphics = Graphics.FromImage(lBitmap))
                {
                    GridRenderer.DrawGrid(
                        lBitmapGraphics, this.mStitchPatternControl.Grid,
                        new Rectangle(Point.Empty, lGridSize), this.mStitchPatternControl.ThickLineFrequency);

                    lBitmap.Save(@"C:\Temp\output.png", ImageFormat.Png);
                }
            }
        }
    }
}
