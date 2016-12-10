using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Reflection;
using Windows.Storage;
using Budget.Models;
using Microsoft.Data.Entity;
using Budget.Interfaces;

namespace Budget.Managers
{
    public static class DatabaseManager
    {
        //private static string database = "Data Source=Budget.sqlite;Version=3";
        private static string _path = Path.Combine(SetPath(), "Budget.sqlite");
        private static SQLite.Net.SQLiteConnection connection;// = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        private static bool _databaseExists { get; set; } = false;

        private static string SetPath()
        {
            var v = ApplicationData.Current.LocalFolder.Path; // RoamingFolder för automatisk sync mellan inloggade devices
            return v.ToString();
        }

        // Public properties
        public static string path
        {
            get
            {
                return _path;
            }
        }


        public static bool databaseExists
        {
            get
            {
                return _databaseExists;
            }
        }

        // Tests the Database connection
        private static void DBCheck()
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    //con.Close();
                    _databaseExists = true;
                }
            }
            catch
            {
                _databaseExists = false;

            }
        }

        // Creates the database, and checks if it worked
        private static void CreateDatabase()
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    db.Database.EnsureCreated();
                }



                //connection = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), _path);
                //string str = connection.DatabasePath;
                //connection.Execute("CREATE DATABASE Budget");
            }
            catch (Exception ex)
            {
                // handle error
            }
            DBCheck();
        }

        // Initial setup of the database. Called from MainPage.
        public static void DatabaseSetup()
        {
            while (!_databaseExists)
            {
                CreateDatabase();
            }

            // Vi är säkra på att databasen är skapad. Skapa tabellerna
            using (connection)
            {
                connection.CreateTable<Household>();
                connection.CreateTable<Person>();
                connection.CreateTable<Category>();
                connection.CreateTable<Recipient>();
                connection.CreateTable<Expense>();
                connection.CreateTable<Income>();
            }

        }

        #region Households

        public static List<Household> GetHouseholds()
        {
            using (var db = new BudgetContext())
            {
                var query = db.Households.ToList().OrderBy(h => h.HouseholdName);
                return query.ToList();
            }
        }

        public static Household GetHousehold(int id)
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    return db.Households.First(x => x.HouseholdId == id);
                }
            }
            catch (Exception ex)
            {
                // Handle error
            }
            return null;
        }


        // Returns the number of rows of the Household table
        public static int HasHouseholds()
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    var query = db.Households.Count();
                    return query;
                }
            }
            catch (Exception ex)
            {
                // Handle error
            }
            return -1;

        }


        public static bool SaveHousehold(string name)
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    var household = new Household { HouseholdName = name };
                    db.Households.Add(household);
                    db.Entry(household).State = EntityState.Added;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                // Handle error
            }
            return false;
        }

        public static bool DeleteHousehold(int id)
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    var household = db.Households.First(x => x.HouseholdId == id);
                    db.Households.Remove(household);
                    db.Entry(household).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                // Handle error
            }
            return false;
        }

        public static bool UpdateHousehold(int id, string name)
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    var household = db.Households.First(x => x.HouseholdId == id);
                    household.HouseholdName = name;
                    db.Households.Update(household);
                    db.Entry(household).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                // Handle error
            }
            return false;
        }

        public static List<Person> GetPersonsInHousehold(Household household)
        {
            List<Person> result = new List<Person>();
            try
            {
                var con = new SqliteConnection("DataSource=Budget.db");
                con.Open();
                string sql = "Select * from Person Where HouseholdHouseholdId = " + household.HouseholdId;
                SqliteCommand cmd = new SqliteCommand(sql, con);
                var toRead = cmd.ExecuteReader();
                while (toRead.Read())
                {
                    //result.Add()
                }
                using (var db = new BudgetContext())
                {
                    //result = db.Persons.Where(p => p.HouseholdHouseholdID == household.HouseholdId).ToList();
                }
                return result;
            }
            catch (Exception ex)
            {
                // Handle error
            }
            return result;
        }



        #endregion

        #region Persons

        public static Person GetPerson(int id)
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    return db.Persons.First(x => x.PersonId == id);
                }
            }
            catch (Exception ex)
            {
                // Handle error
            }
            return null;
        }

        public static List<Person> GetPersons()
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    return db.Persons.ToList();
                }
            }
            catch (Exception ex)
            {
                // Handle error
            }
            return null;
        }

        public static bool SavePerson(string name)
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    var person = new Person { Name = name };
                    db.Persons.Add(person);
                    db.Entry(person).State = EntityState.Added;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                // Handle error
            }
            return false;
        }

        public static bool DeletePerson(int id)
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    var person = db.Persons.First(x => x.PersonId == id);
                    db.Persons.Remove(person);
                    db.Entry(person).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                // Handle error
            }
            return false;
        }

        public static bool UpdatePerson(int id, string name)
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    var person = db.Persons.First(x => x.PersonId == id);
                    person.Name = name;
                    db.Persons.Update(person);
                    db.Entry(person).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                // Handle error
            }
            return false;
        }

        public static bool AttachPerson(Person person, Household household)
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    if (household.PersonsInHousehold == null)
                    {
                        household.PersonsInHousehold = new List<Person>();
                    }
                    household.PersonsInHousehold.Add(person);
                    db.Households.Update(household);
                    db.Entry(household).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                // Handle error
            }
            return false;
        }

        public static bool DetachPerson(Person person, Household household)
        {
            try
            {
                using (var db = new BudgetContext())
                {
                    household.PersonsInHousehold.Remove(person);
                    db.Households.Update(household);
                    db.Entry(household).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                // Handle error
            }
            return false;
        }

        #endregion


    }
}
