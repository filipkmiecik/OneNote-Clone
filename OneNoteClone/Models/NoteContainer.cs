using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OneNoteClone.Models
{
    public class NoteContainer : INotifyPropertyChanged
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

		private string name;

		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}

		private int userId;

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

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string value)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(value));
		}
	}
}
