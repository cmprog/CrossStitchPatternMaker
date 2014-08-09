using System.Drawing;

namespace CrossStitchPatternMaker.WinForms
{
    internal static class StringFormats
    {
        private static readonly StringFormat sMiddleCenter = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

        private static readonly StringFormat sLeftCenter = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };

        public static StringFormat MiddleCenter
        {
            get { return sMiddleCenter; }
        }

        public static StringFormat LeftCenter
        {
            get { return sLeftCenter; }
        }
    }
}
