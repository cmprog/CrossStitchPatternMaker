using System;
using System.Collections.Generic;
using System.IO;

namespace CrossStitchPatternMaker
{
    public sealed class ApplicationSettings
    {
        #region Instance Fields --------------------------------------------------------

        private readonly Dictionary<string, object> mCache = new Dictionary<string, object>();

        private static readonly Lazy<ApplicationSettings> sInstance =
            new Lazy<ApplicationSettings>(() => new ApplicationSettings());

        #endregion

        #region Constructors -----------------------------------------------------------

        #endregion

        #region Instance Properties ----------------------------------------------------

        private const string sMarkerRepositoryDirectoryPathKey = "MarkerRepositoryDirectoryPath";
        public string MarkerRepositoryDirectoryPath
        {
            get { return this.Read<string>(sMarkerRepositoryDirectoryPathKey); }
            set { this.Write(sMarkerRepositoryDirectoryPathKey, value); }
        }

        #endregion

        #region Static Properties ------------------------------------------------------

        public static ApplicationSettings Instance
        {
            get { return sInstance.Value; }
        }

        private TValue Read<TValue>(string key)
        {
            object lValue;
            if (this.mCache.TryGetValue(key, out lValue))
            {
                return (TValue)lValue;
            }

            lValue = (object) default(TValue);

            var lSettingPath = this.GetSettingPath(key);
            if (File.Exists(lSettingPath))
            {
                var lSettingText = File.ReadAllText(lSettingPath);
                if (!string.IsNullOrEmpty(lSettingText))
                {
                    try
                    {
                        lValue = Convert.ChangeType(lSettingText, typeof (TValue));
                    }
                    catch
                    {
                    }
                }
            }

            this.mCache[key] = lValue;
            return (TValue) lValue;
        }

        private bool Write(string key, object value)
        {
            object lExistingValue;
            if (this.mCache.TryGetValue(key, out lExistingValue) && Equals(lExistingValue, value))
            {
                return false;
            }

            var lSettingPath = this.GetSettingPath(key);

            try
            {
                File.WriteAllText(lSettingPath, (value == null) ? string.Empty : value.ToString());
                this.mCache[key] = value;
            }
            catch
            {
            }

            return true;
        }

        private string GetSettingPath(string key)
        {
            return Path.Combine(Program.UserDataFolder, key + ".text");
        }

        #endregion

        #region Instance Methods -------------------------------------------------------

        #endregion

    }
}
