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
            {
                e.Graphics.FillRectangle(lBackBrush, e.Bounds);
                e.Graphics.DrawString(lMarker.Name, e.Font, lForeBrush, e.Bounds, StringFormats.MiddleCenter);
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
