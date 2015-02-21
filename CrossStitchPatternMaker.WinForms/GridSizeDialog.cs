using System.Linq;
using System.Windows.Forms;

namespace CrossStitchPatternMaker.WinForms
{
    public partial class GridSizeDialog : Form
    {
        #region Instance Fields --------------------------------------------------------

        #endregion

        #region Constructors -----------------------------------------------------------

        public GridSizeDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Instance Properties ----------------------------------------------------

        public int GridWidth
        {
            get
            {
                int lValue;
                int.TryParse(this.mTextBoxWidth.Text, out lValue);
                return lValue;
            }
            set { this.mTextBoxWidth.Text = value.ToString(); }
        }

        public int GridHeight
        {
            get
            {
                int lValue;
                int.TryParse(this.mTextBoxHeight.Text, out lValue);
                return lValue;
            }
            set { this.mTextBoxHeight.Text = value.ToString(); }
        }

        #endregion

        #region Instance Methods -------------------------------------------------------

        private void LinkLabelCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TextBoxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Delete:
                    e.SuppressKeyPress = false;
                    return;
            }

            char lCurrentKey = (char) e.KeyCode;
            bool lHasModifier = e.Control || e.Alt || e.Shift;
            var lIsNonNumber =
                char.IsLetter(lCurrentKey) ||
                    char.IsSymbol(lCurrentKey) ||
                    char.IsWhiteSpace(lCurrentKey) ||
                    char.IsPunctuation(lCurrentKey);

            if (!lHasModifier && lIsNonNumber)
            {
                e.SuppressKeyPress = true;
            }

            if (e.Control && (e.KeyCode == Keys.V))
            {
                var lPasteText = Clipboard.GetText();
                if (lPasteText.Any(x => !char.IsNumber(x)))
                {
                    e.SuppressKeyPress = true;
                }
            }
        }

        #endregion
    }
}
