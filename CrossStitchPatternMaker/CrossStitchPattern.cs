using System;

namespace CrossStitchPatternMaker
{
    public sealed class CrossStitchPattern
    {
        #region Instance Fields --------------------------------------------------------

        private readonly CrossStitchGrid mGrid;

        #endregion

        #region Constructors -----------------------------------------------------------

        public CrossStitchPattern()
        {
            this.mGrid = new CrossStitchGrid(25, 25);
        }

        #endregion

        #region Instance Properties ----------------------------------------------------

        public DateTime CreateOnUtc { get; set; }
        public DateTime ModifiedOnUtc { get; set; }

        public CrossStitchGrid Grid
        {
            get { return this.mGrid; }
        }

        #endregion

        #region Instance Methods -------------------------------------------------------

        #endregion
    }
}
