using ChequeCashing.Interface;
using ChequeCashing.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChequeCashing.ViewModel
{
    public class HistoryViewModel : BaseViewModel
    {
        //private SQLiteConnection conn;
        //public HistoryViewModel regmodel;

        private List<ChequeTransaction> _historyItem;
        public List<ChequeTransaction> HistoryItem
        {
            get { return _historyItem; }
            set { _historyItem = value; OnPropertyChanged(nameof(HistoryItem)); }
        }

        public HistoryViewModel()
        {
            //conn = DependencyService.Get<ISqlite>().GetConnection();
            //conn.CreateTable<ChequeTransaction>();
            //conn.CreateTable<Person>();
            HistoryItem = new List<ChequeTransaction>();
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

           
            //HistoryItem = new List<ChequeTransaction> {
            //    new ChequeTransaction{ChequeNumber = "123456", Status = "Done", DateOfSubmission = DateTime.UtcNow, RemainingAmount = "0"}
            //};
        }

    }
}
