using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNoteClone.ViewModels
{
    public class DataManager
    {
        private static string databaseFile = Path.Combine(Environment.CurrentDirectory, "notesDatabase");

        public static bool Insert<T>(T entry)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(databaseFile))
            {
                connection.CreateTable<T>();
                int rowCount = connection.Insert(entry);
                if (rowCount > 0)
                    result = true;
            }

            return result;
        }
        public static bool Update<T>(T entry)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(databaseFile))
            {
                connection.CreateTable<T>();
                int rowCount = connection.Update(entry);
                if (rowCount > 0)
                    result = true;
            }

            return result;
        }
        public static bool Delete<T>(T entry)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(databaseFile))
            {
                connection.CreateTable<T>();
                int rowCount = connection.Delete(entry);
                if (rowCount > 0)
                    result = true;
            }

            return result;
        }
    }
}
