using ChequeCashing.Abstractions;
using ChequeCashing.Controls;
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
    public partial class Dashboard : BaseContentPage
    {
        public Dashboard(ChequeTransaction item)
        {
            var cheque = new DashboardViewModel(item);
            InitializeComponent();
            BindingContext = cheque;
            CreateDatePicker(item);

            
        }

        private void CreateDatePicker(ChequeTransaction item)
        {
            var DatePickerForVerifyTab = new CalenderDatePicker()
            {
                HorizontalOptions = LayoutOptions.Fill,
                FontSize = 16,
                HeightRequest = 50,
                PlaceHolderText = "DD/MM/YY",
                Format = "dd/MM/yy",
                FontFamily = Device.RuntimePlatform == Device.iOS ? "Montserrat-Regular" : Device.RuntimePlatform == Device.Android ? "Montserrat-Regular.ttf#Montserrat-Regular" : "Assets/Montserrat-Regular.ttf#Montserrat-Regular",
                TextColor = (Color)App.Current.Resources["Gray-900"], 
            };
            if (item != null)
            {
                DatePickerForVerifyTab.PlaceHolderText = item.DateOnCheque.ToString("dd/MM/yy");
                DatePickerForVerifyTab.IsEnabled = false;
            }
            CustomDatePickerForVerifyTab.Content = new StackLayout
            {
                Children =
                {
                     DatePickerForVerifyTab
                }
            };

            DatePickerForVerifyTab.DateSelected += CustomDatePickerVerifyTab_DateSelected;
            

            var DatePickerForPersonDeytail = new CalenderDatePicker()
            {
                HorizontalOptions = LayoutOptions.Fill,
                FontSize = 16,
                HeightRequest = 50,
                PlaceHolderText = "DD/MM/YY",
                Format = "dd/MM/yy",
                FontFamily = Device.RuntimePlatform == Device.iOS ? "Montserrat-Regular" : Device.RuntimePlatform == Device.Android ? "Montserrat-Regular.ttf#Montserrat-Regular": "Assets/Montserrat-Regular.ttf#Montserrat-Regular",
                TextColor = (Color)App.Current.Resources["Gray-900"],
            };
            if (item != null)
            {
                DatePickerForPersonDeytail.PlaceHolderText = item.DOB.ToString("dd/MM/yy");
                DatePickerForPersonDeytail.IsEnabled = false;
            }
            CustomDatePickerForPersonDeytailTab.Content = new StackLayout
            {

                Children =
                {
                        DatePickerForPersonDeytail
                }
            };

            DatePickerForPersonDeytail.DateSelected += CustomDatePickerPersonTab_DateSelected;

            var DatePickerForTransaction = new CalenderDatePicker()
            {
                HorizontalOptions = LayoutOptions.Fill,
                FontSize = 16,
                HeightRequest = 50,
                PlaceHolderText = "DD/MM/YY",
                Format = "dd/MM/yy",
                FontFamily = Device.RuntimePlatform == Device.iOS ? "Montserrat-Regular" : Device.RuntimePlatform == Device.Android ? "Montserrat-Regular.ttf#Montserrat-Regular" : "Assets/Montserrat-Regular.ttf#Montserrat-Regular",
                TextColor = Color.Red,
            };
            if (item != null)
            {
                DatePickerForTransaction.PlaceHolderText = item.DateOfSubmission.ToString("dd/MM/yy");
                DatePickerForTransaction.IsEnabled = false;
            }
            CustomDatePickerForTransaction.Content = new StackLayout
            {
                Children =
                {
                        DatePickerForTransaction
                }
            };

            DatePickerForTransaction.DateSelected += CustomDatePickerTransactionTab_DateSelected;
        }

        private void CustomDatePickerVerifyTab_DateSelected(object sender, DateChangedEventArgs e)
        {
            var date = ((DatePicker)sender).Date;
            ((DashboardViewModel)this.BindingContext).ChequeTransaction.DateOnCheque = date;
        }

        private void CustomDatePickerPersonTab_DateSelected(object sender, DateChangedEventArgs e)
        {
            var date = ((DatePicker)sender).Date;
            ((DashboardViewModel)this.BindingContext).ChequeTransaction.DOB = date;
        }

        private void CustomDatePickerTransactionTab_DateSelected(object sender, DateChangedEventArgs e)
        {
            var date = ((DatePicker)sender).Date;
            ((DashboardViewModel)this.BindingContext).ChequeTransaction.DateOfSubmission = date;
        }

        internal void ClearValues()
        {
            CustomDatePickerForVerifyTab.Content = null;
            CustomDatePickerForPersonDeytailTab.Content = null;
            CustomDatePickerForTransaction.Content = null;

            CreateDatePicker(null);

        }
    }
}