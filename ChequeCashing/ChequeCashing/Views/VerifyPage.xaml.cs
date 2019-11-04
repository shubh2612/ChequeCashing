using ChequeCashing.Model;
using ChequeCashing.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace ChequeCashing.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerifyPage : ContentPage
    {
        public VerifyPage()
        {
            InitializeComponent();
            BindingContext = new VerifyViewModel();
        }

        private void CustomDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var date = ((DatePicker)sender).Date;
            ((VerifyViewModel)this.BindingContext).SelectedDate = date;
        }
    }
}