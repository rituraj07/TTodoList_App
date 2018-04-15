using System;
using System.IO;
using Xamarin.Forms;
using db.Droid;

[assembly: Dependency(typeof(SQLite_Droid))]
namespace db.Droid
{
    public class SQLite_Droid : ISqlite
    {
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var filename = "Student.sqlite";
            var documentspath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);
            return connection;
        }
    }
}