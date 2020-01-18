using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneNoteClone.ViewModels.Commands
{
    public class SignIn : ICommand
    {
        public SignInVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public SignIn(SignInVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // 4 later
        }
    }
}
