using ChequeCashing.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChequeCashing.ViewModel
{
    class DashboardViewModel : BaseViewModel
    {
        public ICommand ChequeDetailsCommand { get; set; }

        public DashboardViewModel()
        {
            ChequeDetailsCommand = new Command(ChequeDetailsTapped);
        }

        private void ChequeDetailsTapped(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new VerifyPage());
        }
    }
}
