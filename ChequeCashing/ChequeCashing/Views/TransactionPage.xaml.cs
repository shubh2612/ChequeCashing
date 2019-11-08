using ChequeCashing.Abstractions;
using ChequeCashing.Model;
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
    public partial class TransactionPage : BaseContentPage
    {
        public TransactionPage(ChequeTransaction chequeTransaction)
        {
            InitializeComponent();
            BindingContext = new TransactionViewModel(chequeTransaction);
            CustomDatePicker.MinimumDate = DateTime.Now;
        }

        private void CustomDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var date = ((DatePicker)sender).Date;
            ((TransactionViewModel)this.BindingContext).SelectedDate = date;
        }
    }
}