using OneNoteClone.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneNoteClone.ViewModels.Commands
{
    public class SignUp : ICommand
    {
        public SignInVM VM {get; set;}
        public event EventHandler CanExecuteChanged;

        public SignUp(SignInVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //sign in logic territory, beware
        }
    }
}
