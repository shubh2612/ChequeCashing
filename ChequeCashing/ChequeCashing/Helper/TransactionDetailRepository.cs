using ChequeCashing.Interface;
using ChequeCashing.Model;
using System.Collections.Generic;

namespace ChequeCashing.Helper
{
    public class TransactionDetailRepository : ITransactionDetailsRepository
    {
        DatabaseHelper _databaseHelper;
        public TransactionDetailRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }
        public List<ChequeTransaction> GetAllData()
        {
            return _databaseHelper.GetAllData();
        }

        public void InsertData(ChequeTransaction cheque)
        {
            _databaseHelper.InsertData(cheque);
        }

    }
}
