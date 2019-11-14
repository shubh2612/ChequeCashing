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
    class DashboardViewModel : BaseViewModel
    {
        public ICommand VerifyCommand { get; set; }
        public ICommand SubmitPersonDetailCommand { get; set; }
        public ICommand SubmitTransactionDetailCommand { get; set; }
        public ICommand TakePhotoTappedCommand { get; set; }
        public ICommand ChequeImageTappedCommand { get; set; }

        private DateTime? _verifyTabSelectedDate;
        public DateTime? VerifyTabSelectedDate
        {
            get { return _verifyTabSelectedDate; }
            set { _verifyTabSelectedDate = value; OnPropertyChanged(nameof(VerifyTabSelectedDate)); }
        }

        private DateTime? _personDetailSelectedDate;
        public DateTime? PersonDetailSelectedDate
        {
            get { return _personDetailSelectedDate; }
            set { _personDetailSelectedDate = value; OnPropertyChanged(nameof(PersonDetailSelectedDate)); }
        }

        private DateTime? _transactionSelectedDate;
        public DateTime? TransactionSelectedDate
        {
            get { return _transactionSelectedDate; }
            set { _transactionSelectedDate = value; OnPropertyChanged(nameof(TransactionSelectedDate)); }
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value;OnPropertyChanged(nameof(SelectedIndex)); }
        }

        private bool _verifyButton;
        public bool VerifyButton
        {
            get { return _verifyButton; }
            set { _verifyButton = value; OnPropertyChanged(nameof(VerifyButton)); }
        }

        private bool _submitPerson;
        public bool SubmitPerson
        {
            get { return _submitPerson; }
            set { _submitPerson = value; OnPropertyChanged(nameof(SubmitPerson)); }
        }

        private bool _submitTransaction;
        public bool SubmitTransaction
        {
            get { return _submitTransaction; }
            set { _submitTransaction = value; OnPropertyChanged(nameof(SubmitTransaction)); }
        }

        private bool _readOnly;
        public bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; OnPropertyChanged(nameof(ReadOnly)); }
        }

        private bool _labelVisibility;
        public bool LabelVisibility
        {
            get { return _labelVisibility; }
            set { _labelVisibility = value; OnPropertyChanged(nameof(LabelVisibility)); }
        }

        private bool _readOnlyCombobox;
        public bool ReadOnlyCombobox
        {
            get { return _readOnlyCombobox; }
            set { _readOnlyCombobox = value; OnPropertyChanged(nameof(ReadOnlyCombobox)); }
        }

        private ChequeTransaction chequeTransaction;
        public ChequeTransaction ChequeTransaction
        {
            get { return chequeTransaction; }
            set { chequeTransaction = value; OnPropertyChanged(nameof(ChequeTransaction)); }
        }
        public DashboardViewModel(ChequeTransaction item)
        {

            if (item != null)
            {
                ChequeTransaction = item;
                LabelVisibility = true;
                VerifyButton = false;
                SubmitPerson = false;
                SubmitTransaction = false;
                ReadOnlyCombobox = false;
                ReadOnly = true;
            }
            else
            {
                LabelVisibility = false;
                ReadOnly = false;
                VerifyButton = true;
                SubmitPerson = true;
                SubmitTransaction = true;
                ReadOnlyCombobox = true;
                ChequeTransaction = new ChequeTransaction();
            }
            VerifyCommand = new Command(VerifyTapped);
            TakePhotoTappedCommand = new Command(TakePhotoTapped);
            SubmitPersonDetailCommand = new Command(SubmitButtonForPersonTapped);
            ChequeImageTappedCommand = new Command(ChequeImageTapped);
            SubmitTransactionDetailCommand = new Command(SubmitButtonForTransactionTapped);
            SelectedIndex = 0;
            VerifyTabSelectedDate = null;
            //ChequeTransaction.DateOfSubmission = null;
            //ChequeTransaction.DOB = null;
            //ChequeTransaction.DateOnCheque = null;
            TransactionSelectedDate = null;
        }

        private async void SubmitButtonForTransactionTapped(object obj)
        {
            var message = ValidateTransaction();
            if (!string.IsNullOrWhiteSpace(message))
            {
                await Application.Current.MainPage.DisplayAlert("Error", message, "Ok", "Cancel");
            }
            else
            {
                if (ChequeTransaction.RemainingAmount == null || ChequeTransaction.RemainingAmount == "0")
                {
                    ChequeTransaction.RemainingAmount = "0";
                    ChequeTransaction.Status = "Closed";
                    ChequeTransaction.DateOfSubmission = ChequeTransaction.DateOfSubmission;
                }
                else
                {
                    ChequeTransaction.Status = "Remaining Amount Left";
                    ChequeTransaction.DateOfSubmission = ChequeTransaction.DateOfSubmission;
                }
                await SaveTransactionContent();
                var page = FindPageByType(typeof(HistoryPage));
                var vm = (HistoryViewModel)page.BindingContext;
                vm.HistoryItem.Insert(0, ChequeTransaction);
                await vm.LoadData();
                await App.navigationPage.PopAsync();
                ChequeTransaction = new ChequeTransaction();
                SelectedIndex = 0;
                ClearValues();

                
            }
        }

        private void ClearValues()
        {
            var page = FindPageByType(typeof(Dashboard));
            if (page != null)
            {
                
                var dashboard = page as Dashboard;
                dashboard.ClearValues(); 
            }
        }

        private async Task SaveTransactionContent()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Transaction Deatils", "Do you want to continue?", "OK", "Cancel");
            if (isUserAccept)
            {
                await App.Database.SaveItemAsync(ChequeTransaction);
            }
        }
        private async void ChequeImageTapped(object obj)
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
                    ChequeTransaction.ChequeImageUrl = Helper.Settings.StreamToBase64(file.GetStreamWithImageRotatedForExternalStorage());
                }
            }
            catch (Exception ex)
            {

            }
            
        }
        private async void SubmitButtonForPersonTapped(object obj)
        {
            var message = ValidatePerson();
            if (!string.IsNullOrWhiteSpace(message))
            {
                await Application.Current.MainPage.DisplayAlert("Error", message, "Ok", "Cancel");
            }
            else
            {
                ChequeTransaction.DOB = ChequeTransaction.DOB;
                await SavePersonDetailsContent();
                SelectedIndex = 2;
                PersonDetailSelectedDate = null;
            }
        }

        private async Task SavePersonDetailsContent()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Verify Person Deatils", "Do you want to continue?", "OK", "Cancel");
            if (isUserAccept)
            {
                await App.Database.SavePersonAsync(ChequeTransaction);
            }
        }
        private async void VerifyTapped(object obj)
        {
            var message = Validate();
            if (!string.IsNullOrWhiteSpace(message))
            {
                await Application.Current.MainPage.DisplayAlert("Error", message, "Ok", "Cancel");
            }
            else
            {
                ChequeTransaction.DateOnCheque = ChequeTransaction.DateOnCheque;
                await SaveVerifyTabContent();
                SelectedIndex = 1;
            }
        }

        private async Task SaveVerifyTabContent()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Verify Cheque Deatils", "Do you want to continue?", "OK", "Cancel");
            if (isUserAccept)
            {
                await App.Database.SaveItemAsync(ChequeTransaction);
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
                    ChequeTransaction.ImageUrl = Helper.Settings.StreamToBase64(file.GetStreamWithImageRotatedForExternalStorage());
                }
            }
            catch (Exception ex)
            {

            }
        }

        public override string Validate()
        {
            var message = new StringBuilder();
            if (string.IsNullOrWhiteSpace(ChequeTransaction.ChequeNumber))
            {
                message.AppendLine("Cheque Number is missing");
            }
            if (string.IsNullOrWhiteSpace(ChequeTransaction.ToPersonName))
            {
                message.AppendLine("Person Name is missing");
            }
            
            //if (string.IsNullOrWhiteSpace((ChequeTransaction.DateOnCheque).ToString()))
            //{
            //    message.AppendLine("Date on cheque is missing");
            //}
            
            if (string.IsNullOrWhiteSpace(ChequeTransaction.Type))
            {
                message.AppendLine("Cheque type is missing");
            }

            if (string.IsNullOrWhiteSpace(ChequeTransaction.Amount))
            {
                message.AppendLine("Amount is missing");
            }

            return message.ToString();
        }

        public override string ValidatePerson()
        {
            var message = new StringBuilder();

            if (string.IsNullOrWhiteSpace(ChequeTransaction.Name))
            {
                message.AppendLine("Name is missing");
            }

            if (string.IsNullOrWhiteSpace(ChequeTransaction.Address))
            {
                message.AppendLine("Address is missing");
            }

            if (string.IsNullOrWhiteSpace(ChequeTransaction.Mobile))
            {
                message.AppendLine("Mobile Number is missing");
            }

            if (string.IsNullOrWhiteSpace((ChequeTransaction.DOB).ToString()))
            {
                message.AppendLine("Date of birth is missing");
            }

            if (string.IsNullOrWhiteSpace(ChequeTransaction.IdentityProof))
            {
                message.AppendLine("ID type is missing");
            }

            return message.ToString();
        }

        public override string ValidateTransaction()
        {
            var message = new StringBuilder();

            if (string.IsNullOrWhiteSpace(ChequeTransaction.To))
            {
                message.AppendLine("Name is missing");
            }

            if (string.IsNullOrWhiteSpace((ChequeTransaction.DateOfSubmission).ToString()))
            {
                message.AppendLine("Date of submission is missing");
            }

            if (string.IsNullOrWhiteSpace(ChequeTransaction.GivenAmount))
            {
                message.AppendLine("Amount is missing");
            }

            return message.ToString();
        }

    }
}
