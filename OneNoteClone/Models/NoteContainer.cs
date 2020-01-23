using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OneNoteClone.Models
{
    /// <summary>
    /// This class is template object of NoteContainer that will be inserted into DB.
    /// </summary>
    public class NoteContainer : INotifyPropertyChanged
	{   
        /// <summary>
        /// PK of our note Container
        /// </summary>
		private int id;

        /// <summary>
        /// Public getter/setter of id
        /// </summary>
		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get { return id; }
			set
			{
				id = value;
				OnPropertyChanged("Id");
			}
		}

        /// <summary>
        /// Name of our new NoteContainer
        /// </summary>
		private string name;

        /// <summary>
        /// Public getter/setter of mame
        /// </summary>
		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}

        /// <summary>
        /// Defines whitch User have access to this noteContainer
        /// </summary>
		private int userId;


        /// <summary>
        /// Public getter/setter of userId
        /// </summary>
		[Indexed]
		public int UserId
		{
			get { return userId; }
			set
			{
				userId = value;
				OnPropertyChanged("UserId");
			}
		}

        /// <summary>
        /// Event that's triggered when property is changed
        /// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///  Update ???
        /// </summary>
        /// <param name="value"></param>
		private void OnPropertyChanged(string value)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(value));
		}
	}
}
