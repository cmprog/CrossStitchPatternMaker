using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace CrossStitchPatternMaker
{
    public sealed class StitchMarkerRepository : IDisposable
    {
        private readonly string mBaseDirectoryPath;
        private readonly Dictionary<Guid, StitchMarker> mCachedStitchMarkers = new Dictionary<Guid, StitchMarker>();

        public StitchMarkerRepository(string baseDirectoryPath)
        {
            if (string.IsNullOrWhiteSpace(baseDirectoryPath)) throw new ArgumentNullException("baseDirectoryPath");
            this.mBaseDirectoryPath = baseDirectoryPath;
        }

        public StitchMarker Get(Guid id)
        {
            StitchMarker lMarker;
            if (!this.mCachedStitchMarkers.TryGetValue(id, out lMarker))
            {
                lMarker = this.Load(id);
            }
            return lMarker;
        }

        private StitchMarker Load(Guid id)
        {
            var lPatternDirectory = Path.Combine(this.mBaseDirectoryPath, id.ToString());
            return StitchMarker.FromDirectory(id, lPatternDirectory);
        }

        public void Save(StitchMarker marker)
        {
            if (marker == null) throw new ArgumentNullException("marker");
            this.mCachedStitchMarkers[marker.Id] = marker;
            var lPatternDirectory = Path.Combine(this.mBaseDirectoryPath, marker.Id.ToString());
            marker.SaveToDirectory(lPatternDirectory);
        }

        public void Dispose()
        {
            foreach (var lMarker in this.mCachedStitchMarkers.Values)
            {
                lMarker.Dispose();
            }
        }
    }
}
