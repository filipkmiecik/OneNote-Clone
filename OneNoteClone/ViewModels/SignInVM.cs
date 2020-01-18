using OneNoteClone.Models;
using OneNoteClone.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNoteClone.ViewModels
{
    public class SignInVM
    {
		private User user;

		public User User
		{
			get { return user; }
			set { user = value; }
		}
		public SignUp SignUp { get; set; }
		public SignIn SignIn { get; set; }

		public SignInVM()
		{
			SignUp = new SignUp(this);
			SignIn = new SignIn(this);
		}
	}
}
