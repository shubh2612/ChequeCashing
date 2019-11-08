using ChequeCashing.Helper;
using ChequeCashing.Model;
using ChequeCashing.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChequeCashing.ViewModel
{
    public class TransactionViewModel : BaseViewModel
    {    
        public ICommand SubmitCommand { get; set; }

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

        public TransactionViewModel(ChequeTransaction chequeTransaction)
        {
            ChequeTransaction = chequeTransaction;
            SubmitCommand = new Command(SubmitButtonTapped);
        }

        private async void SubmitButtonTapped(object obj)
        {
            if (ChequeTransaction.RemainingAmount == null || ChequeTransaction.RemainingAmount == "0")
            {
                ChequeTransaction.RemainingAmount = "0";
                ChequeTransaction.Status = "Closed";
                ChequeTransaction.DateOfSubmission = SelectedDate;
            }
            else
            {
                ChequeTransaction.Status = "Remaining Amount Left";
                ChequeTransaction.DateOfSubmission = SelectedDate;
            }
            await SaveContent();
        }

        private async Task SaveContent()
        {
            //var _transactionDetailRepository = new TransactionDetailRepository();
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Transaction Deatils", "Do you want to continue?", "OK", "Cancel");
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
