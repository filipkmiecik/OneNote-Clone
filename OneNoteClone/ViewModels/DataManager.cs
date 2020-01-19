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
        public static string databaseFile = Path.Combine(Environment.CurrentDirectory, "notesDatabase");


        /// <summary>
        /// Accessing database and Inserting items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entry"></param>
        /// <returns>true </returns>
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
