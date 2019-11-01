using ChequeCashing.Model;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChequeCashing.ViewModel
{
    public class PersonDetailsViewModel : BaseViewModel
    {

        public ICommand TakePhotoTappedCommand { get; set; }

        private Person _person;

        public Person Person
        {
            get { return _person; }
            set { _person = value; }
        }

        public PersonDetailsViewModel()
        {
            TakePhotoTappedCommand = new Command(TakePhotoTapped);
        }

        private async void TakePhotoTapped(object obj)
        {
            try
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    MaxWidthHeight = 360,
                    CompressionQuality = 30,
                    PhotoSize = PhotoSize.Small,
                    AllowCropping = true,
                    Directory = "ChequeCashing",
                    SaveToAlbum = false,
                    ModalPresentationStyle = MediaPickerModalPresentationStyle.OverFullScreen
                });
                if (file != null)
                {
                    Person.ImageUrl = Helper.Settings.StreamToBase64(file.GetStreamWithImageRotatedForExternalStorage());
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
