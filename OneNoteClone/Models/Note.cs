using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OneNoteClone.Models
{
     public class Note : INotifyPropertyChanged
    {
		private int id;

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

		private string title;

		public string Title
		{
			get { return title; }
			set
			{
				title = value;
				OnPropertyChanged("Title");
			}
		}

		private int containerId;

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

		private DateTime creationDate;

		public DateTime CreationDate
		{
			get { return creationDate; }
			set
			{
				creationDate = value;
				OnPropertyChanged("CreationDate");
			}
		}

		private	DateTime updateDate;

		public DateTime UpdateDate
		{
			get { return updateDate; }
			set 
			{ 
				updateDate = value;
				OnPropertyChanged("UpdateData");
			}
		}

		private string fileDirectory;

		public string FileDirectory
		{
			get { return fileDirectory; }
			set 
			{ 
				fileDirectory = value;
				OnPropertyChanged("FileDirectory");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string value)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(value));
		}

	}
}
