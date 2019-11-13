using ChequeCashing.Model;
using ChequeCashing.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChequeCashing.ViewModel
{
    public class HistoryViewModel : BaseViewModel
    {
        public ICommand ListItemTappedCommand { get; set; }

        private ChequeTransaction chequeTransaction;

        public ChequeTransaction ChequeTransaction
        {
            get { return chequeTransaction; }
            set { chequeTransaction = value; OnPropertyChanged(nameof(ChequeTransaction)); }
        }


        private List<ChequeTransaction> _historyItem;
        public List<ChequeTransaction> HistoryItem
        {
            get { return _historyItem; }
            set { _historyItem = value; OnPropertyChanged(nameof(HistoryItem)); }
        }

        public HistoryViewModel()
        {
            HistoryItem = new List<ChequeTransaction>();
            ListItemTappedCommand = new Command(ListItemTapped);

        }

        private async void ListItemTapped(object obj)
        {
            var e = obj as Syncfusion.ListView.XForms.ItemTappedEventArgs;
            var item = (ChequeTransaction)e.ItemData;
            await App.navigationPage.PushAsync(new Dashboard(item));
        }

        public async override Task LoadData()
        {
            var data = (await App.Database.GetItemsAsync());
            if(data == null){
                await Application.Current.MainPage.DisplayAlert("Error","DB is null", "Ok");
            }
            else
            {
                var items = (from x in data orderby x.Id descending select x).ToList();
                if(items == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Unable to order the list", "Ok");
                }
                else
                {
                    HistoryItem = items;
                }
            }
        }
    }
}
