using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrossStitchPatternMaker.WinForms
{
    internal sealed class StitchPatternControl : Control
    {
        #region Instance Fields --------------------------------------------------------

        private CrossStitchGrid mGrid;

        private readonly StringFormat mStringFormatMiddleCenter = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };

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

        public CrossStitchPattern ActivePattern { get; set; }

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
                    this.ClientRectangle, this.mStringFormatMiddleCenter);
            }
            else
            {
                this.DrawGrid(e);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        private void DrawGrid(PaintEventArgs e)
        {
            var lCellWidthF = (float) (this.ClientRectangle.Width)/this.Grid.Width;
            var lCellHeightF = (float) (this.ClientRectangle.Height)/this.Grid.Height;

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

                    lCurrentY += lCellHeightF;
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

                    lCurrentX += lCellWidthF;
                    e.Graphics.DrawLine(lPen, lCurrentX, this.ClientRectangle.Top, lCurrentX, this.ClientRectangle.Bottom);
                }
            }
        }

        #endregion
    }
}
