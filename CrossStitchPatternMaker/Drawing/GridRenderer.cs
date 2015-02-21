using System.Drawing;

namespace CrossStitchPatternMaker.Drawing
{
    public static class GridRenderer
    {
        public static Size MeasureGrid(Graphics g, CrossStitchGrid grid, float cellsPerInch)
        {
            var lCellSizeF = new SizeF(g.DpiX / cellsPerInch, g.DpiY / cellsPerInch);
            var lGridSizeF = new SizeF(lCellSizeF.Width * grid.Width, lCellSizeF.Height * grid.Height);
            return Size.Truncate(lGridSizeF);
        }

        /// <summary>
        /// Draws to the given Graphics a CrossStitchGrid with the given cellsPerInch.
        /// </summary>
        /// <returns>The size of the grid.</returns>
        public static void DrawGrid(Graphics g, CrossStitchGrid grid, Rectangle bounds, int thickLineFrequency = 10)
        {
            var lSavedState = g.Save();

            var lCellSizeF = new SizeF((float) bounds.Width/grid.Width, (float) bounds.Height/grid.Height);

            g.FillRectangle(Brushes.White, bounds);
            DrawMarkers(g, grid, bounds, lCellSizeF);
            DrawGrid(g, grid, bounds, lCellSizeF, thickLineFrequency);
            DrawCenterArrowMarkers(g, grid, bounds, lCellSizeF);

            g.Restore(lSavedState);
        }

        private static void DrawGrid(Graphics g, CrossStitchGrid grid, Rectangle bounds, SizeF cellSizeF, int thickLineFrequency)
        {
            using (var lThickPen = new Pen(Color.Black, 2.0f))
            using (var lThinPen = new Pen(Color.Black, 1.0f))
            {
                var lThickLineCounter = 0;
                float lCurrentY = bounds.Top;

                var lGridWidthF = grid.Width * cellSizeF.Width;
                var lGridHeightF = grid.Height * cellSizeF.Height;

                g.DrawLine(lThickPen, bounds.Left, lCurrentY, bounds.Left + lGridWidthF, lCurrentY);
                for (int lRowIndex = 0; lRowIndex < grid.Height; lRowIndex++)
                {
                    var lPen = lThinPen;
                    if (++lThickLineCounter == thickLineFrequency)
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
                for (int lColumnIndex = 0; lColumnIndex < grid.Width; lColumnIndex++)
                {
                    var lPen = lThinPen;
                    if (++lThickLineCounter == thickLineFrequency)
                    {
                        lPen = lThickPen;
                        lThickLineCounter = 0;
                    }

                    lCurrentX += cellSizeF.Width;
                    g.DrawLine(lPen, lCurrentX, bounds.Top, lCurrentX, bounds.Top + lGridHeightF);
                }
            }
        }

        private static void DrawCenterArrowMarkers(Graphics g, CrossStitchGrid grid, Rectangle bounds, SizeF cellSizeF)
        {
            var lMiddleRowIndex = grid.Height / 2;
            var lMiddleColumnIndex = grid.Width / 2;
            var lMiddlePositionY = bounds.Y + (cellSizeF.Height * lMiddleRowIndex);
            var lMiddlePositionX = bounds.X + (cellSizeF.Width * lMiddleColumnIndex);
            var lArrowSizeF = new SizeF(cellSizeF.Width * 0.75f, cellSizeF.Height * 0.75f);
            var lArrowOffsetF = new SizeF(cellSizeF.Width * 0.4f, cellSizeF.Height * 0.4f);

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

        private static void DrawMarkers(Graphics g, CrossStitchGrid grid, Rectangle bounds, SizeF cellSizeF)
        {
            var lCurrentPosition = new PointF(bounds.Left, bounds.Top);
            for (int lRowIndex = 0; lRowIndex < grid.Height; lRowIndex++)
            {
                lCurrentPosition.X = bounds.Left;

                for (int lColumnIndex = 0; lColumnIndex < grid.Width; lColumnIndex++)
                {
                    var lCell = grid[lRowIndex, lColumnIndex];
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
    }
}
