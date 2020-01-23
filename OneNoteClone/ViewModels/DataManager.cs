using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNoteClone.ViewModels
{   
    /// <summary>
    /// Class to manage local database.
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// Contains database path
        /// </summary>
        public static string databaseFile = Path.Combine(Environment.CurrentDirectory, "notesDatabase");

        /// <summary>
        /// With this method you can insert entry to proper NoteContainer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entry">Proper entry</param>
        /// <returns></returns>
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

        /// <summary>
        /// With this method you can update database table of NoteContainer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entry"></param>
        /// <returns></returns>
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

        /// <summary>
        /// With this method you can delete proper table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entry"></param>
        /// <returns></returns>
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
