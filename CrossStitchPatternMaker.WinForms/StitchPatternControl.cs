using System;
using System.Drawing;
using System.Windows.Forms;

namespace CrossStitchPatternMaker.WinForms
{
    internal sealed class StitchPatternControl : Control
    {
        #region Instance Fields --------------------------------------------------------

        private CrossStitchGrid mGrid;

        private float mCellWidthF;
        private float mCellHeightF;

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
                this.mCellWidthF = (float)(this.ClientRectangle.Width) / this.Grid.Width;
                this.mCellHeightF = (float)(this.ClientRectangle.Height) / this.Grid.Height;

                this.DrawMarkers(e);
                this.DrawGrid(e);
            }
        }

        private void DrawMarkers(PaintEventArgs e)
        {
            var lClientRectangle = this.ClientRectangle;

            var lCurrentPosition = new PointF(lClientRectangle.Left, lClientRectangle.Top);
            for (int lRowIndex = 0; lRowIndex < this.Grid.Height; lRowIndex++)
            {
                lCurrentPosition.X = lClientRectangle.Left;

                for (int lColumnIndex = 0; lColumnIndex < this.Grid.Width; lColumnIndex++)
                {
                    var lCell = this.Grid[lRowIndex, lColumnIndex];
                    if ((lCell != null) && (lCell.Marker != null) && (lCell.Marker.Image != null))
                    {
                        e.Graphics.DrawImage(
                           lCell.Marker.Image,
                           lCurrentPosition.X, lCurrentPosition.Y,
                           this.mCellWidthF, this.mCellHeightF);
                    }

                    lCurrentPosition.X += this.mCellWidthF;
                }

                lCurrentPosition.Y += this.mCellHeightF;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            const float lcZeroValueThreshold = 0.001f;
            if ((Math.Abs(this.mCellWidthF) < lcZeroValueThreshold) ||
                (Math.Abs(this.mCellHeightF) < lcZeroValueThreshold))
            {
                return;
            }

            var lIndexX = (int) ((e.X - this.ClientRectangle.Left)/this.mCellWidthF);
            var lIndexY = (int) ((e.Y - this.ClientRectangle.Top)/this.mCellHeightF);

            this.Grid[lIndexY, lIndexX].Marker = this.ActiveMarker;
            this.Invalidate();
        }

        private void DrawGrid(PaintEventArgs e)
        {

            const int lcThickLineFrequency = 5;

            using (var lThickPen = new Pen(Color.Black, 2.0f))
            using (var lThinPen = new Pen(Color.Black, 1.0f))
            {
                var lThickLineCounter = 0;
                float lCurrentY = this.ClientRectangle.Top;

                e.Graphics.DrawLine(lThickPen, this.ClientRectangle.Left, lCurrentY, this.ClientRectangle.Right, lCurrentY);
                for (int lRowIndex = 0; lRowIndex < this.Grid.Height; lRowIndex++)
                {
                    var lPen = lThinPen;
                    if (++lThickLineCounter == lcThickLineFrequency)
                    {
                        lPen = lThickPen;
                        lThickLineCounter = 0;
                    }

                    lCurrentY += this.mCellHeightF;
                    e.Graphics.DrawLine(lPen, this.ClientRectangle.Left, lCurrentY, this.ClientRectangle.Right, lCurrentY);
                }

                lThickLineCounter = 0;
                float lCurrentX = this.ClientRectangle.Left;

                e.Graphics.DrawLine(lThickPen, lCurrentX, this.ClientRectangle.Top, lCurrentX, this.ClientRectangle.Bottom);
                for (int lColumnIndex = 0; lColumnIndex < this.Grid.Width; lColumnIndex++)
                {
                    var lPen = lThinPen;
                    if (++lThickLineCounter == lcThickLineFrequency)
                    {
                        lPen = lThickPen;
                        lThickLineCounter = 0;
                    }

                    lCurrentX += this.mCellWidthF;
                    e.Graphics.DrawLine(lPen, lCurrentX, this.ClientRectangle.Top, lCurrentX, this.ClientRectangle.Bottom);
                }
            }
        }

        #endregion
    }
}
