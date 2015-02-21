using System;
using System.Drawing;
using System.Windows.Forms;

namespace CrossStitchPatternMaker.WinForms
{
    internal sealed class StitchPatternControl : ScrollableControl
    {
        #region Instance Fields --------------------------------------------------------

        private CrossStitchGrid mGrid;

        private SizeF mCellSizeF;
        private float mCellsPerInch;
        private int mThickLineFrequency;

        #endregion

        #region Constructors -----------------------------------------------------------

        public StitchPatternControl()
        {
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);

            this.mCellsPerInch = 10.0f;
            this.Padding = new Padding(1);
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

        public float CellsPerInch
        {
            get { return this.mCellsPerInch; }
            set
            {
                this.mCellsPerInch = value;
                this.Invalidate();
            }
        }

        public int ThickLineFrequency
        {
            get { return this.mThickLineFrequency; }
            set
            {
                this.mThickLineFrequency = value;
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

                this.mCellSizeF = new SizeF(e.Graphics.DpiX/this.CellsPerInch, e.Graphics.DpiY/this.CellsPerInch);

                var lGridBoundsF = new RectangleF(
                    this.Padding.Left, this.Padding.Top,
                    (this.mCellSizeF.Width*this.Grid.Width) + this.Padding.Left + this.Padding.Right,
                    (this.mCellSizeF.Height * this.Grid.Height) + this.Padding.Top + this.Padding.Bottom);
                var lGridBounds = Rectangle.Truncate(lGridBoundsF);
                this.AutoScrollMinSize = lGridBounds.Size;

                e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);

                this.DrawMarkers(e.Graphics, lGridBounds, this.mCellSizeF);
                this.DrawGrid(e.Graphics, lGridBounds, this.mCellSizeF);
                this.DrawCenterArrowMarkers(e.Graphics, lGridBounds, this.mCellSizeF);
            }
        }

