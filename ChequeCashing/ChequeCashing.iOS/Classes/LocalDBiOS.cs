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
            //var plat = new SQLite.;
            //var conn = new SQLiteConnection(path, plat);
            //// Return the database connection   
            //return conn;

            var dbase = "Mydatabase";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}