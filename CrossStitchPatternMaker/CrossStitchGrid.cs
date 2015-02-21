using System.Collections.Generic;

namespace CrossStitchPatternMaker
{
    public sealed class CrossStitchGrid
    {
        #region Instance Fields --------------------------------------------------------

        private readonly List<List<CrossStitchCell>> mCellRows = new List<List<CrossStitchCell>>();
        private int mHeight;
        private int mWidth;

        #endregion

        #region Constructors -----------------------------------------------------------

        public CrossStitchGrid(int height, int width)
        {
            this.Width = width;
            this.Height = height;
        }

        #endregion

        #region Instance Properties ----------------------------------------------------

        public int Height
        {
            get { return this.mHeight; }
            set
            {
                if (this.mHeight == value) return;
                this.mHeight = value;

                while (this.mCellRows.Count < this.Height)
                {
                    var lCellRow = new List<CrossStitchCell>();
                    for (int lWidthIndex = 0; lWidthIndex < this.Width; lWidthIndex++)
                    {
                        lCellRow.Add(new CrossStitchCell());
                    }
                    this.mCellRows.Add(lCellRow);
                }
                while (this.mCellRows.Count > this.Height) this.mCellRows.RemoveAt(this.mCellRows.Count - 1);
            }
        }

        public int Width
        {
            get { return this.mWidth; }
            set
            {
                if (this.mWidth == value) return;
                this.mWidth = value;

                foreach (var lCellRow in this.mCellRows)
                {
                    while (lCellRow.Count < this.Width) lCellRow.Add(new CrossStitchCell());
                    while (lCellRow.Count > this.Width) lCellRow.RemoveAt(lCellRow.Count - 1);
                }
            }
        }

        public CrossStitchCell this[int rowIndex, int columnIndex]
        {
            get { return this.mCellRows[rowIndex][columnIndex]; }
        }

        #endregion

        #region Instance Methods -------------------------------------------------------

        #endregion

        public void Clear()
        {
            for (int lRowIndex = 0; lRowIndex < this.Height; lRowIndex++)
            {
                for (int lColumnIndex = 0; lColumnIndex < this.Width; lColumnIndex++)
                {
                    this[lRowIndex, lColumnIndex].Marker = null;
                }
            }
        }

        public bool WillSizeChangeResultInDataLoss(int suggestedWidth, int suggestedHeight)
        {
            if (suggestedWidth < this.Width)
            {
                for (int lRowIndex = 0; lRowIndex < this.Height; lRowIndex++)
                {
                    for (int lColumnIndex = suggestedWidth; lColumnIndex < this.Width; lColumnIndex++)
                    {
                        if (this[lRowIndex, lColumnIndex].Marker != null) return true;
                    }
                }
            }

            if (suggestedHeight < this.Height)
            {
                for (int lRowIndex = suggestedHeight; lRowIndex < this.Height; lRowIndex++)
                {
                    for (int lColumnIndex = 0; lColumnIndex < this.Width; lColumnIndex++)
                    {
                        if (this[lRowIndex, lColumnIndex].Marker != null) return true;
                    }
                }
            }

            return false;
        }
    }
}
