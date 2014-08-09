using System;
using System.IO;

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

        public int Version { get; internal set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime ModifiedOnUtc { get; set; }

        public CrossStitchGrid Grid
        {
            get { return this.mGrid; }
        }

        #endregion

        #region Instance Methods -------------------------------------------------------
        
        public void SaveAs(string filePath)
        {
            using (var lFileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            using (var lStreamWriter = new StreamWriter(lFileStream))
            {
                var lVersionBytes = BitConverter.GetBytes(this.Version);
                lFileStream.Write(lVersionBytes, 0, lVersionBytes.Length);
                lStreamWriter.WriteLine(this.CreatedOnUtc.Ticks);
                lStreamWriter.WriteLine(this.ModifiedOnUtc.Ticks);
                lStreamWriter.WriteLine(this.Grid.Width);
                lStreamWriter.WriteLine(this.Grid.Height);
                
                for (int lRowIndex = 0; lRowIndex < this.Grid.Height; lRowIndex++)
                {
                    for (int lColumnIndex = 0; lColumnIndex < this.Grid.Width; lColumnIndex++)
                    {
                        var lCell = this.Grid[lRowIndex, lColumnIndex];
                        if ((lCell == null) || (lCell.Marker == null))
                        {
                            lStreamWriter.WriteLine();
                        }
                        else
                        {
                            lStreamWriter.WriteLine(lCell.Marker.Id);
                        }
                    }
                }
            }
        }

        public static CrossStitchPattern CreateFromFile(string filePath, StitchMarkerRepository repository)
        {
            if (filePath == null) throw new ArgumentNullException("filePath");
            if (repository == null) throw new ArgumentNullException("repository");

            using (var lFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var lStreamReader = new StreamReader(lFileStream))
            {
                var lPattern = new CrossStitchPattern();

                var lVersionBuffer = new byte[sizeof (int)];
                lFileStream.Read(lVersionBuffer, 0, lVersionBuffer.Length);
                lPattern.Version = BitConverter.ToInt32(lVersionBuffer, 0);

                lPattern.CreatedOnUtc = new DateTime(long.Parse(lStreamReader.ReadLine()));
                lPattern.ModifiedOnUtc = new DateTime(long.Parse(lStreamReader.ReadLine()));
                lPattern.Grid.Width = int.Parse(lStreamReader.ReadLine());
                lPattern.Grid.Height = int.Parse(lStreamReader.ReadLine());

                for (int lRowIndex = 0; lRowIndex < lPattern.Grid.Height; lRowIndex++)
                {
                    for (int lColumnIndex = 0; lColumnIndex < lPattern.Grid.Width; lColumnIndex++)
                    {
                        Guid lMarkerId;
                        if (Guid.TryParse(lStreamReader.ReadLine(), out lMarkerId))
                        {
                            var lMarker = repository.Get(lMarkerId);
                            lPattern.Grid[lRowIndex, lColumnIndex].Marker = lMarker;
                        }
                    }
                }

                return lPattern;
            }
        }

        #endregion

        #region Static Methods ---------------------------------------------------------

        #endregion
    }
}
