using ChequeCashing.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChequeCashing.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            BindingContext = new DashboardViewModel();
        }

        private void HistoryClicked(object sender, EventArgs e)
        {
            App.navigationPage.PushAsync(new HistoryPage());
        }

        private void ChequeDetailsButtonClicked(object sender, EventArgs e)
        {
            App.navigationPage.PushAsync(new VerifyPage());
        }

        private void PersonDetailsButtonClicked(object sender, EventArgs e)
        {
            App.navigationPage.PushAsync(new PersonDetailsPage());
        }

        private void TransactionClicked(object sender, EventArgs e)
        {
            App.navigationPage.PushAsync(new TransactionPage());
        }
    }
}