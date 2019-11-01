using ChequeCashing.Interface;
using ChequeCashing.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChequeCashing.Helper
{
    public class DatabaseHelper
    {
        static SQLiteConnection sqliteconnection;
        public const string DbFileName = "RouteDetails.db";

        public DatabaseHelper()
        {
            sqliteconnection = DependencyService.Get<ISqlite>().GetConnection();
            sqliteconnection.CreateTable<ChequeTransaction>();
        }

        // Get All Contact data       
        //public List<ChequeTransaction> GetAllData()
        //{
        //    return (from data in sqliteconnection.Table<ChequeTransaction>()
        //            select data).ToList();
        //}

        public void InsertData(ChequeTransaction route)
        {
            sqliteconnection.Insert(route);
        }
    }
}
