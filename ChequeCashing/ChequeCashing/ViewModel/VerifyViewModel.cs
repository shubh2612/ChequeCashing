using ChequeCashing.Helper;
using ChequeCashing.Model;
using ChequeCashing.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChequeCashing.ViewModel
{
    public class VerifyViewModel : BaseViewModel
    {

        public ICommand VerifyCommand { get; set; }

        private DateTime _selectedDate;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { _selectedDate = value; OnPropertyChanged(nameof(SelectedDate)); }
        }

        private ChequeTransaction chequeTransaction;

        public ChequeTransaction ChequeTransaction
        {
            get { return chequeTransaction; }
            set { chequeTransaction = value; OnPropertyChanged(nameof(ChequeTransaction)); }
        }


        public VerifyViewModel()
        {
            ChequeTransaction = new ChequeTransaction();
            VerifyCommand = new Command(VerifyTapped);
        }

        private async void VerifyTapped(object obj)
        {
            ChequeTransaction.DateOnCheque = SelectedDate;
            await SaveContent();
        }

        private async Task SaveContent()
        {
            //var _transactionDetailRepository = new TransactionDetailRepository();
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Verify Cheque Deatils", "Do you want to continue?", "OK", "Cancel");
            if (isUserAccept)
            {
                await App.Database.SaveItemAsync(ChequeTransaction);
                var page = FindPageByType(typeof(Dashboard));
                var vm = (DashboardViewModel)page.BindingContext;
                //vm.Item.Insert(0, saveContent);
                await App.navigationPage.PopAsync();
            }
        }
    }
}
