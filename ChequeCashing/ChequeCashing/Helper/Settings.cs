using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;

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

        public static ImageSource GetImageSourceFromURL(string imageUrl, string defaultImage = "Camera.png")
        {
            if (!string.IsNullOrWhiteSpace(imageUrl) && (imageUrl.Contains(".jpg") || imageUrl.Contains(".JPG") || imageUrl.Contains(".jpeg") || imageUrl.Contains(".JPEG")))
            {
                try
                {
                    var base64String = GetImageUrltoBase64String(imageUrl);
                    var imageSource = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(base64String)));
                    return imageSource;
                }
                catch (Exception e)
                {
                    return defaultImage;
                }
            }
            return string.IsNullOrWhiteSpace(imageUrl) ? defaultImage : ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(imageUrl)));
        }

        private static string GetImageUrltoBase64String(string photoURL)
        {
            var request = System.Net.WebRequest.Create(photoURL);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            var base64String = StreamToBase64(responseStream);
            return base64String;
        }
    }
}
