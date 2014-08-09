using System;
using System.IO;
using System.Windows.Forms;

namespace CrossStitchPatternMaker.WinForms
{
    public partial class MainForm : Form
    {
        #region Instance Fields --------------------------------------------------------

        private CrossStitchPattern mActivePattern;

        #endregion

        #region Constructors -----------------------------------------------------------

        public MainForm()
        {
            InitializeComponent();

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

        #endregion

        #region Instance Methods -------------------------------------------------------

        private void ToolStripMenuItemFileNew_Click(object sender, System.EventArgs e)
        {
            this.ActivePattern = new CrossStitchPattern();
        }

        private void MarkerSelectionControl_SelectedMarkerChanged(object sender, EventArgs e)
        {
            this.mStitchPatternControl.ActiveMarker = this.mMarkerSelectionControl.SelectedMarker;
        }

        #endregion
    }
}
