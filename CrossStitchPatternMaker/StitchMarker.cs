using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CrossStitchPatternMaker
{
    public sealed class StitchMarker : IDisposable
    {
        private readonly Guid mId;

        private string mName;
        private Image mImage;

        public DateTime CreatedOnUtc { get; internal set; }
        public DateTime ModifiedOnUtc { get; internal set; }

        private readonly static Bitmap sWhitePixel;

        static StitchMarker()
        {
            sWhitePixel = new Bitmap(1, 1);
            sWhitePixel.SetPixel(0, 0, Color.White);
        }

        public StitchMarker()
            : this(sWhitePixel)
        {
            
        }

        public StitchMarker(Image image)
            : this(Guid.NewGuid(), image)
        {
        }

        internal StitchMarker(Guid id, Image image)
        {
            this.mId = id;
            this.mName = string.Empty;
            this.mImage = image;

            var lCurrentDateTimeUtc = DateTime.UtcNow;
            this.CreatedOnUtc = lCurrentDateTimeUtc;
            this.ModifiedOnUtc = lCurrentDateTimeUtc;
        }

        public Guid Id
        {
            get { return this.mId; }
        } 

        public string Name
        {
            get { return this.mName; }
            set
            {
                if (string.Equals(this.mName, value, StringComparison.Ordinal)) return;
                this.mName = value;
                this.ModifiedOnUtc = DateTime.UtcNow;
            }
        }

        public Image Image
        {
            get { return this.mImage; }
            set
            {
                if (ReferenceEquals(this.mImage, value)) return;

                if (this.mImage != null)
                {
                    this.mImage.Dispose();
                }

                this.mImage = value;
                this.ModifiedOnUtc = DateTime.UtcNow;
            }
        }

        public void Dispose()
        {
            if (this.mImage != null)
            {
                this.mImage.Dispose();
            }
        }

        internal void SaveToDirectory(string directoryPath)
        {
            var lPatternImageFilePath = Path.Combine(directoryPath, "image.png");
            this.Image.Save(lPatternImageFilePath, ImageFormat.Png);

            var lMetaDataFilePath = Path.Combine(directoryPath, "meta.smpat");
            using (var lFileStream = new FileStream(lMetaDataFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            using (var lStreamWriter = new StreamWriter(lFileStream))
            {
                lStreamWriter.WriteLine(this.mName);
                lStreamWriter.WriteLine(this.CreatedOnUtc.Ticks);
                lStreamWriter.WriteLine(this.ModifiedOnUtc.Ticks);
            }
        }

        internal static StitchMarker FromDirectory(Guid id, string directoryPath)
        {
            var lPatternImageFilePath = Path.Combine(directoryPath, "image.png");
            var lMetaDataFilePath = Path.Combine(directoryPath, "meta.smpat");

            var lMarker = new StitchMarker(id, Image.FromFile(lPatternImageFilePath));

            using (var lFileStream = new FileStream(lMetaDataFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var lStreamReader = new StreamReader(lFileStream, System.Text.Encoding.UTF8))
            {
                lMarker.mName = lStreamReader.ReadLine();
                lMarker.CreatedOnUtc = new DateTime(long.Parse(lStreamReader.ReadLine()));
                lMarker.ModifiedOnUtc = new DateTime(long.Parse(lStreamReader.ReadLine()));
            }

            return lMarker;
        }
    }
}
