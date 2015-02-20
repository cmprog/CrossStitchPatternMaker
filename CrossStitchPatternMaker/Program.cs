using System;
using System.IO;

namespace CrossStitchPatternMaker
{
    internal static class Program
    {
        internal static readonly string ProgramSubPath = "CrossStitchPatternMaker";

        internal static string UserDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProgramSubPath);
    }
}
