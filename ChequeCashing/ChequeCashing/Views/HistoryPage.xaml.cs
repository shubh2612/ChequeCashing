using ChequeCashing.Abstractions;
using ChequeCashing.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChequeCashing.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : BaseContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
            BindingContext = new HistoryViewModel();
        }
    }
}