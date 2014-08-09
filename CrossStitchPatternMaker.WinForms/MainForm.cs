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

        #endregion
    }
}
