using ChequeCashing.Helper;
using ChequeCashing.Model;
using ChequeCashing.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChequeCashing.ViewModel
{
    public class PersonDetailsViewModel : BaseViewModel
    {
        public ICommand SubmitCommand { get; set; }
        public ICommand TakePhotoTappedCommand { get; set; }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { _selectedDate = value; OnPropertyChanged(nameof(SelectedDate)); }
        }

        private Person _person;
        public Person Person
        {
            get { return _person; }
            set { _person = value; }
        }

        public PersonDetailsViewModel()
        {
            Person = new Person();
            TakePhotoTappedCommand = new Command(TakePhotoTapped);
            SubmitCommand = new Command(SubmitButtonTapped);
        }

        private async void SubmitButtonTapped(object obj)
        {
            Person.DOB = SelectedDate;
            await SaveContent();
        }

        private async Task SaveContent()
        {
            var _personRepository = new PersonRepository();
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Verify Person Deatils", "Do you want to continue?", "OK", "Cancel");
            if (isUserAccept)
            {
                _personRepository.InsertData(Person);
                var page = FindPageByType(typeof(Dashboard));
                var vm = (DashboardViewModel)page.BindingContext;
                //vm.Item.Insert(0, saveContent);
                await App.navigationPage.PopAsync();
            }
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
