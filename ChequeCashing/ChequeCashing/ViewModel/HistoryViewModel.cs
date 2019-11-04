using ChequeCashing.Interface;
using ChequeCashing.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChequeCashing.ViewModel
{
    public class HistoryViewModel : BaseViewModel
    {
        public SQLiteConnection conn;
        public HistoryViewModel regmodel;

        private ObservableCollection<ChequeTransaction> _historyItem;
        public ObservableCollection<ChequeTransaction> HistoryItem
        {
            get { return _historyItem; }
            set { _historyItem = value; }
        }

        public HistoryViewModel()
        {
            //conn = DependencyService.Get<ISqlite>().GetConnection();
            //conn.CreateTable<ChequeTransaction>();
            //LoadData();
        }

        public async override Task LoadData()
        {
            var items = (from x in conn.Table<ChequeTransaction>() orderby x.Id descending select x).ToList();
            HistoryItem = new ObservableCollection<ChequeTransaction>(items);
        }

    }
}
