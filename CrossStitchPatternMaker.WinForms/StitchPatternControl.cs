using System;
using System.Drawing;
using System.Windows.Forms;

namespace CrossStitchPatternMaker.WinForms
{
    internal sealed class StitchPatternControl : Control
    {
        #region Instance Fields --------------------------------------------------------

        private CrossStitchGrid mGrid;

        private float mCellSizeF;

        #endregion

        #region Constructors -----------------------------------------------------------

        public StitchPatternControl()
        {
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);
        }

        #endregion

        #region Instance Properties ----------------------------------------------------

        public StitchMarker ActiveMarker { get; set; }

        public CrossStitchGrid Grid
        {
            get { return this.mGrid; }
            set
            {
                this.mGrid = value;
                this.Invalidate();
            }
        }

        #endregion

        #region Instance Methods -------------------------------------------------------

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Grid == null)
            {
                e.Graphics.DrawString(
                    "Load or Create a new pattern to begin",
                    this.Font, SystemBrushes.ControlText,
                    this.ClientRectangle, StringFormats.MiddleCenter);
            }
            else
            {
                e.Graphics.Clear(Color.White);

                this.mCellSizeF = Math.Min(
                    (float) (this.ClientRectangle.Width)/this.Grid.Width,
                    (float) (this.ClientRectangle.Height)/this.Grid.Height);

                this.DrawMarkers(e.Graphics, this.ClientRectangle, this.mCellSizeF);
                this.DrawGrid(e.Graphics, this.ClientRectangle, this.mCellSizeF);
            }
        }

        private void DrawMarkers(Graphics g, Rectangle bounds, float cellSizeF)
        {
            var lCurrentPosition = new PointF(bounds.Left, bounds.Top);
            for (int lRowIndex = 0; lRowIndex < this.Grid.Height; lRowIndex++)
            {
                lCurrentPosition.X = bounds.Left;

                for (int lColumnIndex = 0; lColumnIndex < this.Grid.Width; lColumnIndex++)
                {
                    var lCell = this.Grid[lRowIndex, lColumnIndex];
                    if ((lCell != null) && (lCell.Marker != null) && (lCell.Marker.Image != null))
                    {
                        g.DrawImage(
                           lCell.Marker.Image,
                           lCurrentPosition.X, lCurrentPosition.Y,
                           cellSizeF, cellSizeF);
                    }

                    lCurrentPosition.X += cellSizeF;
                }

                lCurrentPosition.Y += cellSizeF;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            const float lcZeroValueThreshold = 0.001f;
            if ((Math.Abs(this.mCellSizeF) < lcZeroValueThreshold) ||
                (Math.Abs(this.mCellSizeF) < lcZeroValueThreshold))
            {
                return;
            }

            var lIndexX = (int)((e.X - this.ClientRectangle.Left) / this.mCellSizeF);
            var lIndexY = (int)((e.Y - this.ClientRectangle.Top) / this.mCellSizeF);

            this.Grid[lIndexY, lIndexX].Marker = this.ActiveMarker;
            this.Invalidate();
        }

        private void DrawGrid(Graphics g, Rectangle bounds, float cellSizeF)
        {
            const int lcThickLineFrequency = 5;

            using (var lThickPen = new Pen(Color.Black, 2.0f))
            using (var lThinPen = new Pen(Color.Black, 1.0f))
            {
                var lThickLineCounter = 0;
                float lCurrentY = bounds.Top;

                var lGridWidthF = this.Grid.Width*cellSizeF;
                var lGridHeightF = this.Grid.Height*cellSizeF;

                g.DrawLine(lThickPen, bounds.Left, lCurrentY, bounds.Left + lGridWidthF, lCurrentY);
                for (int lRowIndex = 0; lRowIndex < this.Grid.Height; lRowIndex++)
                {
                    var lPen = lThinPen;
                    if (++lThickLineCounter == lcThickLineFrequency)
                    {
                        lPen = lThickPen;
                        lThickLineCounter = 0;
                    }

                    lCurrentY += cellSizeF;
                    g.DrawLine(lPen, bounds.Left, lCurrentY, bounds.Left + lGridWidthF, lCurrentY);
                }

                lThickLineCounter = 0;
                float lCurrentX = bounds.Left;

                g.DrawLine(lThickPen, lCurrentX, bounds.Top, lCurrentX, bounds.Top + lGridHeightF);
                for (int lColumnIndex = 0; lColumnIndex < this.Grid.Width; lColumnIndex++)
                {
                    var lPen = lThinPen;
                    if (++lThickLineCounter == lcThickLineFrequency)
                    {
                        lPen = lThickPen;
                        lThickLineCounter = 0;
                    }

                    lCurrentX += cellSizeF;
                    g.DrawLine(lPen, lCurrentX, bounds.Top, lCurrentX, bounds.Top + lGridHeightF);
                }
            }
        }

        internal void DrawGrid(Graphics g, Rectangle bounds)
        {
            var lCellSizeF = Math.Min(
                (float) (bounds.Width)/this.Grid.Width,
                (float) (bounds.Height)/this.Grid.Height);

            this.DrawMarkers(g, bounds, lCellSizeF);
            this.DrawGrid(g, bounds, lCellSizeF);
        }

        #endregion
    }
}
