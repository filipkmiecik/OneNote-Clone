using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OneNoteClone.Models
{
    public class User : INotifyPropertyChanged
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

		private string firstName;

		[MaxLength(30)]
		public string FirstName
		{
			get { return firstName; }
			set
			{
				firstName = value;
				OnPropertyChanged("FirstName");
			}
		}

		private string lastName;

		[MaxLength(30)]
		public string LastName
		{
			get { return lastName; }
			set
			{
				lastName = value;
				OnPropertyChanged("LastName");
			}
		}

		private string username;

		[MaxLength(30)]
		public string Username
		{
			get { return username; }
			set
			{
				username = value;
				OnPropertyChanged("Username");
			}
		}

		private string password;

		public string Password
		{
			get { return password; }
			set
			{
				password = value;
				OnPropertyChanged("Password");
			}
		}

		private string emailAddress;

		public string EmailAddress
		{
			get { return emailAddress; }
			set
			{
				emailAddress = value;
				OnPropertyChanged("EmailAddress");
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
