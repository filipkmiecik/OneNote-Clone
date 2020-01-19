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
		public SignUpCommand SignUp { get; set; }
		public SignInCommand SignIn { get; set; }

		public SignInVM()
		{
			SignUp = new SignUpCommand(this);
			SignIn = new SignInCommand(this);
		}
	}
}
