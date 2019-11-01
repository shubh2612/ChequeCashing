using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ChequeCashing.Helper
{
    public class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string StreamToBase64(Stream stream)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }
            return Convert.ToBase64String(bytes);
        }
    }
}
