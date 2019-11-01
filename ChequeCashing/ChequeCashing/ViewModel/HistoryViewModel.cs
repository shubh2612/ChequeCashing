using ChequeCashing.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ChequeCashing.ViewModel
{
    public class HistoryViewModel : BaseViewModel
    {
        private List<ChequeTransaction> _historyItem;

        public List<ChequeTransaction> HistoryItem
        {
            get { return _historyItem; }
            set { _historyItem = value; }
        }

        public HistoryViewModel()
        {
            LoadData();
        }

        public async override Task LoadData()
        {
            HistoryItem = new List<ChequeTransaction>
            {
                new ChequeTransaction{ ChequeNumber = "12345", Status = "Done", DateOfSubmission ="10/10/2019", RemainingAmount = "0"},
                new ChequeTransaction{ ChequeNumber = "23145", Status = "Remaining Amount Left", DateOfSubmission ="11/10/2019", RemainingAmount = "2000"},
                new ChequeTransaction{ ChequeNumber = "36541", Status = "Done", DateOfSubmission ="12/10/2019", RemainingAmount = "0"},
                new ChequeTransaction{ ChequeNumber = "74125", Status = "Done", DateOfSubmission ="13/10/2019", RemainingAmount = "0"}
            };
        }

    }
}