        private void DrawMarkers(Graphics g, Rectangle bounds, SizeF cellSizeF)
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
                           cellSizeF.Width, cellSizeF.Height);
                    }

                    lCurrentPosition.X += cellSizeF.Width;
                }

                lCurrentPosition.Y += cellSizeF.Height;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.PlaceMarker(e.X, e.Y);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.PlaceMarker(e.X, e.Y);
            }
        }

        private void PlaceMarker(int x, int y)
        {
            const float lcZeroValueThreshold = 0.001f;
            if ((Math.Abs(this.mCellSizeF.Width) < lcZeroValueThreshold) ||
                (Math.Abs(this.mCellSizeF.Height) < lcZeroValueThreshold))
            {
                return;
            }

            var lNormalizedPositionX = x - this.AutoScrollPosition.X;
            var lNormalizedPositionY = y - this.AutoScrollPosition.Y;

            var lIndexX = (int)((lNormalizedPositionX - this.ClientRectangle.Left) / this.mCellSizeF.Width);
            var lIndexY = (int)((lNormalizedPositionY - this.ClientRectangle.Top) / this.mCellSizeF.Height);

            if ((lIndexX < 0) || (lIndexX >= this.Grid.Width)) return;
            if ((lIndexY < 0) || (lIndexY >= this.Grid.Height)) return;

            var lModifierKeys = ModifierKeys;
            var lIsControlDown = ((lModifierKeys & Keys.Control) == Keys.Control);
            var lMarker = lIsControlDown ? null : this.ActiveMarker;

            var lCell = this.Grid[lIndexY, lIndexX];
            if (lCell.Marker == lMarker) return;

            lCell.Marker = lMarker;
            this.Invalidate();
        }

        private void DrawGrid(Graphics g, Rectangle bounds, SizeF cellSizeF)
        {
            using (var lThickPen = new Pen(Color.Black, 2.0f))
            using (var lThinPen = new Pen(Color.Black, 1.0f))
            {
                var lThickLineCounter = 0;
                float lCurrentY = bounds.Top;

                var lGridWidthF = this.Grid.Width*cellSizeF.Width;
                var lGridHeightF = this.Grid.Height*cellSizeF.Height;

                g.DrawLine(lThickPen, bounds.Left, lCurrentY, bounds.Left + lGridWidthF, lCurrentY);
                for (int lRowIndex = 0; lRowIndex < this.Grid.Height; lRowIndex++)
                {
                    var lPen = lThinPen;
                    if (++lThickLineCounter == this.ThickLineFrequency)
                    {
                        lPen = lThickPen;
                        lThickLineCounter = 0;
                    }

                    lCurrentY += cellSizeF.Height;
                    g.DrawLine(lPen, bounds.Left, lCurrentY, bounds.Left + lGridWidthF, lCurrentY);
                }

                lThickLineCounter = 0;
                float lCurrentX = bounds.Left;

                g.DrawLine(lThickPen, lCurrentX, bounds.Top, lCurrentX, bounds.Top + lGridHeightF);
                for (int lColumnIndex = 0; lColumnIndex < this.Grid.Width; lColumnIndex++)
                {
                    var lPen = lThinPen;
                    if (++lThickLineCounter == this.ThickLineFrequency)
                    {
                        lPen = lThickPen;
                        lThickLineCounter = 0;
                    }

                    lCurrentX += cellSizeF.Width;
                    g.DrawLine(lPen, lCurrentX, bounds.Top, lCurrentX, bounds.Top + lGridHeightF);
                }
            }
        }

        private void DrawCenterArrowMarkers(Graphics g, Rectangle bounds, SizeF cellSizeF)
        {
            var lMiddleRowIndex = this.Grid.Height/2;
            var lMiddleColumnIndex = this.Grid.Width/2;
            var lMiddlePositionY = bounds.Y + (cellSizeF.Height*lMiddleRowIndex);
            var lMiddlePositionX = bounds.X + (cellSizeF.Width * lMiddleColumnIndex);
            var lArrowSizeF = new SizeF(cellSizeF.Width*0.75f, cellSizeF.Height*0.75f);
            var lArrowOffsetF = new SizeF(cellSizeF.Width*0.4f, cellSizeF.Height*0.4f);
            
            using (var lArrowPen = new Pen(Color.Black, 3.0f))
            {
                g.DrawLine(lArrowPen, bounds.X, lMiddlePositionY, bounds.X + lArrowSizeF.Width, lMiddlePositionY);
                g.DrawLine(
                    lArrowPen,
                    bounds.X + lArrowSizeF.Width - lArrowOffsetF.Width, lMiddlePositionY - lArrowOffsetF.Height,
                    bounds.X + lArrowSizeF.Width, lMiddlePositionY);
                g.DrawLine(
                    lArrowPen,
                    bounds.X + lArrowSizeF.Width - lArrowOffsetF.Width, lMiddlePositionY + lArrowOffsetF.Height,
                    bounds.X + lArrowSizeF.Width, lMiddlePositionY);

                g.DrawLine(lArrowPen, lMiddlePositionX, bounds.Y, lMiddlePositionX, bounds.Y + lArrowSizeF.Height);
                g.DrawLine(
                    lArrowPen,
                    lMiddlePositionX - lArrowOffsetF.Width, bounds.Y + lArrowSizeF.Width - lArrowOffsetF.Width,
                    lMiddlePositionX, bounds.Y + lArrowSizeF.Height);
                g.DrawLine(
                    lArrowPen,
                    lMiddlePositionX + lArrowOffsetF.Width, bounds.Y + lArrowSizeF.Width - lArrowOffsetF.Width,
                    lMiddlePositionX, bounds.Y + lArrowSizeF.Height);
            }
        }

        internal void DrawGrid(Graphics g, Rectangle bounds)
        {
            var lCellSizeF = new SizeF(g.DpiX*this.CellsPerInch, g.DpiY*this.CellsPerInch);
            this.DrawMarkers(g, bounds, lCellSizeF);
            this.DrawGrid(g, bounds, lCellSizeF);
            this.DrawCenterArrowMarkers(g, bounds, lCellSizeF);
        }

        #endregion
    }
}
