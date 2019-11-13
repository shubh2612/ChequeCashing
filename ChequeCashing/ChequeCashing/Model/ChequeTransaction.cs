using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using SQLite;
using System;
using Xamarin.Forms;

namespace ChequeCashing.Model
{
    [Table("ChequeTransaction")]
    public class ChequeTransaction : BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ChequeNumber { get; set; }
        public string Status { get; set; }
        public string From { get; set; }
        public string ToPersonName { get; set; }
        public string Amount { get; set; }
        public string GivenAmount { get; set; }
        public string To { get; set; } 
        public string RemainingAmount { get; set; }
        public DateTime DateOnCheque { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public string Company { get; set; }
        public string Type { get; set; }




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
        public string PhotoURLString
        {
            get { return string.IsNullOrWhiteSpace(ImageUrl) ? "userHighlighted.png" : ImageUrl; }
        }

        [JsonIgnore]
        [IgnoreProperty]
        public ImageSource PhotoImageSource
        {
            get
            {
                return Helper.Settings.GetImageSourceFromURL(ImageUrl, "Camera.png");
            }
        }



        private string _chequeImageUrl;
        public string ChequeImageUrl
        {
            get => _chequeImageUrl;
            set
            {
                _chequeImageUrl = value;
                OnPropertyChanged(nameof(ChequeImageUrl));
                OnPropertyChanged(nameof(ChequeImageSource));
            }
        }

        [JsonIgnore]
        [IgnoreProperty]
        public string ChequeURLString
        {
            get { return string.IsNullOrWhiteSpace(ChequeImageUrl) ? "Camera.png" : ChequeImageUrl; }
        }

        [JsonIgnore]
        [IgnoreProperty]
        public ImageSource ChequeImageSource
        {
            get
            {
                return Helper.Settings.GetImageSourceFromURL(ChequeImageUrl, "Camera.png");
            }
        }
    }
}
