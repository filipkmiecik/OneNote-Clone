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
    /// This class is template object of Note that is inserted into DB.
    /// </summary>
     public class Note : INotifyPropertyChanged
    {
        /// <summary>
        /// Primary key, id.
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
        /// Name of Note
        /// </summary>
		private string title;

        /// <summary>
        /// Public getter/setter of Name
        /// </summary>
		public string Title
		{
			get { return title; }
			set
			{
				title = value;
				OnPropertyChanged("Title");
			}
		}

        /// <summary>
        /// Foreign key, that's need to sort notes to proper noteContainers
        /// </summary>
		private int containerId;

        /// <summary>
        /// Public getter/setter of contaierId
        /// </summary>
		[Indexed]
		public int ContainerId
		{
			get { return containerId; }
			set
			{
				containerId = value;
				OnPropertyChanged("ContainerId");
			}
		}

        /// <summary>
        /// Defines date of creation
        /// </summary>
		private DateTime creationDate;


        /// <summary>
        /// Public getter/setter of creationDate
        /// </summary>
		public DateTime CreationDate
		{
			get { return creationDate; }
			set
			{
				creationDate = value;
				OnPropertyChanged("CreationDate");
			}
		}

        /// <summary>
        /// Defines date of last update
        /// </summary>
		private	DateTime updateDate;

        /// <summary>
        ///  Public getter/setter of updateDate
        /// </summary>
		public DateTime UpdateDate
		{
			get { return updateDate; }
			set 
			{ 
				updateDate = value;
				OnPropertyChanged("UpdateData");
			}
		}

        /// <summary>
        /// Defines where file is located.
        /// </summary>
		private string fileDirectory;

        /// <summary>
        /// Public getter/setter of filer dirctory
        /// </summary>
		public string FileDirectory
		{
			get { return fileDirectory; }
			set 
			{ 
				fileDirectory = value;
				OnPropertyChanged("FileDirectory");
			}
		}

        /// <summary>
        ///  Event that's triggered when property is changed
        /// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method that update our note ???
        /// ??? 
        /// </summary>
        /// <param name="value"></param>
		private void OnPropertyChanged(string value)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(value));
		}

	}
}
