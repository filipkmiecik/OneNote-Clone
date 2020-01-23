using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneNoteClone.ViewModels.Commands
{
    public class StartEditCommand : ICommand
    {
        public NoteVM Vm { get; set; }
        public event EventHandler CanExecuteChanged;

        public StartEditCommand(NoteVM vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.EditNoteContainer();
        }
    }
}
