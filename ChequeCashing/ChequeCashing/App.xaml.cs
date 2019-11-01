using ChequeCashing.Views;
using Xamarin.Forms;

namespace ChequeCashing
{
    public partial class App : Application
    {
        public static NavigationPage navigationPage { get; set; }
        public App()
        {
            InitializeComponent();
            navigationPage = new NavigationPage(new Dashboard());
            navigationPage.BarBackgroundColor = Color.FromHex("#f54e5e");
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
