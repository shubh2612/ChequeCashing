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
    public partial class PersonDetailsPage : ContentPage
    {
        public PersonDetailsPage()
        {
            InitializeComponent();
            BindingContext = new PersonDetailsViewModel();
        }

        private void CustomDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var date = ((DatePicker)sender).Date;
            ((PersonDetailsViewModel)this.BindingContext).SelectedDate = date;
        }
    }
}