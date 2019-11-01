using ChequeCashing.Model;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChequeCashing.ViewModel
{
    public class VerifyViewModel : BaseViewModel
    {

        public ICommand VerifyCommand { get; set; }

        private string _selectedDate;

        public string SelectedDate
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

        private void VerifyTapped(object obj)
        {
            SaveContent();
        }

        private void SaveContent()
        {
            // var saveContent = new ChequeTransaction();
            //saveContent.ChequeNumber = ChequeTransaction.ChequeNumber;
            //saveContent.ToPersonName = ChequeTransaction.ToPersonName;
            //saveContent.DateOfSubmission = SelectedDate;
            //saveContent.Type = ChequeTransaction.Type;
        }
    }
}
