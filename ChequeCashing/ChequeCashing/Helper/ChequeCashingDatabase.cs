using ChequeCashing.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ChequeCashing.Helper
{
    public class ChequeCashingDatabase
    {
        SQLiteAsyncConnection database;
        public ChequeCashingDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ChequeTransaction>().Wait();
            database.CreateTableAsync<Person>().Wait();
        }

        public Task<List<ChequeTransaction>> GetItemsAsync()
        {
            return database.Table<ChequeTransaction>().ToListAsync();
        }

        public Task<List<ChequeTransaction>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<ChequeTransaction>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<ChequeTransaction> GetItemAsync(int id)
        {
            return database.Table<ChequeTransaction>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ChequeTransaction item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> SavePersonAsync(Person item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ChequeTransaction item)
        {
            return database.DeleteAsync(item);
        }
    }
}
