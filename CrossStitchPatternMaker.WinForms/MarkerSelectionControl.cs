using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CrossStitchPatternMaker.WinForms
{
    public partial class MarkerSelectionControl : UserControl
    {
        #region Instance Fields --------------------------------------------------------

        private StitchMarkerRepository mRepository;

        #endregion

        #region Constructors -----------------------------------------------------------

        public MarkerSelectionControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Events -----------------------------------------------------------------

        public event EventHandler SelectedMarkerChanged;

        #endregion

        #region Instance Properties ----------------------------------------------------

        public StitchMarker SelectedMarker
        {
            get { return (StitchMarker) this.mListBoxMarkers.SelectedItem; }
            set { this.mListBoxMarkers.SelectedItem = value; }
        }

        public StitchMarkerRepository Repository
        {
            get { return this.mRepository; }
            set
            {
                this.mRepository = value;
                this.RefreshAllMarkers();
            }
        }

        #endregion

        #region Instance Methods -------------------------------------------------------

        private void RefreshAllMarkers()
        {
            this.mListBoxMarkers.Items.Clear();
            var lRepository = this.Repository;
            if (lRepository == null) return;

            var lSelectedMarker = this.SelectedMarker;
            this.mListBoxMarkers.Items.AddRange(
                lRepository.EnumerateAll().Cast<object>().ToArray());
            this.SelectedMarker = lSelectedMarker;
            
            if ((this.mListBoxMarkers.SelectedIndex < 0) &&
                (this.mListBoxMarkers.Items.Count > 0))
            {
                this.mListBoxMarkers.SelectedIndex = 0;
            }
        }

        private void ListBoxMarkers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if ((e.Index < 0) || (e.Index >= this.mListBoxMarkers.Items.Count)) return;
            var lMarker = (StitchMarker) this.mListBoxMarkers.Items[e.Index];

            var lIsSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            var lBackColor = lIsSelected ? SystemColors.Highlight : SystemColors.Window;
            var lForeColor = lIsSelected ? SystemColors.HighlightText : SystemColors.WindowText;

            using (var lForeBrush = new SolidBrush(lForeColor))
            using (var lBackBrush = new SolidBrush(lBackColor))
            using (var lBorderPen = new Pen(Color.Black, 2.0f))
            {
                var lImageBounds = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height);
                var lTextBounds = new Rectangle(lImageBounds.Right, lImageBounds.Y, e.Bounds.Right - lImageBounds.Right, lImageBounds.Height);

                e.Graphics.FillRectangle(SystemBrushes.Window, lImageBounds);
                e.Graphics.FillRectangle(lBackBrush, lTextBounds);
             
                lImageBounds.Inflate(-2, -2);
                e.Graphics.DrawImage(
                    lMarker.Image, 
                    lImageBounds.X, lImageBounds.Y, 
                    lImageBounds.Width, lImageBounds.Height);
                e.Graphics.DrawRectangle(lBorderPen, lImageBounds);

                e.Graphics.DrawString(lMarker.Name, e.Font, lForeBrush, lTextBounds, StringFormats.LeftCenter);
            }
        }

        private void ListBoxMarkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lSelectedMarkerChanged = this.SelectedMarkerChanged;
            if (lSelectedMarkerChanged != null) lSelectedMarkerChanged(this, EventArgs.Empty);
        }

        #endregion
    }
}
