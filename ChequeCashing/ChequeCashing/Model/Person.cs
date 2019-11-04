using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace ChequeCashing.Model
{
    [Table("Person")]
    public class Person : BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string IdentityProof { get; set; }

        private string _imageUrl;
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
                OnPropertyChanged(nameof(ImageUrl));
                OnPropertyChanged(nameof(PhotoImageSource));
            }
        }

        [JsonIgnore]
        [IgnoreProperty]
        public ImageSource PhotoImageSource
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ImageUrl) && (ImageUrl.Contains(".jpg") || ImageUrl.Contains(".JPG") || ImageUrl.Contains(".jpeg") || ImageUrl.Contains(".JPEG")))
                {
                    try
                    {
                        var base64String = GetImageUrltoBase64String(ImageUrl);
                        var imageSource = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(base64String)));
                        return imageSource;
                    }
                    catch (Exception e)
                    {
                        return "userHighlighted.png";
                    }
                }
                return string.IsNullOrWhiteSpace(ImageUrl) ? "userHighlighted.png" : ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(ImageUrl)));
            }
        }

        private string GetImageUrltoBase64String(string photoURL)
        {
            var request = System.Net.WebRequest.Create(photoURL);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            var base64String = StreamToBase64(responseStream);
            return base64String;
        }

        public string StreamToBase64(Stream stream)
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
