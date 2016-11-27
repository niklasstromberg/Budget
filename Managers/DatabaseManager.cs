using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Data.SQLite;

namespace Budget
{
    public static class DatabaseManager
    {
        private static string database = "Data Source=Budget.sqlite;Version=3";

        public static bool DBExists()
        {
            try
            {
                using (var con = new SqliteConnection(database))
                {
                    con.Open();
                    con.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int HasHouseholds()
        {
            int count;
            using (var con = new SqliteConnection(database))
            {
                con.Open();
                SqliteCommand cmd = new SqliteCommand("SELECT count(*) FROM Household");
                count = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            return count;
        }

        private static void CreateDatabase()
        {
            try
            {
                string path = Path.Combine(System.Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Budget.sqlite");
                SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            }
            catch
            {
                
            }
        }

    }
}
