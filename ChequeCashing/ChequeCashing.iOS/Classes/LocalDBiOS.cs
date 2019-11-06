using ChequeCashing.Helper;
using ChequeCashing.Interface;
using ChequeCashing.iOS.Classes;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalDBiOS))]
namespace ChequeCashing.iOS.Classes
{
    class LocalDBiOS : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            //string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder   
            //string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder   
            //var path = Path.Combine(libraryPath, DatabaseHelper.DbFileName);
            //// Create the connection   
            //var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            //var conn = new SQLiteConnection(path, plat);
            //// Return the database connection   
            //return conn;

            //var dbase = "Mydatabase";
            ////var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");
            //var path = Path.Combine(dbpath, dbase);
            //var connection = new SQLiteConnection(path);
            //return connection;

            //var sqliteFilename = "MyDatabase.db3";

            //string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            //string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder instead
            //var path = Path.Combine(libraryPath, sqliteFilename);
            //var connection = new SQLiteConnection(path);
            //return connection;

            var dbName = "ChequeCashingDB.db3";
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}