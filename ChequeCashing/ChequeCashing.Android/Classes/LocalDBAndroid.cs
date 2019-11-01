using ChequeCashing.Droid.Classes;
using ChequeCashing.Interface;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalDBAndroid))]
namespace ChequeCashing.Droid.Classes
{
    public class LocalDBAndroid : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "Mydatabase";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}