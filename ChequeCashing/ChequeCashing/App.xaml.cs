using ChequeCashing.Helper;
using ChequeCashing.Model;
using ChequeCashing.Views;
using System;
using System.IO;
using Xamarin.Forms;

namespace ChequeCashing
{
    public partial class App : Application
    {
        static ChequeCashingDatabase database;
        public static ChequeCashingDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ChequeCashingDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ChequeCashingSQLite.db3"));
                }
                return database;
            }
        }

        //static Person PersonDatabase;
        //public static Person Database2
        //{
        //    get
        //    {
        //        if (PersonDatabase == null)
        //        {
        //            PersonDatabase = new PersonDataBase(
        //              Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ChequeCashingSQLite.db3"));
        //        }
        //        return PersonDatabase;
        //    }
        //}

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
